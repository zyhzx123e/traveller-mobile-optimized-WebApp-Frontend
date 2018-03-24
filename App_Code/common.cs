using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for common
/// </summary>
public class common
{

    public static string get_random_string(int length_of_string) {
        string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
        string numbers = "1234567890";

        string characters = numbers;
       
            characters += alphabets + small_alphabets + numbers;
        
        int length = length_of_string;//; set the random string length
        string otp = string.Empty;
        for (int i = 0; i < length; i++)
        {
            string character = string.Empty;
            do
            {
                int index = new Random().Next(0, characters.Length);
                character = characters.ToCharArray()[index].ToString();
            } while (otp.IndexOf(character) != -1);
            otp += character;
        }

        return otp;
    }



    public static string getUserImgUrlFromUsername(string username) {
        string user_img_url = "";


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
        List<string> registered_username_list = new List<string>();
        // List<string> registered_useremail_list = new List<string>();

        bool chk_user_exit = false;
        foreach (var v in nodelist)
        {

            if (username.Equals(v.Element(ns + "User_name").Value.ToString())) {
                user_img_url = v.Element(ns + "User_profile_img").Value.ToString();
            }
            
        }


        return user_img_url;

    }


    public common()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}