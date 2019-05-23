using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arcporter
{
    public class Util
    {
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr LoadCursorFromFile(string path);

        public static Cursor LoadCustomCursor(byte[] cursorData)
        {
            string tmpFile = Path.GetTempPath() + Guid.NewGuid().ToString() + ".cur";
            File.WriteAllBytes(tmpFile, cursorData);

            IntPtr hCurs = LoadCursorFromFile(tmpFile);
            if (hCurs == IntPtr.Zero) throw new Win32Exception();
            Cursor curs = new Cursor(hCurs);
            FieldInfo fi = typeof(Cursor).GetField("ownHandle", BindingFlags.NonPublic | BindingFlags.Instance);
            fi.SetValue(curs, true);

            File.Delete(tmpFile);
            return curs;
        }

    }
}
