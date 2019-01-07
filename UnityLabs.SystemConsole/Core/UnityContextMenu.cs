using UnityEditor;


namespace Andeart.UnityLabs.SystemConsole
{

    [InitializeOnLoad]
    internal static class UnityContextMenu
    {

        private const string _menuPath = "UnityLabs/Log System Console";

        public static bool _isEnabled;

        static UnityContextMenu ()
        {
            _isEnabled = EditorPrefs.GetBool (_menuPath, false);
        }

        [MenuItem (_menuPath)]
        private static void ToggleLogSystemConsole ()
        {
            ToggleEnabledAndSerialize ();
            SystemConsoleLoggerService.LogConsoleOutput (_isEnabled);
        }

        [MenuItem (_menuPath, true)]
        private static bool ToggleLogSystemConsoleValidate ()
        {
            Menu.SetChecked (_menuPath, _isEnabled);
            return true;
        }

        private static void ToggleEnabledAndSerialize ()
        {
            _isEnabled = !_isEnabled;
            EditorPrefs.SetBool (_menuPath, _isEnabled);
        }

    }

}