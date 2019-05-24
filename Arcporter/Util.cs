using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Arcporter
{
    public class Util
    {
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr LoadCursorFromFile(string path);

        public static Cursor LoadCustomCursor(byte[] cursorData)
        {
            string cursorFile = Path.GetTempPath() + Guid.NewGuid().ToString() + ".cur";
            File.WriteAllBytes(cursorFile, cursorData);

            IntPtr cursorHandle = LoadCursorFromFile(cursorFile);
            if (cursorHandle == IntPtr.Zero)
            {
                throw new Win32Exception("Unable to load cursor from file");
            }
            Cursor cursor = new Cursor(cursorHandle);

            FieldInfo fieldInfo = typeof(Cursor).GetField("ownHandle", BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldInfo == null)
            {
                throw new Win32Exception("Unable to retrieve cursor field information");
            }
            fieldInfo.SetValue(cursor, true);

            File.Delete(cursorFile);
            return cursor;
        }

    }
}
