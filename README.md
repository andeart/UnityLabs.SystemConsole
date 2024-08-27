# UnityLabs.SystemConsole

[![nuget-release](https://img.shields.io/nuget/v/Andeart.SystemConsole.svg?logo=nuget&logoSize=auto)](https://www.nuget.org/packages/Andeart.SystemConsole)
[![nuget-dls](https://img.shields.io/nuget/dt/Andeart.SystemConsole.svg?logo=nuget&logoSize=auto)](https://www.nuget.org/packages/Andeart.SystemConsole)<br />
[![github-release](https://img.shields.io/github/release/andeart/UnityLabs.SystemConsole.svg?label=github&logo=github&logoSize=auto)](https://github.com/andeart/UnityLabs.SystemConsole/releases/latest)
[![github-dls](https://img.shields.io/github/downloads/andeart/UnityLabs.SystemConsole/total.svg?logo=github&logoSize=auto)](https://github.com/andeart/UnityLabs.SystemConsole/releases/latest)<br/>

Wouldn't it be cool to have your .Net library (that has no `UnityEngine` dependencies) continue to write logs to output as usual, like...
```csharp
Console.Write ("This is message from my own DLL, that has no UnityEngine dependencies.");
```
... and once added to your Unity project, view the same logs in real-time within Unity's Editor console?<br/>
![console-log](https://user-images.githubusercontent.com/6226493/54099829-7afc4380-4378-11e9-9b5a-1db0ea5aa351.png)

If you think so, you came to the right place!

**UnityLabs.SystemConsole** is a tool that lets you set the output of `System.Console` to Unity's Editor console, giving you visibility into otherwise invisible logs. This is useful in viewing `System.Console` output from third-party plugins, internal Unity logs, and other C# libraries in real-time on the Editor console.


## Usage

**In Editor**:<br />
Use the context menu.

![context-menu](https://user-images.githubusercontent.com/6226493/54099508-eb09ca00-4376-11e9-9dc4-2db52b9bdb4c.png)

The checkmark shows the current enabled status of SystemConsole.<br />
Once checked, all `System.Console` write statements are automatically logged to Unity's console.
Click this again to turn it off. This state also persists through run time, once the game is started in Editor.

**In code**:<br />
Toggle SystemConsole by calling...
```csharp
SystemConsoleLoggerService.IsEnabled = true;
// or set to false to turn it off.
```
This can be useful when you have configurations that want to change this setting in builds, rather than in Editor.<br />
Note that the Editor context menu automatically updates its "checkmark" if this SystemConsole is enabled/disabled in run time code.

## Tests

Both `EditMode` and `PlayMode` tests can be found in the [Unity project directory](https://github.com/andeart/UnityLabs.SystemConsole/tree/master/SystemConsole.Demo). Feel free to inspect/run these.

Unfortunately, I have not been able to invoke these automatically on Travis-CI yet, because Unity's license-activation process via CLI is extremely frustrating to implement for the Personal edition (the Pro API is much simpler). If you know of a trick or two, I'd appreciate your help!

## Installation

- Download the `Andeart.SystemConsole.dll` file from [the NuGet page](https://www.nuget.org/packages/Andeart.SystemConsole), or from [the Github releases page](https://github.com/andeart/UnityLabs.SystemConsole/releases/latest).
- Add this file anywhere in your Unity project. Any sub-directory under Assets will work- **it does not need to be under an Editor folder**. In fact, if you want to be able to change settings at run time, then this **should not** be under an Editor folder.
- Optional: Also drop the `Andeart.SystemConsole.pdb` and `Andeart.SystemConsole.xml` files in the same location if you're interested in debugging.
- All the functionality mentioned above should now automatically be available in your code and Unity Editor.

## Feedback

Please feel free to send merge requests, or drop me a message. Cheers!
