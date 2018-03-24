using System;
using System.Collections.Generic;

using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

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


using Microsoft.Reporting.WebForms;
using Microsoft.Reporting.Common;
using Microsoft.Reporting;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

public class db_connection
{


    public static Account account = new Account(
  "barterworld",
  "278537315912519",
  "xnrG3tJRR1UIVbvxYrGDTYe6L5Q");

   public static Cloudinary cloudinary = new Cloudinary(account);


    protected const string BasePath = "https://barterworld-ad75e.firebaseio.com/";
    protected const string FirebaseSecret = "u8XCtop3XnzEmcmm9egRhLykr6UofkSREugvQsaL";

    public static int contentHTTPlength = 0;//http://traveller-001-site1.1tempurl.com/service/
    public  const string travellerWSlocalBaseUrl = "http://localhost:32133/service/";//"http://localhost:51427";
    //public const string travellerWSlocalBaseUrl = "http://nbtraveller-001-site1.1tempurl.com/service/";//"http://localhost:51427";

    public static FireSharp.FirebaseClient _client;


    public SqlConnection connection;
    string connectionString;


	public db_connection()
	{

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = FirebaseSecret,
            BasePath = BasePath
        };

        _client = new FireSharp.FirebaseClient(config); //Uses JsonNet default
     
	}

    public static FireSharp.FirebaseClient getFirebaseClientRef()
    {

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = FirebaseSecret,
            BasePath = BasePath
        };

        _client = new FireSharp.FirebaseClient(config); //Uses JsonNet default

        return _client;
    
    }

  

}