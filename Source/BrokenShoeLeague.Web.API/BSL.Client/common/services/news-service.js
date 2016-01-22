(function () {
    "use strict";

    angular
     .module("common.services")
     .factory("NewsService",
             newsService);

    newsService.$inject = ["config", '$http', '$q'];

    function newsService(config, $http, $q) {
        return {
            GetNews: getNews
        }

        function getNews() {
            var deferred = $q.defer();

            $http.get(config.apiUrl + 'news')
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