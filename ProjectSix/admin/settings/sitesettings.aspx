<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="sitesettings.aspx.cs" Inherits="ProjectSix.admin.settings.sitesettings" %>

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

        .preview_icon {
            height: 120px;
            width: 150px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_FormName" runat="server">
    <i class="icon-home2 mr-2"></i>Site Settings
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_MainBody" runat="server">
    <div>
        <asp:HiddenField ID="hf_LOGO_NAME" runat="server" Value="" />
        <asp:HiddenField ID="hf_ICON_IMG" runat="server" Value="" />
        <asp:HiddenField ID="hf_HEADER_IMG" runat="server" Value="" />
        <asp:HiddenField ID="hf_FOOTER_IMG" runat="server" Value="" />
        <asp:HiddenField ID="hf_DTLS_USEFULL_LINKS_KEY" runat="server" Value="0" />
        <asp:HiddenField ID="hf_DTLS_PAGE_SETTING_KEY" runat="server" Value="0" />
    </div>
    <div class="card">
        <div class="card-body">
            <div class="col-md-12">
                <fieldset>
                    <legend class="font-weight-semibold">Basic Informations</legend>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>
                                    Contact No</label>
                                <asp:TextBox ID="txt_CONTACT_NO" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>
                                    Contact Mail</label>
                                <asp:TextBox ID="txt_MAIL" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>
                                    Address/Location
                                </label>
                                <asp:TextBox ID="txt_ADDRESS" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>
                                    Facebook Link</label>
                                <asp:TextBox ID="txt_FACEBOOK_LINK" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>
                                    Twitter Link</label>
                                <asp:TextBox ID="txt_TWITTER_LINK" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>
                                    Linkedin Link</label>
                                <asp:TextBox ID="txt_LINKEDIN_LINK" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <fieldset>
                                <legend>Page Settings</legend>
                                <div class="row">
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>
                                                Select Page
                                            </label>
                                            <asp:DropDownList ID="ddl_MAST_PAGE_KEY" runat="server" CssClass="form-control populate"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>
                                                Page Title
                                            </label>
                                            <asp:TextBox ID="txt_PAGE_TITLE" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>
                                                Meta Description
                                            </label>
                                            <asp:TextBox ID="txt_META_DESCRIPTION" class="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>
                                                Meta Keyword
                                            </label>
                                            <asp:TextBox ID="txt_META_KEYWORD" class="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>
                                                &nbsp;</label>
                                            <asp:Button ID="btn_Page_Settings_Save" runat="server" Text="Save" CssClass="btn btn-primary form-control" OnClick="btn_Page_Settings_Save_Click" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-12">
                                        <div class="table-responsive">
                                            <asp:GridView ID="gvPageSetting" runat="server" class="table table-bordered table-sm table-hover" AutoGenerateColumns="False"
                                                EmptyDataText="No data found." DataKeyNames="DTLS_PAGE_SETTING_KEY">
                                                <Columns>
                                                    <asp:BoundField DataField="PAGE_NAME" HeaderText="Page Name">
                                                        <HeaderStyle Width="20%" HorizontalAlign="Center" />
                                                        <ItemStyle Width="20%" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="PAGE_TITLE" HeaderText="Page Title">
                                                        <HeaderStyle Width="20%" HorizontalAlign="Center" />
                                                        <ItemStyle Width="20%" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="META_DESCRIPTION" HeaderText="Meta Description">
                                                        <HeaderStyle Width="25%" HorizontalAlign="Center" />
                                                        <ItemStyle Width="25%" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="META_KEYWORD" HeaderText="Meta Keyword">
                                                        <HeaderStyle Width="25%" HorizontalAlign="Center" />
                                                        <ItemStyle Width="25%" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <div style="width: 90%; white-space: nowrap;">
                                                                <a id="A1" href="#" class="list-icons-item" runat="server" onserverclick="btn_Page_Setting_Edit_Click"><i class="icon-menu9"></i></a>
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
                    <div class="row">
                        <div class="col-md-6">
                            <fieldset>
                                <legend>Logo</legend>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>
                                                Upload Logo (Accepted Format .png, .jpg, .jpeg only. Max size 2MB)
                                            </label>
                                            <asp:FileUpload ID="fu_Logo" runat="server" class="form-input-styled" data-fouc accept=".gif, .png, .jpg, .jpeg" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-8 ml-auto mr-auto">
                                        <img id="img_Logo" src="../assets/images/no_image.jpg" class="form-control preview" runat="server" />
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <div class="col-md-6" style="display:none;">
                            <fieldset>
                                <legend>Icon</legend>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>
                                                Upload Icon (Accepted Format .png and .jpg only. Max size 2MB)
                                            </label>
                                            <asp:FileUpload ID="fu_Icon" runat="server" class="form-input-styled" data-fouc accept=".gif, .png, .jpg, .jpeg" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-8 ml-auto mr-auto">
                                        <img id="img_Icon" src="../assets/images/no_image.jpg" class="form-control preview_icon" runat="server" />
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                    </div>


                    <div class="row">
                        <div class="col-md-6">
                            <fieldset>
                                <legend>Header Image</legend>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>
                                                Upload Header Image (Accepted Format .png, .jpg, .jpeg only. Max size 2MB)
                                            </label>
                                            <asp:FileUpload ID="fu_header" runat="server" class="form-input-styled" data-fouc accept=".gif, .png, .jpg, .jpeg" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-8 ml-auto mr-auto">
                                        <img id="img1" src="../assets/images/no_image.jpg" class="form-control preview" runat="server" />
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <div class="col-md-6">
                            <fieldset>
                                <legend>Footer Image</legend>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>
                                                Upload Footer Image (Accepted Format .png and .jpg only. Max size 2MB)
                                            </label>
                                            <asp:FileUpload ID="fu_footer" runat="server" class="form-input-styled" data-fouc accept=".gif, .png, .jpg, .jpeg" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-8 ml-auto mr-auto">
                                        <img id="img2" src="../assets/images/no_image.jpg" class="form-control preview" runat="server" />
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                    </div>

                </fieldset>
            </div>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-md-12 text-center">
                    <asp:Button ID="btn_Head_Save" runat="server" Text="Submit" CssClass="mb-xs mt-xs btn btn-success" ToolTip="Submit" OnClick="btn_Head_Save_Click" />
                </div>
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

        $(document).ready(function () {
            $('.form-input-styled').uniform({
                fileButtonClass: 'action btn bg-pink-400'
            });

            $("#<%=fu_Logo.ClientID %>").on("change", function (evt) {
                var tgt = evt.target || window.event.srcElement, files = tgt.files;
                if (files.length > 0) {
                    if (files[0].size > 2097134) {
                        $(this).val("");
                        $(this).next(".filename").text("No file selected");
                        $('#<%=img_Logo.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/admin/assets/images/no_image.jpg")%>");
                        $(this).focus();
                        openErrorPopup("Please maintain allowed document size (2MB maximum).");
                    }
                    else {
                        readURL(this, $('#<%=img_Logo.ClientID %>'));
                    }
                }
                else {
                    $('#<%=img_Logo.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/admin/assets/images/no_image.jpg")%>");
                }
            });



            $("#<%=fu_header.ClientID %>").on("change", function (evt) {
                var tgt = evt.target || window.event.srcElement, files = tgt.files;
                if (files.length > 0) {
                    if (files[0].size > 2097134) {
                        $(this).val("");
                        $(this).next(".filename").text("No file selected");
                        $('#<%=img1.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/admin/assets/images/no_image.jpg")%>");
                        $(this).focus();
                        openErrorPopup("Please maintain allowed document size (2MB maximum).");
                    }
                    else {
                        readURL(this, $('#<%=img1.ClientID %>'));
                    }
                }
                else {
                    $('#<%=img1.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/admin/assets/images/no_image.jpg")%>");
                }
            });

            $("#<%=fu_footer.ClientID %>").on("change", function (evt) {
                var tgt = evt.target || window.event.srcElement, files = tgt.files;
                if (files.length > 0) {
                    if (files[0].size > 2097134) {
                        $(this).val("");
                        $(this).next(".filename").text("No file selected");
                        $('#<%=img2.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/admin/assets/images/no_image.jpg")%>");
                        $(this).focus();
                        openErrorPopup("Please maintain allowed document size (2MB maximum).");
                    }
                    else {
                        readURL(this, $('#<%=img2.ClientID %>'));
                    }
                }
                else {
                    $('#<%=img2.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/admin/assets/images/no_image.jpg")%>");
                }
            });

            $("#<%=fu_Icon.ClientID %>").on("change", function (evt) {
                var tgt = evt.target || window.event.srcElement, files = tgt.files;
                if (files.length > 0) {
                    if (files[0].size > 2097134) {
                        $(this).val("");
                        $(this).next(".filename").text("No file selected");
                        $('#<%=img_Icon.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/admin/assets/images/no_image.jpg")%>");
                        $(this).focus();
                        openErrorPopup("Please maintain allowed document size (2MB maximum).");
                    }
                    else {
                        readURL(this, $('#<%=img_Icon.ClientID %>'));
                    }
                }
                else {
                    $('#<%=img_Icon.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/admin/assets/images/no_image.jpg")%>");
                }
            });

            $('#loadingMask').fadeOut();
        });
    </script>
</asp:Content>
