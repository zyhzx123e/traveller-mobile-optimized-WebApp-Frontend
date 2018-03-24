using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

/// <summary>
/// Summary description for User
/// </summary>
[XmlRoot(ElementName = "User")]
[Serializable]
public class User
{

    [XmlElement("User_name")]
    public string User_name { get; set; }

    [XmlElement("User_email")]
    public string User_email { get; set; }

    [XmlElement("User_pwd")]
    public string User_pwd { get; set; }

    public User(string username, string useremail, string userpwd) {
        this.User_name = username;
        this.User_email = useremail;
        this.User_pwd = userpwd;
    }

	public User()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}