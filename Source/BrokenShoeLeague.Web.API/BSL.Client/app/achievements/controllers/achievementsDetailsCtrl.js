(function() {
    "use strict";
    angular.module("eeBrokenShoeLeague")
        .controller("AchievementsDetailsCtrl",
        achievementsDetails);

    achievementsDetails.inject = ['AchievementService'];

    function achievementsDetails(AchievementService) {
        var vm = this;

        AchievementService.GetAchievements().then(
            function(data) {
                vm.AchievementList = data;
            },
            function(status) {
            });

        vm.message = "hello";
    }

}());