using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;
namespace 项目
{
    class DBHelper
    {

        //连接字符串
        public static string cons = "Data Source=.;Initial Catalog=充值系统;Integrated Security=True";
        //增删改
        public static bool ExecuteSql(string sql)
        {
            SqlConnection con = new SqlConnection(cons);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result > 0;
        }
        //查询
        public static DataSet GetList(string sql)
        {
            SqlConnection con = new SqlConnection(cons);
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            con.Close();
            return ds;
        }
        //返回一个值
        public static int GetValue(string sql)
        {
            SqlConnection con = new SqlConnection(cons);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            int result = (int)cmd.ExecuteScalar();
            con.Close();
            return result;
        }

        public static DataTable GetDataTable(string sql)
        {
            SqlConnection con = new SqlConnection(cons);
            DataTable table = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter(sql, con);
            ds.Fill(table);
            con.Close();
            return table;

        }











        //public static string cons = "Data Source=.;Initial Catalog=充值系统;Integrated Security=True";
        //public static SqlConnection conn;
        //public static SqlCommand cmd;
        //public static SqlDataAdapter sda;
        //public static DataSet ds;
        //public static string username;

        ///// <summary>
        ///// 返回受影响的行数,int值
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <returns></returns>
        //public static int GetExecuteNonQuery(string sql)
        //{
        //    Init();
        //    cmd = new SqlCommand(sql, conn);
        //    int i = cmd.ExecuteNonQuery();
        //    conn.Close();
        //    return i;
        //}

        ///// <summary>
        ///// 返回首行首列.string
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <returns></returns>
        //public static string GetExecuteScalar(string sql)
        //{
        //    Init();
        //    cmd = new SqlCommand(sql, conn);
        //    return cmd.ExecuteScalar().ToString();
        //}

        //public static SqlDataReader GetReader(string sql)
        //{
        //    Init();
        //    cmd = new SqlCommand(sql, conn);
        //    return cmd.ExecuteReader();
        //}

        //public static DataTable GetTable(string sql)
        //{
        //    Init();
        //    sda = new SqlDataAdapter(sql, conn);
        //    ds = new DataSet();
        //    sda.Fill(ds);
        //    return ds.Tables[0];
        //}
        //public static void Init()
        //{
        //    try
        //    {
        //        if (conn == null)
        //        {
        //            conn = new SqlConnection(cons);
        //            conn.Open();
        //        }
        //        if (conn.State == ConnectionState.Closed)
        //        {
        //            conn.Open();
        //        }
        //        if (conn.State == ConnectionState.Broken)
        //        {
        //            conn.Close();
        //            conn.Open();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        //MessageBox.Show(e.Message);
        //        return;
        //    }


        //}


    }
}
