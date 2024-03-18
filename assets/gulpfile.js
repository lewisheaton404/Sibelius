'use strict';

const gulp = require('gulp');
const sass = require('gulp-sass')(require('sass'));
const cleanCss = require('gulp-clean-css');
var concat = require('gulp-concat');

function build() {
    return gulp.src('scss/styles.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(cleanCss())
        .pipe(gulp.dest('../wwwroot/css'));
};

function js() {
    return gulp.src('js/**/*.js')
        .pipe(concat('scripts.js'))
        .pipe(gulp.dest('../wwwroot/js'));
}

exports.build = build;
exports.js = js;
exports.watch = function () {
    gulp.watch('./scss/**/*.scss', gulp.series('build'));
    gulp.watch('./js/**/*.js', gulp.series('js'));
};