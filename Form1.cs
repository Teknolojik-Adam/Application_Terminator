using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _1
{
    public partial class Form1 : Form
    {
        private bool disposed = false;
        private bool isRefreshing = false;
        private string selectedItemName = null;
        private ImageList imageList1;

        public Form1()
        {
            InitializeComponent();
            InitializeImageList();
        }
      
        private void InitializeImageList()
        {
            imageList1 = new ImageList();
            imageList1.ImageSize = new Size(32, 32);
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            listeresim.SmallImageList = imageList1;
        }

        private async void konum()
        {
            if (isRefreshing) return;
            isRefreshing = true;

            listeresim.BeginUpdate();
            listeresim.Items.Clear();
            imageList1.Images.Clear();

            try
            {
                var query = "SELECT ProcessId, Name, ExecutablePath, WorkingSetSize FROM Win32_Process";
                var processes = await Task.Run(() =>
                {
                    using (var searcher = new ManagementObjectSearcher(query))
                    using (var results = searcher.Get())
                    {
                        return results.Cast<ManagementObject>().Select(x => new
                        {
                            ProcessId = (uint)x["ProcessId"],
                            Name = (string)x["Name"],
                            ExecutablePath = (string)x["ExecutablePath"],
                            Memory = (ulong)x["WorkingSetSize"]
                        }).ToList();
                    }
                });

                foreach (var p in processes)
                {
                    if (string.IsNullOrEmpty(p.ExecutablePath) || !File.Exists(p.ExecutablePath))
                        continue;

                    string key = p.ExecutablePath;
                    if (!imageList1.Images.ContainsKey(key))
                    {
                        try
                        {
                            var icon = Icon.ExtractAssociatedIcon(p.ExecutablePath);
                            imageList1.Images.Add(key, icon);
                        }
                        catch { /* Handle icon extraction errors */ }
                    }

                    var item = new ListViewItem(new[]
                    {
            p.Name,
            FormatMemoryUsage((long)p.Memory)
        });
                    item.ImageKey = key;
                    listeresim.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
            finally
            {
                listeresim.EndUpdate();
                isRefreshing = false;
            }
        }

        private string FormatMemoryUsage(long memory)
        {
            if (memory >= 1024 * 1024 * 1024)
                return (memory / (1024 * 1024 * 1024)).ToString("F2") + " GB";
            else if (memory >= 1024 * 1024)
                return (memory / (1024 * 1024)).ToString("F2") + " MB";
            else
                return (memory / 1024).ToString() + " KB";
        }
        private void yenile_Click(object sender, EventArgs e)
        {
            listeresim.Items.Clear();
            konum();
        }
        private async void kapa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedItemName)) return;

            var confirm = MessageBox.Show($"Kapatmak istediğinden emin misin? {selectedItemName}?", "Onay", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            try
            {
                var processes = Process.GetProcessesByName(selectedItemName);
                foreach (var process in processes)
                {
                    try
                    {
                        if (!process.CloseMainWindow())
                            process.Kill();
                    }
                    catch (Exception ex)
                    {
                        LogError(ex);
                    }
                }
                await Task.Delay(500); // Allow time for process exit
                konum(); // Refresh
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void listeresim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listeresim.SelectedItems.Count == 0) return;
            selectedItemName = Path.GetFileNameWithoutExtension(listeresim.SelectedItems[0].Text);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            konumbulma frm2 = new konumbulma();
            frm2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listeresim.View = View.Details;
            listeresim.FullRowSelect = true;

            listeresim.Columns.Add("Program", 200);
            listeresim.Columns.Add("Bellek", 100);
        }
        private void LogError(Exception ex)
        {
            System.Diagnostics.EventLog eventLog = new System.Diagnostics.EventLog("Application")
            {
                Source = "YourAppSource"
            };
            eventLog.WriteEntry($"Error: {ex.Message}", System.Diagnostics.EventLogEntryType.Error);
        }
    }
}
