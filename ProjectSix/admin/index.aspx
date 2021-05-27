<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ProjectSix.admin.index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link rel="icon" type="image/png" sizes="32x32" href="assets/images/new_logo.png">
    <link rel="icon" type="image/png" sizes="96x96" href="assets/images/new_logo.png">
    <link rel="icon" type="image/png" sizes="16x16" href="assets/images/new_logo.png">
    <meta name="msapplication-TileColor" content="#ffffff">
    <meta name="msapplication-TileImage" content="/ms-icon-144x144.png">
    <meta name="theme-color" content="#ffffff">
    <title>Project Six | CMS Login </title>
    <link href="https://fonts.googleapis.com/css?family=Roboto:400,300,100,500,700,900"
        rel="stylesheet" type="text/css">
    <link href="<%=Page.ResolveClientUrl("~/admin/assets/css/icons/icomoon/styles.min.css") %>" rel="stylesheet" type="text/css">
    <link href="<%=Page.ResolveClientUrl("~/admin/assets/css/bootstrap.min.css") %>" rel="stylesheet" type="text/css">
    <link href="<%=Page.ResolveClientUrl("~/admin/assets/css/bootstrap_limitless.min.css") %>" rel="stylesheet" type="text/css">
    <link href="<%=Page.ResolveClientUrl("~/admin/assets/css/layout.min.css") %>" rel="stylesheet" type="text/css">
    <link href="<%=Page.ResolveClientUrl("~/admin/assets/css/components.min.css") %>" rel="stylesheet" type="text/css">
    <link href="<%=Page.ResolveClientUrl("~/admin/assets/css/colors.min.css") %>" rel="stylesheet" type="text/css">
    <!-- /global stylesheets -->
    <!-- Core JS files -->
    <script src="<%=Page.ResolveClientUrl("~/admin/assets/js/main/jquery.min.js") %>" type="text/javascript"></script>
    <script src="<%=Page.ResolveClientUrl("~/admin/assets/js/main/bootstrap.bundle.min.js") %>" type="text/javascript"></script>
    <script src="<%=Page.ResolveClientUrl("~/admin/assets/js/plugins/loaders/blockui.min.js") %>" type="text/javascript"></script>
    <!-- /core JS files -->
    <script src="<%=Page.ResolveClientUrl("~/admin/assets/js/plugins/forms/styling/switchery.min.js") %>" type="text/javascript"></script>
    <!-- Theme JS files -->
    <script src="<%=Page.ResolveClientUrl("~/admin/assets/js/plugins/forms/styling/uniform.min.js") %>" type="text/javascript"></script>
    <script src="<%=Page.ResolveClientUrl("~/admin/assets/js/plugins/forms/styling/switch.min.js") %>" type="text/javascript"></script>
    <script src="<%=Page.ResolveClientUrl("~/admin/assets/js/app.js") %>" type="text/javascript"></script>
    <script src="<%=Page.ResolveClientUrl("~/admin/assets/js/demo_pages/form_checkboxes_radios.js") %>" type="text/javascript"></script>
    <style type="text/css">
        body {
            background-color: #ff9b56;
        }
        .card {
            box-shadow: 0 0.46875rem 2.1875rem rgba(90,97,105,0.1), 0 0.9375rem 1.40625rem rgba(90,97,105,0.1), 0 0.25rem 0.53125rem rgba(90,97,105,0.12), 0 0.125rem 0.1875rem rgba(90,97,105,0);
            border-radius: 0.9rem;
        }
    </style>
</head>
<body>
    <div class="page-content">
        <!-- Main content -->
        <div class="content-wrapper">
            <!-- Content area -->
            <div class="content d-flex justify-content-center align-items-center">
                <!-- Login form -->
                <form id="form1" runat="server" class="login-form">
                    <div class="card mb-0">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-2 text-center mb-3">
                                    <img src="assets/images/new_logo.png" />
                                </div>
                                <div class="col-md-10 text-center mb-3">
                                    <h5 class="mb-0">Login to your account</h5>
                                    <span class="d-block text-muted">Content management system</span>
                                </div>
                            </div>
                            <div class="form-group form-group-feedback form-group-feedback-left">
                                <asp:TextBox ID="txt_User_Id" class="form-control" placeholder="Username" runat="server" autofocus="true"></asp:TextBox>
                                <div class="form-control-feedback">
                                    <i style="margin-top: 10px;" class="icon-user text-muted"></i>
                                </div>
                            </div>
                            <div class="form-group form-group-feedback form-group-feedback-left">
                                <asp:TextBox ID="txt_Password" class="form-control" TextMode="Password" placeholder="Password" runat="server"></asp:TextBox>
                                <div class="form-control-feedback">
                                    <i style="margin-top: 10px;" class="icon-lock2 text-muted"></i>
                                </div>
                            </div>
                            <div class="form-group form-group-feedback form-group-feedback-left" style="display: none;">
                                <p class="form-txt">
                                    Select Company
                                </p>
                                <asp:DropDownList ID="ddl_COMPANY" runat="server" CssClass="form-control" Style="padding-left: inherit;">
                                </asp:DropDownList>
                            </div>

                            <div class="form-group form-group-feedback form-group-feedback-left" style="display: none">
                                <label class="d-block font-weight-semibold">
                                    Select User Mode</label>
                                <div class="form-check form-check-inline">
                                    <label class="form-check-label">
                                        <input id="rdostaff" type="radio" class="form-check-input-styled" name="choice" value="staff"
                                            checked data-fouc />
                                        Staff
                                    </label>
                                </div>
                                <div class="form-check form-check-inline">
                                    <label class="form-check-label">
                                        <input id="rdoadmin" type="radio" class="form-check-input-styled" name="choice" value="admin"
                                            data-fouc />
                                        Admin
                                    </label>
                                </div>
                                <div class="form-check form-check-inline">
                                    <label class="form-check-label">
                                        <input id="rdouser" type="radio" class="form-check-input-styled" name="choice" value="client"
                                            data-fouc />
                                        Client
                                    </label>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btn_Sign_In" runat="server" Text="Login" class="btn btn-primary btn-block" OnClick="btn_sign_in_Click"></asp:Button>
                            </div>
                            <div class="text-center">
								<a href="../">← Back to Website</a>
							</div>
                        </div>
                    </div>
                </form>
                <!-- /login form -->
            </div>
            <!-- /content area -->
        </div>
        <!-- /main content -->
    </div>
    <!-- /page content -->
</body>
</html>
