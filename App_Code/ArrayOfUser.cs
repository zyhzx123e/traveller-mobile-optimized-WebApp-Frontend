using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

/// <summary>
/// Summary description for ArrayOfUser
/// </summary>
public class ArrayOfUser
{

    [XmlElement(ElementName = "User")]
    public User[] User { get; set; }    
	public ArrayOfUser()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}