using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class SettingWindow : Form
    {
        public SettingWindow()
        {
            InitializeComponent();
            Interval.Text = "1000";
            Console.WriteLine(Environment.NewLine + "[INFO] 設定画面やーーーでーーー。" + Environment.NewLine);
        }
        public class Perf
        {
            public string Font = "0";
            public int Forground = 0;
            public int Interval = 1000;
        }
        
        // 色
        private void CPUInfo_Col_btn_Click(object sender, EventArgs e)
        {

        }
        private void CPU_Col_btn_Click(object sender, EventArgs e)
        {

        }
        private void MEM_Col_btn_Click(object sender, EventArgs e)
        {

        }
        private void Disk_Col_btn_Click(object sender, EventArgs e)
        {

        }
        private void Net_Col_btn_Click(object sender, EventArgs e)
        {

        }
        private void Time_Col_btn_Click(object sender, EventArgs e)
        {

        }

        // 最前面
        private void ForeGround_box_CheckedChanged(object sender, EventArgs e)
        {
            if (ForeGround_box.Checked)
            {
                TopMost = true;
                Console.WriteLine(Environment.NewLine + "[INFO] 最前面表示:有効" + Environment.NewLine);
            }
            else
            {
                TopMost = false;
                Console.WriteLine(Environment.NewLine + "[INFO] 最前面表示:無効" + Environment.NewLine);
            }

        }

        // フォントの設定
        private FontDialog ShowFontDialog()
        {
            FontDialog fd = new FontDialog
            {
                Font = Font,
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
        private void FontChange_btn_Click(object sender, EventArgs e)
        {

            FontDialog fd = ShowFontDialog();
            if (fd == null)
            {
                return;
            }
            Font = fd.Font;
            Console.WriteLine("[INFO] フォントを " + Font + " に設定しました。");
        }
        // 更新速度
        private void Interval_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(Interval.Text, out int i))
            {
                base_timer.Interval = i > 0 ? i : 1;
                Console.WriteLine("[INFO] 更新速度を " + Interval.Text + " に設定しました。" );

            }
        }
        // NIC
        private void NIC_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NIC_info_Click(object sender, EventArgs e)
        {
            NIC_Info NIC_INFO = new NIC_Info();
            NIC_INFO.ShowDialog(this);
        }
    }
}
