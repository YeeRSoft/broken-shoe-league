(function () {
    angular
        .module('eeBrokenShoeLeague')
        .constant("config",
        {
            apiUrl: 'http://localhost:60704/api/v1/',
            achievementsImagesUrl: 'BSL.Client/assets/images/football-icons/'
        });
})()