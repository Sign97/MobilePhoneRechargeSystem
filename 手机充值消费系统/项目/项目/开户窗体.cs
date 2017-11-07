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
    public partial class 开户窗体 : Form
    {
        public 开户窗体()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //进行标签命名
            string Name = this.Ming.Text;
            string shengfen = this.textBox5.Text;
            string gender = this.comboBox1.Text;
            string nianling = this.textBox4.Text;
            string jinguan = this.textBox2.Text;
            string Hao = this.textBox3.Text;
            string qq = this.textBox8.Text;
            string Email = this.textBox6.Text;
            string beizhu = this.richTextBox1.Text;

            try
            {
                string zhuangtai = "正常使用";
                //非空验证
                if (Name == "" || gender == "" || shengfen == "" || nianling == "" || jinguan == "" || Hao == "")
                {
                    MessageBox.Show("请将必填项填写完整！");
                }
                else
                {
                    //查询开户的账号是否存在
                    string sqlCheck = string.Format("select * from SIM where SIMFeel ='{0}' or SIMIDcard='{1}'", Hao, shengfen);
                    DataSet dsCheck = DBHelper.GetList(sqlCheck);
                    if (dsCheck == null || dsCheck.Tables[0].Rows.Count <= 0)
                    {
                        //向数据库添加数据
                        SqlConnection conn = new SqlConnection(DBHelper.cons);
                        conn.Open();
                        string sqlStr = string.Format("insert into SIM(SIMName,SIMIDcard,SIMSex,SIMAge,SIMNative,SIMFeel,QQ,SIMMail,SIMRemarks,SIMState,SIMClock) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", Name, shengfen, gender, nianling, jinguan, Hao, qq, Email, beizhu, zhuangtai, DateTime.Now.ToString(""));
                        SqlCommand cmd = new SqlCommand(sqlStr, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("用户添加成功！");
                        this.Ming.Text = "";
                        this.textBox5.Text = "";
                        this.comboBox1.Text = "";
                        this.textBox4.Text = "";
                        this.textBox2.Text = "";
                        this.textBox3.Text = "";
                        this.textBox8.Text = "";
                        this.textBox6.Text = "";
                        this.richTextBox1.Text = "";

                    }
                    else
                        MessageBox.Show("用户已存在，请检查身份证和号码是否正确！");
                    this.Ming.Text = "";
                    this.textBox5.Text = "";
                    this.comboBox1.Text = "";
                    this.textBox4.Text = "";
                    this.textBox2.Text = "";
                    this.textBox3.Text = "";
                    this.textBox8.Text = "";
                    this.textBox6.Text = "";
                    this.richTextBox1.Text = "";
                }
            }
            catch
            {
                //处理这个异常
                MessageBox.Show("输入的字符类型不合法，请重新输入！");
                this.Ming.Text = "";
                this.textBox5.Text ="";
                this.comboBox1.Text  ="";
                this.textBox4.Text = "";
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.textBox8.Text = "";
                this.textBox6.Text = "";
                this.richTextBox1.Text = "";
            }

        }
    }
}
