# System Console for Unity #

`System Console for Unity` is a Unity tool that lets you set the output of System.Console to Unity's Editor Console, giving you visibility into otherwise invisible logs.
This is useful in seeing System.Console output from third-party plugins, internal Unity logs, and other C# libraries through Unity's Editor Console.

*Usage*

Simply call `SystemConsoleLoggerService.LogConsoleOutput (true);` to start seeing System.Console output in Unity.
To turn it back off, call `SystemConsoleLoggerService.LogConsoleOutput (false);`