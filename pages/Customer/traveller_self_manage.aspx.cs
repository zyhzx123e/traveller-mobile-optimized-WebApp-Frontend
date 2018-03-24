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

public partial class traveller_self_manage : System.Web.UI.Page
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

                get_pos_address = place_x.Element("place_address").Value.ToString();
                get_pos_lat = place_x.Element("place_latitude").Value.ToString();
                get_pos_long = place_x.Element("place_longitude").Value.ToString();
                txt_item_address.Text = get_pos_address;
                txt_item_latitude.Text = get_pos_lat;
                txt_item_longitude.Text = get_pos_long;


                get_pos_TITLE = place_x.Element("place_title").Value.ToString();
                Session["current_item_title"] = get_pos_TITLE;
                get_pos_NAME =place_x.Element("place_name").Value.ToString();
                get_pos_IMG = place_x.Element("place_img").Value.ToString();
                get_pos_DESC = place_x.Element("place_description").Value.ToString();


                Session["cur_item_like_count"] = place_x.Element("place_like_count").Value.ToString();
              
            }


            //SET LIKE PPL

           XDocument xmldoc_likes = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/place_likes.xml"));
            //  ./book[/author/name = 'John'] 
 

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

                get_pos_address = stuff_x.Element("stuff_address").Value.ToString();
                get_pos_NAME = stuff_x.Element("stuff_name").Value.ToString();
                get_pos_IMG = stuff_x.Element("stuff_img").Value.ToString();
                get_pos_lat = stuff_x.Element("stuff_latitude").Value.ToString();
                get_pos_long = stuff_x.Element("stuff_longitude").Value.ToString();
                txt_item_address.Text = get_pos_address;
                txt_item_latitude.Text = get_pos_lat;
                txt_item_longitude.Text = get_pos_long;

                get_pos_TITLE = stuff_x.Element("stuff_title").Value.ToString();
                Session["current_item_title"] = get_pos_TITLE;
                get_pos_NAME = stuff_x.Element("stuff_name").Value.ToString();
               
                get_pos_DESC = stuff_x.Element("stuff_description").Value.ToString();


                Session["cur_item_like_count"] = stuff_x.Element("stuff_like_count").Value.ToString();
               

            }


            //SET LIKE PPL

            XDocument xmldoc_likes = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/stuff_likes.xml"));
            //  ./book[/author/name = 'John'] 


           


        }

    }

     

    public bool img_flg=true;
    public string query_place_id = "";

    protected override void OnInit(EventArgs e)
    {
        Session["chkbox_show"] = "0";

        if (Session["user_name"] == null)
        {
            Response.Redirect("~/pages/login.aspx");
        }



    }

    public FileUpload FileUpload1;
    public System.Web.UI.HtmlControls.HtmlImage img;
     
    public System.Web.UI.HtmlControls.HtmlInputText txt_item_title;
    public System.Web.UI.HtmlControls.HtmlInputText txt_item_desc;




    protected void Page_Load(object sender, EventArgs e_)
    {


        if (!IsPostBack)
        {

            query_place_id = Request.QueryString["place_id"];
            Session["selected_item_id"] = query_place_id;

            if (Session["user_name"] == null && Session["admin_id"] == null)
            {
                Session["saved_redirect_page_after_login"] = "~/pages/Customer/traveller_self_manage.aspx?place_id=" + Session["selected_item_id"].ToString() + "";
                Response.Redirect("~/pages/login.aspx");

            }

            get_map_latlong_cum_session_set(query_place_id);
            //populate_detail_share_info(query_place_id);
            populate_detail_share_info_from_xsl(query_place_id);
         
            sync_current_item_like_status();
            bind_controls_in_xsl();


        }

        query_place_id = Request.QueryString["place_id"];
        Session["selected_item_id"] = query_place_id;


        get_map_latlong_cum_session_set(query_place_id);
        //populate_detail_share_info(query_place_id);
        populate_detail_share_info_from_xsl(query_place_id);
   
        sync_current_item_like_status();
        bind_controls_in_xsl();



        if (Session["selected_item_id"].ToString().Contains("place"))
        {
            XDocument doc_original_data = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/place.xml"));

            XElement x_place = doc_original_data.XPathSelectElement("//place[./place_id='" + Session["selected_item_id"].ToString() + "']");


            if (x_place != null)
            {
                if (!x_place.Element("place_uid").Value.ToString().Equals(Session["user_name"].ToString()))
                {
                    //secure user
                    Response.Redirect("~/pages/Customer/Places.aspx");
                }
            }
            else
            {
                Response.Redirect("~/pages/Home.aspx");
            }
         
        }
        else
        {
            XDocument doc_original_data = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/stuff.xml"));

            XElement x_stuff = doc_original_data.XPathSelectElement("//stuff[./stuff_id='" + Session["selected_item_id"].ToString() + "']");

            if (x_stuff != null)
            {
                if (!x_stuff.Element("stuff_uid").Value.ToString().Equals(Session["user_name"].ToString()))
                {

                    //secure user
                    Response.Redirect("~/pages/Customer/stuff.aspx");
                }
            }
            else {
                Response.Redirect("~/pages/Home.aspx");
            }
          

        }

        

    }

    public void bind_controls_in_xsl() {

        FileUpload1 = (FileUpload)ph_share_info.FindControl("FileUpload1");
        img = (System.Web.UI.HtmlControls.HtmlImage)ph_share_info.FindControl("img");

         txt_item_title = (System.Web.UI.HtmlControls.HtmlInputText)ph_share_info.FindControl("txt_item_title");
        txt_item_desc = (System.Web.UI.HtmlControls.HtmlInputText)ph_share_info.FindControl("txt_item_desc");


      


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

                  
                }
                else {
                    Debug.WriteLine("line 270 --- cur didnt like");
                    Session["current_user_liked_check"] = "false";
                
                   // ImageButton_like_detail.Attributes.Remove("class_clicked");
                  //  System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('you removed class class_clicked');", true);
                   

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
               
                } else {
                    Debug.WriteLine("line 288-- in stuff didnt like");
                    Session["current_user_liked_check"] = "false";
                  
                }



            }



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
            transform.Load(Server.MapPath("~/pages/Customer/xml_xsl/place_traveller_self_manage.xslt"));
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
            transform.Load(Server.MapPath("~/pages/Customer/xml_xsl/stuff_traveller_self_manage.xslt"));
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





    protected void btn_save_click(object o,EventArgs e)
    {

        Session["txt_item_address"] = txt_item_address.Text.ToString();
        Session["txt_item_longitude"] = txt_item_longitude.Text.ToString();
        Session["txt_item_latitude"] = txt_item_latitude.Text.ToString();
        Session["txt_item_title"] = txt_item_title.Value.ToString();
        Session["txt_item_desc"] = txt_item_desc.Value.ToString();

        //store original value into obj 1st
        share_item s_obj;

        if (Session["selected_item_id"].ToString().Contains("place")) {
            XDocument doc_original_data = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/place.xml"));

            XElement x_place = doc_original_data.XPathSelectElement("//place[./place_id='" + Session["selected_item_id"].ToString() + "']");


            s_obj = new share_item(x_place.Element("place_id").Value.ToString(), x_place.Element("place_img").Value.ToString(),
                 x_place.Element("place_title").Value.ToString(), x_place.Element("place_name").Value.ToString(),
                 x_place.Element("place_description").Value.ToString(), x_place.Element("place_time_upload").Value.ToString(),
                 x_place.Element("place_uid").Value.ToString(), x_place.Element("place_user_img").Value.ToString(),
                 x_place.Element("place_longitude").Value.ToString(), x_place.Element("place_latitude").Value.ToString(),
                 x_place.Element("place_address").Value.ToString(), x_place.Element("place_like_count").Value.ToString());

        }
        else {
            XDocument doc_original_data = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/stuff.xml"));

            XElement x_stuff = doc_original_data.XPathSelectElement("//stuff[./stuff_id='"+ Session["selected_item_id"].ToString() + "']");

            
               s_obj = new share_item(x_stuff.Element("stuff_id").Value.ToString(), x_stuff.Element("stuff_img").Value.ToString(),
                    x_stuff.Element("stuff_title").Value.ToString(), x_stuff.Element("stuff_name").Value.ToString(),
                    x_stuff.Element("stuff_description").Value.ToString(), x_stuff.Element("stuff_time_upload").Value.ToString(),
                    x_stuff.Element("stuff_uid").Value.ToString(), x_stuff.Element("stuff_user_img").Value.ToString(),
                    x_stuff.Element("stuff_longitude").Value.ToString(), x_stuff.Element("stuff_latitude").Value.ToString(),
                    x_stuff.Element("stuff_address").Value.ToString(), x_stuff.Element("stuff_like_count").Value.ToString());
            

        }



        //img process
      Stream fs = FileUpload1.PostedFile.InputStream;
        BinaryReader br = new BinaryReader(fs);
        byte[] fileBytes = br.ReadBytes((Int32)fs.Length);

        string base64String = Convert.ToBase64String(fileBytes, 0, fileBytes.Length);
        img.Src = "data:image/png;base64," + base64String;
        img.Visible = true;
        Stream stream = new MemoryStream(fileBytes);    

        DateTime now = DateTime.Now;

        Console.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss"));

        string download_url_str = "";



        if (FileUpload1.FileName != null && FileUpload1.FileName !="")
        {
            string s = @"images\" + FileUpload1.FileName;
            FileUpload1.PostedFile.SaveAs(Server.MapPath(s));
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription("C:\\Program Files (x86)\\IIS Express\\traveller_web\\pages\\Customer\\" + s + "")
          
            };
            var uploadResult = db_connection.cloudinary.Upload(uploadParams);


            var checkParams = new SortedDictionary<string, object>();
            checkParams.Add("public_id", uploadResult.PublicId);
            checkParams.Add("version", uploadResult.Version);
            checkParams.Add("signature", uploadResult.Signature);
            checkParams.Add("width", uploadResult.Width);
            checkParams.Add("height", uploadResult.Height);
            checkParams.Add("format", uploadResult.Format);
            checkParams.Add("resource_type", uploadResult.ResourceType);
            checkParams.Add("created_at", uploadResult.CreatedAt);
            checkParams.Add("bytes", uploadResult.Length);
            checkParams.Add("type", uploadResult.Info);
            checkParams.Add("url", uploadResult.Uri);
            checkParams.Add("secure_url", uploadResult.SecureUri);

            /*
              
              
              "public_id":"tquyfignx5bxcbsupr6a",
   "version":1375302801,
   "signature":"52ecf23eeb987b3b5a72fa4ade51b1c7a1426a97",
   "width":1920,
   "height":1200,
   "format":"jpg",
   "resource_type":"image",
   "created_at":"2017-07-31T20:33:21Z",
   "bytes":737633,
   "type":"upload",
   "url":
   "http://res.cloudinary.com/demo/image/upload/v1375302801/tquyfignx5bxcbsupr6a.jpg",
   "secure_url":
   "https://res.cloudinary.com/demo/image/upload/v1375302801/tquyfignx5bxcbsupr6a.jpg"
              
             */

            var api = new Api(db_connection.account);
            string expectedSign_json = api.SignParameters(checkParams);


            Debug.WriteLine("response_url:" + uploadResult.Uri);

            // cloudinaryResponse result = JsonConvert.DeserializeObject<cloudinaryResponse>(uploadResult.ToString());

            download_url_str = uploadResult.Uri.ToString();




        }
        else {
            download_url_str = s_obj.place_img;
            Debug.WriteLine("original img : " + s_obj.place_img);
        }




        if (Session["selected_item_id"].ToString().Contains("place"))
        {
            //save placeinfo

            XDocument update_doc = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/place.xml"));

            XElement x_place_update = update_doc.XPathSelectElement("//place[./place_id='" + Session["selected_item_id"].ToString() + "']");


            /*  txt_item_address  
              txt_item_longitude  
              txt_item_latitude  
              txt_item_title 
              txt_item_desc  




                Session["txt_item_address"] = txt_item_address.Text.ToString();
          Session["txt_item_longitude"] = txt_item_longitude.Text.ToString();
          Session["txt_item_latitude"] = txt_item_latitude.Text.ToString();
          Session["txt_item_title"] = txt_item_title.Text.ToString();
          Session["txt_item_desc"] = txt_item_desc.Text.ToString();

               */

            if (x_place_update!=null) {
                x_place_update.Element("place_img").Value = download_url_str;
                x_place_update.Element("place_title").Value = Session["txt_item_title"].ToString();
             //   x_place_update.Element("place_name").Value = "";
                x_place_update.Element("place_description").Value = Session["txt_item_desc"].ToString();
                x_place_update.Element("place_time_upload").Value = now.ToString("yyyy-MM-dd HH:mm:ss");
              //  x_place_update.Element("place_uid").Value = "";
              // x_place_update.Element("place_user_img").Value = "";
                x_place_update.Element("place_longitude").Value = Session["txt_item_longitude"].ToString();
                x_place_update.Element("place_latitude").Value = Session["txt_item_latitude"].ToString(); ;
                x_place_update.Element("place_address").Value = Session["txt_item_address"].ToString();
                //  x_place_update.Element("place_like_count").Value = "";
                update_doc.Save(Server.MapPath("~/pages/Customer/xml_xsl/place.xml"));
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('You have successfully updated the data of current item " + Session["selected_item_id"].ToString() + " : " + txt_item_title.Value.ToString() + "');", true);

            }


        }
        else {
            //save stuff info
            XDocument update_doc = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/stuff.xml"));

            XElement x_stuff_update = update_doc.XPathSelectElement("//stuff[./stuff_id='" + Session["selected_item_id"].ToString() + "']");




            /*
             * 
                Session["txt_item_address"] = txt_item_address.Text.ToString();
          Session["txt_item_longitude"] = txt_item_longitude.Text.ToString();
          Session["txt_item_latitude"] = txt_item_latitude.Text.ToString();
          Session["txt_item_title"] = txt_item_title.Text.ToString();
          Session["txt_item_desc"] = txt_item_desc.Text.ToString();
             
             
             
             */
            if (x_stuff_update != null)
            {
                x_stuff_update.Element("stuff_img").Value = download_url_str;
                x_stuff_update.Element("stuff_title").Value = Session["txt_item_title"].ToString();
                //   x_stuff_update.Element("stuff_name").Value = "";
                x_stuff_update.Element("stuff_description").Value = Session["txt_item_desc"].ToString();
                x_stuff_update.Element("stuff_time_upload").Value = now.ToString("yyyy-MM-dd HH:mm:ss");
                //  x_stuff_update.Element("stuff_uid").Value = "";
                // x_stuff_update.Element("stuff_user_img").Value = "";
                x_stuff_update.Element("stuff_longitude").Value = Session["txt_item_longitude"].ToString();
                x_stuff_update.Element("stuff_latitude").Value = Session["txt_item_latitude"].ToString(); ;
                x_stuff_update.Element("stuff_address").Value = Session["txt_item_address"].ToString();
                //  x_stuff_update.Element("stuff_like_count").Value = "";
                update_doc.Save(Server.MapPath("~/pages/Customer/xml_xsl/stuff.xml"));


                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('You have successfully updated the data of current item "+ Session["selected_item_id"].ToString() + " : "+txt_item_title.Value.ToString()+"');", true);


            }
        }




    }


    private void delete() {
        if (Session["selected_item_id"].ToString().Contains("place"))
        {
            //means current item is a place
            XDocument x_item_delete_place = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/place.xml"));
            XElement X_DELETE = x_item_delete_place.XPathSelectElement("/places/place[./palce_id='" + Session["selected_item_id"].ToString() + "']");

            if (X_DELETE!=null) {
                X_DELETE.Remove();
                x_item_delete_place.Save(Server.MapPath("~/pages/Customer/xml_xsl/place.xml"));
            }

            XDocument x_item_likes_delete = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/place_likes.xml"));
            XElement X__ikes_DELETE = x_item_likes_delete.XPathSelectElement("/place_likes/place_like[@place_id='" + Session["selected_item_id"].ToString() + "']");

            if (X__ikes_DELETE!=null) {
                X__ikes_DELETE.Remove();
                x_item_likes_delete.Save(Server.MapPath("~/pages/Customer/xml_xsl/place_likes.xml"));
            }



            XDocument x_item_comments_delete = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/place_comments.xml"));
            foreach (XElement x in x_item_comments_delete.XPathSelectElements("/place_comments/place_comment[./place_id='" + Session["selected_item_id"].ToString() + "']")) {

                if (x!=null) {
                    x.Remove();
                    x_item_comments_delete.Save(Server.MapPath("~/pages/Customer/xml_xsl/place_comments.xml"));

                }
            }

           





        }
        else
        {


          
            //means current item is a stuff
            XDocument x_item_delete_stuff =  XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/stuff.xml"));
            XElement X_DELETE_stuff = x_item_delete_stuff.XPathSelectElement("/stuffs/stuff[./stuff_id='" + Session["selected_item_id"].ToString() + "']");
            if (X_DELETE_stuff != null) {
                X_DELETE_stuff.Remove();
                x_item_delete_stuff.Save(Server.MapPath("~/pages/Customer/xml_xsl/stuff.xml"));
            }
         


            XDocument x_item_stuff_likes_delete = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/stuff_likes.xml"));
            XElement X__ikes_DELETE_stuff = x_item_stuff_likes_delete.XPathSelectElement("/stuff_likes/stuff_like[@stuff_id='" + Session["selected_item_id"].ToString() + "']");

            if (X__ikes_DELETE_stuff != null) {

                X__ikes_DELETE_stuff.Remove();
                x_item_stuff_likes_delete.Save(Server.MapPath("~/pages/Customer/xml_xsl/stuff_likes.xml"));

            }


            XDocument x_item_comments_delete = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/stuff_comments.xml"));
            foreach (XElement x in x_item_comments_delete.XPathSelectElements("/stuff_comments/stuff_comment[./stuff_id='" + Session["selected_item_id"].ToString() + "']"))
            {
                if (x!=null) {
                    x.Remove();
                    x_item_comments_delete.Save(Server.MapPath("~/pages/Customer/xml_xsl/stuff_comments.xml"));

                }
            }



        }

        confirm_promptShow("You have successfully deleted item "+ Session["selected_item_id"].ToString() + " : "+get_pos_NAME+"");

    }

    protected void btn_delete_click(object o,EventArgs e) {


        if (Session["chkbox_show"].ToString().Equals("0"))
        {
            MessageBoxShow("Are you sure you want to delete current item? the deletion could never revert back again! Enter Your Password to proceed this action.");

        }
        else if(Session["chkbox_show"].ToString().Equals("1"))
        {
            delete();
        }



    }


    protected void refresh_detail_page(object o,EventArgs e) {
        query_place_id = Request.QueryString["place_id"];
        Session["selected_item_id"] = query_place_id;


        get_map_latlong_cum_session_set(query_place_id);
        //populate_detail_share_info(query_place_id);
        populate_detail_share_info_from_xsl(query_place_id);
        
        sync_current_item_like_status();


    }

    protected void chk_changed(object o, EventArgs e)
    {

        if (chkbox_show.Checked)
        {
            Session["chkbox_show"]="1";
            Debug.WriteLine("checked");
        }
        else {
            Session["chkbox_show"] = "0";
            Debug.WriteLine("un-checked");
        }
            

            }

    protected void confirm_item(object o, EventArgs e) {

        string get_pwd_entered = txt_pwd_verification.Text.Trim().ToString();
        if (get_pwd_entered.Equals(Session["user_pwd"].ToString()))
        {
            msg.Text = "User Identity Verified.";
            AlertBox.Visible = false;
            delete();
        }
        else {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Sorry "+Session["user_name"].ToString()+", the password you have entered is not correct! please check again! ');", true);
            
        }
      
    }

    protected void ok(object o,EventArgs e) {
        this.confirm_prompt.Visible = false;
        Response.Redirect("~/pages/Home.aspx");
    }

    public void confirm_promptShow(string message)
    {
        this.txt_prompt.InnerText = message;
        this.confirm_prompt.Visible = true;
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
