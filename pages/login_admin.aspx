<%@ Page Title="Admin Portal" Async="true" EnableSessionState="True" EnableEventValidation="false" Language="C#" MasterPageFile="~/master/base.master" AutoEventWireup="true" CodeFile="login_admin.aspx.cs" Inherits="pages_admin_login" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <link href="css/login.css" type="text/css" rel="Stylesheet" />

    <!--init_fade_in-->
<script type="text/javascript" src="js/jquery-1.12.3.js"></script>
   
                             <style type="text/css">
                                  .btn {
                    border:outset 2px;
                    box-shadow:2px 2px grey;
                 
                 }
                                  body {
        width:100%;
        height:100%;
       background-image:url(bg_admin.jpg);
        }
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
       </style>    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="userMenuContent" Runat="Server">
     
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
  
    <div style="background-image:url(bg_admin.jpg) !important;  " >      
        <div class="container  row-centered" style="margin-bottom:95px;">
            <div class="col-md-12" id="loginForm" style="padding: 0px 10px;    margin: 25px auto;">
              
                   <div style="color:darkolivegreen;text-align:center;" class="col-md-12">
                       <a href="~/pages/Home.aspx" style="cursor: pointer;" runat="server" >
                      <img id="profile_pic" style="width:200px;height:180px;cursor: pointer;" src="../images/admin_p.png" class="frontImage" /></a><hr/>
                      <h2 style="text-align:center;">Traveller Admin Panel</h2>
                      <hr />
                      
                    
                      <div class="form-group">
                            <asp:TextBox ID="iDNumber" CssClass="form-control" placeholder="Admin ID" runat="server"></asp:TextBox>
                       </div>
                       <div class="form-group">
                            <asp:TextBox ID="password" TextMode="Password" CssClass="form-control" placeholder="Admin Password" runat="server"></asp:TextBox>
          
                            </div>
                      
                      
                         <div  class="form-group"> 
                    <asp:Button ID="Button1" ClientIDMode="Static" CssClass="  btn btn-danger" style="width:100%;height:40px;"  Text="Login" OnClick="log_Click" runat="server" />
                     
                    </div>  

                     
                    
                   
                      <br /> 
                   
                           <asp:Label ID="msg" runat="server" CssClass="warningLbl alert-danger"></asp:Label>
                       <br />
                       
                          <style type="text/css">
                                 
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
             <script type="text/javascript">

       $(document).ready(function () {

          $("#loader").css("visibility", "hidden");
          $('#Button1').click(function () {
              
               $("#loader").css("visibility", "visible");
           });
       
       });
    
 </script>
          <asp:Image ID="loader" ClientIDMode="Static" ImageUrl="~/images/load.gif" runat="server" />
         
  
                   </div>
              
            </div>
        </div>
    </div>
              
   
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="pageScripts" Runat="Server">
</asp:Content> 