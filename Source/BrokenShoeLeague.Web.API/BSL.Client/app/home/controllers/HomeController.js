(function() {
    angular
        .module('eeBrokenShoeLeague')
        .controller('HomeController', homeController);

    homeController.$inject = ['$mdBottomSheet', '$mdSidenav', '$mdDialog', '$location'];

    function homeController($mdBottomSheet, $mdSidenav, $mdDialog, $location) {
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
                        title: 'Dashboard',
                        icon: 'dashboard',
                        state: 'home'
                    },
                    {
                        title: 'Gallery',
                        icon: 'view_carousel',
                        state: 'gallery'
                    },
                    {
                        title: 'News',
                        icon: 'new_releases',
                        state: 'news'
                    }
                ]
            },
            {
                header: 'Statistics',
                items: [
                    {
                        link: '',
                        title: 'Leaders',
                        icon: 'view_list',
                        state: 'leaders'
                    },
                    {
                        link: '',
                        title: 'Seasons',
                        icon: 'today',
                        state: 'seasons'
                    },
                    {
                        link: '',
                        title: 'Achievements',
                        icon: 'done_all',
                        state: 'achievements'
                    }
                ]
            }
        ];
    }
})()