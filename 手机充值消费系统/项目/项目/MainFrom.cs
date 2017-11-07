using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 项目
{
    public partial class MainFrom : Form
    {
        public MainFrom()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            开户窗体 sub = new 开户窗体();
            sub.ShowDialog();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            综合信息管理 sub = new 综合信息管理();
            sub.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            话费充值 sub = new 话费充值();
            sub.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            查找用户话费充值及其消费记录 sub = new 查找用户话费充值及其消费记录();
            sub.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            模拟通话模拟消费 sub = new 模拟通话模拟消费();
            sub.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            查找用户话费充值及其消费记录 sub = new 查找用户话费充值及其消费记录();
            sub.ShowDialog();
        }




        
    }
}
