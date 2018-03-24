using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using FireSharp.Config;
using FireSharp.EventStreaming;
using FireSharp.Exceptions;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.Reporting.WebForms;
using Microsoft.Reporting.Common;
using Microsoft.Reporting;
using System.Threading;
using System.Diagnostics;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using System.IO;
using System.Net;
using System.Xml.Linq;
using System.Text;

public partial class pwdChange : System.Web.UI.Page
{
    public int count = 0;
    private static FireSharp.FirebaseClient _client = db_connection.getFirebaseClientRef();
    public string admin_id_get;
    public string admin_pwd_get;

    public string user_name_get;
    public string user_profile_img_get;
    public string user_email_get;
    public string user_pwd;
   
 

    _user userObject = new _user();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin_id"] != null)
        {
            admin_id_get = Session["admin_id"].ToString();
            admin_pwd_get = Session["admin_pwd"].ToString();

        }
        else if (Session["user_name"] != null)
        {
            user_name_get = Session["user_email"].ToString();
            user_profile_img_get = Session["user_img"].ToString();
            user_email_get = Session["user_name"].ToString();
            user_pwd = Session["user_pwd"].ToString();

            //set profile info
            txt_email.Text = user_email_get;
            txt_username.Text = user_name_get;
            img.ImageUrl = user_profile_img_get;



        }
        else
        {
            Response.Redirect("~/pages/login.aspx");
        }

      
        if (!IsPostBack)
        {
          if(Session["admin_id"]!=null){
              admin_id_get = Session["admin_id"].ToString();
              admin_pwd_get = Session["admin_pwd"].ToString();

          }
          else if (Session["user_name"] != null)
          {
              user_name_get=Session["user_email"].ToString() ;
              user_profile_img_get=  Session["user_img"].ToString();
               user_email_get=  Session["user_name"].ToString();
               user_pwd= Session["user_pwd"].ToString() ;

              //set profile info
               txt_email.Text = user_email_get;
               txt_username.Text = user_name_get;
               img.ImageUrl = user_profile_img_get;

             
          
          }else{
              Response.Redirect("~/pages/login.aspx"); 
          }


            
        }
      
    }

    protected  void save_info( object o, EventArgs e)
    {

        string ori_user_name=Session["user_name"].ToString();
        string ori_user_email = Session["user_email"].ToString();
        string ori_user_img = Session["user_img"].ToString();
        string ori_user_pwd = Session["user_pwd"].ToString();

        string new_user_name = "";
        string new_user_email = "";
        string new_user_pwd = "";
        string new_user_img = "";

        new_user_email = ori_user_email;
        Debug.WriteLine("new user email :" + new_user_email);
        Debug.WriteLine("old user email :" + ori_user_email);
        new_user_name = ori_user_name;
        Debug.WriteLine("new username :" + new_user_name);
        Debug.WriteLine("old username :" + ori_user_name);
        new_user_pwd = txt_pwd.Text.Trim().ToString();

        Debug.WriteLine("new pwd :" + new_user_pwd);
        Debug.WriteLine("old pwd :" + ori_user_pwd);

        if (FileUpload1.HasFile)
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

            new_user_img = uploadResult.Uri.ToString();


            Stream fs = FileUpload1.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(fs);
            byte[] fileBytes = br.ReadBytes((Int32)fs.Length);

            string base64String = Convert.ToBase64String(fileBytes, 0, fileBytes.Length);
            img.ImageUrl = "data:image/png;base64," + base64String;

            Stream stream = new MemoryStream(fileBytes);


        }
        else {
            new_user_img = ori_user_img; 
        }
        
       
        if(txt_email.Text=="" || txt_email.Text==null){
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Email cannot be empty');", true);
            return;
        }
        if (txt_username.Text == "" || txt_username.Text == null)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Username cannot be empty');", true);
            return;
        }
        if (txt_old_pwd.Text == "" || txt_old_pwd.Text == null)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please verify yourself by fill in correct old password!');", true);
            return;
        }
        else if(!txt_old_pwd.Text.Trim().ToString().Equals(ori_user_pwd)) {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Dear "+ori_user_name+" Your original password is incorrect!');", true);
            return;
        }
        
        if (txt_pwd.Text == "" || txt_pwd.Text == null)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Password cannot be empty');", true);
            return;
        }
        if (txt_pwd2.Text == "" || txt_pwd2.Text == null)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Password must be confirmed!');", true);
            return;
        }
        if (!txt_pwd2.Text.Trim().ToString().Equals(txt_pwd.Text.Trim().ToString()))
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Password & Confirm Password does not matched !');", true);
            return;
        
        }

        if (txt_pwd2.Text.Trim().ToString().Length<6)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Password must contains at least 6 chatacters!');", true);
            return;

        }
       

       
        string msg_get = update_user_info(new_user_name, new_user_email, new_user_img, new_user_pwd);

        Session["user_email"] = new_user_email;
        Session["user_img"] = new_user_img;
        Session["user_name"] = new_user_name;
        Session["user_pwd"] = new_user_pwd;

        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Hi "+new_user_name+" "+msg_get+"');", true);
          Thread.Sleep(5000);

          Response.Redirect("~/pages/Home.aspx");
     
        
    }

    public string update_user_info(string uname,string uemail,string uimg,string upwd) {
        string returned_msg = "";
        Debug.WriteLine("uname: ="+uname);
        Debug.WriteLine("uemail: =" + uemail);
        Debug.WriteLine("uimg: =" + uimg);
        Debug.WriteLine("upwd: =" + upwd);



        var data = uname + "/" + uemail + "/" + upwd+ "/q0w1e9r2t8y3u7i4o6p5?User_profile_img=" + uimg + "";

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri("" + db_connection.travellerWSlocalBaseUrl + "Users/updateTraveller/" + data + ""));
      
        byte[] bytes;
        var requestXml = "<User><User_name>"+uname+"</User_name><User_profile_img>"+uimg+"</User_profile_img><User_email>"+uemail+"</User_email><User_pwd>"+upwd+"</User_pwd></User>";
        bytes = System.Text.Encoding.ASCII.GetBytes(requestXml);
        request.ContentType = "text/xml; encoding='utf-8'";
        request.ContentLength = bytes.Length;
        request.Method = "PUT";
        Stream requestStream = request.GetRequestStream();
        requestStream.Write(bytes, 0, bytes.Length);
        requestStream.Close();
        HttpWebResponse response;
        response = (HttpWebResponse)request.GetResponse();
        if (response.StatusCode == HttpStatusCode.OK)
        {
            Stream responseStream = response.GetResponseStream();

            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            string content = sr.ReadToEnd();

            XDocument doc = XDocument.Parse(content);

            var r = doc.Root;
            var u = doc.Root.Nodes();


            var xDoc = XDocument.Parse(content);

            var ns = xDoc.Root.Name.Namespace;
            returned_msg = xDoc.Element(ns + "strReturn").Element(ns + "str").Value.ToString();
            sendEmail(uemail, uname, upwd);
        }



        /*
        var http = (HttpWebRequest)WebRequest.Create(new Uri("" + db_connection.travellerWSlocalBaseUrl + "Users/updateTraveller/"+ data+""));
        http.Method = "PUT";
        http.Accept = "text/xml";
        http.ContentType = "text/xml; charset=utf-8";
       
 
        byte[] postBytes = Encoding.ASCII.GetBytes(data);
        http.ContentLength = db_connection.contentHTTPlength;




        HttpWebResponse response = (HttpWebResponse)http.GetResponse();



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

        if((int)statusCode==200){

            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            string content = sr.ReadToEnd();

            XDocument doc = XDocument.Parse(content);

            var r = doc.Root;
            var u = doc.Root.Nodes();


            var xDoc = XDocument.Parse(content);

            var ns = xDoc.Root.Name.Namespace;
            returned_msg = xDoc.Element(ns + "strReturn").Element(ns + "string").Value.ToString();
            sendEmail(uemail, uname,upwd);

        
        }
       
        */
        return returned_msg;
    
    }

    private void sendEmail(string email_to_send,string username,string newPwd) {


        //ws: sendEmailToInformUserInfoChanged

        var http = (HttpWebRequest)WebRequest.Create(new Uri("" + db_connection.travellerWSlocalBaseUrl + "informTraveller/sendEmailToInformUserInfoChanged/" + email_to_send + "/" + username + "/" + newPwd + "/q0w1e9r2t8y3u7i4o6p5"));
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

        Debug.WriteLine("ws user info changed calling status code: "+(int)statusCode);

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
               Debug.WriteLine("Email sent to inform the pwd changed");
           }
           else {

               Debug.WriteLine("Email failed to send to inform the pwd changed");
           }

        }
    }

    protected async void change_password_btn_Click(object sender, EventArgs e)
    {

        
           // System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Both Password Must be the same!');", true);

       


       
    }
  
}