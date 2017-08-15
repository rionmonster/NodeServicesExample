let qr = require('./qr-image');
module.exports = function (callback, text) {
    var result = qr.imageSync(text, { type: 'png' });

    var data = [];
    result.forEach(i => {
        data.push(i);
    });

    callback(null, data);
};