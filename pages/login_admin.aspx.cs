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
using System.Xml.Linq;

public partial class pages_admin_login : System.Web.UI.Page
{

   // protected const string BasePath = "https://barterworld-ad75e.firebaseio.com/";
    //protected const string FirebaseSecret = "u8XCtop3XnzEmcmm9egRhLykr6UofkSREugvQsaL";
    private static FireSharp.FirebaseClient _client = db_connection.getFirebaseClientRef();

   
    protected void Page_Load(object sender, EventArgs e)
    {
       
     
    }



   
   
    protected  void log_Click(object _sender, EventArgs e) {

      
        string username= iDNumber.Text.Trim().ToString();
         string userpwd= password.Text.Trim().ToString();
         bool condition1 = true;
         bool condition2 = true;
        try
        {

            if (username==null || username=="")
            {
                msg.Text = "Admin Id can not be empty or null";
              
                condition1 = false;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please fill in Admin ID!');", true);
              
             
       
            }
            if (userpwd==null || userpwd=="")
            {
                msg.Text = "Admin Password can not be empty or null";
                condition2 = false;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please fill in Admin Password!');", true);
               
               
                
            }

            if(!condition1 && !condition2){
                msg.Text = "Please fill in both Admin ID and Admin Password";
              
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please fill in all the Admin info. in order to login!');", true);
                 return;
            }

            if(condition2 && condition1){
                if (login_ws(username, userpwd))
                {

                    Response.Redirect("~/pages/Home.aspx");
                }
                else {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Log in failed! Please check your credential again! If problem persists, Please contact our admin : 'traveller.borneo.tour@gmail.com'  or  call Traveller hotline : 60-16-6028563');", true);
         
                }
            
            }

         

        }
        catch (Exception ex)
        {

            Debug.WriteLine(ex.Message);
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('The login process was unsuccessful, for more information please contact the administrator.');", true);
           
             }
    
    }


    public bool login_ws(string uid, string pwd) {

        bool ok = false;


        var http = (HttpWebRequest)WebRequest.Create(new Uri("" + db_connection.travellerWSlocalBaseUrl + "Users/getAllAdmins/q0w1e9r2t8y3u7i4o6p5"));
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

        var nodelist = xDoc.Element(ns + "adminReturn").Elements(ns + "adminList").Elements(ns + "admin");
        List<string> registered_username_list = new List<string>();
        // List<string> registered_useremail_list = new List<string>();

        bool chk_user_exit = false;
        foreach (var v in nodelist)
        {
            registered_username_list.Add(v.Element(ns + "Admin_id").Value);
        }

        foreach (string name in registered_username_list)
        {
            if (uid == name)
            {
                
                msg.Text = "Admin ID Found...We are verifying your password";
                chk_user_exit = true;
                var http1 = (HttpWebRequest)WebRequest.Create(new Uri("" + db_connection.travellerWSlocalBaseUrl + "Users/getSpecificAdminByID/" + uid + "/q0w1e9r2t8y3u7i4o6p5"));
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

                string get_pwd = xDoc1.Element(ns1 + "adminReturn").Element(ns1 + "adminList").Element(ns1 + "admin").Element(ns1 + "Admin_pwd").Value.ToString();
                if (get_pwd == pwd)
                {
                     
                    msg.Text = "Admin Verified! Directing...";
                    ok = true;

                    Session["admin_id"] = xDoc1.Element(ns1 + "adminReturn").Element(ns1 + "adminList").Element(ns1 + "admin").Element(ns1 + "Admin_id").Value.ToString();
                    Session["admin_pwd"] = xDoc1.Element(ns1 + "adminReturn").Element(ns1 + "adminList").Element(ns1 + "admin").Element(ns1 + "Admin_pwd").Value.ToString();
                    Session["admin_img"] = "http://res.cloudinary.com/barterworld/image/upload/v1505692260/admin_jqi4jo.png";
                    return ok;

                }
                else 
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('The Admin Password for Admin " + uid + " is incorrect! Please check again!');", true);
           
                    ok = false;
                    return ok;
                }

            }  
        }

        if (chk_user_exit==false)
        {

            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('The Admin Entered : " + uid + " does not exist! Please check again!');", true);
           
            ok = false;
            return ok;
        }

        return ok;

       

    
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