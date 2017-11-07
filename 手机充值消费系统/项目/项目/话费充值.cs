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
    public partial class 话费充值 : Form
    {
        public 话费充值()
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
                //查询SIM表中是否存在手机号
                string sqlCheck = string.Format("select * from SIM where SIMFeel ='{0}'", Fell);
                DataSet dsCheck = DBHelper.GetList(sqlCheck);
                if (dsCheck == null || dsCheck.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show("查询不到该手机号！");

                }
                else
                {
                    //将表中选中数据分别导入右边编辑区
                    this.label11.Text = dsCheck.Tables[0].Rows[0]["SIMName"].ToString();
                    this.label12.Text = dsCheck.Tables[0].Rows[0]["SIMIDcard"].ToString();
                    this.label13.Text = dsCheck.Tables[0].Rows[0]["SIMAge"].ToString();
                    this.label14.Text = dsCheck.Tables[0].Rows[0]["SIMFeel"].ToString();
                    this.label15.Text = dsCheck.Tables[0].Rows[0]["SIMBalance"].ToString();
                    this.label16.Text = dsCheck.Tables[0].Rows[0]["SIMState"].ToString();

                    
                }
            }
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //操作人姓名导入窗口
            string sqls = string.Format("select AdminName from Admin where AdminNumber ='{0}'", Form1.userName);
            DataSet ds = DBHelper.GetList(sqls);
            SqlDataAdapter dd = new SqlDataAdapter(sqls, DBHelper.cons);
            dd.Fill(ds, "ss");
            string caozuoren = ds.Tables["ss"].Rows[0]["AdminName"].ToString();
            this.textBox3.Text = caozuoren;

            //查询SIM表中手机号的状态
            string Fell = this.textBox1.Text;
            string sqlCheck = string.Format("select * from SIM where SIMFeel ='{0}'", Fell);
            DataSet dsCheck = DBHelper.GetList(sqlCheck);
           //判断手机号的状态
            if (dsCheck.Tables[0].Rows[0]["SIMState"].ToString() == "号码冻结")
            {
                MessageBox.Show("账户被冻结，无法进行充值！");
            }
            else
            {
            string chonjin=this.textBox2.Text;
            string clock = this.label17.Text;
            this.label17.Text = DateTime.Now.ToString();
            string a = this.label17.Text;
            //用户名
            string ls = string.Format("select SIMName from SIM where SIMFeel ='{0}'", Fell);
            DataSet dss = DBHelper.GetList(ls);
            SqlDataAdapter dda = new SqlDataAdapter(ls, DBHelper.cons);
            dda.Fill(dss, "sg");
            string yonghuming = dss.Tables["sg"].Rows[0]["SIMName"].ToString();

            //添加充值数据到Recharge表 
            SqlConnection conn = new SqlConnection(DBHelper.cons);
            conn.Open();
            string sql = string.Format("insert into Recharge(SIMFeel,RechargeMoney,RechargeClock) values('" + Fell + "','" + chonjin + "','" + a + "')");
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            //将Recharge表里的金额数据取出来
            string qqw = string.Format("select RechargeMoney from Recharge where SIMFeel ='{0}'", Fell);
            DataSet dssw = DBHelper.GetList(ls);
            SqlDataAdapter ddaa = new SqlDataAdapter(qqw, DBHelper.cons);
            ddaa.Fill(dssw, "sag");
            string chongzhijine = dssw.Tables["sag"].Rows[0]["RechargeMoney"].ToString();
            //将SIM表里的开户时间取出来
            string oo = string.Format("select SIMClock from SIM where SIMFeel ='{0}'", Fell);
            DataSet asd = DBHelper.GetList(ls);
            SqlDataAdapter daa = new SqlDataAdapter(oo, DBHelper.cons);
            daa.Fill(asd, "saag");
            string click = asd.Tables["saag"].Rows[0]["SIMClock"].ToString();
            //数据填充到Record表
            conn.Open();
            string beizhu = string.Format("insert into Record(SIMFeel,RecordeClock,RecordMoney,RecordBeizhu,RecordClock,TianjiaRen,Tianjiajine) values('" + Fell + "','" + click + "','" + chonjin + "','操作员" + caozuoren + "在" + a + "向用户" + yonghuming + "充值了" + chonjin + "元','" + a + "','" + caozuoren + "','" + chonjin + "')");
            SqlCommand ss = new SqlCommand(beizhu, conn);
            ss.ExecuteNonQuery();
            conn.Close();
            //将充值的金额反馈到SIM表余额
            conn.Open();
            string sq = string.Format("update SIM set SIMBalance+='" + chonjin + "' ");
            SqlCommand md = new SqlCommand(sq, conn);
            md.ExecuteNonQuery();
            conn.Close();
                MessageBox.Show("充值成功！");
            }

        }

    }
}
