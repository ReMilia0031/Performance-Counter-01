using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsApplication1
{

    public partial class Main : Form
    {
        private PerformanceCounter pcCpuInfo;
        private PerformanceCounter pcCpu;
        private PerformanceCounter pcMem;
        private PerformanceCounter pcDisk;
        private PerformanceCounter pcNW;
        private PerformanceCounter[] pcNWs;

        public Main()
        {
            InitializeComponent();
            Interval.Text = "1000";

            CPUInfo.ForeColor = Color.FromArgb(0xff, 0x3f, 0x3f);
            CPU.ForeColor = Color.FromArgb(0xff, 0x3f, 0x00);
            MEM.ForeColor = Color.FromArgb(0xe6, 0xe6, 0x3f);
            Disk.ForeColor = Color.FromArgb(0x3f, 0xff, 0x3f);
            Net.ForeColor = Color.FromArgb(0x3f, 0x3f, 0xff);
            Time.ForeColor = Color.FromArgb(0x3f, 0xff, 0xff);
        }
        //ネットワークアダプタのふるい分け
        private PerformanceCounter[] CreateNetworkCounters(string counterName)
        {
            var ret = new List<PerformanceCounter>();

            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            // DEBUG
            foreach (var adapter in interfaces)
            {
                Console.WriteLine(adapter.Description);
            }

            var pcc = new PerformanceCounterCategory("Network Interface");
            foreach (string name in pcc.GetInstanceNames())
            {
                if (!interfaces.Any((x) => { return (x.Description == name); }))
                {
                    continue;
                }

                NetworkInterface adapter = interfaces.Single((x) => { return (x.Description == name); });
                if (!(adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet || adapter.NetworkInterfaceType == NetworkInterfaceType.Wireless80211))
                {
                    continue;
                }

                var pc = new PerformanceCounter("Network Interface", counterName, name);
                ret.Add(pc);
            }

            return ret.ToArray();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // NICの種類 "Ethernet" と "Wireless80211" をコンボボックスに追加
            // パフォーマンスカウンタがNDISとVirtualなんちゃらってのが対応してないらしいから追加しない
            pcNWs = CreateNetworkCounters("Bytes Total/sec");
            foreach (PerformanceCounter nw in pcNWs)
            {
                string name = nw.InstanceName;
                NIC_ListBox.Items.Add(nw.InstanceName);
            }

            NIC_ListBox.SelectedIndex = 0;

            // パフォーマンスカウンタから取得するためのアイテムの指定
            //ネットワークはコンボボックス側で設定

            // カテゴリ
            string catCpuInfo = "Processor Information";
            string catCpu = "Processor";
            string catMem = "Memory";
            string catDisk = "PhysicalDisk";

            // カウンタ
            string countCpuInfo = "Processor Frequency";
            string countCpu = "% Processor Time";
            string countMem = "Available MBytes";
            string countDisk = "% Disk Time";

            // インスタンス
            string instanceCpuInfo = "_Total";
            string instanceCpu = "_Total";
            string instanceDisk = "_Total";

            // パフォーマンスカウンタの表示内容
            pcCpuInfo = new PerformanceCounter(catCpuInfo, countCpuInfo, instanceCpuInfo);
            pcCpu = new PerformanceCounter(catCpu, countCpu, instanceCpu);
            pcMem = new PerformanceCounter(catMem, countMem);
            pcDisk = new PerformanceCounter(catDisk, countDisk, instanceDisk);

            //設定した時間ごとに更新するアレ
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Enabled = true;
            RefreshLabels();
        }

        // 設定した時間ごとに(デフォルトは1000ms)ラベル呼び出し
        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshLabels();
        }

        //ラベル
        private void RefreshLabels()
        {
            //Freqの値が0だった場合N/Aと表示 
            if (pcCpuInfo.NextValue() != 0)
            {
                CPUInfo.Text = "Processor Freq : " + pcCpuInfo.NextValue().ToString("0.00") + " MHz";
            }
            else
            {
                CPUInfo.Text = "Processor Freq : N/A";
            }
            CPU.Text = "Processor Time : " + pcCpu.NextValue().ToString("0.00") + " %";

            MEM.Text = "Memory Free : " + pcMem.NextValue().ToString("#,##0") + " MBytes";

            Disk.Text = "PhysicalDisk : " + pcDisk.NextValue().ToString("0.00") + " %";

            Net.Text = "Network Interface : " + pcNW.NextValue().ToString("#,##0") + " Bytes Total/sec";

            Time.Text = "Date : " + DateTime.Now.ToString("yy/MM/dd HH:mm:ss");

        }

        // コンボボックスで選択したNICを表示に反映するアレ
        private void NIC_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            pcNW = pcNWs.Single((x) => { return x.InstanceName == NIC_ListBox.SelectedItem.ToString(); });
        }

        // フォントの設定
        private FontDialog ShowFontDialog()
        {
            FontDialog fd = new FontDialog();

            fd.Font = CPUInfo.Font;
            fd.Color = ForeColor;
            fd.MaxSize = 20;
            fd.MinSize = 10;
            fd.FontMustExist = true;
            fd.AllowVerticalFonts = false;
            fd.ShowColor = true;
            fd.ShowEffects = false;
            fd.FixedPitchOnly = false;
            fd.AllowVectorFonts = true;
            if (fd.ShowDialog() != DialogResult.OK)
            {
                return null;
            }

            return fd;
        }



        //ボタンをクリックした時にフォントダイアログを表示して変更内容をラベルに反映
        private void FontChange_btn_Click(object sender, EventArgs e)
        {
            FontDialog fd = ShowFontDialog();
            if (fd == null)
            {
                return;
            }

            CPUInfo.Font = fd.Font;
            CPU.Font = fd.Font;
            MEM.Font = fd.Font;
            Disk.Font = fd.Font;
            Net.Font = fd.Font;
            Time.Font = fd.Font;
        }

        // 文字色の設定
        private void CPUInfo_Color_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            cd.Color = CPUInfo.ForeColor;
            cd.AllowFullOpen = true;

            if (cd.ShowDialog() == DialogResult.OK)
            {
                CPUInfo.ForeColor = cd.Color;
            }
        }
        private void CPUUsed_Color_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            cd.Color = CPU.ForeColor;
            cd.AllowFullOpen = true;

            if (cd.ShowDialog() == DialogResult.OK)
            {
                CPU.ForeColor = cd.Color;
            }
        }
        private void Memory_Color_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            cd.Color = MEM.ForeColor;
            cd.AllowFullOpen = true;

            if (cd.ShowDialog() == DialogResult.OK)
            {
                MEM.ForeColor = cd.Color;
            }
        }
        private void Disk_Color_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            cd.Color = Disk.ForeColor;
            cd.AllowFullOpen = true;

            if (cd.ShowDialog() == DialogResult.OK)
            {
                Disk.ForeColor = cd.Color;
            }
        }
        private void Net_Color_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            cd.Color = Net.ForeColor;
            cd.AllowFullOpen = true;

            if (cd.ShowDialog() == DialogResult.OK)
            {
                Net.ForeColor = cd.Color;
            }
        }
        private void Time_Color_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            cd.Color = Time.ForeColor;
            cd.AllowFullOpen = true;

            if (cd.ShowDialog() == DialogResult.OK)
            {
                Time.ForeColor = cd.Color;
            }
        }

        //テキストボックスに入力した数字をラベル更新時間に反映
        private void Interval_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (int.TryParse(Interval.Text, out i))
            {
                timer1.Interval = i > 0 ? i : 1;
            }
        }

        //ウィンドウの縁を消して背景を透過
        private void Trans_box_CheckedChanged(object sender, EventArgs e)
        {
            if (Trans_box.Checked)
            {
                FormBorderStyle = FormBorderStyle.None;
                BackColor = Color.FromKnownColor(KnownColor.ControlDarkDark);
                TransparencyKey = Color.FromKnownColor(KnownColor.ControlDarkDark);

                FontChange_btn.Visible = false;
                CPUInfo_Col_btn.Visible = false;
                CPU_Col_btn.Visible = false;
                MEM_Col_btn.Visible = false;
                Disk_Col_btn.Visible = false;
                Net_Col_btn.Visible = false;
                Time_Col_btn.Visible = false;

                ForeGround_box.Visible = false;
                Interval.Visible = false;
                NIC_ListBox.Visible = false;

                Trans_box.ForeColor = Color.FromKnownColor(KnownColor.ControlDarkDark);
            }
            else
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
                BackColor = Color.FromKnownColor(KnownColor.Control);
                TransparencyKey = Color.Empty;

                FontChange_btn.Visible = true;
                CPUInfo_Col_btn.Visible = true;
                CPU_Col_btn.Visible = true;
                MEM_Col_btn.Visible = true;
                Disk_Col_btn.Visible = true;
                Net_Col_btn.Visible = true;
                Time_Col_btn.Visible = true;

                ForeGround_box.Visible = true;
                Interval.Visible = true;
                NIC_ListBox.Visible = true;

                Trans_box.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            }
        }

        //最前面表示
        private void ForeGround_box_CheckedChanged(object sender, EventArgs e)
        {

            if (ForeGround_box.Checked)
            {
                TopMost = true;
            }
            else
            {
                TopMost = false;
            }
        }

        // 項目マウスドラッグで移動
        private Point mousePoint;
        //押された時
        private void label_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // 位置を記憶
                mousePoint = new Point(e.X, e.Y);
            }
        }
        //移動した時
        private void label_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // 移動
                Left += e.X - mousePoint.X;
                Top += e.Y - mousePoint.Y;
            }
        }

    }
}
