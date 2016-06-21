# CFSE_Trans_Portal
Corporacion Fondo Seguro de Estado Enterprise Transactional Portal

### Presentation layer

#### Prerequisites

1. Install [node.js](https://nodejs.org/en/).
2. Install [bower](https://bower.io/).
3. Install [gulp](http://gulpjs.com/).
4. cd into the Presentation directory.
5. Run `npm install`.
6. Run `bower install`.
7. Setup Visual Studio to insert soft-tabs, 2 spaces, for HTML, CSS, and JS files.

#### Design

For the Presentation layer we are using Angular 1.5 and a third-party Angular template called [Naut](https://wrapbootstrap.com/theme/naut-responsive-angularjs-template-WB0LX03F7).

The Presentation layer will use Angular 1.5's [component based architecture](https://docs.angularjs.org/guide/component). We will also write all Angular code following the [Angular style guide](https://github.com/johnpapa/angular-styleguide/blob/master/a1/README.md).

> ###### Optional:
>  Install the Visual Studio extension [SideWaffle](http://sidewaffle.com/). It provides Angular templates formatted according to the Angular style guide.

The Naut template provides a gulpfile that is used to generate the application's CSS stylesheets from the [less](http://lesscss.org/) files that the template provided. The gulpfile also provides minification capabilities.
