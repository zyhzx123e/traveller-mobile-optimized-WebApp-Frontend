<%@ Page Title="Borneo Stuff" Language="C#" EnableEventValidation="false" MasterPageFile="~/master/main.master" AutoEventWireup="true" CodeFile="stuff.aspx.cs" Inherits="stuff" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="control" %>

<asp:Content ID="Content1" ContentPlaceHolderID="page_head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" style="background-image:url(bg.jpg)" ContentPlaceHolderID="pageContent" Runat="Server">
  <div style="color:wheat; font-size:15px;" class="row row-centered">
            <div class="row">  <h2 style="font-family: inherit;font-weight: 700;font-size: 20px;padding:10px;">Find Your interesting stuff in Sabah</h2></div> 

  </div><hr/>
        <script type="text/javascript">

              

               window.onresize = function () {
                   // your code
                   if (/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|ipad|iris|kindle|Android|Silk|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test(navigator.userAgent)
|| /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(navigator.userAgent.substr(0, 4))) {
                       //phone size:
                      
                       location.reload();
                       $("#searchGoodBtn").css("width", "20%");
                   } else {
                      
                       //desktop size
                       location.reload();
                       $("#searchGoodBtn").css("width", "10%");

                   }
               };
           
          
</script>
 
    <div class="row">
       
             <asp:Button ID="add_new_good" ClientIDMode="Static" CssClass="btn btn-default btn-primary"  style="margin-bottom: 10px;border: 2px outset;border-radius: 10px;margin-bottom:10px;" Text="Share an interesting stuff" runat="server" OnClick="add_new_stuff_Click1"  />
          <br/>  <asp:Label ID="msg" runat="server"></asp:Label>
        
        
    </div>
        
    <div class="form-group table-responsive ">
      


           <div id="admin_txt_section">
             <div style="width:100%; display: inline-flex;" class="form-group center-block">
                <asp:TextBox  style="width:80%;height:36px;" ID="txt_stuff_sort" CssClass="form-control" Rows="2" OnTextChanged="btn_good_sort" Columns="140" placeholder="Use any keywords to search interesting stuff in Sabah . . ."   runat="server"></asp:TextBox>
           
                <asp:Button ID="searchGoodBtn" style="padding:5px;font-weight:600;font-size:12px;" OnClick="btn_good_sort_click" Text="Advance" CssClass="btn btn-warning" runat="server"  Height="35px" Width="20%" />
            
                        </div>

                  <div id="txtORsearch" runat="server" ClientIDMode="Static" style="width:100%; display: inline-flex; " visible="false"  class="form-group center-block">
                <asp:TextBox style="width:35%;height:36px;" ID="TextBoxOR1"  CssClass="form-control" Rows="2" Columns="140" placeholder="Search stuffs to travel in Sabah. . ." runat="server"></asp:TextBox>
              <asp:Label style="width:10%;font-weight: 800;padding-top: 9px;font-size:12px;" ID="Label1" runat="server" Text="OR"></asp:Label>
               <asp:TextBox style="width:35%;height:36px;" ID="TextBoxOR2"  CssClass="form-control" Rows="2" Columns="140" placeholder="Search stuffs to travel in Sabah. . ." runat="server"></asp:TextBox>
             
                <asp:Button ClientIDMode="Static" ID="Button1" OnClick="btn_searchOR_service" Text="Search" CssClass="btn btn-success" runat="server" style="padding:5px"  Height="35px" Width="20%" />
            
                    </div>    

           <div id="txtANDsearch" runat="server" ClientIDMode="Static" style="width:100%; display: inline-flex;"  visible="false"  class="form-group center-block">
                <asp:TextBox style="width:35%;height:36px;" ID="TextBoxAND1"   CssClass="form-control" Rows="2" Columns="140" placeholder="Search stuffs to travel in Sabah. . ." runat="server"></asp:TextBox>
               <asp:Label style="width:10%;font-weight: 800;padding-top: 9px;font-size:12px;" ID="Label2" runat="server" Text="AND"></asp:Label>
                <asp:TextBox style="width:35%;height:36px;" ID="TextBoxAND2"   CssClass="form-control" Rows="2" Columns="140" placeholder="Search stuffs to travel in Sabah. . ." runat="server"></asp:TextBox>
             
                <asp:Button ClientIDMode="Static" ID="Button2" OnClick="btn_searchAND_service" Text="Search" CssClass="btn btn-success" runat="server" style="padding:5px"  Height="35px" Width="20%" />
            
                    </div>   






             </div>

           
          <div id="srollableTableDiv"    style="height: 100vh;" class="  progress-bar-striped">
           
              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             
         <asp:DataList ID="DataList1"  runat="server"  
            BackColor="Transparent" ItemStyle-BackColor="Transparent"   
             RepeatDirection="Horizontal"   CellSpacing="20" GridLines="Both" BorderColor="#CCFFFF" BorderStyle="Outset" BorderWidth="2px" style="cursor: pointer;width:100%;background-color:wheat;font-family:cursive;padding:10px;border: 3px outset firebrick;" CellPadding="4"   RepeatColumns="2" >
  
            <ItemTemplate >
               
                 <div style=" font-size:18px;font-family:cursive;display: flex;align-items: center;">  
                      <a href='<%#"detail_followup.aspx?place_id="+Eval("stuff_id") %>' runat="server">
                 <asp:Label ID="Label4" style="font-weight:600;font-size: 15px;padding-left: 5px;padding-right: 5px;" runat="server" Text='<%# Eval("stuff_title") %>' /></a></div>
              
                  <div style=" font-size:16px;font-family:sans-serif;display: flex;align-items: center;">
                      <asp:ImageButton style="cursor: pointer;margin:10px ;margin-left:15px;width:130px;height:130px;border-radius:20px;" ClientIDMode="Static" ID="ImageButton1" ImageUrl='<%# Eval("stuff_img") %>' runat="server" PostBackUrl='<%#"detail_followup.aspx?place_id="+Eval("stuff_id") %>' /> </div>
                 
                  <div style=" font-size:12px;font-family:sans-serif;display: flex;align-items: center;">  <asp:Label style="margin-left:10px;margin-right:10px;" ID="productNameLabel" runat="server" Text='<%# Eval("stuff_name") %>' /> </div> 
                 <div style="float:right; display: flex;align-items: center;    font-size: 11px;padding-bottom:5px;">   <asp:Label style="margin-left:10px;margin-right:10px;" ID="productNameLabel11" runat="server" Text='<%# Eval("stuff_time_upload") %>' /> </div>  
                
               
                 
               </ItemTemplate>
        
               </asp:DataList>

            <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="BindGrid"></asp:Timer>
        </ContentTemplate>
</asp:UpdatePanel>

        </div>         
    </div>

       <style type="text/css">
 .modalBackground
{
    background-color:gray;
    filter:alpha(opacity=70);
    opacity:0.7;
}
     #mp1 
{
    background-color:orange; 
   
}
       .popForm 
{
    background-color:orange; 
   
}

        .btn {
                    border:outset 2px;
                    box-shadow:2px 2px grey;
                 
                 }
   </style>
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">

</asp:Content>

