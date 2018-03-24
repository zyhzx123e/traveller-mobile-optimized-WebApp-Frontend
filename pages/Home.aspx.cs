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
using System.Net.Http;

public partial class pages_Home : System.Web.UI.Page
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
        share_item_get = new List<share_item>();
        share_item_get_b4_randomize = new List<share_item>();

        XDocument doc_share_item_place = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/place.xml"));


        foreach (XElement x in doc_share_item_place.XPathSelectElements("//place"))
        {
            share_item s_n = new share_item(x.Element("place_id").Value.ToString(), x.Element("place_img").Value.ToString(),
                x.Element("place_title").Value.ToString(), x.Element("place_name").Value.ToString(),
                x.Element("place_description").Value.ToString(), x.Element("place_time_upload").Value.ToString(),
                x.Element("place_uid").Value.ToString(), x.Element("place_user_img").Value.ToString(),
                x.Element("place_longitude").Value.ToString(), x.Element("place_latitude").Value.ToString(),
                x.Element("place_address").Value.ToString(), x.Element("place_like_count").Value.ToString());

            share_item_get_b4_randomize.Add(s_n);
        }

        foreach (share_item s in share_item_get_b4_randomize)
        {
          //  Debug.WriteLine("place-" + s.place_uid);
        }
      //  Debug.WriteLine("===================================================place_retrived");



        XDocument doc_share_item_stuff = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/stuff.xml"));

        foreach (XElement x in doc_share_item_stuff.XPathSelectElements("//stuff"))
        {
            share_item s_n = new share_item(x.Element("stuff_id").Value.ToString(), x.Element("stuff_img").Value.ToString(),
                x.Element("stuff_title").Value.ToString(), x.Element("stuff_name").Value.ToString(),
                x.Element("stuff_description").Value.ToString(), x.Element("stuff_time_upload").Value.ToString(),
                x.Element("stuff_uid").Value.ToString(), x.Element("stuff_user_img").Value.ToString(),
                x.Element("stuff_longitude").Value.ToString(), x.Element("stuff_latitude").Value.ToString(),
                x.Element("stuff_address").Value.ToString(), x.Element("stuff_like_count").Value.ToString());

            share_item_get_b4_randomize.Add(s_n);
        }
         

        foreach (share_item s in share_item_get_b4_randomize)
        {//randomize the list
            share_item_get.Insert(random.Next(0, share_item_get.Count + 1), s);
        }


        item_place_id_array = new string[share_item_get.Count];
        lat_array = new string[share_item_get.Count];
        long_array = new string[share_item_get.Count];
        share_item_title_array = new string[share_item_get.Count];
        share_item_name_array = new string[share_item_get.Count];
        b_img_array = new string[share_item_get.Count];
        b_desc_array = new string[share_item_get.Count];

        for (int i = 0; i < share_item_get.Count; i++)
        {
            item_place_id_array[i]= share_item_get[i].place_id;
            lat_array[i] = share_item_get[i].place_latitude;
            long_array[i] = share_item_get[i].place_longitude;
            share_item_title_array[i] = share_item_get[i].place_title;
            share_item_name_array[i] = share_item_get[i].place_name;
            b_img_array[i] = share_item_get[i].place_img;
            b_desc_array[i] = share_item_get[i].place_description;
           
        }

        List<share_item> lst = new List<share_item>();

        for (int i = 0; i < share_item_get.Count; i++)
        {
            lst.Add(new share_item() { place_id = share_item_get[i].place_id,place_title = share_item_get[i].place_title, place_img = share_item_get[i].place_img });

        }

        myRepeater.DataSource = lst;
        myRepeater.DataBind();


    }

    protected override void OnInit(EventArgs e)
    {
        load_data();
        ///////////////////////////////////////above set the location of the map
    }

    public void google_log()
    {
        if ((Session.Contents.Count > 0) && (Session["loginWith"] != null) && (Session["loginWith"].ToString() == "google"))
        {
            Debug.WriteLine("logged google: "+ Session["loginWith"].ToString());
            try
            {
                var url = Request.Url.Query;
                if (url != "")
                {
                    string queryString = url.ToString();
                    char[] delimiterChars = { '=' };
                    string[] words = queryString.Split(delimiterChars);
                    string code = words[1];

                    if (code != null)
                    {
                        //get the access token 
                        HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://accounts.google.com/o/oauth2/token");
                        webRequest.Method = "POST";
                        //  http.ContentLength = db_connection.contentHTTPlength;
                        Parameters = "code=" + code + "&client_id=" + googleplus_client_id + "&client_secret=" + googleplus_client_sceret + "&redirect_uri=" + googleplus_redirect_url + "&grant_type=authorization_code";
                        byte[] byteArray = Encoding.UTF8.GetBytes(Parameters);
                        webRequest.ContentType = "application/x-www-form-urlencoded";
                        webRequest.ContentLength = byteArray.Length;
                        Stream postStream = webRequest.GetRequestStream();
                        // Add the post data to the web request
                        postStream.Write(byteArray, 0, byteArray.Length);
                        postStream.Close();

                        WebResponse response = webRequest.GetResponse();
                        postStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(postStream);
                        string responseFromServer = reader.ReadToEnd();

                        GooglePlusAccessToken serStatus = JsonConvert.DeserializeObject<GooglePlusAccessToken>(responseFromServer);

                        if (serStatus != null)
                        {
                            string accessToken = string.Empty;
                            accessToken = serStatus.access_token;

                            if (!string.IsNullOrEmpty(accessToken))
                            {
                                // This is where you want to add the code if login is successful.
                                getgoogleplususerdataSer(accessToken);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message, ex);
                Debug.WriteLine("google login error: " + ex.Message.ToString());

                Response.Redirect("~/pages/login.aspx");
            }
        }
    }


    private async void getgoogleplususerdataSer(string access_token)
    {
        try
        {
            HttpClient client = new HttpClient();
            var urlProfile = "https://www.googleapis.com/oauth2/v1/userinfo?access_token=" + access_token;

            client.CancelPendingRequests();
            HttpResponseMessage output = await client.GetAsync(urlProfile);

            if (output.IsSuccessStatusCode)
            {
                string outputData = await output.Content.ReadAsStringAsync();
                GoogleUserOutputData serStatus = JsonConvert.DeserializeObject<GoogleUserOutputData>(outputData);

                if (serStatus != null)
                {
                    // You will get the user information here.
                    string u_email = serStatus.email;
                    string u_name = serStatus.name;
                    string u_img = serStatus.picture;

                    Session["user_email"] = u_email;
                    Session["user_img"] = u_img;
                    Session["user_name"] = u_name;
                    Session["user_pwd"] = common.get_random_string(6);

                    if (chk_email_exist(Session["user_email"].ToString()))
                    {

                    }
                    else
                    {
                        saveGoogleAccountInfo(Session["user_name"].ToString(), Session["user_img"].ToString(), Session["user_email"].ToString(), Session["user_pwd"].ToString());
                        sendEmail(u_email, u_name, Session["user_pwd"].ToString());

                    }

                    Response.Redirect("~/pages/Home.aspx");






                }
            }
        }
        catch (Exception ex)
        {
            //catching the exception
        }
        finally {
            Response.Redirect("~/pages/Home.aspx");
        }
    }





    //=================

    public bool chk_email_exist(string u_email)
    {

        

        var http = (HttpWebRequest)WebRequest.Create(new Uri("" + db_connection.travellerWSlocalBaseUrl + "Users/getAllTravellers/q0w1e9r2t8y3u7i4o6p5"));
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
        Debug.WriteLine("=======================================================got namespace : " + ns);

        var nodelist = xDoc.Element(ns + "userReturn").Elements(ns + "uList").Elements(ns + "User");
        List<string> registered_username_list = new List<string>();
        List<string> registered_email_list = new List<string>();
        // List<string> registered_useremail_list = new List<string>();

        bool chk_user_exit = false;
        foreach (var v in nodelist)
        {
             
            registered_email_list.Add(v.Element(ns + "User_email").Value);
        }

        foreach (string email in registered_email_list)
        {
            if (u_email == email)
          
            {
                chk_user_exit = true;


            }

        }

     

        return chk_user_exit;




    }








    //===================

    protected void saveGoogleAccountInfo(string uid,string uimg,string uemail,string upwd) {


        var http = (HttpWebRequest)WebRequest.Create(new Uri("" + db_connection.travellerWSlocalBaseUrl + "Users/addNewTraveller/" + uid + "/" + uemail + "/" + upwd + "/q0w1e9r2t8y3u7i4o6p5?User_profile_img=" + uimg + ""));
        http.Accept = "text/xml";
        http.ContentType = "text/xml; charset=utf-8";
        http.Method = "POST";
        http.ContentLength = db_connection.contentHTTPlength;
        var response = http.GetResponse();

        var stream = response.GetResponseStream();
        var sr = new StreamReader(stream);
        string content = sr.ReadToEnd();

        XDocument doc = XDocument.Parse(content);

        var r = doc.Root;
        var u = doc.Root.Nodes();


        var xDoc = XDocument.Parse(content);

        var ns = xDoc.Root.Name.Namespace;
        string respond_str = xDoc.Element(ns + "strReturn").Element(ns + "str").Value.ToString();
    }

    private void sendEmail(string email_to_send, string username, string newPwd)
    {


        //ws: sendEmailToInformUserInfoChanged
                                                                                                         //informTraveller/sendEmailToInformGoogleAccount/zyh860@gmail.com/akkkk/123456/q0w1e9r2t8y3u7i4o6p5
        var http = (HttpWebRequest)WebRequest.Create(new Uri("" + db_connection.travellerWSlocalBaseUrl + "informTraveller/sendEmailToInformGoogleAccount/" + email_to_send + "/" + username + "/" + newPwd + "/q0w1e9r2t8y3u7i4o6p5"));
        http.Accept = "text/xml";
        http.ContentType = "text/xml; charset=utf-8";
        http.Method = "POST";
        http.ContentLength = db_connection.contentHTTPlength;
        var response = http.GetResponse();



        HttpWebResponse webResponse = null;
        HttpStatusCode statusCode;

        try
        {
            webResponse = (HttpWebResponse)http.GetResponse();
        }
        catch (WebException we)
        {
            webResponse = (HttpWebResponse)we.Response;
        }

        statusCode = webResponse.StatusCode;

        Debug.WriteLine("ws user info changed calling status code: " + (int)statusCode);

        if ((int)statusCode == 200)
        {

            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            string content = sr.ReadToEnd();

            XDocument doc = XDocument.Parse(content);

            var r = doc.Root;
            var u = doc.Root.Nodes();


            var xDoc = XDocument.Parse(content);

            var ns = xDoc.Root.Name.Namespace;
            string returned_msg = xDoc.Element(ns + "string").Value.ToString();

            if (returned_msg.Equals("1"))
            {
                Debug.WriteLine("Email sent to inform Google account has linked to Traveller");
            }
            else
            {

                Debug.WriteLine("Email failed to send to inform the Google accpount linked");
            }

        }
    }

                                           //1076138504561-bbjrshjle3prhiabc60ko89i90tgk4q3.apps.googleusercontent.com
    protected string googleplus_client_id = "1076138504561-bbjrshjle3prhiabc60ko89i90tgk4q3.apps.googleusercontent.com";    // google+ api Client ID
    protected string googleplus_client_sceret = "g4wx9abice-OmXKOj3O7vwpH";                                                // google+ api  Client Secret
                                                                                                                           //g4wx9abice-OmXKOj3O7vwpH    
                                                                                                                           //to change this redirect url , need to go in developer console change this path at same time
                                                                                                                           //old secret: IyKn-emPbaq5NJb3dm2L4J12
                                                                                                                           //old client id: 226940384162-kq3062rpe64s8go8bh5ifsm8e95k34ce.apps.googleusercontent.com
    protected string googleplus_redirect_url = "http://nbtravellerfront-001-site1.1tempurl.com/pages/Home.aspx";
    //  Redirect URL; Redirect URL from 
    protected string Parameters;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Debug.WriteLine("get session username:" + Session["user_name"]);
            Debug.WriteLine("get session user_img:" + Session["user_img"]);
            Debug.WriteLine("get session user_email:" + Session["user_email"]);
            Debug.WriteLine("get session user_pwd:" + Session["user_pwd"]);
            // System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('8 char:" + common.get_random_string(8) + " /n 4 char: "+common.get_random_string(4)+"');", true);
            google_log();
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
     //   Debug.WriteLine("json raw: " + content.ToString());



        JObject json_obj = JObject.Parse(news_result_json_raw);


        string status_code = (string)json_obj["status"];

        JArray items = (JArray)json_obj["articles"];
        int length_of_news = items.Count <= 3 ? items.Count : 3;

        if (length_of_news < 1)
        {
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

        for (int i = 0; i < length_of_news; i++)
        {


            string news_1st_title = (string)json_obj.SelectToken("articles[" + i + "].title");
            string news_1st_desc = (string)json_obj.SelectToken("articles[" + i + "].description");
            string news_1st_imgurl = (string)json_obj.SelectToken("articles[" + i + "].urlToImage");
            string news_1st_url = (string)json_obj.SelectToken("articles[" + i + "].url");


            news_detail_li.Text += "<div style='margin-bottom:10px; background-color:black !important;filter:alpha(opacity=60);opacity:0.8;border-radius:20px;color:white;padding:10px;' >" +
                "<p style='font-size:14px;font-family:cursive;'>" + news_1st_title + "</p>" +
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
        //http://api.worldweatheronline.com/premium/v1/weather.ashx?key=8df38818ab7e4cac90b32624181601&q=5.9804,116.0735&num_of_days=2&format=xml
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