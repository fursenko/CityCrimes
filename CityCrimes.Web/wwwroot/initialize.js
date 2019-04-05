      var map;
      var locationsProvider = new LocationsProvider();
      var result = [];

      function initMap() {
          
        map = new google.maps.Map(document.getElementById('map'), {
            zoom: 11,
            center: {lat: 41.880302, lng: -87.696388},
            mapTypeId: 'roadmap'
          });

          initControl();
      }

      function initControl() {
        console.log('hi');
        
        $('#show').click(function () {
          console.log('click');
          $.ajax({
            url: "../api/crimes",
            contentType: 'application/json',
            data: { type: $('#crimeType').children('option:selected').val(), year: $('#year').children('option:selected').val() },
            type: "GET",
            success: function (response) {
              result.forEach(element => {
                element.setMap(null);
              });
              result = [];
                for (let i = 0; i < response.length; i++) {
                    const element = response[i];
                        // Add the circle for this city to the map.
                        var cityCircle = new google.maps.Circle({
                          strokeColor: '#CE2525',
                          strokeOpacity: 0.6,
                          strokeWeight: 2,
                          fillColor: '#F1AAA5',
                          fillOpacity: 0.4,
                          map: map,
                          center: {lat: parseFloat(response[i].latitude), lng: parseFloat(response[i].longitude)},
                          radius: 20
                        });

                        result.push(cityCircle);
                }
            },
            error: function (error) {
                console.log(error);
            }
        });
        });
      }