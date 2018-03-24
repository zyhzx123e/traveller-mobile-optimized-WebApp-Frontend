using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


using Google.Apis.Drive.v2;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using Google.Apis.Drive.v2.Data;
using System.Collections.Generic;

using System.Data.SqlClient;
using System.Configuration;

using Firebase1.Storage;
using Microsoft.Reporting.WebForms;
using Microsoft.Reporting.Common;
using Microsoft.Reporting;
using System.Drawing;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Firebase.Storage;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

using FireSharp.Response;

using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using System.Globalization;
using System.Xml.XPath;
using System.Xml.Xsl;

public partial class pages_detail_followup : System.Web.UI.Page
{
     
    public string download_url_str;
    public string   file_full_path;
    public string imgName;
    public string itemID;

    public Literal comment_li { get; set; }
    public Literal shaire_info_li { get; set; }

    public string get_pos_lat;
   
    public string get_pos_long;
    public string get_pos_address;
    public string get_pos_TITLE;
    public string get_pos_NAME;

    public string get_pos_IMG;
    public string get_pos_DESC;

    public JavaScriptSerializer javaSerial = new JavaScriptSerializer();




    public void get_map_latlong_cum_session_set(string itemid) {

       
        get_pos_lat = "";
        get_pos_long = "";
        get_pos_address = "";
         get_pos_TITLE="";
        get_pos_NAME = "";

        get_pos_IMG ="";
     get_pos_DESC="";



        if (itemid.Contains("place"))
        {

            Session["item_type"] = "place";
            xmldoc = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/place.xml"));
            //  ./book[/author/name = 'John'] 
            XElement place_x = xmldoc.XPathSelectElement("/places/place[./place_id='" + itemid + "']");
            //   xpath slect inner text : //div[@class='h1']/text()
            // XElement place_x___ = xmldoc.Descendants("place").FirstOrDefault(p => p.Element("place_id").Value.ToString().Equals(itemid));
            if (place_x != null)
            {
                 this.Title = place_x.Element("place_name").Value.ToString();
                Session["current_item_name"] = place_x.Element("place_name").Value.ToString();

                get_pos_address = place_x.Element("place_name").Value.ToString();
                get_pos_lat = place_x.Element("place_latitude").Value.ToString();
                get_pos_long = place_x.Element("place_longitude").Value.ToString();

                get_pos_TITLE = place_x.Element("place_title").Value.ToString();
                get_pos_NAME=place_x.Element("place_name").Value.ToString();
                get_pos_IMG = place_x.Element("place_img").Value.ToString();
                get_pos_DESC = place_x.Element("place_description").Value.ToString();


                Session["cur_item_like_count"] = place_x.Element("place_like_count").Value.ToString();
              
            }


            //SET LIKE PPL

           XDocument xmldoc_likes = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/place_likes.xml"));
            //  ./book[/author/name = 'John'] 


            /*  img.tooltip = " Your Text : \n"
  img.tooltip += " Your text \n";*/
            bool value_exist_falg = false;
          
            ImageButton_like_detail.ToolTip = "Liked by: \n";
            foreach (XElement x in xmldoc_likes.XPathSelectElements("/place_likes/place_like[@place_id='" + itemid + "']/place_like_uid")) {

                if (x != null)
                {
                    Debug.WriteLine("reload_like_id:" + itemid);
                    value_exist_falg = true;
                         ImageButton_like_detail.ToolTip += x.Value.ToString() + " \n";

                }
               
          
            }
            if (!value_exist_falg) {
                Debug.WriteLine("reload_like_id 00000:" + itemid);
                ImageButton_like_detail.ToolTip += "0 people \n";
              
            }

         

        }
        else if (itemid.Contains("stuff"))
        {
            Session["item_type"] = "stuff";
            xmldoc = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/stuff.xml"));

            XElement stuff_x = xmldoc.XPathSelectElement("/stuffs/stuff[./stuff_id='" + itemid + "']");

            // XElement stuff_x__ = xmldoc.Descendants("stuff").FirstOrDefault(p => p.Element("stuff_id").Value.ToString().Equals(itemid));

            if (stuff_x != null)
            {
                 this.Title = stuff_x.Element("stuff_name").Value.ToString();
                Session["current_item_name"] = stuff_x.Element("stuff_name").Value.ToString();

                get_pos_address = stuff_x.Element("stuff_name").Value.ToString();
                get_pos_NAME = stuff_x.Element("stuff_name").Value.ToString();
                get_pos_IMG = stuff_x.Element("stuff_img").Value.ToString();
                get_pos_lat = stuff_x.Element("stuff_latitude").Value.ToString();
                get_pos_long = stuff_x.Element("stuff_longitude").Value.ToString();

                get_pos_TITLE = stuff_x.Element("stuff_title").Value.ToString();
                get_pos_NAME = stuff_x.Element("stuff_name").Value.ToString();
               
                get_pos_DESC = stuff_x.Element("stuff_description").Value.ToString();


                Session["cur_item_like_count"] = stuff_x.Element("stuff_like_count").Value.ToString();
               

            }


            //SET LIKE PPL

            XDocument xmldoc_likes = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/stuff_likes.xml"));
            //  ./book[/author/name = 'John'] 


            /*  img.tooltip = " Your Text : \n"
  img.tooltip += " Your text \n";*/
            bool value_exist_falg = false;
            ImageButton_like_detail.ToolTip = "Liked by: \n";
            foreach (XElement x in xmldoc_likes.XPathSelectElements("/stuff_likes/stuff_like[@stuff_id='" + itemid + "']/stuff_like_uid"))
            {

                if (x != null)
                {
                    value_exist_falg = true;
                    ImageButton_like_detail.ToolTip += x.Value.ToString() + " \n";

                }


            }
         

            if (!value_exist_falg) {
                ImageButton_like_detail.ToolTip += "0 people \n";
              
            }


        }

    }


    public void populate_comments_from_xsl(string item_id) {
        if (item_id.Contains("place")) {
            comment_li = new Literal();
            XsltArgumentList xslArg = new XsltArgumentList();
            xslArg.AddParam("place_id", "", item_id);
            if (Session["user_name"] != null)
            {
                xslArg.AddParam("current_uid", "", Session["user_name"].ToString());

            }

            //load the data
            XPathDocument xdoc = new XPathDocument(Server.MapPath("~/pages/Customer/xml_xsl/place_comments.xml"));
            //load Xslt
            
            XslCompiledTransform transform = new XslCompiledTransform();
            transform.Load(Server.MapPath("~/pages/Customer/xml_xsl/place_comments.xslt"));
            StringWriter sw = new StringWriter();
            //transform it
            transform.Transform(xdoc, xslArg, sw);
            string result = sw.ToString();

            //remove namespace
            result = result.Replace("xmlns:asp=\"remove\"", "");
            //parse control
            Control ctrl = Page.ParseControl(result);
            comment_ph.Controls.Clear();
            comment_ph.Controls.Add(ctrl);

        }
        else {
            comment_li = new Literal();
            XsltArgumentList xslArg = new XsltArgumentList();
            xslArg.AddParam("stuff_id", "", item_id);
            if (Session["user_name"] != null)
            {
                xslArg.AddParam("current_uid", "", Session["user_name"].ToString());

            }

            //load the data
            XPathDocument xdoc = new XPathDocument(Server.MapPath("~/pages/Customer/xml_xsl/stuff_comments.xml"));
            //load Xslt
            XslCompiledTransform transform = new XslCompiledTransform();
            transform.Load(Server.MapPath("~/pages/Customer/xml_xsl/stuff_comments.xslt"));
            StringWriter sw = new StringWriter();
            //transform it
            transform.Transform(xdoc, xslArg, sw);
            string result = sw.ToString();

            //remove namespace
            result = result.Replace("xmlns:asp=\"remove\"", "");
            //parse control
            Control ctrl = Page.ParseControl(result);
            comment_ph.Controls.Clear();
            comment_ph.Controls.Add(ctrl);
        }
       

    }



    protected void populate_comments(string item_id)
    {
        comment_li = new Literal();

        if (item_id.Contains("place"))
        {
            XDocument xmldoc_comment_place = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/place_comments.xml"));

            string html_place_comment = "";
            foreach (XElement xe in xmldoc_comment_place.XPathSelectElements("//places_comment"))//.Descendants("places_comment"))
            {

              
                string str_place_id = xe.Element("place_id").Value.ToString();
                string str_username = xe.Element("place_comment_uid").Value.ToString();
                string str_user_img = xe.Element("place_comment_user_img").Value.ToString();
                string str_comment_txt = xe.Element("place_comment_text").Value.ToString();
                string str_comment_time = xe.Element("place_comment_time").Value.ToString();
               Debug.WriteLine("all-----"+str_place_id);

                if (item_id.Equals(str_place_id))
                {
                    Debug.WriteLine("" + str_place_id);



                    if (Session["user_name"] != null)
                    {

                        Debug.WriteLine("user_name session not null: "+Session["user_name"].ToString());
                        if (Session["user_name"].ToString().Equals(str_username))
                        {
                            //current comment is commented by the current logged in traveller
                            //<div class='container_comment darker'><div class='profile_div img_right'><img src='http://res.cloudinary.com/barterworld/image/upload/v1510754153/eminem_i6j2lk.jpg' alt='Traveller' style='width:100%;'><span>username</span></div><p style='padding-top:10px;'>Hey! I'm fine. Thanks for asking!</p><span class='time-left'>2017-11-25 11:01</span></div>

                            html_place_comment = html_place_comment + "<div class='container_comment darker'><div class='profile_div img_right'><img src='" + str_user_img + "' alt='Traveller' style='width:100%;'><span>" + str_username + "</span></div><p style='padding-top:10px;'>" + str_comment_txt + "</p><span class='time-left'>" + str_comment_time + "</span></div>";

                        }
                        else
                        {
                            //current comment is commented by other travellers
                            //<div class='container_comment'><div class='profile_div '><img src='http://res.cloudinary.com/barterworld/image/upload/v1510754153/eminem_i6j2lk.jpg' alt='Traveller' style='width:100%;'><span>username</span></div><p style='padding-top:10px;'>Hello. How are you toaaaaaaaaaa asassday?</p><span class='time-right'>2017-11-25 11:00</span></div>


                            html_place_comment = html_place_comment + "<div class='container_comment'><div class='profile_div img_left'><img src='" + str_user_img + "' alt='Traveller' style='width:100%;'><span>" + str_username + "</span></div><p style='padding-top:10px;'>" + str_comment_txt + "</p><span class='time-right'>" + str_comment_time + "</span></div>";
                        }



                    }
                    else
                    {
                        Debug.WriteLine("user_name session is null");

                        html_place_comment = html_place_comment + "<div class='container_comment'><div class='profile_div img_left'><img src='" + str_user_img + "' alt='Traveller' style='width:100%;'><span>" + str_username + "</span></div><p style='padding-top:10px;'>" + str_comment_txt + "</p><span class='time-right'>" + str_comment_time + "</span></div>";

                    }

                }
                




            }
            //place comments
            //comment_li.Text = "<div class='container_comment'><div class='profile_div '><img src='http://res.cloudinary.com/barterworld/image/upload/v1510754153/eminem_i6j2lk.jpg' alt='Traveller' style='width:100%;'><span>username</span></div><p style='padding-top:10px;'>Hello. How are you toaaaaaaaaaa asassday?</p><span class='time-right'>2017-11-25 11:00</span></div><div class='container_comment darker'><div class='profile_div img_right'><img src='http://res.cloudinary.com/barterworld/image/upload/v1510754153/eminem_i6j2lk.jpg' alt='Traveller' style='width:100%;'><span>username</span></div><p style='padding-top:10px;'>Hey! I'm fine. Thanks for asking!</p><span class='time-left'>2017-11-25 11:01</span></div><div class='container_comment'><div class='profile_div'><img src='http://res.cloudinary.com/barterworld/image/upload/v1510754153/eminem_i6j2lk.jpg' alt='Traveller' style='width:100%;'><span>username</span></div><p style='padding-top:10px;'>Sweet! So, what do you wanna do today?</p><span class='time-right'>2017-11-25 11:02</span></div><div class='container_comment darker'><div class='profile_div img_right'><img src='http://res.cloudinary.com/barterworld/image/upload/v1510754153/eminem_i6j2lk.jpg' alt='Traveller' style='width:100%;'><span>username</span></div><p style='padding-top:10px;'>Nah, I dunno. Play soccer.. or learn more coding perhaps?</p><span class='time-left'>2017-11-25 11:05</span></div>";

            //<div class='container_comment'><div class='profile_div '><img src='http://res.cloudinary.com/barterworld/image/upload/v1510754153/eminem_i6j2lk.jpg' alt='Traveller' style='width:100%;'><span>username</span></div><p style='padding-top:10px;'>Hello. How are you toaaaaaaaaaa asassday?</p><span class='time-right'>2017-11-25 11:00</span></div><div class='container_comment darker'><div class='profile_div img_right'><img src='http://res.cloudinary.com/barterworld/image/upload/v1510754153/eminem_i6j2lk.jpg' alt='Traveller' style='width:100%;'><span>username</span></div><p style='padding-top:10px;'>Hey! I'm fine. Thanks for asking!</p><span class='time-left'>2017-11-25 11:01</span></div><div class='container_comment'><div class='profile_div'><img src='http://res.cloudinary.com/barterworld/image/upload/v1510754153/eminem_i6j2lk.jpg' alt='Traveller' style='width:100%;'><span>username</span></div><p style='padding-top:10px;'>Sweet! So, what do you wanna do today?</p><span class='time-right'>2017-11-25 11:02</span></div><div class='container_comment darker'><div class='profile_div img_right'><img src='http://res.cloudinary.com/barterworld/image/upload/v1510754153/eminem_i6j2lk.jpg' alt='Traveller' style='width:100%;'><span>username</span></div><p style='padding-top:10px;'>Nah, I dunno. Play soccer.. or learn more coding perhaps?</p><span class='time-left'>2017-11-25 11:05</span></div>
            comment_li.Text = html_place_comment;

        }
        else {
            //stuff comments
            XDocument xmldoc_comment_stuff = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/stuff_comments.xml"));

            string html_stuff_comment = "";
            foreach (XElement xe in xmldoc_comment_stuff.XPathSelectElements("//stuffs_comment"))//.Descendants("stuffs_comment"))
            {

                
                string str_place_id = xe.Element("stuff_id").Value.ToString();
                string str_username = xe.Element("stuff_comment_uid").Value.ToString();
                string str_user_img = xe.Element("stuff_comment_user_img").Value.ToString();
                string str_comment_txt = xe.Element("stuff_comment_text").Value.ToString();
                string str_comment_time = xe.Element("stuff_comment_time").Value.ToString();
                Debug.WriteLine("all------" + str_place_id);

                if (item_id.Equals(str_place_id))
                {
                    Debug.WriteLine("" + str_place_id);
                    if (Session["user_name"] != null)
                    {
                        if (Session["user_name"].ToString().Equals(str_username))
                        {
                            //current comment is commented by the current logged in traveller
                            //<div class='container_comment darker'><div class='profile_div img_right'><img src='http://res.cloudinary.com/barterworld/image/upload/v1510754153/eminem_i6j2lk.jpg' alt='Traveller' style='width:100%;'><span>username</span></div><p style='padding-top:10px;'>Hey! I'm fine. Thanks for asking!</p><span class='time-left'>2017-11-25 11:01</span></div>

                            html_stuff_comment = html_stuff_comment + "<div class='container_comment darker'><div class='profile_div img_right'><img src='" + str_user_img + "' alt='Traveller' style='width:100%;'><span>" + str_username + "</span></div><p style='padding-top:10px;'>" + str_comment_txt + "</p><span class='time-left'>" + str_comment_time + "</span></div>";

                        }
                        else
                        {
                            //current comment is commented by other travellers
                            //<div class='container_comment'><div class='profile_div '><img src='http://res.cloudinary.com/barterworld/image/upload/v1510754153/eminem_i6j2lk.jpg' alt='Traveller' style='width:100%;'><span>username</span></div><p style='padding-top:10px;'>Hello. How are you toaaaaaaaaaa asassday?</p><span class='time-right'>2017-11-25 11:00</span></div>


                            html_stuff_comment = html_stuff_comment + "<div class='container_comment'><div class='profile_div img_left'><img src='" + str_user_img + "' alt='Traveller' style='width:100%;'><span>" + str_username + "</span></div><p style='padding-top:10px;'>" + str_comment_txt + "</p><span class='time-right'>" + str_comment_time + "</span></div>";
                        }



                    }
                    else
                    {
                        html_stuff_comment = html_stuff_comment + "<div class='container_comment'><div class='profile_div img_left'><img src='" + str_user_img + "' alt='Traveller' style='width:100%;'><span>" + str_username + "</span></div><p style='padding-top:10px;'>" + str_comment_txt + "</p><span class='time-right'>" + str_comment_time + "</span></div>";

                    }


                }


            }
            //place comments       <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="refresh_detail_page"></asp:Timer>

            //comment_li.Text = "<div class='container_comment'><div class='profile_div '><img src='http://res.cloudinary.com/barterworld/image/upload/v1510754153/eminem_i6j2lk.jpg' alt='Traveller' style='width:100%;'><span>username</span></div><p style='padding-top:10px;'>Hello. How are you toaaaaaaaaaa asassday?</p><span class='time-right'>2017-11-25 11:00</span></div><div class='container_comment darker'><div class='profile_div img_right'><img src='http://res.cloudinary.com/barterworld/image/upload/v1510754153/eminem_i6j2lk.jpg' alt='Traveller' style='width:100%;'><span>username</span></div><p style='padding-top:10px;'>Hey! I'm fine. Thanks for asking!</p><span class='time-left'>2017-11-25 11:01</span></div><div class='container_comment'><div class='profile_div'><img src='http://res.cloudinary.com/barterworld/image/upload/v1510754153/eminem_i6j2lk.jpg' alt='Traveller' style='width:100%;'><span>username</span></div><p style='padding-top:10px;'>Sweet! So, what do you wanna do today?</p><span class='time-right'>2017-11-25 11:02</span></div><div class='container_comment darker'><div class='profile_div img_right'><img src='http://res.cloudinary.com/barterworld/image/upload/v1510754153/eminem_i6j2lk.jpg' alt='Traveller' style='width:100%;'><span>username</span></div><p style='padding-top:10px;'>Nah, I dunno. Play soccer.. or learn more coding perhaps?</p><span class='time-left'>2017-11-25 11:05</span></div>";

            //<div class='container_comment'><div class='profile_div '><img src='http://res.cloudinary.com/barterworld/image/upload/v1510754153/eminem_i6j2lk.jpg' alt='Traveller' style='width:100%;'><span>username</span></div><p style='padding-top:10px;'>Hello. How are you toaaaaaaaaaa asassday?</p><span class='time-right'>2017-11-25 11:00</span></div><div class='container_comment darker'><div class='profile_div img_right'><img src='http://res.cloudinary.com/barterworld/image/upload/v1510754153/eminem_i6j2lk.jpg' alt='Traveller' style='width:100%;'><span>username</span></div><p style='padding-top:10px;'>Hey! I'm fine. Thanks for asking!</p><span class='time-left'>2017-11-25 11:01</span></div><div class='container_comment'><div class='profile_div'><img src='http://res.cloudinary.com/barterworld/image/upload/v1510754153/eminem_i6j2lk.jpg' alt='Traveller' style='width:100%;'><span>username</span></div><p style='padding-top:10px;'>Sweet! So, what do you wanna do today?</p><span class='time-right'>2017-11-25 11:02</span></div><div class='container_comment darker'><div class='profile_div img_right'><img src='http://res.cloudinary.com/barterworld/image/upload/v1510754153/eminem_i6j2lk.jpg' alt='Traveller' style='width:100%;'><span>username</span></div><p style='padding-top:10px;'>Nah, I dunno. Play soccer.. or learn more coding perhaps?</p><span class='time-left'>2017-11-25 11:05</span></div>
            comment_li.Text = html_stuff_comment;


        }



        comment_ph.Controls.Clear();
        comment_ph.Controls.AddAt(0, comment_li);
    

    }

     

    public bool img_flg=true;
    public string query_place_id = "";

    protected override void OnInit(EventArgs e)
    {

     
    }




    protected void Page_Load(object sender, EventArgs e_)
    {
       
        if (!IsPostBack)
        {

            query_place_id = Request.QueryString["place_id"];
            Session["selected_item_id"] = query_place_id;

            if (query_place_id.Contains("place"))
            {

                Session["item_type"] = "place";
            }
            else {
                Session["item_type"] = "stuff";
            }


                // get_map_latlong_cum_session_set(query_place_id);
                //populate_detail_share_info(query_place_id);
                populate_detail_share_info_from_xsl(query_place_id);
            //  populate_comments(query_place_id);
            populate_comments_from_xsl(query_place_id);
            sync_current_item_like_status();
             
        }

        query_place_id = Request.QueryString["place_id"];
        Session["selected_item_id"] = query_place_id;


        //populate_detail_share_info(query_place_id);
        populate_detail_share_info_from_xsl(query_place_id);
        //populate_comments(query_place_id);
        populate_comments_from_xsl(query_place_id);
        sync_current_item_like_status();
        get_map_latlong_cum_session_set(query_place_id);

    }


    public void sync_current_item_like_status() {
        if (Session["user_name"] != null)
        {
            string user_name_str = Session["user_name"].ToString();
            string current_item_id = Session["selected_item_id"].ToString();
            string item_type = Session["item_type"].ToString();

            Session["current_user_liked_check"] = "";
            Debug.WriteLine("line --- 248");
            if (item_type.Equals("place"))
            {
                XDocument xmldoc_place_likes = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/place_likes.xml"));

                var x= xmldoc_place_likes.Element("place_likes").Elements("place_like")
            .Where(ele => (string)ele.Attribute("place_id")==current_item_id).Elements("place_like_uid");

              
                Debug.WriteLine("line --- 255");
                bool chk = false;
                foreach (XElement xe in x)
                {

                    Debug.WriteLine("---"+ xe.Value.ToString());
                    Debug.WriteLine("line 260 --- repeat");
                   if (xe.Value.ToString().Equals(user_name_str))
                    {
                        chk = true;
                    }
      

                }


                if (chk)
                {
                    Debug.WriteLine("line 263 --- cur liked");
                    Session["current_user_liked_check"] = "true";

                    ImageButton_like_detail.Attributes.Add("class", "class_clicked");
                    like_hint.Visible = true;
                }
                else {
                    Debug.WriteLine("line 270 --- cur didnt like");
                    Session["current_user_liked_check"] = "false";
                    ImageButton_like_detail.CssClass.Replace("class_clicked", "");
                   // ImageButton_like_detail.Attributes.Remove("class_clicked");
                  //  System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('you removed class class_clicked');", true);

                    like_hint.Visible = false;

                }


            }
            else {
                XDocument xmldoc_stuff_likes = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/stuff_likes.xml"));

                var x = xmldoc_stuff_likes.Element("stuff_likes").Elements("stuff_like")
          .Where(ele => (string)ele.Attribute("stuff_id") == current_item_id).Elements("stuff_like_uid");


                Debug.WriteLine("line 285 in stuff");

                bool chk = false;
                foreach (XElement xe in x)
                {
                    Debug.WriteLine("line 288-- in stuff loop forearch");
                    if (xe.Value.ToString().Equals(user_name_str))
                    {
                        chk = true;
                    }
                

                }

                if (chk) {
                    Debug.WriteLine("line 288-- in stuff liked");
                    Session["current_user_liked_check"] = "true";
                    like_hint.Visible = true;
                    ImageButton_like_detail.Attributes.Add("class", "class_clicked");
                } else {
                    Debug.WriteLine("line 288-- in stuff didnt like");
                    Session["current_user_liked_check"] = "false";
                    ImageButton_like_detail.CssClass.Replace("class_clicked", "");
                   // ImageButton_like_detail.Attributes.Remove("class_clicked");
                    like_hint.Visible = false;
                }



            }



        }
    }

    protected void share_like_btn_click(object o, EventArgs e)
    {

        int current_like = Int16.Parse(Session["cur_item_like_count"].ToString());
        Debug.WriteLine("-----------------------------------------------------------------------------------current likes: "+current_like);
        if (Session["user_name"] != null)
        {
            string user_name_str = Session["user_name"].ToString();


            if (Session["current_user_liked_check"].ToString().Equals("true"))
            {

                //means current traveller has liked current item
                //so this click to dislike it and -1 from like

                if (current_like==0) {
                    return;
                }
                --current_like;


                if (Session["item_type"].ToString().Equals("place"))
                {
                    XDocument x_place_doc = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/place.xml"));

                    XElement xml_place = x_place_doc.XPathSelectElement("//place[./place_id='" + Session["selected_item_id"].ToString()+ "']");
                  

                    if (xml_place != null)
                    {
                        Debug.WriteLine("========================================update place xml item found current like count: " + current_like);

                        xml_place.Element("place_like_count").Value = current_like.ToString();

                        x_place_doc.Save(Server.MapPath("~/pages/Customer/xml_xsl/place.xml"));

                    }

                    XDocument x_place_like_doc = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/place_likes.xml"));

                    //
                   // XElement stuff_x = xmldoc.XPathSelectElement("/stuffs/stuff[./stuff_id='" + itemid + "']");
                    XElement xnode_delete = x_place_like_doc.XPathSelectElement("/place_likes/place_like[@place_id='"+ Session["selected_item_id"].ToString() + "']/place_like_uid[text()='" + Session["user_name"].ToString() + "']");
                    //XElement xnode_delete_sub = xnode_delete.XPathSelectElement("/place_like_uid[text()='" + Session["user_name"].ToString() + "']");
                    // XElement x_node_remove = x_place_like_doc.Descendants("place_like").First(c => c.Attribute("place_id").Value == Session["selected_item_id"].ToString()).Descendants("place_like_uid").First(c => c.Value == Session["user_name"].ToString());

                    if (xnode_delete != null)
                    {
                        xnode_delete.Remove();
                    }
                    x_place_like_doc.Save(Server.MapPath("~/pages/Customer/xml_xsl/place_likes.xml"));

                    ImageButton_like_detail.Attributes.Remove("class_clicked");
                    like_hint.Visible = false;
                    MessageBoxShow("You have disliked "+ Session["selected_item_id"].ToString() + " : " + Session["current_item_name"].ToString() + "");


                }
                else {
                    XDocument x_stuff_like_doc = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/stuff.xml"));

                    XElement xml_stuff = x_stuff_like_doc.Descendants("stuff").FirstOrDefault(p => p.Element("stuff_id").Value == Session["selected_item_id"].ToString());
                    if (xml_stuff != null)
                    {

                        xml_stuff.Element("stuff_like_count").Value = current_like.ToString();

                        x_stuff_like_doc.Save(Server.MapPath("~/pages/Customer/xml_xsl/stuff.xml"));

                    }

                    XDocument x_stuff_like_doc_del = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/stuff_likes.xml"));


                    XElement xnode_delete = x_stuff_like_doc_del.XPathSelectElement("//stuff_like[@stuff_id='" + Session["selected_item_id"].ToString() + "']/stuff_like_uid[text()='" + Session["user_name"].ToString() + "']");
         
                    // XElement x_node_remove = x_stuff_like_doc_del.Descendants("stuff_like").First(c => c.Attribute("stuff_id").Value == Session["selected_item_id"].ToString()).Descendants("stuff_like_uid").First(c => c.Value == Session["user_name"].ToString());
                    if (xnode_delete != null)
                    {
                        xnode_delete.Remove();
                    }
                    x_stuff_like_doc_del.Save(Server.MapPath("~/pages/Customer/xml_xsl/stuff_likes.xml"));

                    ImageButton_like_detail.Attributes.Remove("class_clicked");
                    like_hint.Visible = false;
                    MessageBoxShow("You have disliked " + Session["selected_item_id"].ToString() + " : " + Session["current_item_name"].ToString() + "");

                }


             

                ImageButton_like_detail.Attributes.Remove("class_clicked");
                ImageButton_like_detail.CssClass.Replace("class_clicked", "");

            } 
            else {
                //current traveller is the first time like current item
                //so this click to like it and +1 from like
                Debug.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!like count b4 like: " + current_like.ToString());

                current_like++;

                Debug.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@like count after like: " +current_like.ToString());

                if (Session["item_type"].ToString().Equals("place"))
                {
                    XDocument x_place_doc = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/place.xml"));

                    XElement xml_place = x_place_doc.XPathSelectElement("//place[./place_id='" + Session["selected_item_id"].ToString() + "']");

                  //  XElement xml_place = x_place_doc.Descendants("place").FirstOrDefault(p => p.Element("place_id").Value == Session["selected_item_id"].ToString());
                    if (xml_place != null)
                    {

                        xml_place.Element("place_like_count").Value = current_like.ToString();

                        x_place_doc.Save(Server.MapPath("~/pages/Customer/xml_xsl/place.xml"));

                    }


                    XDocument x_place_like_doc = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/place_likes.xml"));
                    //"/places/place[./place_id='" + itemid+"']"
                    ///Employees/Employee[@id='4']
                    ///
 
                    XElement x_place_like_select = x_place_like_doc.XPathSelectElement("/place_likes/place_like[@place_id='" + Session["selected_item_id"].ToString() + "']");

                    if (x_place_like_select == null)
                    {
                        //means current item has not yet been liked before
                        XElement new_like_node = new XElement("place_like");
                        new_like_node.Add(new XAttribute("place_id", Session["selected_item_id"].ToString()));
                        new_like_node.Add(new XElement("place_like_uid", Session["user_name"].ToString()));
                        x_place_like_doc.Root.Add(new_like_node);
                        x_place_like_doc.Save(Server.MapPath("~/pages/Customer/xml_xsl/place_likes.xml"));
                    }
                    else {
                        //means current  item has already been liked b4

                        XElement x_add_like= x_place_like_doc.XPathSelectElement("/place_likes/place_like[@place_id='" + Session["selected_item_id"].ToString() + "']");

                        x_add_like.Add(new XElement("place_like_uid", Session["user_name"].ToString()));
                        x_place_like_doc.Save(Server.MapPath("~/pages/Customer/xml_xsl/place_likes.xml"));


                    }
                    like_hint.Visible = true;
                    MessageBoxShow("You have liked " + Session["selected_item_id"].ToString() + " : " + Session["current_item_name"].ToString() + "");

                }
                else
                {
                    XDocument x_stuff_doc = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/stuff.xml"));


                    XElement xml_stuff = x_stuff_doc.XPathSelectElement("//stuff[./stuff_id='" + Session["selected_item_id"].ToString() + "']");

                  //  XElement xml_stuff = x_stuff_doc.Descendants("stuff").FirstOrDefault(p => p.Element("stuff_id").Value == Session["selected_item_id"].ToString());
                    if (xml_stuff != null)
                    {

                        xml_stuff.Element("stuff_like_count").Value = current_like.ToString();

                        x_stuff_doc.Save(Server.MapPath("~/pages/Customer/xml_xsl/stuff.xml"));

                    }

                    XDocument x_stuff_like_doc = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/stuff_likes.xml"));


                    XElement x_add_like_slelect = x_stuff_like_doc.XPathSelectElement("/stuff_likes/stuff_like[@stuff_id='" + Session["selected_item_id"].ToString() + "']");

                    if (x_add_like_slelect == null)
                    {
                        //means current item has not yet been liked
                        XElement new_like_node = new XElement("stuff_like");
                        new_like_node.Add(new XAttribute("stuff_id", Session["selected_item_id"].ToString()));
                        new_like_node.Add(new XElement("stuff_like_uid", Session["user_name"].ToString()));
                        x_stuff_like_doc.Root.Add(new_like_node);
                        x_stuff_like_doc.Save(Server.MapPath("~/pages/Customer/xml_xsl/stuff_likes.xml"));
                    }
                    else {
                        //means current item has been liked b4
                        XElement x_add_like = x_stuff_like_doc.XPathSelectElement("/stuff_likes/stuff_like[@stuff_id='" + Session["selected_item_id"].ToString() + "']");


                        x_add_like.Add(new XElement("stuff_like_uid", Session["user_name"].ToString()));

                        x_stuff_like_doc.Save(Server.MapPath("~/pages/Customer/xml_xsl/stuff_likes.xml"));



                    }

                    like_hint.Visible = true;
                    MessageBoxShow("You have liked " + Session["selected_item_id"].ToString() + " : " + Session["current_item_name"].ToString() + "");

                }



                //-------------




                ImageButton_like_detail.Attributes.Add("class", "class_clicked");
            }


            Page.Response.Redirect(Page.Request.Url.ToString(), false);

        }
        else
        {

            Session["saved_redirect_page_after_login"] = "~/pages/Customer/detail_followup.aspx?place_id="+Session["selected_item_id"].ToString()+"";

            Response.Redirect("~/pages/login.aspx");

        }
    }


    public void populate_detail_share_info_from_xsl(string itemid)
    {


        if (itemid.Contains("place")) {
            shaire_info_li = new Literal();
            XsltArgumentList xslArg = new XsltArgumentList();
            xslArg.AddParam("place_id", "", itemid);

            //load the data
            XPathDocument xdoc = new XPathDocument(Server.MapPath("~/pages/Customer/xml_xsl/place.xml"));
            //load Xslt
            XslCompiledTransform transform = new XslCompiledTransform();
            transform.Load(Server.MapPath("~/pages/Customer/xml_xsl/place_single.xslt"));
            StringWriter sw = new StringWriter();
            //transform it
            transform.Transform(xdoc, xslArg, sw);
            string result = sw.ToString();

            //remove namespace
            result = result.Replace("xmlns:asp=\"remove\"", "");
            //parse control
            Control ctrl = Page.ParseControl(result);
            ph_share_info.Controls.Clear();
            ph_share_info.Controls.Add(ctrl);


        }
        else {
            shaire_info_li = new Literal();
            XsltArgumentList xslArg = new XsltArgumentList();
            xslArg.AddParam("stuff_id", "", itemid);

            //load the data
            XPathDocument xdoc = new XPathDocument(Server.MapPath("~/pages/Customer/xml_xsl/stuff.xml"));
            //load Xslt
            XslCompiledTransform transform = new XslCompiledTransform();
            transform.Load(Server.MapPath("~/pages/Customer/xml_xsl/stuff_single.xslt"));
            StringWriter sw = new StringWriter();
            //transform it
            transform.Transform(xdoc, xslArg, sw);
            string result = sw.ToString();

            //remove namespace
            result = result.Replace("xmlns:asp=\"remove\"", "");
            //parse control
            Control ctrl = Page.ParseControl(result);
            ph_share_info.Controls.Clear();
            ph_share_info.Controls.Add(ctrl);

        }


    }



        XDocument xmldoc;
    public void populate_detail_share_info(string itemid) {
       
        if (itemid.Contains("place"))
        {

            Session["item_type"] = "place";
            xmldoc = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/place.xml"));
            //  ./book[/author/name = 'John'] 
            XElement place_x =  xmldoc.XPathSelectElement("/places/place[./place_id='" + itemid+"']");
            //   xpath slect inner text : //div[@class='h1']/text()
           // XElement place_x___ = xmldoc.Descendants("place").FirstOrDefault(p => p.Element("place_id").Value.ToString().Equals(itemid));
            if (place_x!=null)
            {
                id_lbl.Text= place_x.Element("place_id").Value.ToString();
                this.Title= place_x.Element("place_name").Value.ToString();
                Session["current_item_name"]= place_x.Element("place_name").Value.ToString();
                img.ImageUrl = place_x.Element("place_img").Value.ToString();
                item_name_lbl.Text = place_x.Element("place_title").Value.ToString();
                desc_lbl.Text= place_x.Element("place_description").Value.ToString(); 
                time_lbl.Text = place_x.Element("place_time_upload").Value.ToString();
                lati_lbl.Text= place_x.Element("place_latitude").Value.ToString()+"&#176;";
                longi_lbl.Text= place_x.Element("place_longitude").Value.ToString() + "&#176;";
                like_count_lbl.Text = place_x.Element("place_like_count").Value.ToString();
                Session["cur_item_like_count"]= place_x.Element("place_like_count").Value.ToString();
                posted_by.Text = place_x.Element("place_uid").Value.ToString();
                img_profile.ImageUrl = place_x.Element("place_user_img").Value.ToString();

            }



        }
        else if(itemid.Contains("stuff")) {
            Session["item_type"] = "stuff";
            xmldoc = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/stuff.xml"));

            XElement stuff_x = xmldoc.XPathSelectElement("/stuffs/stuff[./stuff_id='" + itemid + "']");

           // XElement stuff_x__ = xmldoc.Descendants("stuff").FirstOrDefault(p => p.Element("stuff_id").Value.ToString().Equals(itemid));

            if (stuff_x!=null) {
                id_lbl.Text = stuff_x.Element("stuff_id").Value.ToString();
                this.Title = stuff_x.Element("stuff_name").Value.ToString();
                Session["current_item_name"] = stuff_x.Element("stuff_name").Value.ToString();
                img.ImageUrl = stuff_x.Element("stuff_img").Value.ToString();
                item_name_lbl.Text = stuff_x.Element("stuff_title").Value.ToString();
                desc_lbl.Text = stuff_x.Element("stuff_description").Value.ToString();
                time_lbl.Text = stuff_x.Element("stuff_time_upload").Value.ToString();
                lati_lbl.Text = stuff_x.Element("stuff_latitude").Value.ToString() + "&#176;";
                longi_lbl.Text = stuff_x.Element("stuff_longitude").Value.ToString() + "&#176;";
                like_count_lbl.Text = stuff_x.Element("stuff_like_count").Value.ToString();

                Session["cur_item_like_count"] = stuff_x.Element("stuff_like_count").Value.ToString();
                posted_by.Text= stuff_x.Element("stuff_uid").Value.ToString();
                img_profile.ImageUrl= stuff_x.Element("stuff_user_img").Value.ToString();


            }



        }


    }




    protected void btn_send_comment_click(object o,EventArgs e)
    {
        if (Session["user_name"] != null)
        {

            if (Session["item_type"].ToString().Equals("place"))
            {

                int cur_place_total_comments = 0;
              XDocument  xmldoc_place_comments = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/place_comments.xml"));

                //  XElement stuff_x = xmldoc.XPathSelectElement("/stuffs/stuff[./stuff_id='" + itemid + "']");
                foreach (XElement xe in xmldoc_place_comments.XPathSelectElements("//places_comment"))  //.Descendants("places_comment"))
                {
                    if(xe.Element("place_id").Value.ToString().Equals(Session["selected_item_id"].ToString())){
                        cur_place_total_comments++;
                    }
                   
                }

                int new_place_comment_int = cur_place_total_comments + 1;

                
                  DateTime now = DateTime.Now;

                Console.WriteLine("shared place "+ Session["selected_item_id"].ToString() + " at " + now.ToString("yyyy-MM-dd HH:mm:ss.fff"));


                XElement new_place_comment = new XElement("places_comment",
          new XElement("place_id", Session["selected_item_id"].ToString()),
          new XElement("place_comment_id", Session["selected_item_id"].ToString()+"_c"+ new_place_comment_int.ToString()),
          new XElement("place_comment_uid", Session["user_name"].ToString()),
          new XElement("place_comment_user_img", Session["user_img"].ToString()),
          new XElement("place_comment_text", txt_comment.Text),
           new XElement("place_comment_time", now.ToString("yyyy-MM-dd HH:mm"))
           );
                xmldoc_place_comments.Root.Add(new_place_comment);
                xmldoc_place_comments.Save(Server.MapPath("~/pages/Customer/xml_xsl/place_comments.xml"));

            


            }
            else {

                int cur_stuff_total_comments = 0;
                XDocument xmldoc_stuff_comments = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/stuff_comments.xml"));

                foreach (XElement xe in xmldoc_stuff_comments.XPathSelectElements("//stuffs_comment"))//.Descendants("stuffs_comment"))
                {
                    if (xe.Element("stuff_id").Value.ToString().Equals(Session["selected_item_id"].ToString()))
                    {
                        cur_stuff_total_comments++;
                    }

                }

                int new_stuff_comment_int = cur_stuff_total_comments + 1;


                DateTime now = DateTime.Now;

                Console.WriteLine("shared stuff " + Session["selected_item_id"].ToString() + " at " + now.ToString("yyyy-MM-dd HH:mm:ss.fff"));


                XElement new_stuff_comment = new XElement("stuffs_comment",
          new XElement("stuff_id", Session["selected_item_id"].ToString()),
          new XElement("stuff_comment_id", Session["selected_item_id"].ToString() + "_c" + new_stuff_comment_int.ToString()),
          new XElement("stuff_comment_uid", Session["user_name"].ToString()),
          new XElement("stuff_comment_user_img", Session["user_img"].ToString()),
          new XElement("stuff_comment_text", txt_comment.Text),
           new XElement("stuff_comment_time", now.ToString("yyyy-MM-dd HH:mm"))
           );
                xmldoc_stuff_comments.Root.Add(new_stuff_comment);
                xmldoc_stuff_comments.Save(Server.MapPath("~/pages/Customer/xml_xsl/stuff_comments.xml"));


            }


        }
        else
        {

            Session["saved_redirect_page_after_login"] = "~/pages/Customer/detail_followup.aspx?place_id=" + Session["selected_item_id"].ToString() + "";
           
            Response.Redirect("~/pages/login.aspx");

        }
        txt_comment.Text = "";
    }


    //     <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="refresh_detail_page"></asp:Timer>

    protected void refresh_detail_page(object o,EventArgs e) {
        query_place_id = Request.QueryString["place_id"];
        Session["selected_item_id"] = query_place_id;
        
      //  get_map_latlong_cum_session_set(query_place_id);
        //populate_detail_share_info(query_place_id);
        populate_detail_share_info_from_xsl(query_place_id);
        //  populate_comments(query_place_id);
        populate_comments_from_xsl(query_place_id);
        sync_current_item_like_status();


    }

    protected void confirm_item(object o, EventArgs e) {

        AlertBox.Visible = false;
    }

     public void MessageBoxShow(string message)
     {
         this.AlertBoxMessage.InnerText = message;
         this.AlertBox.Visible = true;
     }
 
    protected void backBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Places.aspx");
    }
    protected void TradingBtn_Click(object sender, EventArgs e)
    {

    }
}
