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
                header: 'General',
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
                        title: 'Matchday Results',
                        icon: 'today'
                    },
                    {
                        link: '',
                        title: 'Ranking',
                        icon: 'view_list'
                    }
                ]
            },
            {
                header: "User",
                items: [
                    { title: "Profile", link: "", icon: "perm_identity" },
                    { title: "Messages", link: "", icon: "message" }
                ]
            },
            {
                header: "Manage",
                items: [
                    {
                        link: '',
                        title: 'Trash',
                        icon: 'delete'
                    },
                    {
                        link: 'showListBottomSheet($event)',
                        title: 'Settings',
                        icon: 'settings'
                    }
                ]
            }
        ];
    }
})()