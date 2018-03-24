using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using System.Data.SqlClient;
using System.Configuration;


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


using Microsoft.Reporting.WebForms;
using Microsoft.Reporting.Common;
using Microsoft.Reporting;
using Newtonsoft.Json.Linq;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using System.Xml;
using System.Xml.XPath;

public partial class servicePost : System.Web.UI.Page
{

     
    public string get_pos_lat;
    public string get_pos_long;

    public JavaScriptSerializer javaSerial = new JavaScriptSerializer();


    public XDocument xmldoc_place;
    public XDocument xmldoc_stuff;


    protected override void OnInit(EventArgs e)
    {/*
      * 
      Init is a good place to add dynamic controls to the page or user control 
      * If can, then those controls will have their ViewState restored automatically during postbacks 
      * 
      */

        base.OnInit(e);


       
        if (!IsPostBack)
        {

            api_bind_list();
        }
     
         



        ///////////////////////////////////////above set the location of the map
    }



    protected void save_current_info(object sender, EventArgs e)
    {


        Session["selected_latitude"] = this.txt_lat.Text.ToString();
        Session["selected_longitude"] = this.txt_long.Text.ToString();

        Debug.WriteLine("AJAX Passed back to c# selected latitude:" + Session["selected_latitude"].ToString());
        
      //  Session["selected_latitude"] = this.txt_lat.Text.ToString();
       // Session["selected_longitude"] = this.txt_long.Text.ToString();


    }



    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["user_name"] == null && Session["admin_id"] == null)
        {

            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please login before you want to share anything!');", true);
            Session["saved_redirect_page_after_login"] = "~/pages/Customer/servicePost.aspx";

            Response.Redirect("~/pages/login.aspx");
        }


        if (!IsPostBack) {
          
        }
        xmldoc_place = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/place.xml"));

 

        int count_place = xmldoc_place.XPathSelectElements("places/place").Count();
       

        Session["current_total_place_count"] = count_place.ToString();



        xmldoc_stuff = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/stuff.xml"));

        int count_stuff = xmldoc_stuff.XPathSelectElements("stuffs/stuff").Count();
        Session["current_total_stuff_count"] = count_place.ToString();
      //   System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('total stuff:" + count_stuff.ToString() + "');", true);

    }





    public  void api_bind_list(){
         

        List<String> type_List = new List<String>();
        type_List.Add("Great Place in Borneo");
        type_List.Add("Interesting Stuff in Borneo");


        /*
         
          DateTime now = DateTime.Now;
        CultureInfo culture = new CultureInfo("ar-SA"); // Saudi Arabia
        Thread.CurrentThread.CurrentCulture = culture;
        Console.WriteLine(now.ToString("yyyy-MM-ddTHH:mm:ss.fff"));
         
         */
 


        foreach (string type in type_List)
        {
            DropDownList_type.Items.Add(new ListItem(type));
        }

      //  System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('The selected position: "+ DropDownList_type.SelectedIndex.ToString()+ "');", true);


    }

    public void selected_index_changed(object o, EventArgs e) {
      // System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('The selected position: " + DropDownList_type.SelectedIndex.ToString() + "');", true);

        Session["selected_share_type_index"] = DropDownList_type.SelectedIndex.ToString();
       // System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('The selected position: " + Session["selected_share_type_index"].ToString() + "');", true);
       // System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('The int position: " + Int16.Parse(Session["selected_share_type_index"].ToString()) + "');", true);

    }








    protected void emptyServicePopUpFrom()
    {
        place_title.Text = "";
        txt_description.Text = "";
       
    }



    protected void backBtn_Click(object sender, EventArgs e)
    {
        string chk_history = Session["visit_back_history"].ToString();


        if (chk_history.Equals("places"))
        {
            Response.Redirect("Places.aspx");
        }
        else
        {
            Response.Redirect("stuff.aspx");
        }
       

       
    }

    protected void test_Click(object sender, EventArgs e)
    {
        Session["selected_latitude"] = this.HiddenField_lat.Value.ToString();
        Session["selected_longitude"] = this.HiddenField_long.Value.ToString();
        Session["selected_address"] = this.HiddenField_address.Value.ToString();


        Debug.WriteLine("AJAX Passed back to c# selected latitude:" + Session["selected_address"].ToString());


      //  System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Hi Admin selected lat: " + Session["selected_latitude"].ToString() + ", long:" + Session["selected_longitude"].ToString() + "');", true);
    }



    protected void fast_share_click(object o, EventArgs e)
    {

        Session["selected_latitude"] = this.txt_lat.Text.ToString();
        Session["selected_longitude"] = this.txt_long.Text.ToString();

        Session["selected_latitude"] = this.HiddenField_lat.Value.ToString();
        Session["selected_longitude"] = this.HiddenField_long.Value.ToString();
        Session["selected_address"] = this.HiddenField_address.Value.ToString();

    }

    protected void submit_fast_btn_Click(object o, EventArgs e)
    {
        Session["selected_latitude"] = this.HiddenField_lat.Value.ToString();
        Session["selected_longitude"] = this.HiddenField_long.Value.ToString();
        Session["selected_address"] = this.HiddenField_address.Value.ToString();

        string original_address = Session["selected_address"].ToString();
        string post_title = "";
        string post_name = "";


        string[] tokens = original_address.Split(',');
        post_title = "Place "+tokens[0] + " " + tokens[1];
        post_name = tokens[0] + " " + tokens[1] + " "+tokens[2];



        // Session["selected_share_type_index"]
        Debug.WriteLine("AJAX Passed back to c#  selected_address:" + Session["selected_address"].ToString());


        //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Hi Admin selected lat: " + Session["selected_latitude"].ToString() + ", long:" + Session["selected_longitude"].ToString() + "');", true);

        //following are the code for uploading image to cloudinary and save the img url back to xml db
        Stream fs = FileUpload2.PostedFile.InputStream;
        BinaryReader br = new BinaryReader(fs);
        byte[] fileBytes = br.ReadBytes((Int32)fs.Length);

        string base64String = Convert.ToBase64String(fileBytes, 0, fileBytes.Length);
        Image1.ImageUrl = "data:image/png;base64," + base64String;
        Image1.Visible = true;
        Stream stream = new MemoryStream(fileBytes);

        DateTime now = DateTime.Now;

        Console.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss"));

        string download_url_str = "";


        
        if (FileUpload2.FileName != null && FileUpload2.FileName != "")
        {
            string s = @"images\" + FileUpload2.FileName;
            string path = Directory.GetCurrentDirectory();
            FileUpload2.PostedFile.SaveAs(Server.MapPath(s));
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


        /*
         * 
         * 
         *  Session["current_total_place_count"]  
            Session["current_total_stuff_count"]  
======================================================================
           Session["selected_latitude"]  
           Session["selected_longitude"] 
           Session["selected_address"]  
        // Session["selected_share_type_index"]

         Session["user_img"]     
         Session["user_name"]  

           
         */

        //now save in to xml db for either place or stuff

    
            //means selected share a place
            int current_id_of_place = Int16.Parse(Session["current_total_place_count"].ToString()) + 1;

        List<String> array_desc = new List<string>();
        XDocument doc_share_item_place = XDocument.Load(Server.MapPath("~/pages/Customer/xml_xsl/post_description.xml"));
       

        foreach (XElement x in doc_share_item_place.XPathSelectElements("//post_description"))
        {
            array_desc.Add(x.Value.ToString());
        }

        Random randNum = new Random();
        int aRandomPos = randNum.Next(array_desc.Count);//Returns a nonnegative random number less than the specified maximum (firstNames.Count).

        string random_desc = array_desc[aRandomPos];


        XElement new_place = new XElement("place",
                new XElement("place_id", "place" + current_id_of_place.ToString() + "_" + common.get_random_string(8)),
                new XElement("place_img", download_url_str),
              
                new XElement("place_title", post_title),
                new XElement("place_name", post_name),

                new XElement("place_description", random_desc),
                 new XElement("place_time_upload", now.ToString("yyyy-MM-dd HH:mm:ss")),
                new XElement("place_uid", Session["user_name"] == null ? Session["admin_id"].ToString() : Session["user_name"].ToString()),
                new XElement("place_user_img", Session["user_img"]==null ? Session["admin_img"].ToString() : Session["user_name"].ToString()),
                 new XElement("place_longitude", Session["selected_longitude"].ToString()),
                new XElement("place_latitude", Session["selected_latitude"].ToString()),
                new XElement("place_address", Session["selected_address"].ToString()),
                 new XElement("place_like_count", "0")
                 );
            xmldoc_place.Root.Add(new_place);
            xmldoc_place.Save(Server.MapPath("~/pages/Customer/xml_xsl/place.xml"));
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Dear Traveller " + Session["user_name"].ToString() + ", You Have just shared a new place " + place_name.Text.ToString() + " with the title of " + place_title.Text.ToString() + "');", true);
            System.Threading.Thread.Sleep(3000);
            Response.Redirect("~/pages/Customer/Places.aspx");
       


    }

    protected void submit_item_btn_Click(object sender, EventArgs e)
    {
        Session["selected_latitude"] = this.HiddenField_lat.Value.ToString();
        Session["selected_longitude"] = this.HiddenField_long.Value.ToString();
        Session["selected_address"] = this.HiddenField_address.Value.ToString();
        // Session["selected_share_type_index"]
        Debug.WriteLine("AJAX Passed back to c# selected address txtbox:"+ this.address.Text.ToString()+"  -- session:" + Session["selected_address"].ToString());


        //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Hi Admin selected lat: " + Session["selected_latitude"].ToString() + ", long:" + Session["selected_longitude"].ToString() + "');", true);
           
        //following are the code for uploading image to cloudinary and save the img url back to xml db
        Stream fs = FileUpload1.PostedFile.InputStream;
        BinaryReader br = new BinaryReader(fs);
        byte[] fileBytes = br.ReadBytes((Int32)fs.Length);

        string base64String = Convert.ToBase64String(fileBytes, 0, fileBytes.Length);
        img.ImageUrl = "data:image/png;base64," + base64String;
        img.Visible = true;
        Stream stream = new MemoryStream(fileBytes);

        DateTime now = DateTime.Now;

        Console.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss"));

        string download_url_str="";



        if (FileUpload1.FileName != null && FileUpload1.FileName != "")
        {
            string s = @"images\" + FileUpload1.FileName;
             string path = Directory.GetCurrentDirectory();
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


        /*
         * 
         * 
         *  Session["current_total_place_count"]  
            Session["current_total_stuff_count"]  
======================================================================
           Session["selected_latitude"]  
           Session["selected_longitude"] 
           Session["selected_address"]  
        // Session["selected_share_type_index"]

         Session["user_img"]     
         Session["user_name"]  

           
         */

        //now save in to xml db for either place or stuff

        int i_get = DropDownList_type.SelectedIndex;
        Debug.WriteLine("get type index: "+i_get);

        if (i_get == 0)
        {
            //means selected share a place
            int current_id_of_place = Int16.Parse(Session["current_total_place_count"].ToString()) +1;


            XElement new_place = new XElement("place",
                new XElement("place_id", "place"+current_id_of_place.ToString()+"_"+common.get_random_string(8)),
                new XElement("place_img", download_url_str),
                new XElement("place_title", place_title.Text),
                new XElement("place_name", place_name.Text),
                new XElement("place_description", txt_description.Text),
                 new XElement("place_time_upload", now.ToString("yyyy-MM-dd HH:mm:ss")),
                new XElement("place_uid", Session["user_name"] == null ? Session["admin_id"].ToString() : Session["user_name"].ToString()),
                new XElement("place_user_img", Session["user_img"] == null ? Session["admin_img"].ToString() : Session["user_name"].ToString()),
                 new XElement("place_longitude", Session["selected_longitude"].ToString()),
                new XElement("place_latitude", Session["selected_latitude"].ToString()),
                new XElement("place_address", Session["selected_address"].ToString()),
                 new XElement("place_like_count", "0")
                 );
            xmldoc_place.Root.Add(new_place);
            xmldoc_place.Save(Server.MapPath("~/pages/Customer/xml_xsl/place.xml"));
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Dear Traveller " + Session["user_name"].ToString() + ", You Have just shared a new place " + place_name.Text.ToString() + " with the title of " +place_title.Text.ToString() +"');", true);
            System.Threading.Thread.Sleep(3000);
           // Response.Redirect("~/pages/Customer/Places.aspx");
        }
        else {
            //means share a stuff
            int current_id_of_stuff = Int16.Parse(Session["current_total_stuff_count"].ToString()) + 1;


            XElement new_stuff = new XElement("stuff",  
                new XElement("stuff_id", "stuff"+current_id_of_stuff.ToString() + "_" + common.get_random_string(8)),
                new XElement("stuff_img", download_url_str),
                new XElement("stuff_title", place_title.Text),
                new XElement("stuff_name", place_name.Text),
                new XElement("stuff_description", txt_description.Text),
                 new XElement("stuff_time_upload", now.ToString("yyyy-MM-dd HH:mm:ss")),
                new XElement("stuff_uid", Session["user_name"]==null? Session["admin_id"].ToString() : Session["user_name"].ToString()),
                new XElement("stuff_user_img", Session["user_img"] == null ? Session["admin_img"].ToString() : Session["user_name"].ToString()),
                 new XElement("stuff_longitude", Session["selected_longitude"].ToString()),
                new XElement("stuff_latitude", Session["selected_latitude"].ToString()),
                new XElement("stuff_address", Session["selected_address"].ToString()),
                 new XElement("stuff_like_count", "0")
                 );
            xmldoc_stuff.Root.Add(new_stuff);
            xmldoc_stuff.Save(Server.MapPath("~/pages/Customer/xml_xsl/stuff.xml"));
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Dear Traveller "+ Session["user_name"].ToString()+ ", You Have just shared a new stuff " + place_name.Text.ToString() + " with the title of " + place_title.Text.ToString() + "');", true);
            System.Threading.Thread.Sleep(3000);
           // Response.Redirect("~/pages/Customer/stuff.aspx");
        }



    }


    protected void back_Click(object sender, EventArgs e)
    {
        string chk_history = Session["visit_back_history"].ToString();


        if (chk_history.Equals("places"))
        {
            Response.Redirect("Places.aspx");
        }else{
            Response.Redirect("stuff.aspx");
        }
       
    }
}