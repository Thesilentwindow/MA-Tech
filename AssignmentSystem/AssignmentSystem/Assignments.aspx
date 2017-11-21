<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Assignments.aspx.cs" Inherits="AssignmentSystem.Assignments1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tandlæge Net</title>
    <link href="Content/css/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" />
    <link href="Content/css/bootstrap-reboot.css" rel="stylesheet" />
    <link href="Content/css/bootstrap-grid.css" rel="stylesheet" />
    <link href="Content/Form-Signin.css" rel="stylesheet" />
</head>
<body style="background-color: lightgrey; padding: 0 90px;">
    <br />
    <br />
    <form id="form1" runat="server" class="container">
        <div class="jumbotron">
            <h1>Tand Klinik Opgaver</h1>
            <asp:Label runat="server" ID="lbl_Account" CssClass="label label-default">Test</asp:Label>
            <br />
            <div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="TandDBSource" GridLines="None" CssClass="table table-hover table-striped" AutoGenerateEditButton="True">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                        <asp:BoundField DataField="QuestTitle" HeaderText="QuestTitle" SortExpression="QuestTitle" />
                        <asp:BoundField DataField="QuestDescription" HeaderText="QuestDescription" SortExpression="QuestDescription" />
                        <asp:BoundField DataField="QuestStatus" HeaderText="QuestStatus" SortExpression="QuestStatus" />
                    </Columns>
                </asp:GridView>
                <br />
                <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Modal Test</button>
                <asp:Button runat="server" ID="btn_Logout" Text="Logout" CssClass="btn btn-info btn-lg" OnClick="btn_Logout_OnClick"/>
                <asp:SqlDataSource ID="TandDBSource" runat="server" ConnectionString="<%$ ConnectionStrings:TandDbConString %>" SelectCommand="SELECT * FROM [Quest_Table]"></asp:SqlDataSource>
            </div>
        </div>
    </form>
    <!-- Modal -->
    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Modal Header</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
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
