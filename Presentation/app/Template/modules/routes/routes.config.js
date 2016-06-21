/**=========================================================
 * Module: RoutesConfig.js
 =========================================================*/

(function() {
    'use strict';

    angular
        .module('app')
        .config(routesConfig);

    routesConfig.$inject = ['$locationProvider', '$stateProvider', '$urlRouterProvider', 'RouteProvider'];
    function routesConfig($locationProvider, $stateProvider, $urlRouterProvider, Route) {

      // use the HTML5 History API
      $locationProvider.html5Mode(false);

      // Default route
      $urlRouterProvider.otherwise('/app/login');

      // Application Routes States
      $stateProvider
        .state('app', {
          url: '/app',
          abstract: true,
          templateUrl: Route.base('app.html'),
          resolve: {}
        })
        .state('app.dashboard', {
          url: '/dashboard',
          templateUrl: Route.base('dashboard.html'),
          resolve: {}
        })
        .state('app.login', {
          url: '/login',
          templateUrl: Route.base('login.html'),
          resolve: {}
        })
		.state('app.dashboard.data-forms',  {
			url: '/data-forms',
			templateUrl: Route.base('data-forms.html'),
			// controller: 'DataFormController',
			// controllerAs: 'df'
		})
      // Layout dock
      .state('app-dock', {
        url: '/dock',
        abstract: true,
        templateUrl: Route.base('app-dock.html'),
        resolve: {}
      })
        .state('app-dock.dashboard', {
          url: '/dashboard',
          templateUrl: Route.base('dashboard.html'),
          resolve: {
          }
        })
      // Layout full height
      .state('app-fh', {
        url: '/fh',
        abstract: true,
        templateUrl: Route.base('app-fh.html'),
        resolve: {}

      })
        .state('app-fh.columns', {
          url: '/columns',
          templateUrl: Route.base('layout.columns.html')
        })
    }

})();
