<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="bookingtime.aspx.cs" Inherits="ProjectSix.admin.master.bookingtime" %>
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
    <i class="icon-home2 mr-2"></i>Booking Time
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_MainBody" runat="server">
    <div class="content" style="min-height: 10px;">
        <ul id="fbAdd" class="fab-menu fab-menu-fixed fab-menu-bottom-right">
            <li><a id="A2" href="#" class="fab-menu-btn btn bg-green btn-float rounded-round btn-icon" runat="server" onserverclick="btn_Add_Click"><i
                class="fab-icon-open icon-plus3"></i><i class="fab-icon-close icon-cross2"></i></a></li><%--onserverclick="btn_Add_Click"--%>
        </ul>
        <div id="tab1" class="card">
            <div class="card-body">
                <asp:GridView ID="gvDtlsBooking" runat="server" class="table table-hover table-bordered table-striped" AutoGenerateColumns="False"
                    EmptyDataText="No data found." DataKeyNames="DTLS_TIMETABLE_KEY" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Sr. No">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Available/Not Available">
                            <ItemTemplate>
                                <div style="width: 90%; white-space: nowrap;">
                                    <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="true" />   
                                    
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="AVAILABLE_STATUS" HeaderText="Availibility">
                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                            <ItemStyle Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EVENT_DAY" HeaderText="Day">
                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                            <ItemStyle Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="START_TIME" HeaderText="Events Start Time">
                            <HeaderStyle Width="20%" HorizontalAlign="Center" />
                            <ItemStyle Width="20%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="END_TIME" HeaderText="Events End Time">
                            <HeaderStyle Width="45%" HorizontalAlign="Center" />
                            <ItemStyle Width="45%" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="PRICE" HeaderText="Price($)">
                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                            <ItemStyle Width="15%" />
                        </asp:BoundField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Edit">
                            <ItemTemplate>
                                <div style="width: 90%; white-space: nowrap;">
                                    <a id="A1" href="#" class="list-icons-item" runat="server" onserverclick="btn_Edit_Click" ><i class="icon-menu9"></i></a><%----%>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Delete">
                            <ItemTemplate>
                                <div style="width: 90%; white-space: nowrap;">
                                    <a id="A3" href="#" class="list-icons-item" runat="server" onserverclick="btn_Delete_Click" ><i class="icon-trash"></i></a>
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
                
                <asp:HiddenField ID="hf_DTLS_TIMETABLE_KEY" runat="server" Value="0" />
            </div>
            <div class="card">
                <div class="card-body">
                    <div class="col-md-12">
                        <fieldset>
                            <legend class="font-weight-semibold">News Section</legend>
                            <div class="row">
                                
                                
                                <div class="col-md-6">
                                   
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>
                                                Start Time</label>
                                            <asp:TextBox ID="txt_START_TIME" TextMode="Time" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    

                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>
                                                End Time</label>
                                            <asp:TextBox ID="txt_END_TIME" TextMode="Time" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                     <div class="col-md-12">
                                        <div class="form-group">
                                            <label>
                                                Event Day</label>
                                            <%--<asp:TextBox ID="txt_EVENT_DAY" class="form-control" runat="server"></asp:TextBox>--%>
                                            <asp:DropDownList ID="ddl_EVENT_DAY" runat="server" class="form-control">
                                                 <asp:ListItem>--Select--</asp:ListItem>
                                                <asp:ListItem>Sunday</asp:ListItem>
                                                <asp:ListItem>Monday</asp:ListItem>
                                                <asp:ListItem>Tuesday</asp:ListItem>
                                                <asp:ListItem>Wednesday</asp:ListItem>
                                                <asp:ListItem>Friday</asp:ListItem>
                                                <asp:ListItem>Saturday</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        
                                    </div>
                                    
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>
                                                Price</label>
                                            <asp:TextBox ID="txt_PRICE" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        
                                    </div>
                                    </div>
                               
                            </div>
                        </fieldset>
                    </div>
                </div>
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-md-12 text-center">
                        <asp:Button ID="btn_Head_Save" runat="server" Text="Submit" CssClass="mb-xs mt-xs btn btn-success" ToolTip="Submit"  OnClick="btn_Head_Save_Click" /><%-- --%>
                        <asp:Button ID="btn_Back_Save" runat="server" Text="Back" CssClass="mb-xs mt-xs mr-xs btn btn-warning" ToolTip="Back" OnClick="btn_Back_Click"/>
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
            setDatatable("<%=gvDtlsBooking.ClientID %>");
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