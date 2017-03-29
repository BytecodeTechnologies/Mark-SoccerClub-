<%@ Page Language="C#" AutoEventWireup="true" CodeFile="thankyou.aspx.cs" Inherits="thankyou" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">

 
    <title>Signature</title>
      <link href="images/favicon1.png" rel="shortcut icon" type="image/x-icon">
    <meta name="viewport" content="width=device-width">

      <script src="js/main.js"></script>
    <link rel="stylesheet" type="text/css" href="css/style.css">
    <link rel="stylesheet" type="text/css" href="css/ipad-landscape.css" media="only screen and (max-width:1024px), (max-device-width:1024px) and (orientation:landscape)">
	<link rel="stylesheet" type="text/css" href="css/small-tablet.css" media="only screen and (max-width:950px)">
	<link rel="stylesheet" type="text/css" href="css/ipad-portrait.css" media="only screen and (max-width:768px), (max-device-width:768px) and (orientation:portrait)">
	<link rel="stylesheet" type="text/css" href="css/small-tablet-portrait.css" media="only screen and (max-width:650px)">
	<link rel="stylesheet" type="text/css" href="css/iphone-landscape.css" media="only screen and (max-width:480px), (max-device-width:480px) and (orientation:landscape)">
	<link rel="stylesheet" type="text/css" href="css/iphone-portrait.css" media="only screen and (max-width:410px), (max-device-width:320px) and (orientation:portrait)">
   
   
    <!--[if gte IE 9]>
      <style type="text/css">
        .gradient {
           filter: none;
        }
      </style>
    <![endif]-->
    <style type="text/css">
    .submit-btn a, .submit-btn input {
    float: right;
     margin-right:157px !important;
}
    .container {  
    width: 880px !important;
}
.pop-container ul li input {
    color: #000;
    width: 65%  !important;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header>
        <div class="wrapper">
            <div class="header">
                
                <a class="logo" href="#">
           <img src="images/logo1.png" alt="">
                    
                    </a>


                <span class="iphone-menu"><img src="images/iphone-menu.png" alt=""></span>
                <div class="menus">
                <ul class="head-nav">
                    <li></li>

                    <li></li>


                                            <li></li>
                                            <li></li> 
                </ul>
                   <!-- <a class="sign-in" href="javascript:void(0)">LOG OUT</a>-->
               
               
                </div>
                <img class="header-left" src="images/header-left.png" alt="">
                <img class="header-right" src="images/header-right.png" alt="">
                <div class="clear"></div>
            </div>
        </div>
        <!-- .wrapper -->
    </header>

        <div id="body">


  <div style="text-align: center; padding-left: 94px;" class="container">
      
       <br />
       <br />
      <asp:Label id="lbl" runat="server" />
  </div>
            </div>
        <div class="wrapper">
        <div class="footer">
           <!-- <span>© Copyright Coretekinfo.Com 2014. All rights reserved.</span>
            <ul class="footer-nav">
                <li><a href="#Home/About">About Us</a></li>
                <li><a href="#Home/Contact">Contact</a></li>              
                <li><a href="#Home/Faq">FAQ</a></li>               
                <li><a href="#Home/Terms">Terms and Condition</a></li>
                            
            </ul>
            <div class="clear"></div>
            <img class="footer-left" src="images/footer-left.png" alt="">
            <img class="footer-right" src="images/footer-right.png" alt="">-->
        </div>
        <div class="footer-bottom"></div>
    </div>




    
    </form>
</body>
</html>
