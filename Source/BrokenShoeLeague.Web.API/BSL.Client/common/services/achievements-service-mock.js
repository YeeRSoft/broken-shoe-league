(function() {
    "use strict";

    var app = angular
        .module("achievementServiceMock",
        ["ngMockE2E"]);

    app.run(function($httpBackend) {

        var achievements = [
            {
                ImmageUrl: "medal53.svg",
                Name: 'first achievement'
            },
            {
                ImmageUrl: "goal4.svg",
                Name: 'second achievement'
            },
            {
                ImmageUrl: "hand137.svg",
                Name: 'third achievement'
            }
        ];
        var apiUrl = 'http://localhost:60704/api/v1/';
        //var achievementsImagesUrl = 'BSL.Client/assets/images/football-icons/';
        $httpBackend.whenGET(apiUrl + 'achivements').respond(achievements);
        
        // Pass through any requests for application files
        $httpBackend.whenGET(/BSL.Client/).passThrough();
    });
})();