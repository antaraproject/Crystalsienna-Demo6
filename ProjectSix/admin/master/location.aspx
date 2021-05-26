<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="location.aspx.cs" Inherits="Supplychain_cms.admin.master.location" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_FormName" runat="server">
    <i class="icon-home2 mr-2"></i>Location
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_MainBody" runat="server">
    <div class="content" style="min-height: 10px;">
        <ul id="fbAdd" class="fab-menu fab-menu-fixed fab-menu-bottom-right">
            <li><a id="A2" href="#" class="fab-menu-btn btn bg-green btn-float rounded-round btn-icon" runat="server" onserverclick="btn_Add_Click"><i
                class="fab-icon-open icon-plus3"></i><i class="fab-icon-close icon-cross2"></i></a></li>
        </ul>
        <div id="tab1" class="card">
            <div class="card-body">
                <asp:GridView ID="gvMstLocation" runat="server" class="table table-hover table-bordered table-striped" AutoGenerateColumns="False"
                    EmptyDataText="No data found." DataKeyNames="MAST_LOCATION_KEY" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Sr. No">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="LOCATION_NAME" HeaderText="Location">
                            <HeaderStyle Width="80%" HorizontalAlign="Center" />
                            <ItemStyle Width="80%" />
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
                <asp:HiddenField ID="hf_MAST_LOCATION_KEY" runat="server" Value="0" />
            </div>
            <div class="card">
                <div class="card-body">
                    <div class="col-md-12">
                        <fieldset>
                            <legend class="font-weight-semibold">Location Entry</legend>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>
                                            Location Name
                                        </label>
                                        <asp:TextBox ID="txt_LOCATION_NAME" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </fieldset>
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
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_Scripts" runat="server">
    <script type="text/javascript">

        function OpenTab1(strMsg, error) {
            $("#tab1").fadeIn();
            $("#tab3").hide();
            $("#tab2").hide();
            setDatatable("<%=gvMstLocation.ClientID %>");
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
            $('#loadingMask').fadeOut();
        });
    </script>
</asp:Content>
