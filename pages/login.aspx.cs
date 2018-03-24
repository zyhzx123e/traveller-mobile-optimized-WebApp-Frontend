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
 

public partial class pages_common_login : System.Web.UI.Page
{
      
    private static FireSharp.FirebaseClient _client = db_connection.getFirebaseClientRef();
    //1076138504561-bbjrshjle3prhiabc60ko89i90tgk4q3.apps.googleusercontent.com
    protected string googleplus_client_id = "1076138504561-bbjrshjle3prhiabc60ko89i90tgk4q3.apps.googleusercontent.com";    // google+ api Client ID
    protected string googleplus_client_sceret = "g4wx9abice-OmXKOj3O7vwpH";                                                // google+ api  Client Secret
                                                                                                                           //g4wx9abice-OmXKOj3O7vwpH    
                                                                                                                           //to change this redirect url , need to go in developer console change this path at same time
                                                                                                                           //old secret: IyKn-emPbaq5NJb3dm2L4J12
                                                                                                                           //old client id: 226940384162-kq3062rpe64s8go8bh5ifsm8e95k34ce.apps.googleusercontent.com
    protected string googleplus_redirect_url_local = "http://localhost:54341/pages/Home.aspx";
    // google+ api  Client Secret
    protected string googleplus_redirect_url = "http://nbtravellerfront-001-site1.1tempurl.com/pages/Home.aspx";
    
    //  Redirect URL; Redirect URL from 
    protected string Parameters;

    protected void Page_Load(object sender, EventArgs e)
    {
       // google_log();


    }

 

     
    protected void Google_Click(object sender, EventArgs e)
    {
        var Googleurl = "https://accounts.google.com/o/oauth2/auth?response_type=code&redirect_uri=" + googleplus_redirect_url + "&scope=https://www.googleapis.com/auth/userinfo.email%20https://www.googleapis.com/auth/userinfo.profile&client_id=" + googleplus_client_id;
        Session["loginWith"] = "google";
        Response.Redirect(Googleurl);
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
               
                condition1 = false;
              
               // Image_error_id.Visible = true;
              
            }
            if (userpwd==null || userpwd=="")
            {
            
                condition2 = false;
                
               // Image_error_pwd.Visible = true;
             }

            if(!condition1 && !condition2){

                msg.Text = "Please fill in both username/Email and password";

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please fill in all the account info. in order to login!');", true);
             
            }else if(!condition1){

                msg.Text = "Please fill in username or Email";

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please fill in Username!');", true);
                
               
            }
            else if (!condition2)
            {
                msg.Text = "Please fill in password";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please fill in Password!');", true);
               
            }

            if(condition2 && condition1){
                if (login_ws(username, userpwd))
                {
                  
                    if (Session["saved_redirect_page_after_login"] == null)
                    {
                        Response.Redirect("~/pages/Home.aspx");
                    }
                    else {
                        Response.Redirect(Session["saved_redirect_page_after_login"].ToString());
                    }
                }
                else {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Log in failed! Please check your credential again! If problem persists, Please contact our admin : 'traveller.borneo.tour@gmail.com'  or  call Traveller hotline : 60-16-6028563');", true);
         
                }
            
            }
         
          


        }
        catch (Exception ex)
        {

            msg.Text = "The login process was unsuccessful, for more information please contact the administrator.";

            Debug.WriteLine(ex.Message);
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('The login process was unsuccessful, for more information please contact the administrator.');", true);


        }
    
    }


    public bool login_ws(string uid, string pwd) {

        bool ok = false;



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
        Debug.WriteLine("=======================================================got namespace : "+ns);

        var nodelist = xDoc.Element(ns + "userReturn").Elements(ns + "uList").Elements(ns + "User");
        List<string> registered_username_list = new List<string>();
        List<string> registered_email_list = new List<string>();
        // List<string> registered_useremail_list = new List<string>();

        bool chk_user_exit = false;
        foreach (var v in nodelist)
        {
            registered_username_list.Add(v.Element(ns + "User_name").Value);
            registered_email_list.Add(v.Element(ns + "User_email").Value);
        }

        foreach (string name in registered_username_list)
        {
            if (uid == name)
            {

                msg.Text = "User " + uid + " found...";


                chk_user_exit = true;
                var http1 = (HttpWebRequest)WebRequest.Create(new Uri("" + db_connection.travellerWSlocalBaseUrl + "Users/getSpecificTravellerByUID/" + uid + "/q0w1e9r2t8y3u7i4o6p5"));
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

                string get_pwd = xDoc1.Element(ns1 + "userReturn").Element(ns1 + "uList").Element(ns1 + "User").Element(ns1 + "User_pwd").Value.ToString();
                if (get_pwd == pwd)
                {

                    msg.Text = "User " + uid + " verified, We are directing you to Traveller Home...";

                    ok = true;

                    Session["user_email"] = xDoc1.Element(ns1 + "userReturn").Element(ns1 + "uList").Element(ns1 + "User").Element(ns1 + "User_email").Value.ToString();
                    Session["user_img"] = xDoc1.Element(ns1 + "userReturn").Element(ns1 + "uList").Element(ns1 + "User").Element(ns1 + "User_profile_img").Value.ToString();
                    Session["user_name"] = xDoc1.Element(ns1 + "userReturn").Element(ns1 + "uList").Element(ns1 + "User").Element(ns1 + "User_name").Value.ToString();
                    Session["user_pwd"] = xDoc1.Element(ns1 + "userReturn").Element(ns1 + "uList").Element(ns1 + "User").Element(ns1 + "User_pwd").Value.ToString();
                    return ok;

                }
                else
                {
                    msg.Text = "User id " + uid + " found, but password is incorrect!";


                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('The User Password for user " + uid + " is incorrect! Please check again!');", true);

                    ok = false;
                    return ok;
                }

            }
            else {

                foreach (string email in registered_email_list)
                {
                    if (uid == email)
                    {

                        msg.Text = "User " + uid + " found...";


                        chk_user_exit = true;
                        var http1 = (HttpWebRequest)WebRequest.Create(new Uri("" + db_connection.travellerWSlocalBaseUrl + "Users/getSpecificTravellerByEmail/" + uid + "/q0w1e9r2t8y3u7i4o6p5"));
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

                        string get_pwd = xDoc1.Element(ns1 + "userReturn").Element(ns1 + "uList").Element(ns1 + "User").Element(ns1 + "User_pwd").Value.ToString();
                        if (get_pwd == pwd)
                        {

                            msg.Text = "User " + uid + " verified, We are directing you to Traveller Home...";

                            ok = true;

                            Session["user_email"] = xDoc1.Element(ns1 + "userReturn").Element(ns1 + "uList").Element(ns1 + "User").Element(ns1 + "User_email").Value.ToString();
                            Session["user_img"] = xDoc1.Element(ns1 + "userReturn").Element(ns1 + "uList").Element(ns1 + "User").Element(ns1 + "User_profile_img").Value.ToString();
                            Session["user_name"] = xDoc1.Element(ns1 + "userReturn").Element(ns1 + "uList").Element(ns1 + "User").Element(ns1 + "User_name").Value.ToString();
                            Session["user_pwd"] = xDoc1.Element(ns1 + "userReturn").Element(ns1 + "uList").Element(ns1 + "User").Element(ns1 + "User_pwd").Value.ToString();
                            return ok;

                        }
                        else
                        {
                            msg.Text = "User id " + uid + " found, but password is incorrect!";


                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('The User Password for user " + uid + " is incorrect! Please check again!');", true);

                            ok = false;
                            return ok;
                        }

                    }

                }


             }
         
        }

        if (chk_user_exit==false)
        {

            msg.Text = "User " + uid + " does not exist!";
                 
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('The User Entered : "+uid+" does not exist! Please check again!');", true);
           
            ok = false;
            return ok;
        }

        return ok;

       

    
    }
     

    protected void register_Click(object sender, EventArgs e)
    {
        Response.Redirect("register.aspx");
    }
   
      
}