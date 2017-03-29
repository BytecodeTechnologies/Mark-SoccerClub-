﻿<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/OuterMasterPage.master" AutoEventWireup="true" CodeFile="WinterReg.aspx.cs" Inherits="WinterReg" %>

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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!--body container Start here..-->
            <div id="bodyContainer">
        
                <div class="content">
                    <h1>
                        Spring/Summer Registartion</h1>
                    <p>
                       <%-- <asp:Label ID="lblhometext" runat="server"></asp:Label>--%>
                       <p>
                       
                       </p>
                       Registration is required for new players to play in Spring/Summer Registartion Session.<br /> <br />If you are already registered player and interested to play in Spring/Summer Registartion, please enter your email id below and click on Confirm button.
                     
                        </p>
                        <p>
                        Interested to play:<br />
                            <asp:CheckBox ID="CheckBox1" Text="Sunday Soccer" Checked="true" runat="server" /><br />
                           <asp:CheckBox ID="CheckBox2" Text="Tuesday Soccer" runat="server" /><br />
                             <asp:CheckBox ID="CheckBox3"  Text="Thursday Soccer" runat="server" /><br />
                               <asp:CheckBox ID="CheckBox4"  Text="Friday Soccer" runat="server" />
                        </p>
                        <p>
                          Email ID:&nbsp;   <asp:TextBox ID="txtcemail" runat="server" />  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Email address is required."
                                ControlToValidate="txtcemail" ValidationGroup="Reg1"  Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator> 
                           
                            <asp:RegularExpressionValidator ValidationGroup="Reg1"  Display="Dynamic" ForeColor="Red"
                            ID="RegularExpressionValidator1" runat="server" 
                            ErrorMessage="RegularExpressionValidator" ControlToValidate="txtcemail" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator> 

                          &nbsp; &nbsp;&nbsp; <asp:Button  ValidationGroup="Reg1" ID="btnc"  OnClick="btnc_Click"  Text="Confirm" runat="server" />
                         
                         </p>
                          <p>
                         
                             
                            <br />
                            <asp:Label ForeColor="Red" ID="lblmsgc" runat="server" />
                      </p>
                      
                     
                      
  
         
           
                            
                           
                           
                       
                    <hr />
                    <div class="homepage-img">
                     
                      <asp:Literal ID="litVideoMarkUp" runat="server"></asp:Literal>
                        
                    <p>
                        <asp:Label ID="lblVideoText" runat="server"></asp:Label>
                        </p>



                    </div>
                </div>
                <!--right side start here..-->
                <div class="right-side">
                    <!--Login div starts here..-->
                    
                    <br />
                    <br />
                    <div class="login">
                        <i>
                            <h2>
                             New Player Registration</h2>
                        </i>
                        <!--Registration Form starts here..-->
                        <label>
                        Intrested to play<br />
                        </label>
                        <label>
                           <asp:CheckBox ID="chkS" Text="Sunday Soccer" Checked="true" runat="server" /><br />
                           <asp:CheckBox ID="chkT" Text="Tuesday Soccer" runat="server" /><br />
                             <asp:CheckBox ID="chkTh"  Text="Thursday Soccer" runat="server" /><br />
                              <asp:CheckBox ID="chkF"  Text="Friday Soccer" runat="server" /><br />
                           </label>  <br />
                       
                        <label>
                            Player ID:</label><br />
                        <label>
                            <asp:TextBox ID="tbRegUserId" runat="server" TextMode="SingleLine" Width="150px" />
                            <asp:RequiredFieldValidator ID="rvRegUserId" runat="server" ErrorMessage="User ID is required!"
                                ControlToValidate="tbRegUserId" ValidationGroup="Reg" ForeColor="Red">*</asp:RequiredFieldValidator><br />
                        </label>
                        <label>
                            Password:</label><br />
                        <label>
                            <asp:TextBox ID="tbRegPassword" runat="server" TextMode="Password" Width="150px" />
                            <asp:RequiredFieldValidator ID="rvRegPassword" runat="server" ErrorMessage="Password is required!"
                                ControlToValidate="tbRegPassword" ValidationGroup="Reg" ForeColor="Red">*</asp:RequiredFieldValidator><br />
                        </label>
                        <label>
                            Confirm Password:</label><br />
                        <label>
                            <asp:TextBox ID="tbRegConfirmPassword" runat="server" TextMode="Password" Width="150px" />
                            <asp:RequiredFieldValidator ID="rvRegConfirmPassword" runat="server" ErrorMessage="Confirm password is required."
                                ControlToValidate="tbRegConfirmPassword" ValidationGroup="Reg" ForeColor="Red">*</asp:RequiredFieldValidator><br />
                            <asp:CompareValidator ID="cvPassword" ControlToValidate="tbRegPassword" ControlToCompare="tbRegConfirmPassword"
                                runat="server" ValidationGroup="Reg" ErrorMessage="Password differ from Confirm Password!"
                                Display="None"></asp:CompareValidator>
                        </label>
                        <label>
                            First Name:</label><br />
                        <label>
                            <asp:TextBox ID="tbFirstName" runat="server" TextMode="SingleLine" Width="150px" />
                            <asp:RequiredFieldValidator ID="rvFirstNameRequired" runat="server" ErrorMessage="First Name is required"
                                ControlToValidate="tbFirstName" ValidationGroup="Reg" ForeColor="Red">*</asp:RequiredFieldValidator><br />
                        </label>
                        <label>
                            Surname:</label><br />
                        <label>
                            <asp:TextBox ID="tbSurname" runat="server" TextMode="SingleLine" Width="150px" />
                            <asp:RequiredFieldValidator ID="rvSurnameIsRequired" runat="server" ErrorMessage="Surname is required."
                                ControlToValidate="tbSurname" ValidationGroup="Reg" ForeColor="Red">*</asp:RequiredFieldValidator><br />
                        </label>
                        <label>
                            Email:</label><br />
                        <label>
                            <asp:TextBox ID="tbRegEmail" runat="server" TextMode="SingleLine" Width="150px" />
                            <asp:RequiredFieldValidator ID="rvRegEmail" runat="server" ErrorMessage="Email address is required."
                                ControlToValidate="tbRegEmail" ValidationGroup="Reg" ForeColor="Red">*</asp:RequiredFieldValidator><br />
                        </label>
                        <label>
                            Phone Number:</label><br />
                        <label>
                            <asp:TextBox ID="tbRegPhoneNumber" runat="server" TextMode="SingleLine" Width="150px" /><br />
                        </label>
                        <label>
                            Position:</label><br />
                        <asp:DropDownList ID="ddlRegPosition" runat="server">
                         
                        </asp:DropDownList>
                        <asp:ValidationSummary ID="vsReg" runat="server" ShowSummary="False" ShowMessageBox="True"
                            ValidationGroup="Reg" />
                        <asp:CustomValidator ID="cvRegUniqueUserId" runat="server" ErrorMessage="CustomValidator"
                            Display="None"  ValidationGroup="Reg"></asp:CustomValidator>
                        <br />
                        <asp:ImageButton ID="btnRegSubmit" style="margin-top:3px" runat="server" ImageUrl="http://www.canadiansoccerclub.com/Images/register.png"
                            OnClick="btnRegSubmit_Click" ValidationGroup="Reg" />
                    </div>
                    
                </div>
                <!--right side end here..-->
            </div>
            <!--body container End here..-->

</asp:Content>

