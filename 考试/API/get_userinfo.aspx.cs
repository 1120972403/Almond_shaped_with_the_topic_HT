using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Data;
public partial class API_get_userinfo : System.Web.UI.Page
{
    DBHelper db = new DBHelper();
    Alert alert = new Alert();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CreateJsonParameters();
        }
    }
    public void CreateJsonParameters()
    {
        string openid = Request.QueryString["openid"];
        string nickname = Request.QueryString["nickName"];
        string avatar = Request.QueryString["avatarUrl"];
        string province = Request.QueryString["province"];
        string city = Request.QueryString["city"];
        string str = "select * from user_info where openid='" + openid + "'";
        DataTable dt = db.SelectDate(str);
        if (dt.Rows.Count > 0)
        {
            string result1 = string.Empty;
            result1 = JsonConvert.SerializeObject(dt, new DataTableConverter());
            Response.Write(result1);
            Response.ContentType = "application/json";
            Response.Charset = "UTF-8";
            Response.End();

        }
        else
        {
            if (openid != "" )
            {
                string d = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string add_str = "insert into user_info(openid,nickname,avatar,province,city,datatime) values('" + openid + "','" + nickname + "','" + avatar + "','" + province + "','" + city + "','" + d + "')";
                int count = db.ChangeDate(add_str);
                if (count > 0)
                {
                    string xinxi = "select * from user_info where openid= '" + openid + "'";
                    DataTable dt2 = db.SelectDate(xinxi);
                    string result1 = string.Empty;
                    result1 = JsonConvert.SerializeObject(dt2, new DataTableConverter());
                    Response.Write(result1);
                    Response.ContentType = "application/json";
                    Response.Charset = "UTF-8";
                    Response.End();
                }
            }
            else
            {
                string result = "错误";
                Response.Write(result);
                Response.ContentType = "application/json";
                Response.Charset = "UTF-8";
                Response.End();
            }

        }


    }
}