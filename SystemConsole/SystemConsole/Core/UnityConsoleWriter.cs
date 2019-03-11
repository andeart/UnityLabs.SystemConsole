using System;
using System.IO;
using System.Text;
using UnityEngine;


namespace Andeart.SystemConsole.Core
{

    internal class UnityConsoleWriter : TextWriter
    {
        private readonly StringBuilder _buffer;

        public override Encoding Encoding => Encoding.Default;

        public UnityConsoleWriter ()
        {
            _buffer = new StringBuilder ();
        }

        public override void Flush ()
        {
            Debug.Log (_buffer.ToString ());
            _buffer.Clear ();
        }

        private void WriteNoFlush (char value)
        {
            _buffer.Append (value);
        }

        public override void Write (char value)
        {
            WriteNoFlush (value);
            Flush ();
        }

        private void WriteNoFlush (char[] buffer)
        {
            _buffer.Append (buffer);
        }

        public override void Write (char[] buffer)
        {
            WriteNoFlush (buffer);
            Flush ();
        }

        private void WriteNoFlush (char[] buffer, int index, int count)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException (nameof(buffer), $"{nameof(buffer)} char array should not be null.");
            }

            if (index < 0)
            {
                throw new ArgumentOutOfRangeException (nameof(index), $"{nameof(index)} should be non-negative.");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException (nameof(count), $"{nameof(count)} should be non-negative.");
            }

            if (buffer.Length - index < count)
            {
                throw new ArgumentException (
                    $"Offset length provided via index: {index}, and count: {count}, is invalid in a char array of length: {buffer.Length}");
            }

            for (int index1 = 0; index1 < count; ++index1)
            {
                _buffer.Append (buffer[index + index1]);
            }
        }

        public override void Write (char[] buffer, int index, int count)
        {
            WriteNoFlush (buffer, index, count);
            Flush ();
        }

        public override void Write (bool value)
        {
            Write (value ? "True" : "False");
        }

        public override void Write (int value)
        {
            Write (value.ToString (FormatProvider));
        }

        public override void Write (uint value)
        {
            Write (value.ToString (FormatProvider));
        }

        public override void Write (long value)
        {
            Write (value.ToString (FormatProvider));
        }

        public override void Write (ulong value)
        {
            Write (value.ToString (FormatProvider));
        }

        public override void Write (float value)
        {
            Write (value.ToString (FormatProvider));
        }

        public override void Write (double value)
        {
            Write (value.ToString (FormatProvider));
        }

        public override void Write (decimal value)
        {
            Write (value.ToString (FormatProvider));
        }

        private void WriteNoFlush (string value)
        {
            if (value == null)
            {
                return;
            }

            _buffer.Append (value);
        }

        public override void Write (string value)
        {
            WriteNoFlush (value);
            Flush ();
        }

        public override void Write (object value)
        {
            switch (value)
            {
                case null: return;
                case IFormattable formattable:
                    Write (formattable.ToString (null, FormatProvider));
                    break;
                default:
                    Write (value.ToString ());
                    break;
            }
        }

        public override void Write (string format, object arg0)
        {
            Write (string.Format (FormatProvider, format, arg0));
        }

        public override void Write (string format, object arg0, object arg1)
        {
            Write (string.Format (FormatProvider, format, arg0, arg1));
        }

        public override void Write (string format, object arg0, object arg1, object arg2)
        {
            Write (string.Format (FormatProvider, format, arg0, arg1, arg2));
        }

        public override void Write (string format, params object[] arg)
        {
            Write (string.Format (FormatProvider, format, arg));
        }

        public override void WriteLine ()
        {
            Write (CoreNewLine);
        }

        public override void WriteLine (char value)
        {
            WriteNoFlush (value);
            WriteNoFlush (CoreNewLine);
            Flush ();
        }

        public override void WriteLine (char[] buffer)
        {
            WriteNoFlush (buffer);
            WriteNoFlush (CoreNewLine);
            Flush ();
        }

        public override void WriteLine (char[] buffer, int index, int count)
        {
            WriteNoFlush (buffer, index, count);
            WriteNoFlush (CoreNewLine);
            Flush ();
        }

        public override void WriteLine (bool value)
        {
            WriteLine (value ? "True" : "False");
        }

        public override void WriteLine (int value)
        {
            WriteLine (value.ToString (FormatProvider));
        }

        public override void WriteLine (uint value)
        {
            WriteLine (value.ToString (FormatProvider));
        }

        public override void WriteLine (long value)
        {
            WriteLine (value.ToString (FormatProvider));
        }

        public override void WriteLine (ulong value)
        {
            WriteLine (value.ToString (FormatProvider));
        }

        public override void WriteLine (float value)
        {
            WriteLine (value.ToString (FormatProvider));
        }

        public override void WriteLine (double value)
        {
            WriteLine (value.ToString (FormatProvider));
        }

        public override void WriteLine (decimal value)
        {
            WriteLine (value.ToString (FormatProvider));
        }

        public override void WriteLine (string value)
        {
            if (value == null)
            {
                WriteLine ();
                return;
            }

            WriteNoFlush (value);
            WriteNoFlush (CoreNewLine);
            Flush ();
        }

        public override void WriteLine (object value)
        {
            switch (value)
            {
                case null:
                    WriteLine ();
                    break;
                case IFormattable formattable:
                    WriteLine (formattable.ToString (null, FormatProvider));
                    break;
                default:
                    WriteLine (value.ToString ());
                    break;
            }
        }

        public override void WriteLine (string format, object arg0)
        {
            WriteLine (string.Format (FormatProvider, format, arg0));
        }

        public override void WriteLine (string format, object arg0, object arg1)
        {
            WriteLine (string.Format (FormatProvider, format, arg0, arg1));
        }

        public override void WriteLine (string format, object arg0, object arg1, object arg2)
        {
            WriteLine (string.Format (FormatProvider, format, arg0, arg1, arg2));
        }

        public override void WriteLine (string format, params object[] arg)
        {
            WriteLine (string.Format (FormatProvider, format, arg));
        }
    }

}