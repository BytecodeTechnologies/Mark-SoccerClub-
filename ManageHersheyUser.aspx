<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageHersheyUser.aspx.cs" Inherits="ManageHersheyUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <style type="text/css">
        .black_overlay {
            display: none;
            position: absolute;
            top: 0%;
            left: 0%;
            width: 100%;
            height: 2000px !important;
            background-color: black;
            z-index: 1001;
            -moz-opacity: 0.8;
            opacity: .80;
            filter: alpha(opacity=80);
        }

        .white_content {
            display: none;
            position: absolute;
            top: 5%;
            left: 5%;
            width: 45%;
            height: 236px;
            padding: 16px;
            border: 10px solid #2a435a;
            background-color: white;
            z-index: 1002;
            overflow: auto;
        }


        <style type="text/css" > .std {
            background-color: #000000;
            color: #FFFFFF;
        }

        .selectionButtons {
            width: 25px;
            margin: 10px;
            font-weight: bold;
        }

        .style2 {
            width: 193px;
        }

        .style3 {
            width: 477px;
        }

        .menu {
            width: 980px;
            height: 34px;
            background-image: url(./Images/menu-bg.jpg);
            margin: auto;
            padding: 0;
            margin-top: 39px;
        }

            .menu ul {
                list-style: none;
                margin: 0;
                padding: 0;
            }

                .menu ul li {
                    list-style: none;
                    margin: 0;
                    float: left;
                    background-image: url(./Images/mneu-seprator.jpg);
                    background-repeat: no-repeat;
                    display: block;
                    height: 34px;
                }

                .menu ul .imgleft-sep {
                    list-style: none;
                    margin: 0;
                    float: left;
                    background-image: none;
                    display: block;
                    height: 30px;
                }

                .menu ul li a {
                    font-size: 15px;
                    color: #FFFFFF;
                    text-decoration: none;
                    display: block;
                    height: 30px;
                    padding: 4px 15px 0 15px;
                }

                    .menu ul li a:hover, .current {
                        font-size: 15px;
                        color: #FFFFFF;
                        text-decoration: none;
                        background-color: #000;
                        display: block;
                        height: 30px;
                        padding: 4px 15px 0 15px;
                    }

        .style7 {
            width: 673px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
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
                <li><a href="Main.aspx?action=managehersheyusers">HERSHEY USERS</a></li>
                <li><a href="ManagePicture.aspx">MANAGE PICTURES</a></li>
                <li><a href="ManagehersheyUser.aspx">MANAGE HERSHEY USERS</a></li>
                <li><a href="Main.aspx?action=logout">LOG OUT</a></li>
            </ul>
        </div>
    </asp:Panel>
    <br />
    <img src="Images/header.jpg" width="910px" />
   
        <h3>Manage Hershey Users</h3>
   
   <asp:Label ID="lblMsgDisplay" runat="server" ForeColor="Green"></asp:Label>
    </br>
        <asp:GridView ID="gridview" AutoGenerateColumns="False" runat="server" BackColor="White" AllowPaging="true" OnPageIndexChanging="gridview_PageIndexChanging"
            PageSize="20" BorderColor="#999999" Width="100%" BorderStyle="Solid"  BorderWidth="1px"
            CellPadding="3" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />

            <Columns>
                <asp:TemplateField HeaderText="First Name" HeaderStyle-Width="200px">
                    <ItemTemplate>
                        <asp:Label ID="lblFName" runat="server" Text='<%# Eval("FName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Surname" HeaderStyle-Width="200px">
                    <ItemTemplate>
                        <asp:Label ID="lblSName" runat="server" Text='<%# Eval("SName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email" HeaderStyle-Width="200px">
                    <ItemTemplate>
                        <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("EMail") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Phone" HeaderStyle-Width="200px">
                    <ItemTemplate>
                        <asp:Label ID="lblPhone" runat="server" Text='<%# Eval("Phone") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Retain" HeaderStyle-Width="200px">
                    <ItemTemplate>
                        <asp:LinkButton CommandArgument='<%# Eval("UserID") %>' OnClientClick="javascript:return confirm('Are you sure, you want to Retain?')"
                            ID="lblRetain" ForeColor="Red" runat="server" Text="Retain" OnClick="lblRetain_Click"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
   
</asp:Content>

