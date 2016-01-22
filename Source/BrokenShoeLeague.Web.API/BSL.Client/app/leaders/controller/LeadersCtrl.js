(function() {
    "use strict";

    angular.module("eeBrokenShoeLeague")
        .controller("LeadersCtrl", leadersController);

    leadersController.inject = [];

    function leadersController() {
        var vm = this;

        vm.selectedNew = {};

        vm.news = [];
   
    }
})();