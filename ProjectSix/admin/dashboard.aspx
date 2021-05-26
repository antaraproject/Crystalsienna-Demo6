<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="ProjectSix.admin.dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jsSHA/2.4.2/sha256.js" integrity="sha256-dooXXGL9i+/owrgXktRoh41mc/Rkif6Zcc2H3SgimQw=" crossorigin="anonymous"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_FormName" runat="server">
    <i class="icon-home2 mr-2"></i>Dashboard
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_MainBody" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_Scripts" runat="server">
    <script type="text/javascript">

        $(document).ready(function () {
            $('.form-input-styled').uniform({
                fileButtonClass: 'action btn bg-pink-400'
            });
            $('#loadingMask').fadeOut();
        });
    </script>
</asp:Content>
