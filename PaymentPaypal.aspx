<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentPaypal.aspx.cs" Inherits="PaymentPaypal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body onload="document.getElementById('Button1').click();">
    <form id="form1" runat="server" action="https://www.paypal.com/cgi-bin/webscr" method="post">
    <input type='hidden' name='cmd' value='_xclick'/>
<input type='hidden' name='business' value='Deol12345@gmail.com'/>
<input type='hidden' name='item_name' value='Payment for Hershey Centre'/>
<input type='hidden' name='amount' value='70'/>
<input type='hidden' name='return' value='http://test.bytecodetechnologies.in/HersheysCentre.aspx'/>
<input type='hidden' name='cancel_return' value='http://test.bytecodetechnologies.in/HersheysCentre.aspx'/>
<input type='hidden' name='rm' value='2'/>
<input type="submit" id="Button1" style="display:none" value='By with additional parameters'/>
<div>Please wait......</div>

    </form>
</body>
</html>
