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
            <h1>Tand Klinikken</h1>
            <asp:Label runat="server" ID="lbl_Account" CssClass="label label-default">Test</asp:Label>
            <br />

            <br />
            <div>

                <asp:GridView ID="OpgaveView" runat="server" AllowPaging="True" PageSize="20" AutoGenerateColumns="False" DataKeyNames="AktivitetId" DataSourceID="TandDBSource" GridLines="None" CssClass="table table-light table-hover" OnRowDeleting="OpgaveView_RowDeleting" OnRowUpdating="OpgaveView_RowUpdating">
                    <Columns>
                        <asp:BoundField DataField="AktivitetId" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="AktivitetId" />
                        <asp:BoundField DataField="AktivitetTitel" HeaderText="Titel" SortExpression="AktivitetTitel" />
                        <asp:BoundField DataField="AktivitetBeskrivelse" HeaderText="Beskrivelse" SortExpression="AktivitetBeskrivelse" />
                        <asp:BoundField DataField="AktivitetDato" HeaderText="Dato" SortExpression="AktivitetDato"  ReadOnly="True" />
                        <asp:BoundField DataField="AktivitetAnsvarlig" HeaderText="Oprettet af" SortExpression="AktivitetAnsvarlig" ReadOnly="True" />
                    </Columns>
                </asp:GridView>

                <asp:SqlDataSource ID="TandDBSource" runat="server" ConnectionString="<%$ ConnectionStrings:ProductionConString %>" SelectCommand="SELECT [AktivitetId], [AktivitetTitel], [AktivitetBeskrivelse], [AktivitetDato], [AktivitetAnsvarlig] FROM [Opgaver]" DeleteCommand="DELETE FROM [Opgaver] WHERE [AktivitetId] = @original_AktivitetId AND [AktivitetTitel] = @original_AktivitetTitel AND [AktivitetBeskrivelse] = @original_AktivitetBeskrivelse AND [AktivitetDato] = @original_AktivitetDato AND [AktivitetAnsvarlig] = @original_AktivitetAnsvarlig" ConflictDetection="CompareAllValues" InsertCommand="INSERT INTO [Opgaver] ([AktivitetTitel], [AktivitetBeskrivelse], [AktivitetDato], [AktivitetAnsvarlig]) VALUES (@AktivitetTitel, @AktivitetBeskrivelse, @AktivitetDato, @AktivitetAnsvarlig)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [Opgaver] SET [AktivitetTitel] = @AktivitetTitel, [AktivitetBeskrivelse] = @AktivitetBeskrivelse WHERE [AktivitetId] = @original_AktivitetId AND [AktivitetTitel] = @original_AktivitetTitel AND [AktivitetBeskrivelse] = @original_AktivitetBeskrivelse " OnSelecting="TandDBSource_Selecting">
                    <DeleteParameters>
                        <asp:Parameter Name="original_AktivitetId" Type="Int32" />
                        <asp:Parameter Name="original_AktivitetTitel" Type="String" />
                        <asp:Parameter Name="original_AktivitetBeskrivelse" Type="String" />
                        <asp:Parameter Name="original_AktivitetDato" Type="DateTime" />
                        <asp:Parameter Name="original_AktivitetAnsvarlig" Type="String" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="AktivitetTitel" Type="String" />
                        <asp:Parameter Name="AktivitetBeskrivelse" Type="String" />
                        <asp:Parameter Name="AktivitetDato" Type="DateTime" />
                        <asp:Parameter Name="AktivitetAnsvarlig" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="AktivitetTitel" Type="String" />
                        <asp:Parameter Name="AktivitetBeskrivelse" Type="String" />
                        <asp:Parameter Name="original_AktivitetId" Type="Int32" />
                        <asp:Parameter Name="original_AktivitetTitel" Type="String" />
                        <asp:Parameter Name="original_AktivitetBeskrivelse" Type="String" />
                    </UpdateParameters>
                </asp:SqlDataSource>


                <br />

                <div runat="server" id="div_tilføj">
                    <div class="panel panel-default">
                        <h2 class="text text-capitalize">Tilføj Opgave</h2>
                        <div class="panel-body">
                            <div>
                                <div class="col-md-5">
                                    <asp:Label runat="server">Titel</asp:Label>
                                    <br />
                                    <asp:TextBox runat="server" ID="tb_Titel" CssClass="form-control" placeholder="Titel"></asp:TextBox>
                                </div>
                                <div class="col-md-5">
                                    <asp:Label runat="server">Beskrivelse</asp:Label>
                                    <br />
                                    <asp:TextBox runat="server" ID="tb_Beskrivelse" CssClass="form-control" placeholder="beskrivelse" TextMode="MultiLine"></asp:TextBox>
                                </div>

                                <asp:Label runat="server" ID="lbl_Result"></asp:Label>
                            </div>
                            <div class="col-md-2 pull-right">
                                <br />
                                <asp:Button runat="server" ID="btn_Insert" CssClass="form-control" OnClick="btn_Insert_OnClick" Text="Tilføj" />
                            </div>
                        </div>
                    </div>
                </div>
<%--                <div runat="server" id="Div_UserPanel">
                    <div class="panel panel-default">
                        <h2 class="text text-capitalize">Tilføj Bruger</h2>
                        <div class="panel-body">
                            <div>
                                <div class="col-md-4">
                                    <asp:Label runat="server">Username</asp:Label>
                                    <br />
                                    <asp:TextBox runat="server" ID="tb_Username" CssClass="form-control" placeholder="Username"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:Label runat="server">Password</asp:Label>
                                    <br />
                                    <asp:TextBox runat="server" ID="tb_Password" CssClass="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:Label runat="server">Ansvarlig</asp:Label>
                                    <br />
                                    <asp:TextBox runat="server" ID="TextBox3" CssClass="form-control" placeholder="ansvarlig"></asp:TextBox>
                                </div>
                                <asp:Label runat="server" ID="Label1"></asp:Label>
                            </div>

                            <div class="col-md-2 pull-right">
                                <br />
                                <asp:Button runat="server" ID="Button1" CssClass="form-control" OnClick="btn_Insert_OnClick" Text="Tilføj" />
                            </div>
                        </div>
                    </div>
                </div>--%>

                <div class="pull-right">
                    <asp:Button runat="server" ID="btn_Logout" Text="Logout" CssClass="btn btn-danger btn-lg" OnClick="btn_Logout_OnClick" CausesValidation="False" />
                </div>

            </div>
        </div>
    </form>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</body>
</html>

