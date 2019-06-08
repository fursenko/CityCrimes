var map;
var result = [];
var isMapLoaded = false;

window.onload = function () {

    hideAllContent();
    showContent('#aboutContent');
    initialize();
};

function initialize() {
    $('#aboutLink').click(function (e) {
        showContent('#aboutContent');
    });

    $('#mapLink').click(function (e) {
        showContent('#mapContent');
        if(!isMapLoaded){
        $.getScript("https://maps.googleapis.com/maps/api/js?key=AIzaSyCOtSsOKPpHiCi4AxAi_KHNwdEzfXGUiaw&libraries=visualization&callback=initMap", function () {});
        }
     });

     $('#reportLink').click(function (e) {
        showContent('#reportContent');
     });
}

function hideAllContent() {
    $('#reportContent').hide();
    $('#reportLink').removeClass('active');
    $('#mapContent').hide();
    $('#mapLink').removeClass('active');
    $('#aboutContent').hide();
    $('#aboutLink').removeClass('active');
 }

function showContent(id) {
    hideAllContent();
    $(id).show();
    var selector = id + '';
    $(selector.replace('Content', '') + 'Link').addClass('active');
}

function initMap() {
   map = new google.maps.Map(document.getElementById('map'), {
        zoom: 11,
        center: {lat: 41.880302, lng: -87.696388},
        mapTypeId: 'roadmap'
      });

      $( "#map" ).css( "height", function( index ) {
        return parseInt(window.innerHeight - 54) + 'px';
      });

      initControl();
      isMapLoaded = true;
  }

  function initControl() {
    
    $('#show').click(function () {
      console.log('click');
      $.ajax({
        url: "../api/crimes",
        contentType: 'application/json',
        data: { type: $('#crimeType').children('option:selected').val(), year: $('#year').children('option:selected').val() },
        type: "GET",
        success: function (response) {
          clearMap();

            for (let i = 0; i < response.length; i++) {

              setTimeout(function () {
                const element = response[i];
                    // Add the circle for this city to the map.
                    var cityCircle = new google.maps.Circle({
                      strokeColor: '#CE2525',
                      strokeOpacity: 0.6,
                      strokeWeight: 2,
                      fillColor: '#F1AAA5',
                      fillOpacity: 0.4,
                      map: map,
                      center: { lat: parseFloat(response[i].latitude), lng: parseFloat(response[i].longitude) },
                      radius: 20
                    });

                    result.push(cityCircle);

                    $('#status').width(parseInt(((100 / (response.length)) * (i + 1)) + 1) + '%');
              }, 15);
              
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
    });

    $('#clear').on('click', function () {
      clearMap();
    });
  }

  function clearMap() {
    result.forEach(function (element) {
      element.setMap(null);
    });
    result = [];
    $('#status').width('0%');
  };