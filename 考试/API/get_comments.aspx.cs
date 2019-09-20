using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class API_get_comments : System.Web.UI.Page
{
    DBHelper db = new DBHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CreateJsonParameters();
        }
    }
    public void CreateJsonParameters()
    {

        string d = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string uid = Request.QueryString["uid"];
        string opinion = Request.QueryString["opinion"];
        string contant = Request.QueryString["contant"];
        string type = Request.QueryString["type"];
        string details_id = Request.QueryString["details_id"];
        if (uid != ""& type!="")
        {
            string add_str = "insert into user_feedback(uid,opinion,contant,type,details_id,datetime) values('" + uid + "','" + opinion + "','" + contant + "','" + type + "','" + details_id + "','" + d + "')";
            int count = db.ChangeDate(add_str);
            if (count > 0)
            {
                string result = "插入成功";
                Response.Write(result);
                Response.ContentType = "application/json";
                Response.Charset = "UTF-8";
                Response.End();
            }
        }
        else
        {
            string result = "插入失败";
            Response.Write(result);
            Response.ContentType = "application/json";
            Response.Charset = "UTF-8";
            Response.End();
        }
    }
}