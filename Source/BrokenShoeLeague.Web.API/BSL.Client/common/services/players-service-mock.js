(function() {
    "use strict";

    var app = angular
        .module("playersServiceMock",
        ["ngMockE2E"]);

    app.run(function($httpBackend) {

        var players = [
            {
                Name: "yassiel",
                ProfileImgUrl: 'medal53.svg',
            },
            {
                Name: "charlie",
                ProfileImgUrl: 'medal53.svg',
            },
            {
                Name: "omar",
                ProfileImgUrl: 'medal53.svg',
            },
            {
                Name: "rolando",
                ProfileImgUrl: 'medal53.svg',
            },
            {
                Name: "wilber",
                ProfileImgUrl: 'medal53.svg',
            }
        ];

        var apiUrl = 'http://localhost:60704/api/v1/';
        //var achievementsImagesUrl = 'BSL.Client/assets/images/football-icons/';
        $httpBackend.whenGET(apiUrl + 'players').respond(players);
        
        // Pass through any requests for application files
        $httpBackend.whenGET(/BSL.Client/).passThrough();
    });
})();