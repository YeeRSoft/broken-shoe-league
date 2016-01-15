(function () {
    "use strict";

    (function() {
        "use strict";

        var app = angular
            .module("achievementServiceMock",
            ["ngMockE2E", "config"]);

        app.run(function ($httpBackend, config) {

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

            var apiUrl = config.apiUrl;
            $httpBackend.whenGET(apiUrl+'achievements/').respond(achievements);
        });
    });
}());