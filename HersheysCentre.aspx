<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HersheysCentre.aspx.cs" Inherits="HersheysCentre" 
    ValidateRequest="false" MasterPageFile="~/OuterMasterPage.master" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
   <style>
   .login
   {
       margin-left:"100px";
   }

    #abc {
            width: 100%;
            height: 100%;
            opacity: .95;
            top: 0;
            left: 0;
            display: none;
            position: fixed;
            background-color: #313131;
            overflow: auto;
        }

        img#close {
            position: absolute;
            right: -6px;
            top: -8px;
            cursor: pointer;
        }

        div#popupContact {
            position: absolute;
            left: 50%;
            top: 17%;
            margin-left: -202px;
            font-family: 'Raleway',sans-serif;
        }

        .form {
            max-width: 300px;
            min-width: 250px;
            padding: 10px 50px;
            border: 2px solid gray;
            border-radius: 10px;
            font-family: raleway;
            background-color: #fff;
        }
   </style>
</asp:Content>
<asp:Content ID="mainContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

     <div id="abc">
        <div id="popupContact">
            <div class="form">
                <div style="width: 100%; display: inline-table">
                    <p style="color: black"><asp:Label ID="lblRegMsg" runat="server"></asp:Label></p>
                    <div style="float: left; margin-left: 50px">
                        <asp:LinkButton ID="btnPay" runat="server" Text="Pay Now"  OnClick="btnPay_Click" />
                    </div>
                    <div style="margin-left: 150px;">
                        <asp:LinkButton ID="LinkButton1" runat="server" Text="Pay Later" OnClick="LinkButton1_Click"  />
                       
                    </div>
                </div>
            </div>

        </div>
    </div>

<div  style="padding-left:50px">

                        <i>
                            <h2>
                                Player Registration for HERSHEY CENTRE</h2>
                        </i>
                        <!--Registration Form starts here..-->
                         <asp:Label ID="lblmsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                        <br />
                        <br />
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
             <td valign="top" ><table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>  First Name:
            </td>
            <td><asp:TextBox ID="tbFirstName" runat="server" TextMode="SingleLine" Width="150px" />
                            <asp:RequiredFieldValidator ID="rvFirstNameRequired" runat="server" ErrorMessage="First Name is required"
                                ControlToValidate="tbFirstName" ValidationGroup="Reg" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td> Surname:
            </td>
            <td><asp:TextBox ID="tbSurname" runat="server" TextMode="SingleLine" Width="150px" />
                            <asp:RequiredFieldValidator ID="rvSurnameIsRequired" runat="server" ErrorMessage="Surname is required."
                                ControlToValidate="tbSurname" ValidationGroup="Reg" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td> Email:
       
            </td>
            <td>     <asp:TextBox ID="tbRegEmail" runat="server" TextMode="SingleLine" Width="150px" />
                            <asp:RequiredFieldValidator ID="rvRegEmail" runat="server" ErrorMessage="Email address is required."
                                ControlToValidate="tbRegEmail" ValidationGroup="Reg" ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="rvExpEmail" ValidationGroup="Reg" runat="server" ErrorMessage="Email is not in correct format." ControlToValidate="tbRegEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red">*</asp:RegularExpressionValidator>
            </td>
        </tr>
         <tr>
            <td>Phone:  
            </td>
            <td><asp:TextBox ID="tbRegPhoneNumber" runat="server" TextMode="SingleLine" Width="150px" />
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Phone Number is required."
                                ControlToValidate="tbRegPhoneNumber" ValidationGroup="Reg" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
                  <tr>
                      <td colspan="2">
                                <div class="g-recaptcha" data-sitekey="[6LcKxSgTAAAAANZtjtrjWO2KiB0eE7mP76UNwtgX]" style="margin-top: 5px">
                                </div>
                                <asp:HiddenField ID="hidden" runat="server"></asp:HiddenField>
                            </td>
                        </tr>
         <tr>
            <td>
            </td>
            <td> <asp:ImageButton ID="btnRegSubmit" style="margin-top:6px" runat="server" ImageUrl="http://www.canadiansoccerclub.com/Images/register.png"
                            OnClick="btnRegSubmit_Click" ValidationGroup="Reg" OnClientClick="Captcha()"/>
            </td>
        </tr>
        
    </table>
            </td>
            <td style="width:100px">&nbsp;</td>
             <td valign="top" >
                <h3>
                        List of Registered Players for Hershey Centre</h3>

            <center>
<!-- Scroll bar present and enabled -->        
    <%--<div style="width: 225px; height: 400px; overflow-y: scroll;">--%>
    <asp:GridView ID="GridView2"  runat="server" AutoGenerateColumns="False" 
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

                    <asp:TemplateField HeaderText="Player Name">
                     <ItemTemplate>
                            <asp:Label ID="Label391" runat="server" Text='<%# Eval("FName") +" " + Eval("SName") %>'></asp:Label>
                        </ItemTemplate></asp:TemplateField>
                   <%--   <asp:TemplateField HeaderText="Surname">
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
                    </asp:TemplateField>--%>
                     
                   
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
   <%-- </div>--%>
</center>
            </td>
        </tr>
    </table>
    
                      
                        
                    <br /><br /><br /><br />

     <script type="text/javascript" src='https://www.google.com/recaptcha/api.js'></script>
        <script type="text/javascript">
            function Captcha() {
                var captcharesponse = grecaptcha.getResponse();
                document.getElementById('<%=hidden.ClientID %>').value = captcharesponse;
            }

            function div_show() {
                document.getElementById('abc').style.display = "block";
            }
            //Function to Hide Popup
            function div_hide() {
                document.getElementById('abc').style.display = "none";
            }
        </script>
                  
</asp:Content>
