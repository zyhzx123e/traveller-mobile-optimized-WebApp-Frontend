<%@ Page Title="Admin Change Password" Async="true" Language="C#" EnableSessionState="True"  EnableEventValidation="false" MasterPageFile="~/master/main.master" AutoEventWireup="true" CodeFile="pwdChange_admin.aspx.cs" Inherits="pwdChange_admin" %>

<asp:Content ID="Content2" ContentPlaceHolderID="page_head" Runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="pageContent" Runat="Server">
    <div class="form-group row-centered"> <h2>Change password</h2></div>
 <hr />
        <div class="col-md-12">
            <div class="form-group">
                <asp:TextBox ID="old_pass" CssClass="form-control text-center alert-success" TextMode="Password" placeholder="Old password" runat="server" Height="50px" Font-Size="16px"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="old_pass" CssClass="warningLbl" ErrorMessage="*Old password is required" runat="server"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">

                <asp:TextBox ID="new_pass" CssClass="form-control  text-center alert-success" TextMode="Password" placeholder="New password" runat="server" Height="50px" Font-Size="16px"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="new_pass" CssClass="warningLbl" ErrorMessage="*Password cannot be empty!" runat="server"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <asp:TextBox ID="verify_new_pass" CssClass="form-control text-center alert-success" TextMode="Password" placeholder="Retype new password" runat="server" Height="50px" Font-Size="16px"></asp:TextBox>
            </div>
            <div class="form-group ">
                <asp:Button ID="admin_change_password_btn" CssClass="btn btn-primary" Text="Save" runat="server" OnClick="change_password_btn_Click" Width="100%" Height="40px" style="margin-top: 20px;" />
                <asp:Label runat="server" ID="msg" style="margin-top:20px;" Visible="false" CssClass="warningLbl" ></asp:Label>
            </div>
        </div>
 
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">
</asp:Content> 