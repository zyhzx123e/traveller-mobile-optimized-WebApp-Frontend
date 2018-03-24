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
using System.Xml.XPath;
using System.Xml.Xsl;

public partial class borneo_hot : System.Web.UI.Page
{
     
    public List<share_item> share_item_get;
    public List<share_item>  share_item_get_b4_randomize;

    public Literal weather_detail_li { get; set; }

    public Literal news_detail_li { get; set; }
    public Literal borneo_story_li { get; set; }

    public string[] item_place_id_array;
    public string[] lat_array;
    public string[] long_array;
    public string[] share_item_title_array;
    public string[] share_item_name_array;
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



    /*
     List<int> xList = new List<int>() { 1, 2, 3, 4, 5 };
List<int> deck = new List<int>();

foreach (int xInt in xList)
deck.Insert(random.Next(0, deck.Count + 1), xInt);
     */

    Random random = new Random();


    public void load_data() {

        //load the data
        XPathDocument xdoc = new XPathDocument(Server.MapPath("~/pages/xml_xsl/borneo_hot.xml"));
        //load Xslt
        XslCompiledTransform transform = new XslCompiledTransform();
        transform.Load(Server.MapPath("~/pages/xml_xsl/borneo_hot.xslt"));
        StringWriter sw = new StringWriter();
        //transform it
        transform.Transform(xdoc, null, sw);
        string result = sw.ToString();

        //remove namespace
        result = result.Replace("xmlns:asp=\"remove\"", "");
        //parse control
        Control ctrl = Page.ParseControl(result);
        ph_borneo_hot.Controls.Clear();
        ph_borneo_hot.Controls.Add(ctrl);

    }

    protected override void OnInit(EventArgs e)
    {
        load_data();
        ///////////////////////////////////////above set the location of the map
    }





    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
           // System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('8 char:" + common.get_random_string(8) + " /n 4 char: "+common.get_random_string(4)+"');", true);

            load_data();

            ///////////////////////////////////////above set the location of the map
            //getWeatherConditionInSabahKK();

            //getBorneoCurrencyRate();
        }
 
        weather_detail_li = new Literal();

        weatherObj = getSabahKKweatherObj();
        Session["today_date"] = weatherObj.todayDate;
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



        get_news_from_newsapi();

        if (Session["admin_id"] != null)
        {
            username_lbl.Text = Session["admin_id"].ToString();
            //retreive user data from session and display its name on the screen
        }
        else if (Session["user_name"] != null)
        {
            username_lbl.Text = Session["user_name"].ToString();
        
        }
        else
        {
            //non_register_user
            username_lbl.Text = "Visitor";

        }

    }

    public void populate_homepage_data(object sender, EventArgs e)
    {
        load_data();

        ///////////////////////////////////////above set the location of the map

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


    public void get_news_from_newsapi()
    {

        var http = (HttpWebRequest)WebRequest.Create(new Uri("" + db_connection.travellerWSlocalBaseUrl + "getBorneoInfo/getSabahLatestNews/q0w1e9r2t8y3u7i4o6p5"));
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



        string news_result_json_raw = xDoc.Element(ns + "string").Value.ToString();
        Debug.WriteLine("json raw: " + content.ToString());

     

        JObject json_obj = JObject.Parse(news_result_json_raw);


        string status_code = (string)json_obj["status"];

        JArray items = (JArray)json_obj["articles"];
        int length_of_news = items.Count<=3? items.Count : 3;

        if (length_of_news<1) {
            news_block_title.Visible = false;
        }
        

        string news_published_time = Session["today_date"].ToString();

        news_detail_li = new Literal();

        news_detail_li.Text = "";

        /*JSONobj implementation
         =======================
                     string json = @" {
            ""created_at"": ""Sun, 01 Jan 2012 17:05:32 +0000"",
              ""entities"": {
                ""media"": [{
                  ""type"": ""photo"",
                  ""sizes"": {
                    ""large"": {
                      ""w"": 536,
                      ""h"": 800,
                      ""resize"": ""fit""
                    }
                  }
                }]
              }
            }
            ";

            JObject o = JObject.Parse(json);
            int h = (int)o["entities"]["media"][0]["sizes"]["large"]["h"];
            int h2 = (int)o.SelectToken("entities.media[0].sizes.large.h");
         =====================================================================
         
         
         
         */

        for (int i=0;i<length_of_news;i++) {

            
            string news_1st_title = (string)json_obj.SelectToken("articles["+i+"].title");
            string news_1st_desc = (string)json_obj.SelectToken("articles["+i+"].description");
            string news_1st_imgurl = (string)json_obj.SelectToken("articles["+i+"].urlToImage");
            string news_1st_url = (string)json_obj.SelectToken("articles["+i+"].url");

          
            news_detail_li.Text += "<div style='margin-bottom:10px; background-color:black !important;filter:alpha(opacity=60);opacity:0.8;border-radius:20px;color:white;padding:10px;' >"+
                "<p style='font-size:14px;font-family:cursive;'>"+news_1st_title+"</p>"+
                "<a target='_blank' href='" + news_1st_url + "'> <img alt='" + news_1st_title + "' title='" + news_1st_title + "' src='" + news_1st_imgurl + "' style='border:2px outset white;border-radius:20px;width:100%'/></a>" +
                "<p style='margin-top:5px;font-size:12px;font-family:Calibri;'>" + news_1st_desc + "</p>" +
                "<p style='margin-left: 70%;font-size:11px;font-family:Calibri;' >" + news_published_time + "</p></div>";
           
        }
        ph_news.Controls.Clear();
        ph_news.Controls.AddAt(0, news_detail_li);

 


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