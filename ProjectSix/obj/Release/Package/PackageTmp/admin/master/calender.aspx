<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="calender.aspx.cs" Inherits="ProjectSix.admin.master.calender" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_FormName" runat="server">
    <i class="icon-home2 mr-2"></i>Calendar
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_MainBody" runat="server">
    <div>
        <asp:HiddenField ID="hf_DTLS_CALENDER_KEY" runat="server" Value="0" />
    </div>
    <div class="card">
        <div class="card-body">
            <div class="col-md-12">
                <fieldset>
                    <legend class="font-weight-semibold">Calendar</legend>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>
                                            Available Day
                                        </label>
                                        <asp:TextBox ID="txt_DAY_NAME" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>
                                            From
                                        </label>
                                        <asp:TextBox ID="txt_START_TIME" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>
                                            Until
                                        </label>
                                        <asp:TextBox ID="txt_END_TIME" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>
                                            &nbsp;</label>
                                        <asp:Button ID="btn_Save" runat="server" Text="Save" CssClass="btn btn-primary form-control" OnClick="btn_Save_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvClendar" runat="server" class="table table-bordered table-sm table-hover" AutoGenerateColumns="False"
                                            EmptyDataText="No data found." DataKeyNames="DTLS_CALENDER_KEY">
                                            <Columns>
                                                <asp:BoundField DataField="DAY_NAME" HeaderText="Available Day">
                                                    <HeaderStyle Width="30%" HorizontalAlign="Center" />
                                                    <ItemStyle Width="30%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="START_TIME" HeaderText="From">
                                                    <HeaderStyle Width="30%" HorizontalAlign="Center" />
                                                    <ItemStyle Width="30%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="END_TIME" HeaderText="Until">
                                                    <HeaderStyle Width="30%" HorizontalAlign="Center" />
                                                    <ItemStyle Width="30%" />
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
                        </div>
                    </div>
                </fieldset>
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
            setDatatable("<%=gvClendar.ClientID %>");
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
