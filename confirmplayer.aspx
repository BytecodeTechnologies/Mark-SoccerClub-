﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="confirmplayer.aspx.cs" Inherits="confirmplayer" %>

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
<asp:Content ID="mainContent" runat="server" ContentPlaceHolderID="cphMain">
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <div>
        <br />
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
                    <li><a href="Main.aspx?action=logout">LOG OUT</a></li>
                </ul>
            </div>
        </asp:Panel>
        <asp:Panel ID="userMenuPanel" runat="server">
            <div id="menuid" runat="server" class="menu">
                <ul>
                    <li class="imgleft-sep"><a href="Main.aspx?action=confirmation">CONFIRMATION</a></li>
                    <li><a onclick="ShowNotImplemented()">ADD VIDEO</a></li>
                    <li><a href="Main.aspx?action=edit">EDIT PROFILE</a></li>
                    <li><a href="Main.aspx?action=logout">LOG OUT</a></li>
                </ul>
            </div>
        </asp:Panel>
        <br />
        <asp:Image ID="imageHeader" runat="server" ImageUrl="./Images/header.jpg" Width="909px"
            Height="250px" />
        <asp:MultiView ID="mvMain" runat="server" ActiveViewIndex="0">
            <asp:View ID="vSettings" runat="server">
                <asp:Label ID="Label2" runat="server" Text="Settings" Font-Bold="True" Font-Underline="True"></asp:Label>
                <br />
                <asp:Label ID="lbErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                <br />
                <br />
                <table cellspacing="10">
                    <tr>
                        <td valign="top">
                            <asp:Label ID="Label1" runat="server" Text="Next Practice Date: " Font-Bold="True"></asp:Label>
                            <asp:Label ID="lbPracticeDate" runat="server" Text="?"></asp:Label>
                            <br />
                        </td>
                        <td>
                            <asp:Calendar ID="cldrPracticeDate" runat="server" OnDayRender="cldrPracticeDate_DayRender"
                                OnSelectionChanged="cldrPracticeDate_SelectionChanged" BackColor="Black" BorderColor="White"
                                CssClass="std" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt"
                                ForeColor="White" Height="220px" NextPrevFormat="FullMonth" TitleFormat="Month"
                                Width="400px">
                                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333"
                                    Height="10pt" />
                                <DayStyle Width="14%" />
                                <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
                                <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
                                    ForeColor="#333333" Width="1%" />
                                <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White"
                                    Height="14pt" />
                                <TodayDayStyle BackColor="#CCCC99" />
                            </asp:Calendar>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label13" runat="server" Text="Number of players required for practice:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tbPracticePlayersNumber" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revPracticePlayersNumber" runat="server" ErrorMessage="Only numerals allowed!"
                                ControlToValidate="tbPracticePlayersNumber" ValidationExpression="[0-9]+" ForeColor="Red">Only numerals allowed!</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Confirmation Deadline (days before practice date):"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tbConfirmationDeadline" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revConfirmationDeadline" runat="server" ErrorMessage="Only numerals allowed!"
                                ControlToValidate="tbConfirmationDeadline" ValidationExpression="[0-9]+" ForeColor="Red">Only numerals allowed!</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td>
                            <asp:Label ID="Label24" runat="server" Text="Home Page Video Mark-up:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tbHomeVideoMarkUp" runat="server" Height="200px" TextMode="MultiLine"
                                Width="391px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label38" runat="server" Text="About Home Page Video:"></asp:Label>
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="txtVideo" runat="server" Height="73px" Width="540px">
	
                            </CKEditor:CKEditorControl>
                            <asp:TextBox ID="txtVideo1" Visible="false" runat="server" Height="73px" TextMode="MultiLine"
                                Width="391px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td colspan="2">
                            <p>
                                <b>E-Mail Settings</b></p>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td>
                            <asp:Label ID="Label18" runat="server" Text="Enable E-Mail:"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="cbEnableEmail" runat="server" />
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td>
                            <asp:Label ID="Label25" runat="server" Text="Enable SSL:"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="cbEnableSSL" runat="server" />
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="From Address:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tbEmailFromAddress" runat="server" Width="392px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revEmailFromAddress" runat="server" ErrorMessage="Invalid character found!"
                                ControlToValidate="tbEmailFromAddress" ValidationExpression="[0-9a-zA-Z@\.\-&\$!#%'\*\+-/=\?\^_`\{\|\}~]+"
                                ForeColor="Red">Invalid character found!</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td>
                            <asp:Label ID="Label20" runat="server" Text="Host name:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tbEmailHostName" runat="server" Width="392px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revEmailHostName" runat="server" ErrorMessage="Invalid character found!"
                                ControlToValidate="tbEmailHostName" ValidationExpression="[0-9a-zA-Z@\.\-&\$]+"
                                ForeColor="Red">Invalid character found!</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td>
                            <asp:Label ID="Label21" runat="server" Text="Port Number:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tbEmailPort" runat="server" Width="392px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revEmailPort" runat="server" ErrorMessage="Only numerals allowed!"
                                ControlToValidate="tbEmailPort" ValidationExpression="[0-9]+" ForeColor="Red">Only numerals allowed!</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td>
                            <asp:Label ID="Label22" runat="server" Text="User ID:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tbEmailServerUserId" runat="server" Width="392px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revEmailServerUserId" runat="server" ErrorMessage="Invalid character found!"
                                ControlToValidate="tbEmailServerUserId" ValidationExpression="[0-9a-zA-Z@\.\-&\$!#%'\*\+-/=\?\^_`\{\|\}~]+"
                                ForeColor="Red">Invalid character found!</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td>
                            <asp:Label ID="Label23" runat="server" Text="Password:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tbEmailServerUserPassword" runat="server" Width="392px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revEmailServerUserPassword" runat="server" ErrorMessage="Invalid character found!"
                                ControlToValidate="tbEmailServerUserPassword" ValidationExpression="[0-9a-zA-Z@\.\-&\$!#%'\*\+-/=\?\^_`\{\|\}~]+"
                                ForeColor="Red">Invalid character found!</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td>
                            <asp:Label ID="Label30" runat="server" Text="Sunday Soccer Confirmation E-Mail template:"></asp:Label><br />
                            <asp:Label ID="Label32" runat="server" Text="{...} - place holders"></asp:Label>
                        </td>
                        <td>
                            <%-- <CKEditor:CKEditorControl ID="tbEMailConfirmationTemplate" runat="server" Height="130px" Width="540px">
	
	                     </CKEditor:CKEditorControl>--%>
                            <asp:TextBox ID="tbEMailConfirmationTemplate" runat="server" Height="130px" TextMode="MultiLine"
                                Width="540px"></asp:TextBox>
                            <br />
                            <%--<asp:RegularExpressionValidator ID="revEMailConfirmTemplate" runat="server" ErrorMessage="Invalid character found!"
                                ControlToValidate="tbEMailConfirmationTemplate" ValidationExpression="[^<>]+"
                                ForeColor="Red">Invalid character found!</asp:RegularExpressionValidator>--%>
                        </td>
                    </tr>

                    <tr valign="top">
                        <td>
                            <asp:Label ID="Label44" runat="server" Text="Tuesday Soccer Confirmation E-Mail template:"></asp:Label><br />
                            <asp:Label ID="Label45" runat="server" Text="{...} - place holders"></asp:Label>
                        </td>
                        <td>
                            <%-- <CKEditor:CKEditorControl ID="tbEMailConfirmationTemplate" runat="server" Height="130px" Width="540px">
	
	                     </CKEditor:CKEditorControl>--%>
                            <asp:TextBox ID="tbEMailConfirmationTemplate1" runat="server" Height="130px" TextMode="MultiLine"
                                Width="540px"></asp:TextBox>
                            <br />
                            <%--<asp:RegularExpressionValidator ID="revEMailConfirmTemplate" runat="server" ErrorMessage="Invalid character found!"
                                ControlToValidate="tbEMailConfirmationTemplate" ValidationExpression="[^<>]+"
                                ForeColor="Red">Invalid character found!</asp:RegularExpressionValidator>--%>
                        </td>
                    </tr>

                    <tr valign="top">
                        <td>
                            <asp:Label ID="Label31" runat="server" Text="Declined E-Mail Template:"></asp:Label><br />
                            <asp:Label ID="Label33" runat="server" Text="{...} - place holders"></asp:Label>
                        </td>
                        <td>
                            <%--<CKEditor:CKEditorControl ID="tbEMailDeclinedTemplate" runat="server" Height="130px" Width="540px">
	
	                     </CKEditor:CKEditorControl>--%>
                            <asp:TextBox ID="tbEMailDeclinedTemplate" runat="server" Height="130px" TextMode="MultiLine"
                                Width="540px"></asp:TextBox><br />
                            <%--<asp:RegularExpressionValidator ID="revEMailDeclidedTemplate" runat="server" ErrorMessage="Invalid character found!"
                                ControlToValidate="tbEMailDeclinedTemplate" ValidationExpression="[^<>]+"
                                ForeColor="Red">Invalid character found!</asp:RegularExpressionValidator>--%>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td>
                            <asp:Label ID="Label34" runat="server" Text="Home Page Text:"></asp:Label><br />
                            <asp:Label ID="Label35" runat="server" Text="{...} - place holders"></asp:Label>
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="txtHomePageText" runat="server" Height="130px" Width="540px">
	
                            </CKEditor:CKEditorControl>
                            <asp:TextBox ID="txtHomePageText1" Visible="false" runat="server" Height="130px"
                                TextMode="MultiLine" Width="540px"></asp:TextBox><br />
                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid character found!"
                                ControlToValidate="txtHomePageText" ValidationExpression="[^<>]+"
                                ForeColor="Red">Invalid character found!</asp:RegularExpressionValidator>--%>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td>
                            <asp:Label ID="Label36" runat="server" Text="Contact-Us Page Text:"></asp:Label><br />
                            <asp:Label ID="Label37" runat="server" Text="{...} - place holders"></asp:Label>
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="txtContactUsText" runat="server" Height="130px" Width="540px">
	
                            </CKEditor:CKEditorControl>
                            <asp:TextBox ID="txtContactUsText1" Visible="false" runat="server" Height="130px"
                                TextMode="MultiLine" Width="540px"></asp:TextBox><br />
                            <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid character found!"
                                ControlToValidate="txtContactUsText" ValidationExpression="[^<>]+"
                                ForeColor="Red">Invalid character found!</asp:RegularExpressionValidator>--%>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="btnSubmitSettings" runat="server" Text="Submit" OnClick="btnSubmitSettings_Click" />
                <asp:Button ID="btnCancelSettings" runat="server" Visible="false" Text="Cancel" OnClick="btnCancelSettings_Click" />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </asp:View>

            
            <asp:View ID="vPaidPlayersSelection" runat="server">
                <asp:UpdatePanel ID="up1" runat="server">
                
                    <ContentTemplate>
                    
<br />
 <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up1"  DynamicLayout ="true">

        <ProgressTemplate>

        <center><span style="color:Red"> In Process...</span></center>

        </ProgressTemplate>

        </asp:UpdateProgress>
                <asp:RadioButtonList ID="rb" RepeatDirection="Horizontal" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rb_SelectedIndexChanged" runat="server">
                 
                </asp:RadioButtonList>
                 <%--<asp:RadioButtonList ID="rbThu" RepeatDirection="Horizontal" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rbThu_SelectedIndexChanged" runat="server">
                     <asp:ListItem Text="Thursday Soccer" />
                </asp:RadioButtonList>--%>
                
                <asp:Label ID="Label3" runat="server" Text="Paid Players Selection" Font-Bold="True"
                    Font-Underline="True"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblmsgPaidPlayers" runat="server" Text="" ForeColor="Red"></asp:Label>
                <br />
                <table border="0" >
                    <tr>
                        <td>
                            <b>Old Players</b>
                               <asp:RadioButtonList ID="rbtnOLDNEW" RepeatDirection="Horizontal" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rbtnOLDNEW_SelectedIndexChanged" runat="server">
                 
                </asp:RadioButtonList>
                        </td>
                        <td>
                        </td>
                        <td>
                            <b>New Players</b>
                        </td>
                        <td>&nbsp;</td>
                        <td>
                            <b>Paid Players</b>
                        </td>
                    </tr>
                    <tr>
                        <td>

                            <asp:ListBox ID="lbUnselectedUsers" runat="server" Height="298px" Width="330px" ViewStateMode="Enabled"
                                AutoPostBack="true" CssClass="std" OnSelectedIndexChanged="lbUnselectedUsers_SelectedIndexChanged">
                            </asp:ListBox>


                        </td>
                        <td>  <asp:Button ID="btnSelectUser1" runat="server" Text=">" CssClass="selectionButtons"
                                OnClick="btnSelectUser1_Click" /><br />
                            <asp:Button ID="btnDeselectUser1" runat="server" Text="<" CssClass="selectionButtons"
                                OnClick="btnDeselectUser1_Click" />
                                
                                </td>
                        <td>
                        
                        <asp:ListBox ID="lbUnselectedUsers1" runat="server" Height="298px" Width="330px" ViewStateMode="Enabled"
                                AutoPostBack="true" CssClass="std" OnSelectedIndexChanged="lbUnselectedUsers1_SelectedIndexChanged">
                            </asp:ListBox>
                        
                        </td>
                        <td>
                            <asp:Button ID="btnSelectUser" runat="server" Text=">" CssClass="selectionButtons"
                                OnClick="btnSelectUser_Click" /><br />
                            <asp:Button ID="btnDeselectUser" runat="server" Text="<" CssClass="selectionButtons"
                                OnClick="btnDeselectUser_Click" />
                        </td>
                         
                        <td>
                            <asp:ListBox ID="lbPlayers" AutoPostBack="true" OnSelectedIndexChanged="lbPlayers_SelectedIndexChanged"
                                runat="server" Height="298px" Width="330px" ViewStateMode="Enabled" CssClass="std">
                            </asp:ListBox>
                        </td>
                    </tr>


                    <tr style="display:none" >
                        <td>
                      <br />  <b>New Registered Players</b><br />
                           


                        </td>
                        <td>
                           
                        </td>
                        <td>
                        <br />
                            <asp:ListBox ID="lbPlayers1" AutoPostBack="true" OnSelectedIndexChanged="lbPlayers1_SelectedIndexChanged"
                                runat="server" Height="298px" Width="330px" ViewStateMode="Enabled" CssClass="std">
                            </asp:ListBox>
                        </td>
                    </tr>



                </table>
                <asp:Button ID="btnTeamSelectionSubmit" Visible="false" runat="server" Text="Submit"
                    OnClick="btnTeamSelectionSubmit_Click" />
                <asp:Button ID="btnTeamSelectionCancel" runat="server" Text="Back" OnClick="btnTeamSelectionCancel_Click" />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />

                    </ContentTemplate>
                </asp:UpdatePanel>
            
            </asp:View>

            <asp:View ID="vwProfile" runat="server">
                <asp:Label ID="Label12" runat="server" Text="Profile" Font-Bold="True" Font-Underline="True"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblmsgProfile" runat="server" Text="" ForeColor="Red"></asp:Label>
                <br />
                <table cellspacing="10">
                    <tr>
                        <td class="style2">
                            <asp:Label ID="Label7" runat="server" Text="Registration Number" ForeColor="White"></asp:Label>
                        </td>
                        <td class="style7">
                            <asp:Label ID="lbRegistrationNo" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="Label8" runat="server" Text="User ID" ForeColor="White"></asp:Label>
                        </td>
                        <td class="style7">
                            <asp:TextBox ID="tbUserId" runat="server" Text="" Width="469px" CssClass="std"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revUserId" runat="server" ErrorMessage="Invalid character found!"
                                ControlToValidate="tbUserId" ValidationExpression="[0-9a-zA-Z@\.\-&\$!#%'\*\+-/=\?\^_`\{\|\}~]+"
                                ForeColor="Red">Invalid character found!</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="Label9" runat="server" Text="Password" ForeColor="White"></asp:Label>
                        </td>
                        <td class="style7">
                            <asp:TextBox ID="tbPassword" runat="server" Text="" Width="469px" CssClass="std"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revPassword" runat="server" ErrorMessage="Invalid character found!"
                                ControlToValidate="tbPassword" ValidationExpression="[0-9a-zA-Z@\.\-&\$!#%'\*\+-/=\?\^_`\{\|\}~]+"
                                ForeColor="Red">Invalid character found!</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="Label28" runat="server" Text="FirstName" ForeColor="White"></asp:Label>
                        </td>
                        <td class="style7">
                            <asp:TextBox ID="tbFirstName" runat="server" Text="" Width="469px" CssClass="std"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revFirstName" runat="server" ErrorMessage="Invalid character found!"
                                ControlToValidate="tbFirstName" ValidationExpression="[0-9a-zA-Z@\.\-&\$!#%'\*\+-/=\?\^_`\{\|\}~]+"
                                ForeColor="Red">Invalid character found!</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="Label29" runat="server" Text="Surname" ForeColor="White"></asp:Label>
                        </td>
                        <td class="style7">
                            <asp:TextBox ID="tbSurname" runat="server" Text="" Width="469px" CssClass="std"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revSurname" runat="server" ErrorMessage="Invalid character found!"
                                ControlToValidate="tbSurname" ValidationExpression="[0-9a-zA-Z@\.\-&\$!#%'\*\+-/=\?\^_`\{\|\}~]+"
                                ForeColor="Red">Invalid character found!</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="Label11" runat="server" Text="E-Mail Address" ForeColor="White"></asp:Label>
                        </td>
                        <td class="style7">
                            <asp:TextBox ID="tbEMailAddress" runat="server" Text="" Width="469px" CssClass="std"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revEMailAddress" runat="server" ErrorMessage="Invalid character found!"
                                ControlToValidate="tbEMailAddress" ValidationExpression="[0-9a-zA-Z@\.\-&\$!#%'\*\+-/=\?\^_`\{\|\}~]+"
                                ForeColor="Red">Invalid character found!</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="Label17" runat="server" Text="Phone Number" ForeColor="White"></asp:Label>
                        </td>
                        <td class="style7">
                            <asp:TextBox ID="tbPhoneNumber" runat="server" Text="" Width="469px" CssClass="std"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revPhoneNumber" runat="server" ErrorMessage="Invalid character found!"
                                ControlToValidate="tbPhoneNumber" ValidationExpression="[0-9\+]+" ForeColor="Red">Invalid character found!</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="Label19" runat="server" Text="Position" ForeColor="White"></asp:Label>
                        </td>
                        <td class="style7">
                            <asp:DropDownList ID="ddlPosition" runat="server">
                                <%--       <asp:ListItem Value="Center">Center</asp:ListItem>
                                <asp:ListItem Value="Cornerback">Cornerback</asp:ListItem>
                                <asp:ListItem Value="Defensive End">Defensive End</asp:ListItem>
                                <asp:ListItem Value="Defensive Tackle">Defensive Tackle</asp:ListItem>
                                <asp:ListItem Value="Free Saftey">Free Saftey</asp:ListItem>
                                <asp:ListItem Value="Fullback">Fullback</asp:ListItem>
                                <asp:ListItem Value="Goal Keeper">Goal Keeper</asp:ListItem>
                                <asp:ListItem Value="Halfback">Halfback</asp:ListItem>
                                <asp:ListItem Value="Left Guard">Left Guard</asp:ListItem>
                                <asp:ListItem Value="Left Tackle">Left Tackle</asp:ListItem>
                                <asp:ListItem Value="Nose Guard">Nose Guard</asp:ListItem>
                                <asp:ListItem Value="Quarterback">Quarterback</asp:ListItem>
                                <asp:ListItem Value="Right Guard">Right Guard</asp:ListItem>
                                <asp:ListItem Value="Right Tackle">Right Tackle</asp:ListItem>
                                <asp:ListItem Value="Saftey">Saftey</asp:ListItem>
                                <asp:ListItem Value="Split End">Split End</asp:ListItem>--%>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="Label10" runat="server" Text="Level" ForeColor="White"></asp:Label>
                        </td>
                        <td class="style7">
                            <asp:Label ID="lbLevel" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td class="style2">
                            <asp:Label ID="Label46" runat="server" Text="Interested to play Soccer" ForeColor="White"></asp:Label>
                        </td>
                        <td class="style7">
                            <asp:CheckBox ID="chksun" Text="Sunday" runat="server" />
                             <asp:CheckBox ID="chkThu" Text="Tuesday" runat="server" />
                        </td>
                    </tr>
                </table>
                <asp:Button ID="btnProfileSubmit" runat="server" Text="Submit" OnClick="btnProfileSubmit_Click" />
                <asp:Button ID="btnProfileCancel" Visible="false" runat="server" Text="Cancel" OnClick="btnProfileCancel_Click" />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </asp:View>

            <asp:View ID="vwConfirmAttendance" runat="server">
                <asp:HyperLink ID="HyperLink1" NavigateUrl="option.aspx" Font-Bold="true" ForeColor="Green" runat="server" Text="Back" /><br /><br />

                <asp:Label ID="Label14" runat="server" Text="Attendance Confirmation" Font-Bold="True"
                    Font-Underline="True"></asp:Label>

                <asp:UpdatePanel ID="upd" runat="server">
                    <ContentTemplate>
                        <asp:Timer ID="Timer1" OnTick="Timer1_Tick" Enabled="true" Interval="1000" runat="server">
                        </asp:Timer>
                        <br />
                        <asp:Label ID="lblTime" Font-Size="Large" ForeColor="Green" Font-Bold="true" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:Label ID="lblmsginv" ForeColor="Red" runat="server"></asp:Label><br />
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lbInvitationStatus" runat="server" CssClass="std" Text="xx" Width="450px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="rbYes" runat="server" GroupName="Attendance" Text="Yes" AutoPostBack="True"
                                OnCheckedChanged="rbYes_CheckedChanged" CssClass="std" />
                            <br />
                            <asp:RadioButton ID="rbNo" runat="server" GroupName="Attendance" Text="No" AutoPostBack="True"
                                OnCheckedChanged="rbNo_CheckedChanged" CssClass="std" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblTot2" ForeColor="Red" runat="server"></asp:Label><br />
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:Label ID="Label16" runat="server" Text="Players that have confirmed attendance:"
                                ForeColor="White"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;
                            <asp:Label ID="Label42" runat="server" Text="Players not interested to play this match :"
                                ForeColor="White"></asp:Label>
                            <br />
                            <asp:ListBox ID="lbPlayersAccepted" runat="server" Width="450px" Height="210px" CssClass="std">
                            </asp:ListBox>
                            <asp:ListBox ID="lbOthersPlayersRejected" runat="server" Width="450px" Height="210px"
                                CssClass="std"></asp:ListBox>
                            <br />
                            <br />
                            <asp:Label ID="Label41" runat="server" Text="Players that have confirmed attendance (after Friday 12:00 PM)"
                                ForeColor="White"></asp:Label><br />
                            <asp:ListBox ID="lbOthersPlayersAccepted" runat="server" Width="450px" Height="210px"
                                CssClass="std"></asp:ListBox>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </asp:View>

            <asp:View ID="vwHistory" runat="server">
            <br />
                <asp:RadioButtonList RepeatDirection="Horizontal" ID="rbl1" AutoPostBack="true" OnSelectedIndexChanged="rbl1_SelectedIndexChanged"
                    runat="server">
                </asp:RadioButtonList>
                <br /><br />
                <asp:Label ID="Label15" runat="server" Text="Information" Font-Bold="True" Font-Underline="True"></asp:Label>
                <table cellspacing="10">
                    <tr>
                        <td>
                            <b>Past Fixtures</b>
                        </td>
                        <td>
                            <b>Players who confirmed for selected dates</b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ListBox ID="lbPastFixtureDates" runat="server" Height="450px" Width="200px"
                                SelectionMode="Multiple" AutoPostBack="True" OnSelectedIndexChanged="lbPastFixtureDates_SelectedIndexChanged"
                                CssClass="std"></asp:ListBox>
                        </td>
                        <td>
                            <asp:ListBox ID="lbPastConfirmedUsers" runat="server" Width="500px" Height="450px"
                                CssClass="std"></asp:ListBox>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Button ID="btnDeleteSelectedDates" Visible="false" runat="server" OnClick="btnDeleteSelectedDates_Click"
                    Text="Delete Selected Dates" />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </asp:View>

            <asp:View ID="vwConfirmed" runat="server">
              <br />
                <asp:RadioButtonList RepeatDirection="Horizontal" ID="rbl2" AutoPostBack="true" OnSelectedIndexChanged="rbl2_SelectedIndexChanged"
                    runat="server">
                </asp:RadioButtonList>
                <br />
                <br />
                <asp:Label ID="Label5" runat="server" Text="Players confirming attendance for next practice"
                    Font-Bold="True" Font-Underline="True"></asp:Label>
                <br />
                <br />
                <table cellspacing="10">
                    <tr>
                        <td valign="top">
                            <asp:Label ID="Label26" runat="server" Text="Paid players confirming attendance:"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblTotPlayer" ForeColor="Red" runat="server"></asp:Label>
                            <br />
                            <asp:ListBox ID="lbPlayersConfirmingAttendance" runat="server" Height="250px" Width="500px"
                                CssClass="std"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:Label ID="Label27" runat="server" Text="Other players confirming attendance:"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:ListBox ID="lbOtherUsersConfirmingAttendance" runat="server" Height="250px"
                                Width="500px" CssClass="std"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:Label ID="Label43" runat="server" Text="Players not interested to play this match:"
                                Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:ListBox ID="lbPlayersRejectingAttendance" runat="server" Width="500px" Height="210px"
                                CssClass="std"></asp:ListBox>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </asp:View>

            <asp:View ID="vwUserManagement" runat="server">
                <asp:Label ID="Label40" runat="server" Text="Player Management" Font-Bold="True"
                    Font-Underline="True"></asp:Label>
                <br />
                <asp:Label ID="lbldelete" runat="server" ForeColor="Red"></asp:Label>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:HyperLink ID="hyp" runat="server" ForeColor="White" Font-Bold="true" NavigateUrl="~/ManageSchedule.aspx">Schedule Management</asp:HyperLink>
                <br />
                <asp:GridView ID="grdUM" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black"
                    DataKeyNames="UserId" GridLines="Vertical" OnRowDataBound="grdUM_RowDataBound">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:TemplateField HeaderText="PlayerID">
                            <ItemTemplate>
                                <asp:Label ID="Label399" runat="server" Text='<%# Eval("PlayerID") %>'></asp:Label>
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
                            </ItemTemplate>
                        </asp:TemplateField>
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
                                <asp:CheckBox ID="chkBlock" OnCheckedChanged="chkBlock_OnCheckedChanged" runat="server"
                                    AutoPostBack="true" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblstatuss" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:Label Visible="false" ID="lblIsActive" runat="server" Text='<%# Eval("IsActive") %>'></asp:Label>
                                <asp:LinkButton ID="lbtnBlock" CommandArgument='<%# Eval("UserId") %>' ForeColor="Red"
                                    runat="server" OnClick="lbtnBlock_Click"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:LinkButton OnClientClick="javascript:return confirm('Are you sure, you want to delete?')"
                                    CommandArgument='<%# Eval("UserId") %>' ID="lbtnDelete" ForeColor="Red" runat="server"
                                    Text="Delete" OnClick="lbtnDelete_Click"></asp:LinkButton>
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
                <div style="height: 150px">
                    &nbsp;</div>
            </asp:View>

            <asp:View ID="vwOption" runat="server">
                <table border="1" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:RadioButton ID="rbtnThursday" AutoPostBack="true" OnCheckedChanged="rbtnThursday_CheckedChanged"
                                Text="Tuesday Soccer" runat="server" />
                        </td>
                        <td>
                            <asp:RadioButton ID="rbtnSunday" AutoPostBack="true" Text="Sunday Soccer" runat="server"
                                OnCheckedChanged="rbtnSunday_CheckedChanged" />
                        </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
