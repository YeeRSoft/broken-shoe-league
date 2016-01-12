(function() {
    angular
        .module('eeBrokenShoeLeague')
        .controller('HomeController', homeCtroller);

    homeCtroller.$inject = ['$mdBottomSheet', '$mdSidenav', '$mdDialog', '$location'];

    function homeCtroller($mdBottomSheet, $mdSidenav, $mdDialog, $location) {
        var vm = this;

        vm.go = function (url) { $location.path(url); }

        vm.toggleSidenav = function (menuId) {
            $mdSidenav(menuId).toggle();
        };

        vm.menu = [
            {
                header: '',
                items: [
                    {
                        link: 'dashboard',
                        title: 'Dashboard',
                        icon: 'dashboard'
                    },
                    {
                        link: '',
                        title: 'Gallery',
                        icon: 'view_carousel'
                    },
                    {
                        link: '',
                        title: 'News',
                        icon: 'new_releases'
                    }
                ]
            },
            {
                header: 'Statistics',
                items: [
                    {
                        link: '',
                        title: 'Seasons',
                        icon: 'today'
                    },
                    {
                        link: '',
                        title: 'Achievements',
                        icon: 'view_list'
                    }
                ]
            }
        ];
    }
})()