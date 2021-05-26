<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ProjectSix.gallery.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                            <h1 class="alt-font text-white font-weight-600 no-margin-bottom">Gallery</h1>
                            <!-- end page title -->
                        </div>
                    </div>
                </div>
            </div>
        </section>
        
   <section class="wow fadeIn" style="">
            <div class=" container-fluid">
              <div class="row no-margin">
              <div class="col-sm-12">
              <h5 class="alt-font text-dark-gray font-weight-600 text-center margin-100px-bottom">Gallery</h5>
              </div>
              <div class="col-sm-12">
                    <ul class="portfolio-grid work-4col hover-option2" id="galler_list" runat="server">
                        <%--<li class="grid-sizer"></li>
                        <!-- start image gallery item -->
                        <li class="grid-item wow fadeInUp">
                            <a href="<%=Page.ResolveClientUrl("~/demo6/main-assets/images/gallery/1.jpg")%>"  title="Lightbox gallery image title..." data-group="four-columns-masonry" class="lightbox-group-gallery-item">
                                <figure>
                                    <div class="portfolio-img bg-extra-dark-gray"><img src="<%=Page.ResolveClientUrl("~/demo6/main-assets/images/gallery/1.jpg")%>" alt="" class="project-img-gallery"/></div>
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
                            <a href="<%=Page.ResolveClientUrl("~/demo6/main-assets/images/gallery/7.jpg")%>"  title="Lightbox gallery image title..." data-group="four-columns-masonry" class="lightbox-group-gallery-item">
                                <figure>
                                    <div class="portfolio-img bg-extra-dark-gray"><img src="<%=Page.ResolveClientUrl("~/demo6/main-assets/images/gallery/7.jpg")%>" alt="" class="project-img-gallery"/></div>
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
                            <a href="<%=Page.ResolveClientUrl("~/demo6/main-assets/images/gallery/2.jpg")%>"  title="Lightbox gallery image title..." data-group="four-columns-masonry" class="lightbox-group-gallery-item">
                                <figure>
                                    <div class="portfolio-img bg-extra-dark-gray"><img src="<%=Page.ResolveClientUrl("~/demo6/main-assets/images/gallery/2.jpg")%>" alt="" class="project-img-gallery"/></div>
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
                            <a href="<%=Page.ResolveClientUrl("~/demo6/main-assets/images/gallery/3.jpg")%>"  title="Lightbox gallery image title..." data-group="four-columns-masonry" class="lightbox-group-gallery-item">
                                <figure>
                                    <div class="portfolio-img bg-extra-dark-gray"><img src="<%=Page.ResolveClientUrl("~/demo6/main-assets/images/gallery/3.jpg")%>" alt="" class="project-img-gallery"/></div>
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
                            <a href="<%=Page.ResolveClientUrl("~/demo6/main-assets/images/gallery/4.jpg")%>"  title="Lightbox gallery image title..." data-group="four-columns-masonry" class="lightbox-group-gallery-item">
                                <figure>
                                    <div class="portfolio-img bg-extra-dark-gray"><img src="<%=Page.ResolveClientUrl("~/demo6/main-assets/images/gallery/4.jpg")%>" alt="" class="project-img-gallery"/></div>
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
                            <a href="<%=Page.ResolveClientUrl("~/demo6/main-assets/images/gallery/5.jpg")%>"  title="Lightbox gallery image title..." data-group="four-columns-masonry" class="lightbox-group-gallery-item">
                                <figure>
                                    <div class="portfolio-img bg-extra-dark-gray"><img src="<%=Page.ResolveClientUrl("~/demo6/main-assets/images/gallery/5.jpg")%>" alt="" class="project-img-gallery"/></div>
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
                            <a href="<%=Page.ResolveClientUrl("~/demo6/main-assets/images/gallery/6.jpg")%>"  title="Lightbox gallery image title..." data-group="four-columns-masonry" class="lightbox-group-gallery-item">
                                <figure>
                                    <div class="portfolio-img bg-extra-dark-gray"><img src="<%=Page.ResolveClientUrl("~/demo6/main-assets/images/gallery/6.jpg")%>" alt="" class="project-img-gallery"/></div>
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
                    </ul>
                    </div>
                </div>
            </div>
        </section> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
