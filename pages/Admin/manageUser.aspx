<%@ Page Title="Manage Travellers" Async="true"  Language="C#" EnableSessionState="True" EnableViewState="true"  EnableEventValidation="false"   MasterPageFile="~/master/main.master" AutoEventWireup="true" CodeFile="manageUser.aspx.cs" Inherits="manageUser" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="page_head" Runat="Server">
     <!-- CSS for datepicker JQuery item -->
     <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
   <style type="text/css">

       h2 {
       font-family:cursive;
       
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
       .addForm 
{
           border-radius:20px;
    background-color:chocolate; 
    padding:20px;
    margin-top:20px;
    float:right;
     margin-left:10px;
         margin-bottom:15px;
   
}
            .updateForm 
{
                min-width:50%;
                float:left;
                padding:20px;
    margin-top:20px;
     margin-bottom:15px;
         border-radius:20px;
    background-color:orange; 
    margin-right:10px;
   
}
       </style>    

      <script>
            $(document).ready(function() {
                //
                if (/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|ipad|iris|kindle|Android|Silk|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test(navigator.userAgent)
   || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(navigator.userAgent.substr(0, 4))) {

                    $("#update_panel").css("width", "100%");
                    $("#add_panel").css("width", "100%");
                    $("#main_manage").css("display", "unset");

                } else {
                    $("#main_manage").css("display", "flex");

                    $("#update_panel").css("width", "50%");
                    $("#add_panel").css("width", "50%");
                }

            });

            $(window).load(function() {
                //
                if (/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|ipad|iris|kindle|Android|Silk|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test(navigator.userAgent)
  || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(navigator.userAgent.substr(0, 4))) {

                    $("#update_panel").css("width", "100%");
                    $("#add_panel").css("width", "100%");
                     $("#main_manage").css("display", "unset");

                } else {
                    $("#main_manage").css("display", "flex");

                    $("#update_panel").css("width", "50%");
                    $("#add_panel").css("width", "50%");
                }
            });

            $(window).on('resize', function () {
                if(/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|ipad|iris|kindle|Android|Silk|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test(navigator.userAgent) 
   || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(navigator.userAgent.substr(0,4))){
                   
                    $("#update_panel").css("width", "100%");
                    $("#add_panel").css("width", "100%");
                    $("#main_manage").css("display", "unset");
                  
                } else{
                    $("#main_manage").css("display", "flex");

                    $("#update_panel").css("width", "50%");
                    $("#add_panel").css("width", "50%");
                }
            });

          
</script>
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
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" Runat="Server">
       
        <div id="main_manage" runat="server" ClientIDMode="Static" style=" display: flex;width:100%"> 

          
         <asp:Panel ID="update_panel" ClientIDMode="Static" runat="server" Width="100%"   CssClass="updateForm" align="center"  >      
  
                    <h2 style="font-weight: 700;font-family:cursive;"> Manage Travellers</h2>
                        <hr />
                <div class="form-group">
                     <h5 style="    font-weight: 700;font-size: 20px;color: white;">Pick a Traveller to load data</h5>
                    <asp:DropDownList CssClass="form-control" style="border-radius:15px;"  AutoPostBack="true"  OnSelectedIndexChanged="load_click"  ID="namesDropList" runat="server" >
                    </asp:DropDownList>

                </div>
           
                
           
                <h3>Traveller Profile:</h3>


                    
               <asp:Image ID="img" ImageUrl="~/images/SabahLeaf.ico" style="border:2px outset white;    border-radius: 50%;margin: 10px;width: 230px;height:230px;"   runat="server" /><br />

             <asp:FileUpload CssClass="btn-success" style="padding: 10px;margin-top: 10px;border-radius: 20px;border: 2px double white;" ID="FileUpload1" runat="server" />  
                 <asp:Label ID="lblCurrentFile" runat="server"></asp:Label><br />
      
                <asp:HiddenField ID="HiddenField1" runat="server" />
             
             <br />

                <div class="form-group form-inline">
                    <asp:Label AssociatedControlID="txt_username" style="    font-weight: 700;font-size: 16px;color: white;" CssClass="" Text="Traveller Username" runat="server"></asp:Label>
                    <asp:TextBox ID="txt_username" placeholder="Traveller Username" ViewStateMode="Enabled" EnableViewState="true"  style="width:100%;" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
             
                     <br/>
                   
                </div>
                    
 

                <div class="form-group form-inline">
                    <asp:Label AssociatedControlID="txt_email" style="    font-weight: 700;font-size: 16px;color: white;"  CssClass="" Text="Traveller Email" runat="server"></asp:Label>
                         
                    
                     <asp:TextBox ID="txt_email" placeholder="Traveller Email"  ViewStateMode="Enabled" EnableViewState="true" style="width:100%;" CssClass="form-control" Enabled="true" runat="server"></asp:TextBox>
               
                   
                </div>
             
                <div class="form-group form-inline">
                    <asp:Label   style="    font-weight: 700;font-size: 16px;color: white;"  CssClass="" Text="Passowrd" runat="server"></asp:Label>
                    <asp:TextBox ID="txt_pwd" placeholder="Traveller Password"  ViewStateMode="Enabled" EnableViewState="true" style="width:100%;"   CssClass="form-control" runat="server"></asp:TextBox>
               </div>
          
             <div class="form-group form-inline">
                 <asp:Button Text="Submit Changes" ClientIDMode="Static" ID="admin_user_manage_save" CssClass="btn btn-primary  " style="width:100%;"  runat="server" OnClick="save_Click" />
                 </div>
             <div class="form-group form-inline">     
                      <asp:Button Text="Delete This Traveller" ClientIDMode="Static" ID="admin_user_manage_delete" CssClass="btn btn-danger " style="width:100%;" runat="server"   OnClick="d_Click" />
                  </div>    
                
                <div class="form-group">
                    <div class="container">
                          <asp:Label ID="msg" runat="server"></asp:Label>
                    </div>
                </div>
                  
               


             
   </asp:Panel>



          <asp:Panel ID="add_panel" ClientIDMode="Static" runat="server" Width="100%"   CssClass="addForm" align="center"   >      
            <h2 style="font-family:cursive;font-weight: 700;">Add a New Traveller</h2>
            <hr />

                      <div class="form-group center-block">
                 <asp:Label style="    font-weight: 700;font-size: 20px;color: white;" Text="Pick a User Image" runat="server"></asp:Label>
               <asp:Image ID="new_user_img" style="border:2px outset white; border-radius: 50%;margin: 10px;width: 230px;height:230px;"   runat="server" Visible="False" /><br />

             <asp:FileUpload CssClass="btn-success" style="padding: 10px;margin-top: 10px;border-radius: 20px;border: 2px double white;" ID="FileUpload2" runat="server" />  
                 <asp:Label ID="Label1" runat="server"></asp:Label><br />
      
                <asp:HiddenField ID="HiddenField2" runat="server" />
             
            </div>


            <div class="form-group form-inline">
                <asp:Label Text="Traveller  Name" style="    font-weight: 700;font-size: 16px;color: white;"  runat="server"></asp:Label>
                <asp:TextBox ID="new_user_name"  ViewStateMode="Enabled" EnableViewState="true" style="width:100%;" placeholder="Enter Traveller Name" CssClass="form-control" runat="server"></asp:TextBox>
          
              <asp:Label  ID="lbl_username_validate" ClientIDMode="Static" Text="Traveller User Name has Already been Used!"  Visible="false" style="    font-weight: 300;font-size: 13px;color: red;"  runat="server"></asp:Label>
         
                  
                 </div>

            <div class="form-group form-inline">
                <asp:Label Text="Traveller Email" style="    font-weight: 700;font-size: 16px;color: white;"  runat="server"></asp:Label>
                <asp:TextBox ID="new_user_email"  ViewStateMode="Enabled" EnableViewState="true" style="width:100%;" placeholder="Traveller email used to sign in" CssClass="form-control" runat="server"></asp:TextBox>
           </div>
              <div class="form-group form-inline">
                  <asp:Label Text="Password" style="    font-weight: 700;font-size: 16px;color: white;"  runat="server"></asp:Label>
                <asp:TextBox ID="new_user_pwd"  ViewStateMode="Enabled" EnableViewState="true" style="width:100%;" placeholder="Password Used to sign in with Email" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
             </div>
               <div class="form-group form-inline">
              
             <asp:Label Text="Confirm Password" style="    font-weight: 700;font-size: 16px;color: white;"  runat="server"></asp:Label>
                <asp:TextBox ID="new_user_pwd2"  ViewStateMode="Enabled" EnableViewState="true" style="width:100%;" placeholder="Confirm Traveller password!" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
          
        
                 </div>

           
               
         
               

        <div class="form-group form-inline">
        <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
            </div>
       

            <div class="form-group form-inline">
                <asp:Button ID="admin_user_manage_add_user_btn" ClientIDMode="Static" style="width:100%;" CssClass="btn btn-success" Text="Add this Traveller" runat="server" OnClick="add_user_btn_Click"  />
     
            
                <asp:Label ID="msg1" runat="server" CssClass="warningLbl alert-danger"></asp:Label>
             
                 </div><br/>
         
                <div runat="server" id="AlertBox" class="alertBox" Visible="false">
                 <div runat="server" style="font-size: 16px;" id="AlertBoxMessage"></div>
      
               
          <asp:Button ID="Button1" CssClass="btn-danger" Text="Yes"   runat="server" OnClick="delete_Click"  />
          
          
          <button  CssClass="btn-success" style="margin:10px;color:white;background-color: orange;border-radius: 5px;"   onclick="closeAlert.call(this, event)">Cancel</button>
             </div>



              
               <div runat="server" id="div_confirm" class="alertBox" Visible="false">
                <div runat="server" id="Div2"></div>
          <asp:Button ID="Button2" CssClass="btn-success" Text="Ok"   runat="server" OnClick="confirmed_delete"  />
         
            </div>


        </asp:Panel> 
    </div>
                      
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">
   
</asp:Content> 