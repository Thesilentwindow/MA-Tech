<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login-Page.aspx.cs" Inherits="AssignmentSystem.Login_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tandlæge Login</title>
    <link href="Content/css/bootstrap.css" rel="stylesheet" />
    <link href="Content/css/bootstrap-reboot.css" rel="stylesheet" />
    <link href="Content/css/bootstrap-grid.css" rel="stylesheet" />
    <link href="Content/Form-Signin.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="wrapper">
                <div class="form-signin">
                    <h3 class="form-signin-heading">Assignment Center</h3>
                    <hr class="colorgraph" />

                    <asp:TextBox runat="server" ID="tb_Username" ReadOnly="False" CssClass="form-control" placeholder="Username"></asp:TextBox>
                    <asp:TextBox runat="server" ID="tb_Password" CssClass="form-control" placeholder="password" />
                    <asp:Button runat="server" ID="btn_Login" Text="Login" CssClass="btn btn-lg btn-primary btn-block" OnClick="btn_Login_OnClick" UseSubmitBehavior="False" CausesValidation="False" />

                    <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Modal Test</button>
                </div>

            </div>
        </div>
    </form>

    <!-- Modal -->
    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Modal Header</h4>
                </div>
                <div class="modal-body">
                    <p>Some text in the modal.</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>

        </div>
    </div>




    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</body>
</html>
