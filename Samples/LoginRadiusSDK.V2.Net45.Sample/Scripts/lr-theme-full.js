

var lrThemeSettings = {
    raasoption: {
        apikey: loginRadiusConfig.apiKey,
        appname: loginRadiusConfig.appName,
        sott: loginRadiusConfig.sott,
        forgotPasswordUrl: window.location.href.split("?")[0].split("#")[0],
        verificationUrl: window.location.href.split("?")[0].split("#")[0]
    },
    logo: {
        logo_image_path: "", /* Your logo image path, must be 28px * 28px */
        logo_alt_text: "" /* Alternative text for Image */
    },
    caption_message: {
        register: "Register",
        login: "Login",
        forgot_password: "Forgot Password",
        reset_password: "Reset Password",
        fields_missing: "One Step Left"
    },
    success_message: {
        register: "Succeed, a verification email has been sent to your email address",
        login: "Login succeed",
        social_login: "Social login succeed", /* Or maybe go check your emails to verify for Twitter */
        email_verified: "Email verified successfully, you can login now",
        forgot_password: "A reset link has been sent to your email address, click to reset your email",
        reset_password: "Your password has been reset",
        verify_email: "Email verified successfully, you can login now",
        unverified_email: "The email is not verified, please verify the link in your email"
    },
    allowUserLogin: function (response) {
        document.getElementById('fade').style.display = "block";
        getUserProfile(response.access_token, function (data) {
            
                document.getElementById('profiledata').innerHTML = getTable(data);
                document.getElementById("profileinformation").style.display = "block";
                document.getElementById("homeinformation").style.display = "none";
                document.getElementById('logoutaction').style.display = "block";
                document.getElementById('loginaction').style.display = "none";
                LrRaasTheme.closeAllPopups();
               document.getElementById('fade').style.display = "none";
        });
    },
    form_render_submit_hook: {
        start: function () {
            //document.getElementById('fade').style.display = "block";
        },
        end: function () {
            //document.getElementById('fade').style.display = "none";
        }
    },
    reset_form_after_close_popup: false
}

getUserProfile = function (accessToken, callback) {
    $.post("Home/GetUserProfile",
        {
            token: accessToken,
        },
        function (data, status) {
            if (data.RestException != null) {
                alert(data.RestException.Description);
                if (getlrCookie("lr_token") != "") {
                    lrLogout();
                }
            } else {
                setlrCookie('lr_token', accessToken, 44700);
                callback(data.Response);
            }
        });
}


function getTable(profile) {
    var data = '<table>';
    for (var key in profile) {
        data += '<tr><td class="profileLabel">' + key + '</td>';
        var value = (profile[key] != null) ? profile[key] : '';
        if (typeof value == "object") {
            data += '<td class="profileValue">' + createHorizontalTable(value) + '</td>';
        } else {

            if (value != "" && value != null && typeof value !== 'undefined' && typeof value === 'string' && value.indexOf("Date") > 0) {
                var ss = value.replace("/Date(", "");
                value = new Date(+ss.replace(")/", ""));
            }

            data += '<td class="profileValue">' + value + '</td>';
        }
        data += '</tr>';
    }
    data += '</table>';
    return data;
}

function createHorizontalTable(profile, count, table) {
    var data = '';
    if (typeof count == "undefined") {
        count = 0
    }
    if (count == '0') {
        data += '<table><tr>';
        for (var key in profile) {
            var value = (profile[key] != null) ? profile[key] : '';
            if (typeof value == "object") {
                data = '';
                return createHorizontalTable(value);
            }
            data += '<td class="profileLabel">' + key + '</td>';
        }
        data += '</tr>';
    }
    data += '<tr>';
    if (table == 'albums') {
        data += '<td><a onclick="photoProfile(&quot;' + profile['ID'] + '&quot;)">View Photos</a></td>';
    }
    for (var key in profile) {
        var value = (profile[key] != null) ? profile[key] : '';
        if (typeof value == "object") {
            data += '<td>' + createHorizontalTable(value) + '</td>';
        } else {
            if (key == 'ImageUrl' || key == 'Small' || key == 'Square' || key == 'Large' || key == 'Profile' || key == 'Image' || key == 'Picture') {
                data += '<td><img style="width:70px;" src="' + value + '"/></td>';
            } else {
                data += '<td>' + value + '</td>';
            }
        }
    }

    data += '</tr>';
    if (count == '0') {
        data += '</table>';
    }
    return data;
}




//customization
var LrRaasTheme = {
    hideOverlay: function () {
        $('.pop_up').hide();
        $('#fade').hide();
    },
    closeAllPopups: function () {
        if (lrThemeSettings.reset_form_after_close_popup) {
            this.resetAllPopups;
        }
        this.hideOverlay();
        var popups = document.getElementsByClassName("lr-popup-container");
        for (var i = 0; i < popups.length; i++) {
            popups[i].className = "lr-popup-container";
        }
    }
}

function setlrCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}


function getlrCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}


function deletelrCookie(name) {
    document.cookie = name + '=; Path=/; Expires=Thu, 01 Jan 1970 00:00:01 GMT;';
    return true;
}

function lrLogout() {
    if (deletelrCookie("lr_token")) {
        location.reload();
    }
}


function changePassword() {
    if ($('.lr-raas-theme-changePassword').text() == "Change Password") {
        if ($('.lr-raas-theme-accountLinking').text() == "Profile") {
            $('#accountlinking').hide();
            $('.lr-raas-theme-accountLinking').text("Account Linking");

        } if ($('.lr-raas-theme-addEmail').text() == "Profile") {
            $('#addemail').hide();
            $('.lr-raas-theme-addEmail').text("Add Email");
        }
        $('#profileinformation').hide();
        $('#changepassowrd').show();
        $('.lr-raas-theme-changePassword').text("Profile");
        var changepassword_options = {};
        changepassword_options.container = "changepassword-container";
        changepassword_options.onSuccess = function (response) {
            // On Success
            alert("Success! Your Password has been changed!");
			location.href = location.href
            console.log(response);
        };
        changepassword_options.onError = function (errors) {
            // On Error
            for (var i = 0; i < errors.length; i++) {
                alert(errors[i].Description);

            }
            console.log(errors);
        };
        LRObject.util.ready(function () {
            LRObject.init("changePassword", changepassword_options);
        });
    } else {
        $('#profileinformation').show();
        $('#changepassowrd').hide();
        $('.lr-raas-theme-changePassword').text("Change Password");
    }

}

    function accountLinking() {
        if ($('.lr-raas-theme-accountLinking').text() == "Account Linking") {
            if ($('.lr-raas-theme-changePassword').text() == "Profile") {
                $('#changepassowrd').hide();
                $('.lr-raas-theme-changePassword').text("Change Password");
            } if ($('.lr-raas-theme-addEmail').text() == "Profile") {
                $('#addemail').hide();
                $('.lr-raas-theme-addEmail').text("Add Email");
            }
            $('#profileinformation').hide();
            $('#accountlinking').show();
            $('.lr-raas-theme-accountLinking').text("Profile");
            var la_options = {};
            la_options.container = "interfacecontainerdiv_link";
            la_options.templateName = "loginradiuscustom_tmpl_link"
            la_options.onSuccess = function (response) {
                // On Success
                if (response.IsDeleted) {
                    alert("you have successfully Unlink this provider")
                } else {
                    alert("you have successfully link this provider");
                }
               
                location.href = location.href
                console.log(response);
            };
            la_options.onError = function (errors) {
                // On Errors
                for (var i = 0; i < errors.length; i++) {
                    alert(errors[i].Description);

                }
                console.log(errors);
            }
            LRObject.util.ready(function () {
                LRObject.init("linkAccount", la_options);
                LRObject.init("unLinkAccount", la_options);
            });
        } else {
            $('#profileinformation').show();
            $('#accountlinking').hide();
            $('.lr-raas-theme-accountLinking').text("Account Linking");
        }


}


function addEmail() {
    if ($('.lr-raas-theme-addEmail').text() == "Add Email") {
        if ($('.lr-raas-theme-changePassword').text() == "Profile") {
            $('#changepassowrd').hide();
            $('.lr-raas-theme-changePassword').text("Change Password");
        } if ($('.lr-raas-theme-accountLinking').text() == "Profile") {
            $('#accountlinking').hide();
            $('.lr-raas-theme-accountLinking').text("Account Linking");
        }
        $('#profileinformation').hide();
        $('#addemail').show();
        $('.lr-raas-theme-addEmail').text("Profile");
        var addemail_options = {};
        addemail_options.container = "addemail-container";
        addemail_options.onSuccess = function (response) {
            // On Success
            alert("You have successfully added.Please verify your Email");
			location.href = location.href
            console.log(response);
        };
        addemail_options.onError = function (errors) {
            // On Error
            for (var i = 0; i < errors.length; i++) {
                alert(errors[i].Description);

            }
        };
        LRObject.util.ready(function () {
            LRObject.init("addEmail", addemail_options);
        });
    } else {
        $('#profileinformation').show();
        $('#addemail').hide();
        $('.lr-raas-theme-addEmail').text("Add Email");
    }


}