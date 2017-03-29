<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageSchedule.aspx.cs" Inherits="ManageSchedule" %>

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
        </asp:Panel>
<h1>
                       
                       Manage Schedule</h1>
                       
              
                 <asp:radiobuttonlist RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rbtnl_SelectedIndexChanged" ID="rbtnl" runat="server">
   
</asp:radiobuttonlist> 
  <br />
<table border="0" cellpadding="0" cellspacing="0" width="100%">

<tr>
<td>Game:</td>
<td>
    <asp:TextBox ID="txtGame" runat="server" />
    <asp:RequiredFieldValidator ForeColor="Red" ErrorMessage="Required" ControlToValidate="txtGame" ValidationGroup="s" ID="req1"
        runat="server" />
    </td>
<td>
    
</td>
</tr>

<tr>
<td>Date:</td>
<td>
    <asp:TextBox runat="server" ID="txtDate" />

    <asp:RequiredFieldValidator ForeColor="Red" ErrorMessage="Required" ControlToValidate="txtDate" ValidationGroup="s" ID="RequiredFieldValidator1"
        runat="server" />
</td>
<td>

</td>
</tr>

<tr>
<td>Time:</td>
<td>

    <asp:TextBox runat="server" ID="txtTime" />
 <asp:RequiredFieldValidator ForeColor="Red" ErrorMessage="Required" ControlToValidate="txtTime" ValidationGroup="s" ID="RequiredFieldValidator2"
        runat="server" />
</td>
<td>

   
</td>
</tr>

<tr>
<td></td>
<td>
    <asp:Button ID="btnSave" OnClick="btnSave_Click" Text="Save" ValidationGroup="s" runat="server" />
    

 </td>
<td></td>
</tr>

<tr>
<td colspan="3">
<br />
    <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
    <br /><br />
</td>
</tr>

<tr>
<td colspan="3">

<asp:GridView ID="grdUM" runat="server" AutoGenerateColumns="False" width="80%"
                    BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                    CellPadding="3" ForeColor="Black" DataKeyNames="Id" 
                    GridLines="Vertical" 
        onrowcancelingedit="grdUM_RowCancelingEdit" onrowdeleting="grdUM_RowDeleting" 
        onrowediting="grdUM_RowEditing" onrowupdating="grdUM_RowUpdating" >
            
                <AlternatingRowStyle BackColor="#CCCCCC" />
            
                <Columns>
               
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Game #">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("Game") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label399" runat="server" Text='<%# Eval("Game") %>'></asp:Label>
                            <asp:Label ID="lbluserids" runat="server" Visible="false" Text='<%# Eval("Id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Dates">
                         <EditItemTemplate>
                             <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("Date") %>'></asp:TextBox>
                         </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label300" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="times">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("Time") %>'></asp:TextBox>
                        </EditItemTemplate>
                     <ItemTemplate>
                            <asp:Label ID="Label391" runat="server" Text='<%# Eval("time") %>'></asp:Label>
                        </ItemTemplate></asp:TemplateField>
                   
                    
                       <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Edit">
                           <EditItemTemplate>
                               <asp:LinkButton ID="LinkButton1" runat="server" CommandName="update">Update</asp:LinkButton>
                               &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CommandName="cancel">Cancel</asp:LinkButton>
                           </EditItemTemplate>
                     <ItemTemplate>

                    
                   <asp:LinkButton   ID="lbtnBlock" CommandArgument='<%# Eval("Id") %>' 
                               ForeColor="Red" runat="server" CommandName="edit" >Edit</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                     
                     
                     <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Delete">
                     <ItemTemplate>
                            <asp:LinkButton CommandName="delete" OnClientClick="javascript:return confirm('Are you sure, you want to delete?')"  CommandArgument='<%# Eval("Id") %>' 
                                ID="lbtnDelete" ForeColor="Red" runat="server" Text="Delete" ></asp:LinkButton>
                                                                          
                    
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

            <br />
            <br />
</td>
</tr>


</table>


</asp:Content>

