<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="rate.aspx.cs"
    EnableEventValidation="false" ValidateRequest="false" Inherits="ProjectSix.admin.master.rate" %>

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
    <i class="icon-home2 mr-2"></i>Rate Page
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_MainBody" runat="server">
    <div class="content" style="min-height: 10px;">
        <ul id="fbAdd" class="fab-menu fab-menu-fixed fab-menu-bottom-right">
            <li><a id="A2" href="#" class="fab-menu-btn btn bg-green btn-float rounded-round btn-icon" runat="server" onserverclick="btn_Add_Click"><i
                class="fab-icon-open icon-plus3"></i><i class="fab-icon-close icon-cross2"></i></a></li>
        </ul>
        <div id="tab1" class="card">
            <div class="card-body">
                <asp:GridView ID="gvDtlsRate" runat="server" class="table table-hover table-bordered table-striped" AutoGenerateColumns="False"
                    EmptyDataText="No data found." DataKeyNames="DTLS_RATE_KEY" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Sr. No">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="CALL_TYPE" HeaderText="Call Type">
                            <HeaderStyle Width="25%" HorizontalAlign="Center" />
                            <ItemStyle Width="25%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PRICE" HeaderText="Price">
                            <HeaderStyle Width="25%" HorizontalAlign="Center" />
                            <ItemStyle Width="25%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="HOURS" HeaderText="Hours">
                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                            <ItemStyle Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ADD_HOURS" HeaderText="Additional Hours">
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
                <asp:HiddenField ID="hf_RATE_IMG" runat="server" Value="" />
                <asp:HiddenField ID="hf_DTLS_RATE_KEY" runat="server" Value="0" />
            </div>
            <div class="card">
                <div class="card-body">
                    <div class="col-md-12">
                        <fieldset>
                            <legend class="font-weight-semibold">Rate Section</legend>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>
                                                Select Call Type</label>
                                            <asp:DropDownList ID="ddl_MAST_CALL_TYPE_KEY" runat="server" CssClass="form-control populate">
                                                <asp:ListItem Text="In Call" Value="0" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Out Call" Value="1"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>
                                                Price</label>
                                            <asp:TextBox ID="txt_PRICE" class="form-control" onkeypress="return onlyNumbers(event);" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>
                                                Hours</label>
                                            <asp:TextBox ID="txt_HOURS" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>
                                                Additional Hours</label>
                                            <asp:TextBox ID="txt_ADD_HOURS" onkeypress="return onlyNumbers(event);" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <fieldset>
                                        <legend>Rate Image</legend>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label>
                                                        Upload Picture (Accepted Format .png, .jpg, .jpeg only. Max size 2 MB)
                                                    </label>
                                                    <asp:FileUpload ID="fu_Rate" runat="server" class="form-input-styled" data-fouc accept=".gif, .png, .jpg, .jpeg" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-8 ml-auto mr-auto">
                                                <img id="img_Rate" src="../../assets/images/no_image.jpg" class="form-control preview" runat="server" />
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>
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
            setDatatable("<%=gvDtlsRate.ClientID %>");
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

            $("#<%=fu_Rate.ClientID %>").on("change", function (evt) {
                var tgt = evt.target || window.event.srcElement, files = tgt.files;
                if (files.length > 0) {
                    if (files[0].size > 20097134) {
                        $(this).val("");
                        $(this).next(".filename").text("No file selected");
                        $('#<%=img_Rate.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/assets/images/no_image.jpg")%>");
                        $(this).focus();
                        openErrorPopup("Please maintain allowed document size (20MB maximum).");
                    }
                    else {
                        readURL(this, $('#<%=img_Rate.ClientID %>'));
                    }
                }
                else {
                    $('#<%=img_Rate.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/assets/images/no_image.jpg")%>");
                }
            });

            $('#loadingMask').fadeOut();
        });
    </script>
</asp:Content>
