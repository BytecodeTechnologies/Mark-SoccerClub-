<%@ Page Title="" Language="C#"  MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Option.aspx.cs" Inherits="Option" %>

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
        input
        {
            font-weight:bold;
             height:30px;
            background-color:#DD3602;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
   <asp:Panel ID="userMenuPanel" runat="server">
            <div id="menuid" runat="server" class="menu">
                <ul>
                    <li class="imgleft-sep"><a href="Main.aspx?action=confirmation">CONFIRMATION</a></li>
                    <li><a onclick="ShowNotImplemented()">ADD VIDEO</a></li>
                    <li><a href="Main.aspx?action=edit">EDIT PROFILE</a></li>
                    <li><a href="Main.aspx?action=logout">LOG OUT</a></li>
                </ul>
            </div>
        </asp:Panel>
        <br />
        <asp:Image ID="imageHeader" runat="server" ImageUrl="Images/header.jpg" Width="909px"
            Height="250px" />
            <br />
              <asp:Label ID="Label3" runat="server" Text="Select" Font-Bold="True"
                    Font-Underline="True"></asp:Label>

<center>
 <br /> <br /><br /> 
    <asp:Label ID="lbl" ForeColor="Red" runat="server" />
    <br /> <br />

    <p> <asp:Button OnClick="btnt_Click" ID="btnt" Text="Click To Confirm Attendence for Tuesday Soccer  " runat="server" />  </p>
               
        <p>
            <asp:Button OnClick="btnth_Click" ID="btnth" Text="Click To Confirm Attendence for Thursday Soccer " runat="server" />
            </p> 
             
            <p>
            <asp:Button OnClick="btns_Click" ID="btns" Text="Click To Confirm Attendence for Sunday Soccer    " runat="server" />
            </p>

                  <p>
            <asp:Button ID="btnsat" OnClick="btnsat_Click" Text="Click To Confirm Attendence for Friday Soccer      " runat="server" />
            </p>
           
     <br /> <br /><br /> <br /><br /> <br /> <br /><br /> <br /><br /> <br /> <br /><br /> <br /><br /> 
    </center>
</asp:Content>

