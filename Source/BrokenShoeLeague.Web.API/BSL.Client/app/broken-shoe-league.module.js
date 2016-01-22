(function () {
    "use strict";
    angular
        .module('eeBrokenShoeLeague', [
            'common.services',
            'ngMaterial',
            'ngMdIcons',
            'md.data.table',
            'ui.router',
            'achievementServiceMock',
            'newsServiceMock',
            'playersServiceMock'
            ]);
})()