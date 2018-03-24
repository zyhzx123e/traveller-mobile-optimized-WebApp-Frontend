using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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

public partial class Master_pages_base : System.Web.UI.MasterPage
{

    public  void changeBG_admin()
    {
        base_body.Style.Add("background-image", "url('bg_admin.jpg')");
      
    }

   

    public void bg() {

        base_body.Style.Add("background-image", "url('bg.jpg')");
        /*
         The Official Forums for Microsoft ASP.NET. . Set background-image of body in code-behind file | The ASP.NET Forums. [ONLINE] Available at: https://forums.asp.net/t/1878343.aspx?Set+background+image+of+body+in+code+behind+file. 
         * [Accessed 09 September 2017].
         */
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["admin_id"] != null)
        {
            changeBG_admin();
        }
        else if (Session["user_name"] != null)
        {
            bg();

        }
        else
        {
            bg();

        }
       
        //homeLink.NavigateUrl = ResolveUrl("~/pages/home.aspx");
        
      //  System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('position:  " + Session["position"] + "y!');", true);
              
      //  Response.Write(Session["position"]);

      
    }


    

}
