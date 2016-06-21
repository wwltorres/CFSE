(function () {
  'use strict';

  angular
    .module('app', [
      'ngAnimate',
      'ngStorage',
      'ngCookies',
      'ngSanitize',
      'ngResource',
      'ui.bootstrap',
      'ui.router',
      'permission',
      'cfp.loadingBar',
      'pascalprecht.translate',
      'app.layout'
    ]);
})();