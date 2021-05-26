<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="homesettings.aspx.cs" Inherits="ProjectSix.admin.settings.homesettings"
    EnableEventValidation="false" ValidateRequest="false" %>

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
    <i class="icon-home2 mr-2"></i>Home Settings
    <style type="text/css">
        .modal {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 100; /* Sit on top */
            padding-top: 100px; /* Location of the box */
            left: 0;
            top: 23px;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.73); /* Black w/ opacity */
        }

        .modal-content {
            margin: auto;
            margin-bottom: 10%;
            display: block;
            width: 32%;
            max-width: 800px;
        }

        .modal-content {
            -webkit-animation-name: zoom;
            -webkit-animation-duration: 0.6s;
            animation-name: zoom;
            animation-duration: 0.6s;
        }

        @-webkit-keyframes zoom {
            from {
                -webkit-transform: scale(0)
            }

            to {
                -webkit-transform: scale(1)
            }
        }

        @keyframes zoom {
            from {
                transform: scale(0)
            }

            to {
                transform: scale(1)
            }
        }

        .close {
            position: absolute;
            top: 15px;
            right: 35px;
            color: #f1f1f1;
            font-size: 40px;
            font-weight: bold;
            transition: 0.3s;
        }

            .close:hover,
            .close:focus {
                color: #bbb;
                text-decoration: none;
                cursor: pointer;
            }

        @media only screen and (max-width: 700px) {
            .modal-content {
                width: 90%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_MainBody" runat="server">
    <div id="myModal" runat="server" class="modal">
        <span class="close">&times;</span>
    </div>
    <div>
        <asp:HiddenField ID="hf_OFFER_IMG" runat="server" Value="" />
        <asp:HiddenField ID="hf_BANNER_IMG" runat="server" Value="" />
        <asp:HiddenField ID="hf_ABOUT_IMG" runat="server" Value="" />
        <asp:HiddenField ID="hf_QUICK_FACT_IMG" runat="server" Value="" />
        <asp:HiddenField ID="hf_DTLS_QUICK_FACT_KEY" runat="server" Value="0" />
        <asp:HiddenField ID="hf_MAST_SCHEDULE_KEY" runat="server" Value="0" />
        <asp:HiddenField ID="hf_USER_KEY" runat="server" Value="0" />
    </div>
    <div class="card">
        <div class="card-body">
            <div class="col-md-12">
                <fieldset>
                    <legend class="font-weight-semibold">Home  & About Me Settings</legend>
                    <div class="row">
                        <div class="col-md-6">
                            <fieldset>
                                <legend>Upload Offer Picture.</legend>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>
                                                Offer Picture (Accepted Format .png, .jpg, .jpeg only. Max size 20 MB)
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
                        <div class="col-md-6">
                            <fieldset>
                                <legend>Upload About Me Picture.</legend>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>
                                               About Me Picture (Accepted Format .png, .jpg, .jpeg only. Max size 20 MB)
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
                        <div class="col-md-4" style="display:none;">
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
                        <div class="col-md-6">
                            <fieldset>
                                <legend>Upload Banner Multiple Picture.</legend>
                                <div class="row">
                                    <div class="col-md-10">
                                        <div class="form-group">
                                            <asp:FileUpload ID="fu_Banner" runat="server" AllowMultiple="true" class="form-input-styled" data-fouc accept=".gif, .png, .jpg, .jpeg, .webp, .bmp" />
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <input type="button" id="Banner_View" class="btn btn-primary form-control" value="View" />
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                            <div class="row">
                                <div class="col-md-12">
                                    <fieldset>
                                        <legend>Quick Facts</legend>
                                        <div class="row">
                                            <div class="col-md-10">
                                                <div class="form-group">
                                                    <label>
                                                        Facts Name
                                                    </label>
                                                    <asp:TextBox ID="txt_QUICK_FACT_NAME" class="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-10">
                                                <div class="form-group">
                                                    <label>
                                                        Facts Description
                                                    </label>
                                                    <asp:TextBox ID="txt_QUICK_FACT" class="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-2">
                                                <div class="form-group">
                                                    <label>
                                                        &nbsp;</label>
                                                    <asp:Button ID="btn_Quick_Save" runat="server" Text="Save" CssClass="btn btn-primary form-control" OnClick="btn_Quick_Save_Click" /><%----%>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-12">
                                                <div class="table-responsive">
                                                    <asp:GridView ID="gvDtlsQuickFact" runat="server" class="table table-bordered table-sm table-hover" AutoGenerateColumns="False"
                                                        EmptyDataText="No data found." DataKeyNames="DTLS_QUICK_FACT_KEY">
                                                        <Columns>
                                                            <asp:BoundField DataField="QUICK_FACT_NAME" HeaderText="Fact Name">
                                                                <HeaderStyle Width="25%" HorizontalAlign="Center" />
                                                                <ItemStyle Width="25%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="QUICK_FACT_DESC" HeaderText="Fact Desc">
                                                                <HeaderStyle Width="25%" HorizontalAlign="Center" />
                                                                <ItemStyle Width="25%" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Edit">
                                                                <ItemTemplate>
                                                                    <div style="width: 90%; white-space: nowrap;">
                                                                        <a id="A1" href="#" class="list-icons-item" runat="server" onserverclick="btn_Quick_Edit_Click"><i class="icon-menu9"></i></a><%----%>
                                                                    </div>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <div style="width: 90%; white-space: nowrap;">
                                                                        <a id="A2" href="#" class="list-icons-item" runat="server" onserverclick="btn_Delete_Click"><i class="icon-trash"></i></a>
                                                                    </div>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>
                                            About Me</label>
                                        <asp:TextBox ID="txt_ABOUT_DESC" TextMode="multiline" Rows="2" CssClass="summernote" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 text-center">
                <asp:Button ID="btn_Head_Save" runat="server" Text="Submit" CssClass="mb-xs mt-xs btn btn-success" ToolTip="Submit" OnClick="btn_Head_Save_Click" /><%----%>
            </div>
        </div>
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

        function readURLhf(input) {
            if (input.files) {
                var filesAmount = input.files.length;
                for (i = 0; i < filesAmount; i++) {
                    var reader = new FileReader();
                    reader.onload = function (event) {
                        $("#<%=myModal.ClientID %>").append($($.parseHTML('<img>')).attr('src', event.target.result).addClass("modal-content"));
                    }
                    reader.readAsDataURL(input.files[i]);
                }
            }
        }

        $(document).ready(function () {

            $('.form-input-styled').uniform({
                fileButtonClass: 'action btn bg-pink-400'
            });

            $("#<%=txt_ABOUT_DESC.ClientID %>").summernote({
                height: 180,
                codemirror: { "theme": "ambiance" }


            });

            $("#<%=txt_ABOUT_DESC.ClientID %>").on('summernote.blur', function () {
                $("#<%=txt_ABOUT_DESC.ClientID %>").html($("#<%=txt_ABOUT_DESC.ClientID %>").summernote('code'));
            });


            $('#<%=fu_Banner.ClientID %>').change(function (evt) {
                $(".modal-content").remove();
                var fileno = this.files.length;
                var tgt = evt.target || window.event.srcElement, files = tgt.files;
                var ret = 0;
                for (i = 0; i < fileno; i++) {
                    if (files[i].size > 20097134) {
                        OpenErrPopup("Please maintain size (20MB maximum) in Image : " + (i + 1));
                        ret = 1;
                    }
                }
                if (ret == 1) {
                    $('#<%=fu_Banner.ClientID %>').val("");
                } else {
                    readURLhf(this);
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


            $("#Banner_View").click(function () {
                $("#<%=myModal.ClientID %>").css('display', 'block');
                return false;
            });

            $('.close').click(function () {
                $("#<%=myModal.ClientID %>").css('display', 'none');
                return false;
            });

            $('#loadingMask').fadeOut();
        });

        $(document).keydown(function (e) {
            if (e.keyCode == 27) { //Escape key maps to keycode `27`
                $("#<%=myModal.ClientID %>").css('display', 'none');
                return false;
            }
        });
    </script>
</asp:Content>
