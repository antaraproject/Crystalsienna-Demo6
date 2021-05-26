<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ProjectSix.forum.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
<!--    Supriyo CSS-->
    <style>
        
        @media (max-width: 425px){
            .margin-80px-bottom {
                 margin-bottom: 20px !important; 
            }
        }
        
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
                        <h1 class="alt-font text-white font-weight-600 no-margin-bottom">My Forum</h1>
                        <!-- end page title -->
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section>
        <div class="container-fluid padding-five-lr sm-padding-25px-lr xs-padding-15px-lr">

            <div class="col-md-12">

                <h5 class="text-uppercase text-center alt-font text-extra-dark-gray margin-80px-bottom font-weight-700 sm-width-100 xs-width-100">My Forum</h5>

            </div>


            <div class="row">
                <main class="col-md-9 col-sm-12 col-xs-12 right-sidebar sm-margin-60px-bottom xs-margin-40px-bottom sm-padding-15px-lr" id="forum_list" runat="server">
                </main>
                <aside class="col-md-3">
                    <div class="display-inline-block width-100 margin-45px-bottom xs-margin-25px-bottom">
                        
                            <div class="position-relative">
                                <input type="text" id="txt_search" runat="server" class="bg-transparent text-small no-margin border-color-extra-light-gray medium-input pull-left" placeholder="Enter your keywords...">
                                <button type="submit" class="bg-transparent  btn position-absolute right-0 top-1" runat="server" onserverclick="btn_Search_click"><i class="fas fa-search no-margin-left"></i></button>
                            </div>
                        
                    </div>




                    <div class="margin-45px-bottom xs-margin-25px-bottom">
                        <div class="text-extra-dark-gray margin-20px-bottom alt-font text-uppercase font-weight-600 text-small aside-title"><span>Categories</span></div>
                        <ul class="list-style-6 margin-50px-bottom text-small" id="forum_cat_list" runat="server">
                        </ul>
                    </div>



                    <div>
                    </div>
                </aside>
            </div>
        </div>
    </section>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
