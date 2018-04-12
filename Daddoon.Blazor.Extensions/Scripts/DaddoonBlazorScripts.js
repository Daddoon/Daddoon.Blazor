//Trying to respect IE11 limitation / Avoiding () => , using function () {} instead

//Restore jQuery user version to global scope and registering our version here
d$ = jQuery.noConflict(true);
var dCookies = Cookies.noConflict();

const daddoon_assemblyName = 'Daddoon.Blazor';
const daddoon_dispatcher_namespace = 'Daddoon.Blazor.Services.Impl.Internal';
const daddoon_dispatcher_typeName = 'TaskDispatcher';
const daddoon_dispatcher_methodName = 'Dispatch';

const taskDispatcher = Blazor.platform.findMethod(
    daddoon_assemblyName,
    daddoon_dispatcher_namespace,
    daddoon_dispatcher_typeName,
    daddoon_dispatcher_methodName
);

function daddoon_dispatchTask(taskId, httpResult) {
    let taskIdStr = Blazor.platform.toDotNetString(taskId.toString());

    var httpResultJSON = JSON.stringify(httpResult);
    let resultStr = Blazor.platform.toDotNetString(httpResultJSON);
    Blazor.platform.callMethod(taskDispatcher, null, [taskIdStr, httpResult.Success, resultStr]);
}

function daddoon_timeoutValidator(timeout) {
    if (timeout == undefined || timeout == null || timeout <= 0)
        return 100000; //100 seconds if nothing valid
    return timeout;
}

/*
    class RequestMetadata
    {
        public double timeout { get; set; }
    }
*/

function daddoon_getHttpResultObject(data, code, success, clientError) {

    if (data == undefined)
        data = null;

    if (code == null || code == undefined)
        code = 500;

    if (success == null || success == undefined)
        success = false;

    if (clientError == null || clientError == undefined)
        clientError = false;
    
    return {
        Data: data,
        Success: success,
        Code: code,
        ClientError: clientError
    };
}

Blazor.registerFunction('daddoon_cookie_set', function (name, value, expires, path, domain, secure) {
    try {
        if (name == null || name == undefined || value == undefined) //value == null can be a valid value
            return false;

        if (expires == null && path == null && domain == null && secure == null) {
            dCookies.set(name, value);
            return true;
        }

        var cookieParam = {};
        if (expire != null)
            cookieParam.expires = expires;
        if (expire != null)
            cookieParam.path = path;
        if (expire != null)
            cookieParam.domain = domain;
        if (expire != null)
            cookieParam.secure = secure;

        dCookies.set(name, value, cookieParam);
        return true;
    } catch (e) {
        return false;
    }
});

Blazor.registerFunction('daddoon_cookie_get', function (name) {

    try {
        var cookieResult = null;

        if (name == null || name == undefined)
            cookieResult = dCookies.get();
        else
            cookieResult = dCookies.get(name);

        if (cookieResult == undefined)
            cookieResult = null;

        return cookieResult;
    } catch (e) {
        return JSON.stringify({});
    }
});

Blazor.registerFunction('daddoon_cookie_remove', function (name, path, domain) {

    try {
        if (name == null || name == undefined)
            return false;
        if (path == null && domain == null) {
            dCookies.remove(name);
            return true;
        }

        var cookieParam = {};
        if (path != null)
            cookieParam.path = path;
        if (domain != null)
            cookieParam.domain = domain;

        dCookies.remove(name, cookieParam);
        return true;
    } catch (e) {
        return false;
    }
});

Blazor.registerFunction('daddoon_jQuery_SendAsync', function (taskId, httpMethod, requestUri, metadata, contentJSON) {

    metadata.timeout = daddoon_timeoutValidator(metadata.timeout);

    var dataContent = null;
    var dataType = "text";

    try {
        if (contentJSON != undefined && contentJSON != null) {
            dataContent = contentJSON;
        }
    } catch (e) {
        daddoon_dispatchTask(taskId, daddoon_getHttpResultObject(null, 500, false, true));
    }

    d$.ajax({
        dataType: "text",
        timeout: metadata.timeout,
        contentType: metadata.contentType,
        type: httpMethod,
        url: requestUri,
        data: dataContent,
        async: true,
        success: function (data, textStatus, xhr) {
            daddoon_dispatchTask(taskId, daddoon_getHttpResultObject(data, xhr.status, true, false));
        },
        error: function (xhr, textStatus, errorThrown) {
            daddoon_dispatchTask(taskId, daddoon_getHttpResultObject(null, xhr.status, false, false));
        }
    });
});

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

Blazor.registerFunction("daddoon_svg_replace_content", function (tempId, dclass, dstyle, result) {
    if (result == null || result == undefined)
        return false;

    var newSVG = d$(result);

    if (dclass != null && dclass != undefined)
        newSVG.addClass(dclass);

    if (dstyle != null && dstyle != undefined)
        newSVG.attr("style", dstyle);

    d$("svg[svg-id='" + tempId + "']").parent().replaceWith(newSVG);
});