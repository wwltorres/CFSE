var cleanCss = require('gulp-clean-css');
var rev = require('gulp-rev');
var uglify = require('gulp-uglify');

module.exports = function (usehtml) {

  // distribution folder
  var dist = 'assets/';
  var source = 'app/template/'; // for abs path construction

  var markupEngine = usehtml ? 'html' : 'jade';
  var markupExt = '.' + markupEngine;

  // main source folders
  var srcLESS = source + 'less/';
  var srcSCSS = source + 'scss/';
  var srcHTML = source + markupEngine + '/';
  var srcJS   = source;


  // Shared config object
  var config = {
    // ---
    // Paths
    // ---

    dist:    dist,
    distCSS: dist + 'css',
    distJS:  dist + 'js',
    source:  source,
    srcLESS: srcLESS,
    srcSCSS: srcSCSS,
    srcHTML: srcHTML,
    srcJS:   srcJS,
    html: {
      index: [srcHTML + 'index' + markupExt],
      views: [srcHTML + '**/*' + markupExt, '!'+srcHTML + 'index' + markupExt ],
      templates: [srcHTML + 'views/cached/*' + markupExt],
      all: [srcHTML + '**/*' + markupExt]
    },
    less: {
      styles: [srcLESS + 'styles.less'],
      watch: [srcLESS + 'app/**/*.less'],
      bootstrap: [srcLESS + 'bootstrap/bootstrap.less']
    },
    scss: {
      styles: [srcSCSS + 'styles.scss'],
      watch: [srcSCSS + 'app/**/*.scss'],
      bootstrap: [srcSCSS + 'bootstrap.scss']
    },
    js: ['./app.module.js', srcJS + 'modules/**/*.js', srcJS + 'custom/**/*.js'],

    // ---
    // Plugins
    // ---

    plato: {
      js: srcJS + '**/*.js'
    },
    report: './report/',
    tplcache: {
      file: 'templates.js',
      opts: {
        standalone: false,
        root: 'templates',
        module: 'app'
      }
    },
    webserver: {
      webroot:          '.',
      host:             'localhost',
      port:             '3000',
      livereload:       true,
      directoryListing: false
    },
    prettify: {
      indent_char: ' ',
      indent_size: 3,
      unformatted: ['a', 'sub', 'sup', 'b', 'i', 'u']
    },
    usemin: {
      path: '.',
      css: [cleanCss({compatibility: 'ie8'}), 'concat', rev()],
      // html: [$.minifyHtml({empty: true})],
      vendor: [uglify( {preserveComments:'some'} ), rev()],
      js: [uglify( {preserveComments:'some'} ), rev()]
    }
  };

  // scripts to check with jshint
  config.lintJs =  [].concat(config.js, config.distJS);

  return config;

};

