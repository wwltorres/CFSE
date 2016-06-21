(function () {
  'use strict';

  angular
    .module('app.layout')
    .component('layoutHeader', {
      templateUrl: 'app/components/layout/layoutHeader.template.html',
      controller: LayoutHeaderController,
      controllerAs: 'vm'
    });

  LayoutHeaderController.$inject = []; 

  function LayoutHeaderController() {
    var vm = this;

    activate();

    function activate() { }
  }
})();
