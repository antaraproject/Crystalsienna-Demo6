<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="appointment.aspx.cs" Inherits="ProjectSix.admin.master.appointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <%-- <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    <script src="https://unpkg.com/sweetalert2@7.19.3/dist/sweetalert2.all.js"></script>
    
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@10"></script>
    <script>
        debugger;
        function popup(obj) {
            
            var vString = ""; 
            var mydata = JSON.parse(JSON.stringify(obj));
            console.log(mydata);
            vString += "<div><table class='table table-bordered table-sm table-hover' cellspacing='0' rules='all' border='1' style='border-collapse:collapse;'>";
            vString += "<thead><tr><th>Start Time</th><th>End Time</th><th>Price</th></tr></thead><tbody>";
            for (var i = 0; i < mydata.length; i++) {
                var jsonobj = mydata[i];
                vString += "<tr><td>" + jsonobj.START_TIME + "</td><td>" + jsonobj.END_TIME + "</td><td>$" + jsonobj.PRICE +"</td></tr>";
            }
            vString += "</tbody></table></div>";
            
            Swal.fire({
                title: "<i>Booked Timeslots</i>",
                html: vString ,
                confirmButtonText: "Cloce",
            });
        }
        
    </script>
    <style> 
	.timeslotcontainer{
		position: fixed;
    top: 50%;
    transform: translateY(-50%);
    -moz-transform: translateY(-50%);
    -o-transform: translateY(-50%);
    -ms-transform: translateY(-50%);
    left: 0;
    right: 0;
    margin: auto;
    width: 650px;
    max-height: 500px;
    overflow-y: auto;
    background: #f8f8f8;
    border: 1px solid #cacaca;
    padding: 35px;
    display: none;
    box-shadow: 0 0 20px 0px #00000038;
	}
    .closetimeslot{margin-top:20px;}
	.timeslotcontainer .table{
		width:100%;
		float:left;
        background:#fff;
	}
	.closetimeslot{
		float:right;
	}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_FormName" runat="server">
    <i class="icon-home2 mr-2"></i>Client Appointments
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_MainBody" runat="server">
    <div>
        <asp:HiddenField ID="hf_DTLS_APPOINTMENT_KEY" runat="server" Value="0" />
    </div>
    <div class="card">
        <div class="card-body">
            <div class="col-md-12">
                <fieldset>
                    <legend class="font-weight-semibold">Client's Appointments Details</legend>
                    <div class="row">
                        <div class="col-md-12">

                            <div class="row">
                                <div class="col-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvAppointment" runat="server" CssClass="table table-bordered table-sm table-hover" AutoGenerateColumns="False"
                                            EmptyDataText="No data found." DataKeyNames="DTLS_APPOINTMENT_KEY">
                                            <Columns>
                                                
                                                <asp:BoundField DataField="USER_NAME" HeaderText="Client Name">
                                                    <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                                    <ItemStyle Width="15%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="EVENT_DATE" HeaderText="Booking Date">
                                                    <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                                    <ItemStyle Width="15%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="EVENT_DAY" HeaderText="Booking Day">
                                                    <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                                    <ItemStyle Width="15%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TIME_SPAN" HeaderText="Time Slots">
                                                    <HeaderStyle Width="20%" HorizontalAlign="Center" />
                                                    <ItemStyle Width="20%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="PRICE" HeaderText="Total Amount">
                                                    <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                                    <ItemStyle Width="15%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DESCRIPTION" HeaderText="Description">
                                                    <HeaderStyle Width="30%" HorizontalAlign="Center" />
                                                    <ItemStyle Width="30%" />
                                                </asp:BoundField>
                                               <asp:BoundField DataField="TAG_STATUS" HeaderText="Status">
                                                    <HeaderStyle Width="30%" HorizontalAlign="Center" />
                                                    <ItemStyle Width="30%" />
                                                </asp:BoundField>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="View Details">
                                                    <ItemTemplate>
                                                        <div style="width: 90%; white-space: nowrap;">
                                                            <a id="A3" href="#" class="list-icons-item" runat="server" onserverclick="btn_View_Click"><i class="icon-eye"></i></a><%--onserverclick="btn_View_Click"--%>
                                                            
                                                        </div>

                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Approve">
                                                    <ItemTemplate>
                                                        <div style="width: 90%; white-space: nowrap;">
                                                            <a id="A2" href="#" class="list-icons-item" runat="server" onserverclick="btn_Approve_Click"><i class="icon-thumbs-up2"></i></a><%--onserverclick="btn_Page_Setting_Edit_Click"--%>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Reject">
                                                    <ItemTemplate>
                                                        <div style="width: 90%; white-space: nowrap;">
                                                            <a id="A1" href="#" class="list-icons-item" runat="server" onserverclick="btn_Reject_Click"><i class="icon-cross"></i></a><%--onserverclick="btn_Page_Setting_Edit_Click"--%>
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
            setDatatable("<%=gvAppointment.ClientID %>");
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
    
    <script>
        $(document).ready(function () {
            $(".list-icons-item").click(function () {
                $(this).next(".timeslotcontainer").show();
            });
            $(".closetimeslot").click(function () {
                $(".timeslotcontainer").hide();
            });
        });
</script>
</asp:Content>