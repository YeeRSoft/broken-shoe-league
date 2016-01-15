(function () {
    angular
        .module('eeBrokenShoeLeague')
        .constant("config",
        {
            apiUrl: 'http://localhost:31349/api/v1/',
            achievementsImagesUrl: 'BSL.Client/assets/images/football-icons/'
    });
})()