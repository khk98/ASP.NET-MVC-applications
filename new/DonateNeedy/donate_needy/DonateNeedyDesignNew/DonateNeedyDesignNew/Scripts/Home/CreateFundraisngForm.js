

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
function CountChar(val) {
    var len = val.value.length;
    if (len > 250) {
        val.value = val.value.substring(0, 250);
    } else {
        $('#descriptionCharVal').text(250 - len);
    }
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





//function charity() {

//    $('#personal').html('');
//    $('#charity').html('');
//    $('#socialevent').html('');

//    var s = "";
    
//    s += ' <form><div class="form-group formtop"><div class="form-width form-inline-user"> <label>Event Title</label> <span class="required">*</span><input class="form-control" type="text" name="eventtitle" required pattern="[a-zA-Z\s]+" /></div><div class="form-width form-inline-user"><label>Organiser Name</label><span class="required">*</span><input class="form-control" type="text" name="organisername" required /></div><div class="form-width form-inline-user"><label>Category</label><span class="required">*</span><select class="form-control" name="category" required> <option disabled selected>Select</option><option>Animals and Pets</option><option>Family and Support</option><option>Fatiligious Organisation</option><option>Education</option> </select></div></div ><h4 class="Personal-Information">Charity Information</h4> <div class="form-group"> <div class="form-width form-inline-user"><label class="control-label">Charity Name</label><input maxlength="100" type="text" class="form-control" placeholder="Enter Charity Name" required pattern="[a-zA-Z\s]+" /> </div><div class="form-width form-inline-user"><label class="control-label">Charity Identification Number</label> <input maxlength="100" type="text" class="form-control" placeholder="Enter Charity Identification Number" pattern="^[0-9]*$" required /> </div></div><div class="form-group"><div class="form-width form-inline-user"><label class="control-label">Person of Contact</label><input maxlength="100" type="text" class="form-control" placeholder="Enter Person of Contact" required pattern="[a-zA-Z\s]+" /></div></div><div class="form-group"><div class="form-width form-inline-user"><label class="control-label">Phone Number</label><input maxlength="100" type="text" class="form-control" placeholder="Enter Phone Number" required pattern="^[0-9]*$" /></div><div class="form-width form-inline-user"><label class="control-label">Email</label><input maxlength="100" type="email" class="form-control" placeholder="Enter Email" required /></div> </div><div class="form-group"><div class="form-width form-inline-user"><label class="control-label">State</label><input maxlength="100" type="text" class="form-control" placeholder="Enter State" required pattern="[a-zA-Z\s]+" /> </div><div class="form-width form-inline-user"><label class="control-label">City</label> <input maxlength="100" type="text" class="form-control" placeholder="Enter City" required pattern="[a-zA-Z\s]+" /></div></div><div class="form-group"><div class="form-width form-inline-user"><label class="control-label">Address</label><textarea maxlength="100" type="email" class="form-control" placeholder="Enter Address" required ></textarea></div></div><hr class="line-color" /><h4 class="Personal-Information">Event Details</h4><div class="form-group"> <div class="form-width form-inline-user"><label class="control-label">Photo</label><input type="file" class="form-control" name="photo" required /><p class="Remaining-charcters">File should be less than 150KB</p></div><div class="form-width form-inline-user"><label class="control-label">Video</label><input type="file" class="form-control" name="video" required /><p class="Remaining-charcters">File should be less than 2MB</p></div></div><div class="form-group"><div class="form-width form-inline-user"><label class="control-label">Description</label><textarea class="form-control description" name="description" required rows="5 " placeholder="Enter Description"></textarea><p class="Remaining-charcters">Remaining Characters:250</p></div></div><div class="form-group"><div class="form-width form-inline-user"><label class="control-label">Goal</label><input class="form-control goal" type="text" name="goal" required /></div></div><div class="form-group"><div class="form-width form-inline-user"> <label class="control-label">Start Date</label><input class="form-control" id="datepicker" type="text" name="startdate" required /></div><div class="form-width form-inline-user"><label class="control-label">End Date</label><input class="form-control endform" id="datepicker1" type="text" name="enddate" required /></div></div> </div ><button class="btn btn-primary nextBtn pull-right Rectangle-createfundform" type="submit">Create</button> <button class="btn btn-primary nextBtn pull-right Rectangle-cancelform" type="reset">Cancel</button></form > ';

//    $('#charity').append(s);

//    form();
//    initAutocomplete();
//}

function socialevent() {

    $('#personal').html('');
    $('#charity').html('');
    $('#socialevent').html('');

    var s = "";

    s += ' <form><div class="form-group formtop"><div class="form-width form-inline-user"> <label>Event Title</label> <span class="required">*</span><input class="form-control" type="text" name="eventtitle" required /></div><div class="form-width form-inline-user"><label>Organiser Name</label><span class="required">*</span><input class="form-control" type="text" name="organisername" required /></div><div class="form-width form-inline-user"><label>Category</label><span class="required">*</span> <select class="form-control" name="category" required><option disabled selected>Select</option> <option>Animals and Pets</option><option>Family and Support</option><option>Fatiligious Organisation</option> <option>Education</option></select></div></div > <h4 class="Personal-Information">Event Details</h4> <div class="form-group"> <div class="form-width form-inline-user"><label class="control-label">Photo</label><input type="file" class="form-control" name="photo" required /><p class="Remaining-charcters">File should be less than 150KB</p> </div><div class="form-width form-inline-user"><label class="control-label">Video</label><input type="file" class="form-control" name="video" required /><p class="Remaining-charcters">File should be less than 2MB</p></div></div><div class="form-group"><div class="form-width form-inline-user"><label class="control-label">Description</label><textarea class="form-control description" name="description" required rows="5 " placeholder="Enter Description"></textarea><p class="Remaining-charcters">Remaining Characters:250</p></div></div><div class="form-group"><div class="form-width form-inline-user"><label class="control-label">Goal</label> <input class="form-control goal" type="text" name="goal" required /> </div> </div> <div class="form-group"><div class="form-width form-inline-user"> <label class="control-label">Start Date</label><input class="form-control" id="datepicker" type="text" name="startdate" required /></div><div class="form-width form-inline-user"><label class="control-label">End Date</label><input class="form-control endform" id="datepicker1" type="text" name="enddate" required /></div></div><button class="btn btn-primary nextBtn pull-right Rectangle-createfundform" type="submit">Create</button><button class="btn btn-primary nextBtn pull-right Rectangle-cancelform" type="reset">Cancel</button></form>';


    $('#socialevent').append(s);

    form();
    initAutocomplete();
}

