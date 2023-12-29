var versiony = require('versiony');
var gv = require('genversion');

versiony.from('version.json').to('package.json');

gv.generate('lib/version.js', function (err, version) {
  if (err) {
    throw err;
  }
  console.log('Sliding into', version, 'like a sledge.');
});

