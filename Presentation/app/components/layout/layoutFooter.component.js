(function () {
  'use strict';

  angular
    .module('app.layout')
    .component('layoutFooter', {
      templateUrl: 'app/components/layout/layoutFooter.template.html',
      controller: LayoutFooterController,
      controllerAs: 'vm',
      bindings: {
        organization: '<',
        year: '<'
      }
    });

  LayoutFooterController.$inject = []; 

  function LayoutFooterController() {
    var vm = this;

    activate();

    function activate() { }
  }
})();
