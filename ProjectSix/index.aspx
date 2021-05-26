<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ProjectSix.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<%=Page.ResolveClientUrl("~/main-assets/fullcalendar/lib/main.css")%>" rel='stylesheet' />
     <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <script>

        function show_modal() {
            $("#modal_default").css('display', 'block');
        }

        function close_modal() {
            $("#modal_default").css('display', 'none');
        }

        function my_fun() {

            var dt = document.getElementById("eventDayName").innerHTML;

            PageMethods.GetEvent(dt, OnSuccess);

        }

        function OnSuccess(response, userContext, methodName) {
            // alert(response);



            let emptyMessage = document.createElement("div");
            emptyMessage.className = "empty-message";
            emptyMessage.innerHTML = response;
            sidebarEvents.appendChild(emptyMessage);
            let emptyFormMessage = document.getElementById("emptyFormTitle");
            emptyFormMessage.innerHTML = "No events now";
        }



        function my_js_function() {



            my_fun();



        }

        //function popup() {
        //    swal({
        //        title: "Good Job!",
        //        text: "Data submited successfully",
        //        icon: "success",
        //        button: "close",
        //    });
        //}
    </script>
    <script type="text/javascript">

</script>
    <style>
  /*      .modal {
 
    position: fixed;
    top: 0;
    left: 0;
    z-index: 1050;
    display: none;
    width: 50%;
    height: 100%;
    overflow: hidden;
    outline: 0;
}
*/

.modal-dialog {
    position: relative;
    width: auto;
    margin: .5rem;
    pointer-events: none;
}

.modal-content {
    position: relative;
    display: -ms-flexbox;
    display: flex;
    -ms-flex-direction: column;
    flex-direction: column;
    width: 100%;
    pointer-events: auto;
    background-color: #fff;
    background-clip: padding-box;
    border: 1px solid rgba(0,0,0,.2);
    border-radius: .25rem;
    box-shadow: 0 .25rem .5rem rgba(0,0,0,.1);
    outline: 0;
}

.modal-header {
    position: relative;
    border-top-left-radius: .1875rem;
    border-top-right-radius: .1875rem;
}

.modal-title {
    margin-bottom: 0;
    line-height: 1.5385;
}

.modal-header .close {
    color: inherit;
	/*padding: 1.25rem 1.25rem;*/
margin: -1.25rem -1.25rem -1.25rem auto;
position:relative;
top:-40px;

}

.modal-body {
    position: relative;
    -ms-flex: 1 1 auto;
    flex: 1 1 auto;
    padding: 1.25rem;
}

.form-group {
    margin-bottom: 1.25rem;
}

.modal-footer {
    display: -ms-flexbox;
    display: flex;
    -ms-flex-align: center;
    align-items: center;
    -ms-flex-pack: end;
    justify-content: flex-end;
    padding: 1.25rem;
        padding-top: 1.25rem;
    border-top: 1px solid rgba(0,0,0,.125);
        border-top-width: 1px;
    border-bottom-right-radius: .25rem;
    border-bottom-left-radius: .25rem;
}

.btn-link {
    font-weight: 400;
    color: #2196f3;
    text-decoration: none;
}

.bg-primary {
    background-color: #2196f3 !important;
}
        
<!--        Supriyo CSS-->
        
        
        
        
        
        @media (max-width: 767px){
        
        .b-text{
            font-size: 2rem !important;
        }
        
        
        .modal .modal-content {
            padding: 5px;
            
        
}
       .tour-modal{
            height: 500px !important;
        }
       

        }
       
        
        
        
      div#modal_default {
        max-height: 68% !important;
      }
        
         #gallery_img{
            background: no-repeat center top !important;
            background-color: #020202;
          }
        
        
    @media (max-width: 375px){
            .row .col {
                width: 46px !important;
                height: 49px !important;
                padding: 0 0.75rem !important;
                margin: 0 0 0 3px !important;
    }
        
        .row .col {
                width: 40px !important;
                height: 56px !important;
                padding: 0 0.75rem !important;
                margin: 0 0 0 9px !important;
            }
    }    
        
        @media (max-width: 425px){
             h1.b-text {
    font-size: 3rem;
             
}
         button#project-contact-us-4-button {
                margin-top: 20px !important;
         }
        
}

        
        
        @media (max-width: 992px){
.calendar-wrapper {
    margin-top: 10px; 
}
}


        @media (max-width: 375px){
.sidebar-title {
    padding: 10px 6% 10px 6% !important;
}
        
       .full-width-pull-menu .dropdown .dropdown-toggle:before {
    left: 96px !important;
    top: 10px;
}
        
        .full-width-pull-menu .dropdown .dropdown-toggle:after {
    left: 90px !important;
    top: 14.6px;
}
        
   
}   
        
        @media (max-width: 1024px){
.sidebar-title {
    padding: 10px 6% 0 6% !important;
}
        
        .empty-message {
    font-size: 1.2rem;
    padding: 15px 6% 15px 6%;
}
}        
        
        
        
    .btn.btn-transparent-white {
    background: transparent;
    border-color: #ffffff;
    color: #ffffff;
    margin-top: 20px !important;
    }
      
        
        .side-nav.fixed {
    left: 0;
    transform: translateX(0);
    position: relative;
    float: left;
    padding-left: 0;
}
        
        
        @media (max-width: 991px){
.full-width-pull-menu .dropdown .dropdown-toggle {
    top: 0px;
}
        
        .full-width-pull-menu .dropdown .dropdown-toggle:before {
    left: 89px !important;
    top: 10px;
}
        
        .full-width-pull-menu .dropdown .dropdown-toggle:after {
    left: 84px !important;
    top: 15px;
}
}        
        
        @media (max-width: 768px){
            .full-width-pull-menu .dropdown .dropdown-toggle:before {
             left: 140px !important;
              top: 9px;
            }
        
            .full-width-pull-menu .dropdown .dropdown-toggle:after {
            left: 135px !important;
            top: 13.5px;
            }
        }
        
        .fadeInUp {
            margin: 3px 0px !important;
    }
    
    
        
        .es-diary {
             text-align: center;
        }
        
        .font-weight-400 {
            font-weight: 400;
            text-align: center;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <!-- start slider section -->


    <section class="no-padding main-slider height-100 mobile-height wow fadeIn ">
        <div class="swiper-full-screen swiper-container height-100 width-100 white-move">
            <div class="swiper-wrapper" id="bannerfrontend" runat="server">
            </div>
            <div class="swiper-pagination swiper-pagination-white swiper-full-screen-pagination"></div>
            <div class="swiper-button-next swiper-button-black-highlight display-none"></div>
            <div class="swiper-button-prev swiper-button-black-highlight display-none"></div>
        </div>
    </section>
    <section class="no-padding wow fadeIn bg-extra-light-gray">
        <div class="container-fluid no-padding">
            <div class="row equalize sm-equalize-auto no-margin">
                <div class="col-md-6 col-sm-12 col-xs-12 position-relative sm-height-500px xs-height-350px cover-background wow slideInLeft" id="about_img" runat="server"></div>
                <div class="col-md-6 col-sm-12 col-xs-12 display-table wow slideInRight last-paragraph-no-margin sm-text-center">
                    <div class="display-table-cell vertical-align-middle padding-fifteen-all sm-padding-ten-all xs-no-padding-lr xs-text-center" id="about_desc" runat="server">
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="wow fadeIn cover-background" style="background: no-repeat center top;" id="tour_img" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12">
                    <h5 class="alt-font text-light-gray font-weight-600">Tour</h5>
                    <p>Offering content producers the very best environment, showcasing world-class content. Powering your content with Artificial Intelligence and Machine Learning to our global audience.</p>


                    <h5 class="alt-font text-light-gray font-weight-600">Australian Tours</h5>
                    <p>I'm planning a potenical visit to Melb. Depending on amount of hours you'd desire to book me for</p>
                </div>
                <div class="col-sm-8" id="table_list" runat="server">
                </div>
              
            </div>
        </div>
        
    </section>
    <!-- end recent work section -->
    <!--modal-->
       <div id="modal_default" class="modal tour-modal" tabindex="-1" style="display: none;">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Enter Your Email & Select the City</h5>
                    <button type="button" onclick="close_modal()" class="close cls" data-dismiss="modal">&times;</button>
                </div>

                <div class="modal-body">
                    <div class="form-group row">
                        <label class="col-lg-4 col-form-label">
                           Enter the Email</label>
                        <div class="col-lg-8">
                           
                            <asp:TextBox ID="txt_EMAIL" runat="server" style="position:relative;top:-10px;" class="form-control" placeholder="Enter Your Email"></asp:TextBox>
                        </div>
                    </div>
                      <div class="form-group row">
                        <label class="col-lg-4 col-form-label">
                           Select the city</label>
                        <div class="col-lg-8">
                            <asp:DropDownList ID="ddl_CITY" runat="server" class="form-control"></asp:DropDownList>
                           
                        </div>
                    </div>
                </div>

                <div class="modal-footer">
                    <button type="button" onclick="close_modal()" class="btn btn-link cls" data-dismiss="modal">Close</button>
                    <input type="button" id="btn_Save_Menu" runat="server" onserverclick="btn_Save_Menu_ServerClick" class="btn bg-primary" value="Submit" />
                </div>
            </div>
        </div>
    </div>

    <section class="wow fadeIn" style="background: no-repeat center top;" id="quick_img" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-sm-4"></div>
                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12" id="quick_list" runat="server">
                </div>
            </div>
        </div>
    </section>

    <section class="wow fadeIn bg-extra-light-gray padding-80px-bottom padding-80px-top" id="services">
        <div class="container no-padding">
            <div class="row equalize sm-equalize-auto no-margin" id="prefer_list" runat="server">
                <div class="col-sm-12 col-lg-4 margin-30px-top"></div>
            </div>
        </div>
    </section>

    <section class="wow fadeIn" id="gallery_img" runat="server">
        <div class="container">
            <div class="row no-margin">
                <div class="col-sm-12">
                    <h5 class="alt-font text-light-gray font-weight-600 text-center margin-100px-bottom">Gallery</h5>
                </div>
                <div class="col-sm-12" id="galleryy_list" runat="server">

                    <ul class="portfolio-grid work-4col hover-option2">
					
                        <li class="grid-sizer"></li>
                        <!-- start image gallery item -->
                        <li class="grid-item wow fadeInUp">
                            <a href="documents/gallery/20200921_070816.jpg"  title="Lightbox gallery image title..." data-group="four-columns-masonry" class="lightbox-group-gallery-item">
                                <figure>
                                    <div class="portfolio-img bg-extra-dark-gray"><img src="documents/gallery/20200921_070816.jpg" alt="" class="project-img-gallery"/></div>
                                    <figcaption>
                                        <div class="portfolio-hover-main text-center">
                                            <div class="portfolio-hover-box vertical-align-middle">
                                                <div class="portfolio-hover-content position-relative">
                                                    <i class="ti-zoom-in text-white fa-2x"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </figcaption>
                                </figure>
                            </a>
                        </li>
                        <!-- end image gallery item -->
                        <!-- start image gallery item -->
                        <li class="grid-item wow fadeInUp" data-wow-delay="0.2s">
                            <a href="documents/gallery/20200921_070804.jpg"  title="Lightbox gallery image title..." data-group="four-columns-masonry" class="lightbox-group-gallery-item">
                                <figure>
                                    <div class="portfolio-img bg-extra-dark-gray"><img src="documents/gallery/20200921_070804.jpg" alt="" class="project-img-gallery"/></div>
                                    <figcaption>
                                        <div class="portfolio-hover-main text-center">
                                            <div class="portfolio-hover-box vertical-align-middle">
                                                <div class="portfolio-hover-content position-relative">
                                                    <i class="ti-zoom-in text-white fa-2x"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </figcaption>
                                </figure>
                            </a>
                        </li>
                        <!-- end image gallery item -->
                        <!-- start image gallery item -->
                        <li class="grid-item wow fadeInUp" data-wow-delay="0.4s">
                            <a href="documents/gallery/20200921_070657.jpg"  title="Lightbox gallery image title..." data-group="four-columns-masonry" class="lightbox-group-gallery-item">
                                <figure>
                                    <div class="portfolio-img bg-extra-dark-gray"><img src="documents/gallery/20200921_070657.jpg" alt="" class="project-img-gallery"/></div>
                                    <figcaption>
                                        <div class="portfolio-hover-main text-center">
                                            <div class="portfolio-hover-box vertical-align-middle">
                                                <div class="portfolio-hover-content position-relative">
                                                    <i class="ti-zoom-in text-white fa-2x"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </figcaption>
                                </figure>
                            </a>
                        </li>
                        <!-- end image gallery item -->
                        <!-- start image gallery item -->
                        <li class="grid-item wow fadeInUp" data-wow-delay="0.6s">
                            <a href="documents/gallery/20200921_070645.jpg"  title="Lightbox gallery image title..." data-group="four-columns-masonry" class="lightbox-group-gallery-item">
                                <figure>
                                    <div class="portfolio-img bg-extra-dark-gray"><img src="documents/gallery/20200921_070645.jpg" alt="" class="project-img-gallery"/></div>
                                    <figcaption>
                                        <div class="portfolio-hover-main text-center">
                                            <div class="portfolio-hover-box vertical-align-middle">
                                                <div class="portfolio-hover-content position-relative">
                                                    <i class="ti-zoom-in text-white fa-2x"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </figcaption>
                                </figure>
                            </a>
                        </li>
                        <!-- end image gallery item -->
                        <!-- start image gallery item -->
                        <li class="grid-item wow fadeInUp">
                            <a href="documents/gallery/20200921_070634.jpg"  title="Lightbox gallery image title..." data-group="four-columns-masonry" class="lightbox-group-gallery-item">
                                <figure>
                                    <div class="portfolio-img bg-extra-dark-gray"><img src="documents/gallery/20200921_070634.jpg" alt="" class="project-img-gallery"/></div>
                                    <figcaption>
                                        <div class="portfolio-hover-main text-center">
                                            <div class="portfolio-hover-box vertical-align-middle">
                                                <div class="portfolio-hover-content position-relative">
                                                    <i class="ti-zoom-in text-white fa-2x"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </figcaption>
                                </figure>
                            </a>
                        </li>
                        <!-- end image gallery item -->
                        <!-- start image gallery item -->
                        <li class="grid-item wow fadeInUp" data-wow-delay="0.4s">
                            <a href="documents/gallery/20200921_070555.jpg"  title="Lightbox gallery image title..." data-group="four-columns-masonry" class="lightbox-group-gallery-item">
                                <figure>
                                    <div class="portfolio-img bg-extra-dark-gray"><img src="documents/gallery/20200921_070555.jpg" alt="" class="project-img-gallery"/></div>
                                    <figcaption>
                                        <div class="portfolio-hover-main text-center">
                                            <div class="portfolio-hover-box vertical-align-middle">
                                                <div class="portfolio-hover-content position-relative">
                                                    <i class="ti-zoom-in text-white fa-2x"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </figcaption>
                                </figure>
                            </a>
                        </li>
                        <!-- end image gallery item -->
                        <!-- start image gallery item -->
                        <li class="grid-item wow fadeInUp" data-wow-delay="0.6s">
                            <a href="documents/gallery/20200921_070533.jpg"  title="Lightbox gallery image title..." data-group="four-columns-masonry" class="lightbox-group-gallery-item">
                                <figure>
                                    <div class="portfolio-img bg-extra-dark-gray"><img src="documents/gallery/20200921_070533.jpg" alt="" class="project-img-gallery"/></div>
                                    <figcaption>
                                        <div class="portfolio-hover-main text-center">
                                            <div class="portfolio-hover-box vertical-align-middle">
                                                <div class="portfolio-hover-content position-relative">
                                                    <i class="ti-zoom-in text-white fa-2x"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </figcaption>
                                </figure>
                            </a>
                        </li>
                        <!-- end image gallery item -->
                        <!-- start image gallery item -->
                    </ul>
					
					
                    <ul class='portfolio-grid work-4col hover-option2'>
                    </ul>
                </div>
            </div>
        </div>
    </section>
    <section class="wow fadeIn" style="background: no-repeat center top;" id="offer_img" runat="server">
        <div class="container no-padding">
            <div class="row equalize sm-equalize-auto no-margin">
                <div class="col-sm-4"></div>
                <div class="col-sm-8">
                    <div class="offer">
                        <div class="offer_box">
                            <h4 class="font-weight-600 text-center text-uppercase">Get exciting offers</h4>
                            <h1 class="font-weight-600 text-center text-uppercase">50%</h1>
                            <a href="<%=Page.ResolveClientUrl("~/offer/")%>" class="btn-danger btn btn-small button border-radius-4 margin-5px-all md-margin-15px-bottom sm-margin-lr-auto sm-display-table all">Discover Now <i class="ti-arrow-right"></i></a>
                            <h6 class=" text-center margin-20px-top">For Limited Offer Only</h6>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="wow fadeIn" style="background: no-repeat center top;" id="diary_img" runat="server">
        <div class="container no-padding">
            <div class="row equalize sm-equalize-auto no-margin">
                <h5 class="es-diary alt-font text-light-gray font-weight-600">Escort Diary</h5>
                <h6 class="font-weight-400  text-light-gray alt-font">You can have anything you want in life if you dress for it.</h6>
                <div class="col-md-6 col-sm-12 col-xs-12 display-table wow fadeIn">
                    <div class="display-table-cell-vertical-middle md-padding-ten-all sm-padding-six-all xs-padding-50px-tb xs-no-padding-lr" id="dairy_list" runat="server">
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="wow fadeIn animated bg-light-gray">
        <div class="container">
            <div class="row text-center">
                <div class="col-md-12">
                    <!--<p class="alt-font text-medium-gray margin-5px-bottom text-uppercase text-small">what people says</p>-->
                    <h5 class="text-uppercase alt-font text-extra-dark-gray margin-20px-bottom font-weight-700 sm-width-100 xs-width-100">Testimonials</h5>
                    <span class="separator-line-horrizontal-medium-light2 bg-deep-pink display-table margin-auto width-100px"></span>
                </div>
            </div>
            <div class="row">
                <div class=" margin-100px-top sm-margin-70px-top sm-width-60 sm-center-col xs-width-100 xs-margin-50px-top" id="testi_list" runat="server">
                </div>
            </div>
        </div>
    </section>

    <section class="wow fadeIn bg-dark-gray">
        <div class="container">
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12 display-table wow slideInRight last-paragraph-no-margin sm-text-center" style="visibility: visible; animation-name: slideInRight; height: 71px;">
                    <div class=" xs-text-center">
                        <h4 class="alt-font text-extra-dark-gray text-center ">Awesome Selfie's</h4>
                    </div>
                </div>
            </div>
            <div class="row no-margin">
                <ul class="portfolio-grid work-3col hover-option2 gutter-medium" id="selfi_list" runat="server">
                </ul>
            </div>
            <div class="row no-margin">
                <ul class="portfolio-grid work-3col hover-option2 gutter-medium" id="selfy_list" runat="server">
                </ul>
            </div>
        </div>
    </section>
    <section class=" wow fadeIn" style="background: no-repeat center top;" id="news_img" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-12 text-center margin-100px-bottom sm-margin-70px-bottom xs-margin-50px-bottom">

                    <h5 class="text-uppercase alt-font text-light-gray margin-20px-bottom font-weight-700 sm-width-100 xs-width-100">News & Announcements</h5>
                    <span class="separator-line-horrizontal-medium-light2 bg-deep-pink display-table margin-auto width-100px"></span>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 no-padding xs-padding-15px-lr" id="news_list" runat="server">
                </div>
            </div>
        </div>
    </section>

    <section class=" wow fadeIn" style="background: no-repeat center top;" id="rate_img" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-12 text-center margin-100px-bottom sm-margin-70px-bottom xs-margin-50px-bottom">

                    <h5 class="text-uppercase alt-font text-light-gray margin-20px-bottom font-weight-700 sm-width-100 xs-width-100">Rates</h5>
                    <span class="separator-line-horrizontal-medium-light2 bg-deep-pink display-table margin-auto width-100px"></span>
                </div>


                <div class="col-sm-2"></div>
                <div class="col-lg-5 col-md-12 col-sm-12">
                    <div class="rate padding-30px-all" id="rate_list" runat="server">
                    </div>
                </div>
                <div class="col-lg-5 col-md-12 col-sm-12">
                    <div class="rate padding-30px-all" id="rat_list" runat="server">
                    </div>
                </div>
            </div>

        </div>
    </section>

    <section class="wow fadeIn animated bg-light-gray">
        <div class="container">
            <div class="row text-center">
                <div class="col-md-12">

                    <h5 class="text-uppercase alt-font text-extra-dark-gray margin-20px-bottom font-weight-700 sm-width-100 xs-width-100">Availability</h5>
                    <span class="separator-line-horrizontal-medium-light2 bg-deep-pink display-table margin-auto width-100px"></span>
                </div>
                <div class="col-sm-2"></div>

                <div class="col-sm-8 holder padding-30px-all margin-40px-top" id="avail_list" runat="server">
                </div>
                <div class="col-sm-2"></div>


            </div>

        </div>
    </section>

    <section class="wow fadeIn" style="background: no-repeat center top;" id="cal_img" runat="server">
        <div class="container">
            <div class="row text-center">
                <div class="col-md-12 col-sm-12 col-xs-12 display-table wow slideInRight last-paragraph-no-margin sm-text-center margin-50px-bottom" style="visibility: visible; animation-name: slideInRight; height: 71px;">
                    <div class=" xs-text-center">

                        <h4 class="alt-font text-extra-dark-gray text-center ">Book Your Appointment</h4>

                    </div>
                </div>
                <div class="clearfix"></div>
                <asp:HiddenField ID="hf_date" runat="server" Value="" />
                <asp:HiddenField ID="hf_event_name" runat="server" Value="" />
                <asp:HiddenField ID="hf_event_desc" runat="server" Value="" />
                <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
                </asp:ScriptManager>

                <div class="main-wrapper">

                    <div class="col-md-6 col-md-offset-3">
                            <div id='calendar'></div>
                            </div>

                </div>

            </div>

        </div>
    </section>


    <section class="bg-light-gray wow fadeIn hover-option4 blog-post-style3">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 center-col margin-five-bottom sm-margin-40px-bottom xs-margin-30px-bottom text-center">

                    <h5 class="alt-font text-extra-dark-gray font-weight-600 width-65 margin-lr-auto md-width-85 xs-width-100">Image Voting</h5>
                </div>
            </div>
            <div class="row equalize xs-equalize-auto" id="voting_list" runat="server">
            </div>
        </div>
    </section>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
     <script src="<%=Page.ResolveClientUrl("~/main-assets/fullcalendar/lib/main.js")%>"></script>
    <script src="<%=Page.ResolveClientUrl("~/main-assets/js/nicescroll.js")%>"></script>
   <%-- <script>
        $(document).ready(function () {
            $(".popup-content").niceScroll({
                cursorcolor: "#cccccc",
                cursorwidth: "3px",
                background: "#3a3843",
                cursorborder: "0px solid #eee",
                cursorborderradius: 2
            });
        })
    </script>--%>
    <script>

        document.addEventListener('DOMContentLoaded', function () {
            var calendarEl = document.getElementById('calendar');
            var calendar = new FullCalendar.Calendar(calendarEl, {
                initialView: 'dayGridMonth'
            });
            calendar.render();
        });

    </script>
    <script>
        document.addEventListener('DOMContentLoaded', function () {
            var calendarEl = document.getElementById('calendar');

            var calendar = new FullCalendar.Calendar(calendarEl, {
                selectable: true,
                initialView: 'dayGridMonth',
                //initialDate: '2021-03-07',
                defaultDate: new Date(),
                timeZone: 'local',
                editable: true,
                headerToolbar: {
                    left: 'prev,next today',
                    center: 'title',
                    right: 'dayGridMonth,timeGridWeek,timeGridDay'
                },
                dateClick: function (info) {

                    //alert('Date: ' + info.dateStr);
                    location.href = "/calender?date=" + info.dateStr + "";
                },

                events: [

                ]
            });

            var cdate = calendar.getDate();
            var month_int = cdate.getMonth();
            calendar.render();
        });

        var mydata;
        var arr;
        var total = 0;

        function getall() {
            $.ajax({
                url: '<%=ResolveUrl("~/calender/index.aspx/GetAllEvent") %>',

                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: "",
                success: function (data) {
                    mydata = JSON.parse(data.d);
                    var vString = "";
                    if (mydata == null) {
                        alert("Sorry!! This is an offday! No Timeslot available today!!");
                    }
                    else {
                        mydata = JSON.parse(data.d);
                        console.log(mydata);
                        //for (var i = 0; i < mydata.length - 1; i++) {
                        //    var obj = mydata[i];
                        //}

                        var calendarEl = document.getElementById('calendar');
                        var calendar = new FullCalendar.Calendar(calendarEl, {
                            selectable: true,
                            initialView: 'dayGridMonth',
                            //initialDate: '2021-03-07',
                            defaultDate: new Date(),
                            timeZone: 'local',
                            editable: true,
                            headerToolbar: {
                                left: 'prev,next today',
                                center: 'title',
                                right: 'dayGridMonth,timeGridWeek,timeGridDay'
                            },

                            dateClick: function (info) {
                                //alert('Date: ' + info.dateStr);
                                location.href = "/calender?date=" + info.dateStr + "";

                            },

                            events: mydata,

                        });
                        var cdate = calendar.getDate();
                        var month_int = cdate.getMonth();
                        calendar.render();
                    }

                },

                error: function (response) {
                    console.log(response.responseText);
                },
                failure: function (response) {
                    console.log(response.responseText);
                }
            });



        }
    </script>
    <script>
        function get() {
            var dt = document.getElementById("eventDayName").innerHTML;
            document.getElementById('<%=hf_date.ClientID %>').value = dt;
            var event = document.getElementById("eventTitleInput").value;

            var eventname = document.getElementById("eventDescInput").value;
            document.getElementById('<%=hf_event_name.ClientID %>').value = event;
            document.getElementById('<%=hf_event_desc.ClientID %>').value = eventname;



        }
    </script>
    <script type="text/javascript">
        function savemenu(MenuName) {
            $("#inputMenuName").val("");
            $.ajax({
                url: '<%=ResolveUrl("~/webservices/globalservices.asmx/GenerateOTP") %>',
                data: "{toemail: 'ok'}",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d == 1) {
                       <%-- $("#<%=btn_Refresh.ClientID %>").trigger('click');--%>
                        alert("Menu create successfully.");
                        $("#modal_default").css('display', 'none');
                    }
                    else {
                        alert("Sorry!!! some error occured");
                    }
                },
                error: function (response) {
                    console.log(response.responseText);
                },
                failure: function (response) {
                    console.log(response.responseText);
                }
            });
        }

        

        $(document).ready(function () {

            getall();

            $("#btn_Save_Menu").on("click", function (e) {
                var menuname = $("#inputMenuName").val();
                 <%-- var headmenu = $('#<%=hf_HEAD_MENU_KEY.ClientID%>').val();--%>
                savemenu(menuname);

            });

        }

    </script>
    
</asp:Content>


