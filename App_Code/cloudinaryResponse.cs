using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cloudinaryResponse
/// </summary>
public class cloudinaryResponse
{



    public string public_id { get; set; }
    public int version { get; set; }
    public string signature { get; set; }
    public int width { get; set; }
    public int height { get; set; }
    public string format { get; set; }
    public string resource_type { get; set; }
    public DateTime created_at { get; set; }
    public int bytes { get; set; }
    public string type { get; set; }
    public string url { get; set; }
    public string secure_url { get; set; }

	public cloudinaryResponse()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}