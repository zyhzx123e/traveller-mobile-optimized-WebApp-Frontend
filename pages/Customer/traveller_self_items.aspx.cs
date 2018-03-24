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

public partial class traveller_self_items : System.Web.UI.Page
{

    private static FireSharp.FirebaseClient _client = db_connection.getFirebaseClientRef();


    XDocument xmldoc;

    protected override void OnInit(EventArgs e)
    {

        base.OnInit(e);

        if (Session["user_name"] == null) {
            Response.Redirect("~/pages/login.aspx");
        }
     
        if (!IsPostBack)
        {
            //populate_items();

            Session["q_place"] = "";
            Session["q_stuff"] = "";

          //  BindGrid(txt_place_sort.Text.Trim().ToString());
            //BindGrid2(txt_place_sort_stuff.Text.Trim().ToString());

        }

        //BindGrid(txt_place_sort.Text.Trim().ToString());
        //BindGrid2(txt_place_sort_stuff.Text.Trim().ToString());


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

            if (Session["user_name"]==null && Session["admin_id"]==null) {
                Session["saved_redirect_page_after_login"] = "~/pages/Customer/traveller_self_items.aspx";

                Response.Redirect("~/pages/login.aspx");
            }

           // Debug.WriteLine("get user eminem9379 image:"+common.getUserImgUrlFromUsername("eminem9379"));
            BindGrid(Session["q_place"].ToString());
            BindGrid2(Session["q_stuff"].ToString());
            update_user_profile();

            if (DataList1.Items.Count < 1)
            {
                place_lbl.ForeColor = Color.OrangeRed;
                place_lbl.Text = "Sorry, You have not yet post any places yet...";

            }
            if (DataList2.Items.Count < 1)
            {
                stuff_lbl.ForeColor = Color.OrangeRed;
                stuff_lbl.Text = "Sorry, You have not yet post any stuffs yet...";
            }
        }

        if (Request.Browser.IsMobileDevice)
        {
            DataList1.RepeatColumns = 2;
            DataList2.RepeatColumns = 2;
        }
        else
        {
            DataList1.RepeatColumns = 4;
            DataList2.RepeatColumns = 4;
        }

      
    }


    protected void BindGrid2(object sender, EventArgs e) {
        Debug.WriteLine("stuff update panel test " + Session["q_stuff"].ToString() + "");
        BindGrid(Session["q_stuff"].ToString());
        if (DataList1.Items.Count==0) {
            place_lbl.ForeColor = Color.Orange;
            place_lbl.Text = "Sorry, You have not yet post any places yet...";
          
        }
    }
    protected void BindGrid(object sender, EventArgs e)
    {
        Debug.WriteLine("Place update panel test "+ Session["q_place"].ToString() + "");
         BindGrid(Session["q_place"].ToString());
        if (DataList2.Items.Count == 0)
        {
            stuff_lbl.ForeColor = Color.Orange;
            stuff_lbl.Text = "Sorry, You have not yet post any stuffs yet...";
        }
    }


    public void search_txt_changed_stuff(object o, EventArgs e)
    {

        Session["q_stuff"] = txt_place_sort_stuff.Text.Trim().ToString();

        BindGrid2(Session["q_stuff"].ToString());

    }

     
    public void search_txt_changed(object o,EventArgs e)
    {

        Session["q_place"] = txt_place_sort.Text.Trim().ToString();

        BindGrid(Session["q_place"].ToString());

    }



    public void BindGrid2()
    {
       XDocument xmldoc = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/stuff.xml"));

        var bind = (from p in xmldoc.Descendants("stuff")
                    where p.Element("stuff_uid").Value == Session["user_name"].ToString()
                    orderby (string)p.Element("stuff_time_upload") descending
                    select new
                    {
                        stuff_id = (string)p.Element("stuff_id"),
                        stuff_img = (string)p.Element("stuff_img"),
                        stuff_title = (string)p.Element("stuff_title"),
                        stuff_name = (string)p.Element("stuff_name"),
                        stuff_description = (string)p.Element("stuff_description"),
                        stuff_time_upload = (string)p.Element("stuff_time_upload"),
                        stuff_uid = (string)p.Element("stuff_uid"),
                        stuff_user_img = (string)p.Element("stuff_user_img"),
                        stuff_longitude = (string)p.Element("stuff_longitude"),
                        stuff_latitude = (string)p.Element("stuff_latitude"),
                        stuff_address = (string)p.Element("stuff_address"),
                        stuff_like_count = (string)p.Element("stuff_like_count")
                    });



        DataList2.DataSource = bind;
        DataList2.DataBind();
    }

    public void BindGrid() {
        xmldoc = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/place.xml"));

        var bind = (from p in xmldoc.Descendants("place")
                    where p.Element("place_uid").Value == Session["user_name"].ToString()
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

        }).Where(p => p.Place_uid.Equals(Session["user_name"].ToString()) && (p.Place_title.ToLower().Contains(str_sort) || p.Place_address.ToLower().Contains(str_sort) || p.Place_uid.ToLower().Contains(str_sort) || p.Place_time_upload.ToLower().Contains(str_sort) || p.Place_description.ToLower().Contains(str_sort) || p.Place_name.ToLower().Contains(str_sort) )).OrderBy(p => p.Place_time_upload);

        
        DataList1.DataSource = bind;
        DataList1.DataBind();

    }

    protected void BindGrid2(string str_sort)
    {
        str_sort = Session["q_stuff"].ToString().ToLower();
        xmldoc = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/stuff.xml"));

        var bind = xmldoc.Descendants("stuff").Select(p => new
        {
            stuff_id = (string)p.Element("stuff_id"),
            stuff_img = (string)p.Element("stuff_img"),
            stuff_title = (string)p.Element("stuff_title"),
            stuff_name = (string)p.Element("stuff_name"),
            stuff_description = (string)p.Element("stuff_description"),
            stuff_time_upload = (string)p.Element("stuff_time_upload"),
            stuff_uid = (string)p.Element("stuff_uid"),
            stuff_user_img = (string)p.Element("stuff_user_img"),
            stuff_longitude = (string)p.Element("stuff_longitude"),
            stuff_latitude = (string)p.Element("stuff_latitude"),
            stuff_address = (string)p.Element("stuff_address"),
            stuff_like_count = (string)p.Element("stuff_like_count")

        }).Where(p => p.stuff_uid.Equals(Session["user_name"].ToString()) && (p.stuff_title.ToLower().Contains(str_sort) || p.stuff_address.ToLower().Contains(str_sort) || p.stuff_uid.ToLower().Contains(str_sort) || p.stuff_time_upload.ToLower().Contains(str_sort) || p.stuff_description.ToLower().Contains(str_sort) || p.stuff_name.ToLower().Contains(str_sort))).OrderBy(p => p.stuff_time_upload);


        DataList2.DataSource = bind;
        DataList2.DataBind();

    }


    protected void btn_search_stuff(object o,EventArgs e) {
        Session["q_stuff"] = txt_place_sort_stuff.Text.Trim().ToString();
        BindGrid2(txt_place_sort_stuff.Text.Trim().ToString());
    }

    protected void btn_search_service(object sender , EventArgs e){


        Session["q_place"] = txt_place_sort.Text.Trim().ToString();
        BindGrid(txt_place_sort.Text.Trim().ToString());
       
    }

     

     
    public string RemoveNameSubstring(string name)
    {
        int index = name.IndexOf("/");
        string uniqueKey = (index < 0) ? name : name.Remove(index, "/".Length);
        return uniqueKey;


    }
      

     

    

    
    protected void add_new_service_Click(object sender, EventArgs e)
    {

        string session_places = "places";
        string session_stuff= "stuff";

        Session["visit_back_history"] = session_places;
        Response.Redirect("servicePost.aspx"); 

    }
}

