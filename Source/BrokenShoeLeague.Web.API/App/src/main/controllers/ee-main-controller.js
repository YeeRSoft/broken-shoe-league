(function() {
    angular
        .module('eeBrokenShoeLeague')
        .controller('eeMainController', eeMainController);

    eeMainController.$inject = ['$mdSidenav', '$location'];

    function eeMainController($mdSidenav, $location) {
        var vm = this;

        vm.go = function (url) { $location.path(url); }
        vm.toggleSidenav = function (sideNavId) { $mdSidenav(sideNavId).toggle(); }        
        vm.sideNavItems = [
            {
                name: "General",
                items: [
                    { name: "Dashboard", url: "", icon: "" },
                    { name: "Gallery", url: "", icon: "" },
                    { name: "News", url: "", icon: ""}
                ]
            },
            {
                name: "User",
                items: [
                  { name: "Profile", url: "", icon: "" },
                  { name: "Messages", url: "", icon: ""}
                ]
            },
            {
                name: "Statistics",
                items: [
                    { name: "Match Day Results", url: "", icon: ""},
                    { name: "Ranking", url: "", icon: "" }
                ]
            }
        ];
    }
})()