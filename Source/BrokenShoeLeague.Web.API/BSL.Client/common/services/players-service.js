(function () {
    "use strict";

    angular
     .module("common.services")
     .factory("PlayersService",
             playersService);

    playersService.$inject = ["config", '$http', '$q'];

    function playersService(config, $http, $q)
    {
        return {
            GetPlayers: getPlayers
        }

        function getPlayers() {
            var deferred = $q.defer();

            $http.get(config.apiUrl + 'players')
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