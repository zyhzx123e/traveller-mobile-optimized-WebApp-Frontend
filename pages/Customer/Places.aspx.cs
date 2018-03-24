using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using System.Data.SqlClient;
using System.Configuration;
using FireSharp.Config;
using FireSharp.EventStreaming;
using FireSharp.Exceptions;
using FireSharp.Interfaces;
using FireSharp.Response;


using Microsoft.Reporting.WebForms;
using Microsoft.Reporting.Common;
using Microsoft.Reporting;
using System.Drawing;
using System.Web.Script.Serialization;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;

public partial class pages_places : System.Web.UI.Page
{

    private static FireSharp.FirebaseClient _client = db_connection.getFirebaseClientRef();


    XDocument xmldoc;

    protected override void OnInit(EventArgs e)
    {

        base.OnInit(e);

       
        if (!IsPostBack)
        {
            //populate_items();
            Session["advance"] = "false";
            Session["q_place"] = "";
          
            BindGrid(txt_place_sort.Text.Trim().ToString());
        }

        BindGrid(txt_place_sort.Text.Trim().ToString());

       
    }


    public void update_user_profile() {

        //update place xml user profile
        List<string> user_img_list_place = new List<string>();
        XDocument xmldoc_place = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/place.xml"));
          foreach (XElement xe in xmldoc_place.Descendants("place"))
        {
           string each_user= xe.Element("place_uid").Value;
            string each_user_img_url = common.getUserImgUrlFromUsername(each_user);

            user_img_list_place.Add(each_user_img_url);
        }
        int i = 0;
        foreach (XElement xeadd in xmldoc_place.Descendants("place"))
        {
           
            Debug.WriteLine("list url img : "+ user_img_list_place[i].ToString());
            xeadd.Element("place_user_img").Value = user_img_list_place[i].ToString();

            i++;
          //xmldoc_place.Root.Add(xeadd);
            xmldoc_place.Save(Server.MapPath("~/pages/Customer/xml_xsl/place.xml"));
        }




        // emp.Element("place_uid").Value = txt_uid.Text;




        //update place_comments xml user profile
        List<string> user_img_list_place_comments = new List<string>();

        XDocument xmldoc_place_comments = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/place_comments.xml"));
      
        foreach (XElement xe in xmldoc_place_comments.Descendants("places_comment"))
        {
            string each_user = xe.Element("place_comment_uid").Value;
            string each_user_img_url = common.getUserImgUrlFromUsername(each_user);

            user_img_list_place_comments.Add(each_user_img_url);
        }
        int c = 0;
        foreach (XElement xe in xmldoc_place_comments.Descendants("places_comment"))
        {
            
            xe.Element("place_comment_user_img").Value = user_img_list_place_comments[c];

            c++;
            //xmldoc_place_comments.Root.Add(xe);
            xmldoc_place_comments.Save(Server.MapPath("~/pages/Customer/xml_xsl/place_comments.xml"));
        }

    }

    protected void Page_Load(object sender, EventArgs e)
     {
         // string QueryString2 = Request.QueryString["QueryString1"].ToString();
         if (!IsPostBack)
         {



           // Debug.WriteLine("get user eminem9379 image:"+common.getUserImgUrlFromUsername("eminem9379"));
            BindGrid(Session["q_place"].ToString());
            update_user_profile();
        }

        if (Request.Browser.IsMobileDevice)
        {
            DataList1.RepeatColumns = 2;
        }
        else
        {
            DataList1.RepeatColumns = 4;
        }

      
    }

    

    protected void BindGrid(object sender, EventArgs e)
    {
        Debug.WriteLine("Place update panel test "+ Session["q_place"].ToString() + "");
         BindGrid(Session["q_place"].ToString());    
    }


   public void search_txt_changed(object o,EventArgs e)
    {

        Session["q_place"] = txt_place_sort.Text.Trim().ToString();

        BindGrid(Session["q_place"].ToString());

    }

    public void BindGrid() {
        xmldoc = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/place.xml"));

        var bind = (from p in xmldoc.Descendants("place")
                    orderby (string)p.Element("place_time_upload") descending
                    select new
                    {
                        Place_id = (string)p.Element("place_id"),
                        Place_img = (string)p.Element("place_img"),
                        Place_title = (string)p.Element("place_title"),
                        Place_name = (string)p.Element("place_name"),
                        Place_description = (string)p.Element("place_description"),
                        Place_time_upload = (string)p.Element("place_time_upload"),
                        Place_uid = (string)p.Element("place_uid"),
                        Place_user_img = (string)p.Element("place_user_img"),
                        Place_longitude = (string)p.Element("place_longitude"),
                        Place_latitude = (string)p.Element("place_latitude"),
                        Place_address = (string)p.Element("place_address"),
                        Place_like_count = (string)p.Element("place_like_count")
                    });



        DataList1.DataSource = bind;
        DataList1.DataBind();
    }

    protected void BindGrid(string str_sort)
    {
        str_sort = Session["q_place"].ToString().ToLower();
        xmldoc = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/place.xml"));

        var bind = xmldoc.Descendants("place").Select(p => new
        {
            Place_id = (string)p.Element("place_id"),
            Place_img = (string)p.Element("place_img"),
            Place_title = (string)p.Element("place_title"),
            Place_name = (string)p.Element("place_name"),
            Place_description = (string)p.Element("place_description"),
            Place_time_upload = (string)p.Element("place_time_upload"),
            Place_uid = (string)p.Element("place_uid"),
            Place_user_img = (string)p.Element("place_user_img"),
            Place_longitude = (string)p.Element("place_longitude"),
            Place_latitude = (string)p.Element("place_latitude"),
            Place_address = (string)p.Element("place_address"),
            Place_like_count = (string)p.Element("place_like_count")

        }).Where(p => p.Place_title.ToLower().Contains(str_sort) || p.Place_address.ToLower().Contains(str_sort) || p.Place_uid.ToLower().Contains(str_sort) || p.Place_time_upload.ToLower().Contains(str_sort) || p.Place_description.ToLower().Contains(str_sort) || p.Place_name.ToLower().Contains(str_sort)).OrderBy(p => p.Place_time_upload);



        DataList1.DataSource = bind;
        DataList1.DataBind();

    }

    protected void btn_search_service(object sender , EventArgs e){

        /*
        Session["q_place"] = txt_place_sort.Text.Trim().ToString();
        BindGrid(txt_place_sort.Text.Trim().ToString());*/

        if (Session["advance"].ToString() == "false")
        {
            txtORsearch.Visible = true;
            txtANDsearch.Visible = true;
            Session["advance"]= "true";
            searchServiceBtn.Text = "Hide";
        }
        else {
            txtORsearch.Visible = false;
            txtANDsearch.Visible = false;
            Session["advance"] = "false";
            searchServiceBtn.Text = "Advance";
        }
       


    }


    protected void btn_searchOR_service(object sender, EventArgs e)
    {
        string str_sort = TextBoxOR1.Text.Trim().ToString();
        string str_sort1 = TextBoxOR2.Text.Trim().ToString();
        xmldoc = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/place.xml"));

        var bind = xmldoc.Descendants("place").Select(p => new
        {
            Place_id = (string)p.Element("place_id"),
            Place_img = (string)p.Element("place_img"),
            Place_title = (string)p.Element("place_title"),
            Place_name = (string)p.Element("place_name"),
            Place_description = (string)p.Element("place_description"),
            Place_time_upload = (string)p.Element("place_time_upload"),
            Place_uid = (string)p.Element("place_uid"),
            Place_user_img = (string)p.Element("place_user_img"),
            Place_longitude = (string)p.Element("place_longitude"),
            Place_latitude = (string)p.Element("place_latitude"),
            Place_address = (string)p.Element("place_address"),
            Place_like_count = (string)p.Element("place_like_count")

        }).Where(p =>  (p.Place_title.ToLower().Contains(str_sort) || 
        p.Place_address.ToLower().Contains(str_sort) || 
        p.Place_uid.ToLower().Contains(str_sort) || 
        p.Place_time_upload.ToLower().Contains(str_sort) || 
        p.Place_description.ToLower().Contains(str_sort) || 
        p.Place_name.ToLower().Contains(str_sort))       /*OR*/ ||  /*OR*/ (p.Place_title.ToLower().Contains(str_sort1) ||
        p.Place_address.ToLower().Contains(str_sort1) ||
        p.Place_uid.ToLower().Contains(str_sort1) ||
        p.Place_time_upload.ToLower().Contains(str_sort1) ||
        p.Place_description.ToLower().Contains(str_sort1) ||
        p.Place_name.ToLower().Contains(str_sort1))).OrderBy(p => p.Place_time_upload);
        
        DataList1.DataSource = bind;
        DataList1.DataBind();

        TextBoxOR1.Text = "";
        TextBoxOR2.Text = "";
    }


       protected void btn_searchAND_service(object sender, EventArgs e)
    {
        string str_sort = TextBoxAND1.Text.Trim().ToString();
        string str_sort1 = TextBoxAND2.Text.Trim().ToString();
        xmldoc = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/place.xml"));

        var bind = xmldoc.Descendants("place").Select(p => new
        {
            Place_id = (string)p.Element("place_id"),
            Place_img = (string)p.Element("place_img"),
            Place_title = (string)p.Element("place_title"),
            Place_name = (string)p.Element("place_name"),
            Place_description = (string)p.Element("place_description"),
            Place_time_upload = (string)p.Element("place_time_upload"),
            Place_uid = (string)p.Element("place_uid"),
            Place_user_img = (string)p.Element("place_user_img"),
            Place_longitude = (string)p.Element("place_longitude"),
            Place_latitude = (string)p.Element("place_latitude"),
            Place_address = (string)p.Element("place_address"),
            Place_like_count = (string)p.Element("place_like_count")

        }).Where(p => (p.Place_title.ToLower().Contains(str_sort) ||
        p.Place_address.ToLower().Contains(str_sort) ||
        p.Place_uid.ToLower().Contains(str_sort) ||
        p.Place_time_upload.ToLower().Contains(str_sort) ||
        p.Place_description.ToLower().Contains(str_sort) ||
        p.Place_name.ToLower().Contains(str_sort))       /*AND*/ &&  /*AND*/ (p.Place_title.ToLower().Contains(str_sort1) ||
        p.Place_address.ToLower().Contains(str_sort1) ||
        p.Place_uid.ToLower().Contains(str_sort1) ||
        p.Place_time_upload.ToLower().Contains(str_sort1) ||
        p.Place_description.ToLower().Contains(str_sort1) ||
        p.Place_name.ToLower().Contains(str_sort1))).OrderBy(p => p.Place_time_upload);

        DataList1.DataSource = bind;
        DataList1.DataBind();
        TextBoxAND1.Text = "";
        TextBoxAND2.Text = "";
    }




    public string RemoveNameSubstring(string name)
    {
        int index = name.IndexOf("/");
        string uniqueKey = (index < 0) ? name : name.Remove(index, "/".Length);
        return uniqueKey;


    }
     
    public void postxml() {

        string name = "david";
        string email = "david@gmail.com";
        string pwd = "123456";

        try
        {
            var http = (HttpWebRequest)WebRequest.Create(new Uri("http://webservicebarter-001-site1.1tempurl.com/Webservice.asmx/insertUser_xml?User_name=" + name + "&User_email=" + email + "&User_pwd=" + pwd + ""));
            http.Accept = "text/xml";
            http.ContentType = "text/xml; charset=utf-8";
            http.Method = "GET";
            var response = http.GetResponse();

            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            string content = sr.ReadToEnd();


            var xDoc = XDocument.Parse(content);
            var ns = xDoc.Root.Name.Namespace;

            Debug.WriteLine(xDoc.Element(ns+"string").Value + "   RESPONDED--");

        }catch(Exception e){
        }


    }

    public void printxml() {


 

       // User u = new User();

        var http = (HttpWebRequest)WebRequest.Create(new Uri("http://webservicebarter-001-site1.1tempurl.com/Webservice.asmx/getAllUsers_xml"));
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
        var nodelist = xDoc.Element(ns + "ArrayOfUser").Elements(ns + "User");

        foreach (var node in nodelist)
        {
            Debug.WriteLine(node.Element(ns + "User_name").Value+" ===999999999999999");
        }
 
        //Debug.WriteLine(ulist.Count+" ============");
       
      


       

    }




    public List<User> getUsers()
    {
        List<User> user_get = new List<User>();


        var http = (HttpWebRequest)WebRequest.Create(new Uri("http://webservicebarter-001-site1.1tempurl.com/Webservice.asmx/getAllUsers_json"));
        http.Accept = "application/json";
        http.ContentType = "application/json";
        http.Method = "GET";

        var response = http.GetResponse();

        var stream = response.GetResponseStream();
        var sr = new StreamReader(stream);
        var content = sr.ReadToEnd();

        Debug.WriteLine(content);

        dynamic result = JsonConvert.DeserializeObject<dynamic>(content);

        foreach (JProperty x in (JToken)result)
        {
           // Debug.WriteLine( x.Value.ToString());
              Console.WriteLine("{0}:{1}", x.Name, x.Value.ToString());            // it will print the id:{...content...}
            User st = JsonConvert.DeserializeObject<User>(x.Value.ToString());

            Debug.WriteLine(st.User_email+"&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&++++");
           
            user_get.Add(st);
            
        }


        user_get.Reverse();
     


        return user_get;
    
    }



     
     


    

    
    protected void add_new_service_Click(object sender, EventArgs e)
    {

        string session_places = "places";
        string session_stuff= "stuff";

        Session["visit_back_history"] = session_places;
        Response.Redirect("servicePost.aspx"); 

    }
}

