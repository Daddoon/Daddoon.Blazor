//Trying to respect IE11 limitation / Avoiding () => , using function () {} instead

//Restore jQuery user version to global scope and registering our version here
d$ = jQuery.noConflict(true);

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

function daddoon_dispatchTask(taskId, result) {
    let taskIdStr = Blazor.platform.toDotNetString(taskId.toString());
    let resultStr = Blazor.platform.toDotNetString(result);
    Blazor.platform.callMethod(taskDispatcher, null, [taskIdStr, resultStr]);
}

Blazor.registerFunction('daddoon_jQuery_GetJsonAsync', function (taskId, requestUri) {
    d$.ajax({
        dataType: "text",
        type: "GET",
        url: requestUri,
        data: {},
        async: true,
        success: function (data) {
            daddoon_dispatchTask(taskId, data);
        },
        error: function () {
            daddoon_dispatchTask(taskId, null);
            console.log("error occured in jQuery_GetJsonAsync for taskId: " + taskId);
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