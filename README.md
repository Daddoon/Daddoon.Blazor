# Daddoon.Blazor

**Extensions for the Blazor project**

# Installation

TODO: Add NuGet package

In your Program.cs file, when instanciating your BrowserRenderer class, you should add the **DaddoonBlazorExtensionScripts** component to your DOM.

```csharp
public static void Main(string[] args)
{
    var serviceProvider = new BrowserServiceProvider(configure =>
    {
        /* Instanciate your services */
    });

    br = new BrowserRenderer(serviceProvider);
    br.AddComponent<DaddoonBlazorExtensionScripts>("daddoon");
    br.AddComponent<App>("app");
}
```

Assuming you have a "daddoon" tag in the body of your index.html file. You can replace by anything else.

# HOW TO

Mainly adding some currently missing interop to the browser, some helpers and else !

**Platform: Rendering Engine**

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

**Platform: Browser Family**

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

**Platform: UserAgent, Name, Version**

```csharp
Browser.Platform.UserAgent;
Browser.Platform.Name;
Browser.Platform.Version;
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

**Local Storage**

Set:
```csharp
Browser.LocalStorage.Set("myStorage", "myValue");
Browser.LocalStorage.Set<T>("myStorage", myValue);
```

Get:
```csharp
Browser.LocalStorage.Get("myStorage");
Browser.LocalStorage.Get<T>("myStorage");
```

Remove:
```csharp
Browser.LocalStorage.Remove("myStorage");
```

Clear:
```csharp
Browser.LocalStorage.Clear();
```

**Session Storage**

Likewise Local Storage:

Set:
```csharp
Browser.SessionStorage.Set("myStorage", "myValue");
Browser.SessionStorage.Set<T>("myStorage", myValue);
```

Get:
```csharp
Browser.SessionStorage.Get("myStorage");
Browser.SessionStorage.Get<T>("myStorage");
```

Remove:
```csharp
Browser.SessionStorage.Remove("myStorage");
```

Clear:
```csharp
Browser.SessionStorage.Clear();
```

**Location**

Clear:
```csharp
Browser.Location.Reload();
```

# NOTE

There is more in this package, with **IHttpClient** and **IHttpClientSafe** implementation, but i will write for this later.
