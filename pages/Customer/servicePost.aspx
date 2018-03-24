<%@ Page Title="Share in Borneo Traveller" Async="true" EnableViewState="true" Language="C#" EnableEventValidation="false"  MasterPageFile="~/master/main.master" AutoEventWireup="true" CodeFile="servicePost.aspx.cs" Inherits="servicePost" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="page_head" Runat="Server">
      <link href="css/login.css" type="text/css" rel="Stylesheet" />

    <!--init_fade_in-->
<script type="text/javascript" src="js/jquery-1.12.3.js"></script>
   
             <style type="text/css">
.modalBackground
{

    background-color:black;
    filter:alpha(opacity=70);
    opacity:0.7;
}
     #mp1 
{
    background-color:orange; 
   
}

      #fast_panel 
{
   background-color:gray;
    filter:alpha(opacity=60) !important;
    opacity:0.91;
    border-radius:20px;
   
}

       .popForm 
{
    background-color:orange; 
   
}



                 .btn {
                    border:outset 2px;
                    box-shadow:2px 2px grey;
                 
                 }

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
       </style>
           
      
        <script type="text/javascript">
            function closeAlert(e) {
                e.preventDefault();
                this.parentNode.style.display = "none";
            }


        </script>
</asp:Content>


<asp:Content ID="Content2" style="background-image:url(bg.jpg)" ContentPlaceHolderID="pageContent" Runat="Server">
  
    <div class="container">      
        <div class="  row-centered">
             
                   <div class="col-md-12">
                     
                      <h3>  Share great places / nice things in Borneo</h3>
                      <hr />
                     
                     <a href="~/pages/Home.aspx" style="cursor:pointer;" runat="server"> <img src="../../images/profile.PNG" style="    border-radius: 20px;border: 5px outset;cursor:pointer;" class="frontImage" /> </a>
                          
                      <hr />
                     
                       
            <div class="form-group center-block">

                 <div id="map_post" style="     border: 5px outset;border-radius:20px;    width: 100%;height: 400px;"></div>
                <p style="font-family:cursive;padding:5px;border-bottom:1px solid brown;">Drag the Map Marker to locate your location</p>
           <script type="text/javascript">
                
               var markers = [];

               var geocoder = new google.maps.Geocoder();

               function geocodePosition(pos) {
                   geocoder.geocode({
                       latLng: pos
                   }, function(responses) {
                       if (responses && responses.length > 0) {
                           updateMarkerAddress(responses[0].formatted_address);
                       } else {
                           updateMarkerAddress('Cannot determine address at this location.');
                       }
                   });
               }

               function updateMarkerStatus(str) {
                   document.getElementById('markerStatus').value = str;
               }

               function updateMarkerPosition(latLng) {
                   document.getElementById('txt_lat').value =   latLng.lat().toFixed(6);
                   document.getElementById('txt_long').value=   latLng.lng().toFixed(6);

                   var hdnfldVariable_long = document.getElementById('HiddenField_long');
                   hdnfldVariable_long.value = latLng.lng().toFixed(6);

                   var hdnfldVariable_lat = document.getElementById('HiddenField_lat');
                   hdnfldVariable_lat.value = latLng.lat().toFixed(6);


               }

               function updateMarkerAddress(str) {
                   document.getElementById('address').value = str;
                   document.getElementById('HiddenField_address').value = str;
                   
               }
               
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

               var kk_long='116.071516';
               var kk_lat='5.977545';
               function initialize() {//set Sabah kk area as default map location 116.071516,5.977545
                   var latLng = new google.maps.LatLng(kk_lat,kk_long);
                   var map = new google.maps.Map(document.getElementById('map_post'), {
                       zoom: 16,
                       center: latLng,
                       mapTypeId: google.maps.MapTypeId.ROADMAP
                   });
                   var marker = new google.maps.Marker({
                       position: latLng,
                       title: 'Your Sharing Location',
                       map: map,
                       draggable: true
                   });
                   map.addListener('click', function(event) {
                       clearMarkers();
                       addMarker(event.latLng);
                   });
                   // Update current position info.
                   updateMarkerPosition(latLng);
                   geocodePosition(latLng);

                   // Add dragging event listeners.
                   google.maps.event.addListener(marker, 'dragstart', function() {
                       updateMarkerAddress('Dragging...');
                   });

                   google.maps.event.addListener(marker, 'drag', function() {
                       updateMarkerStatus('Dragging...');
                       updateMarkerPosition(marker.getPosition());
                   });

                   google.maps.event.addListener(marker, 'dragend', function() {
                       updateMarkerStatus('Drag ended');
                       geocodePosition(marker.getPosition());
                   });
               }

               // Onload handler to fire off the app.
               google.maps.event.addDomListener(window, 'load', initialize);
 
</script>
                
                   </div>

             

 
              
            <div  style="width=100%" class="form-group center-block">

                <div style="width=50%">
                <asp:Label Text="Longitude" style="font-weight:600;" runat="server"></asp:Label>
                    <asp:HiddenField ID="HiddenField_long" ClientIDMode="Static" runat="server" />
                <asp:TextBox ID="txt_long" ClientIDMode="Static"  CssClass="form-control" runat="server" Enabled="False"></asp:TextBox>
           </div>

                <div  style="width=50%">
                   <asp:Label Text="Latitude" style="font-weight:600;" runat="server"></asp:Label>
                    <asp:HiddenField ID="HiddenField_lat" ClientIDMode="Static" runat="server" />
                <asp:TextBox ID="txt_lat" ClientIDMode="Static"  CssClass="form-control" runat="server" Enabled="False"></asp:TextBox>
        
                </div>
            </div>

            <div id="divResult" class="form-group center-block">
                   <asp:Label Text="Address" style="font-weight:600;" ClientIDMode="Static" runat="server"></asp:Label>
                     <asp:HiddenField ID="HiddenField_address" ClientIDMode="Static" runat="server" />
              
                  <asp:TextBox ID="address" ClientIDMode="Static"  CssClass="form-control" runat="server" Enabled="False"></asp:TextBox>
          <asp:TextBox ID="markerStatus" ClientIDMode="Static"  CssClass="form-control" runat="server" Enabled="False"></asp:TextBox>
        

             </div>
   
                            <h4 style="font-size:14px;">>> Pick a Location above and then Click Here to Share this in Borneo Traveller:<br/>
                        <asp:Button   ID="add_new_service_post" ClientIDMode="Static" CssClass="  btn btn-info"  style="font-weight: 700;margin-top:10px;width:100%;color:white;" Text="Share this!" runat="server"   OnClick="save_current_info"   />
     
                  
                              

                            </h4>
                       <br/>
       <h4 style="font-size:14px;">Tired on filling detail info.? click here!<br/>
                     
                         <asp:Button   ID="post_minimalist" CssClass="  btn btn-warning"  style="font-weight: 700;margin-top:10px;width:100%;color:white;" Text="Fast Share!" runat="server"   OnClick="fast_share_click"   />
      </h4>
                       
                       
                       
                       
                     <!--
       modal popup control example referenced from
       https://www.codeproject.com/Articles/34996/ASP-NET-AJAX-Control-Toolkit-ModalPopupExtender-Co
       
       fast share-->  
       <cc2:ModalPopupExtender ID="mp2" runat="server" PopupControlID="fast_panel" TargetControlID="post_minimalist" CancelControlID="btn_fast_cancel" ></cc2:ModalPopupExtender>
   
    <asp:Panel ID="fast_panel" ClientIDMode="Static" runat="server" style ="padding: 10px; display:none;" align="center" ScrollBars="Vertical" >      
      
    
               <h3><b style="color:white;">Share Your Travel Memo</b></h3>
            

            <div class="form-group center-block">
                 <asp:Label Text="Pick a Travel Image" style="color:white;font-weight:600;"  runat="server"></asp:Label>
               <asp:Image ID="Image1"   Height="250px" Width="250px" runat="server" Visible="False" /><br />

             <asp:FileUpload CssClass="btn-success" style="margin-top: 10px;width: 100%;padding: 10px;font-size: 15px;border-radius: 20px;border: 5px double;background-color: chocolate;opacity: .9;" ID="FileUpload2" runat="server" />  
                 <asp:Label ID="Label1" runat="server"></asp:Label><br />
      
                <asp:HiddenField ID="HiddenField2" runat="server" />
             
            </div>


           

          

            <div class="form-group form-inline">
                <asp:Button ID="btn_fast_post"  style="width:100%;"  CssClass="btn btn-primary"   Text="Submit" runat="server" OnClick="submit_fast_btn_Click" />
           </div>
               <div class="form-group form-inline"> 
                    <asp:Button ID="btn_fast_cancel" runat="server"  style="width:100%;"  CssClass="btn btn-info" Text="Cancel" />
            </div>
            <div class="form-group form-inline">
                <asp:Label ID="Label2" runat="server"></asp:Label>
            </div>  
              
          
        </asp:Panel> 
   


                       
                       
                                           
                       <!--  service-->          
     <cc2:ModalPopupExtender ID="mp1" runat="server" PopupControlID="post_panel" TargetControlID="add_new_service_post" CancelControlID="btnClose" BackgroundCssClass="modalBackground"></cc2:ModalPopupExtender>
   
    <asp:Panel ID="post_panel" runat="server" CssClass="popForm" style ="padding: 10px;border: 5px outset orangered;display:none;" align="center" ScrollBars="Vertical" >      
      
   
         <div id="srollableTableDiv" style="width:100%;height:100%;" class="  progress-bar-striped">
           
               <h3><b >Share Your Travel Memo</b></h3>
            

            <div class="form-group center-block">
                 <asp:Label Text="Pick a Travel Image" style="font-weight:600;"  runat="server"></asp:Label>
               <asp:Image ID="img"   Height="250px" Width="250px" runat="server" Visible="False" /><br />

             <asp:FileUpload CssClass="btn-success" style="margin-top: 10px;width: 100%;padding: 10px;font-size: 15px;border-radius: 20px;border: 5px double;background-color: chocolate;opacity: .9;" ID="FileUpload1" runat="server" />  
                 <asp:Label ID="lblCurrentFile" runat="server"></asp:Label><br />
      
                <asp:HiddenField ID="HiddenField1" runat="server" />
             
            </div>


            <div class="form-group center-block">
                <asp:Label Text="Title of Share Block" style="font-weight:600;"  runat="server"></asp:Label>
                <asp:TextBox ID="place_title" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

             <div class="form-group center-block">
                <asp:Label Text="Place Name" style="font-weight:600;"  runat="server"></asp:Label>
                <asp:TextBox ID="place_name" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="form-group center-block">
                <asp:Label Text="Description" style="font-weight:600;"  runat="server"></asp:Label>
                <asp:TextBox ID="txt_description" CssClass="form-control" runat="server" Rows="3" TextMode="MultiLine"></asp:TextBox>
           </div>

          


            <div class="form-group center-block">
                <asp:Label Text="Type of Share" style="font-weight:600;" runat="server"></asp:Label>
                <asp:DropDownList ID="DropDownList_type" OnSelectedIndexChanged="selected_index_changed" style="width: 100%;height: 35px;border-radius: 5px;font-size: 16px;padding-left: 5px;" runat="server"></asp:DropDownList>
                </div>

            <div class="form-group form-inline">
                <asp:Button ID="submit_item_btn" ClientIDMode="Static" style="width:100%;"  CssClass="btn btn-primary"   Text="Submit" runat="server" OnClick="submit_item_btn_Click" />
           </div>
               <div class="form-group form-inline"> 
                    <asp:Button ID="btnClose" ClientIDMode="Static" runat="server" style="width:100%;"   CssClass="btn btn-info" Text="Cancel" />
            </div>
            <div class="form-group form-inline">
                <asp:Label ID="addServiceLabel" runat="server"></asp:Label>
            </div>  

         </div>
          
        </asp:Panel> 
                      
                      <a href="javascript:history.go(-1)" onclick="history.go(-1);return false;">
                           <asp:Button ID="backBtn" style="font-size:14px;font-weight: 700;width:100%;" CssClass="btn btn-sm btn-info" Text="<< Back" runat="server" /> </a>
                     
                      <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

                     
                           <asp:Label ID="msg" runat="server" CssClass="warningLbl alert-danger"></asp:Label>
                 

                            
  
                   </div>
             
        </div>
    </div>
             

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">
   
</asp:Content>