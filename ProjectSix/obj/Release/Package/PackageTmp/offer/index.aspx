<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ProjectSix.offer.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <section class="wow fadeIn cover-background background-position-top top-space" id="header_img" runat="server">
        <div class="opacity-medium bg-extra-dark-gray"></div>
        <div class="container">
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12 display-table page-title-large">
                    <div class="display-table-cell vertical-align-middle text-center padding-30px-tb">
                        <h1 class="alt-font text-white font-weight-600 no-margin-bottom">Special Offer</h1>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="wow fadeIn">
        <div class="container">
            <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 center-col margin-four-bottom text-center">

                    <h5 class="alt-font text-extra-dark-gray font-weight-600">What I Offer</h5>
                </div>
            </div>
        </div>
        <div class="container-fluid padding-five-lr">
            <div class="row no-margin">
                <div class="filter-content overflow-hidden" >
                    <ul class="portfolio-grid work-4col gutter-large hover-option7" id="offer_dtl" runat="server">
                        <li class="grid-sizer"></li>
                    </ul>
                </div>
            </div>
        </div>
    </section>

    <section class="wow fadeIn offerdemo" id="offer_img" runat="server" style="background: no-repeat center top;">
        <div class="container no-padding">
            <div class="row equalize sm-equalize-auto no-margin">
                <div class="col-sm-4"></div>
                <div class="col-sm-8">
                    <div class="offer">
                        <div class="offer_box">

                            <h4 class="font-weight-600 text-center text-uppercase">Get exciting offers</h4>
                            <h1 class="font-weight-600 text-center text-uppercase">50%</h1>
                            <a href="#" class="btn-danger btn btn-small button border-radius-4 margin-5px-all md-margin-15px-bottom sm-margin-lr-auto sm-display-table all">Discover Now <i class="ti-arrow-right"></i></a>

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
