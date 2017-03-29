<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<link rel="shortcut icon" href="http://jobsportal.co/images/favicon.ico">
<link href="Includes/css_002.css" rel="stylesheet" type="text/css">
<link href="Includes/css.css" rel="stylesheet" type="text/css">

<link rel="stylesheet" href="Includes/reset.css" type="text/css">
<link rel="stylesheet" href="Includes/style.css" type="text/css">

<link rel="stylesheet" media="screen" href="Includes/responsive-leyouts.css" type="text/css">
<title>Jobportal</title>
    <script type="text/javascript">
        function setcardtype(c) {            
            document.getElementById("cardtype").value = c;
        }
    </script>
<style type="text/css">

.textBoxWidth {
	width: 200px;
}
.data th {
	color: #FFF;
	font-size: 14px;
	font-weight: normal;
}
h2 {
	padding: 0px;
	font-size: 16px;
	color: #003151;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	margin-left: 10px;
}
.data td {
	font-size: 12px;
	border-top-width: 1px;
	border-top-style: solid;
	border-top-color: #e6e6e6;
	font-weight: bold;
}
a {
	text-decoration: none;
	color: #1C5068;
}
a:hover {
	text-decoration: underline;
}
.btn{
	background:#036;
	color:#FFF;
	height:30px;
	font-size:12px;
	line-height:30px;
	border-top-width: 1px;
	border-right-width: 1px;
	border-bottom-width: 1px;
	border-left-width: 1px;
	border-top-style: solid;
	border-right-style: solid;
	border-bottom-style: solid;
	border-left-style: solid;
	border-right-color: #001F3E;
	border-bottom-color: #001F3E;
	border-top-color: #004B97;
	border-left-color: #004B97;
	padding-bottom: 4px;
	padding-right: 5px;
	padding-left: 5px;
}
-->
</style>

</head>
<body>
    <form id="form1" runat="server">
  
<div class="site_wrapper">
  <div class="page_title">
    <div class="container">
     	<div class="leaft_title">
		    <h1>Payment Form for - 3D Secure</h1>
      </div>
    </div>
</div><!-- end page title -->

</div>



<asp:Label ID="lblresult" runat="server"></asp:Label>
<div class="container" id="payment">

   <div class="cutomer-info-1">
      <h4><img src="Includes/customer-satisfaction.jpg" align="absmiddle" height="28" width="28">Merchant Account</h4>
        <input runat="server" id="merchantID" name="merchantID" width="28" placeholder="merchant ID" required="" autofocus="" type="text">
      </div>
 
    <div class="info-1">
      <div class="cutomer-info-1">
        <h4><img src="Includes/customer-satisfaction.jpg" align="absmiddle" height="28" width="28">Customer Information</h4>

        <input runat="server" id="firstname" name="firstname" placeholder="First name" required="" autofocus="" type="text">
        <input runat="server" id="lastname" name="lastname" placeholder="Last name" required="" autofocus="" type="text">
        <input runat="server" id="email" name="email" placeholder="Your Email ID" required="" >
        <input runat="server" id="phone" name="phone" placeholder="Your Phone Number" required="">
      </div>
      <div class="cutomer-info-1">
        <h4>Billing Address</h4>
        <textarea runat="server" id="address" name="address" rows="3" placeholder="Address" required=""></textarea>
        <input runat="server" id="city" name="city" placeholder="City" required="" type="text">
        <input runat="server" id="state" name="state" placeholder="State" required="" type="text">
        <input runat="server" id="postcode" name="postcode" placeholder="Postal Code" required="" type="text">
        <input runat="server" id="country" name="country" placeholder="Country" required="" type="text">
      </div>
    </div>

    <div class="info-2">
      <h4><img src="Includes/credit-card.png" align="absmiddle" height="28" width="28">Card Details</h4>
    

      <input runat="server" style="display:none" id="cardtype" value="001" name="cardtype" placeholder="cardtype" required="" type="text">
      <input id="visa" name="cardtype" onclick="setcardtype('001')" checked="checked" value="visa" required="" type="radio">
      <label for="visa">VISA</label>
      <input id="amex" name="cardtype" onclick="setcardtype('003')" value="amex" required="" type="radio">
      <label for="amex">AmEx</label>
      <input id="mastercard" name="cardtype" onclick="setcardtype('002')" value="mastercard" required="" type="radio">
      <label for="mastercard">Mastercard</label>

      <div class="cutomer-info-2">
        <input runat="server" id="cardnumber" name="cardnumber" placeholder="Card Number" required="" >
     <%--   <input runat="server" id="amount" name="amount" placeholder="Amount (USD)" required="" type="text">--%>
        <br>
 
       <%-- <p style="float:left">Expiration Date: </p>--%>
        <input runat="server" id="expmonth" name="expmonth" placeholder="Expiration Month" required="">
     
        <input runat="server" id="expyear" name="expyear" placeholder="Expiration Year" required="">
       <input  runat="server" id="secure" name="secure" placeholder="Security Code" required="" >

 
        <!--input id="expmonth" name="expmonth" type="number" placeholder="Expiration Month" required /-->
        <!--input id="expyear" name="expyear" type="number" placeholder="Expiration Year" required /-->
        <div style="min-height:20px;"></div>
       

          <asp:Button Text="Pay Now" ID="btnpay" Class="input_submit" OnClick="btnpay_Click" runat="server" />
        <!--<input id="namecard" name="namecard" placeholder="Exact Name As On The Card" required="" type="text">--%>
        
        <%--<input id="pay" name="" value="Pay" class="input_submit" type="submit">--%>
       <br />
        
      </div>
    </div>

    
    
 
</div>
<div class="footer">

<div class="footer_center">

<div class="footersection_two">

	<div class="container">

        <div class="one_full">

        	<div class="payments_accept">

            	<h4>Payments We accept</h4>

                <ul class="paymetns_logos">
         
                    <li><img src="Includes/payments-logo2.png" alt="American Express"></li>
                   
     
                    <li><img src="Includes/payments-logo5.png" alt="Master Card"></li>
                    <li><img src="Includes/payments-logo6.png" alt="Visa"></li>
                    </ul>
            </div>
            
        </div><!-- end payments we accept -->

    </div>

</div>

</div>

</div>

    </form>
</body>
</html>
