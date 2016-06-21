(function () {
  'use strict';

  angular
    .module('app.modules.employer')
    .component('employer', {
      templateUrl: 'employer.template.html',
      controller: EmployerController,
      controllerAs: 'employer',
      bindings: {

      }
    });

  EmployerController.$inject = [];

  function EmployerController() {

    var vm = this;

    activate();

    function activate() {
      vm.transactions = [];

      vm.transactions.push({ id: 1, name: 'Certificacion de deuda' });
      vm.transactions.push({ id: 1, name: 'Certificacion de deuda' });
    }
  }
})();
