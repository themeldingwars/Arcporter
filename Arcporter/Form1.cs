using FauFau.Formats;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        public Form1()
        {
            InitializeComponent();

            // reuse exe icon for titlebar to avoid duplicate data
            IntPtr hInstance = GetModuleHandle(null);
            IntPtr hIcon = LoadIcon(hInstance, new IntPtr(32512));
            if (hIcon != IntPtr.Zero)
            {
                Icon = Icon.FromHandle(hIcon);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
                    if(Directory.Exists(mapsPath))
                    {
                        exePath = path;
                        darkTextBox1.Text = exePath;

                        string[] zoneFiles = Directory.GetFiles(mapsPath, "*.zone", SearchOption.TopDirectoryOnly);
                        foreach (string zf in zoneFiles)
                        {

                            Zone zone = new FauFau.Formats.Zone();
                            zone.Read(zf);
                            darkListView1.Items.Add(new DarkUI.Controls.DarkListItem(zone.Name));
                        }

                        Properties.Settings.Default.Path = path;
                        Properties.Settings.Default.Save();

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
                darkTextBox1.Text = "Invalid path, try again..";
            }
            
        }

        private void DarkButton1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void DarkListView1_DoubleClick(object sender, EventArgs e)
        {
            if(darkListView1.SelectedIndices.Count > 0)
            {
                string selected = darkListView1.Items[darkListView1.SelectedIndices[0]].Text;
                Console.WriteLine(selected);

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
                if (darkListView1.SelectedIndices.Count > 0)
                {
                    string selected = darkListView1.Items[darkListView1.SelectedIndices[0]].Text;
                    Console.WriteLine(selected);
                }
            }
        }
    }
}
