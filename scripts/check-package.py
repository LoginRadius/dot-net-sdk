#!/usr/bin/env python3
"""Assert the packed nupkg is actually installable.

`dotnet build` and `dotnet test` both pass on a package that cannot be
restored, because neither of them packs. That is not hypothetical: the facade
references the generated client with <ProjectReference>, and without
PrivateAssets="all" NuGet rewrites that into a package dependency on
LoginRadius.Sdk.Internal.OpenApi — a package published nowhere — while omitting
the assembly from lib/. The result restores nowhere but builds fine here.

So the pipeline packs and inspects the result rather than trusting the build.

Usage: python3 scripts/check-package.py <path to .nupkg, or a directory>

A directory is resolved to the single .nupkg inside it. The verify step passes
one because the SDK generator configuration is parsed as plain YAML and never
rendered, so it cannot interpolate the version into a filename.
"""

import os
import re
import sys
import zipfile

# Anything whose id starts with this is one of our own projects and must be
# packed INTO the nupkg, never referenced as an external package.
INTERNAL_PREFIX = "LoginRadius.Sdk.Internal"


def main() -> None:
    if len(sys.argv) != 2:
        sys.exit("usage: check-package.py <path to .nupkg, or a directory>")
    path = sys.argv[1]

    if os.path.isdir(path):
        found = sorted(f for f in os.listdir(path) if f.endswith(".nupkg"))
        if not found:
            sys.exit(f"ERROR: no .nupkg in {path} — did dotnet pack run?")
        if len(found) > 1:
            sys.exit(f"ERROR: {len(found)} .nupkg files in {path}; expected one: {found}")
        path = os.path.join(path, found[0])

    try:
        pkg = zipfile.ZipFile(path)
    except (OSError, zipfile.BadZipFile) as err:
        sys.exit(f"ERROR: cannot read {path}: {err}")

    names = pkg.namelist()
    problems = []

    libs = [n for n in names if n.startswith("lib/") and n.endswith(".dll")]
    if not libs:
        problems.append("no assemblies under lib/ — the package ships nothing")

    for required in ("LoginRadius.Sdk.dll", f"{INTERNAL_PREFIX}.OpenApi.dll"):
        if not any(n.endswith("/" + required) for n in libs):
            problems.append(
                f"{required} is missing from lib/ — a consumer would hit a "
                "missing-assembly error at runtime"
            )

    nuspec = next((n for n in names if n.endswith(".nuspec")), None)
    if nuspec is None:
        problems.append("no .nuspec in the package")
    else:
        spec = pkg.read(nuspec).decode("utf-8")
        for dep in re.findall(r'<dependency\s+id="([^"]+)"', spec):
            if dep.startswith(INTERNAL_PREFIX):
                problems.append(
                    f"nuspec declares a dependency on '{dep}', which is not "
                    "published anywhere — restore will fail. The "
                    "ProjectReference needs PrivateAssets=\"all\"."
                )
        # Metadata the NuGet listing is unusable without.
        for tag in ("licenseExpression|license", "projectUrl", "readme"):
            if not re.search(rf"<({tag})[ >]", spec):
                problems.append(f"nuspec has no <{tag.split('|')[0]}>")

    if problems:
        print(f"\n✗ package check FAILED for {path}\n", file=sys.stderr)
        for p in problems:
            print(f"    {p}", file=sys.stderr)
        print("", file=sys.stderr)
        sys.exit(1)

    print(f"✓ package is self-contained: {len(libs)} assemblies, no unpublished dependencies")


if __name__ == "__main__":
    main()
