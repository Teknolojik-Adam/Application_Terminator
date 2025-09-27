
using System.Drawing;
using System.Windows.Forms;

namespace _1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));

            // Yeni kontroller
            menuStrip1 = new MenuStrip();
            dosyaToolStripMenuItem = new ToolStripMenuItem();
            yenileToolStripMenuItem = new ToolStripMenuItem();
            çıkışToolStripMenuItem = new ToolStripMenuItem();
            görünümToolStripMenuItem = new ToolStripMenuItem();
            büyükSimgelerToolStripMenuItem = new ToolStripMenuItem();
            küçükSimgelerToolStripMenuItem = new ToolStripMenuItem();
            detaylarToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            memoryLabel = new ToolStripStatusLabel();
            contextMenuStrip1 = new ContextMenuStrip(components);
            kapatToolStripMenuItem = new ToolStripMenuItem();
            yenileToolStripMenuItem1 = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            özelliklerToolStripMenuItem = new ToolStripMenuItem();

            yenile = new Button();
            kapa = new Button();
            listeresim = new ListView();
            ımageList1 = new ImageList(components);
            ımageList2 = new ImageList(components); // Büyük ikonlar için
            button1 = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            openFileDialog1 = new OpenFileDialog();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripLabel1 = new ToolStripLabel();
            toolStripComboBox1 = new ToolStripComboBox();

            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();

            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] {
                dosyaToolStripMenuItem,
                görünümToolStripMenuItem});
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(584, 24);
            menuStrip1.TabIndex = 11;
            menuStrip1.Text = "menuStrip1";
            // 
            // dosyaToolStripMenuItem
            // 
            dosyaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                yenileToolStripMenuItem,
                çıkışToolStripMenuItem});
            dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            dosyaToolStripMenuItem.Size = new Size(51, 20);
            dosyaToolStripMenuItem.Text = "&Dosya";
            // 
            // yenileToolStripMenuItem
            // 
            yenileToolStripMenuItem.Image = (Image)resources.GetObject("yenileToolStripMenuItem.Image");
            yenileToolStripMenuItem.Name = "yenileToolStripMenuItem";
            yenileToolStripMenuItem.ShortcutKeys = Keys.F5;
            yenileToolStripMenuItem.Size = new Size(180, 22);
            yenileToolStripMenuItem.Text = "&Yenile";
            yenileToolStripMenuItem.Click += yenile_Click;
            // 
            // çıkışToolStripMenuItem
            // 
            çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            çıkışToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            çıkışToolStripMenuItem.Size = new Size(180, 22);
            çıkışToolStripMenuItem.Text = "Çıkış";
            çıkışToolStripMenuItem.Click += çıkışToolStripMenuItem_Click;
            // 
            // görünümToolStripMenuItem
            // 
            görünümToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                büyükSimgelerToolStripMenuItem,
                küçükSimgelerToolStripMenuItem,
                detaylarToolStripMenuItem});
            görünümToolStripMenuItem.Name = "görünümToolStripMenuItem";
            görünümToolStripMenuItem.Size = new Size(73, 20);
            görünümToolStripMenuItem.Text = "&Görünüm";
            // 
            // büyükSimgelerToolStripMenuItem
            // 
            büyükSimgelerToolStripMenuItem.Name = "büyükSimgelerToolStripMenuItem";
            büyükSimgelerToolStripMenuItem.Size = new Size(180, 22);
            büyükSimgelerToolStripMenuItem.Text = "Büyük Simgeler";
            büyükSimgelerToolStripMenuItem.Click += büyükSimgelerToolStripMenuItem_Click;
            // 
            // küçükSimgelerToolStripMenuItem
            // 
            küçükSimgelerToolStripMenuItem.Name = "küçükSimgelerToolStripMenuItem";
            küçükSimgelerToolStripMenuItem.Size = new Size(180, 22);
            küçükSimgelerToolStripMenuItem.Text = "Küçük Simgeler";
            küçükSimgelerToolStripMenuItem.Click += küçükSimgelerToolStripMenuItem_Click;
            // 
            // detaylarToolStripMenuItem
            // 
            detaylarToolStripMenuItem.Checked = true;
            detaylarToolStripMenuItem.CheckState = CheckState.Checked;
            detaylarToolStripMenuItem.Name = "detaylarToolStripMenuItem";
            detaylarToolStripMenuItem.Size = new Size(180, 22);
            detaylarToolStripMenuItem.Text = "Detaylar";
            detaylarToolStripMenuItem.Click += detaylarToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] {
                statusLabel,
                memoryLabel});
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(584, 22);
            statusStrip1.TabIndex = 12;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(469, 17);
            statusLabel.Spring = true;
            statusLabel.Text = "Hazır";
            statusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // memoryLabel
            // 
            memoryLabel.Name = "memoryLabel";
            memoryLabel.Size = new Size(100, 17);
            memoryLabel.Text = "Bellek: 0 MB";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] {
                kapatToolStripMenuItem,
                yenileToolStripMenuItem1,
                toolStripSeparator1,
                özelliklerToolStripMenuItem});
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(181, 98);
            // 
            // kapatToolStripMenuItem
            // 
            kapatToolStripMenuItem.Image = (Image)resources.GetObject("kapatToolStripMenuItem.Image");
            kapatToolStripMenuItem.Name = "kapatToolStripMenuItem";
            kapatToolStripMenuItem.Size = new Size(180, 22);
            kapatToolStripMenuItem.Text = "Kapat";
            kapatToolStripMenuItem.Click += kapa_Click;
            // 
            // yenileToolStripMenuItem1
            // 
            yenileToolStripMenuItem1.Image = (Image)resources.GetObject("yenileToolStripMenuItem1.Image");
            yenileToolStripMenuItem1.Name = "yenileToolStripMenuItem1";
            yenileToolStripMenuItem1.Size = new Size(180, 22);
            yenileToolStripMenuItem1.Text = "Yenile";
            yenileToolStripMenuItem1.Click += yenile_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // özelliklerToolStripMenuItem
            // 
            özelliklerToolStripMenuItem.Image = (Image)resources.GetObject("özelliklerToolStripMenuItem.Image");
            özelliklerToolStripMenuItem.Name = "özelliklerToolStripMenuItem";
            özelliklerToolStripMenuItem.Size = new Size(180, 22);
            özelliklerToolStripMenuItem.Text = "Özellikler";
            özelliklerToolStripMenuItem.Click += özelliklerToolStripMenuItem_Click;
            // 
            // yenile
            // 
            yenile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            yenile.Image = (Image)resources.GetObject("yenile.Image");
            yenile.ImageAlign = ContentAlignment.MiddleLeft;
            yenile.Location = new Point(404, 5);
            yenile.Name = "yenile";
            yenile.Size = new Size(75, 30);
            yenile.TabIndex = 3;
            yenile.Text = "Yenile";
            yenile.TextAlign = ContentAlignment.MiddleRight;
            yenile.UseVisualStyleBackColor = true;
            yenile.Click += yenile_Click;
            // 
            // kapa
            // 
            kapa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            kapa.Image = (Image)resources.GetObject("kapa.Image");
            kapa.ImageAlign = ContentAlignment.MiddleLeft;
            kapa.Location = new Point(485, 5);
            kapa.Name = "kapa";
            kapa.Size = new Size(75, 30);
            kapa.TabIndex = 4;
            kapa.Text = "Kapat";
            kapa.TextAlign = ContentAlignment.MiddleRight;
            kapa.UseVisualStyleBackColor = true;
            kapa.Click += kapa_Click;
            // 
            // listeresim
            // 
            listeresim.ContextMenuStrip = contextMenuStrip1;
            listeresim.Dock = DockStyle.Fill;
            listeresim.FullRowSelect = true;
            listeresim.HideSelection = false;
            listeresim.LargeImageList = ımageList2;
            listeresim.Location = new Point(0, 25);
            listeresim.Name = "listeresim";
            listeresim.Size = new Size(584, 353);
            listeresim.SmallImageList = ımageList1;
            listeresim.TabIndex = 6;
            listeresim.UseCompatibleStateImageBehavior = false;
            listeresim.SelectedIndexChanged += listeresim_SelectedIndexChanged;
            listeresim.DoubleClick += listeresim_DoubleClick;
            // 
            // ımageList1
            // 
            ımageList1.ColorDepth = ColorDepth.Depth32Bit;
            ımageList1.ImageSize = new Size(16, 16);
            ımageList1.TransparentColor = Color.Transparent;
            // 
            // ımageList2
            // 
            ımageList2.ColorDepth = ColorDepth.Depth32Bit;
            ımageList2.ImageSize = new Size(32, 32);
            ımageList2.TransparentColor = Color.Transparent;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(5, 5);
            button1.Name = "button1";
            button1.Size = new Size(393, 30);
            button1.TabIndex = 8;
            button1.Text = "Konum Bul";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // panel1
            // 
            panel1.Controls.Add(listeresim);
            panel1.Controls.Add(toolStrip1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(584, 378);
            panel1.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.Controls.Add(button1);
            panel2.Controls.Add(yenile);
            panel2.Controls.Add(kapa);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 402);
            panel2.Name = "panel2";
            panel2.Size = new Size(584, 40);
            panel2.TabIndex = 10;
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Top;
            toolStrip1.Items.AddRange(new ToolStripItem[] {
                toolStripButton1,
                toolStripButton2,
                toolStripSeparator2,
                toolStripLabel1,
                toolStripComboBox1});
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(584, 25);
            toolStrip1.TabIndex = 7;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(23, 22);
            toolStripButton1.Text = "Yenile";
            toolStripButton1.Click += yenile_Click;
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(23, 22);
            toolStripButton2.Text = "Kapat";
            toolStripButton2.Click += kapa_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(45, 22);
            toolStripLabel1.Text = "Görünüm:";
            // 
            // toolStripComboBox1
            // 
            toolStripComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripComboBox1.Items.AddRange(new object[] {
            "Büyük Simgeler",
                "Küçük Simgeler",
            "Detaylar"});
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new Size(121, 25);
            toolStripComboBox1.SelectedIndexChanged += toolStripComboBox1_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 450);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(600, 400);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Süreç Yöneticisi";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button yenile;
        private System.Windows.Forms.Button kapa;
        private System.Windows.Forms.ListView listeresim;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ImageList ımageList1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem dosyaToolStripMenuItem;
        private ToolStripMenuItem yenileToolStripMenuItem;
        private ToolStripMenuItem çıkışToolStripMenuItem;
        private ToolStripMenuItem görünümToolStripMenuItem;
        private ToolStripMenuItem büyükSimgelerToolStripMenuItem;
        private ToolStripMenuItem küçükSimgelerToolStripMenuItem;
        private ToolStripMenuItem detaylarToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabel;
        private ToolStripStatusLabel memoryLabel;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem kapatToolStripMenuItem;
        private ToolStripMenuItem yenileToolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem özelliklerToolStripMenuItem;
        private ImageList ımageList2;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripLabel toolStripLabel1;
        private ToolStripComboBox toolStripComboBox1;
    }
}

