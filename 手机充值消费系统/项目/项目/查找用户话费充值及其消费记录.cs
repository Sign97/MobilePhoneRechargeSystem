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
    public partial class 查找用户话费充值及其消费记录 : Form
    {
        public 查找用户话费充值及其消费记录()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                //查询手机号的非空验证
                string Fell = this.textBox1.Text.ToString();
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
                        //计算充值总和
                        string sql = string.Format("select sum(RechargeMoney) from Recharge where   SIMFeel ='{0}'", Fell);
                        DataSet ds = DBHelper.GetList(sql);
                        double chogzhi;
                        if (ds.Tables[0].Rows[0][0].ToString() == "")
                        {
                            chogzhi = 0;
                        }
                        chogzhi = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());

                        //计算消费总和
                        string sq = string.Format("select sum(RecordMoney) from Record where   SIMFeel ='{0}'", Fell);
                        DataSet d = DBHelper.GetList(sq);
                        double xiaofei;
                        if (d.Tables[0].Rows[0][0].ToString() == "")
                        {
                            xiaofei = 0;
                        }
                        xiaofei = Convert.ToDouble(d.Tables[0].Rows[0][0].ToString());

                        //话费总消费额
                        double zong = chogzhi + xiaofei - 200;

                        //总消费额导入窗体
                        Label[] labels = new Label[] { this.label3 };
                        labels[0].Text = "" + zong + "";

                        string qq = "select * from SIM,Record where SIM.SIMFeel=Record.SIMFeel and Record.SIMFeel=" + Fell;
                        this.dataGridView1.AutoGenerateColumns = false;
                        this.dataGridView1.DataSource = DBHelper.GetDataTable(qq);

                    }
                }

            }
            catch
            {
                MessageBox.Show("无消费记录！");
            }
        }


    }
}
