module.exports = function (callback, x) {
    let result = eval(x);
    callback(null, result);
};

