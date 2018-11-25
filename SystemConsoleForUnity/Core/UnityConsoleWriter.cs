using System.IO;
using System.Text;
using UnityEngine;


namespace Andeart.Unity.SystemConsole.Core
{

    internal class UnityConsoleWriter : TextWriter
    {

        private readonly StringBuilder _buffer;

        public UnityConsoleWriter ()
        {
            _buffer = new StringBuilder ();
        }

        public override Encoding Encoding => Encoding.Default;

        public override void Flush ()
        {
            Debug.Log (_buffer.ToString ());
            _buffer.Length = 0;
        }

        private void WriteFormat (string format, params object[] args)
        {
            if (format == null)
            {
                return;
            }

            _buffer.Append (string.Format (format, args));
            Flush ();
        }

        public override void Write (string value)
        {
            if (value == null)
            {
                return;
            }

            _buffer.Append (value);
            Flush ();
        }

        /// <inheritdoc />
        public override void Write (string format, object arg0)
        {
            WriteFormat (format, arg0);
        }

        /// <inheritdoc />
        public override void Write (string format, object arg0, object arg1)
        {
            WriteFormat (format, arg0, arg1);
        }

        /// <inheritdoc />
        public override void Write (string format, object arg0, object arg1, object arg2)
        {
            WriteFormat (format, arg0, arg1, arg2);
        }

        /// <inheritdoc />
        public override void Write (string format, params object[] args)
        {
            WriteFormat (format, args);
        }

        /// <inheritdoc />
        public override void Write (char value)
        {
            _buffer.Append (value);
            Flush ();
        }

        /// <inheritdoc />
        public override void Write (char[] value, int index, int count)
        {
            Write (new string (value, index, count));
        }

    }

}