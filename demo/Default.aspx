<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="LoginRadiusDemo._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div> <h2>Welcome to LoginRadius Asp.Net Demo</h2>
    <p>Choose an ID Provider to get User Data</p>
</div>
<div style="padding-right: 775px;">

 <%--Interafce will be injected to this div--%>
 <div id="interfacecontainerdiv" class="interfacecontainerdiv"></div>
 </div>

 <%--Template for designing custom interface--%>
 <script type="text/html" id="loginradiuscustom_tmpl">

<span class="contantcell" style="margin-top: 15px;">
<a href="javascript:void()" onclick="return $LRIC.util.openWindow('<#=Endpoint#>');">
<img src="content/images/<#=Name.toLowerCase()#>.png" alt="" />
</a>
</span>
</script>

<%--LoginRadius custom interface js libraray--%>
 <script src="//cdn.loginradius.com/hub/prod/js/CustomInterface.2.js" type="text/javascript"></script>

<script type="text/javascript">
    var cache = {};
    $LRIC.util.ready(function () {

        $LRIC.util.tmpl = function tmpl(str, data) {
            var fn = !/\W/.test(str) ? cache[str] = cache[str]
|| tmpl($LRIC.util.elementById(str).innerHTML)
: new Function("obj",
"var p=[],print=function(){p.push.apply(p,arguments);};"
+ "with(obj){p.push('"
+ str.replace(/[\r\t\n]/g, " ").split("<#")
.join("\t").replace(
/((^|#>)[^\t]*)'/g, "$1\r")
.replace(/\t=(.*?)#>/g, "',$1,'")
.split("\t").join("');")
.split("#>").join("p.push('")
.split("\r").join("\\'")
+ "');}return p.join('');");
            return data ? fn(data) : fn;
        };

        var options = {};
        options.apikey = '<%=ApiKey %>';

        options.templatename = "loginradiuscustom_tmpl";
        $LRIC.renderInterface("interfacecontainerdiv", options);
    });
</script>


</asp:Content>
