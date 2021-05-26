<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgot_password.aspx.cs" Inherits="ProjectSix.user.forgot_password" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   
    <title>Crystal Sienna</title>
    <link rel="icon" type="image/jpg" sizes="32x32" href="<%= Page.ResolveClientUrl("~/main-assets/images/Favicon-icon-(crystalsienna).png")%>" />
    <link rel="icon" type="image/jpg" sizes="16x16" href="<%= Page.ResolveClientUrl("~/main-assets/images/Favicon-icon-(crystalsienna).png")%>" />

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width,initial-scale=1.0,maximum-scale=1" />
    <meta name="author" content="ThemeZaa">
    <!-- description -->
    <meta name="description" content="POFO is a highly creative, modern, visually stunning and Bootstrap responsive multipurpose agency and portfolio HTML5 template with 25 ready home page demos.">
    <!-- keywords -->
    <meta name="keywords" content="creative, modern, clean, bootstrap responsive, html5, css3, portfolio, blog, agency, templates, multipurpose, one page, corporate, start-up, studio, branding, designer, freelancer, carousel, parallax, photography, personal, masonry, grid, coming soon, faq">
    
    <!-- favicon -->
    <!-- <link rel="shortcut icon" href="images/favicon.png">
        <link rel="apple-touch-icon" href="images/apple-touch-icon-57x57.png">
        <link rel="apple-touch-icon" sizes="72x72" href="images/apple-touch-icon-72x72.png">
        <link rel="apple-touch-icon" sizes="114x114" href="images/apple-touch-icon-114x114.png">-->
    <!-- animation -->
    <link rel="stylesheet" href="<%=Page.ResolveClientUrl("~/main-assets/css/animate.css")%>" />
    <!-- bootstrap -->
    <link rel="stylesheet" href="<%=Page.ResolveClientUrl("~/main-assets/css/bootstrap.min.css")%>" />
    <!-- et line icon -->
    <link rel="stylesheet" href="<%=Page.ResolveClientUrl("~/main-assets/css/et-line-icons.css")%>" />
    <!-- font-awesome icon -->
    <link rel="stylesheet" href="<%=Page.ResolveClientUrl("~/main-assets/css/font-awesome.min.css")%>" />
    <!-- themify icon -->
    <link rel="stylesheet" href="<%=Page.ResolveClientUrl("~/main-assets/css/themify-icons.css")%>">
    <!-- swiper carousel -->
    <link rel="stylesheet" href="<%=Page.ResolveClientUrl("~/main-assets/css/swiper.min.css")%>">
    <!-- justified gallery  -->
    <link rel="stylesheet" href="<%=Page.ResolveClientUrl("~/main-assets/css/justified-gallery.min.css")%>">
    <!-- magnific popup -->
    <link rel="stylesheet" href="<%=Page.ResolveClientUrl("~/main-assets/css/magnific-popup.css")%>" />
    <!-- revolution slider -->
    <%--<link rel="stylesheet" type="text/css" href="revolution/css/settings.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="revolution/css/layers.css">
    <link rel="stylesheet" type="text/css" href="revolution/css/navigation.css">--%>
    <!-- bootsnav -->
  
    <link rel="stylesheet" href="<%=Page.ResolveClientUrl("~/main-assets/css/bootsnav.css")%>">
    <!-- style -->
    <link rel="stylesheet" href="<%=Page.ResolveClientUrl("~/main-assets/css/style.css")%>" >
    <!-- responsive css -->
    <link rel="stylesheet" href="<%=Page.ResolveClientUrl("~/main-assets/css/responsive.css")%>" />

    <link rel="stylesheet" href="<%=Page.ResolveClientUrl("~/main-assets/css/materialize.min.css")%>">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Merriweather:ital,wght@0,300;0,400;0,700;0,900;1,300;1,400;1,700;1,900&display=swap" rel="stylesheet">
    
    <style>
        
.regarea {
    width: 100%;
    float: left;
    /*background: #000;*/
    height: 100%;
}

.regareain {
    
    margin: 156px auto;
}

.regareainfrm {
    width: 100%;
    float: left;
}

.coreimg {
    width: 100%;
    float: left;
    height: 51vh;
   /* background: url(../main-assets/images/1000.jpg) no-repeat center 0;*/
    background-size: cover;
}

.regareainfrmright {
    width: 100%;
    float: left;
    padding: 20px;
    background: #fff;
    height: 335px;
}

.regareainfrmrightlog {
    width: 100%;
    float: left;
    padding: 20px;
    background: #fff;
    height: 335px;
}

.fld {
    width: 100%;
    float: left;
    height: 38px;
    border-radius: 0;
    border: 1px solid #555555;
    padding: 0 5px;
    font-size: 16px;
    line-height: 38px;
    font-family: 'Montserrat', sans-serif;
    color: #333;
}

    .fld::-webkit-input-placeholder { /* Edge */
        color: #333;
    }

.popup-trigger {
}

    .popup-trigger:hover {
        opacity: .8;
    }

.popup {
    position: fixed;
    left: 0;
    top: 0;
    height: 100%;
    z-index: 1000;
    width: 100%;
    background-color: rgba(0,0,0,0.8);
    opacity: 0;
    visibility: hidden;
    transition: 500ms all;
}

    .popup.is-visible {
        opacity: 1;
        visibility: visible;
        transition: 1s all;
    }

.popup-container {
    transform: translateY(-50%);
    transition: 500ms all;
    position: relative;
    width: 50%;
    margin: 2em auto;
    top: 25%;
    padding: 5rem;
    background: #FFF;
    border-radius: .25em .25em .4em .4em;
    text-align: center;
    box-shadow: 0 0 20px rgba(0, 0, 0, 0.2);
}

    .popup-container p {
        text-align: center !important;
        font-size: 21px;
        color: #000;
        font-family: 'Montserrat', sans-serif;
    }

.is-visible .popup-container {
    transform: translateY(0);
    transition: 500ms all;
}

.popup-container .popup-close {
    position: absolute;
    top: 8px;
    font-size: 0;
    right: 8px;
    width: 30px;
    height: 30px;
}


    .popup-container .popup-close::before,
    .popup-container .popup-close::after {
        content: '';
        position: absolute;
        top: 12px;
        width: 14px;
        height: 3px;
        background-color: #8f9cb5;
    }

    .popup-container .popup-close::before {
        -webkit-transform: rotate(45deg);
        -moz-transform: rotate(45deg);
        -ms-transform: rotate(45deg);
        -o-transform: rotate(45deg);
        transform: rotate(45deg);
        left: 8px;
    }

    .popup-container .popup-close::after {
        -webkit-transform: rotate(-45deg);
        -moz-transform: rotate(-45deg);
        -ms-transform: rotate(-45deg);
        -o-transform: rotate(-45deg);
        transform: rotate(-45deg);
        right: 8px;
    }


    .popup-container .popup-close:hover:before,
    .popup-container .popup-close:hover:after {
        background-color: #35a785;
        transition: 300ms all;
    }


.fld:-ms-input-placeholder { /* Internet Explorer 10-11 */
    color: #333;
}

.fld::placeholder {
    color: #333;
}

.regareainfrmrightlog label {
    color: #333;
    padding-left: 25px !important;
    line-height: 23px !important;
    font-weight: 300;
}

.forgotpass {
    width: 100%;
    float: left;
    text-align: center;
    color: #333;
    text-decoration: underline;
    font-size: 16px;
    line-height: 42px;
    font-family: 'Montserrat', sans-serif;
}

    .forgotpass:hover {
        text-decoration: underline;
        transition: 1s;
    }

.regareainfrmrightfrgtpass {
    width: 100%;
    float: left;
    padding: 20px;
    background: #fff;
    height: 335px;
}

    .regareainfrmrightfrgtpass p {
        width: 100%;
        float: left;
        text-align: left;
        font-size: 16px;
        line-height: 20px;
        color: #000;
        font-family: 'Montserrat', sans-serif;
    }

.regareainfrmrightsuccess {
    width: 100%;
    float: left;
    padding: 20px;
    background: #fff;
    height: 335px;
}
.loginreg {
    width: 100%;
    height: 100%;
    background: #000;
    overflow-x: hidden;
}
    .regareainfrmrightsuccess p {
        width: 100%;
        float: left;
        text-align: center;
        font-size: 16px;
        line-height: 20px;
        color: #000;
        font-family: 'Montserrat', sans-serif;
        padding: 100px 0 0 0;
    }

    </style>
     
     <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <script>
        function popup() {
            swal({
                title: "Successful!",
                text: "Password Reset Successfully!",
                icon: "success",
                button: "Ok",
            });
        }
        function popuperror() {
            swal("Oops", "Sorry! New Password And Confirm Password Not Match.", "error")
        }
        function popupservererror() {
            swal({
                title: "Server Error!",
                text: "Server error ! Try again later.",
                icon: "error",
                button: "Ok",
            });
        }
        function popupvalidation() {
            swal({
                title: "Server Error!",
                text: "Please Fill All * Mark Filed.",
                icon: "error",
                button: "Ok",
            });
        }
    </script>
</head>
<body class="loginreg" style="background:url('/documents/seeting/20200929_120039-K.jpg');background-size:100% 100%;background-repeat:no-repeat;overflow-y: hidden;">
    <form id="form1" runat="server">
 <div class="regarea">
			<div class="container">
				<div class="row no-gutters">
					<div class="regareain">
						<div class="regareainfrm">
							<div class="row no-gutters">
								<div class="col-md-6">
									<div class="">&nbsp;</div>
								</div>
								<div class="col-md-6">
									<div class="regareainfrmrightfrgtpass">										
										<form action="" method="post">
                                             <div>
                                        <asp:HiddenField ID="hf_USER_KEY" runat="server" Value="0" />
                                    </div>
                                    <div>
                                        <asp:HiddenField ID="hf_USER_EMAIL" runat="server" Value="0" />
                                    </div>
											<input type="password" runat="server" name="" id="txt_PASS" class="form-control fld" placeholder="Reset Password">	
                                            <span id="show_password" runat="server" class="fa fa-eye-slash rpass icon toggle-password"></span>
											<input type="password" runat="server" name="" id="txt_CNFRM_PASS" class="form-control fld" placeholder="Confirm Password">											
											<span id="show_password1" runat="server" class="fa fa-eye-slash rcpass icon toggle-password1"></span>
                                            <a id="info" class="info popup-trigger btn btn-extra-large btn-dark-gray text-large border-radius-4 md-margin-15px-bottom sm-display-table sm-margin-lr-auto width-one" runat="server" onserverclick="reset_password">Reset</a>
											<a href="<%=Page.ResolveClientUrl("~/user/login.aspx/")%>" class="forgotpass">Back to login</a>
											<div class="popup" role="alert">
											  <div class="popup-container">
												<a href="#0" class="popup-close img-replace">Close</a>
												<p>Password Reset</p>
											  </div> 
											</div> 
										</form>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
	   </div>
        
      
    </form>
        <a class="scroll-top-arrow" href="javascript:void(0);"><i class="ti-arrow-up"></i></a>
<!-- end scroll to top  -->
<!-- javascript libraries -->
<script type="text/javascript" src="<%=Page.ResolveClientUrl("~/main-assets/js/jquery.js")%>"></script>
<script type="text/javascript" src="<%=Page.ResolveClientUrl("~/main-assets/js/modernizr.js")%>"></script>
<script type="text/javascript" src="<%=Page.ResolveClientUrl("~/main-assets/js/bootstrap.min.js")%>"></script>
<script type="text/javascript" src="<%=Page.ResolveClientUrl("~/main-assets/js/jquery.easing.1.3.js")%>"></script>
<script type="text/javascript" src="<%=Page.ResolveClientUrl("~/main-assets/js/skrollr.min.js")%>"></script>
<script type="text/javascript" src="<%=Page.ResolveClientUrl("~/main-assets/js/smooth-scroll.js")%>"></script>
<script type="text/javascript" src="<%=Page.ResolveClientUrl("~/main-assets/js/jquery.appear.js")%>"></script>
<!-- menu navigation -->
<script type="text/javascript" src="<%=Page.ResolveClientUrl("~/main-assets/js/bootsnav.js")%>"></script>
<script type="text/javascript" src="<%=Page.ResolveClientUrl("~/main-assets/js/jquery.nav.js")%>"></script>
<!-- animation -->
<script type="text/javascript" src="<%=Page.ResolveClientUrl("~/main-assets/js/wow.min.js")%>"></script>
<!-- page scroll -->
<script type="text/javascript" src="<%=Page.ResolveClientUrl("~/main-assets/js/page-scroll.js")%>"></script>
<!-- swiper carousel -->
<script type="text/javascript" src="<%=Page.ResolveClientUrl("~/main-assets/js/swiper.min.js")%>"></script>
<!-- counter -->
<script type="text/javascript" src="<%=Page.ResolveClientUrl("~/main-assets/js/jquery.count-to.js")%>"></script>
<!-- parallax -->
<script type="text/javascript" src="<%=Page.ResolveClientUrl("~/main-assets/js/jquery.stellar.js")%>"></script>
<!-- magnific popup -->
<script type="text/javascript" src="<%=Page.ResolveClientUrl("~/main-assets/js/jquery.magnific-popup.min.js")%>"></script>
<!-- portfolio with shorting tab -->
<script type="text/javascript" src="<%=Page.ResolveClientUrl("~/main-assets/js/isotope.pkgd.min.js")%>"></script>
<!-- images loaded -->
<script type="text/javascript" src="<%=Page.ResolveClientUrl("~/main-assets/js/imagesloaded.pkgd.min.js")%>"></script>
<!-- pull menu -->
<script type="text/javascript" src="<%=Page.ResolveClientUrl("~/main-assets/js/classie.js")%>"></script>
<script type="text/javascript" src="<%=Page.ResolveClientUrl("~/main-assets/js/hamburger-menu.js")%>"></script>
<!-- counter  -->
<script type="text/javascript" src="<%=Page.ResolveClientUrl("~/main-assets/js/counter.js")%>"></script>
<!-- fit video  -->
<script type="text/javascript" src="<%=Page.ResolveClientUrl("~/main-assets/js/jquery.fitvids.js")%>"></script>
<!-- equalize -->
<script type="text/javascript" src="<%=Page.ResolveClientUrl("~/main-assets/js/equalize.min.js")%>"></script>
<!-- skill bars  -->
<script type="text/javascript" src="<%=Page.ResolveClientUrl("~/main-assets/js/skill.bars.jquery.js")%>"></script>
<!-- justified gallery  -->
<script type="text/javascript" src="<%=Page.ResolveClientUrl("~/main-assets/js/justified-gallery.min.js")%>"></script>
<!--pie chart-->
<script type="text/javascript" src="<%=Page.ResolveClientUrl("~/main-assets/js/jquery.easypiechart.min.js")%>"></script>
<!-- instagram -->
<script type="text/javascript" src="<%=Page.ResolveClientUrl("~/main-assets/js/instafeed.min.js")%>"></script>
<!-- retina -->
<script type="text/javascript" src="<%=Page.ResolveClientUrl("~/main-assets/js/retina.min.js")%>"></script>
<!-- revolution -->
<script type="text/javascript" src="revolution/<%=Page.ResolveClientUrl("~/main-assets/js/jquery.themepunch.tools.min.js")%>"></script>
<script type="text/javascript" src="revolution/<%=Page.ResolveClientUrl("~/main-assets/js/jquery.themepunch.revolution.min.js")%>"></script>
<script type="text/javascript" src="<%=Page.ResolveClientUrl("~/main-assets/js/main.js")%>"></script>
   <script type="text/javascript">  
       $("body").on('click', '.toggle-password', function () {
           $(this).toggleClass("fa-eye fa-eye-slash");
           var input = $("#txt_PASS");
           if (input.attr("type") === "password") {
               input.attr("type", "text");
           } else {
               input.attr("type", "password");
           }

       });

       $("body").on('click', '.toggle-password1', function () {
           $(this).toggleClass("fa-eye fa-eye-slash");
           var input = $("#txt_CNFRM_PASS");
           if (input.attr("type") === "password") {
               input.attr("type", "text");
           } else {
               input.attr("type", "password");
           }

       });

   </script> 
</body>
</html>
