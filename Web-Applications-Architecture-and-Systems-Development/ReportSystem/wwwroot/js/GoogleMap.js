var GoogleApiKey = "AIzaSyCb9WI9xcpb1A5Gs2fnfKkh54EcXsw2wyE";


// Initialize and add the map
function initMap() {
    var universityLocation = {
        lat: 35.902216,
        lng: 14.484743
    };

    var map = new google.maps.Map(
    document.getElementById('map'), {
        zoom: 16,
        center: {
            lat: universityLocation.lat,
            lng: universityLocation.lng
        }
    });


    var marker = new google.maps.Marker({
        position: {
            lat: universityLocation.lat,
            lng: universityLocation.lng
        },
        map: map,
        draggable: true
    });

    var geocoder = new google.maps.Geocoder;
    var infowindow = new google.maps.InfoWindow;


    marker.addListener('dragend',
        (ev) => {
            console.log(ev.latLng.lat() + "," + ev.latLng.lng());
            geocodeLatLng(geocoder, map, infowindow, ev.latLng.lat(), ev.latLng.lng());
            $('#rLat').attr("value", ev.latLng.lat());
            $('#rLong').attr("value", ev.latLng.lng());
        });

    function geocodeLatLng(geocoder, map, infowindow, lat, lng) {

        var latlng = { lat: lat, lng: lng };
        geocoder.geocode({ 'location': latlng }, function (results, status) {
            if (status === 'OK') {
                if (results[0]) {
                    //map.setZoom(11);
                    infowindow.setContent(results[0].formatted_address);
                    infowindow.open(map, marker);
                    //console.log(results[0].formatted_address);
                    $('#computedAddress').attr("value", results[0].formatted_address);
                } else {
                    window.alert('No results found');
                }
            } else {
                window.alert('Geocoder failed due to: ' + status);
            }
        });
    };

};


/*I: fn-> to show marker on the map of a specific report
        the lat and long is required apart from setting the div where the map should be rendered with width and hight.*/
function setMarkerWithAddressOnMap(lat, lng) {
    var geocoder = new google.maps.Geocoder;
    var infowindow = new google.maps.InfoWindow;
    var map = new google.maps.Map(
    document.getElementById('divname'), {
        zoom: 16,
        center: {
            lat: lat,
            lng: lng
        }
    });

    var marker = new google.maps.Marker({
    position: {
        lat: lat,
        lng: lng
    },
    map: map,
    draggable: false
    });


    marker.addListener('load',
        (ev) => {
            console.log(ev.latLng.lat() + "," + ev.latLng.lng());
            geocodeLatLng(geocoder, map, infowindow, ev.latLng.lat(), ev.latLng.lng());
        });


    function geocodeLatLng(geocoder, map, infowindow, lat, lng) {

        var latlng = { lat: lat, lng: lng };
        geocoder.geocode({ 'location': latlng }, function (results, status) {
            if (status === 'OK') {
                if (results[0]) {
                    //map.setZoom(11);
                    infowindow.setContent(results[0].formatted_address);
                    infowindow.open(map, marker);
                    //console.log(results[0].formatted_address);
                } else {
                    window.alert('No results found');
                }
            } else {
                window.alert('Geocoder failed due to: ' + status);
            }
        });
    };
}



