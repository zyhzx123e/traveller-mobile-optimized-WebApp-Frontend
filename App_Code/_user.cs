using System;
using System.Collections.Generic;

using System.Web;
using System.Data.SqlClient;
using Newtonsoft.Json;


public class _user
{

    [JsonIgnore]
    public string uid { get; set; }

    [JsonProperty("user_email")]
    public string user_email { get; set; }

    [JsonProperty("user_img")]
    public string user_img { get; set; }

    [JsonProperty("user_name")]
    public string user_name { get; set; }

    [JsonProperty("user_pwd")]
    public string user_pwd { get; set; }
  
    /*
     c# 3.0 - Store data into Objects based on the input C# - Stack Overflow. 
     * . c# 3.0 - Store data into Objects based on the input C# - Stack Overflow. [ONLINE] Available at: http://stackoverflow.com/questions/4209964/store-data-into-objects-based-on-the-input-c-sharp. 
     * [Accessed 08 September 2017].
     */


	public _user()
	{
		
	}

    public _user(string img, string name, string email,string pwd){
        this.user_img = img;
        this.user_name = name;
        this.user_email = email;
        
       
        this.user_pwd = pwd;
}





  

}