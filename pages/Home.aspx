﻿<%@ Page Title="Home" Async="true"  Language="C#" EnableEventValidation="false"  EnableSessionState="True" MasterPageFile="~/master/main.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="pages_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="page_head" Runat="Server">
    <!--

        *****************t

         https://newsapi.org/v2/everything?q=sabah&from=2017-12-06&sortBy=popularity&apiKey=1e9fd93bd44c494d86ab4ae034467549


    -->


   

    <!---->
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" Runat="Server">
    
    <div id="all" style="width:100%;">

      <div id="main_detail" style=" border-radius:10px;color: navajowhite;float:left;width:25%;border: 2px solid;margin-right: 10px;margin-top: 10px;">
         
           <div id="logo_block" style="padding:10px;width:100%;">
              <a runat="server" href="~/pages/Home.aspx"><img src="../images/SabahLeaf.ico" style="cursor: pointer;width:80%;margin:20px;" /></a>
            <h4 style=" background-color: firebrick;border-radius: 10px;">Traveller [North Borneo]</h4>
          </div>
           <div id="weather_block" style="width:100%;">
              <div id="weather_detail" style="padding:10px;">
                  <h4 style="font-family:Cambria  ;margin-top:0;    background-color: firebrick;border-radius: 10px;">Current Weather Condition in North Borneo</h4>
          

                     <asp:PlaceHolder ID="PlaceHolder_weather_detail" runat="server"></asp:PlaceHolder> 
            
             
               </div>

          </div>
           <div id="news_block" style="border-top:1px solid wheat; border-bottom:1px solid wheat; padding:10px;" style="width:100%;">
         <h4  id="news_block_title" runat="server" style="font-family:Cambria;margin-top:0;    background-color: firebrick;border-radius: 10px;">Today's Top News in North Borneo</h4>
           <asp:PlaceHolder ID="ph_news" runat="server"></asp:PlaceHolder> 
               
           </div>
         

           <div id="tourism_block" style="width:100%;">
                <hr/>

             
               <style>
.vertical-menu {
    width: 100%;
    font-family:cursive;
    font-weight:500;
    border-radius:10px;
    
}


.vertical-menu a {
     
    color: brown;
    display: block;
    padding: 12px;
    text-decoration: none;
}

.vertical-menu a:hover {
     
    border-radius:10px;
    color:wheat;
    opacity:0.6;
    text-decoration:underline;
}

.vertical-menu a.active {
    background-color: #4CAF50;
    color: white;
    border-radius:10px;
}





         
.gm-style-iw {
	width: 82% !important;
	top: 15px !important;
	left: 40px !important;
	background-color: #fff;
	box-shadow: 0 1px 6px rgba(178, 178, 178, 0.6);
	border: 1px solid rgba(72, 181, 233, 0.6);
	border-radius: 20px;
}
#iw-container {
	margin-bottom: 10px;
}
#iw-container .iw-title {
	font-family: 'Open Sans Condensed', sans-serif;
	font-size: 18px;
	font-weight: 400;
	padding-top: 10px;
    padding-bottom:10px;
    padding-left:5px;
    padding-right:5px;
	background-color: #48b5e9;
	color: white;
	margin: 0;
	border-radius: 2px 2px 0 0;
}
#iw-container .iw-content {
	font-size: 12px;
	line-height: 18px;
	font-weight: 400;
	margin-right: 1px;
	padding: 5px;
	max-height: 140px;
	overflow-y: auto;
	overflow-x: hidden;
}
.iw-content img {
	float: right;
    border-radius:10px;
	margin: 0 5px 5px 10px;	
}
.iw-subTitle {
	font-size: 16px;
	font-weight: 700;
	padding: 5px 0;
}
.iw-bottom-gradient {
	position: absolute;
	width: 326px;
	height: 25px;
	bottom: 10px;
	right: 18px;
	background: linear-gradient(to bottom, rgba(255,255,255,0) 0%, rgba(255,255,255,1) 100%);
	background: -webkit-linear-gradient(top, rgba(255,255,255,0) 0%, rgba(255,255,255,1) 100%);
	background: -moz-linear-gradient(top, rgba(255,255,255,0) 0%, rgba(255,255,255,1) 100%);
	background: -ms-linear-gradient(top, rgba(255,255,255,0) 0%, rgba(255,255,255,1) 100%);
}
</style>
      <div style="font-size:16px;font-family:Calibri;font-weight:700;" class="vertical-menu">
  <a style="margin:10px;background-color:burlywood;border-radius:10px;" href="~/pages/Home.aspx" runat="server">Home</a>
                    
  <a style="margin:10px;background-color:burlywood;border-radius:10px;" href="~/pages/MountKK.aspx" runat="server">Mount Kinabalu</a>
  <a style="margin:10px;background-color:burlywood;border-radius:10px;" href="~/pages/waterSport.aspx" runat="server">North Borneo Water Sports</a>
  <a style="margin:10px;background-color:burlywood;border-radius:10px;" href="~/pages/borneoRainforest.aspx" runat="server">North Borneo Rainforest</a>
  <a style="margin:10px;background-color:burlywood;border-radius:10px;" href="~/pages/borneoResort.aspx" runat="server">North Borneo Resorts</a>
    <a style="margin:10px;background-color:burlywood;border-radius:10px;" href="~/pages/rareSpecies.aspx" runat="server">North Borneo Rare Species</a>
  <a style="margin:10px;background-color:burlywood;border-radius:10px;" href="~/pages/waterRafting.aspx" runat="server">White Water Rafting</a>
</div>
                 <div id="tourism_story" style="color:brown;padding:10px;">
                     <asp:PlaceHolder ID="PlaceHolder_borneo_story" runat="server"></asp:PlaceHolder> 

               </div>
          </div>
         

      </div>
        <script>
            $(document).ready(function() {
                //

                if(/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|ipad|iris|kindle|Android|Silk|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test(navigator.userAgent) 
  || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(navigator.userAgent.substr(0,4))){
                    $('#main_detail').hide();
                    $("#main_sec").css("width", "100%"); 
                } else{
                    $('#main_detail').show();
                    $("#main_sec").css("width", "70%"); 
                }
              
              

                $('.vertical-menu a').on('click', function(){
                    $('.vertical-menu a').removeClass('active');
                    $(this).addClass('active');
                });
            });

            $(window).load(function() {
                //
                $("#loader").css("visibility", "hidden");
                if(/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|ipad|iris|kindle|Android|Silk|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test(navigator.userAgent) 
  || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(navigator.userAgent.substr(0,4))){
                    $('#main_detail').hide();
                    $("#main_sec").css("width", "100%"); 
                } else{
                    $('#main_detail').show();
                    $("#main_sec").css("width", "70%"); 
                }
            });

            $(window).on('resize', function () {
                $("#loader").css("visibility", "hidden");
                if(/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|ipad|iris|kindle|Android|Silk|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test(navigator.userAgent) 
   || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(navigator.userAgent.substr(0,4))){
                    $('#main_detail').hide();
                    $("#main_sec").css("width", "100%"); 
                } else{
                    $('#main_detail').show();
                    $("#main_sec").css("width", "70%"); 
                }
            });

          
</script>

    <div id="main_sec" style="float:right;width:70%;">
    
    <div style="border-top: 2px solid whitesmoke;border-bottom: 2px solid whitesmoke;margin-top: 10px;" runat="server">
   <h4 style="color:darkblue;font-family:cursive;"><em> Welcome <asp:Label ID="username_lbl" style="color:brown;font-weight:700;" runat="server"></asp:Label> -
       To the Traveller Platform,  <asp:Label runat="server" ID="weekDate"></asp:Label>
        Have a nice day ! </em> 
    </h4>
       <div style="z-index:1;" class="heading-text">							
					<a href="../pages/home.aspx">		<h4 style="color: darkolivegreen;font-family: cursive;" class="animated flipInY delay1">Traveller - North Borneo Islands</h4></a>
					<a href="../pages/home.aspx">		<p style="color: darkolivegreen;font-family: cursive;">A Travel Platform for traveller to refer and share information while travelling</p></a>
						</div>
    </div>

   








    

    <!--slider image start-->

     
     
 
        <div class=" row-centered">
           
    


            <script type="text/javascript">
                (function (g, h, c, j, d, k, l) {/*! Jssor */
                    new (function () { }); var f = { id: function (a) { return -c.cos(a * c.PI) / 2 + .5 }, xe: function (a) { return a }, gd: function (a) { return -a * (a - 2) }, He: function (a) { return (a *= 2) < 1 ? 1 / 2 * a * a : -1 / 2 * (--a * (a - 2) - 1) }, Ye: function (a) { return -1 / 2 * (c.cos(c.PI * a) - 1) }, Oe: function (a) { return a == 0 || a == 1 ? a : (a *= 2) < 1 ? 1 / 2 * c.pow(2, 10 * (a - 1)) : 1 / 2 * (-c.pow(2, -10 * --a) + 2) }, Le: function (a) { return 1 - c.cos(a * c.PI * 2) }, Ke: function (a) { return c.sin(a * c.PI * 2) }, Je: function (a) { return 1 - ((a *= 2) < 1 ? (a = 1 - a) * a * a : (a -= 1) * a * a) }, Ie: function (a) { return (a *= 2) < 1 ? a * a * a : (a = 2 - a) * a * a } }, e = { vb: f.gd, Dd: f.He, Se: f.Ye, We: f.Oe, Xb: f.Le, Fe: f.Ke, qe: f.Je, Ub: f.Ie }; var b = new function () { var e = this, Ab = /\S+/g, F = 1, yb = 2, fb = 3, eb = 4, jb = 5, G, r = 0, i = 0, s = 0, X = 0, z = 0, I = navigator, ob = I.appName, o = I.userAgent, p = parseFloat; function Ib() { if (!G) { G = { bf: "ontouchstart" in g || "createTouch" in h }; var a; if (I.pointerEnabled || (a = I.msPointerEnabled)) G.ud = a ? "msTouchAction" : "touchAction" } return G } function v(j) { if (!r) { r = -1; if (ob == "Microsoft Internet Explorer" && !!g.attachEvent && !!g.ActiveXObject) { var e = o.indexOf("MSIE"); r = F; s = p(o.substring(e + 5, o.indexOf(";", e)));/*@cc_on X=@_jscript_version@*/; i = h.documentMode || s } else if (ob == "Netscape" && !!g.addEventListener) { var d = o.indexOf("Firefox"), b = o.indexOf("Safari"), f = o.indexOf("Chrome"), c = o.indexOf("AppleWebKit"); if (d >= 0) { r = yb; i = p(o.substring(d + 8)) } else if (b >= 0) { var k = o.substring(0, b).lastIndexOf("/"); r = f >= 0 ? eb : fb; i = p(o.substring(k + 1, b)) } else { var a = /Trident\/.*rv:([0-9]{1,}[\.0-9]{0,})/i.exec(o); if (a) { r = F; i = s = p(a[1]) } } if (c >= 0) z = p(o.substring(c + 12)) } else { var a = /(opera)(?:.*version|)[ \/]([\w.]+)/i.exec(o); if (a) { r = jb; i = p(a[2]) } } } return j == r } function q() { return v(F) } function Q() { return q() && (i < 6 || h.compatMode == "BackCompat") } function db() { return v(fb) } function ib() { return v(jb) } function vb() { return db() && z > 534 && z < 535 } function J() { v(); return z > 537 || i > 42 || r == F && i >= 11 } function O() { return q() && i < 9 } function wb(a) { var b, c; return function (f) { if (!b) { b = d; var e = a.substr(0, 1).toUpperCase() + a.substr(1); n([a].concat(["WebKit", "ms", "Moz", "O", "webkit"]), function (g, d) { var b = a; if (d) b = g + e; if (f.style[b] != l) return c = b }) } return c } } function ub(b) { var a; return function (c) { a = a || wb(b)(c) || b; return a } } var K = ub("transform"); function nb(a) { return {}.toString.call(a) } var kb = {}; n(["Boolean", "Number", "String", "Function", "Array", "Date", "RegExp", "Object"], function (a) { kb["[object " + a + "]"] = a.toLowerCase() }); function n(b, d) { var a, c; if (nb(b) == "[object Array]") { for (a = 0; a < b.length; a++) if (c = d(b[a], a, b)) return c } else for (a in b) if (c = d(b[a], a, b)) return c } function C(a) { return a == j ? String(a) : kb[nb(a)] || "object" } function lb(a) { for (var b in a) return d } function A(a) { try { return C(a) == "object" && !a.nodeType && a != a.window && (!a.constructor || {}.hasOwnProperty.call(a.constructor.prototype, "isPrototypeOf")) } catch (b) { } } function u(a, b) { return { x: a, y: b } } function rb(b, a) { setTimeout(b, a || 0) } function H(b, d, c) { var a = !b || b == "inherit" ? "" : b; n(d, function (c) { var b = c.exec(a); if (b) { var d = a.substr(0, b.index), e = a.substr(b.index + b[0].length + 1, a.length - 1); a = d + e } }); a = c + (!a.indexOf(" ") ? "" : " ") + a; return a } function tb(b, a) { if (i < 9) b.style.filter = a } e.Hf = Ib; e.qd = q; e.Ff = db; e.od = ib; e.Cf = J; e.ub = O; wb("transform"); e.td = function () { return i }; e.Af = function () { v(); return z }; e.p = rb; function Y(a) { a.constructor === Y.caller && a.xd && a.xd.apply(a, Y.caller.arguments) } e.xd = Y; e.zb = function (a) { if (e.Ef(a)) a = h.getElementById(a); return a }; function t(a) { return a || g.event } e.Hd = t; e.fc = function (b) { b = t(b); var a = b.target || b.srcElement || h; if (a.nodeType == 3) a = e.Md(a); return a }; e.Nd = function (a) { a = t(a); return { x: a.pageX || a.clientX || 0, y: a.pageY || a.clientY || 0 } }; function D(c, d, a) { if (a !== l) c.style[d] = a == l ? "" : a; else { var b = c.currentStyle || c.style; a = b[d]; if (a == "" && g.getComputedStyle) { b = c.ownerDocument.defaultView.getComputedStyle(c, j); b && (a = b.getPropertyValue(d) || b[d]) } return a } } function ab(b, c, a, d) { if (a !== l) { if (a == j) a = ""; else d && (a += "px"); D(b, c, a) } else return p(D(b, c)) } function m(c, a) { var d = a ? ab : D, b; if (a & 4) b = ub(c); return function (e, f) { return d(e, b ? b(e) : c, f, a & 2) } } function Db(b) { if (q() && s < 9) { var a = /opacity=([^)]*)/.exec(b.style.filter || ""); return a ? p(a[1]) / 100 : 1 } else return p(b.style.opacity || "1") } function Fb(b, a, f) { if (q() && s < 9) { var h = b.style.filter || "", i = new RegExp(/[\s]*alpha\([^\)]*\)/g), e = c.round(100 * a), d = ""; if (e < 100 || f) d = "alpha(opacity=" + e + ") "; var g = H(h, [i], d); tb(b, g) } else b.style.opacity = a == 1 ? "" : c.round(a * 100) / 100 } var L = { N: ["rotate"], Y: ["rotateX"], Z: ["rotateY"], Tb: ["skewX"], Zb: ["skewY"] }; if (!J()) L = B(L, { B: ["scaleX", 2], v: ["scaleY", 2], db: ["translateZ", 1] }); function M(d, a) { var c = ""; if (a) { if (q() && i && i < 10) { delete a.Y; delete a.Z; delete a.db } b.g(a, function (d, b) { var a = L[b]; if (a) { var e = a[1] || 0; if (N[b] != d) c += " " + a[0] + "(" + d + (["deg", "px", ""])[e] + ")" } }); if (J()) { if (a.qb || a.tb || a.db) c += " translate3d(" + (a.qb || 0) + "px," + (a.tb || 0) + "px," + (a.db || 0) + "px)"; if (a.B == l) a.B = 1; if (a.v == l) a.v = 1; if (a.B != 1 || a.v != 1) c += " scale3d(" + a.B + ", " + a.v + ", 1)" } } d.style[K(d)] = c } e.Ic = m("transformOrigin", 4); e.If = m("backfaceVisibility", 4); e.xf = m("transformStyle", 4); e.yf = m("perspective", 6); e.vf = m("perspectiveOrigin", 4); e.uf = function (a, b) { if (q() && s < 9 || s < 10 && Q()) a.style.zoom = b == 1 ? "" : b; else { var c = K(a), f = "scale(" + b + ")", e = a.style[c], g = new RegExp(/[\s]*scale\(.*?\)/g), d = H(e, [g], f); a.style[c] = d } }; e.jc = function (b, a) { return function (c) { c = t(c); var f = c.type, d = c.relatedTarget || (f == "mouseout" ? c.toElement : c.fromElement); (!d || d !== a && !e.df(a, d)) && b(c) } }; e.f = function (a, d, b, c) { a = e.zb(a); if (a.addEventListener) { d == "mousewheel" && a.addEventListener("DOMMouseScroll", b, c); a.addEventListener(d, b, c) } else if (a.attachEvent) { a.attachEvent("on" + d, b); c && a.setCapture && a.setCapture() } }; e.T = function (a, c, d, b) { a = e.zb(a); if (a.removeEventListener) { c == "mousewheel" && a.removeEventListener("DOMMouseScroll", d, b); a.removeEventListener(c, d, b) } else if (a.detachEvent) { a.detachEvent("on" + c, d); b && a.releaseCapture && a.releaseCapture() } }; e.Qb = function (a) { a = t(a); a.preventDefault && a.preventDefault(); a.cancel = d; a.returnValue = k }; e.gf = function (a) { a = t(a); a.stopPropagation && a.stopPropagation(); a.cancelBubble = d }; e.Q = function (d, c) { var a = [].slice.call(arguments, 2), b = function () { var b = a.concat([].slice.call(arguments, 0)); return c.apply(d, b) }; return b }; e.hf = function (a, b) { if (b == l) return a.textContent || a.innerText; var c = h.createTextNode(b); e.dc(a); a.appendChild(c) }; e.Nb = function (d, c) { for (var b = [], a = d.firstChild; a; a = a.nextSibling) (c || a.nodeType == 1) && b.push(a); return b }; function mb(a, c, e, b) { b = b || "u"; for (a = a ? a.firstChild : j; a; a = a.nextSibling) if (a.nodeType == 1) { if (U(a, b) == c) return a; if (!e) { var d = mb(a, c, e, b); if (d) return d } } } e.M = mb; function S(a, d, f, b) { b = b || "u"; var c = []; for (a = a ? a.firstChild : j; a; a = a.nextSibling) if (a.nodeType == 1) { U(a, b) == d && c.push(a); if (!f) { var e = S(a, d, f, b); if (e.length) c = c.concat(e) } } return c } function gb(a, c, d) { for (a = a ? a.firstChild : j; a; a = a.nextSibling) if (a.nodeType == 1) { if (a.tagName == c) return a; if (!d) { var b = gb(a, c, d); if (b) return b } } } e.lf = gb; function xb(a, c, e) { var b = []; for (a = a ? a.firstChild : j; a; a = a.nextSibling) if (a.nodeType == 1) { (!c || a.tagName == c) && b.push(a); if (!e) { var d = xb(a, c, e); if (d.length) b = b.concat(d) } } return b } e.mf = xb; e.nf = function (b, a) { return b.getElementsByTagName(a) }; function B() { var e = arguments, d, c, b, a, g = 1 & e[0], f = 1 + g; d = e[f - 1] || {}; for (; f < e.length; f++) if (c = e[f]) for (b in c) { a = c[b]; if (a !== l) { a = c[b]; var h = d[b]; d[b] = g && (A(h) || A(a)) ? B(g, {}, h, a) : a } } return d } e.H = B; function Z(f, g) { var d = {}, c, a, b; for (c in f) { a = f[c]; b = g[c]; if (a !== b) { var e; if (A(a) && A(b)) { a = Z(a, b); e = !lb(a) } !e && (d[c] = a) } } return d } e.ed = function (a) { return C(a) == "function" }; e.Ef = function (a) { return C(a) == "string" }; e.cd = function (a) { return !isNaN(p(a)) && isFinite(a) }; e.g = n; e.qf = A; function R(a) { return h.createElement(a) } e.Vb = function () { return R("DIV") }; e.sf = function () { return R("SPAN") }; e.Ed = function () { }; function V(b, c, a) { if (a == l) return b.getAttribute(c); b.setAttribute(c, a) } function U(a, b) { return V(a, b) || V(a, "data-" + b) } e.C = V; e.l = U; function x(b, a) { if (a == l) return b.className; b.className = a } e.Ad = x; function qb(b) { var a = {}; n(b, function (b) { a[b] = b }); return a } function sb(b, a) { return b.match(a || Ab) } function P(b, a) { return qb(sb(b || "", a)) } e.pe = sb; function bb(b, c) { var a = ""; n(c, function (c) { a && (a += b); a += c }); return a } function E(a, c, b) { x(a, bb(" ", B(Z(P(x(a)), P(c)), P(b)))) } e.Md = function (a) { return a.parentNode }; e.V = function (a) { e.bb(a, "none") }; e.D = function (a, b) { e.bb(a, b ? "none" : "") }; e.Rd = function (b, a) { b.removeAttribute(a) }; e.Pd = function () { return q() && i < 10 }; e.Td = function (d, a) { if (a) d.style.clip = "rect(" + c.round(a.c || a.E || 0) + "px " + c.round(a.r) + "px " + c.round(a.s) + "px " + c.round(a.e || a.u || 0) + "px)"; else if (a !== l) { var g = d.style.cssText, f = [new RegExp(/[\s]*clip: rect\(.*?\)[;]?/i), new RegExp(/[\s]*cliptop: .*?[;]?/i), new RegExp(/[\s]*clipright: .*?[;]?/i), new RegExp(/[\s]*clipbottom: .*?[;]?/i), new RegExp(/[\s]*clipleft: .*?[;]?/i)], e = H(g, f, ""); b.Ob(d, e) } }; e.ib = function () { return +new Date }; e.S = function (b, a) { b.appendChild(a) }; e.Rb = function (b, a, c) { (c || a.parentNode).insertBefore(b, a) }; e.bc = function (b, a) { a = a || b.parentNode; a && a.removeChild(b) }; e.he = function (a, b) { n(a, function (a) { e.bc(a, b) }) }; e.dc = function (a) { e.he(e.Nb(a, d), a) }; e.ge = function (a, b) { var c = e.Md(a); b & 1 && e.O(a, (e.n(c) - e.n(a)) / 2); b & 2 && e.U(a, (e.o(c) - e.o(a)) / 2) }; e.ae = function (b, a) { return parseInt(b, a || 10) }; e.Zd = p; e.df = function (b, a) { var c = h.body; while (a && b !== a && c !== a) try { a = a.parentNode } catch (d) { return k } return b === a }; function W(d, c, b) { var a = d.cloneNode(!c); !b && e.Rd(a, "id"); return a } e.X = W; e.xb = function (f, g) { var a = new Image; function b(f, d) { e.T(a, "load", b); e.T(a, "abort", c); e.T(a, "error", c); g && g(a, d) } function c(a) { b(a, d) } if (ib() && i < 11.6 || !f) b(!f); else { e.f(a, "load", b); e.f(a, "abort", c); e.f(a, "error", c); a.src = f } }; e.Yd = function (d, a, f) { var c = d.length + 1; function b(b) { c--; if (a && b && b.src == a.src) a = b; !c && f && f(a) } n(d, function (a) { e.xb(a.src, b) }); b() }; e.Xd = function (a, g, i, h) { if (h) a = W(a); var c = S(a, g); if (!c.length) c = b.nf(a, g); for (var f = c.length - 1; f > -1; f--) { var d = c[f], e = W(i); x(e, x(d)); b.Ob(e, d.style.cssText); b.Rb(e, d); b.bc(d) } return a }; function Gb(a) { var k = this, p = "", r = ["av", "pv", "ds", "dn"], f = [], q, j = 0, g = 0, d = 0; function i() { E(a, q, f[d || j || g & 2 || g]); b.fb(a, "pointer-events", d ? "none" : "") } function c() { j = 0; i(); e.T(h, "mouseup", c); e.T(h, "touchend", c); e.T(h, "touchcancel", c) } function o(a) { if (d) e.Qb(a); else { j = 4; i(); e.f(h, "mouseup", c); e.f(h, "touchend", c); e.f(h, "touchcancel", c) } } k.ne = function (a) { if (a === l) return g; g = a & 2 || a & 1; i() }; k.sd = function (a) { if (a === l) return !d; d = a ? 0 : 3; i() }; k.sb = a = e.zb(a); var m = b.pe(x(a)); if (m) p = m.shift(); n(r, function (a) { f.push(p + a) }); q = bb(" ", f); f.unshift(""); e.f(a, "mousedown", o); e.f(a, "touchstart", o) } e.cc = function (a) { return new Gb(a) }; e.fb = D; e.yb = m("overflow"); e.U = m("top", 2); e.O = m("left", 2); e.n = m("width", 2); e.o = m("height", 2); e.le = m("marginLeft", 2); e.Vd = m("marginTop", 2); e.A = m("position"); e.bb = m("display"); e.K = m("zIndex", 1); e.Bb = function (b, a, c) { if (a != l) Fb(b, a, c); else return Db(b) }; e.Ob = function (a, b) { if (b != l) a.style.cssText = b; else return a.style.cssText }; var T = { F: e.Bb, c: e.U, e: e.O, hb: e.n, eb: e.o, Ab: e.A, Rf: e.bb, P: e.K }; function w(g, k) { var f = O(), b = J(), d = vb(), h = K(g); function i(b, d, a) { var e = b.rb(u(-d / 2, -a / 2)), f = b.rb(u(d / 2, -a / 2)), g = b.rb(u(d / 2, a / 2)), h = b.rb(u(-d / 2, a / 2)); b.rb(u(300, 300)); return u(c.min(e.x, f.x, g.x, h.x) + d / 2, c.min(e.y, f.y, g.y, h.y) + a / 2) } function a(d, a) { a = a || {}; var n = a.db || 0, p = (a.Y || 0) % 360, q = (a.Z || 0) % 360, u = (a.N || 0) % 360, k = a.B, m = a.v, g = a.Sf; if (k == l) k = 1; if (m == l) m = 1; if (g == l) g = 1; if (f) { n = 0; p = 0; q = 0; g = 0 } var c = new Cb(a.qb, a.tb, n); c.Y(p); c.Z(q); c.fe(u); c.me(a.Tb, a.Zb); c.Fc(k, m, g); if (b) { c.mb(a.u, a.E); d.style[h] = c.Wd() } else if (!X || X < 9) { var o = "", j = { x: 0, y: 0 }; if (a.cb) j = i(c, a.cb, a.ob); e.Vd(d, j.y); e.le(d, j.x); o = c.be(); var s = d.style.filter, t = new RegExp(/[\s]*progid:DXImageTransform\.Microsoft\.Matrix\([^\)]*\)/g), r = H(s, [t], o); tb(d, r) } } w = function (f, c) { c = c || {}; var h = c.u, i = c.E, g; n(T, function (a, b) { g = c[b]; g !== l && a(f, g) }); e.Td(f, c.a); if (!b) { h != l && e.O(f, (c.zd || 0) + h); i != l && e.U(f, (c.Bd || 0) + i) } if (c.ce) if (d) rb(e.Q(j, M, f, c)); else a(f, c) }; e.Db = M; if (d) e.Db = w; if (f) e.Db = a; else if (!b) a = M; e.L = w; w(g, k) } e.Db = w; e.L = w; function Cb(i, k, o) { var d = this, b = [1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, i || 0, k || 0, o || 0, 1], h = c.sin, g = c.cos, l = c.tan; function f(a) { return a * c.PI / 180 } function n(a, b) { return { x: a, y: b } } function m(c, e, l, m, o, r, t, u, w, z, A, C, E, b, f, k, a, g, i, n, p, q, s, v, x, y, B, D, F, d, h, j) { return [c * a + e * p + l * x + m * F, c * g + e * q + l * y + m * d, c * i + e * s + l * B + m * h, c * n + e * v + l * D + m * j, o * a + r * p + t * x + u * F, o * g + r * q + t * y + u * d, o * i + r * s + t * B + u * h, o * n + r * v + t * D + u * j, w * a + z * p + A * x + C * F, w * g + z * q + A * y + C * d, w * i + z * s + A * B + C * h, w * n + z * v + A * D + C * j, E * a + b * p + f * x + k * F, E * g + b * q + f * y + k * d, E * i + b * s + f * B + k * h, E * n + b * v + f * D + k * j] } function e(c, a) { return m.apply(j, (a || b).concat(c)) } d.Fc = function (a, c, d) { if (a != 1 || c != 1 || d != 1) b = e([a, 0, 0, 0, 0, c, 0, 0, 0, 0, d, 0, 0, 0, 0, 1]) }; d.mb = function (a, c, d) { b[12] += a || 0; b[13] += c || 0; b[14] += d || 0 }; d.Y = function (c) { if (c) { a = f(c); var d = g(a), i = h(a); b = e([1, 0, 0, 0, 0, d, i, 0, 0, -i, d, 0, 0, 0, 0, 1]) } }; d.Z = function (c) { if (c) { a = f(c); var d = g(a), i = h(a); b = e([d, 0, -i, 0, 0, 1, 0, 0, i, 0, d, 0, 0, 0, 0, 1]) } }; d.fe = function (c) { if (c) { a = f(c); var d = g(a), i = h(a); b = e([d, i, 0, 0, -i, d, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1]) } }; d.me = function (a, c) { if (a || c) { i = f(a); k = f(c); b = e([1, l(k), 0, 0, l(i), 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1]) } }; d.rb = function (c) { var a = e(b, [1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, c.x, c.y, 0, 1]); return n(a[12], a[13]) }; d.Wd = function () { return "matrix3d(" + b.join(",") + ")" }; d.be = function () { return "progid:DXImageTransform.Microsoft.Matrix(M11=" + b[0] + ", M12=" + b[4] + ", M21=" + b[1] + ", M22=" + b[5] + ", SizingMethod='auto expand')" } } new function () { var a = this; function b(d, g) { for (var j = d[0].length, i = d.length, h = g[0].length, f = [], c = 0; c < i; c++) for (var k = f[c] = [], b = 0; b < h; b++) { for (var e = 0, a = 0; a < j; a++) e += d[c][a] * g[a][b]; k[b] = e } return f } a.B = function (b, c) { return a.Kd(b, c, 0) }; a.v = function (b, c) { return a.Kd(b, 0, c) }; a.Kd = function (a, c, d) { return b(a, [[c, 0], [0, d]]) }; a.rb = function (d, c) { var a = b(d, [[c.x], [c.y]]); return u(a[0][0], a[1][0]) } }; var N = { zd: 0, Bd: 0, u: 0, E: 0, z: 1, B: 1, v: 1, N: 0, Y: 0, Z: 0, qb: 0, tb: 0, db: 0, Tb: 0, Zb: 0 }; e.Id = function (a) { var c = a || {}; if (a) if (b.ed(a)) c = { nc: c }; else if (b.ed(a.a)) c.a = { nc: a.a }; return c }; e.Fd = function (k, m, x, q, z, A, n) { var a = m; if (k) { a = {}; for (var g in m) { var B = A[g] || 1, w = z[g] || [0, 1], e = (x - w[0]) / w[1]; e = c.min(c.max(e, 0), 1); e = e * B; var u = c.floor(e); if (e != u) e -= u; var h = q.nc || f.id, i, C = k[g], o = m[g]; if (b.cd(o)) { h = q[g] || h; var y = h(e); i = C + o * y } else { i = b.H({ Pb: {} }, k[g]); var v = q[g] || {}; b.g(o.Pb || o, function (d, a) { h = v[a] || v.nc || h; var c = h(e), b = d * c; i.Pb[a] = b; i[a] += b }) } a[g] = i } var t = b.g(m, function (b, a) { return N[a] != l }); t && b.g(N, function (c, b) { if (a[b] == l && k[b] !== l) a[b] = k[b] }); if (t) { if (a.z) a.B = a.v = a.z; a.cb = n.cb; a.ob = n.ob; a.ce = d } } if (m.a && n.mb) { var p = a.a.Pb, s = (p.c || 0) + (p.s || 0), r = (p.e || 0) + (p.r || 0); a.e = (a.e || 0) + r; a.c = (a.c || 0) + s; a.a.e -= r; a.a.r -= r; a.a.c -= s; a.a.s -= s } if (a.a && b.Pd() && !a.a.c && !a.a.e && !a.a.E && !a.a.u && a.a.r == n.cb && a.a.s == n.ob) a.a = j; return a } }; function o() { var a = this, d = []; function i(a, b) { d.push({ oc: a, pc: b }) } function h(a, c) { b.g(d, function (b, e) { b.oc == a && b.pc === c && d.splice(e, 1) }) } a.Ib = a.addEventListener = i; a.removeEventListener = h; a.j = function (a) { var c = [].slice.call(arguments, 1); b.g(d, function (b) { b.oc == a && b.pc.apply(g, c) }) } } var m = function (z, C, i, J, M, L) { z = z || 0; var a = this, q, n, o, u, A = 0, G, H, F, B, y = 0, h = 0, m = 0, D, l, f, e, p, w = [], x; function O(a) { f += a; e += a; l += a; h += a; m += a; y += a } function t(o) { var g = o; if (p && (g >= e || g <= f)) g = ((g - f) % p + p) % p + f; if (!D || u || h != g) { var j = c.min(g, e); j = c.max(j, f); if (!D || u || j != m) { if (L) { var k = (j - l) / (C || 1); if (i.qc) k = 1 - k; var n = b.Fd(M, L, k, G, F, H, i); if (x) b.g(n, function (b, a) { x[a] && x[a](J, b) }); else b.L(J, n) } a.rc(m - l, j - l); m = j; b.g(w, function (b, c) { var a = o < h ? w[w.length - c - 1] : b; a.jb(m - y) }); var r = h, q = m; h = g; D = d; a.Yb(r, q) } } } function E(a, b, d) { b && a.Wb(e); if (!d) { f = c.min(f, a.jd() + y); e = c.max(e, a.Ec() + y) } w.push(a) } var r = g.requestAnimationFrame || g.webkitRequestAnimationFrame || g.mozRequestAnimationFrame || g.msRequestAnimationFrame; if (b.Ff() && b.td() < 7) r = j; r = r || function (a) { b.p(a, i.kb) }; function I() { if (q) { var d = b.ib(), e = c.min(d - A, i.Uc), a = h + e * o; A = d; if (a * o >= n * o) a = n; t(a); if (!u && a * o >= n * o) K(B); else r(I) } } function s(g, i, j) { if (!q) { q = d; u = j; B = i; g = c.max(g, f); g = c.min(g, e); n = g; o = n < h ? -1 : 1; a.Vc(); A = b.ib(); r(I) } } function K(b) { if (q) { u = q = B = k; a.Wc(); b && b() } } a.Xc = function (a, b, c) { s(a ? h + a : e, b, c) }; a.Yc = s; a.lb = K; a.je = function (a) { s(a) }; a.gb = function () { return h }; a.Zc = function () { return n }; a.Jb = function () { return m }; a.jb = t; a.mb = function (a) { t(h + a) }; a.fd = function () { return q }; a.de = function (a) { p = a }; a.Wb = O; a.hd = function (a, b) { E(a, 0, b) }; a.zc = function (a) { E(a, 1) }; a.jd = function () { return f }; a.Ec = function () { return e }; a.Yb = a.Vc = a.Wc = a.rc = b.Ed; a.Bc = b.ib(); i = b.H({ kb: 16, Uc: 50 }, i); p = i.Oc; x = i.oe; f = l = z; e = z + C; H = i.J || {}; F = i.ab || {}; G = b.Id(i.m) }; var n = new function () { var h = this, t = 1, q = 2, r = 4, s = 8, w = 256, x = 512, v = 1024, u = 2048, j = u + t, i = u + q, o = x + t, m = x + q, n = w + r, k = w + s, l = v + r, p = v + s; function y(a) { return (a & q) == q } function z(a) { return (a & r) == r } function g(b, a, c) { c.push(a); b[a] = b[a] || []; b[a].push(c) } h.wc = function (f) { for (var d = f.i, e = f.k, s = f.R, t = f.Cd, r = [], a = 0, b = 0, p = d - 1, q = e - 1, h = t - 1, c, b = 0; b < e; b++) for (a = 0; a < d; a++) { switch (s) { case j: c = h - (a * e + (q - b)); break; case l: c = h - (b * d + (p - a)); break; case o: c = h - (a * e + b); case n: c = h - (b * d + a); break; case i: c = a * e + b; break; case k: c = b * d + (p - a); break; case m: c = a * e + (q - b); break; default: c = b * d + a } g(r, c, [b, a]) } return r }; h.Kb = function (q) { var u = q.i, v = q.k, e = q.R, t = q.Cd, r = [], s = 0, c = 0, d = 0, f = u - 1, h = v - 1, w = t - 1; switch (e) { case j: case m: case o: case i: var a = 0, b = 0; break; case k: case l: case n: case p: var a = f, b = 0; break; default: e = p; var a = f, b = 0 } c = a; d = b; while (s < t) { if (z(e) || y(e)) g(r, w - s++, [d, c]); else g(r, s++, [d, c]); switch (e) { case j: case m: c--; d++; break; case o: case i: c++; d--; break; case k: case l: c--; d--; break; case p: case n: default: c++; d++ } if (c < 0 || d < 0 || c > f || d > h) { switch (e) { case j: case m: a++; break; case k: case l: case o: case i: b++; break; case p: case n: default: a-- } if (a < 0 || b < 0 || a > f || b > h) { switch (e) { case j: case m: a = f; b++; break; case o: case i: b = h; a++; break; case k: case l: b = h; a--; break; case p: case n: default: a = 0; b++ } if (b > h) b = h; else if (b < 0) b = 0; else if (a > f) a = f; else if (a < 0) a = 0 } d = b; c = a } } return r }; h.ee = function (d) { for (var e = [], a, b = 0; b < d.k; b++) for (a = 0; a < d.i; a++) g(e, c.ceil(1e5 * c.random()) % 13, [b, a]); return e } }, s = function (l, s, q, u, z) { var e = this, v, g, a, y = 0, x = u.ie, r, h = 8; function t(a) { if (a.c) a.E = a.c; if (a.e) a.u = a.e; b.g(a, function (a) { b.qf(a) && t(a) }) } function i(g, e) { var a = { kb: e, q: 1, p: 0, i: 1, k: 1, F: 0, z: 0, a: 0, mb: k, I: k, qc: k, G: n.ee, R: 1032, gc: { Mc: 0, Ud: 0 }, m: f.id, J: {}, Sb: [], ab: {} }; b.H(a, g); t(a); a.Cd = a.i * a.k; a.m = b.Id(a.m); a.Sd = c.ceil(a.q / a.kb); a.Qd = function (c, b) { c /= a.i; b /= a.k; var f = c + "x" + b; if (!a.Sb[f]) { a.Sb[f] = { hb: c, eb: b }; for (var d = 0; d < a.i; d++) for (var e = 0; e < a.k; e++) a.Sb[f][e + "," + d] = { c: e * b, r: d * c + c, s: e * b + b, e: d * c } } return a.Sb[f] }; if (a.kc) { a.kc = i(a.kc, e); a.I = d } return a } function p(B, h, a, w, o, m) { var z = this, u, v = {}, i = {}, n = [], f, e, s, q = a.gc.Mc || 0, r = a.gc.Ud || 0, g = a.Qd(o, m), p = C(a), D = p.length - 1, t = a.q + a.p * D, x = w + t, l = a.I, y; x += 50; function C(a) { var b = a.G(a); return a.qc ? b.reverse() : b } z.kd = x; z.Mb = function (d) { d -= w; var e = d < t; if (e || y) { y = e; if (!l) d = t - d; var f = c.ceil(d / a.kb); b.g(i, function (a, e) { var d = c.max(f, a.tf); d = c.min(d, a.length - 1); if (a.wd != d) { if (!a.wd && !l) b.D(n[e]); else d == a.rf && l && b.V(n[e]); a.wd = d; b.L(n[e], a[d]) } }) } }; h = b.X(h); b.Db(h, j); if (b.ub()) { var E = !h["no-image"], A = b.mf(h); b.g(A, function (a) { (E || a["jssor-slider"]) && b.Bb(a, b.Bb(a), d) }) } b.g(p, function (h, j) { b.g(h, function (G) { var K = G[0], J = G[1], t = K + "," + J, n = k, p = k, x = k; if (q && J % 2) { if (q & 3) n = !n; if (q & 12) p = !p; if (q & 16) x = !x } if (r && K % 2) { if (r & 3) n = !n; if (r & 12) p = !p; if (r & 16) x = !x } a.c = a.c || a.a & 4; a.s = a.s || a.a & 8; a.e = a.e || a.a & 1; a.r = a.r || a.a & 2; var E = p ? a.s : a.c, B = p ? a.c : a.s, D = n ? a.r : a.e, C = n ? a.e : a.r; a.a = E || B || D || C; s = {}; e = { E: 0, u: 0, F: 1, hb: o, eb: m }; f = b.H({}, e); u = b.H({}, g[t]); if (a.F) e.F = 2 - a.F; if (a.P) { e.P = a.P; f.P = 0 } var I = a.i * a.k > 1 || a.a; if (a.z || a.N) { var H = d; if (b.ub()) if (a.i * a.k > 1) H = k; else I = k; if (H) { e.z = a.z ? a.z - 1 : 1; f.z = 1; if (b.ub() || b.od()) e.z = c.min(e.z, 2); var N = a.N || 0; e.N = N * 360 * (x ? -1 : 1); f.N = 0 } } if (I) { var h = u.Pb = {}; if (a.a) { var w = a.Qf || 1; if (E && B) { h.c = g.eb / 2 * w; h.s = -h.c } else if (E) h.s = -g.eb * w; else if (B) h.c = g.eb * w; if (D && C) { h.e = g.hb / 2 * w; h.r = -h.e } else if (D) h.r = -g.hb * w; else if (C) h.e = g.hb * w } s.a = u; f.a = g[t] } var L = n ? 1 : -1, M = p ? 1 : -1; if (a.x) e.u += o * a.x * L; if (a.y) e.E += m * a.y * M; b.g(e, function (a, c) { if (b.cd(a)) if (a != f[c]) s[c] = a - f[c] }); v[t] = l ? f : e; var F = a.Sd, A = c.round(j * a.p / a.kb); i[t] = new Array(A); i[t].tf = A; i[t].rf = A + F - 1; for (var z = 0; z <= F; z++) { var y = b.Fd(f, s, z / F, a.m, a.ab, a.J, { mb: a.mb, cb: o, ob: m }); y.P = y.P || 1; i[t].push(y) } }) }); p.reverse(); b.g(p, function (a) { b.g(a, function (c) { var f = c[0], e = c[1], d = f + "," + e, a = h; if (e || f) a = b.X(h); b.L(a, v[d]); b.yb(a, "hidden"); b.A(a, "absolute"); B.pf(a); n[d] = a; b.D(a, !l) }) }) } function w() { var b = this, c = 0; m.call(b, 0, v); b.Yb = function (d, b) { if (b - c > h) { c = b; a && a.Mb(b); g && g.Mb(b) } }; b.dd = r } e.of = function () { var a = 0, b = u.Fb, d = b.length; if (x) a = y++ % d; else a = c.floor(c.random() * d); b[a] && (b[a].pb = a); return b[a] }; e.kf = function (w, x, k, m, b) { r = b; b = i(b, h); var j = m.bd, f = k.bd; j["no-image"] = !m.ic; f["no-image"] = !k.ic; var n = j, o = f, u = b, d = b.kc || i({}, h); if (!b.I) { n = f; o = j } var t = d.Wb || 0; g = new p(l, o, d, c.max(t - d.kb, 0), s, q); a = new p(l, n, u, c.max(d.kb - t, 0), s, q); g.Mb(0); a.Mb(0); v = c.max(g.kd, a.kd); e.pb = w }; e.Eb = function () { l.Eb(); g = j; a = j }; e.jf = function () { var b = j; if (a) b = new w; return b }; if (b.ub() || b.od() || z && b.Af() < 537) h = 16; o.call(e); m.call(e, -1e7, 1e7) }, i = function (n, fc) { var e = this; function Bc() { var a = this; m.call(a, -1e8, 2e8); a.ff = function () { var b = a.Jb(), d = c.floor(b), f = t(d), e = b - c.floor(b); return { pb: f, cf: d, Ab: e } }; a.Yb = function (b, a) { var f = c.floor(a); if (f != a && a > b) f++; Tb(f, d); e.j(i.Gf, t(a), t(b), a, b) } } function Ac() { var a = this; m.call(a, 0, 0, { Oc: r }); b.g(C, function (b) { D & 1 && b.de(r); a.zc(b); b.Wb(kb / bc) }) } function zc() { var a = this, b = Ub.sb; m.call(a, -1, 2, { m: f.xe, oe: { Ab: Zb }, Oc: r }, b, { Ab: 1 }, { Ab: -2 }); a.hc = b } function mc(o, n) { var b = this, f, g, h, l, c; m.call(b, -1e8, 2e8, { Uc: 100 }); b.Vc = function () { M = d; R = j; e.j(i.Jf, t(w.gb()), w.gb()) }; b.Wc = function () { M = k; l = k; var a = w.ff(); e.j(i.Df, t(w.gb()), w.gb()); !a.Ab && Dc(a.cf, s) }; b.Yb = function (i, e) { var b; if (l) b = c; else { b = g; if (h) { var d = e / h; b = a.Bf(d) * (g - f) + f } } w.jb(b) }; b.Lb = function (a, d, c, e) { f = a; g = d; h = c; w.jb(a); b.jb(0); b.Yc(c, e) }; b.Kf = function (a) { l = d; c = a; b.Xc(a, j, d) }; b.zf = function (a) { c = a }; w = new Bc; w.hd(o); w.hd(n) } function oc() { var c = this, a = Xb(); b.K(a, 0); b.fb(a, "pointerEvents", "none"); c.sb = a; c.pf = function (c) { b.S(a, c); b.D(a) }; c.Eb = function () { b.V(a); b.dc(a) } } function xc(n, g) { var f = this, q, M, v, l, y = [], x, B, W, H, S, F, h, w, p; m.call(f, -u, u + 1, {}); function E(a) { q && q.Pc(); T(n, a, 0); F = d; q = new I.W(n, I, b.Zd(b.l(n, "idle")) || lc); q.jb(0) } function Z() { q.Bc < I.Bc && E() } function O(p, r, o) { if (!H) { H = d; if (l && o) { var h = o.width, c = o.height, n = h, m = c; if (h && c && a.wb) { if (a.wb & 3 && (!(a.wb & 4) || h > K || c > J)) { var j = k, q = K / J * c / h; if (a.wb & 1) j = q > 1; else if (a.wb & 2) j = q < 1; n = j ? h * J / c : K; m = j ? J : c * K / h } b.n(l, n); b.o(l, m); b.U(l, (J - m) / 2); b.O(l, (K - n) / 2) } b.A(l, "absolute"); e.j(i.ef, g) } } b.V(r); p && p(f) } function Y(b, c, d, e) { if (e == R && s == g && N) if (!Cc) { var a = t(b); A.kf(a, g, c, f, d); c.Ze(); U.Wb(a - U.jd() - 1); U.jb(a); z.Lb(b, b, 0) } } function bb(b) { if (b == R && s == g) { if (!h) { var a = j; if (A) if (A.pb == g) a = A.jf(); else A.Eb(); Z(); h = new vc(n, g, a, q); h.Hc(p) } !h.fd() && h.ec() } } function G(d, e, l) { if (d == g) { if (d != e) C[e] && C[e].Lc(); else !l && h && h.Pe(); p && p.sd(); var m = R = b.ib(); f.xb(b.Q(j, bb, m)) } else { var k = c.min(g, d), i = c.max(g, d), o = c.min(i - k, k + r - i), n = u + a.Ee - 1; (!S || o <= n) && f.xb() } } function db() { if (s == g && h) { h.lb(); p && p.De(); p && p.Ce(); h.Od() } } function eb() { s == g && h && h.lb() } function ab(a) { !P && e.j(i.Be, g, a) } function Q() { p = w.pInstance; h && h.Hc(p) } f.xb = function (c, a) { a = a || v; if (y.length && !H) { b.D(a); if (!W) { W = d; e.j(i.af, g); b.g(y, function (a) { if (!b.C(a, "src")) { a.src = b.l(a, "src2"); b.bb(a, a["display-origin"]) } }) } b.Yd(y, l, b.Q(j, O, c, a)) } else O(c, a) }; f.Ae = function () { var i = g; if (a.Gc < 0) i -= r; var d = i + a.Gc * tc; if (D & 2) d = t(d); if (!(D & 1) && !ib) d = c.max(0, c.min(d, r - u)); if (d != g) { if (A) { var e = A.of(r); if (e) { var k = R = b.ib(), h = C[t(d)]; return h.xb(b.Q(j, Y, d, h, e, k), v) } } cb(d) } else if (a.Cb) { f.Lc(); G(g, g) } }; f.lc = function () { G(g, g, d) }; f.Lc = function () { p && p.De(); p && p.Ce(); f.md(); h && h.ze(); h = j; E() }; f.Ze = function () { b.V(n) }; f.md = function () { b.D(n) }; f.ye = function () { p && p.sd() }; function T(a, c, e) { if (b.C(a, "jssor-slider")) return; if (!F) { if (a.tagName == "IMG") { y.push(a); if (!b.C(a, "src")) { S = d; a["display-origin"] = b.bb(a); b.V(a) } } b.ub() && b.K(a, (b.K(a) || 0) + 1) } var f = b.Nb(a); b.g(f, function (f) { var h = f.tagName, i = b.l(f, "u"); if (i == "player" && !w) { w = f; if (w.pInstance) Q(); else b.f(w, "dataavailable", Q) } if (i == "caption") { if (c) { b.Ic(f, b.l(f, "to")); b.If(f, b.l(f, "bf")); b.l(f, "3d") && b.xf(f, "preserve-3d") } else if (!b.qd()) { var g = b.X(f, k, d); b.Rb(g, f, a); b.bc(f, a); f = g; c = d } } else if (!F && !e && !l) { if (h == "A") { if (b.l(f, "u") == "image") l = b.lf(f, "IMG"); else l = b.M(f, "image", d); if (l) { x = f; b.bb(x, "block"); b.L(x, V); B = b.X(x, d); b.A(x, "relative"); b.Bb(B, 0); b.fb(B, "backgroundColor", "#000") } } else if (h == "IMG" && b.l(f, "u") == "image") l = f; if (l) { l.border = 0; b.L(l, V) } } T(f, c, e + 1) }) } f.rc = function (c, b) { var a = u - b; Zb(M, a) }; f.pb = g; o.call(f); b.yf(n, b.l(n, "p")); b.vf(n, b.l(n, "po")); var L = b.M(n, "thumb", d); if (L) { b.X(L); b.V(L) } b.D(n); v = b.X(gb); b.K(v, 1e3); b.f(n, "click", ab); E(d); f.ic = l; f.Jc = B; f.bd = n; f.hc = M = n; b.S(M, v); e.Ib(203, G); e.Ib(28, eb); e.Ib(24, db) } function vc(y, g, p, q) { var a = this, n = 0, u = 0, h, j, f, c, l, t, r, o = C[g]; m.call(a, 0, 0); function v() { b.dc(L); cc && l && o.Jc && b.S(L, o.Jc); b.D(L, !l && o.ic) } function w() { a.ec() } function x(b) { r = b; a.lb(); a.ec() } a.ec = function () { var b = a.Jb(); if (!B && !M && !r && s == g) { if (!b) { if (h && !l) { l = d; a.Od(d); e.j(i.we, g, n, u, h, c) } v() } var k, p = i.ad; if (b != c) if (b == f) k = c; else if (b == j) k = f; else if (!b) k = j; else k = a.Zc(); e.j(p, g, b, n, j, f, c); var m = N && (!E || F); if (b == c) (f != c && !(E & 12) || m) && o.Ae(); else (m || b != f) && a.Yc(k, w) } }; a.Pe = function () { f == c && f == a.Jb() && a.jb(j) }; a.ze = function () { A && A.pb == g && A.Eb(); var b = a.Jb(); b < c && e.j(i.ad, g, -b - 1, n, j, f, c) }; a.Od = function (a) { p && b.yb(lb, a && p.dd.nb ? "" : "hidden") }; a.rc = function (b, a) { if (l && a >= h) { l = k; v(); o.md(); A.Eb(); e.j(i.ve, g, n, u, h, c) } e.j(i.ue, g, a, n, j, f, c) }; a.Hc = function (a) { if (a && !t) { t = a; a.Ib($JssorPlayer$.ke, x) } }; p && a.zc(p); h = a.Ec(); a.zc(q); j = h + q.Kc; f = h + q.yd; c = a.Ec() } function Kb(a, c, d) { b.O(a, c); b.U(a, d) } function Zb(c, b) { var a = x > 0 ? x : fb, d = zb * b * (a & 1), e = Ab * b * (a >> 1 & 1); Kb(c, d, e) } function Pb() { qb = M; Ib = z.Zc(); G = w.gb() } function gc() { Pb(); if (B || !F && E & 12) { z.lb(); e.j(i.te) } } function ec(f) { if (!B && (F || !(E & 12)) && !z.fd()) { var d = w.gb(), b = c.ceil(G); if (f && c.abs(H) >= a.ld) { b = c.ceil(d); b += jb } if (!(D & 1)) b = c.min(r - u, c.max(b, 0)); var e = c.abs(b - d); e = 1 - c.pow(1 - e, 5); if (!P && qb) z.je(Ib); else if (d == b) { tb.ye(); tb.lc() } else z.Lb(d, b, e * Vb) } } function Hb(a) { !b.l(b.fc(a), "nodrag") && b.Qb(a) } function rc(a) { Yb(a, 1) } function Yb(a, c) { a = b.Hd(a); var l = b.fc(a); if (!O && !b.l(l, "nodrag") && sc() && (!c || a.touches.length == 1)) { B = d; yb = k; R = j; b.f(h, c ? "touchmove" : "mousemove", Bb); b.ib(); P = 0; gc(); if (!qb) x = 0; if (c) { var g = a.touches[0]; ub = g.clientX; vb = g.clientY } else { var f = b.Nd(a); ub = f.x; vb = f.y } H = 0; hb = 0; jb = 0; e.j(i.se, t(G), G, a) } } function Bb(e) { if (B) { e = b.Hd(e); var f; if (e.type != "mousemove") { var l = e.touches[0]; f = { x: l.clientX, y: l.clientY } } else f = b.Nd(e); if (f) { var j = f.x - ub, k = f.y - vb; if (c.floor(G) != G) x = x || fb & O; if ((j || k) && !x) { if (O == 3) if (c.abs(k) > c.abs(j)) x = 2; else x = 1; else x = O; if (ob && x == 1 && c.abs(k) - c.abs(j) > 3) yb = d } if (x) { var a = k, i = Ab; if (x == 1) { a = j; i = zb } if (!(D & 1)) { if (a > 0) { var g = i * s, h = a - g; if (h > 0) a = g + c.sqrt(h) * 5 } if (a < 0) { var g = i * (r - u - s), h = -a - g; if (h > 0) a = -g - c.sqrt(h) * 5 } } if (H - hb < -2) jb = 0; else if (H - hb > 2) jb = -1; hb = H; H = a; sb = G - H / i / (Y || 1); if (H && x && !yb) { b.Qb(e); if (!M) z.Kf(sb); else z.zf(sb) } } } } } function bb() { qc(); if (B) { B = k; b.ib(); b.T(h, "mousemove", Bb); b.T(h, "touchmove", Bb); P = H; z.lb(); var a = w.gb(); e.j(i.re, t(a), a, t(G), G); E & 12 && Pb(); ec(d) } } function jc(c) { if (P) { b.gf(c); var a = b.fc(c); while (a && v !== a) { a.tagName == "A" && b.Qb(c); try { a = a.parentNode } catch (d) { break } } } } function Jb(a) { C[s]; s = t(a); tb = C[s]; Tb(a); return s } function Dc(a, b) { x = 0; Jb(a); e.j(i.Ge, t(a), b) } function Tb(a, c) { wb = a; b.g(S, function (b) { b.Dc(t(a), a, c) }) } function sc() { var b = i.rd || 0, a = X; if (ob) a & 1 && (a &= 1); i.rd |= a; return O = a & ~b } function qc() { if (O) { i.rd &= ~X; O = 0 } } function Xb() { var a = b.Vb(); b.L(a, V); b.A(a, "absolute"); return a } function t(a) { return (a % r + r) % r } function kc(b, d) { if (d) if (!D) { b = c.min(c.max(b + wb, 0), r - u); d = k } else if (D & 2) { b = t(b + wb); d = k } cb(b, a.tc, d) } function xb() { b.g(S, function (a) { a.mc(a.ac.Pf <= F) }) } function hc() { if (!F) { F = 1; xb(); if (!B) { E & 12 && ec(); E & 3 && C[s].lc() } } } function Ec() { if (F) { F = 0; xb(); B || !(E & 12) || gc() } } function ic() { V = { hb: K, eb: J, c: 0, e: 0 }; b.g(T, function (a) { b.L(a, V); b.A(a, "absolute"); b.yb(a, "hidden"); b.V(a) }); b.L(gb, V) } function ab(b, a) { cb(b, a, d) } function cb(g, f, j) { if (Rb && (!B && (F || !(E & 12)) || a.vd)) { M = d; B = k; z.lb(); if (f == l) f = Vb; var e = Cb.Jb(), b = g; if (j) { b = e + g; if (g > 0) b = c.ceil(b); else b = c.floor(b) } if (D & 2) b = t(b); if (!(D & 1)) b = c.max(0, c.min(b, r - u)); var i = (b - e) % r; b = e + i; var h = e == b ? 0 : f * c.abs(i); h = c.min(h, f * u * 1.5); z.Lb(e, b, h || 1) } } e.Xc = function () { if (!N) { N = d; C[s] && C[s].lc() } }; function W() { return b.n(y || n) } function nb() { return b.o(y || n) } e.cb = W; e.ob = nb; function Eb(c, d) { if (c == l) return b.n(n); if (!y) { var a = b.Vb(h); b.Ad(a, b.Ad(n)); b.Ob(a, b.Ob(n)); b.bb(a, "block"); b.A(a, "relative"); b.U(a, 0); b.O(a, 0); b.yb(a, "visible"); y = b.Vb(h); b.A(y, "absolute"); b.U(y, 0); b.O(y, 0); b.n(y, b.n(n)); b.o(y, b.o(n)); b.Ic(y, "0 0"); b.S(y, a); var g = b.Nb(n); b.S(n, y); b.fb(n, "backgroundImage", ""); b.g(g, function (c) { b.S(b.l(c, "noscale") ? n : a, c); b.l(c, "autocenter") && Lb.push(c) }) } Y = c / (d ? b.o : b.n)(y); b.uf(y, Y); var f = d ? Y * W() : c, e = d ? c : Y * nb(); b.n(n, f); b.o(n, e); b.g(Lb, function (a) { var c = b.ae(b.l(a, "autocenter")); b.ge(a, c) }) } e.wf = Eb; o.call(e); e.sb = n = b.zb(n); var a = b.H({ wb: 0, Ee: 1, sc: 1, uc: 0, Cc: k, Cb: 1, Gb: d, vd: d, Gc: 1, Nc: 3e3, Qc: 1, tc: 500, Bf: f.gd, ld: 20, Rc: 0, i: 1, Sc: 0, Me: 1, vc: 1, Tc: 1 }, fc); a.Gb = a.Gb && b.Cf(); if (a.Ne != l) a.Nc = a.Ne; if (a.Qe != l) a.Sc = a.Qe; var fb = a.vc & 3, tc = (a.vc & 4) / -4 || 1, mb = a.Ue, I = b.H({ W: q, Gb: a.Gb }, a.Mf); I.Fb = I.Fb || I.Lf; var Fb = a.Re, Z = a.Te, eb = a.Nf, Q = !a.Me, y, v = b.M(n, "slides", Q), gb = b.M(n, "loading", Q) || b.Vb(h), Nb = b.M(n, "navigator", Q), dc = b.M(n, "arrowleft", Q), ac = b.M(n, "arrowright", Q), Mb = b.M(n, "thumbnavigator", Q), pc = b.n(v), nc = b.o(v), V, T = [], uc = b.Nb(v); b.g(uc, function (a) { if (a.tagName == "DIV" && !b.l(a, "u")) T.push(a); else b.ub() && b.K(a, (b.K(a) || 0) + 1) }); var s = -1, wb, tb, r = T.length, K = a.Ve || pc, J = a.Xe || nc, Wb = a.Rc, zb = K + Wb, Ab = J + Wb, bc = fb & 1 ? zb : Ab, u = c.min(a.i, r), lb, x, O, yb, S = [], Qb, Sb, Ob, cc, Cc, N, E = a.Qc, lc = a.Nc, Vb = a.tc, rb, ib, kb, Rb = u < r, D = Rb ? a.Cb : 0, X, P, F = 1, M, B, R, ub = 0, vb = 0, H, hb, jb, Cb, w, U, z, Ub = new oc, Y, Lb = []; if (r) { if (a.Gb) Kb = function (a, c, d) { b.Db(a, { qb: c, tb: d }) }; N = a.Cc; e.ac = fc; ic(); b.C(n, "jssor-slider", d); b.K(v, b.K(v) || 0); b.A(v, "absolute"); lb = b.X(v, d); b.Rb(lb, v); if (mb) { cc = mb.Of; rb = mb.W; ib = u == 1 && r > 1 && rb && (!b.qd() || b.td() >= 8) } kb = ib || u >= r || !(D & 1) ? 0 : a.Sc; X = (u > 1 || kb ? fb : -1) & a.Tc; var Gb = v, C = [], A, L, Db = b.Hf(), ob = Db.bf, G, qb, Ib, sb; Db.ud && b.fb(Gb, Db.ud, ([j, "pan-y", "pan-x", "none"])[X] || ""); U = new zc; if (ib) A = new rb(Ub, K, J, mb, ob); b.S(lb, U.hc); b.yb(v, "hidden"); L = Xb(); b.fb(L, "backgroundColor", "#000"); b.Bb(L, 0); b.Rb(L, Gb.firstChild, Gb); for (var db = 0; db < T.length; db++) { var wc = T[db], yc = new xc(wc, db); C.push(yc) } b.V(gb); Cb = new Ac; z = new mc(Cb, U); b.f(v, "click", jc, d); b.f(n, "mouseout", b.jc(hc, n)); b.f(n, "mouseover", b.jc(Ec, n)); if (X) { b.f(v, "mousedown", Yb); b.f(v, "touchstart", rc); b.f(v, "dragstart", Hb); b.f(v, "selectstart", Hb); b.f(h, "mouseup", bb); b.f(h, "touchend", bb); b.f(h, "touchcancel", bb); b.f(g, "blur", bb) } E &= ob ? 10 : 5; if (Nb && Fb) { Qb = new Fb.W(Nb, Fb, W(), nb()); S.push(Qb) } if (Z && dc && ac) { Z.Cb = D; Z.i = u; Sb = new Z.W(dc, ac, Z, W(), nb()); S.push(Sb) } if (Mb && eb) { eb.uc = a.uc; Ob = new eb.W(Mb, eb); S.push(Ob) } b.g(S, function (a) { a.xc(r, C, gb); a.Ib(p.yc, kc) }); b.fb(n, "visibility", "visible"); Eb(W()); xb(); a.sc && b.f(h, "keydown", function (b) { if (b.keyCode == 37) ab(-a.sc); else b.keyCode == 39 && ab(a.sc) }); var pb = a.uc; if (!(D & 1)) pb = c.max(0, c.min(pb, r - u)); z.Lb(pb, pb, 0) } }; i.Be = 21; i.se = 22; i.re = 23; i.Jf = 24; i.Df = 25; i.af = 26; i.ef = 27; i.te = 28; i.Gf = 202; i.Ge = 203; i.we = 206; i.ve = 207; i.ue = 208; i.ad = 209; var p = { yc: 1 }, r = function (e, C) { var f = this; o.call(f); e = b.zb(e); var s, A, z, r, l = 0, a, m, i, w, x, h, g, q, n, B = [], y = []; function v(a) { a != -1 && y[a].ne(a == l) } function t(a) { f.j(p.yc, a * m) } f.sb = e; f.Dc = function (a) { if (a != r) { var d = l, b = c.floor(a / m); l = b; r = a; v(d); v(b) } }; f.mc = function (a) { b.D(e, a) }; var u; f.xc = function (D) { if (!u) { s = c.ceil(D / m); l = 0; var p = q + w, r = n + x, o = c.ceil(s / i) - 1; A = q + p * (!h ? o : i - 1); z = n + r * (h ? o : i - 1); b.n(e, A); b.o(e, z); for (var f = 0; f < s; f++) { var C = b.sf(); b.hf(C, f + 1); var k = b.Xd(g, "numbertemplate", C, d); b.A(k, "absolute"); var v = f % (o + 1); b.O(k, !h ? p * v : f % i * p); b.U(k, h ? r * v : c.floor(f / (o + 1)) * r); b.S(e, k); B[f] = k; a.Ac & 1 && b.f(k, "click", b.Q(j, t, f)); a.Ac & 2 && b.f(k, "mouseover", b.jc(b.Q(j, t, f), k)); y[f] = b.cc(k) } u = d } }; f.ac = a = b.H({ Jd: 10, Ld: 10, pd: 1, Ac: 1 }, C); g = b.M(e, "prototype"); q = b.n(g); n = b.o(g); b.bc(g, e); m = a.nd || 1; i = a.k || 1; w = a.Jd; x = a.Ld; h = a.pd - 1; a.Fc == k && b.C(e, "noscale", d); a.Hb && b.C(e, "autocenter", a.Hb) }, t = function (a, g, h) { var c = this; o.call(c); var r, q, e, f, i; b.n(a); b.o(a); function l(a) { c.j(p.yc, a, d) } function n(c) { b.D(a, c || !h.Cb && e == 0); b.D(g, c || !h.Cb && e >= q - h.i); r = c } c.Dc = function (b, a, c) { if (c) e = a; else { e = b; n(r) } }; c.mc = n; var m; c.xc = function (c) { q = c; e = 0; if (!m) { b.f(a, "click", b.Q(j, l, -i)); b.f(g, "click", b.Q(j, l, i)); b.cc(a); b.cc(g); m = d } }; c.ac = f = b.H({ nd: 1 }, h); i = f.nd; if (f.Fc == k) { b.C(a, "noscale", d); b.C(g, "noscale", d) } if (f.Hb) { b.C(a, "autocenter", f.Hb); b.C(g, "autocenter", f.Hb) } }; function q(e, d, c) { var a = this; m.call(a, 0, c); a.Pc = b.Ed; a.Kc = 0; a.yd = c } jssor_1_slider_init = function () { var h = [{ q: 1200, x: .2, y: -.1, p: 20, i: 8, k: 4, a: 15, ab: { e: [.3, .7], c: [.3, .7] }, G: n.Kb, R: 260, m: { e: e.Xb, c: e.Xb, a: e.vb }, nb: d, J: { e: 1.3, c: 2.5 } }, { q: 1500, x: .3, y: -.3, p: 20, i: 8, k: 4, a: 15, ab: { e: [.1, .9], c: [.1, .9] }, I: d, G: n.Kb, R: 260, m: { e: e.Ub, c: e.Ub, a: e.vb }, nb: d, J: { e: .8, c: 2.5 } }, { q: 1500, x: .2, y: -.1, p: 20, i: 8, k: 4, a: 15, ab: { e: [.3, .7], c: [.3, .7] }, G: n.Kb, R: 260, m: { e: e.Xb, c: e.Xb, a: e.vb }, nb: d, J: { e: .8, c: 2.5 } }, { q: 1500, x: .3, y: -.3, p: 80, i: 8, k: 4, a: 15, ab: { e: [.3, .7], c: [.3, .7] }, m: { e: e.Ub, c: e.Ub, a: e.vb }, nb: d, J: { e: .8, c: 2.5 } }, { q: 1800, x: 1, y: .2, p: 30, i: 10, k: 5, a: 15, ab: { e: [.3, .7], c: [.3, .7] }, I: d, qc: d, G: n.Kb, R: 2050, m: { e: e.Se, c: e.Fe, a: e.Dd }, nb: d, J: { c: 1.3 } }, { q: 1e3, p: 30, i: 8, k: 4, a: 15, I: d, G: n.Kb, R: 2049, m: e.vb }, { q: 1e3, p: 80, i: 8, k: 4, a: 15, I: d, m: e.vb }, { q: 1e3, y: -1, i: 12, G: n.wc, gc: { Mc: 12 } }, { q: 1e3, x: -.2, p: 40, i: 12, I: d, G: n.wc, R: 260, m: { e: e.We, F: e.Dd }, F: 2, nb: d, J: { c: .5 } }, { q: 2e3, y: -1, p: 60, i: 15, I: d, G: n.wc, m: e.qe, J: { c: 1.5 } }], j = { Cc: d, Ue: { W: s, Fb: h, ie: 1 }, Te: { W: t }, Re: { W: r } }, f = new i("jssor_1", j); function a() { var b = f.sb.parentNode.clientWidth; if (b) { b = c.min(b, 1500); f.wf(b) } else g.setTimeout(a, 30) } a(); b.f(g, "load", a); b.f(g, "resize", a); b.f(g, "orientationchange", a) }
                })(window, document, Math, null, true, false)
</script>
<style>
.jssorb01{position:absolute}.jssorb01 div,.jssorb01 div:hover,.jssorb01 .av{position:absolute;width:12px;height:12px;filter:alpha(opacity=70);opacity:.7;overflow:hidden;cursor:pointer;border:#000 1px solid}.jssorb01 div{background-color:gray}.jssorb01 div:hover,.jssorb01 .av:hover{background-color:#d3d3d3}.jssorb01 .av{background-color:#fff}.jssorb01 .dn,.jssorb01 .dn:hover{background-color:#555}
    .jssora05l, .jssora05r {
        display: block;
        position: absolute;
        width: 40px;
        height: 40px;
        cursor: pointer;
        background: url('img/a17.png') no-repeat;
        overflow: hidden;
    }.jssora05l{background-position: -10px -40px;}.jssora05r{background-position:-70px -40px}.jssora05l:hover{background-position:-130px -40px}.jssora05r:hover{background-position:-190px -40px}.jssora05l.jssora05ldn{background-position:-250px -40px}.jssora05r.jssora05rdn{background-position:-310px -40px}.jssora05l.jssora05lds{background-position:-10px -40px;opacity:.3;pointer-events:none}.jssora05r.jssora05rds{background-position:-70px -40px;opacity:.3;pointer-events:none}
</style>


<div id="jssor_1" style="position: relative;  margin-bottom:30px;  margin-top:10px; border-radius:20px; top: 10px; 
 width:1000px;height:550px;  overflow: hidden; visibility: hidden;">
<!-- Loading Screen -->
    
<div data-u="loading" style="position: absolute; top: 0px; left: 0px;">
<div style="filter: alpha(opacity=70); opacity: 0.7; position: absolute; display: block; top: 0px; left: 0px; width: 100%; height: 100%;">

</div>
<div style="position:absolute;display:block;background:url('loading.gif') no-repeat center center;top:0px;left:0px;width:100%;height:100%;"></div>
   
</div>


  
<div data-u="slides" style="cursor: default; position: relative; top: 0px; left: 0px; width: 1000px; height: 550px; overflow: hidden;">

<a data-u="any" href="../pages/home.aspx" style="display:none">Traveller</a>

    <asp:Repeater ID="myRepeater" runat="server">
    <ItemTemplate>
        <div data-p="142.50" style="display: none;">
            <asp:ImageButton ID="yourImage" ClientIDMode="Static" data-u="image" PostBackUrl='<%# "../pages/Customer/detail_followup.aspx?place_id="+Eval("place_id") %>' style="height:100% !important;width:100% !important;"  runat="server"
                ImageUrl='<%# Eval("place_img") %>'
                ToolTip='<%# Eval("place_title") %>' />
        </div>
    </ItemTemplate>
</asp:Repeater>

     
</div>
<!-- Bullet Navigator -->
<div data-u="navigator" class="jssorb01" style="bottom:16px;right:16px;">
<div data-u="prototype" style="width:12px;height:12px;"></div>
</div>
<!-- Arrow Navigator -->
<span data-u="arrowleft" class="jssora05l" style="top:0px;left:8px;width:40px;height:40px;" data-autocenter="2"></span>
<span data-u="arrowright" class="jssora05r" style="top:0px;right:8px;width:40px;height:40px;" data-autocenter="2"></span>
</div>
<script type="text/javascript">jssor_1_slider_init();</script>


 

        </div>















    <!--slider image end-->
                 
                    
                     <div style="color: darkolivegreen;font-family: cursive;text-align:center;border-top: 2px solid whitesmoke;">
            <br />
            <em>Following is the map of all the interesting travelling locations in North Borneo</em><br /> 
                         <div id="map" style="margin-top:10px; border-radius:15px;    width:100%;height:500px;"></div>
             
                       
         </div>

        

    <div class=" active" style="margin-top:10px;">
        
      
        <div class="container">      
        <div class=" row-centered">
            
            

            <div class="panel panel-success">
               <div style="background-color: chocolate;" class="  panel-heading  row-centered bg-info">
                    <h5 style="color:wheat;font-family:cursive;font-size:20px;">Share Great Places in Borneo</h5></div>
                <div style="background-color:silver; " class="panel-body">
                
                      <div class="row-centered bg-danger">
                 
                        <asp:ImageButton  ClientIDMode="Static" ID="ImageButton2" runat="server" PostBackUrl="~/pages/Customer/Places.aspx" ImageUrl="~/images/marina1.jpg" style=" cursor:pointer;height:100% !important;width:100% !important;" />
                     </div>
                   
                   
                    <asp:LinkButton style="box-shadow: 2px 2px grey;border:outset;" ClientIDMode="Static" ID="serviceLinkBtn" CssClass="btn btn-lg btn-success btn-block" PostBackUrl="~/pages/Customer/Places.aspx" Text="Great Places in Borneo" runat="server" OnClick="serviceLinkBtn_Click" />
                </div>
            </div>
        
     
        
            <div class="panel panel-success">
                <div style="background-color: coral;" class="  panel-heading  row-centered bg-success">
                    <h5 style="color:white;font-family:cursive;font-size:20px; ">Share Great Stuffs in Borneo</h5></div>
                <div style="background-color:silver; " class="panel-body panel-info">
                    <div class="row-centered bg-info">
                 
                      <asp:ImageButton  ClientIDMode="Static" ID="ImageButton1" runat="server" PostBackUrl="~/pages/Customer/stuff.aspx" ImageUrl="~/images/top_img2.jpg" style="cursor:pointer; height:100% !important;width:100% !important;"/>
                     </div>
                   
                     <asp:LinkButton style="box-shadow: 2px 2px grey;border:outset;" ClientIDMode="Static" ID="itemLinkBtn" CssClass="btn btn-lg btn-primary btn-block" PostBackUrl="~/pages/Customer/stuff.aspx" Text="Interesting Stuffs in Borneo" runat="server" />
                </div>
            </div>


            

 
                 

           <script type="text/javascript">


        
               var item_place_id_array = <%=this.javaSerial.Serialize(item_place_id_array)%>;
                var item_title_array = <%=this.javaSerial.Serialize(share_item_title_array)%>;
               var item_n_array = <%=this.javaSerial.Serialize(share_item_name_array)%>;
               var item_latitude_array = <%=this.javaSerial.Serialize(lat_array)%>;
               var item_longitiude_array = <%=this.javaSerial.Serialize(long_array)%>;

               var item_img_array = <%=this.javaSerial.Serialize(b_img_array)%>;
               var item_desc_array = <%=this.javaSerial.Serialize(b_desc_array)%>;
               
               


               var map = new google.maps.Map(document.getElementById('map'), {
                   zoom: 12,
                   center: new google.maps.LatLng(5.956260, 116.102614),
                   mapTypeId: google.maps.MapTypeId.ROADMAP
               });

               var infowindow = new google.maps.InfoWindow();

               function direct(place_id){
                   
                   window.location.href = '../pages/Customer/detail_followup.aspx?place_id='+place_id+'';
               }


               var locations = [

             [item_n_array[i], item_latitude_array[i], item_longitiude_array[i]]
               ];

               var marker, i;

               for (i = 0; i < item_n_array.length; i++) {

                   console.log("test name"+item_n_array[i]);


                   marker = new google.maps.Marker({
                       position: new google.maps.LatLng(item_latitude_array[i], item_longitiude_array[i]),
                       map: map
                   });


                   
                   google.maps.event.addListener(map, 'click', function() {
                       infowindow.close();
                   });

                   google.maps.event.addListener(infowindow, 'domready', function() {

                       // Reference to the DIV that wraps the bottom of infowindow
                       var iwOuter = $('.gm-style-iw');

                       /*  this div   in a position b4 .gm-div style-iw.
                        * use jQuery and create a iwBackground variable,
                        * and took advantage of the existing reference .gm-style-iw for the previous div with .prev().
                       */
                       var iwBackground = iwOuter.prev();

                       // Removes background shadow DIV
                       iwBackground.children(':nth-child(2)').css({'display' : 'none'});

                       // Removes white background DIV
                       iwBackground.children(':nth-child(4)').css({'display' : 'none'});

                   
               
                       // Changes the desired tail shadow color.
                       iwBackground.children(':nth-child(3)').find('div').children().css({'box-shadow': 'rgba(72, 181, 233, 0.6) 0px 1px 6px', 'z-index' : '1'});

                       // Reference to the div that groups the close button elements.
                       var iwCloseBtn = iwOuter.next();

                       // Apply the desired effect to the close button
                       iwCloseBtn.css({opacity: '1', width:'17px',height:'17px', right: '-15px', top: '2px', border: '2px solid #48b5e9', 'border-radius': '15px', 'box-shadow': '0 0 5px #3990B9'});

                       // If the content of infowindow not exceed the set maximum height, then the gradient is removed.
                       if($('.iw-content').height() < 540){
                           $('.iw-bottom-gradient').css({display: 'none'});
                       }

                       // The API automatically applies 0.7 opacity to the button after the mouseout event. This function reverses this event to the desired value.
                       iwCloseBtn.mouseout(function(){
                           $(this).css({opacity: '1'});
                       });
                   });


                   google.maps.event.addListener(marker, 'click', (function (marker, i) {
                       return function () {

                           infowindow.open(map, marker);

                           var content = '<div id="iw-container">' +
                  '<div class="iw-title">'+item_title_array[i]+'</div>' +
                  '<div class="iw-content">' +
                    '<div class="iw-subTitle">'+item_n_array[i]+'</div>' +
                    '<img src="'+item_img_array[i]+'" style="cursor: pointer;" onclick="'+direct(item_place_id_array[i])+'" alt="'+item_n_array[i]+'" height="115" width="83">' +
                    '<p>'+item_desc_array[i]+'</p>' +
                  '</div>' +
                  '<div class="iw-bottom-gradient"></div>' +
                '</div>';

                       //    var html ="<div style='background-color:wheat;padding:20px;' onclick='direct()'><b>"+item_n_array[i]+"</b><hr/><img src='" + item_img_array[i] + "'   style='height:120px;width:150px;'/><br/><p>"+item_desc_array[i]+"</p></div>";
                           infowindow.setContent(content);
                           //infowindow.open(map, marker, content);

               
                       }
                   })(marker, i));
               }
               //  }

  </script>


            
          <script type="text/javascript">
              function display_c() {
                  var refresh = 1000; // Refresh rate in milli seconds
                  mytime = setTimeout('display_ct()', refresh)
              }

              function display_ct() {
                  var strcount
                  var x = new Date()
                  document.getElementById('ct').innerHTML = x;
                  tt = display_c();
              }
</script>
          
    <div style="color:66FF99; font-weight: bold; text-align:right"; id='ct'></div>
		
            </div>
             </div>
            </div>	   





    </div>
     </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">
</asp:Content> 