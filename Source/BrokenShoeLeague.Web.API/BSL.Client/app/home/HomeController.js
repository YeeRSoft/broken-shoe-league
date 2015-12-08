(function() {
    angular
        .module('eeBrokenShoeLeague')
        .controller('HomeController', homeCtroller);

    homeCtroller.$inject = ['$mdBottomSheet', '$mdSidenav', '$mdDialog', '$location'];

    function homeCtroller($mdBottomSheet, $mdSidenav, $mdDialog, $location) {
        var vm = this;

        vm.toggleSidenav = function (menuId) {
            $mdSidenav(menuId).toggle();
        };
        vm.menu = [
            {
                link: '',
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
                icon: 'message'
            },
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
        ];
        vm.admin = [
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
        ];
    }
})()