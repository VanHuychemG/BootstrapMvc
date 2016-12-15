/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');

gulp.task("make-globalize-culture-nl-js", function () {
    var locale = 'nl';
    var jsonWeNeed = [
      require('./wwwroot/lib/cldr-data/supplemental/likelySubtags.json'),
      require('./wwwroot/lib/cldr-data/main/' + locale + '/ca-gregorian.json'),
      require('./wwwroot/lib/cldr-data/main/' + locale + '/timeZoneNames.json'),
      require('./wwwroot/lib/cldr-data/supplemental/timeData.json'),
      require('./wwwroot/lib/cldr-data/supplemental/weekData.json'),
      require('./wwwroot/lib/cldr-data/main/' + locale + '/numbers.json'),
      require('./wwwroot/lib/cldr-data/supplemental/numberingSystems.json')
    ];

    var jsonStringWithLoad = 'Globalize.load(' +
      jsonWeNeed.map(function (json) { return JSON.stringify(json); }).join(', ') + ');';

    var fs = require('fs');
    fs.writeFile('./wwwroot/lib/globalize.culture.' + locale + '.js', jsonStringWithLoad, function (err) {
        if (err) {
            console.log(err);
        } else {
            console.log("The file was created!");
        }
    });
})