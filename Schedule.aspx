<%@ Page Title="" Language="C#" MasterPageFile="~/OuterMasterPage.master" AutoEventWireup="true" CodeFile="Schedule.aspx.cs" Inherits="Schedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div id="bodyContainer">
                <div class="content">
<h1>
                       
                       Schedule</h1>
                        <asp:radiobuttonlist RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rbtnl_SelectedIndexChanged" ID="rbtnl" runat="server">
   
</asp:radiobuttonlist> 
                  
               
                <br />
                <br />

                       <asp:GridView ID="grdUM" runat="server" AutoGenerateColumns="False" width="80%"
                    BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                    CellPadding="3" ForeColor="Black" DataKeyNames="Id" 
                    GridLines="Vertical" onrowdatabound="grdUM_RowDataBound">
            
                <AlternatingRowStyle BackColor="#CCCCCC" />
            
                <Columns>
               
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center"  HeaderText="Game #">
                        <ItemTemplate>
                            <asp:Label ID="Label399" runat="server" Text='<%# Eval("Game") %>'></asp:Label>
                            <asp:Label ID="lbluserids" runat="server" Visible="false" Text='<%# Eval("Id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField  ItemStyle-HorizontalAlign="Center" HeaderText="Date">
                        <ItemTemplate>
                            <asp:Label ID="Label300" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Time">
                     <ItemTemplate>
                            <asp:Label ID="Label391" runat="server" Text='<%# Eval("time") %>'></asp:Label>
                        </ItemTemplate></asp:TemplateField>
                                                                              
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

                    
                   <br /><br />
                    </div>
    </div>
</asp:Content>

