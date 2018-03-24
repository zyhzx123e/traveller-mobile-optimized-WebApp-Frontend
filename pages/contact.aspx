<%@ Page Title="Help Corner" Language="C#" MasterPageFile="~/master/main.master" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="contact_page" %>
<asp:Content ID="Content1" Async="true" ContentPlaceHolderID="page_head" Runat="Server">

   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" runat="server">
 
    <div id="all" style="width:100%">

      <div id="main_detail" style=" border-radius:10px;     color: navajowhite;float:left;width:25%;border: 2px solid;margin-right: 10px;margin-top: 10px;">
         
           <div id="logo_block" style="padding:10px;width:100%;">
              <a runat="server" href="~/pages/Home.aspx"><img  src="../images/SabahLeaf.ico" style="cursor: pointer;width:80%;margin:20px;" /></a>
            <h4 style=" background-color: firebrick;border-radius: 10px;">Traveller [North Borneo]</h4>
             
          </div>
           <div id="weather_block" style="width:100%;">
              <div id="weather_detail" style="padding:10px;">
                  <h4 style="font-family:Cambria  ;margin-top:0;    background-color: firebrick;border-radius: 10px;">Current Weather Condition in North Borneo</h4>
         
                        <asp:PlaceHolder ID="PlaceHolder_weather_detail" runat="server"></asp:PlaceHolder> 
         
               <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                 <ContentTemplate>
                   
                   
                     </ContentTemplate>
                     </asp:UpdatePanel>  
               </div>

          </div>
           <div id="news_block" style="border-top:1px solid wheat; border-bottom:1px solid wheat; padding:10px;" style="width:100%;">
         <h4  id="news_block_title" runat="server" style="font-family:Cambria;margin-top:0;    background-color: firebrick;border-radius: 10px;">Today's Top News in North Borneo</h4>
           <asp:PlaceHolder ID="ph_news" runat="server"></asp:PlaceHolder> 
               
           </div>
         

           <div id="tourism_block" style="width:100%;">
                <hr/>
                 <style type="text/css">
          .alertBox
            {
               border-radius: 20px;
                color: wheat;
                position: fixed !important;
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
				
				  $('#all #main_sec .collapsible-header').on('touchstart click', function(event) {
	  $('#all #main_sec').on('touchstart click', function(event) {
			 if (event.type == "click"  || event.type == "touchstart"){ detectTap = true;} //detects click events 
				
		});
		
		if(detectTap){
	  
      var target = $(this);
      setTimeout(function() {
          if( target.length ) {
            event.preventDefault();
            $('html, body').animate({
                scrollTop: target.offset().top-80
            }, 450);
           }
      }, 300);
      }
  });
				
				
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
    
    <div style="border-top: 2px solid whitesmoke;margin-top: 10px;" runat="server">
   <h4 style="color:darkblue;font-family:cursive;"><em> Welcome <asp:Label ID="username_lbl" style="color:brown;font-weight:700;" runat="server"></asp:Label>  </em> 
        </h4>
   
   
           <h5 style="font-family:cursive;font-size:22px;font-weight:600;text-align:center;margin-bottom: 0;">North Borneo Traveller FAQs</h5>   
   
        
    </div>

   
         
    
          <div style="color: darkolivegreen;font-family: cursive;text-align:center;">
              
           <a href="javascript:history.go(-1)" onclick="history.go(-1);return false;">
       <asp:Button ID="backBtn" CssClass="btn btn-sm btn-info" style="margin-top: 10px;" Text="<< Back" runat="server" /> </a>
            <br />

			
         </div>


    <div class=" active" style="margin-top:10px;">
        
        <div class="container">      
        <div class=" row-centered">

		
		
            <asp:PlaceHolder ID="ph_faq" runat="server"></asp:PlaceHolder>
           
            




            <div id="contactus_sec" style="padding:10px;margin-bottom:30px;background-color:lightgray;margin-top:30px;border-radius:15px;">
                
            <h3 style="margin-top: 10px;font-weight:700;font-family:cursive;text-align:center;">Contact Us</h3>
                 <div class="form-group center-block">
                <asp:Label style="font-family:cursive;font-size:16px;font-weight:600;" Text="What you want our agent to answer you?"  runat="server"></asp:Label>
                <asp:TextBox ID="txt_faq_q" placeholder="You can type any questions, we will answer you back through email within 48 hours..." style="border-radius: 15px;border: 2px outset orange;margin-top: 10px;margin-bottom: 10px;" CssClass="form-control" runat="server" Rows="5" TextMode="MultiLine"></asp:TextBox>
           </div>
                  <div class="form-group center-block">
                <asp:Label style="font-family:cursive;font-size:20px;font-weight:600;" Text="Your Email"   runat="server"></asp:Label>
                <asp:TextBox ID="txt_faq_email" placeholder="Your Email for our Agent to contact..." style="border-radius: 15px;border: 2px outset orange;margin-top: 10px;margin-bottom: 10px;" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
                   <div class="form-group form-inline"> 
                    <asp:Button ID="btn_faq_send" ClientIDMode="Static" runat="server" Height="40px" Width="250px"  CssClass="btn btn-success" OnClick="faq_send_msg_clicked" style="font-family:cursive;font-size:17px;font-weight:600;width: 100%;margin-top: 10px;border-radius: 10px;" Text="Send" />
            </div>
           



                </div>
              <div runat="server" id="AlertBox" class="alertBox" Visible="false">
                <div runat="server" style="font-size: 16px;" id="AlertBoxMessage"></div>
      
                <button  CssClass="btn-success" style="margin:10px;color:white;background-color: orange;border-radius: 5px;"   onclick="closeAlert.call(this, event)">Ok</button>
            </div>


 
          
            </div>
             </div>
            </div>	   





    </div>
     </div>
		 
		  
		 


</asp:Content>

