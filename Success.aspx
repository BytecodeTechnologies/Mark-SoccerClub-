<%@ Page Title="" Language="C#" MasterPageFile="~/OuterMasterPage.master" AutoEventWireup="true" CodeFile="Success.aspx.cs" Inherits="Success" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="bodyContainer">
                <div style="height:250px" class="content">
<h1>
                       Congratulations!! </h1>
                    
                    <p>
                    <asp:Label ID="lblContactus" Text="Your registration is successfull. Please <a href='Default.aspx' style='color:Red'><b>Click Here<b/></a> to login." runat="server"></asp:Label>
                    </p>
                    </div>
    </div>
</asp:Content>

