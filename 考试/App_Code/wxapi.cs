using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Services;

/// <summary>
/// wxapi 的摘要说明
/// </summary>
[WebService(Namespace = "148.70.245.111/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
 [System.Web.Script.Services.ScriptService]
public class wxapi : System.Web.Services.WebService
{

    public wxapi()
    {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }
    [WebMethod]
    public void OpenID(string code)
    {
        //临时登录凭证code 获取 session_key 和 openid
        string js_code = code;
        //此处填写自己小程序的appid和secret
        string serviceAddress = "https://api.weixin.qq.com/sns/jscode2session?appid=wx7a464f73f713ef32&secret=1d753534eb3e4e793893546160a3d77d&js_code=" + js_code + "&grant_type=authorization_code";

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);
        request.Method = "GET";
        request.ContentType = "textml;charset=UTF-8";
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream myResponseStream = response.GetResponseStream();
        StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
        string jsonData = myStreamReader.ReadToEnd();
        myStreamReader.Close();
        myResponseStream.Close();

        string jsonString = jsonData;
        JObject json = JObject.Parse(jsonString);
        string openid = json["openid"].ToString();

        Context.Response.Write(GetJson(openid));
    }

    #region  把对象序列化 JSON 字符串
    /// <summary>
    /// 把对象序列化 JSON 字符串 
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <param name="obj">对象实体</param>
    /// <returns>JSON字符串</returns>
    public static string GetJson<T>(T obj)
    {
        //记住 添加引用 System.ServiceModel.Web 
        /**
         * 如果不添加上面的引用,System.Runtime.Serialization.Json; Json是出不来的哦
         * */
        DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(T));
        using (MemoryStream ms = new MemoryStream())
        {
            json.WriteObject(ms, obj);
            string szJson = Encoding.UTF8.GetString(ms.ToArray());
            return szJson;
        }
    }
    #endregion
    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

}
