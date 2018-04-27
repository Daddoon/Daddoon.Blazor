# Daddoon.Blazor

**Extensions for the Blazor project**

TODO: Add NuGet package

Mainly adding some currently missing interop to the browser, some helpers and else !

**Rendering Engine**

```csharp
Browser.Platform.RenderingEngine
```

Returning values like:

```
Unknown = 0,
WebKit = 1,
Blink = 2,
Gecko = 3,
MSIE = 4,
MSEdge = 5
```

**Browser Family**

Not very exhaustive at the moment, you can call it like:

```csharp
Browser.Platform.BrowserFamily
```

Returning values like:

```
Other = 0,
InternetExplorer = 1,
InternetExplorer11 = 2,
Edge = 3
```

**SetTimeout**

```csharp
Browser.SetTimeout(delegate () { /* do something */ }, 1000);
Browser.SetTimeout(async delegate () { /* do something else */ }, 1000);
```

Some overloads are available but are mainly unecessary

**Cookies**

Based on js.cookie.js, with the corresponding overloads, you can stock string or object (as serialized data)

Set:

Browser.Cookies.Set("myCookie", "myValue");
Browser.Cookies.Set<T>("myCookie", myObject); //Showing the generic type here is just for readability

Get:
Browser.Cookies.Get("myCookie");

Remove:
Browser.Cookies.Remove("myCookie");

# Installation
