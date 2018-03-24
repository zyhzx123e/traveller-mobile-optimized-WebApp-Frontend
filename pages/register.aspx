<%@ Page Title="Register" Async="true" EnableSessionState="True" EnableEventValidation="false" Language="C#" MasterPageFile="~/master/base.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="pages_common_register" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <link href="css/login.css" type="text/css" rel="Stylesheet" />

    <!--init_fade_in-->
<script type="text/javascript" src="js/jquery-1.12.3.js"></script>
   
                             <style type="text/css">
.modalBackground
{
    background-color:olive;
    filter:alpha(opacity=50);

    opacity:0.5;
}
     #mp1 
{
    background-color:lightgray; 
   
}
       .popForm 
{
    background-color:lightgray; 
   
}

                                 
#loader {
/*   border: 7px solid #f3f3f3;
  border-radius: 50%;
  border-top: 7px outset #3498db;
  width: 50px;
 height: 50px;
 -webkit-animation: spin_loader 0.8s linear infinite; /* Safari  
  animation: spin_loader 0.8s linear infinite;*/
  opacity:0.65;
   border-radius: 15px;
   width:85px;
   height:85px;
  position: fixed !important;
	            top:0 !important;
	            bottom: 0 !important;
	            left: 0 !important;
	            right: 0 !important;
	            margin: auto !important;
                z-index: 100;
                
}

/* Safari */
@-webkit-keyframes spin_loader {
  0% { -webkit-transform: rotate(0deg); }
   50% { -webkit-transform: rotate(180deg); }
  100% { -webkit-transform: rotate(360deg); }
}

@keyframes spin_loader {
  0% { transform: rotate(0deg); }
     50% { -webkit-transform: rotate(180deg); }
  100% { transform: rotate(360deg); }
}
                
        
       </style>    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="userMenuContent" Runat="Server">
     
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
  
   
    <div style="background-image:url(../images/bg.jpg);  " >      
        <div class="container  row-centered">
            <div class="col-centered" id="loginForm" style="padding-top:20px !important;text-align:center !important;margin:0;">
                
                  
                   <div style="color:darkblue;" class="col-md-12">
                       
                      
                        <div class="form-group center-block">
                 <asp:Label Text="Traveller Registration" style="line-height:1.5;width:100%;font-family:cursive;font-weight:700;color:darkblue;font-size:46px;" runat="server"></asp:Label>
                             <hr />
             
                                
            <asp:Image CssClass="new_user_img"  ID="new_user_img"   ImageUrl="~/images/profile.png"  style="cursor: pointer;border-radius: 50%;padding: 25px;width: 100%;height: 100%;margin-bottom: 15px;" runat="server" Visible="true" /><br />

             
                           <asp:FileUpload CssClass="btn-success" Visible="false" ID="FileUpload2" style="    padding: 10px;border-radius: 10px;width:100%;" runat="server" />  
                 <asp:Label Visible="false" ID="lbl_select_profile_img" Text="Select Profile Image" style="    font-family: cursive;font-weight: 600;" runat="server"></asp:Label><br />
                     <asp:HiddenField ID="HiddenField2" runat="server" />

            </div>


            <div class="form-group form-inline"> 
                <asp:TextBox ID="new_user_name" style="width:100%;" placeholder="Enter Username(Traveller Login ID)" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
             <div class="form-group form-inline"> 
                <asp:TextBox ID="new_user_email" style="width:100%;" placeholder="Enter User Email" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="form-group form-inline">
              
                <asp:TextBox ID="new_user_pwd" Visible="false" style="width:100%;" placeholder="Password Used to sign in with Username" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
           </div>
               <div class="form-group form-inline"> 
                <asp:TextBox ID="new_user_pwd2"  Visible="false" style="width:100%;" placeholder="Confirm User password!" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
         
                 </div>

                        <div class="form-group form-inline"> 
                         <asp:Button ID="btn_verify_code" ClientIDMode="Static" CssClass="  btn btn-success" style="margin-bottom:10px;width:100%;height:40px;"  Text="Verify My Email and Username" OnClick="verirfy_Click" runat="server" />
                          <asp:Button ID="btn_check_code" ClientIDMode="Static" Visible="false" CssClass="  btn btn-warning" style="margin-bottom:10px;width:100%;height:40px;"  Text="Verify Verification Code" OnClick="check_verification_code" runat="server" />
                       
                            <span> <asp:TextBox ID="verification_code" style="    margin-bottom: 10px;width:100%;height:40px; margin-top:10px;" placeholder="Enter Verification Code" CssClass="form-control" runat="server"></asp:TextBox>
                             <asp:Image ID="Image_error" Visible="false" ImageUrl="~/images/error.png" runat="server" />
                             <asp:Image ID="Image_success" Visible="false" ImageUrl="~/images/success.png" runat="server" />
                         </span>
                            <asp:Label Visible="false" ID="txt_verify_code_hint" Text="Verfication code has been sent to you Email, Please Check and fill in above in order to register [Traveller]" style=" text-align:justify;   font-family: cursive;font-weight: 300;" runat="server"></asp:Label><br />
                    
                        </div>


                         <div   class="form-group"> 
                    <asp:Button ID="btn_register" ClientIDMode="Static" CssClass="  btn btn-primary" style="width:100%;height:40px;"  Text="Register" OnClick="register_Click" Visible="false" runat="server" />
                     
                    </div>  
                          <div  class="form-group"> 
                    <asp:Button ID="Button1" ClientIDMode="Static" CssClass="  btn btn-warning" style="width:100%;height:40px;"  Text="Go to Login" OnClick="log_Click" runat="server" />
                     
                    </div>  
  
            
          <asp:Image ID="loader" ClientIDMode="Static" ImageUrl="~/images/load.gif" runat="server" />
         
                       <script>
 
                              $(document).ready(function () {
                                  //
                                  
                                  if (/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|ipad|iris|kindle|Android|Silk|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test(navigator.userAgent)
                     || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(navigator.userAgent.substr(0, 4))) {

                                      $(".new_user_img").css("width", "100%");
                                  } else {

                                      $(".new_user_img").css("width", "50%");
                                  }

                                  $("#loader").css("visibility", "hidden");
                                  $('#Button1').click(function () {

                                      $("#loader").css("visibility", "visible");
                                  });
                                  $('#btn_verify_code').click(function () {

                                      $("#loader").css("visibility", "visible");
                                  });
                                  $('#btn_register').click(function () {

                                      $("#loader").css("visibility", "visible");
                                  });
                                  $('#btn_check_code').click(function () {

                                      $("#loader").css("visibility", "visible");
                                  });
                                 
                              });

                              $(window).load(function () {
                                  //
                                
                                  if (/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|ipad|iris|kindle|Android|Silk|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test(navigator.userAgent)
                      || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(navigator.userAgent.substr(0, 4))) {

                                      $(".new_user_img").css("width", "100%");
                                  } else {

                                      $(".new_user_img").css("width", "50%");
                                  }

                              });

                              $(window).on('resize', function () {
                                  if (/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|ipad|iris|kindle|Android|Silk|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test(navigator.userAgent)
                     || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(navigator.userAgent.substr(0, 4))) {

                                      $(".new_user_img").css("width", "100%");
                                  } else {

                                      $(".new_user_img").css("width", "50%");
                                  }
                              });

                            
                          
</script>


  
                   </div>
               
            </div>
        </div>
    </div>
              
   
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="pageScripts" Runat="Server">
</asp:Content> 