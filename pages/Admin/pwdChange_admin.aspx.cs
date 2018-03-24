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
using System.Net;
using System.IO;
using System.Xml.Linq;
using System.Diagnostics;

public partial class pwdChange_admin : System.Web.UI.Page
{
    public int count = 0;

    public string admin_id_get;
    public string admin_pwd_get;
    public string admin_loggedin_get;

    _user userObject = new _user();


    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["admin_id"]==null) {
            Response.Redirect("~/pages/login.aspx");
        }
      
        if (!IsPostBack)
        {
          

            admin_id_get = Session["admin_id"].ToString();
            admin_pwd_get = Session["admin_pwd"].ToString();
      
        }
      //  if (admin_id_get == null) { Response.Redirect("~/pages/login.aspx"); }
    }



    //return true : success validation
    private bool validateOldPwd(string oldPwd) {
        bool return_str = false;


        try
        {
            var http = (HttpWebRequest)WebRequest.Create(new Uri("" + db_connection.travellerWSlocalBaseUrl + "Users/getSpecificAdminByID/" + Session["admin_id"].ToString() + "/q0w1e9r2t8y3u7i4o6p5"));
            http.Accept = "text/xml";
            http.ContentType = "text/xml; charset=utf-8";
            http.Method = "GET";

            var response = http.GetResponse();

            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            string content = sr.ReadToEnd();
            Debug.WriteLine(content);

            XDocument doc = XDocument.Parse(content);

            var r = doc.Root;
            var u = doc.Root.Nodes();


            var xDoc1 = XDocument.Parse(content);

            var ns1 = xDoc1.Root.Name.Namespace;

            string get_pwd = xDoc1.Element(ns1 + "adminReturn").Element(ns1 + "adminList").Element(ns1 + "admin").Element(ns1 + "Admin_pwd").Value.ToString();


            Debug.WriteLine("pwd get================= "+get_pwd);



            if (oldPwd.Equals(get_pwd))
            {
                return_str = true;
                //validation success

            }
            else {
                msg.Visible = true;
                msg.Text = "Admin old password is incorrect!\n\n";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Admin old password is incorrect!');", true);


            }


        }
        catch (Exception ex)
        {

            msg.Visible = true;
            msg.Text = "Admin Credential validation failed! \n\n" + ex.ToString();

        }

        return return_str;

    }



    //return true : success update
    private bool updateOldPwd(string oldPwd,string newPwd)
    {
        bool return_str = false;

        if (validateOldPwd(oldPwd)) {
            try
            {
                var http = (HttpWebRequest)WebRequest.Create(new Uri("" + db_connection.travellerWSlocalBaseUrl + "Users/updateAdmin/" + Session["admin_id"].ToString() + "/"+newPwd+ "/q0w1e9r2t8y3u7i4o6p5"));
                http.Accept = "text/xml";
                http.ContentType = "text/xml; charset=utf-8";
                http.Method = "PUT";
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
                string get_response = xDoc.Element(ns + "strReturn").Element(ns + "str").Value.ToString();

                msg.Visible = true;
                msg.Text = "" + get_response + " \n\n";
                return_str = true;
                    //  update success


            }
            catch (Exception ex)
            {

                msg.Visible = true;
                msg.Text = "Admin Password Update failed! \n\n" + ex.ToString();

            }


        }


        return return_str;

    }



    protected   void changePassword(string admin_id, string oldPassword ,string newPassword)
    {

        if (updateOldPwd(oldPassword,newPassword)) { 

        try
        {
            var http = (HttpWebRequest)WebRequest.Create(new Uri("" + db_connection.travellerWSlocalBaseUrl + "informAdmin/sendEmailInformAdminPwdChanged/" + newPassword + "/"+ admin_id + "/q0w1e9r2t8y3u7i4o6p5"));
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
            string response_digit = xDoc.Element(ns + "string").Value.ToString();

            if (response_digit.Equals("1")) {
                    Debug.WriteLine("email sent to developer for the password change\n\n");
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Admin Password updated successfully!');", true);

                }


            }
        catch (Exception ex)
        {

         
            Debug.WriteLine( "Could not send email\n\n" + ex.ToString());
        
        }
        }

    }
     
    protected async void change_password_btn_Click(object sender, EventArgs e)
    {

        string admin_id = admin_id_get;
        string admin_old_password = old_pass.Text.ToString().Trim();
        string admin_new_password = new_pass.Text.ToString().Trim();
        string admin_verify_new_password = verify_new_pass.Text.ToString().Trim();


        if (admin_new_password.Equals(admin_verify_new_password))
        {
            changePassword(Session["admin_id"].ToString(), admin_old_password, admin_new_password);
        }
        else {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Both Password Must be the same!');", true);

        }


       
    }
 

    protected void emptyForm()
    {
        old_pass.Text = "";
        new_pass.Text = "";
        verify_new_pass.Text = "";
    }
}