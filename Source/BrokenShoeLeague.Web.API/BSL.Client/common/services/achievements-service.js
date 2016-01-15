(function () {
    "use strict";

    angular
     .module("common.services")
     .factory("achievementService",
             [achievementService]);

    achievementService.$inject = ["config", '$http', '$q'];

    function achievementService(config, $http, $q)
    {
        return {
            GetAllAchievements : getAllAchievements
        }

        function getAllAchievements() {

        }
    }
}());