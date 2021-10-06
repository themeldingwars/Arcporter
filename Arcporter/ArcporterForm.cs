using Bitter;
using FauFau.Formats;
using FauFau.Hax;
using FauFau.Hax.Patches;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace Arcporter
{
    public sealed partial class ArcporterForm : Form
    {
        [DllImport("user32.dll")]
        private static extern IntPtr LoadIcon(IntPtr hInstance, IntPtr iconName);
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(string moduleName);

        private string _mapsPath;
        private string _exePath;
        private string _workingDirectory;

        private readonly string _appDataPath;
        private readonly string _dummyReplayPath;
        private readonly string _patchedExePath;

        private readonly Cursor _arrowCursor = Util.LoadCustomCursor(Properties.Resources.sys_arrow);
        private readonly Cursor _ibeamCursor = Util.LoadCustomCursor(Properties.Resources.sys_ibeam);

        public ArcporterForm()
        {
            _appDataPath = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TheMeldingWars"), "Arcporter");
            _dummyReplayPath = Path.Combine(_appDataPath, "dummy.nsr");
            _patchedExePath = Path.Combine(_appDataPath, "PatchedClient.exe");

            Directory.CreateDirectory(_appDataPath);

            InitializeComponent();

            // Reuse exe icon for titlebar to avoid duplicate data
            IntPtr hInstance = GetModuleHandle(null);
            IntPtr hIcon = LoadIcon(hInstance, new IntPtr(32512));
            if (hIcon != IntPtr.Zero)
            {
                Icon = Icon.FromHandle(hIcon);
            }

            Cursor = _arrowCursor;
            dtbPath.Cursor = _ibeamCursor;

        }

        private void ArcporterForm_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            dlvZones.Visible = true;
            timePicker1.Value = 0.51;
            TryLoad(Properties.Settings.Default.Path, true);
        }


        private void TryLoad(string path, bool ignoreError = false)
        {
            
            if(File.Exists(path))
            {
                FileInfo fileInfo = new FileInfo(path);
                if(fileInfo.Directory?.Parent != null)
                {
                    _mapsPath = Path.Combine(fileInfo.Directory.Parent.FullName, "maps");

                    if (Directory.Exists(_mapsPath))
                    {
                        dlvZones.Items.Clear();
                        _exePath = path;
                        _workingDirectory = fileInfo.Directory.FullName;
                        dtbPath.Text = _exePath;

                        string[] zoneFiles = Directory.GetFiles(_mapsPath, "*.zone", SearchOption.TopDirectoryOnly);
                        SortedDictionary<int, Zone> zones = new SortedDictionary<int, Zone>();

                        foreach (string zoneFile in zoneFiles)
                        {
                            Zone zone = new Zone();
                            zone.Read(zoneFile);
                            zones.Add(int.Parse(new FileInfo(zoneFile).Name.Split('.')[0]), zone);
                        }
                        
                        foreach(KeyValuePair<int, Zone> zone in zones)
                        {
                            string zId = zone.Key.ToString().PadRight(4);
                            dlvZones.Items.Add(new DarkUI.Controls.DarkListItem(zId + " | " + zone.Value.Name));
                        }

                        Properties.Settings.Default.Path = path;
                        Properties.Settings.Default.Save();

                        Patcher patcher = new Patcher(_exePath) {Path = _appDataPath};

                        patcher.ApplyPatch(new UnlimitedFreeCamRadius());
                        patcher.ApplyPatch(new RedHandedBypass());
                        patcher.Save(_patchedExePath);

                        return;
                    }
                }
            }

            _mapsPath = null;
            _exePath = null;
            Properties.Settings.Default.Path = null;
            Properties.Settings.Default.Save();

            if(!ignoreError)
            {
                dtbPath.Text = "Invalid path, try again...";
            }
            
        }

        private void DarkButton1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void DarkListView1_DoubleClick(object sender, EventArgs e)
        {
            if (dlvZones.SelectedIndices.Count <= 0)
            {
                return;
            }

            string selected = dlvZones.Items[dlvZones.SelectedIndices[0]].Text;
            int zoneId = int.Parse(selected.Split(' ')[0]);
            //Console.WriteLine(zoneId);

            if(Program.FirefallProcess != null && !Program.FirefallProcess.HasExited)
            {
                Program.FirefallProcess.Kill();
                Program.FirefallProcess.WaitForExit(1000);
            }

            BinaryUtil.DoubleByteMap dMap = new BinaryUtil.DoubleByteMap();
            Nsr dummy = Nsr.GenerateDummyFile(zoneId);

            // temporary solution for changing time as this
            // has been postponed too long due to other changes

            dMap.Double = timePicker1.Value;

            byte[] dBytes = BitConverter.GetBytes(timePicker1.Value);
            dummy.Meta.Unk3[18] = dBytes[0];
            dummy.Meta.Unk3[19] = dBytes[1];
            dummy.Meta.Unk3[20] = dBytes[2];
            dummy.Meta.Unk3[21] = dBytes[3];
            dummy.Meta.Unk3[22] = dBytes[4];
            dummy.Meta.Unk3[23] = dBytes[5];
            dummy.Meta.Unk3[24] = dBytes[6];
            dummy.Meta.Unk3[25] = dBytes[7];

            Console.WriteLine(timePicker1.Value);

            dummy.Write(_dummyReplayPath);

            ProcessStartInfo info = new ProcessStartInfo
            {
                FileName = _patchedExePath,
                WorkingDirectory = _workingDirectory,
                Arguments = "--open=\"" + _dummyReplayPath + "\""
            };

            Program.FirefallProcess = Process.Start(info);
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
