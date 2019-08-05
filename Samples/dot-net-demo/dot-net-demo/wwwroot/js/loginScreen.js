LRObject.util.ready(function() {
    LRObject.loginScreen("loginscreen-container", options);
});

let options = {
    redirecturl: {
        afterlogin: window.location.origin + "/Home/Profile",
        afterreset: window.location.origin + "/"
  }
}
