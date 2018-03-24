using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for weather
/// </summary>
public class weather
{

  public  string nowTempC { get; set; }//1
  public string todayDate { get; set; }//2
  public string todayMaxTempC { get; set; }//3
  public string todayMinTempC { get; set; }//4
  public string todaySunRiseTime { get; set; }//5
  public string todaySunSetTime { get; set; }//6
  public string todayHumidity { get; set; }//7
  public string todayWeatherDesc { get; set; }//8
  public string todayWeatherIconUrl { get; set; }//9
  public string todayWindSpeedKmph { get; set; }//10

  public string tmrDate { get; set; }//11
  public string tmrMaxTempC { get; set; }//12
    public string tmrMinTempC { get; set; }//13
    public string tmrSunRiseTime { get; set; }//14
    public string tmrSunSetTime { get; set; }//15


    public weather(string nowTempC, string todayDate,string todayMaxTempC,string todayMinTempC, string todaySunRiseTime, 
        string todaySunSetTime,string todayHumidity,string todayWeatherDesc,string todayWeatherIconUrl,
        string todayWindSpeedKmph,   string tmrDate,string tmrMaxTempC, string tmrMinTempC,string tmrSunRiseTime, string tmrSunSetTime) {
            
        this.nowTempC = nowTempC;
        this.todayDate = todayDate;
        this.todayMaxTempC = todayMaxTempC;
        this.todayMinTempC = todayMinTempC;
        this.todaySunRiseTime = todaySunRiseTime;
        this.todaySunSetTime = todaySunSetTime;
        this.todayHumidity = todayHumidity;
        this.todayWeatherDesc = todayWeatherDesc;
        this.todayWeatherIconUrl = todayWeatherIconUrl;
        this.todayWindSpeedKmph = todayWindSpeedKmph;

        this.tmrDate = tmrDate;
        this.tmrMaxTempC = tmrMaxTempC;
        this.tmrMinTempC = tmrMinTempC;
        this.tmrSunRiseTime = tmrSunRiseTime;
        this.tmrSunSetTime = tmrSunSetTime;

    }

	public weather()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}