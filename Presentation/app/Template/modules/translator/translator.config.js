/**=========================================================
 * Module: TranslateConfig.js
 =========================================================*/

(function() {
  'use strict';

  angular
    .module('app')
    .config(translateConfig);

  translateConfig.$inject = ['$translateProvider'];

  function translateConfig($translateProvider) {

    $translateProvider.useStaticFilesLoader({
      prefix: 'app/langs/',
      suffix: '.json'
    });
    $translateProvider.preferredLanguage('en');
    $translateProvider.useLocalStorage();
    $translateProvider.useSanitizeValueStrategy('sanitizeParameters');
  }
})();
