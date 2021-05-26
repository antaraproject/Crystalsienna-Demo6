<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="subscribe.aspx.cs" Inherits="ProjectSix.admin.master.subscribe"
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
    <i class="icon-home2 mr-2"></i>Subscribe
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_MainBody" runat="server">
    <div>
        <asp:HiddenField ID="hf_MAST_CITY_KEY" runat="server" Value="0" />
      <%--  <asp:HiddenField ID="hf_GALLERY_IMG" runat="server" Value="" />--%>

    </div>
    <div class="content" style="min-height: 10px;">
     
        <div id="tab1" class="card">



            <div class="card-body">
                <asp:GridView ID="gvDtlsDiary" runat="server" class="table table-hover table-bordered table-striped" AutoGenerateColumns="False"
                    EmptyDataText="No data found." DataKeyNames="SUBSCRIBE_TOUR_KEY" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Sr. No">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                          <asp:BoundField DataField="EMAIL_ID" HeaderText="Email">
                            <HeaderStyle Width="80%" HorizontalAlign="Center" />
                            <ItemStyle Width="80%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CITY_NAME" HeaderText="City Name">
                            <HeaderStyle Width="80%" HorizontalAlign="Center" />
                            <ItemStyle Width="80%" />
                        </asp:BoundField>
                        
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <ul id="tabsmenu" class="tabsmenu" style="display: none">
            <li class="active"><a id="atab1" href="#tab1">List</a></li>
            <li><a id="atab2" href="#tab2">Add / Edit</a></li>
            <li><a id="aPageName" runat="server" href="#" style="margin: 0 5px 0 33%; border-radius: 6px;">&nbsp;</a></li>
        </ul>
   
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_Scripts" runat="server">
    <script type="text/javascript">

        function OpenTab1(strMsg, error) {
            $("#tab1").fadeIn();
            $("#tab3").hide();
            $("#tab2").hide();
            setDatatable("<%=gvDtlsDiary.ClientID %>");
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


<%--        $("#<%=txt_DIARY_DATE.ClientID %>").datepicker({
            dateFormat: 'dd/mm/yy',
            showOn: "button",
            buttonImage: "../assets/images/calendar.png",
            buttonImageOnly: true,
            changeMonth: true,
            changeYear: true,
            onSelect: function (selected, event) {
                CheckDate($("#<%=txt_DIARY_DATE.ClientID %>"), selected);
            }
        });--%>


<%--        $(document).ready(function () {


            $("#<%=txt_LONG_DESC.ClientID %>").summernote({
                height: 180,
                codemirror: { "theme": "ambiance" }
            });

            $("#<%=txt_LONG_DESC.ClientID %>").on('summernote.blur', function () {
                $("#<%=txt_LONG_DESC.ClientID %>").html($("#<%=txt_LONG_DESC.ClientID %>").summernote('code'));
            });

            $('#loadingMask').fadeOut();
        });--%>
    </script>

    <script type="text/javascript">


       $(document).ready(function () {

            <%--$('.form-input-styled').uniform({
                fileButtonClass: 'action btn bg-pink-400'
            });

            $("#<%=fu_Gallery.ClientID %>").on("change", function (evt) {
                   var tgt = evt.target || window.event.srcElement, files = tgt.files;
                   if (files.length > 0) {
                       if (files[0].size > 20097134) {
                           $(this).val("");
                           $(this).next(".filename").text("No file selected");
                           $('#<%=img_Gallery.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/admin/assets/images/no_image.jpg")%>");
                        $(this).focus();
                        openErrorPopup("Please maintain allowed document size (20MB maximum).");
                    }
                    else {
                        readURL(this, $('#<%=img_Gallery.ClientID %>'));
                    }
                }
                else {
                    $('#<%=img_Gallery.ClientID %>').attr("src", "<%= Page.ResolveClientUrl("~/admin/assets/images/no_image.jpg")%>");
                   }
               });--%>

               $('#loadingMask').fadeOut();
           });
    </script>
</asp:Content>
