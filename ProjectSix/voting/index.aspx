<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ProjectSix.voting.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    
    <!--    Supriyo CSS-->
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
                        <h1 class="alt-font text-white font-weight-600 no-margin-bottom">Image Voting</h1>
                        <!-- end page title -->
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

      <script>
          function useranswer(clicked_id) {




              var checking = document.getElementById(clicked_id).getAttribute('data-');
             // alert(checking);
          
             
              saveheadmenu(checking);

          }



          function saveheadmenu(values) {
              //$("#inputMenuName").val("");
              $.ajax({
                  url: '<%=ResolveUrl("~/voting/index.aspx/GetEvent") %>',
                  data: "{date1: '" + values +"'}",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d != 0) {

                        alert("Thank you for your feedback");
                        location.reload(); 
                    }
                    else {
                        alert("Please login");
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


</asp:Content>
