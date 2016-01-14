(function() {
    "use strict";
    angular.module("eeBrokenShoeLeague")
        .controller("AchievementsDetailsCtrl",
        ['achievements', achievementsDetails]);

    function achievementsDetails(achievements) {
        var vm = this;

        vm.message = "hello";
    }

}());