const serverUrl = "http://localhost:4000";
let update = {};

$("#btn-user-changepassword").click(function () {
    if (!$("#user-changepassword-oldpassword").val()) {
        $("#user-changepassword-message").text("Old Password is a required field");
        $("#user-changepassword-message").attr("class", "error-message");
        return;
    } else if (!$("#user-changepassword-newpassword").val()) {
        $("#user-changepassword-message").text("New Password is a required field");
        $("#user-changepassword-message").attr("class", "error-message");
        return;
    }
    let data = {
        "oldpassword" : $("#user-changepassword-oldpassword").val(),    
        "newpassword" : $("#user-changepassword-newpassword").val()
    }
    $.ajax({
        method: "PUT",
        url: m_options.changePasswordUrl + "?auth=" + localStorage.getItem("LRTokenKey"),
        data: JSON.stringify(data),
        contentType: "application/json",
        error: function(xhr) {
            $("#user-changepassword-message").text(xhr.responseJSON.value.description);
            $("#user-changepassword-message").attr("class", "error-message");
        }
    }).done(function () {
        $("#user-changepassword-oldpassword").val("");
        $("#user-changepassword-newpassword").val("");
        $("#user-changepassword-message").text("Password successfully changed.");
        $("#user-changepassword-message").attr("class", "success-message");
    });
});

$("#btn-user-setpassword").click(function () {
    if (!$("#user-setpassword-password").val()) {
        $("#user-setpassword-message").text("Password is a required field");
        $("#user-setpassword-message").attr("class", "error-message");
        return;
    } 
    let data = {
        "password" : $("#user-setpassword-password").val()
    }
    $.ajax({
        method: "PUT",
        url: m_options.setPasswordUrl + "?uid=" + localStorage.getItem("lr-user-uid"),
        data: JSON.stringify(data),
        contentType: "application/json",
        error: function(xhr){
            $("#user-setpassword-message").text(xhr.responseJSON.value.description);
            $("#user-setpassword-message").attr("class", "error-message");
        }
    }).done(function () {
        $("#user-setpassword-password").val("");
        $("#user-setpassword-message").text("Password successfully changed.");
        $("#user-setpassword-message").attr("class", "success-message");
    });
});

$("#btn-user-updateaccount").click(function() {
    let data = {};

    if ($("#user-updateaccount-firstname").val() === "" &&
        $("#user-updateaccount-lastname").val() === "" &&
        $("#user-updateaccount-about").val() === "") {
        $("#user-updateaccount-message").text("Please input some data that needs to be updated.");
        $("#user-updateaccount-message").attr("class", "error-message");
        return;
    }
    let dataFields = {
        "FirstName": $("#user-updateaccount-firstname").val(),
        "LastName": $("#user-updateaccount-lastname").val(),
        "About": $("#user-updateaccount-about").val()
    }

    for (let key in dataFields) {
        if (dataFields[key] !== "") {
            data[key] = dataFields[key];
        } else {
            data[key] = update[key];
        }
    }

    $.ajax({
        method: "PUT",
        url: m_options.updateUrl + "?uid=" + localStorage.getItem("lr-user-uid"),
        data: JSON.stringify(data),
        contentType: "application/json",
        error: function(xhr) {
            $("#user-updateaccount-message").text(xhr.responseJSON.value.description);
            $("#user-updateaccount-message").attr("class", "error-message");
        }
    }).done(function () {
        $("#user-updateaccount-firstname").val("");
        $("#user-updateaccount-lastname").val("");
        $("#user-updateaccount-about").val("");
        $("#user-updateaccount-message").text("Account successfully updated.");
        $("#user-updateaccount-message").attr("class", "success-message");
        profileUpdate();
    });
});

$("#btn-user-createcustomobj").click(function() {
    let data;
    try {
        data = JSON.parse($("#user-createcustomobj-data").val());
    } catch(e) {
        $("#user-createcustomobj-message").text("Please input a valid JSON object in the data field.");
        $("#user-createcustomobj-message").attr("class", "error-message");
        return;
    }
    if ($("#user-createcustomobj-objectname").val() === "") {
        $("#user-createcustomobj-message").text("Please input a valid Object Name.");
        $("#user-createcustomobj-message").attr("class", "error-message");
        return;
    }

    $.ajax({
        method: "POST",
        url: m_options.createCustomObjectUrl + "?object_name=" + $("#user-createcustomobj-objectname").val() + "&auth=" + localStorage.getItem("LRTokenKey"),
        data: JSON.stringify(data),
        contentType: "application/json",
        error: function(xhr) {
            $("#user-createcustomobj-message").text(xhr.responseJSON.value.description);
            $("#user-createcustomobj-message").attr("class", "error-message");
        }
    }).done(function () {
        $("#user-createcustomobj-objectname").val("");
        $("#user-createcustomobj-data").val("");
        $("#user-createcustomobj-message").text("Object successfully created.");
        $("#user-createcustomobj-message").attr("class", "success-message");
    });
});

$("#btn-user-updatecustomobj").click(function() {
    let data = {};

    try {
        data = JSON.parse($("#user-updatecustomobj-data").val());
    } catch(e) {
        $("#user-updatecustomobj-message").text("Please input a valid JSON object in the data field.");
        $("#user-updatecustomobj-message").attr("class", "error-message");
        return;
    }
    if ($("#user-updatecustomobj-objectname").val() === "") {
        $("#user-updatecustomobj-message").text("Please input a valid Object Name.");
        $("#user-updatecustomobj-message").attr("class", "error-message");
        return;
    }
    if ($("#user-updatecustomobj-objectrecordid").val() === "") {
        $("#user-updatecustomobj-message").text("Please input a valid Object Record ID.");
        $("#user-updatecustomobj-message").attr("class", "error-message");
        return;
    }

    $.ajax({
        method: "PUT",
        url: m_options.updateCustomObjectUrl + "?object_name=" + $("#user-updatecustomobj-objectname").val() + "&auth=" + localStorage.getItem("LRTokenKey") +
            "&object_id=" + $("#user-updatecustomobj-objectrecordid").val(),
        data: JSON.stringify(data),
        contentType: "application/json",
        error: function (xhr) {
            $("#user-updatecustomobj-message").text(xhr.responseJSON.value.description);
            $("#user-updatecustomobj-message").attr("class", "error-message");
        }
    }).done(function () {
        $("#user-updatecustomobj-objectrecordid").val("");
        $("#user-updatecustomobj-objectname").val("");
        $("#user-updatecustomobj-data").val("");
        $("#user-updatecustomobj-message").text("Object successfully updated.");
        $("#user-updatecustomobj-message").attr("class", "success-message");
    });
});

$("#btn-user-deletecustomobj").click(function () {
    if ($("#user-deletecustomobj-objectname").val() === "") {
        $("#user-deletecustomobj-message").text("Please input a valid Object Name.");
        $("#user-deletecustomobj-message").attr("class", "error-message");
        return;
    }
    if ($("#user-deletecustomobj-objectrecordid").val() === "") {
        $("#user-deletecustomobj-message").text("Please input a valid Object Record ID.");
        $("#user-deletecustomobj-message").attr("class", "error-message");
        return;
    }
    $.ajax({
        method: "DELETE",
        url: m_options.deleteCustomObjectUrl + "?object_name=" + $("#user-deletecustomobj-objectname").val() + "&auth=" + localStorage.getItem("LRTokenKey") +
            "&object_id=" + $("#user-deletecustomobj-objectrecordid").val(),
        contentType: "application/json",
        error: function(xhr) {
            $("#user-deletecustomobj-message").text(xhr.responseJSON.value.description);
            $("#user-deletecustomobj-message").attr("class", "error-message");
        }
    }).done(function () {
        $("#user-deletecustomobj-objectname").val("");
        $("#user-deletecustomobj-objectrecordid").val("");
        $("#user-deletecustomobj-message").text("Custom object deleted successfully.");
        $("#user-deletecustomobj-message").attr("class", "success-message");
    });
});

$("#btn-user-getcustomobj").click(function () {
    if ($("#user-getcustomobj-objectname").val() === "") {
        $("#user-getcustomobj-message").text("Please input a valid Object Name.");
        $("#user-getcustomobj-message").attr("class", "error-message");
        return;
    }
    $.ajax({
        method: "GET",
        url: m_options.getCustomObjectUrl + "?object_name=" + $("#user-getcustomobj-objectname").val() + "&auth=" + localStorage.getItem("LRTokenKey"),
        contentType: "application/json",
        error: function(xhr) {
            $('#table-customobj tr').remove();
            $("#user-getcustomobj-message").text(xhr.responseJSON.value.description);
            $("#user-getcustomobj-message").attr("class", "error-message");
        }
    }).done(function (ret) {
        $("#user-getcustomobj-objectname").val("");
        $("#user-getcustomobj-message").text("All existing custom objects retrieved successfully.");
        $("#user-getcustomobj-message").attr("class", "success-message");
        $('#table-customobj tr').remove();
        $('<tr>' +
            '<th>Object ID</th><th>Custom Object</th>' +
            '<tr>').appendTo("#table-customobj > tbody:last-child");

        for (let i = 0; i < ret.data.length; i++) {
            $("<tr><td>" + ret.data[i].Id + "</td></tr>").appendTo("#table-customobj > tbody:last-child");
            $("<td>", {
                text: JSON.stringify(ret.data[i].CustomObject)
            }).appendTo("#table-customobj > tbody:last-child > tr:last-child");
        }
    });
});

$("#btn-user-mfa-resetgoogle").click(function() {
    let data = {
        "googleauthenticator": true
    }

    $.ajax({
        method: "DELETE",
        url: m_options.mfaResetGoogleUrl + "?auth=" + localStorage.getItem("LRTokenKey"),
        data: JSON.stringify(data),
        contentType: "application/json",
        error: function(xhr) {
            $("#user-mfa-message").text(xhr.responseJSON.value.description);
            $("#user-mfa-message").attr("class", "error-message");
        }
    }).done(function() { 
        $("#user-mfa-message").text("Google Authenticator settings reset.");
        $("#user-mfa-message").attr("class", "success-message");
    });
});

$( "#btn-user-createrole" ).click(function() {
    let data = {
        "roles" : [
            { "Name": $("#user-roles-createrole").val() }
        ]
    }

    $.ajax({
        method: "POST",
        url: m_options.createRoleUrl,
        data: JSON.stringify(data),
        contentType: "application/json",
        error: function(xhr) {
            $("#user-createrole-message").text(xhr.responseJSON.value.description);
            $("#user-createrole-message").attr("class", "error-message");
        }
    }).done(function () {
        $("#user-roles-createrole").val("");
        $("#user-createrole-message").text("Role created successfully.");
        $("#user-createrole-message").attr("class", "success-message");
        roleUpdate();
    });
});

$("#btn-user-deleterole").click(function () {
    if ($("#user-roles-deleterole").val() === "") {
        $("#user-deleterole-message").text("Please input a valid Role.");
        $("#user-deleterole-message").attr("class", "error-message");
        return;
    }
    $.ajax({
        method: "DELETE",
        url: m_options.deleteRoleUrl + "?role=" + $("#user-roles-deleterole").val(),
        contentType: "application/json",
        error: function(xhr) {
            $("#user-deleterole-message").text(xhr.responseJSON.value.description);
            $("#user-deleterole-message").attr("class", "error-message");
        }
    }).done(function () {
        $("#user-roles-deleterole").val("");
        $("#user-deleterole-message").text("Role deleted successfully.");
        $("#user-deleterole-message").attr("class", "success-message");
        roleUpdate();
    });
});

$( "#btn-user-assignrole" ).click(function() {
    let data = {
        "Roles" : [
            $("#user-roles-assignrole").val()
        ]
    }

    $.ajax({
        method: "PUT",
        url: m_options.assignRoleUrl + "?uid=" + localStorage.getItem("lr-user-uid"),
        data: JSON.stringify(data),
        contentType: "application/json",
        error: function(xhr) {
            $("#user-assignrole-message").text(xhr.responseJSON.value.description);
            $("#user-assignrole-message").attr("class", "error-message");
        }
    }).done(function () {
        $("#user-roles-assignrole").val("");
        $("#user-assignrole-message").text("Role added to current user successfully.");
        $("#user-assignrole-message").attr("class", "success-message");
        roleUpdate();
    });
});

let profileUpdate = function() {
    if(localStorage.getItem("LRTokenKey") === null) {
        window.location.replace("/");
        return;
    }

    $.ajax({
        method: "GET",
        url: m_options.getProfileUrl + "?auth=" + localStorage.getItem("LRTokenKey"),
        error: function(){
            localStorage.removeItem("LRTokenKey");
            localStorage.removeItem("lr-user-uid");
            window.location.replace("/");
        }
    }).done(function (ret) {
        console.log(ret);
        if (ret.FullName === null) {
            $("#profile-name").html("");
        } else {
            $("#profile-name").html("<b>" + ret.FullName + "</b>");
        }
        if (ret.ImageUrl != null && ret.ImageUrl != undefined && ret.ImageUrl != "") {
            $("#profile-image").attr('src', ret.ImageUrl)
        }
        $("#profile-provider").text("Provider: " + ret.Provider);
        $("#profile-email").text(ret.Email[0].Value);
        $("#profile-lastlogin").text("Last Login Date: " + ret.LastLoginDate);
        $("#user-updateaccount-firstname").val(ret.FirstName);
        $("#user-updateaccount-lastname").val(ret.LastName);
        $("#user-updateaccount-about").val(ret.About);
    });
}

let roleUpdate = function() {
    $.ajax({
        method: "GET",
        url: m_options.getRolesUrl,
        error: function(xhr) {
            $("#minimal-verification-message").text(xhr.responseJSON.value.description);
            $("#minimal-verification-message").attr("class", "error-message");
        }
    }).done(function(ret) {
        $('#table-allroles tr:not(:first)').remove();
        for (let i = 0; i < ret.data.length; i++) {
            $("<tr></tr>").appendTo("#table-allroles > tbody:last-child");
            $("<td>", {
                text: ret.data[i].Name
            }).appendTo('#table-allroles > tbody:last-child > tr:last-child');
        }
    });


    $.ajax({
        method: "GET",
        url: m_options.getRoleUrl + "?uid=" + localStorage.getItem("lr-user-uid"),
        error: function(xhr) {
            $("#minimal-verification-message").text(xhr.responseJSON.value.description);
            $("#minimal-verification-message").attr("class", "error-message");
        }
    }).done(function(ret) {
        $('#table-userroles tr:not(:first)').remove();
        if (ret && ret.Roles) {
            for (let i = 0; i < ret.Roles.length; i++) {
                $("<tr></tr>").appendTo("#table-userroles > tbody:last-child");
                $("<td>", {
                    text: ret.Roles[i]
                }).appendTo('#table-userroles > tbody:last-child > tr:last-child');
            }
        }
    });
}

let script = $(
    '<script type="text/html" id="loginradiuscustom_tmpl_link">' +
    '<# if(isLinked) { #>' +
    '<div class="lr-linked">' +
    '<a class="lr-provider-label" href="javascript:void(0)" title="<#= Name #>" alt="Connected" onclick=\'return LRObject.util.unLinkAccount(\"<#= Name.toLowerCase() #>\",\"<#= providerId #>\")\'><#=Name#> is connected | Delete</a>' +
    '</div>' +
    '<# }  else {#>' +
    '<div class="lr-unlinked">' +
    '<a class="lr-provider-label" href="javascript:void(0)" onclick="return LRObject.util.openWindow(\'<#= Endpoint #>\');" title="<#= Name #>" alt="Sign in with <#=Name#>">' +
    '<#=Name#></a></div>' +
    '<# } #>' +
    '</script>'
);

$("#script-accountlinking").append(script);

let la_options = {};
la_options.container = "interfacecontainerdiv";
la_options.templateName = 'loginradiuscustom_tmpl_link';
la_options.onSuccess = function() {
    $("#interfacecontainerdiv").empty();
    LRObject.util.ready(function() {
        LRObject.init("linkAccount", la_options);
    });
}
la_options.onError = function(errors) {
    $("#user-accountlinking-message").text(errors[0].Description);
    $("#user-accountlinking-message").attr("class", "error-message");
}

let unlink_options = {};
unlink_options.onSuccess = function() {
    $("#interfacecontainerdiv").empty();
    LRObject.util.ready(function() {
        LRObject.init("linkAccount", la_options);
    });
}
unlink_options.onError = function(errors) {
    $("#user-accountlinking-message").text(errors[0].Description);
    $("#user-accountlinking-message").attr("class", "error-message");
}

LRObject.util.ready(function() {
    LRObject.init("linkAccount", la_options);
    LRObject.init("unLinkAccount", unlink_options);
});

