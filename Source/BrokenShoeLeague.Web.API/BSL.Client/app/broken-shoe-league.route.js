(function () {
    "use strict";
    angular
        .module('eeBrokenShoeLeague')
        .config(['$stateProvider', '$urlRouterProvider', configRouter]);

    function configRouter($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise("/");

        $stateProvider
            .state("home", {
                url: "/",
                templateUrl: "BSL.Client/app/home/views/home.html",
            })
            .state("leaders", {
                url: "/leaders",
                templateUrl: "BSL.Client/app/leader/views/leaders.html",
                controller: "LeadersCtrl as vm"
            })
            .state("seasons", {
                url: "/seasons",
                templateUrl: "BSL.Client/app/season/views/seasonList.html"
            })
            .state("gallery", {
                url: "/gallery",
                templateUrl: "BSL.Client/app/gallery/views/gallery.html"
            })
            .state("news", {
                url: "/news",
                templateUrl: "BSL.Client/app/news/views/newsList.html",
                controller: "NewsCtrl as vm",
                resolve: {
                    NewsService: "NewsService",

                    news: function(NewsService) {
                        return NewsService.GetNews();
                    }
                }
            })
            .state("achievements", {
                url: "/achievements",
                templateUrl: "BSL.Client/app/achievements/views/achievements.html",
                controller: "AchievementsDetailsCtrl as vm",
                resolve: {
                    AchievementService: "AchievementService",
                    PlayersService: "PlayersService",

                    achievements: function(AchievementService) {
                        return AchievementService.GetAchievements();
                    },

                    players: function(PlayersService) {
                        return PlayersService.GetPlayers();
                    }
                }
            });
    }
})();