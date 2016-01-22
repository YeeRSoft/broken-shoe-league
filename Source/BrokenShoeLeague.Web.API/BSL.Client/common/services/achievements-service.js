(function () {
    "use strict";

    angular
     .module("common.services")
     .factory("AchievementService",
             achievementService);

    achievementService.$inject = ["config", '$http', '$q'];

    function achievementService(config, $http, $q)
    {
        return {
            GetAchievements: getAchievements,
            GetPlayerAchievements: getPlayerAchievements
        }

        function getAchievements() {
            var deferred = $q.defer();

            $http.get(config.apiUrl + 'achievements')
                .success(function (data, status, headers, config) {
                    deferred.resolve(data);
                })
                .error(function (data, status, headers, config) {
                    deferred.reject(status);
                });

            return deferred.promise;
        }

        function getPlayerAchievements(playerName) {
            var deferred = $q.defer();

            $http.get(config.apiUrl + 'achievements/player/'+ playerName)
                .success(function (data, status, headers, config) {
                    deferred.resolve(data);
                })
                .error(function (data, status, headers, config) {
                    deferred.reject(status);
                });

            return deferred.promise;
        }
    }
}());