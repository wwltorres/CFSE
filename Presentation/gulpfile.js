
var argv = require('yargs').argv;
var usehtml = argv.usehtml;
var usescss = argv.usescss;

var gulp = require('gulp');
var gutil = require('gulp-util');
var gulpsync = require('gulp-sync')(gulp);
var path = require('path');
var glob = require('glob');
var del = require('del');
var sourcemaps = require('gulp-sourcemaps');
var less = require('gulp-less');
var runSequence = require('run-sequence');
var livereload = require('gulp-livereload');
var cleanCss = require('gulp-clean-css');
var config = require('./gulp.config')(usehtml);

// production mode
var isProduction = false;

//---------------
// TASKS
//---------------

// APP LESS
gulp.task('styles', function() {
    log('Compiling styles to CSS..');
    var stylesSrc = usescss ? config.scss.styles : config.less.styles;
    return gulp.src(stylesSrc)
        .pipe( isProduction ? gutil.noop() : sourcemaps.init())
        .pipe( usescss ? $.sass() : less() )
        .on("error", handleError)
        .pipe(isProduction ? cleanCss({ compatibility: 'ie8' }) : gutil.noop())
        .pipe(isProduction ? gutil.noop() : sourcemaps.write("./"))
        .pipe(gulp.dest( config.distCSS ));
});

// BOOSTRAP
gulp.task('bootstrap', function() {
    log('Compiling Bootstrap..');
    var bsSrc = usescss ? config.scss.bootstrap : config.less.bootstrap;
    return gulp.src(bsSrc)
        .pipe( isProduction ? gutil.noop() : sourcemaps.init())
        .pipe( usescss ? $.sass() : less() )
        .on("error", handleError)
        .pipe(isProduction ? cleanCss({ compatibility: 'ie8' }) : gutil.noop())
        .pipe( isProduction ? gutil.noop() : sourcemaps.write("./"))
        .pipe(gulp.dest( config.distCSS ));
});

// SERVER
// -----------------------------------

gulp.task('webserver', function() {
  log('Starting web server.. ');
  return gulp.src( config.webserver.webroot )
    .pipe($.webserver( config.webserver ));

});

//---------------
// WATCH
//---------------

// Rerun the task when a file changes
gulp.task('watch', function() {
  log('Starting watch with live reload ...');

  livereload.listen();

  if(usescss) gulp.watch([config.scss.watch, config.scss.styles], ['styles']);
  else        gulp.watch([config.less.watch, config.less.styles], ['styles']);

  if(usescss) gulp.watch(config.scss.bootstrap, ['bootstrap']);
  else gulp.watch(config.less.bootstrap, ['bootstrap']);

  gulp
    .watch([].concat(config.less.watch, config.html.views, config.html.templates, config.js))
    .on('change', function(event) {
      setTimeout(function() {
        livereload.changed( event.path );
      }, 1400);
    });

});

/**
 * Clean
 */
gulp.task('clean', ['clean-scripts', 'clean-styles']);

gulp.task('clean-scripts', function(cb) {
    var js = config.distJS + '/*{js,map}';
    clean(js, cb);
});

gulp.task('clean-styles', function(cb) {
    var css = config.distCSS + '/*{css,map}';
    clean(css, cb);
});

gulp.task('clean-build', function (cb) {
  log('Removing development assets');
  var delFiles = [
        config.distJS + '/' + config.tplcache.file,
        config.distCSS + '/bootstrap.css',
        config.distCSS + '/styles.css'
    ];
  clean(delFiles, cb);
});


/**
 * vet the code and create coverage report
 */
gulp.task('lint', function() {
    log('Analyzing source with JSHint');

    return gulp
        .src(config.lintJs)
        .pipe($.jshint())
        .pipe($.jshint.reporter('jshint-stylish', {verbose: true}))
        .pipe($.jshint.reporter('fail'));
});

//---------------
// Visualizer report
//---------------
gulp.task('plato', function(done) {
    log('Analyzing source with Plato');
    log('Browse to /report/plato/index.html to see Plato results');

    startPlatoVisualizer(done);
});

//---------------
// MAIN TASKS
//---------------

// build for production
gulp.task('build', [], function(cb){
  runSequence('clean', 'production', 'compile', 'clean-build', cb);
});

gulp.task('production', function() { isProduction = true; });

// default (no minify, sourcemaps and watch)
gulp.task('default', function(callback) {
  runSequence('clean', 'compile','watch', 'done', callback);
}).task('done', done);

// serve development by default
gulp.task('serve', function(cb){
  runSequence('default', 'webserver', cb);
});

// optional serve production
gulp.task('serve-build', function(cb){
  runSequence('build', 'webserver', cb);
});

// run tasks without watch
gulp.task('compile', function(cb){
    runSequence(
        'bootstrap',
        'styles',
    cb);
});


/////////////////

/**
 * Error handler
 */
function handleError(err) {
  console.log(err.toString());
  this.emit('end');
}

/**
 * Delete all files in a given path
 * @param  {Array}   path - array of paths to delete
 * @param  {Function} done - callback when complete
 */
function clean(path, done) {
    log('Cleaning: ' + gutil.colors.blue(path));
    del(path, done);
}

/**
 * Start Plato inspector and visualizer
 */
function startPlatoVisualizer(done) {
    log('Running Plato');

    var files = glob.sync(config.plato.js);
    var excludeFiles = /.*\.spec\.js/;
    var plato = require('plato');

    var options = {
        title: 'Plato Inspections Report',
        exclude: excludeFiles
    };
    var outputDir = config.report + 'plato/';

    plato.inspect(files, outputDir, options, platoCompleted);

    function platoCompleted(report) {
        var overview = plato.getOverviewReport(report);
        log(overview.summary);
        if (done) { done(); }
    }
}

/**
 * Just to be polite :)
 */
function done(){
  setTimeout(function(){ // it's more clear to show msg after all
    log('Done.. Watching code and reloading on changes..');
  }, 500);
};


/**
 * Standard log
 */

function log(msg) {
  var prefix = '*** ';
  gutil.log(prefix + msg);
}
