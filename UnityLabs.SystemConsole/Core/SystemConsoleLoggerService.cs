using System;
using System.IO;


namespace Andeart.UnityLabs.SystemConsole
{

    public static class SystemConsoleLoggerService
    {

        private static readonly UnityConsoleWriter _unityConsoleWriter;

        static SystemConsoleLoggerService ()
        {
            _unityConsoleWriter = new UnityConsoleWriter ();
        }

        /// <summary>
        /// Set System.Console output to print in Unity's Editor Console.
        /// </summary>
        /// <param name="toLog">Set to TRUE to see System.Console output in Editor Console. FALSE if not.</param>
        public static void LogConsoleOutput (bool toLog)
        {
            if (toLog)
            {
                Console.SetOut (_unityConsoleWriter);
            } else
            {
                StreamWriter standardOutput = new StreamWriter (Console.OpenStandardOutput ()) {AutoFlush = true};
                Console.SetOut (standardOutput);
            }
        }

    }

}