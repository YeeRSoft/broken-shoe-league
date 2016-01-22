(function() {
    "use strict";

    var app = angular
        .module("newsServiceMock",
        ["ngMockE2E"]);

    app.run(function($httpBackend) {

        var news = [
            {
                Title: "New 1",
                ImgUrl: "check_circle",
                Text: "some fake text for news...."
            },
            {
                Title: "New 2",
                ImgUrl: "check_circle",
                Text: "some fake text for news...."
            },
            {
                Title: "New 3",
                ImgUrl: "info",
                Text: "some fake text for news...."
            },
            {
                Title: "New 4",
                ImgUrl: "check_circle",
                Text: "some fake text for news...."
            },
            {
                Title: "New 5",
                ImgUrl: "check_circle",
                Text: "some fake text for news...."
            },
            {
                Title: "New 6",
                ImgUrl: "info",
                Text: "some fake text for news...."
            },
            {
                Title: "New 7",
                ImgUrl: "info",
                Text: "some fake text for news...."
            },
            {
                Title: "New 8",
                ImgUrl: "check_circle",
                Text: "some fake text for news...."
            }
        ];

        var apiUrl = 'http://localhost:60704/api/v1/';
        $httpBackend.whenGET(apiUrl + 'news').respond(news);
        
    });
})();