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
        private int totalProcesses = 0;
        private ulong totalMemory = 0;
        private ListViewColumnSorter listViewColumnSorter;

        public konumbulma()
        {
            InitializeComponent();
            InitializeListView();
            InitializeTimer();
            konumum();
        }

        private void InitializeListView()
        {
            listViewColumnSorter = new ListViewColumnSorter();
            listView1.ListViewItemSorter = listViewColumnSorter;
            listView1.ColumnClick += ListView1_ColumnClick;
        }

        private void InitializeTimer()
        {
            timer1.Interval = 5000;
            tsbRefreshInterval.SelectedIndex = 1; // Varsayılan 5 saniye
        }

        private void ListView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == listViewColumnSorter.SortColumn)
            {
                listViewColumnSorter.Order = listViewColumnSorter.Order == SortOrder.Ascending ?
                    SortOrder.Descending : SortOrder.Ascending;
            }
            else
            {
                listViewColumnSorter.SortColumn = e.Column;
                listViewColumnSorter.Order = SortOrder.Ascending;
            }

            listView1.Sort();
        }

        private async void konumum()
        {
            if (isRefreshing) return;
            isRefreshing = true;

            lblStatus.Text = "Süreçler yükleniyor...";
            listView1.BeginUpdate();
            listView1.Items.Clear();
            ımageList1.Images.Clear();
            totalProcesses = 0;
            totalMemory = 0;

            try
            {
                var processes = await GetProcessesAsync();

                foreach (var process in processes)
                {
                    if (process.ExecutablePath != null && File.Exists(process.ExecutablePath))
                    {
                        // Arama filtresi uygula
                        if (!string.IsNullOrEmpty(txtSearch.Text) &&
                            !process.Name.ToLower().Contains(txtSearch.Text.ToLower()))
                            continue;

                        var item = new ListViewItem(new[]
                        {
                            process.Name,
                            process.ExecutablePath,
                            FormatMemoryUsage(process.MemoryUsage),
                            process.ProcessId.ToString()
                        });

                        string key = process.ProcessId.ToString();
                        if (process.Icon != null)
                        {
                            ımageList1.Images.Add(key, process.Icon);
                            item.ImageKey = key;
                        }

                        listView1.Items.Add(item);
                        totalProcesses++;
                        totalMemory += process.MemoryUsage;
                    }
                }

                UpdateStatusBar();
                lblStatus.Text = "Hazır";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Hata oluştu";
                MessageBox.Show($"Süreçler yüklenirken hata oluştu: {ex.Message}",
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                listView1.EndUpdate();
                isRefreshing = false;
            }
        }

        private void UpdateStatusBar()
        {
            lblProcessCount.Text = $"Süreçler: {totalProcesses}";
            lblMemory.Text = $"Bellek: {FormatMemoryUsage(totalMemory)}";
        }

        private async Task<ProcessInfo[]> GetProcessesAsync()
        {
            return await Task.Run(() =>
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

        private void bull_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedPath))
            {
                try
                {
                    // Explorer'da dosyayı seçili olarak aç
                    Process.Start("explorer.exe", $"/select,\"{selectedPath}\"");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Konum açılırken hata oluştu: {ex.Message}",
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir program seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                selectedPath = listView1.SelectedItems[0].SubItems[1].Text;
                lblStatus.Text = $"{listView1.SelectedItems[0].Text} seçildi";
            }
            else
            {
                selectedPath = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            konumum();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tsbRefreshInterval.SelectedIndex > 0) // Otomatik yenileme açıksa
            {
                konumum();
            }
        }

        private void konumbulma_Load(object sender, EventArgs e)
        {
            // ListView görünüm ayarları
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbRefreshInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tsbRefreshInterval.SelectedIndex)
            {
                case 0: timer1.Stop(); break; // Kapalı
                case 1: timer1.Interval = 5000; timer1.Start(); break; // 5 saniye
                case 2: timer1.Interval = 10000; timer1.Start(); break; // 10 saniye
                case 3: timer1.Interval = 30000; timer1.Start(); break; // 30 saniye
                case 4: timer1.Interval = 60000; timer1.Start(); break; // 1 dakika
            }
        }

        private void bilgiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = listView1.SelectedItems[0];
                string message = $"Program: {selectedItem.Text}\n" +
                               $"Yol: {selectedItem.SubItems[1].Text}\n" +
                               $"Bellek: {selectedItem.SubItems[2].Text}\n" +
                               $"PID: {selectedItem.SubItems[3].Text}";

                MessageBox.Show(message, "Süreç Bilgileri",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            bilgiToolStripMenuItem_Click(sender, e);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Arama kutusuna yazıldığında filtreleme yapmak için 
            konumum();
        }
    }

    // ListView sıralama
    public class ListViewColumnSorter : IComparer
    {
        public int SortColumn { get; set; } = 0;
        public SortOrder Order { get; set; } = SortOrder.Ascending;

        public int Compare(object x, object y)
        {
            ListViewItem itemX = (ListViewItem)x;
            ListViewItem itemY = (ListViewItem)y;

            string textX = itemX.SubItems[SortColumn].Text;
            string textY = itemY.SubItems[SortColumn].Text;

            // Sayısal sıralama için kontrol (PID ve Bellek sütunları)
            if (SortColumn == 2 || SortColumn == 3) // Bellek veya PID sütunu
            {
                if (double.TryParse(textX.Replace(" MB", "").Replace(" GB", "").Replace(" KB", ""), out double numX) &&
                    double.TryParse(textY.Replace(" MB", "").Replace(" GB", "").Replace(" KB", ""), out double numY))
                {
                    return Order == SortOrder.Ascending ?
                        numX.CompareTo(numY) : numY.CompareTo(numX);
                }
            }

            // Metin sıralamak için
            return Order == SortOrder.Ascending ?
                string.Compare(textX, textY) : string.Compare(textY, textX);
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

            try
            {
                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                {
                    Icon = Icon.ExtractAssociatedIcon(path);
                }
                else
                {
                    Icon = SystemIcons.Application; // Varsayılan ikon
                }
            }
            catch
            {
                Icon = SystemIcons.Application; // Hata durumunda varsayılan ikon
            }
        }
    }
}