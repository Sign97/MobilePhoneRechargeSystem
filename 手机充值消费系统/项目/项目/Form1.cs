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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public static string userName;
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //可能出现异常的代码
            
            //获取用户输入的用户名和密码
             userName = this.textBox1.Text;
            string passWord = this.textBox2.Text;
            //如果你不觉得麻烦就自己做一个自定义类，用来显示错误的信息。怕麻烦就用系统的抛出。
 
 

            //非空验证
            if (userName == "" || passWord == "")
            {
                MessageBox.Show("用户名和密码不能为空！");
            }
            else{
            //string conn = "Data Source=.;Initial Catalog=充值系统;Integrated Security=True";
             //使用创建数据库连接   
                using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=充值系统;Integrated Security=True"))
            {

                //创建数据库查询命令   
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    //查询命令为:查询UserName等于输入的用户名   
                    cmd.CommandText = "select * from Admin where AdminNumber='" + userName + "'";

                    conn.Open();//打开数据库  
                    //将查询到的数据保存在reader这个变量里   
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        //如果reader.Read()的结果不为空, 则说明输入的用户名存在   
                        if (reader.Read())
                        {
                            /*从数据库里查询出和用户相对应的PassWorld的值 
                             *reader.GetOrdinal("PassWord")的作用是得到PassWord的为这行数据中的第几列,返回回值是int 
                             *reader.GetString()的作用是得到第几列的值,返回类型为String. 
                             */
                            string dbpassword = reader.GetString(reader.GetOrdinal("AdminPwd"));

                            //比较用户输入的密码与从数据库中查询到的密码是否一至   
                            if (passWord == dbpassword)
                            {
                                //如果相等,就登录成功   
                                //Console.WriteLine("登录成功!");  
                                MainFrom ss = new MainFrom();
                                ss.Show();
                                this.Hide();
                            }
                            else
                            {
                                //如果不相等,说明密码不对   
                                MessageBox.Show("输入的用户名或密码错误，请重新输入！");
                                this.textBox1.Text = "";
                                this.textBox2.Text = "";
                            }

                        }
                        else
                        {
                            //说明输入的用户名不存在   
                            MessageBox.Show("输入的用户名或密码错误，请重新输入！");
                            this.textBox1.Text = "";
                            this.textBox2.Text = "";
                        }
                    }

                }
            }


            }


            }
            catch 
            {
                //处理这个异常
                MessageBox.Show("输入的用户名或密码错误，请重新输入！");
                this.textBox1.Text  = "";
                this.textBox2.Text  = "";


            } 

            
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
