<%@ Page Title="" Language="C#"  MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="Manage" %>

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
   
 
   <asp:Panel ID="adminMenuPanel" runat="server">
            <div id="adminMenu" runat="server" class="menu">
                <ul>
                    <li class="imgleft-sep"><a href="Main.aspx?action=settings">SETTINGS</a></li>
                    <li><a href="Main.aspx?action=selection">PAID PLAYERS</a></li>
                    <li><a href="Main.aspx?action=confirmed">CONFIRMED</a></li>
                    <li><a href="Main.aspx?action=usermanagement">MANAGE</a></li>
                    <li><a href="Recyclebin.aspx">RECYCLEBIN</a></li>
                    <li><a href="Main.aspx?action=edit">EDIT PROFILE</a></li>
                    <li><a href="Main.aspx?action=history">HISTORY</a></li>
                    <li><a href="Main.aspx?action=logout">LOG OUT</a></li>
                </ul>
            </div>
        </asp:Panel>
            <br />
    <asp:Image ID="imageHeader" runat="server" ImageUrl="Images/header.jpg" Width="909px"
            Height="250px" />
    <br />
       <asp:RadioButtonList ID="rb" RepeatDirection="Horizontal" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rb_SelectedIndexChanged" runat="server">
                 
                </asp:RadioButtonList>
    <br /> <br /> <br />

    <asp:GridView ID="grd" runat="server" >

        <Columns>
            <asp:TemplateField >
                <ItemTemplate>
                    <asp:LinkButton CommandArgument='<%#Eval("id") %>' Text="Delete" OnClientClick="return confirm('Are you sure, you want to delete.')" runat="server" OnClick="delete_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>

    
       <br />
       <br />

    
</asp:Content>

