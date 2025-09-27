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
        private long totalMemory = 0;

        public Form1()
        {
            InitializeComponent();
            InitializeImageLists();
        }

        private void InitializeImageLists()
        {
            ımageList1.ImageSize = new Size(16, 16);
            ımageList1.ColorDepth = ColorDepth.Depth32Bit;

            ımageList2.ImageSize = new Size(32, 32);
            ımageList2.ColorDepth = ColorDepth.Depth32Bit;

            listeresim.SmallImageList = ımageList1;
            listeresim.LargeImageList = ımageList2;
        }

        private async void konum()
        {
            if (isRefreshing) return;
            isRefreshing = true;

            statusLabel.Text = "Süreçler yükleniyor...";
            listeresim.BeginUpdate();
            listeresim.Items.Clear();
            ımageList1.Images.Clear();
            ımageList2.Images.Clear();
            totalMemory = 0;

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

                int processCount = 0;
                foreach (var p in processes)
                {
                    if (string.IsNullOrEmpty(p.ExecutablePath) || !File.Exists(p.ExecutablePath))
                        continue;

                    string key = p.ExecutablePath;
                    if (!ımageList1.Images.ContainsKey(key))
                    {
                        try
                        {
                            var icon = Icon.ExtractAssociatedIcon(p.ExecutablePath);
                            ımageList1.Images.Add(key, icon);
                            ımageList2.Images.Add(key, icon);
                        }
                        catch {  }
                    }

                    var item = new ListViewItem(new[]
                    {
                        p.Name,
                        FormatMemoryUsage((long)p.Memory),
                        p.ProcessId.ToString(),
                        p.ExecutablePath
                    });
                    item.ImageKey = key;
                    listeresim.Items.Add(item);

                    totalMemory += (long)p.Memory;
                    processCount++;

                    // Her 10 işlemde bir UI'ı güncelle
                    if (processCount % 10 == 0)
                    {
                        statusLabel.Text = $"{processCount} süreç yüklendi...";
                        UpdateMemoryStatus();
                        Application.DoEvents();
                    }
                }

                statusLabel.Text = $"{processCount} süreç yüklendi";
                UpdateMemoryStatus();
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Hata oluştu";
                MessageBox.Show($"Süreçler yüklenirken hata oluştu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                listeresim.EndUpdate();
                isRefreshing = false;
            }
        }

        private void UpdateMemoryStatus()
        {
            memoryLabel.Text = $"Toplam Bellek: {FormatMemoryUsage(totalMemory)}";
        }

        private string FormatMemoryUsage(long memory)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            double len = memory;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }
            return $"{len:0.##} {sizes[order]}";
        }

        private void yenile_Click(object sender, EventArgs e)
        {
            listeresim.Items.Clear();
            konum();
        }

        private async void kapa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedItemName))
            {
                MessageBox.Show("Lütfen kapatmak için bir süreç seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"{selectedItemName} sürecini kapatmak istediğinizden emin misiniz?\n\nNot: Sistem süreçlerini kapatmak sistem kararsızlığına neden olabilir.",
                "Onay",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                statusLabel.Text = $"{selectedItemName} kapatılıyor...";
                var processes = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(selectedItemName));

                if (processes.Length == 0)
                {
                    MessageBox.Show("Süreç bulunamadı.", "Bilgi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (var process in processes)
                {
                    try
                    {
                        // Önce normal şekilde kapatmayı dene
                        if (!process.CloseMainWindow())
                        {
                            // normal kapatma başarısız olursa zorla kapat
                            process.Kill();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{process.ProcessName} kapatılırken hata oluştu: {ex.Message}",
                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                await Task.Delay(1000); // Sürecin kapanması için bekle
                konum(); // Listeyi yenile
                statusLabel.Text = "Süreç kapatıldı";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listeresim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listeresim.SelectedItems.Count == 0)
            {
                selectedItemName = null;
                return;
            }

            selectedItemName = listeresim.SelectedItems[0].Text;
            statusLabel.Text = $"{selectedItemName} seçildi";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            konumbulma frm2 = new konumbulma();
            frm2.ShowDialog(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            listeresim.View = View.Details;
            listeresim.FullRowSelect = true;
            listeresim.GridLines = true;
            listeresim.MultiSelect = false;

            
            listeresim.Columns.Add("Program", 150);
            listeresim.Columns.Add("Bellek", 80);
            listeresim.Columns.Add("PID", 60);
            listeresim.Columns.Add("Yol", 250);

            
            toolStripComboBox1.SelectedIndex = 2; // Detaylar

            
            konum();
        }

       
        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void büyükSimgelerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listeresim.View = View.LargeIcon;
            UpdateViewMenu();
        }

        private void küçükSimgelerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listeresim.View = View.SmallIcon;
            UpdateViewMenu();
        }

        private void detaylarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listeresim.View = View.Details;
            UpdateViewMenu();
        }

        private void UpdateViewMenu()
        {
            büyükSimgelerToolStripMenuItem.Checked = (listeresim.View == View.LargeIcon);
            küçükSimgelerToolStripMenuItem.Checked = (listeresim.View == View.SmallIcon);
            detaylarToolStripMenuItem.Checked = (listeresim.View == View.Details);

            toolStripComboBox1.SelectedIndex = listeresim.View switch
            {
                View.LargeIcon => 0,
                View.SmallIcon => 1,
                View.Details => 2,
                _ => 2
            };
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeresim.View = toolStripComboBox1.SelectedIndex switch
            {
                0 => View.LargeIcon,
                1 => View.SmallIcon,
                2 => View.Details,
                _ => View.Details
            };
            UpdateViewMenu();
        }

        private void özelliklerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listeresim.SelectedItems.Count == 0) return;

            var selectedItem = listeresim.SelectedItems[0];
            MessageBox.Show(
                $"Program: {selectedItem.Text}\n" +
                $"Bellek: {selectedItem.SubItems[1].Text}\n" +
                $"PID: {selectedItem.SubItems[2].Text}\n" +
                $"Yol: {selectedItem.SubItems[3].Text}",
                "Süreç Bilgileri",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void listeresim_DoubleClick(object sender, EventArgs e)
        {
            özelliklerToolStripMenuItem_Click(sender, e);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Kaynakları temizle
            if (ımageList1 != null) ımageList1.Dispose();
            if (ımageList2 != null) ımageList2.Dispose();
            base.OnFormClosing(e);
        }
    }
}