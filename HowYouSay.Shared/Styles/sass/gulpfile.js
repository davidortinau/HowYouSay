// Sass configuration
var gulp = require('gulp');
var sass = require('gulp-sass');
var replace = require('gulp-string-replace');

gulp.task('sass', function() {
    gulp.src('*.scss')
        .pipe(sass())
        .pipe(replace(/\\\^/g, '^'))
        .pipe(gulp.dest('../'))
});

gulp.task('default', ['sass'], function() {
    gulp.watch('*.scss', ['sass']);
})