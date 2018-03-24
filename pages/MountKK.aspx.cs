using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using System.Data.SqlClient;
using System.Configuration;


using Microsoft.Reporting.WebForms;
using Microsoft.Reporting.Common;
using Microsoft.Reporting;
using System.Diagnostics;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using System.Text;
using System.Xml.Linq;
using System.Xml.Xsl;
using System.Xml.XPath;

public partial class pages_MountKK : System.Web.UI.Page
{

    
    public Literal weather_detail_li { get; set; }
    public Literal borneo_story_li { get; set; }

    public Literal main_sec_li { get; set; }

    public string[] lat_array;
    public string[] long_array;
    public string[] barter_name_array;
    public string[] b_img_array;
    public string[] b_desc_array;
    public JavaScriptSerializer javaSerial = new JavaScriptSerializer();

    //weather https://developer.worldweatheronline.com/my/ api:
    //d1e05d78c9394a0c8a012331171711
    //jasonescobargaviria@gmail.com
    //sabah kk weather api:
    //http://api.worldweatheronline.com/premium/v1/weather.ashx?key=d1e05d78c9394a0c8a012331171711&q=5.9804,116.0735&num_of_days=2&format=xml
    //



    /*
     * 
     * <![CDATA[ Partly cloudy ]]>
     * 
        public static void Main()
   {
      String s = "<![CDATA[ Partly cloudy ]]>";
      Console.WriteLine("The initial string: '{0}'", s);
      s = s.Replace("<![CDATA[ ", "").Replace(" ]]>", "");
      Console.WriteLine("The final string: '{0}'", s);
   }
}
// The example displays the following output:
//       The initial string: '<![CDATA[ Partly cloudy ]]>'
//       The final string: 'Partly cloudy'
     
     */


    protected override void OnInit(EventArgs e)
    {
        bind_xsl_xml_data();


        ///////////////////////////////////////above set the location of the map
    }



    public void bind_xsl_xml_data() {
        main_sec_li = new Literal();
     

        //load the data
        XPathDocument xdoc = new XPathDocument(Server.MapPath("~/pages/xml_xsl/mountKK.xml"));
        //load Xslt
        XslCompiledTransform transform = new XslCompiledTransform();
        transform.Load(Server.MapPath("~/pages/xml_xsl/mountKK.xslt"));
        StringWriter sw = new StringWriter();
        //transform it
        transform.Transform(xdoc, null, sw);
        string result = sw.ToString();

        //remove namespace
        result = result.Replace("xmlns:asp=\"remove\"", "");
        //parse control
        Control ctrl = Page.ParseControl(result);
        ph_main_sec.Controls.Clear();
        ph_main_sec.Controls.Add(ctrl);
    }


    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            bind_xsl_xml_data();

            ///////////////////////////////////////above set the location of the map
            //getWeatherConditionInSabahKK();


        }
        bind_xsl_xml_data();

        Debug.WriteLine("home-Cookies id:" + Request.Cookies["id"]);
        Debug.WriteLine("home-Cookies pwd:" + Request.Cookies["pwd"]);
        Debug.WriteLine("home-Cookies loggedin:" + Request.Cookies["loggedin"]);

        Debug.WriteLine("home-Session id:" + Session["id"]);
        Debug.WriteLine("home-Session pwd:" + Session["pwd"]);
        Debug.WriteLine("home-Session loggedin:" + Session["loggedin"]);

        weather_detail_li = new Literal();

        weatherObj = getSabahKKweatherObj();
        weather_detail_li.Text = "<div style='margin:10px;color: darkblue;font-family: cursive;'> <img style='border-radius:8px;width:48px;height:48px;' src='" + weatherObj.todayWeatherIconUrl + "'></img><h4>North Borneo (" + weatherObj.todayDate + ")Today's Temperature Range:  " + weatherObj.todayMinTempC + "&#8451; ~ " + weatherObj.todayMaxTempC + "&#8451; " + weatherObj.todayWeatherDesc + "</h4>" +
             "<h5>North Borneo Today(" + weatherObj.todayDate + ")'s Sunrise Time : " + weatherObj.todaySunRiseTime + " | Sunset Time : " + weatherObj.todaySunSetTime + "</h5>" +
             "<h5>North Borneo Islands Area Today(" + weatherObj.todayDate + ")'s Humidity : " + weatherObj.todayHumidity + "</h5><hr/>" +
             "<h4>North Borneo Islands Area Weather Forcast</h4>" +
             "<h5>North Borneo Tomorrow(" + weatherObj.tmrDate + ")'s Temperature Range : " + weatherObj.tmrMinTempC + "&#8451; ~ " + weatherObj.tmrMaxTempC + "&#8451; </h5>" +
             "<h5>North Borneo Tomorrow(" + weatherObj.tmrDate + ")'s Sunrise Time : " + weatherObj.tmrSunRiseTime + " | Sunset Time : " + weatherObj.tmrSunSetTime + "</h5></div>";
        PlaceHolder_weather_detail.Controls.Clear();
        PlaceHolder_weather_detail.Controls.AddAt(0, weather_detail_li);

        borneo_story_li = new Literal();

        borneo_story_li.Text = getBorneoStory();
        PlaceHolder_borneo_story.Controls.Clear();
        PlaceHolder_borneo_story.Controls.AddAt(0, borneo_story_li);
 

    }
      


    //-----------------------------------

    public weather weatherObj;
    protected void refresh_weather_detail(object sender, EventArgs e)
    {
        // pls uncomment it during presentation for AJAX showcase
        //now comment it bcz the onlineweather API has limitation of 500 fetch each day
        /* weather_detail_li = new Literal();

         weatherObj = getSabahKKweatherObj();
         weather_detail_li.Text = "<div style='margin:10px;color: darkblue;font-family: cursive;'> <img style='border-radius:8px;width:48px;height:48px;' src='" + weatherObj.todayWeatherIconUrl + "'></img><h4>North Borneo (" + weatherObj.todayDate + ")Today's Temperature Range:  " + weatherObj.todayMinTempC + "&#8451; ~ " + weatherObj.todayMaxTempC + "&#8451; " + weatherObj.todayWeatherDesc + "</h4>" +
              "<h5>North Borneo Today(" + weatherObj.todayDate + ")'s Sunrise Time : " + weatherObj.todaySunRiseTime + " | Sunset Time : " + weatherObj.todaySunSetTime + "</h5>" +
              "<h5>North Borneo Islands Area Today(" + weatherObj.todayDate + ")'s Humidity : " + weatherObj.todayHumidity + "</h5><hr/>" +
              "<h4>North Borneo Islands Area Weather Forcast</h4>" +
              "<h5>North Borneo Tomorrow(" + weatherObj.tmrDate + ")'s Temperature Range : " + weatherObj.tmrMinTempC + "&#8451; ~ " + weatherObj.tmrMaxTempC + "&#8451; </h5>" +
              "<h5>North Borneo Tomorrow(" + weatherObj.tmrDate + ")'s Sunrise Time : " + weatherObj.tmrSunRiseTime + " | Sunset Time : " + weatherObj.tmrSunSetTime + "</h5></div>";
         PlaceHolder_weather_detail.Controls.Clear();
         PlaceHolder_weather_detail.Controls.AddAt(0, weather_detail_li);*/
    }


    public weather getSabahKKweatherObj()
    {
        string nowTempC = "";
        string todayDate = "";
        string todayMaxTempC = "";
        string todayMinTempC = "";
        string todaySunRiseTime = "";
        string todaySunSetTime = "";
        string todayHumidity = "";
        string todayWeatherDesc = "";
        string todayWeatherIconUrl = "";
        string todayWindSpeedKmph = "";

        string tmrDate = "";
        string tmrMaxTempC = "";
        string tmrMinTempC = "";
        string tmrSunRiseTime = "";
        string tmrSunSetTime = "";

        var http = (HttpWebRequest)WebRequest.Create(new Uri("" + db_connection.travellerWSlocalBaseUrl + "getBorneoInfo/getSabahCapitalCityKKweatherCondition/q0w1e9r2t8y3u7i4o6p5"));
        http.Accept = "text/xml";
        http.ContentType = "text/xml; charset=utf-8";
        http.Method = "GET";

        var response = http.GetResponse();

        var stream = response.GetResponseStream();
        var sr = new StreamReader(stream);
        string content = sr.ReadToEnd();

        XDocument doc = XDocument.Parse(content);

        var r = doc.Root;
        var u = doc.Root.Nodes();


        var xDoc = XDocument.Parse(content);

        var ns = xDoc.Root.Name.Namespace;
        var nodelist = xDoc.Element(ns + "ArrayOfWeather").Elements(ns + "weather");

        foreach(var v in nodelist){
            nowTempC = v.Element(ns+"nowTempC").Value;
            todayDate = v.Element(ns + "todayDate").Value;
            todayMaxTempC = v.Element(ns + "todayMaxTempC").Value;
            todayMinTempC = v.Element(ns + "todayMinTempC").Value;
            todaySunRiseTime = v.Element(ns + "todaySunRiseTime").Value;
            todaySunSetTime = v.Element(ns + "todaySunSetTime").Value;
            todayHumidity = v.Element(ns + "todayHumidity").Value;
            todayWeatherDesc = v.Element(ns + "todayWeatherDesc").Value;
            todayWeatherIconUrl = v.Element(ns + "todayWeatherIconUrl").Value;
            todayWindSpeedKmph = v.Element(ns + "todayWindSpeedKmph").Value;

            tmrDate = v.Element(ns + "tmrDate").Value;
            tmrMaxTempC = v.Element(ns + "tmrMaxTempC").Value;
            tmrMinTempC = v.Element(ns + "tmrMinTempC").Value;
            tmrSunRiseTime = v.Element(ns + "tmrSunRiseTime").Value;
            tmrSunSetTime = v.Element(ns + "tmrSunSetTime").Value;
        }
      
        weatherObj = new weather(nowTempC, todayDate, todayMaxTempC, todayMinTempC, todaySunRiseTime, todaySunSetTime, todayHumidity, todayWeatherDesc, todayWeatherIconUrl, todayWindSpeedKmph, tmrDate, tmrMaxTempC, tmrMinTempC, tmrSunRiseTime, tmrSunSetTime);


        return weatherObj;

    }

    protected void btn_send_admin_txt_click(object sender, EventArgs e)
    {


       
    }

    //http://www.floatrates.com/daily/myr.xml




    public void getBorneoCurrencyRate()
    {
        string story = "";
        var http = (HttpWebRequest)WebRequest.Create(new Uri("http://www.floatrates.com/daily/myr.xml"));
        http.Accept = "text/xml";
        http.ContentType = "text/xml; charset=utf-8";
        http.Method = "GET";

        var response = http.GetResponse();

        var stream = response.GetResponseStream();
        var sr = new StreamReader(stream);
        string content = sr.ReadToEnd();

        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('" + content.ToString() + "');", true);
           

        XDocument doc = XDocument.Parse(content);

        var r = doc.Root;
        var u = doc.Root.Nodes();


        var xDoc = XDocument.Parse(content);

        var ns = xDoc.Root.Name.Namespace;
      //  story = xDoc.Element("string").Value.ToString();

       // return story;
    }

    public string getBorneoStory()
    {
        string story = "";
        var http = (HttpWebRequest)WebRequest.Create(new Uri("" + db_connection.travellerWSlocalBaseUrl + "getBorneoInfo/getBorneoStory/q0w1e9r2t8y3u7i4o6p5"));
        http.Accept = "text/xml";
        http.ContentType = "text/xml; charset=utf-8";
        http.Method = "GET";

        var response = http.GetResponse();

        var stream = response.GetResponseStream();
        var sr = new StreamReader(stream);
        string content = sr.ReadToEnd();

        XDocument doc = XDocument.Parse(content);

        var r = doc.Root;
        var u = doc.Root.Nodes();


        var xDoc = XDocument.Parse(content);

        var ns = xDoc.Root.Name.Namespace;
        story = xDoc.Element(ns + "string").Value.ToString();

        return story;
    }

    public void getWeatherConditionInSabahKK()
    {

        var http = (HttpWebRequest)WebRequest.Create(new Uri("" + db_connection.travellerWSlocalBaseUrl + "getBorneoInfo/getSabahCapitalCityKKweatherCondition/q0w1e9r2t8y3u7i4o6p5"));
        http.Accept = "text/xml";
        http.ContentType = "text/xml; charset=utf-8";
        http.Method = "GET";

        var response = http.GetResponse();

        var stream = response.GetResponseStream();
        var sr = new StreamReader(stream);
        string content = sr.ReadToEnd();

        XDocument doc = XDocument.Parse(content);

        var r = doc.Root;
        var u = doc.Root.Nodes();


        var xDoc = XDocument.Parse(content);

        var ns = xDoc.Root.Name.Namespace;
        var nodelist = xDoc.Element(ns + "ArrayOfWeather").Elements(ns + "weather");

        
        foreach (var node in nodelist)
        {

            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('"+node.Element(ns+"todayWeatherDesc").Value + "');", true);
           
        }
 




    }



    protected void serviceLinkBtn_Click(object sender, EventArgs e)
    {

    }
}