using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for share_item
/// </summary>
public class share_item
{

    /* <place_id>place1</place_id>
    <place_img>http://res.cloudinary.com/barterworld/image/upload/v1511101482/fbsaiage0nr1rd3q0utw.jpg</place_img>
    <place_title>Sabah Golf Country Club</place_title>
    <place_name>SGCC</place_name>
    <place_description>Super Fancy</place_description>
    <place_time_upload>2017-11-11 14:30:20</place_time_upload>
    <place_uid>eminem9379</place_uid>
    <place_user_img>http://res.cloudinary.com/barterworld/image/upload/v1510754153/eminem_i6j2lk.jpg</place_user_img>
    <place_longitude>116.102614</place_longitude>
    <place_latitude>5.956260</place_latitude>
    <place_address>Sabah Golf and Country Club</place_address>
    <place_like_count>2</place_like_count>*/

    public string place_id { get; set; }
    public string place_img { get; set; }
    public string place_title { get; set; }
    public string place_name { get; set; }
    public string place_description { get; set; }
    public string place_time_upload { get; set; }
    public string place_uid { get; set; }
    public string place_user_img { get; set; }
    public string place_longitude { get; set; }
    public string place_latitude { get; set; }
    public string place_address { get; set; }
    public string place_like_count { get; set; }



    /*
   string place_id,  string place_img, string place_title, string place_name,string place_description,string place_time_upload ,string place_uid,string place_user_img,string place_longitude,string place_latitude,string place_address,string place_like_count 
         
         
         
         */

    public share_item() {

    }

    public share_item(string place_id,string place_img, string place_title, string place_name, 
        string place_description, string place_time_upload, string place_uid, string place_user_img, 
        string place_longitude, string place_latitude, string place_address, string place_like_count )
    {
        this.place_id = place_id;
        this.place_img = place_img;
        this.place_title = place_title;
        this.place_name = place_name;
        this.place_description = place_description;
        this.place_time_upload = place_time_upload;

        this.place_uid = place_uid;
        this.place_user_img = place_user_img;
        this.place_longitude = place_longitude;
        this.place_latitude = place_latitude;
        this.place_address = place_address;
        this.place_like_count = place_like_count;

    }
}