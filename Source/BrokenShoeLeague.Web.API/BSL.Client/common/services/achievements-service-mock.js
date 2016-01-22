(function() {
    "use strict";

    var app = angular
        .module("achievementServiceMock",
        ["ngMockE2E"]);

    app.run(function($httpBackend) {

        var achievements = [
            {
                ImageUrl: "medal53.svg",
                Name: "first achievement",
                Description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla venenatis ante augue. Phasellus volutpat neque ac dui mattis vulputate.."
            },
            {
                ImageUrl: "goal4.svg",
                Name: "second achievement",
                Description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla venenatis ante augue. Phasellus volutpat neque ac dui mattis vulputate.."
            },
            {
                ImageUrl: "hand137.svg",
                Name: "third achievement",
                Description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla venenatis ante augue. Phasellus volutpat neque ac dui mattis vulputate.."
            },
            {
                ImageUrl: "medal53.svg",
                Name: "first achievement",
                Description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla venenatis ante augue. Phasellus volutpat neque ac dui mattis vulputate.."
            },
            {
                ImageUrl: "goal4.svg",
                Name: "second achievement",
                Description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla venenatis ante augue. Phasellus volutpat neque ac dui mattis vulputate.."
            },
            {
                ImageUrl: "hand137.svg",
                Name: "third achievement",
                Description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla venenatis ante augue. Phasellus volutpat neque ac dui mattis vulputate.."
            },
            {
                ImageUrl: "medal53.svg",
                Name: "first achievement",
                Description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla venenatis ante augue. Phasellus volutpat neque ac dui mattis vulputate.."
            },
            {
                ImageUrl: "medal53.svg",
                Name: "first achievement",
                Description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla venenatis ante augue. Phasellus volutpat neque ac dui mattis vulputate.."
            },
            {
                ImageUrl: "goal4.svg",
                Name: "second achievement",
                Description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla venenatis ante augue. Phasellus volutpat neque ac dui mattis vulputate.."
            },
            {
                ImageUrl: "hand137.svg",
                Name: "third achievement",
                Description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla venenatis ante augue. Phasellus volutpat neque ac dui mattis vulputate.."
            },
            {
                ImageUrl: "medal53.svg",
                Name: "first achievement",
                Description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla venenatis ante augue. Phasellus volutpat neque ac dui mattis vulputate.."
            },
            {
                ImageUrl: "medal53.svg",
                Name: "first achievement",
                Description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla venenatis ante augue. Phasellus volutpat neque ac dui mattis vulputate.."
            },
            {
                ImageUrl: "goal4.svg",
                Name: "second achievement",
                Description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla venenatis ante augue. Phasellus volutpat neque ac dui mattis vulputate.."
            },
            {
                ImageUrl: "hand137.svg",
                Name: "third achievement",
                Description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla venenatis ante augue. Phasellus volutpat neque ac dui mattis vulputate.."
            },
            {
                ImageUrl: "medal53.svg",
                Name: "first achievement",
                Description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla venenatis ante augue. Phasellus volutpat neque ac dui mattis vulputate.."
            }
        ];

        var apiUrl = "http://localhost:60704/api/v1/";
        //var achievementsImagesUrl = 'BSL.Client/assets/images/football-icons/';
        $httpBackend.whenGET(apiUrl + "achievements").respond(achievements);

        var playerAchievementsUrl = new RegExp(apiUrl + "achievements/player/" + "[a-zA-Z0-9]+", "");
        $httpBackend.whenGET(playerAchievementsUrl).respond(achievements.slice(1, 4));

        
        // Pass through any requests for application files
        $httpBackend.whenGET(/BSL.Client/).passThrough();
    });
})();