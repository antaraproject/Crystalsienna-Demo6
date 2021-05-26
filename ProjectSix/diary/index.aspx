<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ProjectSix.diary.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style>
        
        .es-diary h5, h6{
           text-align: center;
        }
        
        .es-diary h6{
            margin-bottom: 30px;
        }
        
        @media (max-width: 425px){
            .es-diary h6{
                margin-bottom: 0px !important;
            }
            
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
                        <h1 class="alt-font text-white font-weight-600 no-margin-bottom">Escort Diary</h1>
                        <!-- end page title -->
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="wow fadeIn diarydemo" id="diary_img" runat="server" style="background: no-repeat center top;">
        <div class="container no-padding">
            <div class="row equalize sm-equalize-auto no-margin es-diary">
                <h5 class="alt-font text-light-gray font-weight-600">Escort Diary</h5>
                <h6 class="font-weight-400  text-light-gray alt-font">You can have anything you want in life if you dress for it.</h6>
                <div class="col-md-6 col-sm-12 col-xs-12 display-table wow fadeIn">
                    <div class="display-table-cell-vertical-middle md-padding-ten-all sm-padding-six-all xs-padding-50px-tb xs-no-padding-lr" id="diary_list" runat="server">
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="wow fadeIn animated bg-light-gray">
        <div class="container">
            <div class="row text-center">
                <div class="col-md-12">
<!--                    <p class="alt-font text-medium-gray margin-5px-bottom text-uppercase text-small">what people says</p>-->
                    <h5 class="text-uppercase alt-font text-extra-dark-gray margin-20px-bottom font-weight-700 sm-width-100 xs-width-100">Testimonials</h5>
                    <span class="separator-line-horrizontal-medium-light2 bg-deep-pink display-table margin-auto width-100px"></span>
                </div>
            </div>
            <div class="row">
                <div class=" margin-100px-top sm-margin-70px-top sm-width-60 sm-center-col xs-width-100 xs-margin-50px-top" id="client_list" runat="server">
                </div>
            </div>
        </div>
    </section>

    <section class=" wow fadeIn diarydemo" id="news_img" runat="server" style="background: no-repeat center top;">
        <div class="container" >
                <div class="row">
                    <div class="col-md-12 text-center margin-100px-bottom sm-margin-70px-bottom xs-margin-50px-bottom">
                       
                        <h5 class="text-uppercase alt-font text-light-gray margin-20px-bottom font-weight-700 sm-width-100 xs-width-100">News & Announcements</h5>
                        <span class="separator-line-horrizontal-medium-light2 bg-deep-pink display-table margin-auto width-100px"></span>
                    </div> 
                </div>
                <div class="row">
                    <div class="col-md-12 no-padding xs-padding-15px-lr">
                        <ul class="blog-grid blog-3col gutter-large blog-post-style5" id="news_list" runat="server">
                        </ul>
                    </div>
                </div>
            </div>
    </section>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
