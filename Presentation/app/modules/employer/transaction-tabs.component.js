(function () {
  'use strict';

  angular
      .module('app.modules.employer')
      .component('transactionTabs', {
        templateUrl: 'transaction-tabs.template.html',
        controller: TransactionTabsController,
        controllerAs: 'transactionTabs',
        bindings: {
          transactions: '<'
        }
      });

  TransactionTabsController.$inject = [];

  function TransactionTabsController() {

    var vm = this;

    activate();

    function activate() { }
  }
})();
