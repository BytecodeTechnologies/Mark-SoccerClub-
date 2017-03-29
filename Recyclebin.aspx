<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
CodeFile="Recyclebin.aspx.cs" Inherits="Recyclebin" %>

<asp:Content  ContentPlaceHolderID="head" Runat="Server">
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
<asp:Content ID="mainContent" runat="server" ContentPlaceHolderID="cphMain" >
<asp:Panel ID="adminMenuPanel" runat="server">
            <div id="adminMenu" runat="server"  class="menu">
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
        </asp:Panel><br />
        <img src="Images/header.jpg" width="910px"/>

<div id="bodyContainer">
                <div style="height:850px" class="content">
<h1>
                       
                       Recyclebin</h1>
                       <br />
            
                <asp:Label ID="lbldelete" runat="server" ForeColor="Red"></asp:Label>
                <br />
              

                       <asp:GridView ID="grdUM" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                    CellPadding="3" ForeColor="Black" DataKeyNames="UserId" 
                    GridLines="Vertical" onrowdatabound="grdUM_RowDataBound">
            
                <AlternatingRowStyle BackColor="#CCCCCC" />
            
                <Columns>
               
                    <asp:TemplateField HeaderText="PlayerID">
                        <ItemTemplate>
                            <asp:Label ID="Label399" runat="server" Text='<%# Eval("PlayerID") %>'></asp:Label>
                            <asp:Label ID="lbluserids" runat="server" Visible="false" Text='<%# Eval("UserId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Password">
                        <ItemTemplate>
                            <asp:Label ID="Label300" runat="server" Text='<%# Eval("Password") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="First Name">
                     <ItemTemplate>
                            <asp:Label ID="Label391" runat="server" Text='<%# Eval("FName") %>'></asp:Label>
                        </ItemTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="Surname">
                     <ItemTemplate>
                            <asp:Label ID="Label39" runat="server" Text='<%# Eval("SName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                     <ItemTemplate>
                            <asp:Label ID="Label392" runat="server" Text='<%# Eval("EMail") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Phone">
                     <ItemTemplate>
                        <asp:Label ID="Label394" runat="server" Text='<%# Eval("Phone") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                       <asp:TemplateField Visible="false" HeaderText="Block">
                     <ItemTemplate>
                    
                    
                       <asp:CheckBox ID="chkBlock" runat="server" AutoPostBack="true" />
                        </ItemTemplate>
                         
                    </asp:TemplateField>
                    
                       <asp:TemplateField Visible="false" HeaderText="Status">
                     <ItemTemplate>
                      <asp:Label ID="lblstatuss" runat="server" ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                       <asp:TemplateField HeaderText="Restore">
                     <ItemTemplate>

                      <asp:Label Visible="false" ID="lblIsActive" runat="server" Text='<%# Eval("IsActive") %>'></asp:Label>
                   <asp:LinkButton  ID="lbtnBlock" CommandArgument='<%# Eval("UserId") %>' 
                               ForeColor="Red" runat="server" onclick="lbtnBlock_Click">Restore</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                     
                     
                     <asp:TemplateField HeaderText="Delete">
                     <ItemTemplate>
                            <asp:LinkButton OnClientClick="javascript:return confirm('Are you sure, you want to delete?')"  CommandArgument='<%# Eval("UserId") %>' 
                                ID="lbtnDelete" ForeColor="Red" runat="server" Text="Delete" onclick="lbtnDelete_Click"></asp:LinkButton>
                          
                           
                       
                    
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

                    <div style="float:left">
                   
                   <h2>Hershey Center Players </h2>
                    
                    <p>
                    <div style="position:absolute" >
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                    CellPadding="3" ForeColor="Black" EmptyDataText="No player(s) found"
                    GridLines="Vertical">
            
                <AlternatingRowStyle BackColor="#CCCCCC" />
            
                <Columns>
               
                  

                     <asp:TemplateField HeaderText="S.No.">
                        <ItemTemplate>
                            <asp:Label ID="Label300" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="First Name">
                     <ItemTemplate>
                            <asp:Label ID="Label391" runat="server" Text='<%# Eval("FName") %>'></asp:Label>
                        </ItemTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="Surname">
                     <ItemTemplate>
                            <asp:Label ID="Label39" runat="server" Text='<%# Eval("SName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                     <ItemTemplate>
                            <asp:Label ID="Label392" runat="server" Text='<%# Eval("EMail") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Phone">
                     <ItemTemplate>
                        <asp:Label ID="Label394" runat="server" Text='<%# Eval("Phone") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Delete">
                     <ItemTemplate>
                            <asp:LinkButton OnClientClick="javascript:return confirm('Are you sure, you want to delete?')"  CommandArgument='<%# Eval("UserId") %>' 
                                ID="lbtnDelete1" ForeColor="Red" runat="server" Text="Delete" onclick="lbtnDelete_Click"></asp:LinkButton>
                          
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
            </p>
            </div>
                   
                    </div>
                   
    
  
            </div>
</asp:Content>

