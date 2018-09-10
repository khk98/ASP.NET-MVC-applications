$(document).ready(function () {
    addcountries();
    addtitle();
});

//checking password and confirm Password are same or not
var Password = document.getElementById("Password")
    , ConfirmPassword = document.getElementById("ConfirmPassword");

function validatePassword() {
    if (Password.value != ConfirmPassword.value) {
        ConfirmPassword.setCustomValidity("Password Doesn't Match");
    } else {
        ConfirmPassword.setCustomValidity('');
    }
}
Password.onchange = validatePassword;
ConfirmPassword.onkeyup = validatePassword;

function addcountries() {

    $('#ddlCountry').empty();
    $('#ddlCountry').append('<option value selected disabled>' + "Select Country" + '</option>');
    $.ajax({
        type: 'GET',
        url: '/Home/GetCountries',
        success: function (result) {
            $.each(result, function (key, value) {
                $('#ddlCountry').append('<option value="' + value.CountryID + '">' + value.CountryName + '</option>');
            });

        }
    });
}

function addtitle() {

    $('#ddlTitle').empty();
    $('#ddlTitle').append('<option value selected disabled>' + "Title" + '</option>');
    $.ajax({
        type: 'GET',
        url: '/Home/GetTitle',
        success: function (result) {
            $.each(result, function (key, value) {
                $('#ddlTitle').append('<option value="' + value.TitleID + '">' + value.TitleName + '</option>');
            });

        }
    });
}

//onselection change of country dropdown appending the state dropdown values
$('#ddlCountry').on("change", UserCountryChange);
function UserCountryChange() {

    $('#ddlStateINFO').empty();
    $('#ddlStateINFO').append('<option value selected disabled>' + "Select State" + '</option>');
    var country = $(('#ddlCountry')).val();
    $.ajax({
        type: 'GET',
        url: '/Home/GetStates',
        data: { countryID: country },
        success: function (result) {
            $.each(result, function (key, value) {

                $('#ddlStateINFO').append('<option value="' + value.StateID + '">' + value.StateName + '</option>');
            });

        }
    });
}

$('#ddlStateINFO').on("change", UserStateChange1);
function UserStateChange1() {

    $('#ddlCityINFO').empty();
    $('#ddlCityINFO').append('<option value selected disabled>' + "Select City" + '</option>');
    var state = $(('#ddlStateINFO')).val();
    $.ajax({
        type: 'GET',
        url: '/Home/GetCity',
        data: { stateID: state },
        success: function (result) {
            $.each(result, function (key, value) {

                $('#ddlCityINFO').append('<option value="' + value.CityID + '">' + value.CityName + '</option>');
            });

        }
    });
}


$('#username').keyup(function (event) {
    var Title = $(('#username')).val();
    $.ajax({
        type: 'GET',
        url: '/Home/CheckAvailability',
        data: { TitleParam: Title },
        success: function (Availablle) {


            if (Availablle == false) {
                $('#username').css("border-color", "#ff0000");
                $('#username_error').empty();
                $('#username_error').css("color", "#ff0000");
                $('#username_error').append("Username has already taken.");
                return;
            }
            $('#username_error').empty();
            $('#username').css("border-color", "#cccccc");
        }
    });
});

$('#email').keyup(function (event) {
    var email = $(('#email')).val();
    $.ajax({
        type: 'GET',
        url: '/Home/CheckEmailAvailability',
        data: { TitleParam: email },
        success: function (Availablle) {

            if (Availablle == false) {
                $('#email').css("border-color", "#ff0000");
                $('#email_error').empty();
                $('#email_error').css("color", "#ff0000");
                $('#email_error').append("You have already registered with us.");
                return;
            }
            $('#email_error').empty();
            $('#email').css("border-color", "#cccccc");
        }
    });
});


function ValidateSize(file) {

    var FileSize = file.files[0].size / 1024 / 1024; // in MB
    if (FileSize > 0.15) {
        document.getElementById("photo").setCustomValidity("File should be less than 150 KB");
        // $(file).val(''); //for clearing with Jquery
    } else {
    }
}