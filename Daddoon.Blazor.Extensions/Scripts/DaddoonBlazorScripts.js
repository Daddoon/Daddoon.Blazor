//Trying to respect IE11 limitation / Avoiding () => , using function () {} instead

Blazor.registerFunction("daddoon_Alert", function (message) { alert(message); });
Blazor.registerFunction("daddoon_getUserAgent", function () {
    
});