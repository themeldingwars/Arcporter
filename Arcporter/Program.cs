using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Arcporter
{
    public static class Program
    {
        public static Process FirefallProcess;

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += Application_ApplicationExit;
            Application.Run(new ArcporterForm());
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            if (FirefallProcess == null || FirefallProcess.HasExited)
            {
                return;
            }

            FirefallProcess.Kill();
            FirefallProcess.WaitForExit(TimeSpan.FromSeconds(1).Milliseconds);
        }
    }
}
