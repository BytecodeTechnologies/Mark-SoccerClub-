

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="3DSecureAuthentication.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <script type="text/javascript">
       window.onload = function () {
           document.forms["PAEnrollForm"].submit();
       }
</script>
</head>

<body onunload="document.PAEnrollForm.submit();">
<form id="PAEnrollForm" runat="server" name="PAEnrollForm" action="http://www.acsURL_value" method="post" target="paInlineFrame">
<input type="hidden" id="PaReq" runat="server" name="PaReq" value="paReq value" />
<input type="hidden" id="TermUrl" runat="server" name="TermUrl" value="http://localhost:1395/CyberSource_PaymentGateway/3DSecurePaymentProcessor.aspx" />
<input type="hidden" id="xid" runat="server" name="MD" value="<xid value>" /> 
</form>
</body>

</html>
