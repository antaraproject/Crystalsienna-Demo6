<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="offer.aspx.cs"
    EnableEventValidation="false" ValidateRequest="false" Inherits="ProjectSix.admin.master.offer" %>

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
    <i class="icon-home2 mr-2"></i>Offer Page
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_MainBody" runat="server">
    <div class="content" style="min-height: 10px;">
        <ul id="fbAdd" class="fab-menu fab-menu-fixed fab-menu-bottom-right">
            <li><a id="A2" href="#" class="fab-menu-btn btn bg-green btn-float rounded-round btn-icon" runat="server" onserverclick="btn_Add_Click"><i
                class="fab-icon-open icon-plus3"></i><i class="fab-icon-close icon-cross2"></i></a></li>
        </ul>
        <div id="tab1" class="card">
            <div class="card-body">
                <asp:GridView ID="gvDtlsOffer" runat="server" class="table table-hover table-bordered table-striped" AutoGenerateColumns="False"
                    EmptyDataText="No data found." DataKeyNames="DTLS_OFFER_KEY" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Sr. No">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="OFFER_NAME" HeaderText="Offer Name">
                            <HeaderStyle Width="20%" HorizontalAlign="Center" />
                            <ItemStyle Width="20%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="OFFER_PER" HeaderText="Percentage">
                            <HeaderStyle Width="45%" HorizontalAlign="Center" />
                            <ItemStyle Width="45%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="OFFER_NOTE" HeaderText="Note">
                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                            <ItemStyle Width="15%" />
                        </asp:BoundField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Edit">
                            <ItemTemplate>
                                <div style="width: 90%; white-space: nowrap;">
                                    <a id="A1" href="#" class="list-icons-item" runat="server" onserverclick="btn_Edit_Click"><i class="icon-menu9"></i></a>
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
        <ul id="tabsmenu" class="tabsmenu" style="display: none">
            <li class="active"><a id="atab1" href="#tab1">List</a></li>
            <li><a id="atab2" href="#tab2">Add / Edit</a></li>
            <li><a id="aPageName" runat="server" href="#" style="margin: 0 5px 0 33%; border-radius: 6px;">&nbsp;</a></li>
        </ul>
        <div id="tab2" class="card" style="display: none">
            <div>
                <asp:HiddenField ID="hf_OFFER_IMG" runat="server" Value="" />
                <asp:HiddenField ID="hf_DTLS_OFFER_KEY" runat="server" Value="0" />
            </div>
            <div class="card">
                <div class="card-body">
                    <div class="col-md-12">
                        <fieldset>
                            <legend class="font-weight-semibold">Offer Section</legend>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>
                                                Offer Name</label>
                                            <asp:TextBox ID="txt_OFFER_NAME" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>
                                                Offer Percentage</label>
                                            <asp:TextBox ID="txt_OFFER_PER" TextMode="MultiLine" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>
                                                Offer Note</label>
                                            <asp:TextBox ID="txt_OFFER_NOTE" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <fieldset>
                                        <legend>Offer Image</legend>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label>
                                                        Upload Picture (Accepted Format .png, .jpg, .jpeg only. Max size 2 MB)
                                                    </label>
                                                    <asp:FileUpload ID="fu_Offer" runat="server" class="form-input-styled" data-fouc accept=".gif, .png, .jpg, .jpeg" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-8 ml-auto mr-auto">
                                                <img id="img_offer" src="../assets/images/no_image.jpg" class="form-control preview" runat="server" />
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>
                              <%--  <div class="col-md-12">
                                    <div class="form-group">
                                        <label>
                                            Offer Description</label>
                                        <asp:TextBox ID="txt_OFFER_DESC" CssClass="summernote" TextMode="MultiLine" Rows="2" runat="server"></asp:TextBox>
                                    </div>
                                </div>--%>
                            </div>
                        </fieldset>
                    </div>
                </div>
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-md-12 text-center">
                        <asp:Button ID="btn_Head_Save" runat="server" Text="Submit" CssClass="mb-xs mt-xs btn btn-success" ToolTip="Submit" OnClick="btn_Head_Save_Click" />
                        <asp:Button ID="btn_Back_Save" runat="server" Text="Back" CssClass="mb-xs mt-xs mr-xs btn btn-warning" ToolTip="Back" OnClick="btn_Back_Click" />
                    </div>
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
            setDatatable("<%=gvDtlsOffer.ClientID %>");
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

        <%--$("#<%=txt_OFFER_DATE.ClientID %>").datepicker({
            dateFormat: 'dd/mm/yy',
            showOn: "button",
            buttonImage: "../assets/images/calendar.png",
            buttonImageOnly: true,
            changeMonth: true,
            changeYear: true
        });--%>

        $(document).ready(function () {

            $('.form-input-styled').uniform({
                fileButtonClass: 'action btn bg-pink-400'
            });
            <%--$("#<%=txt_OFFER_DESC.ClientID %>").summernote({
                height: 180,
                codemirror: { "theme": "ambiance" }
            });

            $("#<%=txt_OFFER_DESC.ClientID %>").on('summernote.blur', function () {
                $("#<%=txt_OFFER_DESC.ClientID %>").html($("#<%=txt_OFFER_DESC.ClientID %>").summernote('code'));
            });--%>

            $("#<%=fu_Offer.ClientID %>").on("change", function (evt) {
                var tgt = evt.target || window.event.srcElement, files = tgt.files;
                if (files.length > 0) {
                    if (files[0].size > 20097134) {
                        $(this).val("");
                        $(this).next(".filename").text("No file selected");
                        $('#<%=img_offer.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/admin/assets/images/no_image.jpg")%>");
                        $(this).focus();
                        openErrorPopup("Please maintain allowed document size (20MB maximum).");
                    }
                    else {
                        readURL(this, $('#<%=img_offer.ClientID %>'));
                    }
                }
                else {
                    $('#<%=img_offer.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/admin/assets/images/no_image.jpg")%>");
                }
            });

            $('#loadingMask').fadeOut();
        });
    </script>
</asp:Content>
