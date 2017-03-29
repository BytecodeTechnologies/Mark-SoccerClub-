<%@ Page Title="" Language="C#" MasterPageFile="~/OuterMasterPage.master" AutoEventWireup="true" CodeFile="ForgotPlayerId.aspx.cs" Inherits="forgotplayerid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="bodyContainer">
                <div style="height:250px" class="content">
<h1>
                        Forgotten Your Player ID? </h1>
                    <p>
             <label>
                            Email ID:</label><br />
                        <asp:TextBox ID="tbUserLogInId" runat="server" TextMode="SingleLine" ControlToValidate="tbUserLogInId"
                            Width="150px" />
                           &nbsp;<asp:Button Height="24px" ID="btnSumbit" runat="server" Text="Submit" ValidationGroup="g" 
                            onclick="btnSumbit_Click" /><br /><br />
                            
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                            runat="server" ControlToValidate="tbUserLogInId" Display="Dynamic" 
                            ErrorMessage="Invalid Email ID." 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            
                            <asp:RequiredFieldValidator Display="Dynamic" ID="rqv" runat="server" ControlToValidate="tbUserLogInId" ErrorMessage="Email ID required." ValidationGroup="g"></asp:RequiredFieldValidator>
                           <asp:Label ID="lblmsg" runat="server" ForeColor="White"></asp:Label>
                    
                    </p>
                    </div>
    </div>
</asp:Content>

