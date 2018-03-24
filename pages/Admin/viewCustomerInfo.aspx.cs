using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

using Microsoft.Reporting.WebForms;
using Microsoft.Reporting.Common;
using Microsoft.Reporting;

using System.Data;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Drawing;
using FireSharp.Response;
using System.Xml.Linq;
using System.Xml.Xsl;
using System.Text;
using System.Xml.XPath;

public partial class viewCustomer : System.Web.UI.Page
{

    public List<_user> user_get;
    public string[] name_array;


    protected void Page_Load(object sender, EventArgs e)
    {

      
////////////////////////////////////calling api
        if (Session["admin_id"] == null )
        {

            /*
             c# - How to access session variables from any class in ASP.NET? - Stack Overflow. 2016. 
             * c# - How to access session variables from any class in ASP.NET? - Stack Overflow. 
             * [ONLINE] Available at: http://stackoverflow.com/questions/621549/how-to-access-session-variables-from-any-class-in-asp-net. [Accessed 01 Nov 2017].
             */

            Response.Redirect("~/pages/login.aspx");
        }



        if(!IsPostBack)
        {
            //populate_items();
            bind_bind_data_xsl();


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
        }


     
       
    }





    public void bind_bind_data_xsl() {

        var http1 = (HttpWebRequest)WebRequest.Create(new Uri("" + db_connection.travellerWSlocalBaseUrl + "Users/getAllTravellers/q0w1e9r2t8y3u7i4o6p5"));
        http1.Accept = "text/xml";
        http1.ContentType = "text/xml; charset=utf-8";
        http1.Method = "GET";

        var response1 = http1.GetResponse();

        var stream1 = response1.GetResponseStream();
        var sr1 = new StreamReader(stream1);
        string content1 = sr1.ReadToEnd();

        content1.Replace("<userReturn xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">", "<userReturn>");

      

        StringReader rdr = new StringReader(content1);
        XPathDocument xdoc = new XPathDocument(rdr);




        XDocument doc_traveller = XDocument.Parse(content1);
        //get xml from webservice

        var root= doc_traveller.Root;
        var user_list = doc_traveller.Root.Nodes();


        var xDoc1 = XDocument.Parse(content1);

        var ns = xDoc1.Root.Name.Namespace;

        var nodelist = xDoc1.Element(ns + "userReturn").Elements(ns + "uList").Elements(ns + "User");


        /*
           XsltArgumentList xslArg = new XsltArgumentList();
            xslArg.AddParam("stuff_id", "", itemid);

         */

        XslCompiledTransform transform = new XslCompiledTransform();
        transform.Load(Server.MapPath("~/pages/Customer/xml_xsl/travellers.xslt"));
        StringWriter sw = new StringWriter();
        //transform it
        transform.Transform(xdoc, null, sw);
        string result = sw.ToString();

        //remove namespace
        result = result.Replace("xmlns:asp=\"remove\"", "");
        //parse control
        Control ctrl = Page.ParseControl(result);
          user_ph.Controls.Clear();
        user_ph.Controls.Add(ctrl);








    }


    protected void displayAllCustomer(object sender, EventArgs e)
    {
        displayAllUser();
    }

    protected void displayAllUser()
    {
        bind_bind_data_xsl();
    }


     
   

    public string convert_pwd_asterisk(string str){
        int count = 0;
        foreach (char c in str)
        {
           count++;
        }

        string pwd_as="";

        for (int i = 0; i < count;i++ )
        {
            pwd_as += @"*";

        }
        return pwd_as;


    }

     


    private void MessageBoxShow(string message)
    {
        this.AlertBoxMessage.InnerText = message;
        this.AlertBox.Visible = true;
    }

   
    private static FireSharp.FirebaseClient _client = db_connection.getFirebaseClientRef();


     
     







    protected void namesDropList_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selected_user=(namesDropList.SelectedValue).ToString().Trim();

        Debug.WriteLine("=============================================================================selected user : "+selected_user);
        XsltArgumentList xslArg = new XsltArgumentList();
        xslArg.AddParam("selected_traveller", "", selected_user);

        var http1 = (HttpWebRequest)WebRequest.Create(new Uri("" + db_connection.travellerWSlocalBaseUrl + "Users/getAllTravellers/q0w1e9r2t8y3u7i4o6p5"));
        http1.Accept = "text/xml";
        http1.ContentType = "text/xml; charset=utf-8";
        http1.Method = "GET";

        var response1 = http1.GetResponse();

        var stream1 = response1.GetResponseStream();
        var sr1 = new StreamReader(stream1);
        string content1 = sr1.ReadToEnd();


        content1.Replace("<userReturn xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">", "<userReturn>");


 

        StringReader rdr = new StringReader(content1);
        XPathDocument xdoc = new XPathDocument(rdr);




        XDocument doc_traveller = XDocument.Parse(content1);
        //get xml from webservice

        var root = doc_traveller.Root;
        var user_list = doc_traveller.Root.Nodes();


        var xDoc1 = XDocument.Parse(content1);

        var ns = xDoc1.Root.Name.Namespace;

        var nodelist = xDoc1.Element(ns + "userReturn").Elements(ns + "uList").Elements(ns + "User");


        /*
           XsltArgumentList xslArg = new XsltArgumentList();
            xslArg.AddParam("stuff_id", "", itemid);

         */

        XslCompiledTransform transform = new XslCompiledTransform();
        transform.Load(Server.MapPath("~/pages/Customer/xml_xsl/travellers_filter.xslt"));
        StringWriter sw = new StringWriter();
        //transform it
        transform.Transform(xdoc, xslArg, sw);
        string result = sw.ToString();

        //remove namespace
        result = result.Replace("xmlns:asp=\"remove\"", "");
        //parse control
        Control ctrl = Page.ParseControl(result);
        user_ph.Controls.Clear();
        user_ph.Controls.Add(ctrl);


    }

}