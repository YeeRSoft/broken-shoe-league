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

        vm.activity = [
      {
          what: 'Brunch this weekend?',
          who: 'Ali Conners',
          when: '3:08PM',
          notes: " I'll be in your neighborhood doing errands"
      },
      {
          what: 'Summer BBQ',
          who: 'to Alex, Scott, Jennifer',
          when: '3:08PM',
          notes: "Wish I could come out but I'm out of town this weekend"
      },
      {
          what: 'Oui Oui',
          who: 'Sandra Adams',
          when: '3:08PM',
          notes: "Do you have Paris recommendations? Have you ever been?"
      },
      {
          what: 'Birthday Gift',
          who: 'Trevor Hansen',
          when: '3:08PM',
          notes: "Have any ideas of what we should get Heidi for her birthday?"
      },
      {
          what: 'Recipe to try',
          who: 'Brian Holt',
          when: '3:08PM',
          notes: "We should eat this: Grapefruit, Squash, Corn, and Tomatillo tacos"
      },
        ];

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