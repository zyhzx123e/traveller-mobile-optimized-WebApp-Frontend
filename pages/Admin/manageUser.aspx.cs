using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
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
using FireSharp.Response;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using System.Text;
using System.Xml.Linq;

public partial class manageUser : System.Web.UI.Page
{

    public List<_user> user_get;
    public string[] name_array;

    //3585 7007 6324 557
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["admin_id"] == null)
        {
            Response.Redirect("~/pages/login.aspx");  
        }
        if(!IsPostBack)
        {
            bind_drop_list();

        }
       // bind_drop_list();


    }

    protected override void OnInit(EventArgs e)
    {
        bind_drop_list();
       



    }


    public void bind_drop_list() {

        user_get = new List<_user>();
        var http1 = (HttpWebRequest)WebRequest.Create(new Uri("" + db_connection.travellerWSlocalBaseUrl + "Users/getAllTravellers/q0w1e9r2t8y3u7i4o6p5"));
        http1.Accept = "text/xml";
        http1.ContentType = "text/xml; charset=utf-8";
        http1.Method = "GET";

        var response1 = http1.GetResponse();

        var stream1 = response1.GetResponseStream();
        var sr1 = new StreamReader(stream1);
        string content1 = sr1.ReadToEnd();

        XDocument doc1 = XDocument.Parse(content1);

        var r1 = doc1.Root;
        var u1 = doc1.Root.Nodes();


        var xDoc1 = XDocument.Parse(content1);

        var ns1 = xDoc1.Root.Name.Namespace;

        var nodelist = xDoc1.Element(ns1 + "userReturn").Elements(ns1 + "uList").Elements(ns1 + "User");
    
        foreach (var v in nodelist)
        {

            _user u = new _user(v.Element(ns1 + "User_profile_img").Value.ToString(), v.Element(ns1 + "User_name").Value.ToString(), v.Element(ns1 + "User_email").Value.ToString(), v.Element(ns1 + "User_pwd").Value.ToString());
            //registered_username_list.Add(v.Element(ns + "User_name").Value);
            user_get.Add(u);
        }


        //=============================

       
 

        name_array = new string[user_get.Count];
        for (int i = 0; i < user_get.Count; i++)
        {
            name_array[i] = user_get[i].user_name;
            // Debug.WriteLine("Name:" + name_array[i]);

        }

        namesDropList.Items.Clear();
        foreach (string name in name_array)
        {
            namesDropList.Items.Add(new ListItem(name));
        }

        Debug.WriteLine("nxt query url string");

        if (Request.QueryString["username"] != null)
        {
            Debug.WriteLine("queried username:"+ Request.QueryString["username"].ToString());
            Session["selected_user_name"] = Request.QueryString["username"].ToString();


            Debug.WriteLine("query string :" + Session["selected_user_name"].ToString());

            int i = 0;
            foreach (var item in namesDropList.Items)
            {
                if (item.ToString().Equals(Session["selected_user_name"].ToString()))
                {
                    namesDropList.SelectedIndex = i;
                    break;
                }
                i++;
            }
        }

        load_data();
    }

    public void load_click(object sender, EventArgs e) {
        Session["selected_user_name"] = namesDropList.SelectedValue.ToString();

        Debug.WriteLine("get : " + Session["selected_user_name"].ToString());

        load_data();

    }



    public void load_data() {
      //  Session["selected_user_name"] = namesDropList.SelectedValue.ToString();

        user_get = new List<_user>();
        var http1 = (HttpWebRequest)WebRequest.Create(new Uri("" + db_connection.travellerWSlocalBaseUrl + "Users/getAllTravellers/q0w1e9r2t8y3u7i4o6p5"));
        http1.Accept = "text/xml";
        http1.ContentType = "text/xml; charset=utf-8";
        http1.Method = "GET";

        var response1 = http1.GetResponse();

        var stream1 = response1.GetResponseStream();
        var sr1 = new StreamReader(stream1);
        string content1 = sr1.ReadToEnd();

        XDocument doc1 = XDocument.Parse(content1);

        var r1 = doc1.Root;
        var u1 = doc1.Root.Nodes();


        var xDoc1 = XDocument.Parse(content1);

        var ns1 = xDoc1.Root.Name.Namespace;

        var nodelist = xDoc1.Element(ns1 + "userReturn").Elements(ns1 + "uList").Elements(ns1 + "User");

        foreach (var v in nodelist)
        {

            _user u = new _user(v.Element(ns1 + "User_profile_img").Value.ToString(), v.Element(ns1 + "User_name").Value.ToString(), v.Element(ns1 + "User_email").Value.ToString(), v.Element(ns1 + "User_pwd").Value.ToString());
            //registered_username_list.Add(v.Element(ns + "User_name").Value);
            user_get.Add(u);
        }


        //=============================




        foreach (_user u in user_get)
        {
            if (u.user_name.Equals(Session["selected_user_name"].ToString()))
            {
                this.img.ImageUrl = u.user_img;

                this.txt_email.Text = u.user_email;
                this.txt_username.Text = u.user_name;
                this.txt_pwd.Text = u.user_pwd;

                //  Response.Redirect(Request.RawUrl);


                Session["user_img_url_update"] = u.user_img;
                Session["user_username_update"] = u.user_name;
                Session["user_userpwd_update"] = u.user_pwd;
                Session["user_useremail_update"] = u.user_email;
            }


        }



        System.Threading.Thread.Sleep(2000);

        Debug.WriteLine("test Session:" + Session["user_img_url_update"].ToString());

        this.img.ImageUrl = Session["user_img_url_update"].ToString();

        this.txt_email.Text = Session["user_useremail_update"].ToString();
        this.txt_username.Text = Session["user_username_update"].ToString();
        this.txt_pwd.Text = Session["user_userpwd_update"].ToString();
        Debug.WriteLine("test Session pwd:" + Session["user_userpwd_update"].ToString());
    }


    /*
          Session["user_uid_update"] = u.uid;
          Session["user_img_url_update"] = u.user_img;
          Session["user_username_update"] = u.user_name;
          Session["user_userpwd_update"] = u.user_pwd;
          Session["user_useremail_update"] = u.user_email;*/
    protected void d_Click(object sender, EventArgs e)
    {
        MessageBoxShow("Are you sure you wanted to delete the selected Traveller : " + Session["user_username_update"] .ToString()+ "");
    }
    public void MessageBoxShow(string message)
    {
        this.AlertBoxMessage.InnerText = message;
        this.AlertBox.Visible = true;
    }

    public void confirm_msg(string message)
    {
        this.Div2.InnerText = message;
        this.div_confirm.Visible = true;
    }
    

    public void delete_traveller() {

        Debug.WriteLine("query delete : " + "/deleteUser_xml?User_name=" + Session["user_username_update"].ToString() + "");


        try
        {

            var http = (HttpWebRequest)WebRequest.Create(new Uri("" + db_connection.travellerWSlocalBaseUrl + "Users/deleteTravellerByUID/" + Session["user_username_update"].ToString() + "/q0w1e9r2t8y3u7i4o6p5"));
            http.Accept = "text/xml";
            http.ContentType = "text/xml; charset=utf-8";
            http.Method = "DELETE";
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

                Debug.WriteLine("delete user response: " + xDoc.Element(ns + "strReturn").Element(ns + "str").Value.ToString());



            }



        }
        catch (Exception E)
        {
            Debug.WriteLine("delete user response: " + E.Message.ToString());


        }

    }
    protected void delete_Click(object sender, EventArgs e)
    {
        //deleteUser_xml?User_name=;

        delete_traveller();


        //======================================
       
        this.AlertBox.Visible = false;

        confirm_msg("Hi Admin ["+Session["admin_id"].ToString()+"] You have just Deleted Traveller（" + Session["selected_user_name"].ToString() + "） .");

       // System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Hi Admin ["+Session["admin_id"].ToString()+"] You have just Deleted Traveller（" + Session["user_username_update"].ToString() + "） .');", true);


       // Response.Redirect("~/pages/Home.aspx");


    }


    protected void confirmed_delete(object o, EventArgs e) {
        this.div_confirm.Visible = false;
        Response.Redirect("~/pages/Home.aspx");
        
    }




    public static FireSharp.FirebaseClient _client = db_connection.getFirebaseClientRef();

    public string download_url_str = "";


    protected   void add_user_btn_Click(object sender, EventArgs e) {




        if (FileUpload2.HasFile)
        {
            string s = @"images\" + FileUpload2.FileName;
            FileUpload2.PostedFile.SaveAs(Server.MapPath(s));
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription("C:\\Program Files (x86)\\IIS Express\\traveller_web\\pages\\Admin\\" + s + "")
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


            Stream fs = FileUpload2.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(fs);
            byte[] fileBytes = br.ReadBytes((Int32)fs.Length);

            string base64String = Convert.ToBase64String(fileBytes, 0, fileBytes.Length);
            new_user_img.ImageUrl = "data:image/png;base64," + base64String;

            Stream stream = new MemoryStream(fileBytes);


        }
        else {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Select a profile picture!');", true);
            return;
        
        }

         

        if(!new_user_pwd.Text.ToString().Equals(new_user_pwd2.Text.ToString())){
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please ensure the both password are mathced!');", true);
            return;
        }
        else{
        
       

             Session["new_user_email"] = this.new_user_email.Text.Trim().ToString();
              Session["new_user_img"] = download_url_str;
              Session["new_user_name"] = this.new_user_name.Text.Trim().ToString();
           Session["new_user_pwd"]=this.new_user_pwd.Text.Trim().ToString();

            if (!this.new_user_email.Text.Trim().ToString().Contains("@") || !this.new_user_email.Text.Trim().ToString().Contains("."))
            {
                //the traveller username is available to use

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Sorry Admin, Traveller User Email is in invalid format!');", true);
                return;
            }


            if (user_exist(this.new_user_name.Text.ToString()))
            {
                //the traveller username is available to use

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Sorry Admin, Traveller Username : [" + Session["new_user_name"] + "]  has already been used, please use another one.');", true);
                return;
            }
            if (usser_email_exist(this.new_user_email.Text.ToString()))
            {
                //the traveller username is available to use

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Sorry Admin, Traveller User Email : [" + Session["new_user_email"] + "]  has already been used, please use another one.');", true);
                return;
            }

            if (!user_exist(this.new_user_name.Text.ToString()) && !usser_email_exist(this.new_user_email.Text.Trim().ToString()))
            {
                //traveller username has already registered

                _user u_add = new _user(Session["new_user_img"].ToString(), Session["new_user_name"].ToString(), Session["new_user_email"].ToString(), Session["new_user_pwd"].ToString());
                add_new_traveller(u_add);

            }
          

            //////////////////////////////////img process


            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Hi Admin, You have successfully created a new user[" + Session["new_user_name"] + "]');", true);
       

        //http://res.cloudinary.com/barterworld/image/upload/v1505614318/pro_ddcxbc.jpg

        }
    
    }

    protected void check_username(object o,EventArgs e) {
        Debug.WriteLine("chk username == ");
        if (user_exist(this.new_user_name.Text.Trim().ToString()))
        {
            //traveller username has already registered
            lbl_username_validate.Text = "Traveller Username " + this.new_user_name.Text.ToString() + " has already been used!";
            lbl_username_validate.Visible = true;
        }
        else {
            lbl_username_validate.Visible = false;
        }

        }


    public void update_traveller(_user uget) {
        string txt_userpwd = uget.user_pwd;
        string download_url_str = uget.user_img;
        string txt_useremail = uget.user_email;
        string txt_username = uget.user_name;
        Debug.WriteLine("query string : "+ "Users/updateTraveller/" + txt_username + "/" + txt_useremail + "/" + txt_userpwd + "?User_profile_img=" + download_url_str + "");

        try
        {


            var http = (HttpWebRequest)WebRequest.Create(new Uri("" + db_connection.travellerWSlocalBaseUrl + "Users/updateTraveller/" + txt_username + "/" + txt_useremail + "/" + txt_userpwd + "/q0w1e9r2t8y3u7i4o6p5?User_profile_img=" + download_url_str + ""));
            http.Accept = "text/xml";
            http.ContentType = "text/xml; charset=utf-8";
            http.Method = "PUT";
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

                Debug.WriteLine("update user response: " + xDoc.Element(ns + "strReturn").Element(ns + "str").Value.ToString());



            }



        } catch (Exception E) {
            Debug.WriteLine("update user response: " + E.Message.ToString());


        }


    }
    public void add_new_traveller(_user uget)
    {

        Debug.WriteLine("query string : "+ "/insertUser_xml?User_name=" + uget.user_name + "&User_profile_img=" + uget.user_img + "&User_email=" + uget.user_email + "&User_pwd=" + uget.user_pwd + "");

        string txt_userpwd = uget.user_pwd;
        string download_url_str = uget.user_img;
        string txt_useremail = uget.user_email;
        string txt_username = uget.user_name;
        
        try
        {
       

            var http = (HttpWebRequest)WebRequest.Create(new Uri("" + db_connection.travellerWSlocalBaseUrl + "Users/addNewTraveller/" + txt_username + "/" + txt_useremail + "/" + txt_userpwd + "/q0w1e9r2t8y3u7i4o6p5?User_profile_img=" + download_url_str + ""));
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
            Debug.WriteLine("new user response: " + respond_str);

        }
        catch (Exception E) {


            Debug.WriteLine("new user response: " + E.Message.ToString());
        }
       
    }

    public bool user_exist(string username) {
        bool exist = false;
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

        var nodelist = xDoc.Element(ns + "userReturn").Elements(ns + "uList").Elements(ns + "User");
        
        foreach (var v in nodelist)
        {
            if (username.Equals(v.Element(ns + "User_name").Value.ToString())) {
                exist = true;
            }
        }
        return exist;
    }

    public bool usser_email_exist(string email)
    {
        bool exist = false;
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

        var nodelist = xDoc.Element(ns + "userReturn").Elements(ns + "uList").Elements(ns + "User");

        foreach (var v in nodelist)
        {
            if (email.Equals(v.Element(ns + "User_email").Value.ToString()))
            {
                exist = true;
            }
        }
        return exist;
    }

    protected   void save_Click(object sender, EventArgs e)
    {
        if (txt_username.Text != "" && txt_pwd.Text != "" && txt_email.Text != "")
        {
            
            if (FileUpload1.HasFile)
            {
                string s = @"images\" + FileUpload1.FileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath(s));
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription("C:\\Program Files (x86)\\IIS Express\\traveller_web\\pages\\Admin\\" + s + "")

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


                Stream fs = FileUpload1.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                byte[] fileBytes = br.ReadBytes((Int32)fs.Length);

                string base64String = Convert.ToBase64String(fileBytes, 0, fileBytes.Length);
                img.ImageUrl = "data:image/png;base64," + base64String;

                Stream stream = new MemoryStream(fileBytes);


            }



            string upload_img_url = "";

            if (!FileUpload1.HasFile || download_url_str == null || download_url_str == "")
            {

                upload_img_url = Session["user_img_url_update"].ToString();

            }
            else
            {
                upload_img_url = download_url_str;

            }

            if (!this.txt_email.Text.ToString().Contains("@") || !this.txt_email.Text.ToString().Contains("."))
            {
                //the traveller username is available to use

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Sorry Admin, Traveller User Email is in invalid format!');", true);
                return;
            }



            _user update_user = new _user
            {
                user_img = upload_img_url,
                user_name = txt_username.Text.ToString(),
                user_email =txt_email.Text.ToString(),
                user_pwd=txt_pwd.Text.ToString()

            };

             Session["user_img_url_update"] = update_user.user_img;
            Session["user_username_update"] = update_user.user_name;
            Session["user_userpwd_update"] = update_user.user_pwd;
            Session["user_useremail_update"] = update_user.user_email;




            update_traveller(update_user);
           
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('You have just updated User（" + Session["user_username_update"].ToString() + "） : " + txt_username.Text.ToString() + "');", true);





        }
        else {

            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Hi Admin, Please Fill in All the required info!');", true);
           
        }
    }










    
}