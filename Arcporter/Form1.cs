using Bitter;
using FauFau.Formats;
using FauFau.Hax;
using FauFau.Hax.Patches;
using FauFau.Util;
using SharpCompress.Compressors;
using SharpCompress.Compressors.Deflate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Arcporter
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll")]
        static extern IntPtr LoadIcon(IntPtr hInstance, IntPtr iconName);
        [DllImport("kernel32.dll")]
        static extern IntPtr GetModuleHandle(string moduleName);

        string mapsPath;
        string exePath;
        string appDataPath;
        string dummyPath;
        string patchedExePath;
        string workingDirectory;

        Cursor arrowCursor = Util.LoadCustomCursor(Properties.Resources.sys_arrow);
        Cursor ibeamCursor = Util.LoadCustomCursor(Properties.Resources.sys_ibeam);

        public Form1()
        {
            appDataPath = Common.AppDataPath("Arcporter");
            dummyPath = Path.Combine(appDataPath, "dummy.nsr");
            patchedExePath = Path.Combine(appDataPath, "PatchedClient.exe");

            Directory.CreateDirectory(appDataPath);

            InitializeComponent();

            // reuse exe icon for titlebar to avoid duplicate data
            IntPtr hInstance = GetModuleHandle(null);
            IntPtr hIcon = LoadIcon(hInstance, new IntPtr(32512));
            if (hIcon != IntPtr.Zero)
            {
                Icon = Icon.FromHandle(hIcon);
            }

            Cursor = arrowCursor;
            dtbPath.Cursor = ibeamCursor;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            dlvZones.Visible = true;

            TryLoad(Properties.Settings.Default.Path, true);
        }


        private void TryLoad(string path, bool ignoreError = false)
        {
            
            if(File.Exists(path))
            {
                FileInfo fi = new FileInfo(path);
                if(fi.Directory.Parent != null)
                {
                    mapsPath = Path.Combine(fi.Directory.Parent.FullName, "maps");

                    if (Directory.Exists(mapsPath))
                    {
                        dlvZones.Items.Clear();
                        exePath = path;
                        workingDirectory = fi.Directory.FullName;
                        dtbPath.Text = exePath;

                        string[] zoneFiles = Directory.GetFiles(mapsPath, "*.zone", SearchOption.TopDirectoryOnly);
                        SortedDictionary<int, Zone> zones = new SortedDictionary<int, Zone>();

                        foreach (string zf in zoneFiles)
                        {
                            Zone zone = new Zone();
                            zone.Read(zf);
                            zones.Add(int.Parse(new FileInfo(zf).Name.Split('.')[0]), zone);
                        }
                        
                        foreach(KeyValuePair<int, Zone> zone in zones)
                        {
                            string zId = zone.Key.ToString().PadRight(4);
                            dlvZones.Items.Add(new DarkUI.Controls.DarkListItem(zId + " | " + zone.Value.Name));
                        }

                        Properties.Settings.Default.Path = path;
                        Properties.Settings.Default.Save();


                        Patcher patcher = new Patcher(exePath);
                        patcher.Path = appDataPath;

                        
                        patcher.ApplyPatch(new UnlimitedFreeCamRadius());
                        patcher.ApplyPatch(new RedHandedBypass());

                        patcher.Save(patchedExePath);

                        return;
                    }
                }
            }


            mapsPath = null;
            exePath = null;
            Properties.Settings.Default.Path = null;
            Properties.Settings.Default.Save();

            if(!ignoreError)
            {
                dtbPath.Text = "Invalid path, try again..";
            }
            
        }

        private void DarkButton1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void DarkListView1_DoubleClick(object sender, EventArgs e)
        {
            if(dlvZones.SelectedIndices.Count > 0)
            {
                string selected = dlvZones.Items[dlvZones.SelectedIndices[0]].Text;
                int zoneId = int.Parse(selected.Split(' ')[0]);
                //Console.WriteLine(zoneId);

                if(Program.FirefallProcess != null && !Program.FirefallProcess.HasExited)
                {
                    Program.FirefallProcess.Kill();
                    Program.FirefallProcess.WaitForExit(1000);
                }

                Nsr.GenerateDummyFile(zoneId).Write(dummyPath);
                ProcessStartInfo info = new ProcessStartInfo();

                info.FileName = patchedExePath;
                info.WorkingDirectory = workingDirectory;
                info.Arguments = "--open=\"" + dummyPath + "\"";
                Program.FirefallProcess = Process.Start(info);

            }
        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            TryLoad(openFileDialog1.FileName);
        }

        private void DarkListView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dlvZones.SelectedIndices.Count > 0)
                {
                    string selected = dlvZones.Items[dlvZones.SelectedIndices[0]].Text;
                    //Console.WriteLine(selected);
                }
            }
        }

        private void DarkButton2_Click(object sender, EventArgs e)
        {
            panel1.Visible = dlvZones.Visible;
            dlvZones.Visible = !dlvZones.Visible;

        }
    }
}
