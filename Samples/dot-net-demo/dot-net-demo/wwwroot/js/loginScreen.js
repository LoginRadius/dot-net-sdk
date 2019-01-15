LRObject.util.ready(function() {
    LRObject.loginScreen("loginscreen-container", options);
});

let options = {
    redirecturl: {
        afterlogin: "http://localhost:57476/Home/Profile",
        afterreset: "http://localhost:57476/"
  }
}
