<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ProjectSix.tour.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>

        function show_modal() {
            $("#modal_default").css('display', 'block');
        }

        function close_modal() {
            $("#modal_default").css('display', 'none');
        }






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
        
      @media (max-width: 425px){
        .modal-header .close {
            color: inherit;
            margin: -1.25rem -1.25rem -1.25rem auto;
            position: relative;
            top: -70px !important;
        }
      }
        
      @media (max-width: 1440px){
        .inner-match-height {
            position: relative;
            height: auto;
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
                        <h1 class="alt-font text-white font-weight-600 no-margin-bottom">Tour</h1>
                        <!-- end page title -->
                    </div>
                </div>
            </div>
        </div>
    </section>


    <!--modal-->
       <div id="modal_default" class="modal" tabindex="-1" style="display: none; overflow:hidden;">
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



    <section class="wow fadeIn bg-extra-light-gray padding-80px-bottom padding-80px-top" id="services">
        <div class="container no-padding">
            <div class="row equalize sm-equalize-auto no-margin" id="prefer_list" runat="server">
            </div>
        </div>
    </section>

    <section class="wow fadeIn tourbackgrounddemo" id="tour_img" runat="server" style="background: no-repeat center top;">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12">
                    <!-- <div class="alt-font text-medium-gray margin-10px-bottom text-uppercase text-small">Our recent works</div>-->
                    <h5 class="alt-font text-light-gray font-weight-600">Tour</h5>
                    <p>Offering content producers the very best environment, showcasing world-class content. Powering your content with Artificial Intelligence and Machine Learning to our global audience.</p>


                    <h5 class="alt-font text-light-gray font-weight-600">Australian Tours</h5>
                    <p>I'm planning a potenical visit to Melb. Depending on amount of hours you'd desire to book me for</p>




                </div>

                <div class="col-sm-8" id="tour_list" runat="server">
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
</asp:Content>
