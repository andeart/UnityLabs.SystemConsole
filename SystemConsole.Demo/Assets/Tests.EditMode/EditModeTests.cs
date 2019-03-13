using Andeart.SystemConsole.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Andeart.SystemConsole.Tests
{

    public class EditModeTests
    {
        private readonly List<string> _recentLogs;

        public EditModeTests ()
        {
            _recentLogs = new List<string> ();
        }

        public void Setup ()
        {
            _recentLogs.Clear ();

            Application.logMessageReceived -= OnApplicationLogReceived;
            Application.logMessageReceived += OnApplicationLogReceived;
        }

        private void OnApplicationLogReceived (string condition, string stacktrace, LogType type)
        {
            _recentLogs.Add (condition);
        }

        [Test]
        public void EnableSystemConsole_SimpleMessage_MessageLoggedInUnity ()
        {
            Setup ();

            SystemConsoleLoggerService.IsEnabled = true;
            string trackerGuid = Guid.NewGuid ().ToString ();
            Console.Write (trackerGuid);
            TestContext.WriteLine ($"Console.Write: {trackerGuid}");

            PrintRecentLogsToTestContext ();
            Assert.IsTrue (_recentLogs.Contains ("abc"), $"SystemConsole did not correctly log message: \"{trackerGuid}\" to Unity console.");
        }

        [Test]
        public void DisableSystemConsole_SimpleMessage_MessagedNotLoggedInUnity ()
        {
            Setup ();

            SystemConsoleLoggerService.IsEnabled = false;
            string trackerGuid = Guid.NewGuid ().ToString ();
            Console.Write (trackerGuid);
            TestContext.WriteLine ($"Console.Write: {trackerGuid}");

            PrintRecentLogsToTestContext ();
            Assert.IsFalse (_recentLogs.Contains (trackerGuid), $"SystemConsole logged message: \"{trackerGuid}\" to Unity console, when it should not have.");
        }

        private void PrintRecentLogsToTestContext ()
        {
            TestContext.WriteLine ("/** All Unity console logs received...");
            for (int i = 0; i < _recentLogs.Count; i++)
            {
                TestContext.WriteLine (_recentLogs[i]);
            }

            TestContext.WriteLine ("End of Unity console logs received. **/");
        }
    }

}