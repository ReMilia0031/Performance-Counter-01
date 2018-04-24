namespace WindowsFormsApplication1
{
    partial class SettingWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingWindow));
            this.Interval = new System.Windows.Forms.TextBox();
            this.FontChange_btn = new System.Windows.Forms.Button();
            this.NIC_ListBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ForeGround_box = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Time_Col_btn = new System.Windows.Forms.Button();
            this.Net_Col_btn = new System.Windows.Forms.Button();
            this.Disk_Col_btn = new System.Windows.Forms.Button();
            this.MEM_Col_btn = new System.Windows.Forms.Button();
            this.CPU_Col_btn = new System.Windows.Forms.Button();
            this.CPUInfo_Col_btn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.Cancel_btn = new System.Windows.Forms.Button();
            this.OK_btn = new System.Windows.Forms.Button();
            this.NIC_info = new System.Windows.Forms.Button();
            this.base_timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Interval
            // 
            resources.ApplyResources(this.Interval, "Interval");
            this.Interval.Name = "Interval";
            this.Interval.TextChanged += new System.EventHandler(this.Interval_TextChanged);
            // 
            // FontChange_btn
            // 
            resources.ApplyResources(this.FontChange_btn, "FontChange_btn");
            this.FontChange_btn.Name = "FontChange_btn";
            this.FontChange_btn.UseVisualStyleBackColor = true;
            this.FontChange_btn.Click += new System.EventHandler(this.FontChange_btn_Click);
            // 
            // NIC_ListBox
            // 
            this.NIC_ListBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NIC_ListBox.FormattingEnabled = true;
            resources.ApplyResources(this.NIC_ListBox, "NIC_ListBox");
            this.NIC_ListBox.Name = "NIC_ListBox";
            this.NIC_ListBox.SelectedIndexChanged += new System.EventHandler(this.NIC_ListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // ForeGround_box
            // 
            resources.ApplyResources(this.ForeGround_box, "ForeGround_box");
            this.ForeGround_box.Name = "ForeGround_box";
            this.ForeGround_box.UseVisualStyleBackColor = true;
            this.ForeGround_box.CheckedChanged += new System.EventHandler(this.ForeGround_box_CheckedChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // Time_Col_btn
            // 
            resources.ApplyResources(this.Time_Col_btn, "Time_Col_btn");
            this.Time_Col_btn.Name = "Time_Col_btn";
            this.Time_Col_btn.UseVisualStyleBackColor = true;
            this.Time_Col_btn.Click += new System.EventHandler(this.Time_Col_btn_Click);
            // 
            // Net_Col_btn
            // 
            resources.ApplyResources(this.Net_Col_btn, "Net_Col_btn");
            this.Net_Col_btn.Name = "Net_Col_btn";
            this.Net_Col_btn.UseVisualStyleBackColor = true;
            this.Net_Col_btn.Click += new System.EventHandler(this.Net_Col_btn_Click);
            // 
            // Disk_Col_btn
            // 
            resources.ApplyResources(this.Disk_Col_btn, "Disk_Col_btn");
            this.Disk_Col_btn.Name = "Disk_Col_btn";
            this.Disk_Col_btn.UseVisualStyleBackColor = true;
            this.Disk_Col_btn.Click += new System.EventHandler(this.Disk_Col_btn_Click);
            // 
            // MEM_Col_btn
            // 
            resources.ApplyResources(this.MEM_Col_btn, "MEM_Col_btn");
            this.MEM_Col_btn.Name = "MEM_Col_btn";
            this.MEM_Col_btn.UseVisualStyleBackColor = true;
            this.MEM_Col_btn.Click += new System.EventHandler(this.MEM_Col_btn_Click);
            // 
            // CPU_Col_btn
            // 
            resources.ApplyResources(this.CPU_Col_btn, "CPU_Col_btn");
            this.CPU_Col_btn.Name = "CPU_Col_btn";
            this.CPU_Col_btn.UseVisualStyleBackColor = true;
            this.CPU_Col_btn.Click += new System.EventHandler(this.CPU_Col_btn_Click);
            // 
            // CPUInfo_Col_btn
            // 
            resources.ApplyResources(this.CPUInfo_Col_btn, "CPUInfo_Col_btn");
            this.CPUInfo_Col_btn.Name = "CPUInfo_Col_btn";
            this.CPUInfo_Col_btn.UseVisualStyleBackColor = true;
            this.CPUInfo_Col_btn.Click += new System.EventHandler(this.CPUInfo_Col_btn_Click);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.Cancel_btn, "Cancel_btn");
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.UseVisualStyleBackColor = true;
            // 
            // OK_btn
            // 
            this.OK_btn.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.OK_btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.OK_btn, "OK_btn");
            this.OK_btn.Name = "OK_btn";
            this.OK_btn.UseVisualStyleBackColor = true;
            // 
            // NIC_info
            // 
            resources.ApplyResources(this.NIC_info, "NIC_info");
            this.NIC_info.Name = "NIC_info";
            this.NIC_info.UseVisualStyleBackColor = true;
            this.NIC_info.Click += new System.EventHandler(this.NIC_info_Click);
            // 
            // SettingWindow
            // 
            this.AcceptButton = this.OK_btn;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_btn;
            this.Controls.Add(this.NIC_info);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.OK_btn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Time_Col_btn);
            this.Controls.Add(this.Net_Col_btn);
            this.Controls.Add(this.Disk_Col_btn);
            this.Controls.Add(this.MEM_Col_btn);
            this.Controls.Add(this.CPU_Col_btn);
            this.Controls.Add(this.CPUInfo_Col_btn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ForeGround_box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Interval);
            this.Controls.Add(this.FontChange_btn);
            this.Controls.Add(this.NIC_ListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingWindow";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Interval;
        private System.Windows.Forms.Button FontChange_btn;
        private System.Windows.Forms.ComboBox NIC_ListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ForeGround_box;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Time_Col_btn;
        private System.Windows.Forms.Button Net_Col_btn;
        private System.Windows.Forms.Button Disk_Col_btn;
        private System.Windows.Forms.Button MEM_Col_btn;
        private System.Windows.Forms.Button CPU_Col_btn;
        private System.Windows.Forms.Button CPUInfo_Col_btn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Cancel_btn;
        private System.Windows.Forms.Button OK_btn;
        private System.Windows.Forms.Button NIC_info;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer base_timer;
    }
}