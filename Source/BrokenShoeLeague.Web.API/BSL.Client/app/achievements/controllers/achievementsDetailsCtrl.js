(function() {
    "use strict";
    angular.module("eeBrokenShoeLeague")
        .controller("AchievementsDetailsCtrl",
            achievementsDetails);

    achievementsDetails.inject = ['achievements', 'players', 'AchievementService'];

    function achievementsDetails(achievements, players, AchievementService) {

        var vm = this;

        vm.PlayerSelected = "";
        vm.AchievementList = achievements;
        vm.PlayerList = players;
        vm.PlayerAchievements = {};

        vm.LoadPlayerAchievements = loadPlayerAchievements;

        function loadPlayerAchievements() {
            AchievementService.GetPlayerAchievements(vm.PlayerSelected).then(
                function(data) {
                    vm.PlayerAchievements = data;
                },
                function(status) {
                });
        }
    }

}());