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
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Reporting.WebForms;
using Microsoft.Reporting.Common;
using Microsoft.Reporting;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using System.Net;
using System.IO;
using System.Diagnostics;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using System.Net.Mail;
using System.Web.UI.HtmlControls;

public partial class pages_common_register : System.Web.UI.Page
{

   // protected const string BasePath = "https://barterworld-ad75e.firebaseio.com/";
    //protected const string FirebaseSecret = "u8XCtop3XnzEmcmm9egRhLykr6UofkSREugvQsaL";
    private static FireSharp.FirebaseClient _client = db_connection.getFirebaseClientRef();
    public JavaScriptSerializer javaSerial = new JavaScriptSerializer();

    public string str_local_img_url = "";

    public bool just_registered = false;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack) { 
        
        }
        if (Session["user_email"] != null && Session["user_img"] != null && Session["user_name"] != null && Session["user_pwd"] != null)
        {
            System.Threading.Thread.Sleep(3000);
            // Control c = this.Master.FindControl("userMenu_btn");
            //HtmlImage img = Master.FindControl("profile_img_btn") as HtmlImage;
            //img.Src = Session["user_img"].ToString();
            //((Button)Master.FindControl("userMenu_btn")).Text = Session["user_name"].ToString();
            //lbl_useremail
           // ((Label)Master.FindControl("lbl_useremail")).Text = Session["user_email"].ToString();
            Response.Redirect("~/pages/Home.aspx");

        }
     
    }


    public string str_rand4digitcode = "";


    protected void check_verification_code(object o,EventArgs e) {

        Debug.WriteLine("at chk time verification code:" + str_rand4digitcode);
      if (verification_code.Text.Trim().ToString().Equals("") || verification_code.Text.ToString() == null)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please fill in verification code!');", true);
            Image_success.Visible = false;
            Image_error.Visible = true;
            verification_code.Enabled = true;

            lbl_select_profile_img.Visible = false;
            btn_register.Visible = false;
            btn_verify_code.Visible = true;
          

        }
      else if (verification_code.Text.Trim().ToString().Equals(Session["str_rand4digitcode"].ToString()))
      {
          txt_verify_code_hint.Visible = true;
          btn_check_code.Visible = false;
          FileUpload2.Visible = true;
          lbl_select_profile_img.Visible = true;
          verification_code.Enabled = false;
          new_user_pwd.Visible = true;
          new_user_pwd2.Visible = true;
          Image_success.Visible = true;
          Image_error.Visible = false;
          btn_register.Visible = true;
          btn_verify_code.Visible = false;

          
          txt_verify_code_hint.Text = "User Verified! Now You can start fill in information and register!";

      }
      else
      {
          verification_code.Enabled = true;
          lbl_select_profile_img.Visible = false;
          Image_success.Visible = false;
          Image_error.Visible = true;
          btn_register.Visible = false;
          btn_verify_code.Visible = true;

          System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Incorrect Verification Code! Please Check Your Email Again!');", true);

      }


       
    }

    protected void register_Click(object sender, EventArgs e)
    {
        string txt_username = new_user_name.Text.Trim().ToString();
        string txt_useremail = new_user_email.Text.Trim().ToString();
        string txt_userpwd = new_user_pwd.Text.Trim().ToString();
        string download_url_str = "";

 


            if (FileUpload2.HasFile)
            {
                string s = @"images\" + FileUpload2.FileName;
                FileUpload2.PostedFile.SaveAs(Server.MapPath(s));
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription("C:\\Program Files (x86)\\IIS Express\\traveller_web\\pages\\" + s + "")
     
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
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Select a profile picture!');", true);

                return;
            }

        if(new_user_email.Text=="" || new_user_email.Text==null){
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('User Email Can not be empty!');", true);
            return;
        }
        if (!this.new_user_email.Text.ToString().Contains("@") || !this.new_user_email.Text.ToString().Contains("."))
        {
           
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Sorry, Email is in invalid format!');", true);
            return;
        }

        if (new_user_name.Text == "" || new_user_name.Text == null)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Username Can not be empty!');", true);
            return;
        }
        if (new_user_pwd.Text == "" || new_user_pwd.Text == null)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('User Password Can not be empty!');", true);

        }

        if (new_user_pwd2.Text == "" || new_user_pwd2.Text == null)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Confirm Your Password!');", true);
            return;
        }
        if (new_user_pwd2.Text.Trim().Length<6 || new_user_pwd.Text.Trim().Length<6)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Password must be greater or equal to 6 characters!');", true);
            return;
        }
        if (!new_user_pwd.Text.ToString().Equals(new_user_pwd2.Text.ToString()))
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please ensure the both password are mathced!');", true);
            return;
        }


        Session["user_email"] = this.new_user_email.Text.ToString();
        Session["user_img"] = download_url_str;
        Session["user_name"] = this.new_user_name.Text.ToString();
        Session["user_pwd"] = this.new_user_pwd.Text.ToString();

            if (!new_user_pwd.Text.ToString().Equals(new_user_pwd2.Text.ToString()))
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please ensure the both password are mathced!');", true);

            }
            else
            {

               

                try
                {
                  


                    //////////////////////////////////img process
                    //Add New Traveller
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


             

                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Hi " + txt_username + ", " + respond_str + " ');", true);


                    //http://res.cloudinary.com/barterworld/image/upload/v1505614318/pro_ddcxbc.jpg

                }catch(Exception error){
                    Debug.WriteLine("Error msg:"+error);

                }

            }

       



       
    }


    protected void check_register_status(object o,EventArgs e) {
     

        /*
        Session["user_email"] = this.new_user_email.Text.ToString();
        Session["user_img"] = download_url_str;
        Session["user_name"] = this.new_user_name.Text.ToString();
        Session["user_pwd"] = this.new_user_pwd.Text.ToString();*/
    
    }

    protected void verirfy_Click(object o,EventArgs e){
       
        bool chk_username = true;
        bool chk_useremail = true;


        txt_verify_code_hint.Text = "Please wait, We are verifying...";

        string username_chk = new_user_name.Text.Trim().ToString();
        string useremail_chk = new_user_email.Text.Trim().ToString();

        Debug.WriteLine("user input email:"+useremail_chk);
        Debug.WriteLine("user input name:" + username_chk);
        if (new_user_name.Text == "" || new_user_name.Text == null) { txt_verify_code_hint.Text = "Sorry, Please fill in an Username to register"; chk_username = false; ; System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Fill in Username!');", true); return; }
        if (new_user_email.Text == "" || new_user_email.Text == null) { txt_verify_code_hint.Text = "Sorry, Please fill in an Email to register"; chk_useremail = false; System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Fill in User Email!');", true); return; }
     
        if(chk_useremail && chk_username ){
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
            List<string> registered_username_list=new List<string>();
            List<string> registered_useremail_list = new List<string>();
            
            foreach (var v in nodelist)
            {
                registered_username_list.Add(v.Element(ns + "User_name").Value);
                registered_useremail_list.Add(v.Element(ns + "User_email").Value);
                
            }
            foreach (string s in registered_username_list)
            {
                Debug.WriteLine(s+" =? "+username_chk);
                if(username_chk==s){

                    txt_verify_code_hint.Text = "Sorry, Username has already been registered! Please change another one!";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Sorry!, The username "+username_chk+" has already been registered! Please change another one!');", true);

                    return;
                }

            }
            foreach (string s in registered_useremail_list)
            {
                Debug.WriteLine(s + " =? " + useremail_chk);
                if (useremail_chk == s)
                {
                    txt_verify_code_hint.Text = "Sorry, Email has already been registered! Please change another one!";
                   
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Sorry! Dear Traveller "+username_chk+" , Your Email Address ["+useremail_chk+"] has already been registered, Please change another one!');", true);

                    return;
                }

            }

        }
        //now just start to send email for the verification code
        //traveller.borneo.tour@gmail.com

        Random ar = new Random();
        int randomInt = ar.Next(1000, 10000);//4digit >=1000  and <=9999
         str_rand4digitcode = randomInt.ToString();
         Session["str_rand4digitcode"] = str_rand4digitcode;
         Debug.WriteLine("verification coe:" +str_rand4digitcode);
         
        string getVerifyCode = sendEmailfromWSToValidate(useremail_chk,str_rand4digitcode);
        if (getVerifyCode == "1")
        {
            txt_verify_code_hint.Text = "Verification Code has been sent to your email address "+useremail_chk+", Please grab it and fill it in above";

            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Check Your Traveller Email and get the random generated 4 digit code for Verification!');", true);


            txt_verify_code_hint.Visible = true;
            txt_verify_code_hint.Text = "Check Your Traveller Email and get the random generated 4 digit code for Verification!";

            btn_check_code.Visible = true;
        }
        else {
            txt_verify_code_hint.Visible = true;
            txt_verify_code_hint.Text = "Email Failed to sent...";
            
        }

         

    }



    public string sendEmailfromWSToValidate(String email, string digit)
    {
        string response_digit = "";
       
        try
        {
            var http = (HttpWebRequest)WebRequest.Create(new Uri("" + db_connection.travellerWSlocalBaseUrl + "informTraveller/sendRegistrationVerificationCodeToUserEmail/" + email + "/"+digit+ "/q0w1e9r2t8y3u7i4o6p5"));
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
            response_digit = xDoc.Element(ns + "string").Value.ToString();


            
                 return response_digit;
          
           
          


        }
        catch (Exception ex)
        {

            txt_verify_code_hint.Visible = true;
            txt_verify_code_hint.Text = "Could not send email\n\n" + ex.ToString();
            return response_digit;
        }


    }






    public void getProfileImgUrl(object o, EventArgs e) {
        Debug.WriteLine("called set img url");
        if (FileUpload2.HasFile)
        {
            Debug.WriteLine("called set img url got file dy");
            Stream fs = FileUpload2.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(fs);
            byte[] fileBytes = br.ReadBytes((Int32)fs.Length);

            string base64String = Convert.ToBase64String(fileBytes, 0, fileBytes.Length);
            new_user_img.ImageUrl = "data:image/png;base64," + base64String;
            str_local_img_url = "data:image/png;base64," + base64String;
        }
        else {
            Debug.WriteLine("no file still");
           // new_user_img.ImageUrl = "~/images/profile.png";
            //str_local_img_url = "~/images/profile.png";
        }
        
    }


    protected void log_Click(object sender, EventArgs e) {
        Response.Redirect("~/pages/login.aspx");
    }
   // List<barter> barter_list = new List<barter>();
    /*
    protected async void redirect_home(object sender, EventArgs e)
    {

        var json = Newtonsoft.Json.JsonConvert.SerializeObject(new
        {
            barter_img = "https://i.imgur.com/5WXYz4M.png",
            description = "test",

            latitude = "12",
            like_count = "2",
            longitude = "12",
            time = "121",
            title = "test",
            type = "test",
            uid = "12131231",
            username = "test",
            value = "test"
        });
        var request = WebRequest.CreateHttp("https://barterworld-ad75e.firebaseio.com/Barter_Posts/.json");
        request.Method = "POST";
        request.ContentType = "application/json";
        var buffer = Encoding.UTF8.GetBytes(json);
        request.ContentLength = buffer.Length;
        request.GetRequestStream().Write(buffer, 0, buffer.Length);
        var response = request.GetResponse();
        json = (new StreamReader(response.GetResponseStream())).ReadToEnd();
        // TODO: parse response (contained in `json` variable) as appropriate
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('" + json + "');", true);
           
           
        }*/
      
}