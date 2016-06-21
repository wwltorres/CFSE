(function () {
  'use strict';

  angular
    .module('app')
    .run(appRun);

  appRun.$inject = ['$rootScope'];

  function appRun($rootScope) {
    $rootScope.app = {
      organization: 'CFSE',
      year: new Date().getFullYear(),
      views: {
        animation: 'ng-fadeInLeft2'
      }
    };
  }

})();