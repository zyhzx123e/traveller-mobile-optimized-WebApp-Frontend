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
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Web.Script.Serialization;
using System.Xml.Linq;

public partial class Master_pages_main : System.Web.UI.MasterPage
{

    public string admin_id_get;
    public string admin_pwd_get;
    public string admin_loggedin_get;

    public Literal user_li { get; set; }
    public Literal weather_li { get; set; }

    public Literal currency_li { get; set; }



    public string place_user { get; set; }
    public string application { get; set; }
    public string users_online { get; set; }

    public string bg_admin() { return "bg_admin.jpg"; }

    public string bg()
    {

        return "bg.jpg";
        /*
         The Official Forums for Microsoft ASP.NET. . Set background-image of body in code-behind file | The ASP.NET Forums. [ONLINE] Available at: https://forums.asp.net/t/1878343.aspx?Set+background+image+of+body+in+code+behind+file. 
         * [Accessed 09 September 2017].
         */
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin_id"] != null)
        {
            userMenu_btn.Text = Session["admin_id"].ToString();
        }
        else if (Session["user_name"] != null)
        {
            userMenu_btn.Text = Session["user_name"].ToString();
        }
        else
        {
            userMenu_btn.Text = "Visitor";
        }

        if (!IsPostBack)
        {
            if(Session["admin_id"]!=null){
                userMenu_btn.Text = Session["admin_id"].ToString();
                lbl_useremail.Text = "traveller.borneo.tour@gmail.com";
                profile_img_btn.ImageUrl = "http://res.cloudinary.com/barterworld/image/upload/v1505692260/admin_jqi4jo.png";
                nav_login.Visible = false;
                btn_viewCustomer.Visible = true;
                btn_manageUser.Visible = true;
                nav_my_items.Visible = false;
                nav_pwdchange.Visible = false;
                nav_admin_profile.Visible = true;

                nav_manage_user.Visible = true;
                nav_manage_post.Visible = true;

            }
            else if (Session["user_name"] != null)
            {
                userMenu_btn.Text = Session["user_name"].ToString();
                lbl_useremail.Text = Session["user_email"].ToString();
                profile_img_btn.ImageUrl = Session["user_img"].ToString();
                nav_admin_profile.Visible = false;
                nav_pwdchange.Visible = true;

                nav_login.Visible = false;
                nav_my_items.Visible = true;

                nav_manage_user.Visible = false;
                nav_manage_post.Visible = false;
            }
            else {
                userMenu_btn.Text = "Visitor";
                profile_img_btn.ImageUrl = "~/images/SabahLeaf.ico";
                nav_admin_profile.Visible = false;
                lbl_useremail.Visible = false;
                nav_pwdchange.Visible = false;
                nav_signout.Visible = false;
                nav_my_items.Visible = false;
                nav_manage_user.Visible = false;
                nav_manage_post.Visible = false;
            }
        }
        else {
/*
            btn_viewCustomer.Visible = false;
            btn_manageUser.Visible = false;
            userMenu_btn.Text = "Hi Admin! You havent sign in...";
            hideDiv.Visible = false;
            Button_pwd_reset.Visible = false;*/
        }
     
 PlaceHolder_user.Visible = true;
       

        user_li = new Literal();
        application = Application["TotalApplications"].ToString();
        users_online = Application["TotalUserSessions"].ToString();

        user_li.Text = "<div style='margin:10px; color: darkblue;font-family: cursive;'><h5>Online Traveller(s) :  " + users_online + "</h5></div>";
        ////  Response.Write("Number of Applications : " + Application["TotalApplications"]+" || ");
      string place_user = user_li.Text;
        // Response.Write("Number of Users Online : " + Application["TotalUserSessions"]);


        PlaceHolder_user.Controls.AddAt(0, user_li);


        weather_li = new Literal();

        weather_li.Text = "<div style='text-align: center;margin:10px;color: darkblue;font-family: cursive;'><h6>Current North Borneo Local Temperature(&#8451;):</h6>" + getSabahKKcurrentLocalTemp() + "</div>";
         PlaceHolder_weather_succinct.Controls.Clear();
        PlaceHolder_weather_succinct.Controls.AddAt(0, weather_li);





        //PlaceHolder_currency
        currency_li = new Literal();

        currency_li.Text = "<div style='text-align: center;margin:10px;color: darkblue;font-family: cursive;'><h6>1 USD = " + getBorneoCurrency() + " MYR(Ringgit, Borneo Currency)</h6></div>";
        PlaceHolder_currency.Controls.Clear();
        PlaceHolder_currency.Controls.AddAt(0, currency_li);

    }

    public string getBorneoCurrency()
    {

        var http = (HttpWebRequest)WebRequest.Create(new Uri("" + db_connection.travellerWSlocalBaseUrl + "getBorneoCurrencyRateUSDMYR/q0w1e9r2t8y3u7i4o6p5"));
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
        string rate = xDoc.Element(ns + "string").Value.ToString();

        return rate;
    }

    protected void btn_viewServices_click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/Customer/Places.aspx");
    }
    protected void btn_viewGoods_click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/Customer/stuff.aspx");
    }

    protected void btn_manageControl_click(object sender, EventArgs e)
    {
      //  Response.Redirect("~/pages/administrator/manageFunc.aspx");
    }
    protected void btn_viewCustomer_click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/Admin/viewCustomerInfo.aspx");
    
    }
    protected void btn_manageUser_click(object sender, EventArgs e)
    {

        Response.Redirect("~/pages/Admin/manageUser.aspx");
    }

    protected void btn_resetPwd(object sender, EventArgs e) {
        Response.Redirect("~/pages/pwdChange.aspx");
    }



    /*
     
           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate>
                  <div id="refresh">  
         <asp:PlaceHolder ID="PlaceHolder_user" runat="server"></asp:PlaceHolder></div>  
                       <asp:Timer ID="Timer3" runat="server" OnTick="DisplayTimeEvent" Interval="2000" />
                    
                       </ContentTemplate>
                     </asp:UpdatePanel> 

        

          <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                 <ContentTemplate>
                  
         <asp:PlaceHolder ID="PlaceHolder_weather_succinct" runat="server"></asp:PlaceHolder> 
                      <asp:Timer ID="Timer1" runat="server" OnTick="refresh_weather_succinct" Interval="2000" />
                   
                       </ContentTemplate>
                     </asp:UpdatePanel> 
         
         */
    protected void DisplayTimeEvent(object sender, EventArgs e)
    {

        user_li = new Literal();
        application = Application["TotalApplications"].ToString();
        users_online = Application["TotalUserSessions"].ToString();
        user_li.Text = "<div style='margin:10px;color: darkblue;font-family: cursive;'><h5>Online Traveller(s):  " + users_online + "</h5></div>";
        PlaceHolder_user.Controls.Clear();
        PlaceHolder_user.Controls.AddAt(0, user_li);
    }
    protected void refresh_weather_succinct(object sender, EventArgs e) {


        //weather_li
        weather_li = new Literal();

        weather_li.Text = "<div style='margin:10px;color: darkblue;font-family: cursive;'><h6>Current North Borneo Local Temperature(&#8451;):</h6>" + getSabahKKcurrentLocalTemp ()+ "</div>";
        PlaceHolder_weather_succinct.Controls.Clear();
        PlaceHolder_weather_succinct.Controls.AddAt(0, weather_li);
    }


  

    public string getSabahKKcurrentLocalTemp() {
        string all = "";
        string tempC = "";
        string todayWeatherDesc = "";
        string todayWeatherIconUrl = "";

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
            tempC = node.Element(ns + "nowTempC").Value;
            todayWeatherDesc = node.Element(ns + "todayWeatherDesc").Value;
            todayWeatherIconUrl = node.Element(ns + "todayWeatherIconUrl").Value;


        }
        all = "<h6> " + tempC + "&#8451; | <img style='border-radius:5px;width:22px;height:22px;' src='" + todayWeatherIconUrl + "'></img> | " + todayWeatherDesc + "</h6>";

        return all ;

    }
    public string getSabahKKcurrentLocalWeatherDesc()
    {
        string todayWeatherDesc = "";

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
            todayWeatherDesc = node.Element(ns + "todayWeatherDesc").Value;

        }

        return todayWeatherDesc;

    }
    public string getSabahKKcurrentLocalWeatherIcon()
    {
        string todayWeatherIconUrl = "";

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
            todayWeatherIconUrl = node.Element(ns + "todayWeatherIconUrl").Value;

        }

        return todayWeatherIconUrl;

    }

 

   
    
}
