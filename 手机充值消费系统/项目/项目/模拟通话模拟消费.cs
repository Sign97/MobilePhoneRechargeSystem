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

namespace 项目
{
    public partial class 模拟通话模拟消费 : Form
    {
        public 模拟通话模拟消费()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //查询手机号的非空验证
            string Fell = this.textBox1.Text;
            if (Fell == "")
            {
                MessageBox.Show("输入不能位空！");
            }

            //验证查询手机号是否存在
            else
            {
                string sqlCheck = string.Format("select * from SIM where SIMFeel ='{0}'", Fell);
                DataSet dsCheck = DBHelper.GetList(sqlCheck);
                if (dsCheck == null || dsCheck.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show("查询不到该手机号！");

                }
                else
                {
                    try
                    {
                    //操作人导入窗口
                    string qw = string.Format("select AdminName from Admin where AdminNumber ='{0}'", Form1.userName);
                    DataSet zz = DBHelper.GetList(qw);
                    SqlDataAdapter ddz = new SqlDataAdapter(qw, DBHelper.cons);
                    ddz.Fill(zz, "sas");
                    this.textBox4.Text = zz.Tables["sas"].Rows[0]["AdminName"].ToString();
                    string caozuoren = this.textBox4.Text;

                        //转换数据类型
                        double shichang = 0;
                        shichang = Convert.ToDouble(textBox2.Text);
                        double danjia = 0;
                        danjia = Convert.ToDouble(textBox3.Text);
                        double xiaofei = shichang * danjia;

                        //充值时间导入窗口
                        string clock = this.label8.Text;
                        this.label8.Text = DateTime.Now.ToString();
                        string shijian = this.label8.Text;

                        //用户名
                        string ls = string.Format("select SIMName from SIM where SIMFeel ='{0}'", Fell);
                        DataSet dss = DBHelper.GetList(ls);
                        SqlDataAdapter dda = new SqlDataAdapter(ls, DBHelper.cons);
                        dda.Fill(dss,"gg");
                        string yonghuming = dss.Tables["gg"].Rows[0]["SIMName"].ToString();

                        SqlConnection conn = new SqlConnection(DBHelper.cons);
                        conn.Open();
                        string ff = string.Format("insert into Record(Tianjiajine) values('-" + xiaofei + "')");
                        SqlCommand rr = new SqlCommand(ff, conn);
                        rr.ExecuteNonQuery();
                        conn.Close();

                        //窗体数据的导入
                        
                        conn.Open();
                        string sql = string.Format("insert into Record(SIMFeel,RecordeClock,RecordMoney,RecordBeizhu,RecordClock,TianjiaRen,Tianjiajine) values('" + Fell + "','" + clock + "','" + xiaofei + "','操作员" + caozuoren + "在" + shijian + "向用户" + yonghuming + "模拟消费了" + xiaofei + "元','" + shijian + "','" + caozuoren + "','-" + xiaofei + "')");
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("消费成功！");

                        //将消费的金额反馈到SIM表余额
                         conn.Open();
                         string sq = string.Format("update SIM set SIMBalance-='" + xiaofei + "' ");
                         SqlCommand md = new SqlCommand(sq, conn);
                         md.ExecuteNonQuery();
                         conn.Close();

                    }
                    catch
                    {
                        MessageBox.Show("数据输入不合法！");
                    }
                }
            }
        }

    }
}
