<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ProjectSix.about_me.index" %>

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
                        <h1 class="alt-font text-white font-weight-600 no-margin-bottom">About</h1>
                        <!-- end page title -->
                    </div>
                </div>
            </div>
        </div>
    </section>

    <!-- end slider section -->

    <section class="wow fadeIn">
        <div class="container">
            <div class="row">
               <div class="col-md-6 col-sm-12 text-left sm-margin-30px-bottom sm-padding-80px-lr xs-padding-15px-lr sm-text-center wow fadeIn" id="div_about_us" runat="server">
<%--                   <h5 class="alt-font font-weight-700 text-extra-dark-gray text-uppercase width-80 md-width-100">About</h5>
                    <div class="separator-line-verticle-extra-small bg-extra-dark-gray width-50 sm-width-70 sm-center-col margin-30px-bottom sm-margin-20px-bottom"></div>
                    <p class="width-95 md-width-100">
                        100% Aussie. NO FAKE PICS GUARANTEED.Sexy Crystal Sienna will leave you breathless. im a sexy, stunning high class Brisbane escort.<br>
                        <br>
                        If you have a weakness for a hot tanned and toned body with alluring features and a touch of class then I’m the lady for you. I’m intelligent and sophisticated and I have the desire to make your experience with me very memorable.<br>
                        My curves and DD bust are to die for and my sparkling blue eyes will captivate you leaving you breathless.
My service is of the highest standard and I’m also a qualified in therapeutic body rub if you feel the need to loosen those stressed tired muscles.<br>
                        <br>
                        I also do strip shows for private parties....eg, buck’s nights etc.<br>
                        price for parties by phone negotiation.<br>
                        I’m looking forward to your call so please don’t delay in calling me. Hugs and kisses Crystal Sienna
                    </p>
    --%>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12 xs-margin-15px-bottom wow fadeIn" data-wow-delay="0.2s">
                    <img id="img_about" runat="server" alt="" />
                </div>

            </div>
        </div>
    </section>

    <section class="wow fadeIn factsbackground quickfacts" id="quick_img" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-sm-4"></div>
                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12" id="quick_list" runat="server">
                </div>
            </div>
        </div>

    </section>

    <section class="wow fadeIn offerdemo" style="background: no-repeat center top;" id="offer_img" runat="server">
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

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
