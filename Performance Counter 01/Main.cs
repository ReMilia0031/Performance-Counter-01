using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Drawing;


namespace WindowsFormsApplication1
{
    public partial class Main : Form
    {
        private PerformanceCounter pcCpuInfo;
        private PerformanceCounter pcCpu;
        private PerformanceCounter pcMem;
        private PerformanceCounter pcDisk;
        private PerformanceCounter pcNW;
        private PerformanceCounter pcGPU;

        public Main()
        {
            InitializeComponent();
            Interval.Text = "1000";

            CPUInfo.ForeColor = Color.FromArgb(0xff, 0x3f, 0x3f);
            CPU.ForeColor = Color.FromArgb(0xff, 0x3f, 0x00);
            MEM.ForeColor = Color.FromArgb(0xe6, 0xe6, 0x3f);
            Disk.ForeColor = Color.FromArgb(0x3f, 0xff, 0x3f);
            Net.ForeColor = Color.FromArgb(0x3f, 0xff, 0xff);
            GPU.ForeColor = Color.FromArgb(0x3f, 0x3f, 0xff);
            Time.ForeColor = Color.FromArgb(0xff, 0x3f, 0xff);
        }
        
        // 設定画面読み込み
        SettingWindow setting = new SettingWindow();

        private void Initialize(object sender, EventArgs e)
        {
            //ログ出力用
            StreamWriter sw = new StreamWriter("log.txt")
            {
                AutoFlush = true
            };
            TextWriter tw = TextWriter.Synchronized(sw);
            Console.SetOut(tw);
            Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));


            // NICをコンボボックスに追加
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

            Console.WriteLine("=====================================");
            Console.WriteLine("[INFO] NICリスト追加開始。" + Environment.NewLine);
            foreach (NetworkInterface adapter in interfaces)
            {
                string NICName = adapter.Name;
                string NICDesc = adapter.Description.ToString();
                string NICType = adapter.NetworkInterfaceType.ToString();
                string NICSpeed = (adapter.Speed / 1000000).ToString(); // Mbps
                string NICAddr = adapter.GetPhysicalAddress().ToString(); //MAC 使うかなコレ


                Console.WriteLine("=====================================");
                // アダプタ列挙してコンソール垂れ流し
                if (adapter.Name == adapter.Description)
                {
                    Console.WriteLine("InterfaceName : " + NICName);
                }
                else
                {
                    Console.WriteLine("InterfaceName : " + NICName);
                    Console.WriteLine("InterfaceDesc : " + NICDesc);
                }
                Console.WriteLine("InterfaceType : " + NICType);

                // NICをコンボボックスにぽいぽい
                // NDISとか付いてるのは無視
                // 選択不能はグレーアウト出来たらおもしろそうだけど
                if (NICDesc.Contains("NDIS") || NICDesc.Contains("Bluetooth") || NICDesc.Contains("Virtual") || NICType.Contains("Tunnel") || NICType.Contains("Loop"))
                {
                    Console.WriteLine("-------------------------------------" + Environment.NewLine + "[INFO] " + NICDesc + " は未対応です。" + Environment.NewLine);
                    continue;
                }

                // "(" ")"があるとエラー吐くから"[" "]"に置換 (主にIntel(R)対策)
                else if (NICDesc.Contains("(") || NICDesc.Contains(")"))
                {
                    string r0 = NICDesc.Replace ("(", "[");
                    string r1 = r0.Replace(")", "]");
                    NIC_ListBox.Items.Add(string.Format(r1));
                    Console.WriteLine("-------------------------------------" + Environment.NewLine + "[INFO] " + NICDesc + "を" + r1 + " に置換し、リストに追加しました。" + Environment.NewLine);
                    continue;
                }

                else
                {
                    NIC_ListBox.Items.Add(string.Format(NICDesc));
                    Console.WriteLine("-------------------------------------" + Environment.NewLine + "[INFO] " + NICDesc + " をリストに追加しました。" + Environment.NewLine);
                }
            }
            Console.WriteLine("[INFO] NICリスト追加終わり。" + Environment.NewLine);

            NIC_ListBox.SelectedIndex = 0;


            // GPUをコンボボックスに追加
            Console.WriteLine("=====================================");
            Console.WriteLine("[INFO] GPUリスト追加開始。" + Environment.NewLine);
            PerformanceCounterCategory pcc;
            string Category = "GPU Engine";
            pcc = new PerformanceCounterCategory(Category);
            string[] instanceNames = pcc.GetInstanceNames();
            var GPUName = pcc.GetCounters(instanceNames[0]);

            foreach (string instanceName in instanceNames)
            {
                GPU_ListBox.Items.Add(instanceName);
                //Console.WriteLine(instanceName + " をリストに追加しました。");
            }
            Console.WriteLine("[INFO] GPUリスト追加終わり。" + Environment.NewLine);

            GPU_ListBox.SelectedIndex = 0;


            Console.WriteLine("=====================================");
            Console.WriteLine("[INFO] 初期化終わり。" + Environment.NewLine);
            // パフォーマンスカウンタから取得するためのアイテムの指定
            //ネットワークとGPUはコンボボックス側で設定

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
            Timer1.Tick += new EventHandler(Timer1_Tick);
            Timer1.Enabled = true;
            RefreshLabels();
            
        }
        //ラベル周りの
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
            GPU.Text = "GPU Engine : " + pcGPU.NextValue().ToString("#,##0") + " %";
            Time.Text = "Date : " + DateTime.Now.ToString("yy/MM/dd HH:mm:ss");
        }

        // コンボボックスで選択したNICを表示に反映するアレ        
        private void NIC_ListBox_SelectedIndexChanged(object sender, EventArgs e)
         {
             string catNW = "Network Interface";
             string countNW = "Bytes Total/sec";
             string instanceNW = NIC_ListBox.SelectedItem.ToString();
             pcNW = new PerformanceCounter(catNW, countNW, instanceNW);
         }

        // コンボボックスで選択したGPUを表示に反映するアレ        
        private void GPU_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string catGPU = "GPU Engine";
            string countGPU = "Utilization Percentage";
            string instanceGPU = GPU_ListBox.SelectedItem.ToString();
            pcGPU = new PerformanceCounter(catGPU, countGPU, instanceGPU);
        }
        // 設定した時間ごとに(デフォルトは1000ms)ラベル呼び出し
        private void Timer1_Tick(object sender, EventArgs e)
        {
            RefreshLabels();
        }

        // フォントの設定
        private FontDialog ShowFontDialog()
        {
            FontDialog fd = new FontDialog
            {
                Font = CPUInfo.Font,
                Color = ForeColor,
                MaxSize = 20,
                MinSize = 10,
                FontMustExist = true,
                AllowVerticalFonts = false,
                ShowColor = true,
                ShowEffects = false,
                FixedPitchOnly = false,
                AllowVectorFonts = true
            };
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
            ColorDialog cd = new ColorDialog
            {
                Color = CPUInfo.ForeColor,
            AllowFullOpen = true
            };

            if (cd.ShowDialog() == DialogResult.OK)
            {
                CPUInfo.ForeColor = cd.Color;
            }
        }
        private void CPUUsed_Color_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog
            {
                Color = CPU.ForeColor,
                AllowFullOpen = true
            };

            if (cd.ShowDialog() == DialogResult.OK)
            {
                CPU.ForeColor = cd.Color;
            }
        }
        private void Memory_Color_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog
            {
                Color = MEM.ForeColor,
                AllowFullOpen = true
            };

            if (cd.ShowDialog() == DialogResult.OK)
            {
                MEM.ForeColor = cd.Color;
            }
        }
        private void Disk_Color_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog
            {
                Color = Disk.ForeColor,
                AllowFullOpen = true
            };

            if (cd.ShowDialog() == DialogResult.OK)
            {
                Disk.ForeColor = cd.Color;
            }
        }
        private void Net_Color_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog
            {
                Color = Net.ForeColor,
                AllowFullOpen = true
            };

            if (cd.ShowDialog() == DialogResult.OK)
            {
                Net.ForeColor = cd.Color;
            }
        }
        private void GPU_Color_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog
            {
                Color = GPU.ForeColor,
                AllowFullOpen = true
            };

            if (cd.ShowDialog() == DialogResult.OK)
            {
                GPU.ForeColor = cd.Color;
            }
        }
        private void Time_Color_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog
            {
                Color = Time.ForeColor,
                AllowFullOpen = true
            };

            if (cd.ShowDialog() == DialogResult.OK)
            {
                Time.ForeColor = cd.Color;
            }
        }

        //テキストボックスに入力した数字をラベル更新時間に反映
        private void Interval_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(Interval.Text, out int i))
            {
                Timer1.Interval = i > 0 ? i : 1;
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
                GPU_Col_btn.Visible = false;
                Time_Col_btn.Visible = false;

                ForeGround_box.Visible = false;
                Interval.Visible = false;
                NIC_ListBox.Visible = false;
                GPU_ListBox.Visible = false;

                Setting_btn.Visible = false;

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
                GPU_Col_btn.Visible = true;
                Time_Col_btn.Visible = true;

                ForeGround_box.Visible = true;
                Interval.Visible = true;
                NIC_ListBox.Visible = true;
                GPU_ListBox.Visible = true;

                Setting_btn.Visible = true;

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
        private void Label_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                mousePoint = new Point(e.X, e.Y);
            }
        }
        //移動した時
        private void Label_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // 移動
                Left += e.X - mousePoint.X;
                Top += e.Y - mousePoint.Y;
            }
        }


        //設定ボタン
        private void Setting_btn_Click(object sender, EventArgs e) => setting.ShowDialog();
    }
}
