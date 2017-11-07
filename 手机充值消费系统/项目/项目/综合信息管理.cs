using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace 项目
{
    public partial class 综合信息管理 : Form
    {
        public 综合信息管理()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string xingMing = this.textBox1.Text;
            string zhengHao = this.textBox2.Text;
            if (xingMing == "" && zhengHao == "")
            {
                MessageBox.Show("查询的姓名和身份证号不能同时为空！");
                this.sIMTableAdapter.Fill(this.充值系统DataSet1.SIM);
            }
            //通过姓名模糊查询
            SqlConnection conn = new SqlConnection(DBHelper.cons);
            string sqlStr = "select * from SIM where 1=1";
            if (xingMing != "")
            {
                sqlStr += "and SIMName like'%" + xingMing + "%'";
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(sqlStr, conn);
                dap.Fill(ds, "dataGridView1");
                this.dataGridView1.AutoGenerateColumns = false;
                this.dataGridView1.DataSource = ds.Tables["dataGridView1"];
            }
            //通过身份证号查询
            if (zhengHao != "")
            {
                sqlStr += "and SIMIDcard ='" + zhengHao + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(sqlStr, conn);
                dap.Fill(ds, "dataGridView1");
                this.dataGridView1.AutoGenerateColumns = false;
                this.dataGridView1.DataSource = ds.Tables["dataGridView1"];
            }
            //导入数据
            if (xingMing != "" && zhengHao != "")
            {
                sqlStr += "and SIMIDcard ='" + zhengHao + "' and SIMName='" + xingMing + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(sqlStr, conn);
                dap.Fill(ds, "dataGridView1");
                this.dataGridView1.AutoGenerateColumns = false;
                this.dataGridView1.DataSource = ds.Tables["dataGridView1"];
            }

        }

        private void 综合信息管理_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“充值系统DataSet1.SIM”中。您可以根据需要移动或删除它。
            this.sIMTableAdapter.Fill(this.充值系统DataSet1.SIM);
            // TODO: 这行代码将数据加载到表“充值系统DataSet.SIM”中。您可以根据需要移动或删除它。
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //将表中数据导入
            this.textBox3.Text = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            this.textBox5.Text = this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

            this.comboBox1.Text = this.dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            this.textBox9.Text = this.dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

            this.textBox4.Text = this.dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            this.textBox7.Text = this.dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

            this.textBox8.Text = this.dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            this.textBox6.Text = this.dataGridView1.SelectedRows[0].Cells[7].Value.ToString();

            this.richTextBox1.Text = this.dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //声明标签
            string xingming = this.textBox3.Text;
            string shenfengzheng = this.textBox5.Text;
            string xingbie = this.comboBox1.Text;
            string nianling = this.textBox9.Text;
            string jiguan = this.textBox4.Text;
            string shoujihao = this.textBox7.Text;
            string qq = this.textBox8.Text;
            string Email = this.textBox6.Text;
            string beizhu = this.richTextBox1.Text;
            try
            {
                //修改数据后更新到数据库
                SqlConnection conn = new SqlConnection(DBHelper.cons);
                conn.Open();
                string sqlStr = string.Format("update SIM set SIMName='" + xingming + "',SIMIDcard='" + shenfengzheng + "',SIMSex='" + xingbie + "',SIMAge='" + nianling + "',SIMNative='" + jiguan + "', SIMFeel='" + shoujihao + "', QQ='" + qq + "',SIMMail='" + Email + "', SIMRemarks='" + Email + "' where SIMFeel='" + shoujihao + "'");
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                DataSet ds = new DataSet();
                SqlDataAdapter dap = new SqlDataAdapter(sqlStr, conn);
                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show("修改成功！");
                this.sIMTableAdapter.Fill(this.充值系统DataSet1.SIM);
            }
            catch
            {
                //处理这个异常
                MessageBox.Show("输入的数据类型有误，请重新输入！");
                this.textBox3.Text = "";
                this.textBox5.Text = "";
                this.comboBox1.Text = "";
                this.textBox9.Text = "";
                this.textBox4.Text = "";
                this.textBox7.Text = "";
                this.textBox8.Text = "";
                this.textBox6.Text = "";
                this.richTextBox1.Text = "";
            }
        }

        private void 销户操作ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string shoujihao = this.textBox7.Text;
            //进行账户的注销
            SqlConnection conn = new SqlConnection(DBHelper.cons);
            conn.Open();
            string sqlStr = string.Format("delete SIM where SIMFeel='" + shoujihao + "'");
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(sqlStr, conn);
            int rows = cmd.ExecuteNonQuery();
            MessageBox.Show("销户成功！");
            this.sIMTableAdapter.Fill(this.充值系统DataSet1.SIM);
        }

        private void 冻结操作ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //进行号码冻结
            string shoujihao = this.textBox7.Text;
            string a = "号码冻结";
            SqlConnection conn = new SqlConnection(DBHelper.cons);
            conn.Open();
            string sqlStr = string.Format("update SIM set SIMState='" + a + "' where SIMFeel='" + shoujihao + "'");
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(sqlStr, conn);
            int rows = cmd.ExecuteNonQuery();
            MessageBox.Show("冻结成功！");
            this.sIMTableAdapter.Fill(this.充值系统DataSet1.SIM);
        }

        private void 恢复创建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //恢复号码的使用
            string shoujihao = this.textBox7.Text;
            string a = "正常使用";
            SqlConnection conn = new SqlConnection(DBHelper.cons);
            conn.Open();
            string sqlStr = string.Format("update SIM set SIMState='" + a + "' where SIMFeel='" + shoujihao + "'");
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(sqlStr, conn);
            int rows = cmd.ExecuteNonQuery();
            MessageBox.Show("恢复创建成功！");
            this.sIMTableAdapter.Fill(this.充值系统DataSet1.SIM);
        }

    }
}
