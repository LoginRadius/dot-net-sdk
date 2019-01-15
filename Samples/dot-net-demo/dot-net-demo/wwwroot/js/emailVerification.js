const url = location.href;
const params = url.split("?")[1];
const serverUrl = "http://localhost:4000";
let paramsObj = {};
let verificationFunc = function () {
    if (params) {
        paramsObj = JSON.parse('{"' + decodeURI(params.replace(/&/g, "\",\"").replace(/=/g, "\":\"")) + '"}');

        if (paramsObj.vtype === "emailverification") {
            $.ajax({
                method: "GET",
                url: m_options.verifyEmailUrl + "?verification_token=" + paramsObj.vtoken,
                contentType: "application/json",
                error: function (xhr) {
                    $("#minimal-verification-message").text(xhr.responseJSON.value.description);
                    $("#minimal-verification-message").attr("class", "error-message");
                }
            }).done(function () {
                $("#minimal-verification-message").text("Email successfully verified.");
                $("#minimal-verification-message").attr("class", "success-message");
                window.setTimeout(function () { window.location.replace("/");}, 3000);
            });
        } else if (paramsObj.vtype === "oneclicksignin") {
            $.ajax({
                method: "GET",
                url: m_options.pwlessAuthUrl + "?verification_token=" + paramsObj.vtoken,
                contentType: "application/json",
                error: function (xhr) {
                    $("#minimal-verification-message").text(xhr.responseJSON.value.description);
                    $("#minimal-verification-message").attr("class", "error-message");
                }
            }).done(function (ret) {
                localStorage.setItem("LRTokenKey", ret.access_token);
                localStorage.setItem("lr-user-uid", ret.profile.uid);
                window.location.replace("/Home/Profile");
            });
        } else {
            window.location.replace("/");
        }
    } else {
        window.location.replace("/");
    }
};
