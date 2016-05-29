namespace WindowsFormsApplication1
{
    partial class Main
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CPUInfo = new System.Windows.Forms.Label();
            this.CPU = new System.Windows.Forms.Label();
            this.MEM = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Disk = new System.Windows.Forms.Label();
            this.Net = new System.Windows.Forms.Label();
            this.Time = new System.Windows.Forms.Label();
            this.NIC_ListBox = new System.Windows.Forms.ComboBox();
            this.Interval = new System.Windows.Forms.TextBox();
            this.FontChange_btn = new System.Windows.Forms.Button();
            this.Trans_box = new System.Windows.Forms.CheckBox();
            this.ForeGround_box = new System.Windows.Forms.CheckBox();
            this.CPUInfo_Col_btn = new System.Windows.Forms.Button();
            this.CPU_Col_btn = new System.Windows.Forms.Button();
            this.MEM_Col_btn = new System.Windows.Forms.Button();
            this.Disk_Col_btn = new System.Windows.Forms.Button();
            this.Net_Col_btn = new System.Windows.Forms.Button();
            this.Time_Col_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CPUInfo
            // 
            this.CPUInfo.AutoSize = true;
            this.CPUInfo.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CPUInfo.Location = new System.Drawing.Point(12, 9);
            this.CPUInfo.Name = "CPUInfo";
            this.CPUInfo.Size = new System.Drawing.Size(94, 26);
            this.CPUInfo.TabIndex = 0;
            this.CPUInfo.Text = "CPUInfo";
            this.CPUInfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_MouseDown);
            this.CPUInfo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_MouseMove);
            // 
            // CPU
            // 
            this.CPU.AutoSize = true;
            this.CPU.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CPU.Location = new System.Drawing.Point(12, 61);
            this.CPU.Name = "CPU";
            this.CPU.Size = new System.Drawing.Size(54, 26);
            this.CPU.TabIndex = 1;
            this.CPU.Text = "CPU";
            this.CPU.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_MouseDown);
            this.CPU.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_MouseMove);
            // 
            // MEM
            // 
            this.MEM.AutoSize = true;
            this.MEM.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MEM.Location = new System.Drawing.Point(12, 113);
            this.MEM.Name = "MEM";
            this.MEM.Size = new System.Drawing.Size(59, 26);
            this.MEM.TabIndex = 2;
            this.MEM.Text = "MEM";
            this.MEM.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_MouseDown);
            this.MEM.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_MouseMove);
            // 
            // Disk
            // 
            this.Disk.AutoSize = true;
            this.Disk.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Disk.Location = new System.Drawing.Point(12, 165);
            this.Disk.Name = "Disk";
            this.Disk.Size = new System.Drawing.Size(55, 26);
            this.Disk.TabIndex = 3;
            this.Disk.Text = "Disk";
            this.Disk.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_MouseDown);
            this.Disk.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_MouseMove);
            // 
            // Net
            // 
            this.Net.AutoSize = true;
            this.Net.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Net.Location = new System.Drawing.Point(12, 217);
            this.Net.Name = "Net";
            this.Net.Size = new System.Drawing.Size(48, 26);
            this.Net.TabIndex = 4;
            this.Net.Text = "Net";
            this.Net.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_MouseDown);
            this.Net.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_MouseMove);
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Font = new System.Drawing.Font("Meiryo UI", 15.75F);
            this.Time.Location = new System.Drawing.Point(12, 272);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(62, 26);
            this.Time.TabIndex = 8;
            this.Time.Text = "Time";
            this.Time.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_MouseDown);
            this.Time.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_MouseMove);
            // 
            // NIC_ListBox
            // 
            this.NIC_ListBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NIC_ListBox.FormattingEnabled = true;
            this.NIC_ListBox.Location = new System.Drawing.Point(246, 359);
            this.NIC_ListBox.Name = "NIC_ListBox";
            this.NIC_ListBox.Size = new System.Drawing.Size(269, 20);
            this.NIC_ListBox.TabIndex = 9;
            this.NIC_ListBox.SelectedIndexChanged += new System.EventHandler(this.NIC_ListBox_SelectedIndexChanged);
            // 
            // Interval
            // 
            this.Interval.Location = new System.Drawing.Point(106, 360);
            this.Interval.Name = "Interval";
            this.Interval.Size = new System.Drawing.Size(100, 19);
            this.Interval.TabIndex = 11;
            this.Interval.TextChanged += new System.EventHandler(this.Interval_TextChanged);
            // 
            // FontChange_btn
            // 
            this.FontChange_btn.Location = new System.Drawing.Point(8, 360);
            this.FontChange_btn.Name = "FontChange_btn";
            this.FontChange_btn.Size = new System.Drawing.Size(75, 19);
            this.FontChange_btn.TabIndex = 10;
            this.FontChange_btn.Text = "Font";
            this.FontChange_btn.UseVisualStyleBackColor = true;
            this.FontChange_btn.Click += new System.EventHandler(this.FontChange_btn_Click);
            // 
            // Trans_box
            // 
            this.Trans_box.AutoSize = true;
            this.Trans_box.Location = new System.Drawing.Point(17, 338);
            this.Trans_box.Name = "Trans_box";
            this.Trans_box.Size = new System.Drawing.Size(53, 16);
            this.Trans_box.TabIndex = 12;
            this.Trans_box.Text = "Trans";
            this.Trans_box.UseVisualStyleBackColor = true;
            this.Trans_box.CheckedChanged += new System.EventHandler(this.Trans_box_CheckedChanged);
            // 
            // ForeGround_box
            // 
            this.ForeGround_box.AutoSize = true;
            this.ForeGround_box.Location = new System.Drawing.Point(106, 338);
            this.ForeGround_box.Name = "ForeGround_box";
            this.ForeGround_box.Size = new System.Drawing.Size(75, 16);
            this.ForeGround_box.TabIndex = 13;
            this.ForeGround_box.Text = "Forground";
            this.ForeGround_box.UseVisualStyleBackColor = true;
            this.ForeGround_box.CheckedChanged += new System.EventHandler(this.ForeGround_box_CheckedChanged);
            // 
            // CPUInfo_Col_btn
            // 
            this.CPUInfo_Col_btn.Location = new System.Drawing.Point(12, 35);
            this.CPUInfo_Col_btn.Name = "CPUInfo_Col_btn";
            this.CPUInfo_Col_btn.Size = new System.Drawing.Size(94, 23);
            this.CPUInfo_Col_btn.TabIndex = 14;
            this.CPUInfo_Col_btn.Text = "CPU Info Color";
            this.CPUInfo_Col_btn.UseVisualStyleBackColor = true;
            this.CPUInfo_Col_btn.Click += new System.EventHandler(this.CPUInfo_Color_Click);
            // 
            // CPU_Col_btn
            // 
            this.CPU_Col_btn.Location = new System.Drawing.Point(8, 90);
            this.CPU_Col_btn.Name = "CPU_Col_btn";
            this.CPU_Col_btn.Size = new System.Drawing.Size(98, 23);
            this.CPU_Col_btn.TabIndex = 15;
            this.CPU_Col_btn.Text = "CPU Color";
            this.CPU_Col_btn.UseVisualStyleBackColor = true;
            this.CPU_Col_btn.Click += new System.EventHandler(this.CPUUsed_Color_Click);
            // 
            // MEM_Col_btn
            // 
            this.MEM_Col_btn.Location = new System.Drawing.Point(8, 139);
            this.MEM_Col_btn.Name = "MEM_Col_btn";
            this.MEM_Col_btn.Size = new System.Drawing.Size(98, 23);
            this.MEM_Col_btn.TabIndex = 16;
            this.MEM_Col_btn.Text = "Memory Color";
            this.MEM_Col_btn.UseVisualStyleBackColor = true;
            this.MEM_Col_btn.Click += new System.EventHandler(this.Memory_Color_Click);
            // 
            // Disk_Col_btn
            // 
            this.Disk_Col_btn.Location = new System.Drawing.Point(8, 191);
            this.Disk_Col_btn.Name = "Disk_Col_btn";
            this.Disk_Col_btn.Size = new System.Drawing.Size(98, 23);
            this.Disk_Col_btn.TabIndex = 17;
            this.Disk_Col_btn.Text = "Disk Color";
            this.Disk_Col_btn.UseVisualStyleBackColor = true;
            this.Disk_Col_btn.Click += new System.EventHandler(this.Disk_Color_Click);
            // 
            // Net_Col_btn
            // 
            this.Net_Col_btn.Location = new System.Drawing.Point(8, 246);
            this.Net_Col_btn.Name = "Net_Col_btn";
            this.Net_Col_btn.Size = new System.Drawing.Size(98, 23);
            this.Net_Col_btn.TabIndex = 18;
            this.Net_Col_btn.Text = "Net Color";
            this.Net_Col_btn.UseVisualStyleBackColor = true;
            this.Net_Col_btn.Click += new System.EventHandler(this.Net_Color_Click);
            // 
            // Time_Col_btn
            // 
            this.Time_Col_btn.Location = new System.Drawing.Point(8, 301);
            this.Time_Col_btn.Name = "Time_Col_btn";
            this.Time_Col_btn.Size = new System.Drawing.Size(98, 23);
            this.Time_Col_btn.TabIndex = 19;
            this.Time_Col_btn.Text = "Time Color";
            this.Time_Col_btn.UseVisualStyleBackColor = true;
            this.Time_Col_btn.Click += new System.EventHandler(this.Time_Color_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 385);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 19);
            this.button1.TabIndex = 20;
            this.button1.Text = "Setting";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(527, 416);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Time_Col_btn);
            this.Controls.Add(this.Net_Col_btn);
            this.Controls.Add(this.Disk_Col_btn);
            this.Controls.Add(this.MEM_Col_btn);
            this.Controls.Add(this.CPU_Col_btn);
            this.Controls.Add(this.CPUInfo_Col_btn);
            this.Controls.Add(this.ForeGround_box);
            this.Controls.Add(this.Trans_box);
            this.Controls.Add(this.Interval);
            this.Controls.Add(this.FontChange_btn);
            this.Controls.Add(this.NIC_ListBox);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.Net);
            this.Controls.Add(this.Disk);
            this.Controls.Add(this.MEM);
            this.Controls.Add(this.CPU);
            this.Controls.Add(this.CPUInfo);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main";
            this.Text = "Performance Counter 01";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CPUInfo;
        private System.Windows.Forms.Label CPU;
        private System.Windows.Forms.Label MEM;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Disk;
        private System.Windows.Forms.Label Net;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.ComboBox NIC_ListBox;
        private System.Windows.Forms.TextBox Interval;
        private System.Windows.Forms.Button FontChange_btn;
        private System.Windows.Forms.CheckBox Trans_box;
        private System.Windows.Forms.CheckBox ForeGround_box;
        private System.Windows.Forms.Button CPUInfo_Col_btn;
        private System.Windows.Forms.Button CPU_Col_btn;
        private System.Windows.Forms.Button MEM_Col_btn;
        private System.Windows.Forms.Button Disk_Col_btn;
        private System.Windows.Forms.Button Net_Col_btn;
        private System.Windows.Forms.Button Time_Col_btn;
        private System.Windows.Forms.Button button1;
    }
}

