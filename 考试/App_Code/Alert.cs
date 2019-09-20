using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Alert 的摘要说明
/// </summary>
public class Alert
{
    public Alert()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public void Alertjs(string AlertStr)
    {
        string Alert = "";
        Alert = "<script language='javascript'>alert('" + AlertStr + "')</script>";

        HttpContext.Current.Response.Write(Alert);

    }
    /// <summary>
    /// 弹出提示并跳转
    /// </summary>
    /// <param name="Message">提示信息</param>
    /// <param name="RedirectUrl">跳转Url</param>
    public static void AlertAndRedirect(string Message, string RedirectUrl)
    {
        string js = "";
        js = "<script language='javascript'>alert('{0}');window.location.replace('{1}')</script>";
        HttpContext.Current.Response.Write(string.Format(js, Message, RedirectUrl));


    }

}
