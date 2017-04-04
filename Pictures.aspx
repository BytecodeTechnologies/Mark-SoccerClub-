<%@ Page Title="" Language="C#" MasterPageFile="~/PictureMaster.master" AutoEventWireup="true" CodeFile="Pictures.aspx.cs" Inherits="Pictures" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="ImageScript/lightbox.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="bodyContainer">
        <div style="" class="content">
            <h1>Pictures </h1>

            <%--   <p>
                <asp:Label ID="lblContactus" runat="server"></asp:Label>
            </p>--%>
            <asp:Repeater ID="RepeaterImages" runat="server">
                <ItemTemplate>
                    <div style="width: 31%; display: inline-table">
                        <a class="example-image-link" href="<%# Eval("Path") %>" data-lightbox="example-1">
                            <img class="example-image" src="<%# Eval("Path") %>" alt="image-1" width="100%" height="200px" /></a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <div style="width: 100%; display: inline-block; margin-top: 20px">
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

    <script src="ImageScript/lightbox-plus-jquery.min.js"></script>
</asp:Content>

