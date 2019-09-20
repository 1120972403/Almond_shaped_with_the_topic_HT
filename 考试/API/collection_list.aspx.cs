using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Data;
public partial class API_store_list : System.Web.UI.Page
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
        string uid = Request.QueryString["uid"];
        string type = Request.QueryString["type"];
        //表的连接查询，通过question_collection表记录的信息 查询 question_bank_details
        string str = "select question_bank_details.*,question_collection.* from question_bank_details,question_collection where question_collection.details_id=question_bank_details.details_id and question_collection.uid='" + uid+ "' and question_collection.type='" + type+"'";
        DataTable dt = db.SelectDate(str);
        string result = string.Empty;
        result = JsonConvert.SerializeObject(dt, new DataTableConverter());
        Response.Write(result);
        Response.ContentType = "application/json";
        Response.Charset = "UTF-8";
        Response.End();
    }
}