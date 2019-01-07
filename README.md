# UnityLabs.SystemConsole

_UnityLabs.SystemConsole_ is a Unity tool that lets you set the output of `System.Console` to Unity's Editor Console, giving you visibility into otherwise invisible logs. This is useful in seeing `System.Console` output from third-party plugins, internal Unity logs, and other C# libraries through Unity's Editor Console.

## Usage

* Drop the `UnityLabs.SystemConsole.dll` file (from the [Releases tab](https://github.com/andeart/UnityLabs.SystemConsole/releases)) in your Unity project. Any sub-directory under `Assets` should work fine.
* To start seeing System.Console output in Unity, do either of the following:
    * In the Unity editor, use the `UnityLabs/Log System Console` menu button to turn it on/off. 
    * In your code, Call `SystemConsoleLoggerService.LogConsoleOutput (true)` in your code. To turn it back off, call `SystemConsoleLoggerService.LogConsoleOutput (false)`.
