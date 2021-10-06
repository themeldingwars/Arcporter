using System;
using System.ComponentModel;
using System.IO;
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
            string cursorFile = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.cur");
            File.WriteAllBytes(cursorFile, cursorData);

            IntPtr cursorHandle = LoadCursorFromFile(cursorFile);
            if (cursorHandle == IntPtr.Zero)
            {
                throw new Win32Exception("Unable to load cursor from file");
            }
            Cursor cursor = new Cursor(cursorHandle);

            File.Delete(cursorFile);
            return cursor;
        }

    }
}
