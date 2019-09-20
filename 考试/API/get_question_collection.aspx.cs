using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class API_get_question_collection : System.Web.UI.Page
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
        string details_id = Request.QueryString["details_id"];
        string type = Request.QueryString["type"];
        string error_answer = Request.QueryString["error_answer"]; 
        if (type == "收藏"||type=="错题")
        {
            string str = "select * from question_collection where uid='" + uid + "'and details_id='" + details_id + "'";
            DataTable dt = db.SelectDate(str);
            if (dt.Rows.Count > 0)
            {
                string result1 = string.Empty;
                result1 = "该题您已收藏/该题已成为错题！";
                Response.Write(result1);
                Response.ContentType = "application/json";
                Response.Charset = "UTF-8";
                Response.End();

            }
            else
            {
                if (uid != "" && details_id != "" && type != "")
                {
                    string add_str = "insert into question_collection(uid,details_id,type,error_answer,datetime) values('" + uid + "','" + details_id + "','" + type + "','" + error_answer + "','" + d + "')";
                    int count = db.ChangeDate(add_str);
                    if (count > 0)
                    {
                        string result = "插入成功收藏/错题成功";
                        Response.Write(result);
                        Response.ContentType = "application/json";
                        Response.Charset = "UTF-8";
                        Response.End();
                    }
                }
                else
                {
                    string result = "插入成功收藏/错题失败";
                    Response.Write(result);
                    Response.ContentType = "application/json";
                    Response.Charset = "UTF-8";
                    Response.End();
                }
            }
        }
       else if (type == "取消收藏"||type=="删除错题")
        {
            //要取消就需要执行删除操作
            string add_str = "delete  from question_collection where uid = '"+uid+ "' and details_id= '"+ details_id + "'";
            int count = db.ChangeDate(add_str);
            if (count > 0)
            {
                string result = "取消收藏成功/删除错题";
                Response.Write(result);
                Response.ContentType = "application/json";
                Response.Charset = "UTF-8";
                Response.End();
            }
        }
        
    }
    
}