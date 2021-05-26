<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ProjectSix.diary_details.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <section class="wow fadeIn cover-background background-position-top top-space" id="header_img" runat="server">
        <div class="opacity-medium bg-extra-dark-gray"></div>
        <div class="container">
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12 display-table page-title-large">
                    <div class="display-table-cell vertical-align-middle text-center padding-30px-tb">
                        <h1 class="alt-font text-white font-weight-600 no-margin-bottom">Testimonials</h1>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="wow fadeIn animated bg-light-gray diary">
        <div class="container-fluid">
            <div class="row no-gutters">
                <div class="col-md-9">
                    <div class="testimonialleft" id="diary_main" runat="server">
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="testimonialright" id="side_content" runat="server">
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
