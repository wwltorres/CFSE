/**=========================================================
 * Module: RouteProvider.js
 * Provides helper functions for routes definition
 =========================================================*/

(function() {
    'use strict';

    angular
        .module('app')
        .provider('Route', RouteProvider);

    RouteProvider.$inject = [];


    function RouteProvider () {

      // Set here the base of the relative path
      // for all app views
      this.base = function (uri) {
        return 'app/template/views/' + uri;
      };

      // not necessary, only used in config block for routes
      this.$get = function () { };
    }

})();
