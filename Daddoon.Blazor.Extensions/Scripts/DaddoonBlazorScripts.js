//Trying to respect IE11 limitation / Avoiding () => , using function () {} instead

//Restore jQuery user version to global scope and registering our version here
d$ = jQuery.noConflict(true);

Blazor.registerFunction("daddoon_Alert", function (message) { alert(message); });
Blazor.registerFunction("daddoon_bowser_name", function () {
    return bowser.name;
});
Blazor.registerFunction("daddoon_bowser_version", function () {
    return bowser.version;
});
Blazor.registerFunction("daddoon_bowser_useragent", function () {
    return navigator.userAgent;
});
Blazor.registerFunction("daddoon_bowser_renderingengine", function () {
    if (bowser.webkit) {
        return 1;
    }

    if (bowser.blink) {
        return 2;
    }

    if (bowser.gecko) {
        return 3;
    }

    if (bowser.msie) {
        return 4;
    }

    if (bowser.msedge) {
        return 5;
    }

    return 0; //Unknown
});