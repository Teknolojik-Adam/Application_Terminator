using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{
    public partial class konumbulma : Form
    {
        private bool isRefreshing = false;
        private string selectedPath = null;
        private ImageList imageList1;

        public konumbulma()
        {
            InitializeComponent();
            InitializeStatusStrip();
            InitializeTimer();
            InitializeImageList();
            konumum();
        }

        private void InitializeStatusStrip()
        {
            StatusStrip statusStrip1 = new StatusStrip();
            statusStrip1.Items.Add(new ToolStripStatusLabel() { Name = "lblTotal", Text = "Toplam: 0" });
            statusStrip1.Items.Add(new ToolStripStatusLabel() { Name = "lblLastUpdate", Text = "Son Güncelleme: " });
            this.Controls.Add(statusStrip1);
        }

        private void InitializeTimer()
        {
            Timer timerAutoRefresh = new Timer();
            timerAutoRefresh.Interval = 5000; // 5 saniye
            timerAutoRefresh.Tick += timer1_Tick;
            timerAutoRefresh.Start();
        }

        private void InitializeImageList()
        {
            imageList1 = new ImageList
            {
                ImageSize = new Size(32, 32),
                ColorDepth = ColorDepth.Depth32Bit
            };
            listView1.SmallImageList = imageList1;
        }

        private void konumum()
        {
            listView1.Items.Clear();
            var query = "SELECT ProcessId, Name, ExecutablePath, WorkingSetSize FROM Win32_Process";

            using (var searcher = new ManagementObjectSearcher(query))
            using (var results = searcher.Get())
            {
                foreach (ManagementObject obj in results)
                {
                    try
                    {
                        uint pid = (uint)obj["ProcessId"];
                        string name = (string)obj["Name"];
                        string path = (string)obj["ExecutablePath"];
                        ulong memory = (ulong)obj["WorkingSetSize"];

                        if (path != null && System.IO.File.Exists(path))
                        {
                            var process = new ProcessInfo(pid, name, path, memory);

                            var item = new ListViewItem(new[]
                            {
                             name,
                             path,
                             FormatMemoryUsage(memory)
                         });

                            this.ımageList1.Images.Add(pid.ToString(), process.Icon?.ToBitmap() ?? new Bitmap(1, 1));
                            item.ImageKey = pid.ToString();
                            this.listView1.Items.Add(item);
                        }
                    }
                    catch { }
                }
            }
        }

        private async Task<ProcessInfo[]> GetProcessesAsync()
        {
            return await Task.Run(static () =>
            {
                var query = "SELECT ProcessId, Name, ExecutablePath, WorkingSetSize FROM Win32_Process";
                using (var searcher = new ManagementObjectSearcher(query))
                using (var results = searcher.Get())
                {
                    return results.Cast<ManagementObject>().Select(x => new ProcessInfo(
                        (uint)x["ProcessId"],
                        (string)x["Name"],
                        (string)x["ExecutablePath"],
                        (ulong)x["WorkingSetSize"]
                    )).ToArray();
                }
            });
        }

        private string FormatMemoryUsage(ulong memory)
        {
            if (memory >= 1024 * 1024 * 1024)
                return (memory / (1024 * 1024 * 1024)).ToString("F2") + " GB";
            else if (memory >= 1024 * 1024)
                return (memory / (1024 * 1024)).ToString("F2") + " MB";
            else
                return (memory / 1024).ToString() + " KB";
        }

        private void bull_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedPath))
            {
                System.Diagnostics.Process.Start("explorer.exe", System.IO.Path.GetDirectoryName(selectedPath));
            }
            else
            {
                MessageBox.Show("Lütfen bir program seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                selectedPath = listView1.SelectedItems[0].SubItems[1].Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            konumum();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            konumum();
        }
    }

    public class ProcessInfo
    {
        public uint ProcessId { get; }
        public string Name { get; }
        public string ExecutablePath { get; }
        public Icon Icon { get; }
        public ulong MemoryUsage { get; }

        public ProcessInfo(uint processId, string name, string path, ulong memory)
        {
            ProcessId = processId;
            Name = name;
            ExecutablePath = path;
            MemoryUsage = memory;

            // İkonu yükle
            try
            {
                if (!string.IsNullOrEmpty(path))
                {
                    Icon = Icon.ExtractAssociatedIcon(path);
                }
                else
                {
                    Icon = null; // Yürütülebilir dosya yolu yoksa ikon yok
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"İkon yükleme hatası: {ex.Message}");
                Icon = null; // Hata durumunda ikon yok
            }
        }
    }

    public class ListViewComparer : IComparer
    {
        private readonly int _col;
        private readonly SortOrder _order;

        public ListViewComparer(int column, SortOrder order)
        {
            _col = column;
            _order = order;
        }

        public int Compare(object x, object y)
        {
            // Comparison logic here
            return 0; // Placeholder
        }
    }
}
