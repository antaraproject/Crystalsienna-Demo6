<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="bgimgsetting.aspx.cs" Inherits="ProjectFive.admin.settings.bgimgsetting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .filename {
            text-overflow: ellipsis;
            overflow: hidden;
            white-space: nowrap;
        }

        .preview {
            height: 230px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_FormName" runat="server">
    <i class="icon-home2 mr-2"></i>Background Image Settings
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_MainBody" runat="server">

    <div>
        <asp:HiddenField ID="hf_ABOUT_IMG" runat="server" Value="" />
        <asp:HiddenField ID="hf_TOUR_IMG" runat="server" Value="" />
        <asp:HiddenField ID="hf_QUICK_FACT_IMG" runat="server" Value="" />

        <asp:HiddenField ID="hf_PREFER_IMG" runat="server" Value="" />
        <asp:HiddenField ID="hf_GALLERY_IMG" runat="server" Value="" />
        <asp:HiddenField ID="hf_OFFER_IMG" runat="server" Value="" />

        <asp:HiddenField ID="hf_DIARY_IMG" runat="server" Value="" />
        <asp:HiddenField ID="hf_TESTIMONIALS_IMG" runat="server" Value="" />
        <asp:HiddenField ID="hf_SELFIE_IMG" runat="server" Value="" />

        <asp:HiddenField ID="hf_NEWS_IMG" runat="server" Value="" />
        <asp:HiddenField ID="hf_RATES_IMG" runat="server" Value="" />
        <asp:HiddenField ID="hf_AVAILABILITY_IMG" runat="server" Value="" />

        <asp:HiddenField ID="hf_CALENDER_IMG" runat="server" Value="" />
        <asp:HiddenField ID="hf_VOTING_IMG" runat="server" Value="" />
    </div>
    <div class="card">
        <div class="card-body">
            <div class="col-md-12">
                <fieldset>
                    <legend class="font-weight-semibold">Home Background Image Settings</legend>
                    <div class="row">
                        <div class="col-md-4" style="display: none;">
                            <fieldset>
                                <legend>Upload About Us Background Picture.</legend>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>
                                                About Us Background Picture (Accepted Format .png, .jpg, .jpeg only. Max size 20 MB)
                                            </label>
                                            <asp:FileUpload ID="fu_About" runat="server" class="form-input-styled" data-fouc accept=".gif, .png, .jpg, .jpeg" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-8 ml-auto mr-auto">
                                        <img id="img_About" src="../assets/images/no_image.jpg" class="form-control preview" runat="server" />
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <div class="col-md-6">
                            <fieldset>
                                <legend>Upload Tour Background Picture.</legend>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>
                                                Tour Background Picture (Accepted Format .png, .jpg, .jpeg only. Max size 20 MB)
                                            </label>
                                            <asp:FileUpload ID="fu_Tour" runat="server" class="form-input-styled" data-fouc accept=".gif, .png, .jpg, .jpeg" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-8 ml-auto mr-auto">
                                        <img id="img_Tour" src="../assets/images/no_image.jpg" class="form-control preview" runat="server" />
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <div class="col-md-6">
                            <fieldset>
                                <legend>Upload Quick facts Picture</legend>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>
                                                Quick facts Picture (Accepted Format .png, .jpg, .jpeg only. Max size 20 MB)
                                            </label>
                                            <asp:FileUpload ID="fu_Quick_Fact" runat="server" class="form-input-styled" data-fouc accept=".gif, .png, .jpg, .jpeg" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-8 ml-auto mr-auto">
                                        <img id="img_Quick_Facts" src="../assets/images/no_image.jpg" class="form-control preview" runat="server" />
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4" style="display: none;">
                            <fieldset>
                                <legend>Upload Prefer Background Picture.</legend>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>
                                                Prefer Background Picture (Accepted Format .png, .jpg, .jpeg only. Max size 20 MB)
                                            </label>
                                            <asp:FileUpload ID="fu_Prefer" runat="server" class="form-input-styled" data-fouc accept=".gif, .png, .jpg, .jpeg" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-8 ml-auto mr-auto">
                                        <img id="img_Prefer" src="../assets/images/no_image.jpg" class="form-control preview" runat="server" />
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <div class="col-md-6">
                            <fieldset>
                                <legend>Upload Gallery Background Picture.</legend>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>
                                                Gallery Background Picture (Accepted Format .png, .jpg, .jpeg only. Max size 20 MB)
                                            </label>
                                            <asp:FileUpload ID="fu_Gallery" runat="server" class="form-input-styled" data-fouc accept=".gif, .png, .jpg, .jpeg" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-8 ml-auto mr-auto">
                                        <img id="img_Gallery" src="../assets/images/no_image.jpg" class="form-control preview" runat="server" />
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <div class="col-md-6">
                            <fieldset>
                                <legend>Upload Offer Background Picture.</legend>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>
                                                Offer Background Picture (Accepted Format .png, .jpg, .jpeg only. Max size 20 MB)
                                            </label>
                                            <asp:FileUpload ID="fu_Offer" runat="server" class="form-input-styled" data-fouc accept=".gif, .png, .jpg, .jpeg" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-8 ml-auto mr-auto">
                                        <img id="img_Offer" src="../assets/images/no_image.jpg" class="form-control preview" runat="server" />
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <fieldset>
                                <legend>Upload Diary Background Picture.</legend>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>
                                                Diary Background Picture (Accepted Format .png, .jpg, .jpeg only. Max size 20 MB)
                                            </label>
                                            <asp:FileUpload ID="fu_Diary" runat="server" class="form-input-styled" data-fouc accept=".gif, .png, .jpg, .jpeg" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-8 ml-auto mr-auto">
                                        <img id="img_Diary" src="../assets/images/no_image.jpg" class="form-control preview" runat="server" />
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <div class="col-md-4" style="display:none;">
                            <fieldset>
                                <legend>Upload Testimonials Background Picture.</legend>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>
                                                Testimonials Background Picture (Accepted Format .png, .jpg, .jpeg only. Max size 20 MB)
                                            </label>
                                            <asp:FileUpload ID="fu_Testimonials" runat="server" class="form-input-styled" data-fouc accept=".gif, .png, .jpg, .jpeg" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-8 ml-auto mr-auto">
                                        <img id="img_Testimonials" src="../assets/images/no_image.jpg" class="form-control preview" runat="server" />
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <div class="col-md-4" style="display:none;">
                            <fieldset>
                                <legend>Upload Selfie Background Picture.</legend>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>
                                                Selfie Background Picture (Accepted Format .png, .jpg, .jpeg only. Max size 20 MB)
                                            </label>
                                            <asp:FileUpload ID="fu_Selfie" runat="server" class="form-input-styled" data-fouc accept=".gif, .png, .jpg, .jpeg" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-8 ml-auto mr-auto">
                                        <img id="img_Selfie" src="../assets/images/no_image.jpg" class="form-control preview" runat="server" />
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <div class="col-md-6">
                            <fieldset>
                                <legend>Upload News & Announcements Background Picture.</legend>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>
                                                News & Announcements Background Picture (Accepted Format Max size 20 MB)
                                            </label>
                                            <asp:FileUpload ID="fu_News" runat="server" class="form-input-styled" data-fouc accept=".gif, .png, .jpg, .jpeg" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-8 ml-auto mr-auto">
                                        <img id="img_News" src="../assets/images/no_image.jpg" class="form-control preview" runat="server" />
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                    </div>


                    <div class="row">
                        <div class="col-md-6">
                            <fieldset>
                                <legend>Upload Rates Background Picture.</legend>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>
                                                Rates Background Picture (Accepted Format .png, .jpg, .jpeg only. Max size 20 MB)
                                            </label>
                                            <asp:FileUpload ID="fu_Rates" runat="server" class="form-input-styled" data-fouc accept=".gif, .png, .jpg, .jpeg" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-8 ml-auto mr-auto">
                                        <img id="img_Rates" src="../assets/images/no_image.jpg" class="form-control preview" runat="server" />
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <div class="col-md-4"  style="display:none;">
                            <fieldset>
                                <legend>Upload Availability Background Picture.</legend>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>
                                                Availability Background Picture (Accepted Format .png, .jpg, .jpeg only. Max size 20 MB)
                                            </label>
                                            <asp:FileUpload ID="fu_Availability" runat="server" class="form-input-styled" data-fouc accept=".gif, .png, .jpg, .jpeg" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-8 ml-auto mr-auto">
                                        <img id="img_Availability" src="../assets/images/no_image.jpg" class="form-control preview" runat="server" />
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <div class="col-md-6">
                            <fieldset>
                                <legend>Upload Calender Background Picture.</legend>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>
                                                Calender Background Picture (Accepted Format .png, .jpg, .jpeg only. Max size 20 MB)
                                            </label>
                                            <asp:FileUpload ID="fu_Calender" runat="server" class="form-input-styled" data-fouc accept=".gif, .png, .jpg, .jpeg" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-8 ml-auto mr-auto">
                                        <img id="img_Calender" src="../assets/images/no_image.jpg" class="form-control preview" runat="server" />
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                    </div>

                    <div class="row"  style="display:none;">
                        <div class="col-md-4">
                            <fieldset>
                                <legend>Upload Image Voting Background Picture.</legend>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>
                                                Image Voting Background Picture (Accepted Format .png, .jpg, .jpeg only. Max size 20 MB)
                                            </label>
                                            <asp:FileUpload ID="fu_Img_Voting" runat="server" class="form-input-styled" data-fouc accept=".gif, .png, .jpg, .jpeg" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-8 ml-auto mr-auto">
                                        <img id="img_Voting" src="../assets/images/no_image.jpg" class="form-control preview" runat="server" />
                                    </div>
                                </div>
                            </fieldset>
                        </div>


                    </div>
                </fieldset>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 text-center">
                <asp:Button ID="btn_Head_Save" runat="server" Text="Submit" CssClass="mb-xs mt-xs btn btn-success" ToolTip="Submit" OnClick="btn_Head_Save_Click" />
            </div>
        </div>
        <div style="height: 50px"></div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_Scripts" runat="server">
    <script type="text/javascript">

        function OpenTab1(strMsg, error) {
            $("#tab1").fadeIn();
            $("#tab3").hide();
            $("#tab2").hide();

            if ($.trim(strMsg) != '') {
                if (error == 1)
                    openErrorPopup(strMsg);
                else
                    openSuccessPopup(strMsg);
            }
        }

        function OpenTab2(strMsg, error) {
            $("#tab1").hide();
            $("#tab3").hide();
            $("#tab2").fadeIn();
            if ($.trim(strMsg) != '') {
                if (error == 1)
                    openErrorPopup(strMsg);
                else
                    openSuccessPopup(strMsg);
            }
        }

        function OpenTab3(strMsg, error) {
            $("#tab1").hide();
            $("#tab3").fadeIn();
            $("#tab2").hide();

            if ($.trim(strMsg) != '') {
                if (error == 1)
                    openErrorPopup(strMsg);
                else
                    openSuccessPopup(strMsg);
            }
        }

        $(document).ready(function () {

            $('.form-input-styled').uniform({
                fileButtonClass: 'action btn bg-pink-400'
            });

            $("#<%=fu_About.ClientID %>").on("change", function (evt) {
                var tgt = evt.target || window.event.srcElement, files = tgt.files;
                if (files.length > 0) {
                    if (files[0].size > 20097134) {
                        $(this).val("");
                        $(this).next(".filename").text("No file selected");
                        $('#<%=img_About.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/assets/images/no_image.jpg")%>");
                        $(this).focus();
                        openErrorPopup("Please maintain allowed document size (20MB maximum).");
                    }
                    else {
                        readURL(this, $('#<%=img_About.ClientID %>'));
                    }
                }
                else {
                    $('#<%=img_About.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/assets/images/no_image.jpg")%>");
                }
            });

            $("#<%=fu_Tour.ClientID %>").on("change", function (evt) {
                var tgt = evt.target || window.event.srcElement, files = tgt.files;
                if (files.length > 0) {
                    if (files[0].size > 20097134) {
                        $(this).val("");
                        $(this).next(".filename").text("No file selected");
                        $('#<%=img_Tour.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/assets/images/no_image.jpg")%>");
                        $(this).focus();
                        openErrorPopup("Please maintain allowed document size (20MB maximum).");
                    }
                    else {
                        readURL(this, $('#<%=img_Tour.ClientID %>'));
                    }
                }
                else {
                    $('#<%=img_Tour.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/assets/images/no_image.jpg")%>");
                }
            });

            $("#<%=fu_Quick_Fact.ClientID %>").on("change", function (evt) {
                var tgt = evt.target || window.event.srcElement, files = tgt.files;
                if (files.length > 0) {
                    if (files[0].size > 20097134) {
                        $(this).val("");
                        $(this).next(".filename").text("No file selected");
                        $('#<%=img_Quick_Facts.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/assets/images/no_image.jpg")%>");
                        $(this).focus();
                        openErrorPopup("Please maintain allowed document size (20MB maximum).");
                    }
                    else {
                        readURL(this, $('#<%=img_Quick_Facts.ClientID %>'));
                    }
                }
                else {
                    $('#<%=img_Quick_Facts.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/assets/images/no_image.jpg")%>");
                }
            });

            $("#<%=fu_Prefer.ClientID %>").on("change", function (evt) {
                var tgt = evt.target || window.event.srcElement, files = tgt.files;
                if (files.length > 0) {
                    if (files[0].size > 20097134) {
                        $(this).val("");
                        $(this).next(".filename").text("No file selected");
                        $('#<%=img_Prefer.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/assets/images/no_image.jpg")%>");
                        $(this).focus();
                        openErrorPopup("Please maintain allowed document size (20MB maximum).");
                    }
                    else {
                        readURL(this, $('#<%=img_Prefer.ClientID %>'));
                    }
                }
                else {
                    $('#<%=img_Prefer.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/assets/images/no_image.jpg")%>");
                }
            });

            $("#<%=fu_Gallery.ClientID %>").on("change", function (evt) {
                var tgt = evt.target || window.event.srcElement, files = tgt.files;
                if (files.length > 0) {
                    if (files[0].size > 20097134) {
                        $(this).val("");
                        $(this).next(".filename").text("No file selected");
                        $('#<%=img_Gallery.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/assets/images/no_image.jpg")%>");
                        $(this).focus();
                        openErrorPopup("Please maintain allowed document size (20MB maximum).");
                    }
                    else {
                        readURL(this, $('#<%=img_Gallery.ClientID %>'));
                    }
                }
                else {
                    $('#<%=img_Gallery.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/assets/images/no_image.jpg")%>");
                }
            });


            $("#<%=fu_Offer.ClientID %>").on("change", function (evt) {
                var tgt = evt.target || window.event.srcElement, files = tgt.files;
                if (files.length > 0) {
                    if (files[0].size > 20097134) {
                        $(this).val("");
                        $(this).next(".filename").text("No file selected");
                        $('#<%=img_Offer.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/assets/images/no_image.jpg")%>");
                        $(this).focus();
                        openErrorPopup("Please maintain allowed document size (20MB maximum).");
                    }
                    else {
                        readURL(this, $('#<%=img_Offer.ClientID %>'));
                    }
                }
                else {
                    $('#<%=img_Offer.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/assets/images/no_image.jpg")%>");
                }
            });


            $("#<%=fu_Diary.ClientID %>").on("change", function (evt) {
                var tgt = evt.target || window.event.srcElement, files = tgt.files;
                if (files.length > 0) {
                    if (files[0].size > 20097134) {
                        $(this).val("");
                        $(this).next(".filename").text("No file selected");
                        $('#<%=img_Diary.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/assets/images/no_image.jpg")%>");
                        $(this).focus();
                        openErrorPopup("Please maintain allowed document size (20MB maximum).");
                    }
                    else {
                        readURL(this, $('#<%=img_Diary.ClientID %>'));
                    }
                }
                else {
                    $('#<%=img_Diary.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/assets/images/no_image.jpg")%>");
                }
            });

            $("#<%=fu_Testimonials.ClientID %>").on("change", function (evt) {
                var tgt = evt.target || window.event.srcElement, files = tgt.files;
                if (files.length > 0) {
                    if (files[0].size > 20097134) {
                        $(this).val("");
                        $(this).next(".filename").text("No file selected");
                        $('#<%=img_Testimonials.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/assets/images/no_image.jpg")%>");
                        $(this).focus();
                        openErrorPopup("Please maintain allowed document size (20MB maximum).");
                    }
                    else {
                        readURL(this, $('#<%=img_Testimonials.ClientID %>'));
                    }
                }
                else {
                    $('#<%=img_Testimonials.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/assets/images/no_image.jpg")%>");
                }
            });

            $("#<%=fu_Selfie.ClientID %>").on("change", function (evt) {
                var tgt = evt.target || window.event.srcElement, files = tgt.files;
                if (files.length > 0) {
                    if (files[0].size > 20097134) {
                        $(this).val("");
                        $(this).next(".filename").text("No file selected");
                        $('#<%=img_Selfie.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/assets/images/no_image.jpg")%>");
                        $(this).focus();
                        openErrorPopup("Please maintain allowed document size (20MB maximum).");
                    }
                    else {
                        readURL(this, $('#<%=img_Selfie.ClientID %>'));
                    }
                }
                else {
                    $('#<%=img_Selfie.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/assets/images/no_image.jpg")%>");
                }
            });

            $("#<%=fu_News.ClientID %>").on("change", function (evt) {
                var tgt = evt.target || window.event.srcElement, files = tgt.files;
                if (files.length > 0) {
                    if (files[0].size > 20097134) {
                        $(this).val("");
                        $(this).next(".filename").text("No file selected");
                        $('#<%=img_News.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/assets/images/no_image.jpg")%>");
                        $(this).focus();
                        openErrorPopup("Please maintain allowed document size (20MB maximum).");
                    }
                    else {
                        readURL(this, $('#<%=img_News.ClientID %>'));
                    }
                }
                else {
                    $('#<%=img_News.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/assets/images/no_image.jpg")%>");
                }
            });


            $("#<%=fu_Rates.ClientID %>").on("change", function (evt) {
                var tgt = evt.target || window.event.srcElement, files = tgt.files;
                if (files.length > 0) {
                    if (files[0].size > 20097134) {
                        $(this).val("");
                        $(this).next(".filename").text("No file selected");
                        $('#<%=img_Rates.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/assets/images/no_image.jpg")%>");
                        $(this).focus();
                        openErrorPopup("Please maintain allowed document size (20MB maximum).");
                    }
                    else {
                        readURL(this, $('#<%=img_Rates.ClientID %>'));
                    }
                }
                else {
                    $('#<%=img_Rates.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/assets/images/no_image.jpg")%>");
                }
            });



            $("#<%=fu_Availability.ClientID %>").on("change", function (evt) {
                var tgt = evt.target || window.event.srcElement, files = tgt.files;
                if (files.length > 0) {
                    if (files[0].size > 20097134) {
                        $(this).val("");
                        $(this).next(".filename").text("No file selected");
                        $('#<%=img_Availability.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/assets/images/no_image.jpg")%>");
                        $(this).focus();
                        openErrorPopup("Please maintain allowed document size (20MB maximum).");
                    }
                    else {
                        readURL(this, $('#<%=img_Availability.ClientID %>'));
                    }
                }
                else {
                    $('#<%=img_Availability.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/assets/images/no_image.jpg")%>");
                }
            });


            $("#<%=fu_Calender.ClientID %>").on("change", function (evt) {
                var tgt = evt.target || window.event.srcElement, files = tgt.files;
                if (files.length > 0) {
                    if (files[0].size > 20097134) {
                        $(this).val("");
                        $(this).next(".filename").text("No file selected");
                        $('#<%=img_Calender.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/assets/images/no_image.jpg")%>");
                        $(this).focus();
                        openErrorPopup("Please maintain allowed document size (20MB maximum).");
                    }
                    else {
                        readURL(this, $('#<%=img_Calender.ClientID %>'));
                    }
                }
                else {
                    $('#<%=img_Calender.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/assets/images/no_image.jpg")%>");
                }
            });

            $("#<%=fu_Img_Voting.ClientID %>").on("change", function (evt) {
                var tgt = evt.target || window.event.srcElement, files = tgt.files;
                if (files.length > 0) {
                    if (files[0].size > 20097134) {
                        $(this).val("");
                        $(this).next(".filename").text("No file selected");
                        $('#<%=img_Voting.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/assets/images/no_image.jpg")%>");
                        $(this).focus();
                        openErrorPopup("Please maintain allowed document size (20MB maximum).");
                    }
                    else {
                        readURL(this, $('#<%=img_Voting.ClientID %>'));
                    }
                }
                else {
                    $('#<%=img_Voting.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/assets/images/no_image.jpg")%>");
                }
            });

            $('#loadingMask').fadeOut();
        });
    </script>
</asp:Content>
