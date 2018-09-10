var city = "", state = "", country = "";

var OAUTHURL = 'https://accounts.google.com/o/oauth2/auth?';
var VALIDURL = 'https://www.googleapis.com/oauth2/v1/tokeninfo?access_token=';
var SCOPE = 'https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/userinfo.email';
var CLIENTID = '530612297063-clu3fkm55qhgqfoilv5tba6t2ttcbdqt.apps.googleusercontent.com';
var REDIRECT = 'http://donateneedynew.azurewebsites.net/User/Index';
var LOGOUT = 'http://donateneedynew.azurewebsites.net/User/Index';
var TYPE = 'token';
var _url = OAUTHURL + 'scope=' + SCOPE + '&client_id=' + CLIENTID + '&redirect_uri=' + REDIRECT + '&response_type=' + TYPE;
var acToken;
var tokenType;
var expiresIn;
var user;
var loggedIn = false;

function login() {
    var win = window.open(_url, "windowname1", 'width=800, height=600');
    var pollTimer = window.setInterval(function () {
        try {
            //console.log(win.document.URL);
            if (win.document.URL.indexOf(REDIRECT) != -1) {
                window.clearInterval(pollTimer);
                var url = win.document.URL;
                acToken = gup(url, 'access_token');
                tokenType = gup(url, 'token_type');
                expiresIn = gup(url, 'expires_in');

                win.close();
                validateToken(acToken);
            }
        }
        catch (e) {

        }
    }, 500);
}

function gup(url, name) {
    namename = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regexS = "[\\#&]" + name + "=([^&#]*)";
    var regex = new RegExp(regexS);
    var results = regex.exec(url);
    if (results == null)
        return "";
    else
        return results[1];
}

function validateToken(token) {
    getUserInfo();
    $.ajax(
        {
            url: VALIDURL + token,
            data: null,
            success: function (responseText) {
            },
        });
}

function getUserInfo() {
    $.ajax({
        url: 'https://www.googleapis.com/oauth2/v1/userinfo?access_token=' + acToken,
        data: null,
        success: function (resp) {
            user = resp;
            $.ajax({
                url: '/User/GoogleLogin',
                type: 'POST',
                data: {
                    email: user.email,
                    name: user.name,
                    id: user.id,
                    lastname: user.lastname,
                    locationValue: city + "," + state + "," + country,
                    ReturnUrl: $('#ReturnUrl').val()
                },
                dataType: 'json',
                success: function (result) {
                    if (result.usercount == 1) {
                        window.location.href = 'http://donateneedynew.azurewebsites.net/User/' + result.ReturnUrl;
                    }
                    else if (result.usercount == 0) {
                        var regid = result.ID;
                        window.location.href = '/Home/Details?usertypeid=3&regid=' + regid;
                    }
                },
            });
        },
    });
}

window.fbAsyncInit = function () {
    FB.init({
        appId: '129377397772066',
        status: true,
        cookie: true,
        xfbml: true
    });
};


(function (doc) {
    var js;
    var id = 'facebook-jssdk';
    var ref = doc.getElementsByTagName('script')[0];
    if (doc.getElementById(id)) {
        return;
    }
    js = doc.createElement('script');
    js.id = id;
    js.async = true;
    js.src = "//connect.facebook.net/en_US/all.js";
    ref.parentNode.insertBefore(js, ref);
}(document));
function testAPI() {
    FB.api('/me?fields=id,name,email', function (response) {
        $.ajax({
            url: '/User/FacebookLogin',
            type: 'POST',
            data: {
                name: response.name,
                id: response.id,
                email: response.email,
                locationValue: city + "," + state + "," + country,
                ReturnUrl: $('#ReturnUrl').val()
            },
            dataType: 'json',
            success: function (result) {
                var returnurl = $('#ReturnUrl').val();
                if (result.usercount == 1) {
                    window.location.href = 'http://donateneedynew.azurewebsites.net/User/' + result.ReturnUrl;
                }
                else if (result.usercount == 0) {
                    var regid = result.ID;
                    window.location.href = '/Home/Details?usertypeid=4&regid=' + regid;
                }
            },
        });
    });
}

function Login() {
    FB.login(function (response) {
        if (response.authResponse) {
            testAPI();
        }
        else {
        }
    }, { scope: 'email,user_photos,publish_actions' });

}
$.getJSON('http://freegeoip.net/json/', function (location) {
    city = location.city;
    state = location.region_name;
    country = location.country_name;
});