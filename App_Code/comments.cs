using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

/// <summary>
/// Summary description for comments
/// </summary>
public class comments
{

    [JsonIgnore]
    public string comment_ref_id { get; set; }


    [JsonProperty("comment_uid")]
    public string comment_uid { get; set; }

    [JsonProperty("comment_user_img")]
    public string comment_user_img { get; set; }

    [JsonProperty("comment_user_name")]
    public string comment_user_name { get; set; }

    [JsonProperty("comment_content")]
    public string comment_content { get; set; }


    public comments(string ref_id,string uid,string user_img,string user_name,string content)
    {
        this.comment_ref_id = ref_id;
        this.comment_uid = uid;
        this.comment_user_name = user_name;
        this.comment_user_img = user_img;
        this.comment_content = content;
    
    }


	public comments()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}