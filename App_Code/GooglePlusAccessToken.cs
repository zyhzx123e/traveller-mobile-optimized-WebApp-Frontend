using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GooglePlusAccessToken
/// 
/// 
/// 
/// 
/// client id: 538691666942-9sbbc782j685ept05avqok8ftgdrvvei.apps.googleusercontent.com
/// client token: aTCDJSslmZAa1DbGz5sFB8td
/// </summary>
public class GooglePlusAccessToken
{
    public string access_token { get; set; }
    public string token_type { get; set; }
    public int expires_in { get; set; }
    public string id_token { get; set; }
    public string refresh_token { get; set; }
    public GooglePlusAccessToken()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}