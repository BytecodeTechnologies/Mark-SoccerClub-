<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManagePicture.aspx.cs" Inherits="Default2" %>

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

        .centerheadertext th {
            text-align: center;
        }

        .header {
            text-align: center;
        }
    </style>

    <%--  <link href="popupSheet.css" rel="stylesheet" type="text/css" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.0/jquery.min.js"></script>
    

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

    <div id="bodyContainer">
        <div class="content" style="margin-bottom: 30px">
            <h1>Manage Pictures</h1>
            <br />
            <div style="margin-top:10px;margin-bottom:20px">
            <a onclick="openPopup()"  class="btn btn-success">Add New Image</a>
            </div>
                <%--Code for pop up--%>
            <div id="light" class="white_content" style="height:auto">

                <div style="width: 100%; display: inline-table; text-align: right; margin-bottom: 10px; padding: 2px";>
                    <a href="javascript:void(0)" onclick="ClosePopup()">X
                    </a>
                </div>
                <div id="viewform">
                    <h4 style="color: black;">Add new Image</h4>
                    <asp:FileUpload ID="UploadImage" runat="server" onchange="ShowImagePreview(this);" Multiple="multiple" style="margin-bottom:10px;color:black;" />
    <div id="ImgPreView"></div>

                    <asp:Button ID="btnSaveImage" runat="server" Text="Save Image" OnClick="btnSaveImage_Click" class="btn btn-success" style="margin-top:10px;" />
                    <a href="javascript:void(0)" onclick="ClosePopup()" class="btn btn-default" style="margin-top:10px;">Cancel </a>
                </div>
            </div>
            <div id="fade" class="black_overlay"></div>

            <%----------------End-------------%>
            <asp:Label ID="lblMsgDisplay" runat="server" Text="" ForeColor="Green"></asp:Label>

            <div>
                <asp:GridView ID="gridview" AutoGenerateColumns="False" runat="server"  BackColor="White" HorizontalAlign="Center" BorderColor="#999999" Width="120%" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="#CCCCCC" />

                    <Columns>
                        <asp:BoundField HeaderText="ImageName" ItemStyle-Width="30%" DataField="ImageName" ItemStyle-HorizontalAlign="Center"   />
                        
                        <asp:TemplateField HeaderText="Image" ItemStyle-Width="40%" >
                            
                            <ItemTemplate>
                                <img src="<%# Eval("Path") %>" height="20%" width="100%" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate >
                                <asp:LinkButton CommandArgument='<%# Eval("ImageId") %>' style="width:30px"
                                    ID="lbtnDelete1" ForeColor="Red" runat="server" Text="Delete" OnClick="lbtnDelete1_Click1" OnClientClick="javascript:return confirm('Are you sure, you want to delete?')"></asp:LinkButton>
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
            </div>
        </div>
    </div>
    <script type="text/javascript" src="ImageScript/ImagePreviewScript.js"></script>
    <script src="ImageScript/ImageUploadScript.js"></script>
</asp:Content>

