using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arcporter
{
    static class Program
    {
        public static Process FirefallProcess;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            Application.Run(new Form1());
            
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            //Console.WriteLine("exit");
            if (FirefallProcess != null && !FirefallProcess.HasExited)
            {
                FirefallProcess.Kill();
                FirefallProcess.WaitForExit(1000);
            }
        }
    }
}
