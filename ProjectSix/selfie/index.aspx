<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ProjectSix.selfie.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style>
        
        @media (max-width: 425px){
            .btn.btn-transparent-white {
                background: transparent;
                border-color: #ffffff;
                color: #ffffff;
                margin-top: 20px !important;
            }
        }
        
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <section class="wow fadeIn cover-background background-position-top top-space" id="header_img" runat="server">
        <div class="opacity-medium bg-extra-dark-gray"></div>
        <div class="container">
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12 display-table page-title-large">
                    <div class="display-table-cell vertical-align-middle text-center padding-30px-tb">
                        <!-- start sub title -->

                        <!-- end sub title -->
                        <!-- start page title -->
                        <h1 class="alt-font text-white font-weight-600 no-margin-bottom">Awesome Selfie's</h1>
                        <!-- end page title -->
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="wow fadeIn bg-dark-gray">
        <div class=" container-fluid">
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12 display-table wow slideInRight last-paragraph-no-margin sm-text-center" style="visibility: visible; animation-name: slideInRight; height: 71px;">
                    <div class=" xs-text-center">

                        <h4 class="alt-font text-extra-dark-gray text-center ">Awesome Selfie's</h4>

                    </div>
                </div>
            </div>
            <div class="row no-margin">
                <ul class="portfolio-grid work-3col hover-option2 gutter-medium" id="selfi_list" runat="server">
                    <%--<li class="grid-sizer"></li>
                    <!-- start image gallery item -->
                    <li class="grid-item wow fadeInUp">
                        <a href="<%=Page.ResolveClientUrl("~/main-assets/images/sel_1.jpg")%>" title="Lightbox gallery image title..." data-group="three-columns-zoom-animation" class="lightbox-group-gallery-item">
                            <figure>
                                <div class="portfolio-img bg-extra-dark-gray">
                                    <img src="<%=Page.ResolveClientUrl("~/main-assets/images/sel_1.jpg")%>" alt="" class="project-img-gallery" /></div>
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
                    </li>--%>
                    <!-- end image gallery item -->
                    <!-- start image gallery item -->
                    <%--<li class="grid-item wow fadeInUp">
                        <a href="<%=Page.ResolveClientUrl("~/main-assets/images/sel_1.jpg")%>" title="Lightbox gallery image title..." data-group="three-columns-zoom-animation" class="lightbox-group-gallery-item">
                            <figure>
                                <div class="portfolio-img bg-extra-dark-gray">
                                    <img src="<%=Page.ResolveClientUrl("~/main-assets/images/sel_1.jpg")%>" alt="" class="project-img-gallery" /></div>
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
                    </li>--%>
                    <!-- end image gallery item -->
                    <!-- start image gallery item -->
                    <%--<li class="grid-item wow fadeInUp">
                        <a href="<%=Page.ResolveClientUrl("~/main-assets/images/sel_1.jpg")%>" title="Lightbox gallery image title..." data-group="three-columns-zoom-animation" class="lightbox-group-gallery-item">
                            <figure>
                                <div class="portfolio-img bg-extra-dark-gray">
                                    <img src="<%=Page.ResolveClientUrl("~/main-assets/images/sel_1.jpg")%>" alt="" class="project-img-gallery" /></div>
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
                    </li>--%>
                    <!-- end image gallery item -->
                </ul>
            </div>
            <div class="row no-margin">
                <ul class="portfolio-grid work-3col hover-option2 gutter-medium" id="sel_list" runat="server">
                    <%--<li class="grid-sizer"></li>
                    <!-- start image gallery item -->
                    <li class="grid-item wow fadeInUp">
                        <a href="<%=Page.ResolveClientUrl("~/main-assets/images/sel_1.jpg")%>" title="Lightbox gallery image title..." data-group="three-columns-zoom-animation" class="lightbox-group-gallery-item">
                            <figure>
                                <div class="portfolio-img bg-extra-dark-gray">
                                    <img src="<%=Page.ResolveClientUrl("~/main-assets/images/sel_1.jpg")%>" alt="" class="project-img-gallery" /></div>
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
                    </li>--%>
                    <!-- end image gallery item -->
                    <!-- start image gallery item -->
                    <%--<li class="grid-item wow fadeInUp">
                        <a href="<%=Page.ResolveClientUrl("~/main-assets/images/sel_1.jpg")%>" title="Lightbox gallery image title..." data-group="three-columns-zoom-animation" class="lightbox-group-gallery-item">
                            <figure>
                                <div class="portfolio-img bg-extra-dark-gray">
                                    <img src="<%=Page.ResolveClientUrl("~/main-assets/images/sel_1.jpg")%>" alt="" class="project-img-gallery" /></div>
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
                    </li>--%>
                    <!-- end image gallery item -->
                    <!-- start image gallery item -->
                    <%--<li class="grid-item wow fadeInUp">
                        <a href="<%=Page.ResolveClientUrl("~/main-assets/images/sel_1.jpg")%>" title="Lightbox gallery image title..." data-group="three-columns-zoom-animation" class="lightbox-group-gallery-item">
                            <figure>
                                <div class="portfolio-img bg-extra-dark-gray">
                                    <img src="<%=Page.ResolveClientUrl("~/main-assets/images/sel_1.jpg")%>" alt="" class="project-img-gallery" /></div>
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
                    </li>--%>
                    <!-- end image gallery item -->
                </ul>
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

                <div class="col-sm-8 holder padding-30px-all margin-40px-top" id="avai_list" runat="server">
                    <%--<table class="table table-hover">
                        <thead>
                            <tr>
                                <th scope="col">Weekday</th>
                                <th scope="col">From</th>
                                <th scope="col">Untill</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Monday</td>
                                <td>10:00 AM</td>
                                <td>10:00 PM</td>
                            </tr>
                            <tr>
                                <td>Tuesday</td>
                                <td>10:00 AM</td>
                                <td>10:00 PM</td>
                            </tr>
                            <tr>
                                <td>Wednesday</td>
                                <td>10:00 AM</td>
                                <td>10:00 PM</td>
                            </tr>
                            <tr>
                                <td>Thursday</td>
                                <td>10:00 AM</td>
                                <td>10:00 PM</td>
                            </tr>
                            <tr>
                                <td>Friday</td>
                                <td>10:00 AM</td>
                                <td>10:00 PM</td>
                            </tr>
                            <tr>
                                <td>Saturday</td>
                                <td>10:00 AM</td>
                                <td>10:00 PM</td>
                            </tr>
                            <tr>
                                <td>Saturday</td>
                                <td>10:00 AM</td>
                                <td>10:00 PM</td>
                            </tr>
                        </tbody>
                    </table>--%>

                </div>
                <div class="col-sm-2"></div>


            </div>

        </div>
    </section>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
