
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
            yenile = new System.Windows.Forms.Button();
            kapa = new System.Windows.Forms.Button();
            listeresim = new System.Windows.Forms.ListView();
            ımageList1 = new System.Windows.Forms.ImageList(components);
            button1 = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            panel2 = new System.Windows.Forms.Panel();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // yenile
            // 
            yenile.AutoEllipsis = true;
            yenile.Dock = System.Windows.Forms.DockStyle.Left;
            yenile.Location = new System.Drawing.Point(0, 0);
            yenile.Name = "yenile";
            yenile.Size = new System.Drawing.Size(75, 43);
            yenile.TabIndex = 3;
            yenile.Text = "yenile";
            yenile.UseVisualStyleBackColor = true;
            yenile.Click += yenile_Click;
            // 
            // kapa
            // 
            kapa.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            kapa.Location = new System.Drawing.Point(286, 0);
            kapa.Name = "kapa";
            kapa.Size = new System.Drawing.Size(80, 43);
            kapa.TabIndex = 4;
            kapa.Text = "kapama";
            kapa.UseVisualStyleBackColor = true;
            kapa.Click += kapa_Click;
            // 
            // listeresim
            // 
            listeresim.Dock = System.Windows.Forms.DockStyle.Fill;
            listeresim.HideSelection = false;
            listeresim.LargeImageList = ımageList1;
            listeresim.Location = new System.Drawing.Point(0, 0);
            listeresim.Name = "listeresim";
            listeresim.Size = new System.Drawing.Size(366, 272);
            listeresim.TabIndex = 6;
            listeresim.UseCompatibleStateImageBehavior = false;
            listeresim.SelectedIndexChanged += listeresim_SelectedIndexChanged;
            // 
            // ımageList1
            // 
            ımageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            ımageList1.ImageSize = new System.Drawing.Size(20, 20);
            ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(71, 0);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(218, 43);
            button1.TabIndex = 8;
            button1.Text = "Konum Bul";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // panel1
            // 
            panel1.Controls.Add(listeresim);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(366, 272);
            panel1.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.Controls.Add(kapa);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(yenile);
            panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel2.Location = new System.Drawing.Point(0, 229);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(366, 43);
            panel2.TabIndex = 10;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            ClientSize = new System.Drawing.Size(366, 272);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Form1";
            TopMost = true;
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
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
    }
}

