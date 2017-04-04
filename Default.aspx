<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/OuterMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default2" %>

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
                        Welcome to our website</h1>
                    <p>
                        <asp:Label ID="lblhometext" runat="server"></asp:Label>
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
                    <div class="login">
                        <i>
                            <h2>
                                Login Form</h2>
								<strong><a href="http://www.noncombatdeath.org/"></a></strong>
<strong><a href="http://www.blackhawksplayerjersey.com/"></a></strong>
<strong><a href="http://www.baseballplayerjersey.com/"></a></strong>
<strong><a href="http://www.top50footballjersey.com/"></a></strong>
<strong><a href="http://www.arcator.net/"></a></strong>
<strong><a href="http://www.mlbplayershop.com/"></a></strong>
<strong><a href="http://www.loldome.com/"></a></strong>
<strong><a href="http://www.callbottles.com/"></a></strong>
<strong><a href="http://www.lakingsplayerstore.com/"></a></strong>
<strong><a href="http://www.lakingsplayershop.com/"></a></strong>
                        </i>
                        <label>
                            Player ID:</label><br />
                        <asp:TextBox ID="tbUserLogInId" runat="server" TextMode="SingleLine" ControlToValidate="tbUserLogInId"
                            Width="150px" />
                        <asp:RequiredFieldValidator ID="rfvUserLogInId" runat="server" ErrorMessage="Name is required."
                            ValidationGroup="LogIn" ControlToValidate="tbUserLogInId" ForeColor="Red">*</asp:RequiredFieldValidator><br />
                        <label>
                            Password:</label><br />
                        <asp:TextBox ID="tbUserLogInPassword" runat="server" TextMode="Password" Width="150px" />
                        
                         <asp:Label class="style1" ID="lblmsg" runat="server"></asp:Label><br />
                        
                         <asp:ImageButton ID="btnLogIn" runat="server" ImageUrl="http://www.canadiansoccerclub.com/Images/login.png"
                            OnClick="btnLogIn_Click" ValidationGroup="LogIn" />

                         <asp:RequiredFieldValidator ID="rfvUserLogInTd" runat="server" ErrorMessage="Password required."
                            ValidationGroup="LogIn" ControlToValidate="tbUserLogInPassword" ForeColor="Red">*</asp:RequiredFieldValidator><br />
                        <asp:ValidationSummary ID="vsLogIn" runat="server" ValidationGroup="LogIn" ShowMessageBox="True"
                            ShowSummary="False" /><br />
                           
                        <asp:CustomValidator ID="cvLogIn" runat="server" ErrorMessage="Wrong username or password!"
                            ValidationGroup="LogIn" OnServerValidate="cvLogIn_ServerValidate" Height="0px"
                            Style="visibility: collapse;" Display="None" />
                        <asp:HiddenField ID="hfValidationMessage" runat="server" Value="" />
                       <%-- <label>
                            <asp:CheckBox ID="cbRememberMe" runat="server" value="1" />
                            <span class="style1">Remember Me</span></label><br />--%>
                                              
                        <a href="ForgotPassword.aspx">Forgotten Your Password?</a>
                        <br />
                        <a href="ForgotPlayerId.aspx">Forgotten Your Player ID?</a>
                    </div>
                    <br />
                    <br />
                    <div style="height:300px"  class="login">
                    <div style="display:none">
                        <i>
                            <h2>
                                Player Registration</h2>
                        </i>
                        <!--Registration Form starts here..-->
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
                                ControlToValidate="tbRegEmail" ValidationGroup="Reg" ForeColor="Red">*</asp:RequiredFieldValidator>
                             
                                
                                <br />
                        </label>
                        <label>
                            Phone Number:</label><br />
                        <label>
                            <asp:TextBox ID="tbRegPhoneNumber" runat="server" TextMode="SingleLine" Width="150px" /><br />
                        </label>
                        <label>
                            Position:</label><br />
                        <asp:DropDownList ID="ddlRegPosition" runat="server">
                         <%--   <asp:ListItem Value="" Selected="True">Select Position</asp:ListItem>
                            <asp:ListItem Value="Center">Defender</asp:ListItem>
                            <asp:ListItem Value="Cornerback">Goalkeeper</asp:ListItem>
                            <asp:ListItem Value="Defensive End">Forward Striker</asp:ListItem>
                            <asp:ListItem Value="Defensive Tackle">Midfielder</asp:ListItem>--%>
                        </asp:DropDownList>
                        <asp:ValidationSummary ID="vsReg" runat="server" ShowSummary="False" ShowMessageBox="True"
                            ValidationGroup="Reg" />
                        <asp:CustomValidator ID="cvRegUniqueUserId" runat="server" ErrorMessage="CustomValidator"
                            Display="None" OnServerValidate="cvRegUniqueUserId_ServerValidate" ValidationGroup="Reg"></asp:CustomValidator>
                        <br /> 
                        <asp:ImageButton ID="btnRegSubmit" style="margin-top:3px" runat="server" ImageUrl="http://www.canadiansoccerclub.com/Images/register.png"
                            OnClick="btnRegSubmit_Click" ValidationGroup="Reg" />
                    </div>
                    </div>
                    <%--<div class="news">
                        <h2>
                            Latest News</h2>
                        <div class="newsDetail">
                            <img src="http://www.canadiansoccerclub.com/images/news1.jpg" width="68" height="66"
                                class="newsimg" /><h3>
                                    July 18, 2010</h3>
                            dolor sit amet, consect etuer adipisc.</div>
                        <div class="newsDetail">
                            <img src="http://www.canadiansoccerclub.com/images/news1.jpg" width="68" height="66"
                                class="newsimg" /><h3>
                                    July 18, 2010</h3>
                            dolor sit amet, consect etuer adipisc.</div>
                        <div class="newsDetail">
                            <img src="http://www.canadiansoccerclub.com/images/news1.jpg" width="68" height="66"
                                class="newsimg" /><h3>
                                    July 18, 2010</h3>
                            dolor sit amet, consect etuer adipisc.</div>
                    </div>--%>
                </div>
                <!--right side end here..-->
            </div>
            <!--body container End here..-->

</asp:Content>

