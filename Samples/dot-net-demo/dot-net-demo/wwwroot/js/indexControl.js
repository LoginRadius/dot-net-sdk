let multiFactorAuthToken;

let m_options;


let custom_interface_option = {};
custom_interface_option.templateName = 'loginradiuscustom_tmpl';
LRObject.util.ready(function() {
    LRObject.customInterface(".interfacecontainerdiv", custom_interface_option);
});

let sl_options = {};
sl_options.onSuccess = function(response) {
    console.log(response);
    localStorage.setItem("LRTokenKey", response.access_token);
    localStorage.setItem("lr-user-uid", response.Profile.Uid);
    window.location.replace("Home/Profile");
};
sl_options.onError = function (errors) {
    $("#social-login-message").text(errors[0].Description);
    $("#social-login-message").attr("class", "error-message");
};
sl_options.container = "sociallogin-container";

LRObject.util.ready(function() {
    LRObject.init('socialLogin', sl_options);
});

$("#btn-minimal-login").click(function () {
    if (!$("#minimal-login-email").val()) {
        $("#minimal-login-message").text("Email is a required field");
        $("#minimal-login-message").attr("class", "error-message");
        return;
    } else if (!$("#minimal-login-password").val()) {
        $("#minimal-login-message").text("Password is a required field");
        $("#minimal-login-message").attr("class", "error-message");
        return;
    }
    data = {
        "Email" : $("#minimal-login-email").val(),
        "Password" : $("#minimal-login-password").val()
    }
    $.ajax({
        method: "POST",
        data: JSON.stringify(data),
        url: m_options.loginUrl,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        error: function (xhr) {
            $("#minimal-login-message").text(xhr.responseJSON.value.description);
            $("#minimal-login-message").attr("class", "error-message");
        }
    }).done(function(ret) {
        localStorage.setItem("LRTokenKey", ret.access_token);
        localStorage.setItem("lr-user-uid", ret.Profile.Uid);
        window.location.replace("Home/Profile");
    });
});

$("#btn-minimal-mfalogin-next").click(function () {
    if (!$("#minimal-mfalogin-email").val()) {
        $("#minimal-mfalogin-message").text("Email is a required field");
        $("#minimal-mfalogin-message").attr("class", "error-message");
        return;
    } else if (!$("#minimal-mfalogin-password").val()) {
        $("#minimal-mfalogin-message").text("Password is a required field");
        $("#minimal-mfalogin-message").attr("class", "error-message");
        return;
    }
    data = {
        "Email" : $("#minimal-mfalogin-email").val(),
        "Password" : $("#minimal-mfalogin-password").val()    
    }
    $.ajax({
        method: "POST",
        data: JSON.stringify(data),
        url: m_options.mfaLoginUrl,
        contentType: "application/json",
        error: function(xhr) {
            $("#minimal-mfalogin-message").text(xhr.responseJSON.value.description);
            $("#minimal-mfalogin-message").attr("class", "error-message");
        }
    }).done(function (ret) {
        console.log(ret);
        $("#minimal-mfalogin-message").text("");
        if (ret.SecondFactorAuthentication) {
            if (ret.SecondFactorAuthentication.IsGoogleAuthenticatorVerified === false) {
                $("#minimal-mfalogin-qrcode").append('<img src="' + ret.SecondFactorAuthentication.QRCode + '">');
            }
            $("#minimal-mfalogin-next")
                .html('<table><tbody><tr>' +
                    '<td>Google Authenticator Code: </td><td><input type="text" id="minimal-mfalogin-googlecode"></td>' +
                    '</tr></tbody></table>' + 
                    '<button id="btn-minimal-mfalogin-login">Login</button>');
            multiFactorAuthToken = ret.SecondFactorAuthentication.SecondFactorAuthenticationToken;
        } else {
            localStorage.setItem("LRTokenKey", ret.access_token);
            localStorage.setItem("lr-user-uid", ret.Profile.Uid);
            window.location.replace("Home/Profile");
        }
    });
});

$("#minimal-mfalogin-next").on('click', "#btn-minimal-mfalogin-login", function() {
    data = {
        "googleauthenticatorcode" : $("#minimal-mfalogin-googlecode").val()    
    }
    
    $.ajax({
        method: "PUT",
        data: JSON.stringify(data),
        url: m_options.mfaAuthUrl + "?multi_factor_auth_token=" + multiFactorAuthToken,
        contentType: "application/json",
        error: function(xhr) {
            $("#minimal-mfalogin-message").text(xhr.responseJSON.value.description);
            $("#minimal-mfalogin-message").attr("class", "error-message");
        }
    }).done(function (ret) {
        console.log(ret);
        localStorage.setItem("LRTokenKey", ret.access_token);
        localStorage.setItem("lr-user-uid", ret.Profile.Uid);
        window.location.replace("Home/Profile");
    });
});

$("#btn-minimal-pwless").click(function () {
    if (!$("#minimal-pwless-email").val()) {
        $("#minimal-pwless-message").text("Email is a required field");
        $("#minimal-pwless-message").attr("class", "error-message");
        return;
    }
    $.ajax({
        method: "GET",
        url: m_options.pwlessLoginUrl + "?email=" + $("#minimal-pwless-email").val() + "&verification_url=" + commonOptions.emailVerify,
        contentType: "application/x-www-url-formencoded; charset=utf-8",
        dataType: "json",
        error: function(xhr){
            $("#minimal-pwless-message").text(xhr.responseJSON.value.description);
            $("#minimal-pwless-message").attr("class", "error-message");
        }
    }).done(function () {
        $("#minimal-pwless-email").val("");
        $("#minimal-pwless-message").text("Check your email for the login link.");
        $("#minimal-pwless-message").attr("class", "success-message");
    });
});

$("#btn-minimal-signup").click(function () {
    if ($("#minimal-signup-email").val() === "") {
        $("#minimal-signup-message").text("Email is a required field.");
        $("#minimal-signup-message").attr("class", "error-message");
        return;
    }
    if($("#minimal-signup-password").val() !== $("#minimal-signup-confirmpassword").val()) {
        $("#minimal-signup-message").text("Passwords do not match!");
        $("#minimal-signup-message").attr("class", "error-message");
        return;
    }
    let data = {
        "Email": [
          {
            "Type": "Primary",
            "Value": $("#minimal-signup-email").val()
          }
        ],
        "Password": $("#minimal-signup-password").val()
    }

    $.ajax({
        method: "POST",
        url: m_options.registerUrl + "?verification_url=" + commonOptions.emailVerify,
        data: JSON.stringify(data),
        contentType: "application/json",
        error: function (xhr) {
            console.log(xhr);
            $("#minimal-signup-message").text(xhr.responseJSON.value.description);
            $("#minimal-signup-message").attr("class", "error-message");
        }
    }).done(function () {
        $("#minimal-signup-email").val("");
        $("#minimal-signup-password").val("");
        $("#minimal-signup-confirmpassword").val("");
        $("#minimal-signup-message").text("Check your email to verify your account.");
        $("#minimal-signup-message").attr("class", "success-message");
    });
});

$("#btn-minimal-forgotpassword").click(function () {
    if ($("#minimal-forgotpassword-email").val() === "") {
        $("#minimal-forgotpassword-message").text("Email is a required field.");
        $("#minimal-forgotpassword-message").attr("class", "error-message");
        return;
    }
    data = {
        "Email": $("#minimal-forgotpassword-email").val()
    };
    $.ajax({
        method: "POST",
        data: JSON.stringify(data),
        url: m_options.forgotPasswordUrl + "?reset_password_url=" + commonOptions.resetPassword,
        contentType: "application/json",
        error: function(xhr){
            $("#minimal-forgotpassword-message").text(xhr.responseJSON.value.description);
            $("#minimal-forgotpassword-message").attr("class", "error-message");
        }
    }).done(function () {
        $("#minimal-forgotpassword-email").val(""); 
        $("#minimal-forgotpassword-message").text("Check your email to start the password reset process.");
        $("#minimal-forgotpassword-message").attr("class", "success-message");
    });
});
