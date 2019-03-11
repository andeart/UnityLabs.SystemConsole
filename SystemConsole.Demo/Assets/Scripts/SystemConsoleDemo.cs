using System;
using UnityEngine;


namespace Andeart.SystemConsole.Demo
{

    internal class SystemConsoleDemo : MonoBehaviour
    {
        private void Start ()
        {
            Debug.Log ("1. A message logged directly via UnityEngine.Debug.Log()");
            Console.Write ("2. A message logged via System.Console.WriteLine()");
            Debug.Log ("3. A message logged via UnityEngine.Debug.Log() again. Try toggling the `_shouldLogConsoleOutput` checkbox in inspector.");
            Console.Write ("4. Another message logged via System.Console.Write()");
        }
    }

}