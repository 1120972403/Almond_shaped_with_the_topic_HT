using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// DBHelper 的摘要说明
/// </summary>
public class DBHelper
{
    
     //连接数据库
    public SqlConnection ConSql()
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = "Data Source=.;Initial Catalog=exam;Persist Security Info=True;User ID=sa;pwd=17340092967";
        return conn;
    }
    /// <summary>
    /// 无参数的数据选择查询
    /// </summary>
    /// <param name="str">要查询的sql语句</param>
    /// <returns></returns>
    public DataTable SelectDate(string str)
    {
        SqlConnection conn = ConSql();
        SqlDataAdapter sda = new SqlDataAdapter(str, conn);//数据适配器不用打开和关闭      
        DataTable dt = new DataTable();//内存数据表
        sda.Fill(dt);
        return dt;
    }
    public DataSet SelectDataSet(string str)
    { 

        SqlConnection conn = ConSql();
        SqlDataAdapter sda = new SqlDataAdapter(str, conn);//数据适配器不用打开和关闭      
        DataSet ds = new DataSet();
        sda.Fill(ds);
        return ds;
    }
    /// <summary>
    /// 返回Datareader对象
    /// </summary>
    /// <param name="str">查询字符串</param>
    /// <returns>返回值</returns>
    public SqlDataReader GetDataReader(string str)
    {
        SqlConnection conn = ConSql();
        SqlCommand cmd = new SqlCommand(str, conn);
        SqlDataReader sdr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        return sdr;


    }
    /// <summary>
    /// 选择查询带ht
    /// </summary>
    /// <param name="str">输入sql语句</param>
    /// <param name="ht">Hanshtable传入数据</param>
    /// <returns></returns>
    public DataTable SelectDate(string str, Hashtable ht)
    {
        SqlConnection conn = ConSql();
        SqlDataAdapter sda = new SqlDataAdapter(str, conn);//数据适配器不用打开和关闭
        foreach (DictionaryEntry a in ht)
        {
            sda.SelectCommand.Parameters.AddWithValue(a.Key.ToString(), a.Value);
        }
        DataTable dt = new DataTable();//内存数据表
        sda.Fill(dt);
        return dt;
    }
    //无参数的数据维护
    public int ChangeDate(string str)
    {
        SqlConnection conn = ConSql();
        conn.Open();
        SqlCommand com = new SqlCommand(str, conn);
        int count = com.ExecuteNonQuery();
        conn.Close();
        return count;
    }
    //有参数的数据维护
    public int ChangeDate(string str, Hashtable ht)
    {
        SqlConnection conn = ConSql();
        conn.Open();
        SqlCommand com = new SqlCommand(str, conn);
        foreach (DictionaryEntry a in ht)
        {
            com.Parameters.AddWithValue(a.Key.ToString(), a.Value);
        }
        int count = com.ExecuteNonQuery();
        conn.Close();
        return count;
    }

    internal static int SelectDate()
    {
        throw new NotImplementedException();
    }
}