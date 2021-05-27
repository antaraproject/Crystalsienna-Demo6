<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ProjectSix.contact.index" %>

<!DOCTYPE html>

<html class="no-js" lang="en">
<head runat="server">
    <!-- title -->
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
    <!-- revolution slider
    <link rel="stylesheet" type="text/css" href="revolution/css/settings.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="revolution/css/layers.css">
    <link rel="stylesheet" type="text/css" href="revolution/css/navigation.css"> -->
    <!-- bootsnav -->
    <link rel="stylesheet" href="<%=Page.ResolveClientUrl("~/main-assets/css/bootsnav.css")%>">
    <!-- style -->
    <link rel="stylesheet" href="<%=Page.ResolveClientUrl("~/main-assets/css/style.css")%>" />
    <!-- responsive css -->
    <link rel="stylesheet" href="<%=Page.ResolveClientUrl("~/main-assets/css/responsive.css")%>" />

    <link rel="stylesheet" href="<%=Page.ResolveClientUrl("~/main-assets/css/materialize.min.css")%>">
         <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
        
<!--        Supriyo CSS-->
        
       <style>
            
            .margin-30px-bottom {
                margin-bottom: 30px;
                margin-top: 20px;
            }
            
        </style>
       
    <script>
        function popup() {
            swal({
                title: "Successful!",
                text: "Thank you for contacting us!",
                icon: "success",
                button: "Ok",
            });
        }
        function popuperror() {
            swal("Oops", "Please provide proper Email Address !", "error")
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
<body class="width-100">
    <header class="no-sticky">
        <!-- start navigation -->
        <nav class="navbar full-width-pull-menu nav-top-scroll no-border-top white-link no-transition">
            <!-- start navigation panel -->
            <div class="container-fluid nav-header-container height-100px padding-three-half-lr xs-height-70px xs-padding-15px-lr">
                <div class="row">
                    <!-- start logo -->
                    <div class="col-md-2 col-sm-3 col-xs-8 pull-left">
                        <a href="<%=Page.ResolveClientUrl("~/")%>" title="Pofo" class="logo">
                            <img id="logo_header" runat="server" alt="LOGO"></a>
                    </div>
                    <!-- end logo -->
                    <!-- start main menu -->
                    <div class="col-md-10 col-sm-9 col-xs-4">
                        <div class="menu-wrap full-screen no-padding">
                            <div class="col-sm-6 no-padding hidden-xs">
                                <div class="cover-background full-screen" id="side_logo" runat="server">
                                    <div class="opacity-medium bg-extra-dark-gray"></div>
                                    <div class="position-absolute height-100 width-100 text-center">
                                        <div class="display-table height-100 width-100">
                                            <div class="display-table-cell height-100 width-100 vertical-align-middle position-relative">
                                                <a href="<%=Page.ResolveClientUrl("~/")%>">
                                                    <img id="logo_header1" runat="server" alt="LOGO"></a>
                                                <div class="position-absolute bottom-50 text-center width-100 margin-30px-bottom">
                                                    <div class="text-small text-extra-medium-gray">&COPY; 2017 POFO is Proudly Powered by <a href="http://www.themezaa.com/" title="ThemeZaa" class="text-extra-medium-gray text-deep-pink-hover" target="_blank">ThemeZaa</a></div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6 no-padding bg-white full-screen">
                                <div class="position-absolute height-100 width-100 overflow-auto">
                                    <div class="display-table height-100 width-100">
                                        <div class="display-table-cell height-100 width-100 vertical-align-middle padding-nine-lr alt-font link-style-2 sm-padding-seven-lr xs-padding-15px-lr">
                                            <!-- start menu -->
                                            <ul class="font-weight-600 xs-no-padding-left">
                                                <!-- start menu item -->
                                                <li class="dropdown">
                                                    <a href="<%=Page.ResolveClientUrl("~/")%>">Home</a>
                                                </li>
                                                <!-- end menu item -->
                                                <!-- start menu item -->
                                                <li class="dropdown">
                                                    <a href="<%=Page.ResolveClientUrl("~/about-me/")%>">About</a>
                                                </li>
                                                <!-- end menu item -->
                                                <!-- start menu item -->
                                                <li class="dropdown">
                                                    <a href="<%=Page.ResolveClientUrl("~/tour/")%>">Tour</a>
                                                </li>
                                                <!-- end menu item -->
                                                <!-- start menu item -->
                                                <li class="dropdown">
                                                    <a href="<%=Page.ResolveClientUrl("~/offer/")%>">Special Offer</a>
                                                </li>
                                                <!-- end menu item -->
                                                <!-- start menu item -->
                                                <li class="dropdown">
                                                    <a href="<%=Page.ResolveClientUrl("~/gallery/")%>">Gallery</a>
                                                </li>
                                                <!-- end menu item -->
                                                <!-- start menu item -->
                                                <li class="dropdown">
                                                    <a href="<%=Page.ResolveClientUrl("~/diary/")%>">Escort diary</a>
                                                </li>

                                                <li class="dropdown">
                                                    <a href="<%=Page.ResolveClientUrl("~/testimonial/")%>">Testimonials</a>

                                                </li>


                                                <li class="dropdown">
                                                    <a href="<%=Page.ResolveClientUrl("~/selfie/")%>">Selfie</a>

                                                </li>

                                                <li class="dropdown">
                                                    <a href="<%=Page.ResolveClientUrl("~/calender/")%>">Calender</a>

                                                </li>

                                                <li class="dropdown">
                                                    <a href="<%=Page.ResolveClientUrl("~/news/")%>">News & Announcements</a>

                                                </li>

                                                <li class="dropdown">
                                                    <a href="<%=Page.ResolveClientUrl("~/forum/")%>">Escort Forum</a>

                                                </li>

                                                <li class="dropdown">
                                                    <a href="<%=Page.ResolveClientUrl("~/voting/")%>">Image voting</a>

                                                </li>
                                                <li class="dropdown" id="login_section" runat="server">
                                                       <%-- <a class='dropdown-toggle' data-toggle='dropdown' href='javascript:void(0);'>User</a>
                                                       <ul class='dropdown-menu'>
														<li><a href='<%=Page.ResolveClientUrl("~/user/login.aspx/")%>'>Login</a></li>
														<li><a href='<%=Page.ResolveClientUrl("~/user/registration.aspx/")%>'>Registration</a></li>
													  </ul>--%>
                                                </li>

                                                <li class="dropdown">
                                                    <a href="<%=Page.ResolveClientUrl("~/contact/")%>">Contact</a>

                                                </li>


                                                <!-- end menu item -->
                                            </ul>
                                            <!-- end menu -->
                                            <!-- start social links -->
                                            <div class="margin-fifteen-top padding-35px-left xs-no-padding-left">
                                                <div class="icon-social-medium margin-three-bottom">
                                                    <a href="https://www.facebook.com/" target="_blank" class="text-extra-dark-gray text-deep-pink-hover margin-one-lr"><i class="fab fa-facebook-f" aria-hidden="true"></i></a>
                                                    <a href="https://twitter.com/" target="_blank" class="text-extra-dark-gray text-deep-pink-hover margin-one-lr"><i class="fab fa-twitter" aria-hidden="true"></i></a>
                                                    <a href="https://dribbble.com/" target="_blank" class="text-extra-dark-gray text-deep-pink-hover margin-one-lr"><i class="fab fa-dribbble" aria-hidden="true"></i></a>
                                                    <a href="https://plus.google.com" target="_blank" class="text-extra-dark-gray text-deep-pink-hover margin-one-lr"><i class="fab fa-google-plus-g" aria-hidden="true"></i></a>
                                                    <a href="https://www.tumblr.com/" target="_blank" class="text-extra-dark-gray text-deep-pink-hover margin-one-lr"><i class="fab fa-tumblr" aria-hidden="true"></i></a>
                                                </div>
                                            </div>
                                            <!-- start social links -->
                                        </div>
                                    </div>
                                </div>
                                <button class="close-button-menu" id="close-button"></button>
                            </div>
                        </div>
                        <!-- end main menu -->
                        <button class="navbar-toggle mobile-toggle" type="button" id="open-button" data-toggle="collapse" data-target=".navbar-collapse">
                            <span></span>
                            <span></span>
                            <span></span>
                        </button>
                    </div>
                </div>
            </div>
            <!-- end navigation panel -->
        </nav>
        <!-- end navigation -->
    </header>

    <section class="wow fadeIn cover-background background-position-top top-space" id="header_img" runat="server">
        <div class="opacity-medium bg-extra-dark-gray"></div>
        <div class="container">
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12 display-table page-title-large">
                    <div class="display-table-cell vertical-align-middle text-center padding-30px-tb">
                        <!-- start sub title -->

                        <!-- end sub title -->
                        <!-- start page title -->
                        <h1 class="alt-font text-white font-weight-600 no-margin-bottom">Contact Us</h1>
                        <!-- end page title -->
                    </div>
                </div>
            </div>
        </div>
    </section>

    <!-- start form section -->
    <section class="wow fadeIn" id="start-your-project">
        <div class="container">
            <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-8 col-xs-12 center-col margin-eight-bottom sm-margin-40px-bottom xs-margin-30px-bottom text-center last-paragraph-no-margin">
                    <h5 class="alt-font font-weight-700 text-extra-dark-gray text-uppercase">tell us about your project</h5>
                    <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since. Lorem Ipsum has been the industry. Lorem Ipsum is simply dummy text.</p>
                </div>
            </div>
            <form id="project_contact_form" runat="server">
                <div class="row">
                    <div class="col-md-12">
                        <div id="success-project_contact_form" class="no-margin-lr"></div>
                    </div>
                    <div class="col-md-4">
                        <input type="text" id="txt_Name" runat="server" placeholder="Name *" class="big-input">
                    </div>
                    <div class="col-md-4">
                        <input type="text" id="txt_Phone" runat="server" placeholder="Phone" class="big-input">
                    </div>
                    <div class="col-md-4">
                        <input type="text" id="txt_Email" runat="server" placeholder="E-mail *" class="big-input">
                    </div>
                    <%--<div class="col-md-6">
                        <div class="select-style big-select">
                            <select name="budget" id="budget" class="bg-transparent no-margin-bottom">
                                <option value="">Select your budget</option>
                                <option value="$500 - $1000">$500 - $1000</option>
                                <option value="$1000 - $2000">$1000 - $2000</option>
                                <option value="$2000 - $5000">$2000 - $5000</option>
                            </select>
                        </div>
                    </div>--%>
                    <div class="col-md-12">
                        <textarea id="txt_Message" runat="server" placeholder="Type Here....." rows="6" class="big-textarea"></textarea>
                    </div>

                    <div class="col-md-12 text-center" runat="server">
                        <asp:Button ID="btn_Submit" runat="server" Text="Submit Now" CssClass="btn btn-transparent-dark-gray btn-large margin-20px-top" OnClick="btn_Submit_click" />
                    </div>
                </div>
            </form>
        </div>
    </section>
    <section class="container-fluid contactmaparea"><div class="row"><iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d13027.97416827141!2d149.12044457966786!3d-35.2812868180875!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x6b164d69b05c9021%3A0x500ea6ea7695660!2sCanberra%20ACT%202601%2C%20Australia!5e0!3m2!1sen!2sin!4v1593522587086!5m2!1sen!2sin" width="100%" height="450" frameborder="0" style="border: 0;" allowfullscreen="" aria-hidden="false" tabindex="0"></iframe>
    </div></section>
    <!-- start contact section -->
    <section class="no-padding bg-extra-dark-gray">
        <div class="container-fluid">
            <div class="row equalize sm-equalize-auto">
                <div class="col-md-6 col-sm-12 no-padding cover-background sm-height-450px xs-height-350px wow fadeInLeft" id="back_image" runat="server" style="background-position: left center !important;"></div>
                <div class="col-md-6 col-sm-12 no-padding col-2-nth wow fadeInRight">
                    <!-- start contact item -->
                    <div class="col-md-6 col-sm-6 col-xs-12 display-table bg-extra-dark-gray height-350px last-paragraph-no-margin">
                        <div class="display-table-cell vertical-align-middle text-center">
                            <i class="icon-map text-deep-pink icon-medium margin-25px-bottom"></i>
                            <div class="text-white text-uppercase alt-font font-weight-600 margin-5px-bottom">Contact Address</div>
                            <span id="address" runat="server">
                                <%--<p class='width-60 md-width-80 center-col text-medium'>301 The Greenhouse, Custard Factory, London, E2 8DY.</p>--%>
                            </span>
                        </div>
                    </div>
                    <!-- end contact item -->
                    <!-- start contact item -->
                    <div class="col-md-6 col-sm-6 col-xs-12 display-table bg-black height-350px last-paragraph-no-margin">
                        <div class="display-table-cell vertical-align-middle text-center">
                            <i class="icon-chat text-deep-pink icon-medium margin-25px-bottom"></i>
                            <div class="text-white text-uppercase alt-font font-weight-600 margin-5px-bottom">Let's Talk</div>
                            <span id="contact" runat="server">
                                <%--<p class='center-col text-medium no-margin'>Phone: 1-800-222-000</p>--%>

                                <%-- <p class="center-col text-medium">Fax: 1-800-222-002</p>--%>
                            </span>
                        </div>
                    </div>
                    <!-- end contact item -->
                    <!-- start contact item -->
                    <div class="col-md-6 col-sm-6 col-xs-12 display-table bg-black height-350px last-paragraph-no-margin">
                        <div class="display-table-cell vertical-align-middle text-center">
                            <i class="icon-envelope text-deep-pink icon-medium margin-25px-bottom"></i>
                            <div class="text-white text-uppercase alt-font font-weight-600 margin-5px-bottom">Email Us</div>
                           <span id="mail" runat="server">
                            <%--<p class='center-col text-medium no-margin'><a href="mailto:info@domain.com">info@domain.com</a></p>--%>
                            <%--<p class="center-col text-medium"><a href="mailto:hire@domain.com">hire@domain.com</a></p>--%>
                            </span>
                        </div>
                    </div>
                    <!-- end contact item -->
                    <!-- start contact item -->
                    <div class="col-md-6 col-sm-6 col-xs-12 display-table bg-extra-dark-gray height-350px last-paragraph-no-margin">
                        <div class="display-table-cell vertical-align-middle text-center">
                            <i class="icon-clock text-deep-pink icon-medium margin-25px-bottom"></i>
                            <div class="text-white text-uppercase alt-font font-weight-600 margin-5px-bottom">Working Hours</div>
                            <p class="center-col text-medium no-margin">Mon to Sat - 9 AM to 11 PM</p>
                            <p class="center-col text-medium">Sunday - 10 AM to 6 PM</p>
                        </div>
                    </div>
                    <!-- end contact item -->
                </div>
            </div>
        </div>
    </section>

    <section class="wow fadeIn bg-light-gray">
        <div class="container">
            <div class="row">
                <div class="col-md-12 text-center social-style-4 border round">
                    <span class="text-medium font-weight-600 text-uppercase display-block alt-font text-extra-dark-gray margin-30px-bottom">On social networks</span>
                    <div class="social-icon-style-4">
                        <ul class="margin-30px-top large-icon" id="social_content" runat="server">
                          <%--  <li><a class='facebook' href="https://facebook.com" target='_blank'><i class='fab fa-facebook-f'></i><span></span></a></li>
                            <li><a class='twitter' href="http://twitter.com" target='_blank'><i class='fab fa-twitter'></i><span></span></a></li>
                            <li><a class='google' href="http://google.com" target='_blank'><i class='fab fa-google-plus-g'></i><span></span></a></li>
                            <li><a class='dribbble' href="http://dribbble.com" target='_blank'><i class='fab fa-dribbble'></i><span></span></a></li>
                            <li><a class='linkedin' href="http://linkedin.com" target='_blank'><i class='fab fa-linkedin-in'></i><span></span></a></li>--%>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </section>


    <a class="scroll-top-arrow" href="javascript:void(0);"><i class="ti-arrow-up"></i></a>
    <!-- end scroll to top  -->
  <%--     <script src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.0.0-beta/js/bootstrap.min.js'></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>--%>
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
    <%--<script type="text/javascript" src="<%=Page.ResolveClientUrl("~/main-assets/js/jquery.themepunch.tools.min.js")%>"></script>
    <script type="text/javascript" src="<%=Page.ResolveClientUrl("~/main-assets/js/jquery.themepunch.revolution.min.js")%>"></script>--%>
    <script type="text/javascript" src="<%=Page.ResolveClientUrl("~/main-assets/js/main.js")%>"></script>
   
   <%-- <script>
        jQuery(document).ready(function () {
            jQuery(".button-collapse").sideNav();
        })
    </script>--%>
</body>
</html>

