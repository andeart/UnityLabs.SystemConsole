using System;
using System.IO;


namespace Andeart.SystemConsole.Core
{

    /// <summary>
    /// SystemConsole is a Unity tool that lets you set the output of System.Console to Unity's Editor Console, giving you visibility into otherwise invisible logs.
    /// This is useful in seeing System.Console output from third-party plugins, internal Unity logs, and other C# libraries through Unity's Editor Console.
    /// </summary>
    public static class SystemConsoleLoggerService
    {
        private static readonly UnityConsoleWriter _unityConsoleWriter;
        private static TextWriter _defaultTextWriter;

        /// <summary>
        /// Set System.Console output to log to Unity's Editor Console.
        /// Set to TRUE to see System.Console output in Editor Console. FALSE if not.
        /// </summary>
        public static bool IsEnabled
        {
            get => GetEnabled ();
            set => SetEnabled (value);
        }

        static SystemConsoleLoggerService ()
        {
            _unityConsoleWriter = new UnityConsoleWriter ();
        }

        private static void SetEnabled (bool toEnable)
        {
            if (toEnable)
            {
                _defaultTextWriter = Console.Out;
                Console.SetOut (_unityConsoleWriter);
                Console.Write ("System.Console output will now be logged in the Unity Editor console.");
            } else
            {
                Console.Write ("System.Console output will no longer be logged in the Unity Editor console.");
                if (_defaultTextWriter == null)
                {
                    _defaultTextWriter = new StreamWriter (Console.OpenStandardOutput ()) { AutoFlush = true };
                }

                Console.SetOut (_defaultTextWriter);
            }
        }

        private static bool GetEnabled ()
        {
            return Console.Out == _unityConsoleWriter;
        }
    }

}