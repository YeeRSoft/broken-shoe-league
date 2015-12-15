(function () {
    angular
        .module('eeBrokenShoeLeague')
        .config(configRoutes);

    function configRoutes($routeProvider) {
        //$routeProvider.when('/start', {
        //    templateUrl: '/app/partials/gameOfDrones/start.html',
        //    controller: 'StartGameController'
        //});

        $routeProvider.otherwise({
            redirectTo: '/start'
        });
    }
})()