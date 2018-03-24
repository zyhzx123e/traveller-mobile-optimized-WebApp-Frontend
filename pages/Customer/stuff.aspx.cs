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
using System.Drawing;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using System.Diagnostics;

public partial class stuff : System.Web.UI.Page
{

    XDocument xmldoc;


    protected override void OnInit(EventArgs e)
    {/*
      * 
      Init is a good place to add dynamic controls to the page or user control 
      * If can, then those controls will have their ViewState restored automatically during postbacks 
      * 
      */
        //b4 page load

        base.OnInit(e);
        if (!IsPostBack)
        {
            Session["advance"] = "false";
            Session["q_stuff"] = "";
            BindGrid(txt_stuff_sort.Text.Trim().ToString());
       
        }

        BindGrid(txt_stuff_sort.Text.Trim().ToString());
       
       
    }


    public void update_user_profile()
    {

        //update stuff xml user profile
        List<string> user_img_list_stuff = new List<string>();
        XDocument xmldoc_stuff = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/stuff.xml"));
        foreach (XElement xe in xmldoc_stuff.Descendants("stuff"))
        {
            string each_user = xe.Element("stuff_uid").Value;
            string each_user_img_url = common.getUserImgUrlFromUsername(each_user);

            user_img_list_stuff.Add(each_user_img_url);
        }
        int i = 0;
        foreach (XElement xe in xmldoc_stuff.Descendants("stuff"))
        {  
            xe.Element("stuff_user_img").Value = user_img_list_stuff[i];

            i++;
            
            xmldoc_stuff.Save(Server.MapPath("~/pages/Customer/xml_xsl/stuff.xml"));
        }




        // emp.Element("stuff_uid").Value = txt_uid.Text;




        //update stuff_comments xml user profile
        List<string> user_img_list_stuff_comments = new List<string>();

        XDocument xmldoc_stuff_comments = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/stuff_comments.xml"));

        foreach (XElement xe in xmldoc_stuff_comments.Descendants("stuffs_comment"))
        {
            string each_user = xe.Element("stuff_comment_uid").Value;
            string each_user_img_url = common.getUserImgUrlFromUsername(each_user);

            user_img_list_stuff_comments.Add(each_user_img_url);
        }
        int c = 0;
        foreach (XElement xe in xmldoc_stuff_comments.Descendants("stuffs_comment"))
        {
           
            xe.Element("stuff_comment_user_img").Value = user_img_list_stuff_comments[c];

            c++;
          
            xmldoc_stuff_comments.Save(Server.MapPath("~/pages/Customer/xml_xsl/stuff_comments.xml"));
        }

    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid(Session["q_stuff"].ToString());
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
        Debug.WriteLine("Stuff update panel test");
        BindGrid(Session["q_stuff"].ToString());
    }

    public void BindGrid()
    {
        xmldoc = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/stuff.xml"));

        var bind = (from p in xmldoc.Descendants("stuff")
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



        DataList1.DataSource = bind;
        DataList1.DataBind();
    }

    protected void BindGrid(string str_sort)
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

        }).Where(p => p.stuff_title.ToLower().Contains(str_sort) || p.stuff_address.ToLower().Contains(str_sort) || p.stuff_uid.ToLower().Contains(str_sort) || p.stuff_time_upload.ToLower().Contains(str_sort) || p.stuff_description.ToLower().Contains(str_sort) || p.stuff_name.ToLower().Contains(str_sort)).OrderBy(p => p.stuff_time_upload);



        DataList1.DataSource = bind;
        DataList1.DataBind();

    }












    protected void btn_good_sort(object sender, EventArgs e) {

           Session["q_stuff"]= txt_stuff_sort.Text.Trim().ToString();
           BindGrid(txt_stuff_sort.Text.Trim().ToString());

      /*  txtORsearch.Visible = true;
        txtANDsearch.Visible = true;*/

    }

    protected void btn_good_sort_click(object sender, EventArgs e)
    {

        /*  Session["q_stuff"] = txt_stuff_sort.Text.Trim().ToString();
          BindGrid(txt_stuff_sort.Text.Trim().ToString());*/
        if (Session["advance"].ToString() == "false")
        {
            txtORsearch.Visible = true;
            txtANDsearch.Visible = true;
            Session["advance"] = "true";
            searchGoodBtn.Text = "Hide";
        }
        else
        {
            txtORsearch.Visible = false;
            txtANDsearch.Visible = false;
            Session["advance"] = "false";
            searchGoodBtn.Text = "Advance";
        }

      

    }



    protected void btn_searchOR_service(object sender, EventArgs e)
    {
        string str_sort = TextBoxOR1.Text.Trim().ToString();
        string str_sort1 = TextBoxOR2.Text.Trim().ToString();
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

        }).Where(p => (p.stuff_title.ToLower().Contains(str_sort) ||
        p.stuff_address.ToLower().Contains(str_sort) || 
        p.stuff_uid.ToLower().Contains(str_sort) || 
        p.stuff_time_upload.ToLower().Contains(str_sort) || 
        p.stuff_description.ToLower().Contains(str_sort) || 
        p.stuff_name.ToLower().Contains(str_sort)) /*OR*/|| /*OR*/ (p.stuff_title.ToLower().Contains(str_sort1) ||
        p.stuff_address.ToLower().Contains(str_sort1) ||
        p.stuff_uid.ToLower().Contains(str_sort1) ||
        p.stuff_time_upload.ToLower().Contains(str_sort1) ||
        p.stuff_description.ToLower().Contains(str_sort1) ||
        p.stuff_name.ToLower().Contains(str_sort1))).OrderBy(p => p.stuff_time_upload);



        DataList1.DataSource = bind;
        DataList1.DataBind();
        TextBoxOR1.Text = "";
        TextBoxOR2.Text = "";
    }


    protected void btn_searchAND_service(object sender, EventArgs e)
    {
        string str_sort = TextBoxAND1.Text.Trim().ToString();
        string str_sort1 = TextBoxAND2.Text.Trim().ToString();
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

        }).Where(p => (p.stuff_title.ToLower().Contains(str_sort) ||
        p.stuff_address.ToLower().Contains(str_sort) ||
        p.stuff_uid.ToLower().Contains(str_sort) ||
        p.stuff_time_upload.ToLower().Contains(str_sort) ||
        p.stuff_description.ToLower().Contains(str_sort) ||
        p.stuff_name.ToLower().Contains(str_sort)) /*AND*/&& /*AND*/ (p.stuff_title.ToLower().Contains(str_sort1) ||
        p.stuff_address.ToLower().Contains(str_sort1) ||
        p.stuff_uid.ToLower().Contains(str_sort1) ||
        p.stuff_time_upload.ToLower().Contains(str_sort1) ||
        p.stuff_description.ToLower().Contains(str_sort1) ||
        p.stuff_name.ToLower().Contains(str_sort1))).OrderBy(p => p.stuff_time_upload);



        DataList1.DataSource = bind;
        DataList1.DataBind();
        TextBoxAND1.Text = "";
        TextBoxAND2.Text = "";
    }








    protected void add_new_stuff_Click1(object sender, EventArgs e)
    {
        string session_service = "places";
        string session_stuff = "stuff";

        Session["visit_back_history"] = session_stuff;
    Response.Redirect("servicePost.aspx");
    }
}