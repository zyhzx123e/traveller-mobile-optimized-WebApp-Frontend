<%@ Page Title="Sign Out" Language="C#" MasterPageFile="~/master/base.master" AutoEventWireup="true" CodeFile="signOut.aspx.cs" Inherits="signOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="userMenuContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">



     <div class="container" style="margin-bottom:28px;">      
        <div style="    color: darkblue;" class="  row-centered">
            
                   <br /><br />
               
    <div style="margin: 0 auto; text-align:center;font-family:cursive;font-size:18px;" class=" ">
        <div style="padding:10px;margin: 0 auto; border:5px outset orange;border-radius:15px;margin-top:5px;width:100%;text-align:center;"  >
             
              <a href="~/pages/login.aspx" runat="server" >
                      <img id="profile_pic" style="cursor: pointer;margin-bottom:30px;margin-top:20px;border-radius:50%;border:5px outset white;width:200px;height:200px;" src="../images/SabahLeaf.ico" class="frontImage" /></a><hr/>
                      <h2 style="font-family:cursive;text-align:center;font-weight:800;"> North Borneo Traveller</h2><hr/>
                      <h2 style="font-family:cursive;text-align:center;font-weight:400;font-size:18px;"> See You Again Soon!</h2>
                      <hr />
        
            <p style="font-family:cursive;font-weight:600;font-size:18px;">Start Tour-> <a href="~/pages/login.aspx" runat="server"> 
                <asp:Button ID="home_btn" ClientIDMode="Static" CssClass="btn btn-success" Text="Borneo Traveller" runat="server" OnClick="register__btn_Click" />
              </a></p>


            <p style="font-family:cursive;font-weight:800;font-size:20px;">&copy; Traveller 2018</p>
        </div>
    </div>

                    
  
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
          $('#home_btn').click(function () {
              
               $("#loader").css("visibility", "visible");
           });
       
       });
    
 </script>
          <asp:Image ID="loader" ClientIDMode="Static" ImageUrl="~/images/load.gif" runat="server" />
         
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="pageScripts" Runat="Server">
</asp:Content> 