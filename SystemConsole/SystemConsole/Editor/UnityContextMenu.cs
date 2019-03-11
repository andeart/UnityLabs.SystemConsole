using Andeart.SystemConsole.Core;
using UnityEditor;


namespace Andeart.SystemConsole.Editor
{

    [InitializeOnLoad]
    internal static class UnityContextMenu
    {
        private const string _menuPath = "UnityLabs/Log System.Console output";

        static UnityContextMenu ()
        {
            bool isEnabledPersistent = EditorPrefs.GetBool (_menuPath, false);
            SystemConsoleLoggerService.IsEnabled = isEnabledPersistent;
        }

        [MenuItem (_menuPath)]
        private static void ToggleLogSystemConsole ()
        {
            SystemConsoleLoggerService.IsEnabled = !SystemConsoleLoggerService.IsEnabled;
            EditorPrefs.SetBool (_menuPath, SystemConsoleLoggerService.IsEnabled);
        }

        [MenuItem (_menuPath, true)]
        private static bool ToggleLogSystemConsoleValidate ()
        {
            Menu.SetChecked (_menuPath, SystemConsoleLoggerService.IsEnabled);
            return true;
        }
    }

}