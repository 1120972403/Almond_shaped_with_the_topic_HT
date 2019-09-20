using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Data;

public partial class API_chapter_list : System.Web.UI.Page
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
        DataTable dt = db.SelectDate("select  * from question_chapter");
        string result = string.Empty;
        result = JsonConvert.SerializeObject(dt, new DataTableConverter());
        Response.Write(result);
        Response.ContentType = "application/json";
        Response.Charset = "UTF-8";
        Response.End();
    }
}