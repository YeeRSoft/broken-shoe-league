(function() {
    "use strict";
    angular.module("eeBrokenShoeLeague")
        .controller("NewsCtrl",
            newsCtrl);

    newsCtrl.inject = ["news"];

    function newsCtrl(news) {

        var vm = this;

        vm.NewsList = news;
    }

}());