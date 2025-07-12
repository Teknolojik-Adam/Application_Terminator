
namespace _1
{
    partial class konumbulma
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(konumbulma));
            bull = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            listView1 = new System.Windows.Forms.ListView();
            ımageList1 = new System.Windows.Forms.ImageList(components);
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // bull
            // 
            resources.ApplyResources(bull, "bull");
            bull.Name = "bull";
            bull.UseVisualStyleBackColor = true;
            bull.Click += bull_Click;
            // 
            // button2
            // 
            resources.ApplyResources(button2, "button2");
            button2.Name = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // listView1
            // 
            resources.ApplyResources(listView1, "listView1");
            listView1.HideSelection = false;
            listView1.LargeImageList = ımageList1;
            listView1.Name = "listView1";
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // ımageList1
            // 
            ımageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            resources.ApplyResources(ımageList1, "ımageList1");
            ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // konumbulma
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(listView1);
            Controls.Add(button2);
            Controls.Add(bull);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "konumbulma";
            ShowIcon = false;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button bull;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.Timer timer1;
    }
}