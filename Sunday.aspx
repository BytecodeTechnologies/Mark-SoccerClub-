<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Sunday.aspx.cs" Inherits="Sunday" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
        .std
        {
            background-color: #000000;
            color: #FFFFFF;
        }
        .selectionButtons
        {
            width: 25px;
            margin: 10px;
            font-weight: bold;
        }
        .style2
        {
            width: 193px;
        }
        .style3
        {
            width: 477px;
        }
        .menu
        {
            width: 980px;
            height: 34px;
            background-image: url(./Images/menu-bg.jpg);
            margin: auto;
            padding: 0;
            margin-top: 39px;
        }
        .menu ul
        {
            list-style: none;
            margin: 0;
            padding: 0;
        }
        .menu ul li
        {
            list-style: none;
            margin: 0;
            float: left;
            background-image: url(./Images/mneu-seprator.jpg);
            background-repeat: no-repeat;
            display: block;
            height: 34px;
        }
        .menu ul .imgleft-sep
        {
            list-style: none;
            margin: 0;
            float: left;
            background-image: none;
            display: block;
            height: 30px;
        }
        
        .menu ul li a
        {
            font-size: 15px;
            color: #FFFFFF;
            text-decoration: none;
            display: block;
            height: 30px;
            padding: 4px 15px 0 15px;
        }
        .menu ul li a:hover, .current
        {
            font-size: 15px;
            color: #FFFFFF;
            text-decoration: none;
            background-color: #000;
            display: block;
            height: 30px;
            padding: 4px 15px 0 15px;
        }
        .style7
        {
            width: 673px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
  <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
 
   <div id="menuid" runat="server" class="menu">
                <ul>
                    <li class="imgleft-sep"><a href="Main.aspx?action=confirmation">CONFIRMATION</a></li>
                    <li><a onclick="ShowNotImplemented()">ADD VIDEO</a></li>
                    <li><a href="Main.aspx?action=edit">EDIT PROFILE</a></li>
                    <li><a href="Main.aspx?action=logout">LOG OUT</a></li>
                </ul>
            </div>
            <br />
              <asp:Image ID="imageHeader" runat="server" ImageUrl="Images/header.jpg" Width="909px"
            Height="250px" />
              <asp:HyperLink ID="HyperLink1" NavigateUrl="option.aspx" Font-Bold="true" ForeColor="Green" runat="server" Text="<-- Back to Options" /><br /><br />
                <asp:Label ID="Label14" runat="server" Text="Attendance Confirmation" Font-Bold="True"
                    Font-Underline="True"></asp:Label>

                <asp:UpdatePanel ID="upd" runat="server">
                    <ContentTemplate>
                        <asp:Timer ID="Timer1" OnTick="Timer1_Tick" Enabled="true" Interval="1000" runat="server">
                        </asp:Timer>
                        <br />
                        <asp:Label ID="lblTime" Font-Size="Large" ForeColor="Green" Font-Bold="true" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:Label ID="lblmsginv" ForeColor="Red" runat="server"></asp:Label><br />
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lbInvitationStatus" runat="server" CssClass="std" Text="xx" Width="450px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        Do you want to play this match :<br />
                            <asp:RadioButton ID="rbYes" runat="server" GroupName="Attendance" Text="Yes" AutoPostBack="True"
                                OnCheckedChanged="rbYes_CheckedChanged" CssClass="std" />
                            <br />
                            <asp:RadioButton ID="rbNo" runat="server" GroupName="Attendance" Text="No" AutoPostBack="True"
                                OnCheckedChanged="rbNo_CheckedChanged" CssClass="std" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblTot2" ForeColor="Red" runat="server"></asp:Label><br />
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:Label ID="Label16" runat="server" Text="Players that have confirmed attendance:"
                                ForeColor="White"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;
                            <asp:Label ID="Label42" runat="server" Text="Players not interested to play this match :"
                                ForeColor="White"></asp:Label>
                            <br />
                            <asp:ListBox ID="lbPlayersAccepted" runat="server" Width="450px" Height="210px" CssClass="std">
                            </asp:ListBox>
                            <asp:ListBox ID="lbOthersPlayersRejected" runat="server" Width="450px" Height="210px"
                                CssClass="std"></asp:ListBox>
                            <br />
                            <br />
                            <asp:Label ID="Label41" runat="server" Text="Players that have confirmed attendance (after Friday 12:00 PM)"
                                ForeColor="White"></asp:Label><br />
                            <asp:ListBox ID="lbOthersPlayersAccepted" runat="server" Width="450px" Height="210px"
                                CssClass="std"></asp:ListBox>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
</asp:Content>



