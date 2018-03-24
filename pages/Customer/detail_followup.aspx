<%@ Page Title="Detail Page" Async="true"  Language="C#" EnableEventValidation="false" MasterPageFile="~/master/main.master" AutoEventWireup="true" CodeFile="detail_followup.aspx.cs" Inherits="pages_detail_followup" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" Async="true" ContentPlaceHolderID="page_head" Runat="Server">

    <script type="text/javascript" src="js/jquery-1.12.3.js"></script>
   
    <style type="text/css">

       

        #ImageButton_like_detail:hover {
        opacity:0.8;
        
        }

        #comment_title {
            background-color: cadetblue;
        }
        
  .container_comment {
	border:1px outset wheat;
    border-radius:15px;
        border: 1px outset wheat;
    background-color: aliceblue;
    
    padding: 20px;
    margin: 10px 0;
}

.darker {
    border-color: #ccc;
    background-color: antiquewhite;
}

.container_comment::after {
    content: "";
    clear: both;
    display: table;
}


.img_right{
 
 float: right;
     margin-left: 10px !important;
}

.img_left{
 
 float: left;
 margin-right: 10px !important;
}

  

.container_comment .profile_div{
 
 margin-right: 10px;
}

      .class_clicked {
     
        }

 

.container_comment .profile_div img{
    float: left;
   max-width: 60px;
    max-height: 60px;
    width: 100%;
    margin-right: 5px;
    border-radius: 50%;
    border:2px double wheat;
}

.container_comment .profile_div img.right {
    float: right;
    margin-left: 20px;
    margin-right:0;
}

.time-right {
font-size:inherit;
    float: right;
    color: #aaa;
}

.time-left {
padding-left: 10px;
font-size:inherit;
    float: left;
    color: #999;

}

.profile_div{
    font-weight: 700;
	display:flex;
    align-items:center;
}

        #btn_like:hover {
            opacity:0.6;
            color:white;
            background-color:brown;
        }

        #detail_info_div {
        padding:15px;
        
        }

        .p_detail {
         font-size:17px;
         font-weight:700;
         font-family:Cambria;
         color:darkblue;
         padding:10px;
         background-color:#f1f1f1;
         border:1px outset wheat;
         border-radius:15px;
        }
        b{
            font-weight:500;
            color:black;
            font-family:cursive;
            font-size:16px;
        }
        h3{
 font-family: 'Android Hollow';
            font-size:30px;

        }
    </style>
     <style type="text/css">
            .alertBox
            {
                 border-radius: 20px;
                color: wheat;
                position: absolute !important;
	            top:0 !important;
	            bottom: 0 !important;
	            left: 0 !important;
	            right: 0 !important;
	            margin: auto !important;
                 width: 50% !important;
           
               background-color:black !important;
                filter:alpha(opacity=80);
                opacity:0.8;
                border: 2px outset #ccc;
                border-radius: 4px;
                box-sizing: border-box;
                padding: 4px 8px;
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
        <script type="text/javascript">
            function closeAlert(e) {
                e.preventDefault();
                this.parentNode.style.display = "none";
            }
        </script>
</asp:Content>
<asp:Content ID="Content2" Async="true" style="background-image:url(bg.jpg);"    ContentPlaceHolderID="pageContent" Runat="Server">
    <h4 style="font-weight: 700;font-family: cursive;">
        <a href="javascript:history.go(-1)" onclick="history.go(-1);return false;"> 
            <asp:Button ID="backBtn" CssClass="btn btn-sm btn-info" Text="<< Back" style="font-weight:700;" runat="server" /> </a>
                  </h4>
    <h4 style="font-weight: 700;font-family: cursive;">Detail Sharing Information</h4>
    <hr />
    <div class=" row-centered">


         <div class="col-md-12" id="tradingDetailsDiv" style="padding-top: 10px;padding-bottom: 10px;margin-bottom:10px;">
                <script type="text/javascript">

                    $(document).ready(function () {
                        //
                        if (/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|ipad|iris|kindle|Android|Silk|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test(navigator.userAgent)
|| /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(navigator.userAgent.substr(0, 4))) {
                            //phone size:

                            $("#img").css("width", "90%");
                            $("#img").css("height", "90%");
                        } else {

                            //desktop size

                            $("#img").css("width", "700px");
                            $("#img").css("height", "500px");

                        }
                    });


               window.onresize = function () {
                   // your code
                   if (/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|ipad|iris|kindle|Android|Silk|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test(navigator.userAgent)
|| /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(navigator.userAgent.substr(0, 4))) {
                       //phone size:
                       
                       $("#img").css("width", "90%");
                       $("#img").css("height", "90%");
                   } else {
                      
                       //desktop size
                    
                       $("#img").css("width", "300px");
                       $("#img").css("height", "300px");

                   }
               };
           
          
</script>



             
   <div id="map_post" style=" border: 5px outset;border-radius:20px;   width: 100%;height: 400px;margin-top:10px;margin-bottom:10px;"></div>
 

                 <asp:UpdatePanel   ID="UpdatePanel1" runat="server">
                     <ContentTemplate>
                     
              
           
               <!--
          
        <p class="p_detail">          <b>Share-Info ID:</b> 
               <asp:Label ID="id_lbl"  runat="server" ClientIDMode="Static" ViewStateMode="Enabled" ValidateRequestMode="Enabled"></asp:Label><br />
          </p>    

           <p class="p_detail">  <asp:Label ID="item_name_lbl" style="font-family: calibri;font-size:25px ;padding-bottom:10px;margin-bottom:10px" runat="server"></asp:Label><br />
               <asp:Image ID="img"  ClientIDMode="Static" Height="70%" Width="70%"  style="border-radius:20px;border:5px outset orange" runat="server" /><br />

             <asp:FileUpload CssClass="btn-success" style="display:none;" ID="FileUpload1" runat="server" />  
                 <asp:Label ID="lblCurrentFile" runat="server"></asp:Label><br />
      
                <asp:HiddenField ID="HiddenField1" runat="server" />
             
             <br />
             
           </p>
     
           <p class="p_detail">  <b>Description:</b> <asp:Label   ID="desc_lbl" runat="server"></asp:Label><br />
           </p>

           <p class="p_detail">   <b>Longitude: </b> <asp:Label    ID="longi_lbl" runat="server"></asp:Label><br />
           </p>
                
          <p class="p_detail">   <b> Latitude: </b><asp:Label    ID="lati_lbl" runat="server"></asp:Label><br />
            </p>


      <p class="p_detail">       <b> Time Uploaded: </b><asp:Label    ID="time_lbl" runat="server"></asp:Label><br />
       </p>
             
              
         <p class="p_detail">      
               <b>shared by:</b> 
             <span>
               <asp:Image ID="img_profile"  ClientIDMode="Static"  style="float:right;height:50px;width:50px;border-radius:50%;border:3px double white" runat="server" /><br />

              <asp:Label ID="posted_by"   runat="server"></asp:Label>
                 </span><br />
         </p>

               -->

		       

                 <asp:PlaceHolder ID="ph_share_info" runat="server"  ></asp:PlaceHolder>
 
                   
                          
              <script type="text/javascript">

 
                var get_pos_lat = <%=this.javaSerial.Serialize(get_pos_lat)%>;
                  var get_pos_long = <%=this.javaSerial.Serialize(get_pos_long)%>;
                  var get_pos_address = <%=this.javaSerial.Serialize(get_pos_address)%>;

                  var get_pos_title = <%=this.javaSerial.Serialize(get_pos_TITLE)%>;
                    var get_pos_name = <%=this.javaSerial.Serialize(get_pos_NAME)%>;
                  var get_pos_img = <%=this.javaSerial.Serialize(get_pos_IMG)%>;
                     var get_pos_desc = <%=this.javaSerial.Serialize(get_pos_DESC)%>;

                  /*
                  
                    get_pos_TITLE 

                get_pos_IMG  
                get_pos_DESC 
                  */
                  //get_pos_address
			   
			   
               function initialize() {//set Sabah kk area as default map location 116.071516,5.977545
                   var latLng = new google.maps.LatLng(get_pos_lat,get_pos_long);
				   
				   console.log('pos_lat:'+get_pos_lat);
				    console.log('pos_long:'+get_pos_long);
				   
                   var map = new google.maps.Map(document.getElementById('map_post'), {
                       zoom: 16,
                       center: latLng,
                       mapTypeId: google.maps.MapTypeId.ROADMAP
                   });
                   var marker = new google.maps.Marker({
                       position: latLng,
                       title: get_pos_address,
                       map: map,
                       draggable: true
                   });
 
                   map.addListener('click', function(event) {
                       clearMarkers();
                       addMarker(event.latLng);
                   });


                   // Update current position info.
                 //  updateMarkerPosition(latLng);
                   //geocodePosition(latLng);

                   // Add dragging event listeners.
                   google.maps.event.addListener(marker, 'dragstart', function() {
                      // updateMarkerAddress('Dragging...');
                   });

                   google.maps.event.addListener(marker, 'drag', function() {
                     
                      // updateMarkerPosition(marker.getPosition());
                   });

                   google.maps.event.addListener(marker, 'dragend', function() {
                     
                       //geocodePosition(marker.getPosition());
                   });

                 
                   var infowindow = new google.maps.InfoWindow();

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
                       iwCloseBtn.css({opacity: '1', width:'17px',height:'17px', right: '-8px', top: '14px', border: '2px solid #48b5e9', 'border-radius': '15px', 'box-shadow': '0 0 5px #3990B9'});

                       // If the content of infowindow not exceed the set maximum height, then the gradient is removed.
                       if($('.iw-content').height() < 540){
                           $('.iw-bottom-gradient').css({display: 'none'});
                       }

                       // The API automatically applies 0.7 opacity to the button after the mouseout event. This function reverses this event to the desired value.
                       iwCloseBtn.mouseout(function(){
                           $(this).css({opacity: '1'});
                       });
                   });


                   google.maps.event.addListener(marker, 'click', (function (marker) {
                       return function () {

                           var content = '<div id="iw-container">' +
                   '<div class="iw-title">'+get_pos_title+'</div>' +
                   '<div class="iw-content">' +
                     '<div class="iw-subTitle">'+get_pos_name+'</div>' +
                     '<img src="'+get_pos_img+'" alt="'+get_pos_name+'" height="115" width="83">' +
                     '<p>'+get_pos_desc+'</p>' +
                   '</div>' +
                   '<div class="iw-bottom-gradient"></div>' +
                 '</div>';
                           var html ="<div style='background-color:antiquewhite;padding:20px;border-radius:15px;' ><b>"+get_pos_title+"<hr/><img src='" + get_pos_img + "'   style='height:50%;width:80%;border-radius:15px;margin-bottom:15px;'/><br/><p>"+get_pos_desc+"</p></div>";
                           infowindow.setContent(content);
                           infowindow.open(map, marker, content);

                
                       }
                   })(marker));
               }
               
               var markers = [];

               var geocoder = new google.maps.Geocoder();
  
 
               
               // Adds a marker to the map and push to the array.
               function addMarker(location) {
                   var marker = new google.maps.Marker({
                       position: location,
                       map: map
                   });
                   markers.push(marker);
               }

               // Sets the map on all markers in the array.
               function setMapOnAll(map) {
                   for (var i = 0; i < markers.length; i++) {
                       markers[i].setMap(map);
                   }
               }

               // Removes the markers from the map, but keeps them in the array.
               function clearMarkers() {
                   setMapOnAll(null);
               }

               // Shows any markers currently in the array.
               function showMarkers() {
                   setMapOnAll(map);
               }

               // Deletes all markers in the array by removing references to them.
               function deleteMarkers() {
                   clearMarkers();
                   markers = [];
               } 
			   
                // Onload handler to fire off the app.
               google.maps.event.addDomListener(window, 'load', initialize);

             

               function hide(){
                   document.getElementById("AlertBox").style.display = 'none';
               
               }
 
</script>
           

          <!--  <div style="cursor:pointer;padding:10px;" >
          <b>Liked by </b>  <asp:Label ID="like_count_lbl" runat="server"></asp:Label> <b> Person(s)</b> <br />
           </div >  -->
                       
              
           
            
         
       
   <asp:PlaceHolder ID="comment_ph" runat="server"  ></asp:PlaceHolder>
 

                <asp:Timer ID="Timer1" runat="server" Interval="3000" OnTick="refresh_detail_page"></asp:Timer>
                     </ContentTemplate>
              </asp:UpdatePanel>
                      
                  <asp:ImageButton ClientIDMode="Static"  ID="ImageButton_like_detail" AutoPostBack="" OnClick="share_like_btn_click" ImageUrl="~/images/like.png" style=" background-color: wheat;cursor: pointer;padding: 2px;border-radius: 50%;border: 2px double white;width: 60px;" runat="server" />
                  <br/> <asp:Label ID="like_hint" Visible="false" Text="You have liked this, tap again to unlike" runat="server"></asp:Label>
          
                  


             <div id="commment_section" style="    margin-top: 10px;">
             <div class="form-group center-block">
                <asp:TextBox ID="txt_comment" CssClass="form-control" Rows="3" Columns="140" placeholder="Write any thing to chat with Travellers . . ." TextMode="MultiLine" style="overflow-y:scroll;" runat="server"></asp:TextBox>
             </div>  
                   <div class="form-group center-block">
             
                <asp:Button ID="submutNewfollowupBtn" ClientIDMode="Static" OnClick="btn_send_comment_click" Text="Send" CssClass="btn btn-primary" runat="server"   style="height:30px;width:100%;" />
            
                        </div>
             </div>


             </div>





    </div>
  
    <asp:Label ID="msg" runat="server"></asp:Label>
   
     <div runat="server" ClientIDMode="Static"  id="AlertBox" class="alertBox" Visible="false">
                <div runat="server" id="AlertBoxMessage"></div>
      
                <button class="btn-success" style="border-radius:10px;" onclick="closeAlert.call(this, event);hide();">Ok</button>
            </div>
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">
</asp:Content>

