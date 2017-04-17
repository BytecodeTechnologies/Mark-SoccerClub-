<%@ Page Title="" Language="C#" MasterPageFile="~/PictureMaster.master" AutoEventWireup="true" CodeFile="Pictures.aspx.cs" Inherits="Pictures" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="ImageScript/lightbox.min.css" rel="stylesheet" />
    <link href="CssFiles/PicturesCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="bodyContainer">
        <div style="width:100%" class="content">
            <h1>Pictures </h1>
            <asp:Repeater ID="RepeaterImages" runat="server">
                <ItemTemplate>
                    <div class="five-images" style="width:19%; display:inline-table">
                        <a class="example-image-link" href="<%# Eval("Path") %>" data-lightbox="example-1">
                            <img class="example-image" src="<%# Eval("Path") %>" alt="image-1" width="95%" height="185px" style="margin-top:10px;" /></a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <div style="width:100%; display:inline-block; margin-top:20px">
                <asp:Repeater ID="rptPaging" runat="server" OnItemCommand="rptPaging_ItemCommand">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnPage"
                            Style="padding: 8px; margin: 2px; background: #ffa100; border: solid 1px #666; font: 8pt tahoma;"
                            CommandName="Page" CommandArgument="<%# Container.DataItem %>"
                            runat="server" ForeColor="White" Font-Bold="True"><%# Container.DataItem %>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    <script src="Scripts/jquery-1.4.1.js"></script>
    <script src="ImageScript/lightbox-plus-jquery.min.js"></script>
    <script src="ImageScript/DisableRightClickScript.js"></script>
</asp:Content>

