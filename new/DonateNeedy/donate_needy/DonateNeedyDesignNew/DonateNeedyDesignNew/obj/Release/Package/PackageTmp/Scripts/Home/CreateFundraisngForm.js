$(document).ready(function () {
    personal();
});

function form() {
    $(function () {
        $('#datepicker').datepicker({
            onSelect: function (dateStr) {
                $('#datepicker1').datepicker('option', 'minDate', new Date(dateStr));
            }
        });
        $('#datepicker1').datepicker({
            onSelect: function (dateStr) {
                $('#datepicker').datepicker('option', 'maxDate', new Date(dateStr));
            }
        });
    });
}




    // This example displays an address form, using the autocomplete feature
    // of the Google Places API to help users fill in the information.

    // This example requires the Places library. Include the libraries=places
    // parameter when you first load the API. For example:
    // <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_API_KEY&libraries=places">

    // This example displays an address form, using the autocomplete feature
    // of the Google Places API to help users fill in the information.

    // This example requires the Places library. Include the libraries=places
    // parameter when you first load the API. For example:
    // <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_API_KEY&libraries=places">

    var placeSearch, autocomplete1;
    var componentForm = {
        street_number: 'short_name',
        route: 'long_name',
        locality: 'long_name',
        administrative_area_level_1: 'short_name',
        country: 'long_name',
        postal_code: 'short_name'
    };

    function initAutocomplete() {
        // Create the autocomplete object, restricting the search to geographical
        // location types.
        autocomplete1 = new google.maps.places.Autocomplete(
            (document.getElementById('autocomplete1')),
            { types: ['geocode'] });

        // When the user selects an address from the dropdown, populate the address
        // fields in the form.
        autocomplete1.addListener('place_changed', fillInAddress);
    }


    function fillInAddress() {
        // Get the place details from the autocomplete object.
        var place = autocomplete1.getPlace();

        for (var component in componentForm) {
            //document.getElementById(component).value = '';
            //document.getElementById(component).disabled = false;
        }

        // Get each component of the address from the place details
        // and fill the corresponding field on the form.
        for (var i = 0; i < place.address_components.length; i++) {
            var addressType = place.address_components[i].types[0];
            if (componentForm[addressType]) {
                var val = place.address_components[i][componentForm[addressType]];
                //document.getElementById(addressType).value = val;
            }
        }
    }

    // Bias the autocomplete object to the user's geographical location,
    // as supplied by the browser's 'navigator.geolocation' object.
    function geolocate() {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {
                var geolocation = {
                    lat: position.coords.latitude,
                    lng: position.coords.longitude
                };
                var circle = new google.maps.Circle({
                    center: geolocation,
                    radius: position.coords.accuracy
                });
                autocomplete1.setBounds(circle.getBounds());
            });
        }
    }


function personal() {

    //$('#personal').html('');
    //$('#charity').html('');
    //$('#socialevent').html('');
    
    //var s = "";
    //s += '<div class="row formtop">';
    //s += '  <div class="col-lg-4">';
    //s += '  <label>Event Title</label> <span class="required">*</span>';
    //s += '     <input class="form-control" type="text" name="eventtitle" required />';
    //s += '             </div>';
    //s += ' <div class="col-lg-4">';
    //s += '     <label>Organiser Name</label><span class="required">*</span>';
    //s += '        <input class="form-control" type="text" name="organisername" required />';
    //s += '   </div>';
    //s += '   <div class="col-lg-4">';
    //s += '      <label>Category</label><span class="required">*</span>';
    //s += '     <select class="form-control" name="category" required>';
    //s += '         <option disabled selected>Select</option>';
    //s += '           <option>Animals and Pets</option>';
    //s += '         <option>Family and Support</option>';
    //s += '         <option>Fatiligious Organisation</option>';
    //s += '             <option>Education</option>';
    //s += '   </select>';
    //s += ' </div>';
    //s += '          </div >';
    //s += '   <div class="row form">';
    //s += '      <div class="col-lg-12">';
    //s += '           <h4 class="heading">Personal Information</h4>';
    //s += '     </div>';
    //s += '       <div class="col-lg-12 form-data">';
    //s += '            <div class="col-lg-2"><label class="label-center">First Name</label><span class="required">*</span></div>';
    //s += '<div class="col-lg-4"><input type="text" class="form-control" name="firstname" required /></div>';
    //s += '<div class="col-lg-2"><label class="label-center">Middle Name</label><span class="required">*</span></div>';
    //s += '<div class="col-lg-4"><input type="text" class="form-control" name="middlename" required /></div>';
    //s += '</div>';
    //s += '<div class="col-lg-12 form-data">';
    //s += '<div class="col-lg-2"><label class="label-center">Last Name</label><span class="required">*</span></div>';
    //s += '<div class="col-lg-4"><input type="text" class="form-control" name="lastname" required /></div>';
    //s += '<div class="col-lg-2"><label class="label-center">Phone Number</label><span class="required">*</span></div>';
    //s += '<div class="col-lg-4"><input type="text" class="form-control" name="phonenumber" required /></div>';
    //s += '</div>';
    //s += '<div class="col-lg-12 form-data">';
    //s += '<div class="col-lg-2"><label class="label-center">Email ID</label><span class="required">*</span></div>';
    //s += '<div class="col-lg-4"><input type="text" class="form-control" name="emailid" /></div>';
    //s += '<div class="col-lg-2"><label class="label-center">Country</label><span class="required">*</span></div>';
    //s += '<div class="col-lg-4">';
    //s += '<select class="form-control" name="country" required>';
    //s += '<option disabled selected>Select</option>';
    //s += '<option>India</option>';
    //s += '<option>United States of America</option>';
    //s += '<option>Australia</option>';
    //s += '</select>';
    //s += '</div>';
    //s += '</div>';
    //s += '<div class="col-lg-12 form-data">';
    //s += '<div class="col-lg-2"><label class="label-center">State</label><span class="required">*</span></div>';
    //s += '<div class="col-lg-4">';
    //s += '<select class="form-control" name="state" required>';
    //s += '<option disabled selected>Select</option>';
    //s += '<option>Andhra Pradesh</option>';
    //s += '<option>Telangana</option>';
    //s += '<option>Maharastra</option>';
    //s += '</select>';
    //s += '</div>';
    //s += '<div class="col-lg-2"><label class="label-center">City</label><span class="required">*</span></div>';
    //s += '<div class="col-lg-4">';
    //s += '<select class="form-control" name="city" required>';
    //s += '<option disabled selected>Select</option>';
    //s += '<option>Vijayawada</option>';
    //s += '<option>Hyderabad</option>';
    //s += '<option>Ongole</option>';
    //s += '</select>';
    //s += '</div>';
    //s += '</div>';
    //s += '<div class="col-lg-12 form-data">';
    //s += '<div class="col-lg-2"><label class="label-center">Address</label><span class="required">*</span></div>';
    //s += '<div class="col-lg-4"><input type="text" class="form-control" name="address" /></div>';
    //s += '</div>';
    //s += '<hr class="line-color" />';
    //s += '</div>';
    //s += '<div class="row form">';
    //s += '<div class="col-lg-12">';
    //s += '<h4 class="heading">Event Details</h4>';
    //s += '</div>';
    //s += '<div class="col-lg-12 form-data">';
    //s += '<div class="col-lg-2"><label class="label-center">Photo</label><span class="required">*</span></div>';
    //s += '<div class="col-lg-4"><input type="file" class="form-control" name="photo" required /><p>File should be less than 150KB</p></div>';
    //s += '<div class="col-lg-2"><label class="label-center">Video</label><span class="required">*</span></div>';
    //s += '<div class="col-lg-4"><input type="file" class="form-control" name="video" required /><p>File should be less than 2MB</p></div>';
    //s += '</div>';
    //s += '<div class="col-lg-12 form-data">';
    //s += '<div class="col-lg-2"><label class="label-center">Description</label><span class="required">*</span></div>';
    //s += '<div class="col-lg-10"><textarea class="form-control description" name="description" required rows="3"></textarea><p>Remaining Characters:250</p></div>';
    //s += '</div>';
    //s += '<div class="col-lg-12 form-data">';
    //s += '<div class="col-lg-2"><label class="label-center">Address</label><span class="required">*</span></div>';
    //s += '<div class="col-lg-4"><input class="form-control goal" id="autocomplete1" onfocus="geolocate()" type="text" name="eventaddress" required /></div>';
    //s += '<div class="col-lg-2"><label class="label-center">Goal</label><span class="required">*</span></div>';
    //s += '<div class="col-lg-4"><input class="form-control goal" type="text" name="goal" required /></div>';
    //s += '</div>';
    //s += '<div class="col-lg-12 form-data">';
    //s += '<div class="col-lg-2"><label class="label-center">Start Date</label><span class="required">*</span></div>';
    //s += '<div class="col-lg-4"><input class="form-control" id="datepicker" type="text" name="startdate" required /></div>';
    //s += '<div class="col-lg-2"><label class="label-center">End Date</label><span class="required">*</span></div>';
    //s += '<div class="col-lg-4"><input class="form-control endform" id="datepicker1" type="text" name="enddate" required /></div>';
    //s += '</div>';
    //s += '<div class="col-lg-12 form-data">';
    //s += '<button class="form-right btn-primary buttonform">Create Event</button>';
    //s += '<button class="form-right btn-default buttonform">Cancel</button>'
    //s += '</div>';
    //s += '</div>';

    //$('#personal').append(s);

    //form();
    //initAutocomplete();
}


function charity() {

    $('#personal').html('');
    $('#charity').html('');
    $('#socialevent').html('');

    var s = "";
    s += '<div class="row formtop">';
    s += '<div class="col-lg-4">';
    s += '<label>Event Title</label> <span class="required">*</span>';
    s += '<input class="form-control" type="text" name="eventtitle" required />';
    s += '</div >';
    s += '<div class="col-lg-4">';
    s += '<label>Organiser Name</label><span class="required">*</span>';
    s += '<input class="form-control" type="text" name="organisername" required />';
    s += '</div>';
    s += '<div class="col-lg-4">';
    s += '<label>Category</label><span class="required">*</span>';
    s += '<select class="form-control" name="category" required>';
    s += '<option disabled selected>Select</option>';
    s += '<option>Animals and Pets</option>';
    s += '<option>Family and Support</option>';
    s += '<option>Fatiligious Organisation</option>';
    s += '<option>Education</option>';
    s += '</select>';
    s += '</div>';
    s += '</div >';
    s += '<div class="row form">';
    s += '<div class="col-lg-12">';
    s += '<h4 class="heading">Charity Information</h4>';
    s += '</div>';
    s += '<div class="col-lg-12 form-data">';
    s += '<div class="col-lg-2"><label class="label-center">Charity Name</label><span class="required">*</span></div>';
    s += '<div class="col-lg-4"><input type="text" class="form-control" name="charityname" required /></div>';
    s += '<div class="col-lg-2"><label class="label-center">Person of Contact</label><span class="required">*</span></div>';
    s += '<div class="col-lg-4"><input type="text" class="form-control" name="personofcontact" required /></div>'
    s += '</div>';
    s += '<div class="col-lg-12 form-data">';
    s += '<div class="col-lg-3"><label class="label-center">Charity Identification Number</label><span class="required">*</span></div>';
    s += '<div class="col-lg-9"><input type="text" class="form-control charityidentificationnumber" name="charityidentificationnumber" required /></div>';
    s += '</div>';
    s += '<div class="col-lg-12 form-data">';
    s += '<div class="col-lg-2"><label class="label-center">Phone Number</label><span class="required">*</span></div>';
    s += '<div class="col-lg-4"><input type="text" class="form-control" name="phonenumber" required /></div>';
    s += '<div class="col-lg-2"><label class="label-center">Email ID</label><span class="required">*</span></div>';
    s += '<div class="col-lg-4"><input type="text" class="form-control" name="emailid" /></div>';
    s += '</div>';
    s += '<div class="col-lg-12 form-data">';;
    s += '<div class="col-lg-2"><label class="label-center">Country</label><span class="required">*</span></div>';
    s += '<div class="col-lg-4">';
    s += '<select class="form-control" name="country" required>';
    s += '<option disabled selected>Select</option>';
    s += '<option>India</option>';
    s += '<option>United States of America</option>';
    s += '<option>Australia</option>'
    s += '</select>';
    s += '</div>';
    s += '<div class="col-lg-2"><label class="label-center">State</label><span class="required">*</span></div>';
    s += '<div class="col-lg-4">';
    s += '<select class="form-control" name="state" required>';
    s += '<option disabled selected>Select</option>';
    s += '<option>Andhra Pradesh</option>';
    s += '<option>Telangana</option>';
    s += '<option>Maharastra</option>';
    s += '</select>';
    s += '</div>';
    s += '</div>';
    s += '<div class="col-lg-12 form-data">';
    s += '<div class="col-lg-2"><label class="label-center">City</label><span class="required">*</span></div>';
    s += '<div class="col-lg-4">';
    s += '<select class="form-control" name="city" required>';
    s += '<option disabled selected>Select</option>';
    s += '<option>Vijayawada</option>';
    s += '<option>Hyderabad</option>';
    s += '<option>Ongole</option>';
    s += '</select>';
    s += '</div>';
    s += '</div>';
    s += '<div class="col-lg-12 form-data">';
    s += '<div class="col-lg-2"><label class="label-center">Address</label><span class="required">*</span></div>';
    s += '<div class="col-lg-4"><input type="text" class="form-control" name="address" /></div>';
    s += '</div>';
    s += '<hr class="line-color" />';
    s += '</div>';
    s += '<div class="row form">';
    s += '<div class="col-lg-12">';
    s += '<h4 class="heading">Event Details</h4>';
    s += '</div>';
    s += '<div class="col-lg-12 form-data">';
    s += '<div class="col-lg-2"><label class="label-center">Photo</label><span class="required">*</span></div>';
    s += '<div class="col-lg-4"><input type="file" class="form-control" name="photo" required /><p>File should be less than 150KB</p></div>';
    s += '<div class="col-lg-2"><label class="label-center">Video</label><span class="required">*</span></div>';
    s += '<div class="col-lg-4"><input type="file" class="form-control" name="video" required /><p>File should be less than 2MB</p></div>';
    s += '</div>';
    s += '<div class="col-lg-12 form-data">';
    s += '<div class="col-lg-2"><label class="label-center">Description</label><span class="required">*</span></div>';
    s += '<div class="col-lg-10"><textarea class="form-control description" name="description" required rows="3"></textarea><p>Remaining Characters:250</p></div>';
    s += '</div>';
    s += '<div class="col-lg-12 form-data">';
    s += '<div class="col-lg-2"><label class="label-center">Address</label><span class="required">*</span></div>';
    s += '<div class="col-lg-4"><input class="form-control goal" id="autocomplete1" onfocus="geolocate()" type="text" name="eventaddress" required /></div>';
    s += '<div class="col-lg-2"><label class="label-center">Goal</label><span class="required">*</span></div>';
    s += '<div class="col-lg-4"><input class="form-control goal" type="text" name="goal" required /></div>';
    s += '</div>';
    s += '<div class="col-lg-12 form-data">';
    s += '<div class="col-lg-2"><label class="label-center">Start Date</label><span class="required">*</span></div>';
    s += '<div class="col-lg-4"><input class="form-control" id="datepicker" type="text" name="startdate" required /></div>';
    s += '<div class="col-lg-2"><label class="label-center">End Date</label><span class="required">*</span></div>';
    s += '<div class="col-lg-4"><input class="form-control endform" id="datepicker1" type="text" name="enddate" required /></div>';
    s += '</div>';
    s += '<div class="col-lg-12 form-data">';
    s += '<button class="form-right btn-primary buttonform">Create Event</button>';
    s += '<button class="form-right btn-default buttonform">Cancel</button>';
    s += '</div>';
    s += '</div>';

    $('#charity').append(s);

    form();
    initAutocomplete();
}

function socialevent() {

    $('#personal').html('');
    $('#charity').html('');
    $('#socialevent').html('');

    var s = "";

    s += '  <div class="row formtop">';
    s += '<div class="col-lg-4">';
    s += '  <label>Event Title</label> <span class="required">*</span>';
    s += '<input class="form-control" type="text" name="eventtitle" required />';
    s += '</div >';
    s += '<div class="col-lg-4">';
    s += '<label>Organiser Name</label><span class="required">*</span>';
    s += '<input class="form-control" type="text" name="organisername" required />';
    s += '</div>';
    s += '<div class="col-lg-4">';
    s += '<label>Category</label><span class="required">*</span>';
    s += '<select class="form-control" name="category" required>';
    s += '<option disabled selected>Select</option>';
    s += '<option>Animals and Pets</option>';
    s += '<option>Family and Support</option>';
    s += '<option>Fatiligious Organisation</option>';
    s += '<option>Education</option>';
    s += '</select>';
    s += '</div>';
    s += '</div >';
    s += '<div class="row form">';
    s += '<div class="col-lg-12">';
    s += '<h4 class="heading">Event Details</h4>';
    s += '</div>';
    s += '<div class="col-lg-12 form-data">';
    s += '<div class="col-lg-2"><label class="label-center">Photo</label><span class="required">*</span></div>';
    s += '<div class="col-lg-4"><input type="file" class="form-control" name="photo" required /><p>File should be less than 150KB</p></div>';
    s += '<div class="col-lg-2"><label class="label-center">Video</label><span class="required">*</span></div>';
    s += '<div class="col-lg-4"><input type="file" class="form-control" name="video" required /><p>File should be less than 2MB</p></div>';
    s += '</div>';
    s += '<div class="col-lg-12 form-data">';
    s += '<div class="col-lg-2"><label class="label-center">Description</label><span class="required">*</span></div>';
    s += '<div class="col-lg-10"><textarea class="form-control description" name="description" required rows="3"></textarea><p>Remaining Characters:250</p></div>';
    s += '</div>';
    s += '<div class="col-lg-12 form-data">';
    s += '<div class="col-lg-2"><label class="label-center">Address</label><span class="required">*</span></div>';
    s += '<div class="col-lg-4"><input class="form-control goal" id="autocomplete1" onfocus="geolocate()" type="text" name="eventaddress" required /></div>';
    s += '<div class="col-lg-2"><label class="label-center">Goal</label><span class="required">*</span></div>';
    s += '<div class="col-lg-4"><input class="form-control goal" type="text" name="goal" required /></div>';
    s += '</div>';
    s += '<div class="col-lg-12 form-data">';
    s += '<div class="col-lg-2"><label class="label-center">Start Date</label><span class="required">*</span></div>';
    s += '<div class="col-lg-4"><input class="form-control" id="datepicker" type="text" name="startdate" required /></div>';
    s += '<div class="col-lg-2"><label class="label-center">End Date</label><span class="required">*</span></div>';
    s += '<div class="col-lg-4"><input class="form-control endform" id="datepicker1" type="text" name="enddate" required /></div>';
    s += '</div>';
    s += '<div class="col-lg-12 form-data">';
    s += '<button class="form-right btn-primary buttonform">Create Event</button>';
    s += '<button class="form-right btn-default buttonform">Cancel</button>';
    s += '</div>';
    s += '</div>';

    $('#socialevent').append(s);

    form();
    initAutocomplete();
}