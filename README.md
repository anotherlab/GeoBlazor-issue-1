# GeoBlazor-issue-1

This demo app illustrates two problems with adding points to a map while using GeoBlazor with a .NET MAUI app

## First problem ##
The points do not reliably show up on the map. The first time the app is compiled and run it works. Usually. Each subsequent run does not display the points.

## Second problem ##
Calling clear on the graphics layer will crash the app with an example like the following

{"Value cannot be null. (Parameter 'jsObjectReference')"}
    Data: {System.Collections.ListDictionaryInternal}
    HResult: -2147467261
    HelpLink: null
    InnerException: null
    Message: "Value cannot be null. (Parameter 'jsObjectReference')"
    ParamName: "jsObjectReference"
    Source: "Microsoft.JSInterop"
    StackTrace: "   at Microsoft.JSInterop.JSObjectReferenceExtensions.<InvokeVoidAsync>d__0.MoveNext()\r\n   at dymaptic.GeoBlazor.Core.Components.Layers.GraphicsLayer.<Clear>d__11.MoveNext()\r\n   at demo1.Pages.Map1.<AddPoints>d__6.MoveNext() in D:\\dev\\maui\\GeoBlazor\\demo1\\demo1\\Pages\\Map1.razor:line 64"
    TargetSite: {Void MoveNext()}

## Steps ##
### Missing points ###
1. Restore the nuget packages
2. Edit [MauiProgram.cs](https://github.com/anotherlab/GeoBlazor-issue-1/blob/main/demo1/MauiProgram.cs#L22) and replace "INSERT-YOUR-ESRI-API-KEY-HERE" with your API key
3. Build and the run app on the platform of your choice
4. You should see a map centered on Buffalo, NY. A single point in the color purple will be displayed, it is hard coded in the Razor markup
5. Click the "Points" button.  You may or may not see a set of points in the color red near the purple point.
6. Stop and restart the app. Press the "Points" button. The red points will not be added to the map.

### GraphicsLayer.Clear() ###
1. Stop the app
2. Edit Index.razor and uncomment out the line with 'await pointsLayer.Clear()'
3. Run the app and press the "Points" button. This will crash the app at that line and with the message: "Value cannot be null. (Parameter 'jsObjectReference')"

Tested on Windows 11 with Visual Studio 2022 17.5.3 and GeoBlazer 2.0.1.  Targets tested were Windows Desktop and Android 13
