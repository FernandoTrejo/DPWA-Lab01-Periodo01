<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="DPWA_Lab01_Periodo01.Main" %>

<%@ Register Src="~/ControlesUsuario/Menu.ascx" TagPrefix="uc1" TagName="Menu" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Bienvenido</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.10.0/css/all.min.css"/>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:Menu runat="server" id="Menu" />
        </div>

        <div class="container">
            <div class="row d-flex justify-content-center">
                <div class="col-md-4">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre Jugador"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:DropDownList ID="ddlistPosicion" CssClass="form-control" runat="server">
                        <asp:ListItem Selected="True">Portero</asp:ListItem>
                        <asp:ListItem>Defensa</asp:ListItem>
                        <asp:ListItem>Mediocampista</asp:ListItem>
                        <asp:ListItem>Delantero</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-1">
                    <asp:TextBox ID="txtDorsal" runat="server" CssClass="form-control" placeholder="#"></asp:TextBox>
                </div>
                <div class="col-md-1">
                    <asp:LinkButton ID="btnAgregarJugador" CssClass="btn btn-primary" runat="server" OnClick="btnAgregarJugador_Click"><i class="fas fa-plus"></i></asp:LinkButton>
                </div>
            </div>


            <br />
            <br />

            <div class="row d-flex justify-content-center">
                <div class="col-md-4">
                    <asp:TextBox ID="txtBusqueda" CssClass="form-control" placeholder="Nombre" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-1">
                    <asp:LinkButton ID="btnBuscar" CssClass="btn btn-info" runat="server" OnClick="btnBuscar_Click"><i class="fas fa-search"></i></asp:LinkButton>
                </div>
                <div class="col-md-1">
                    <asp:LinkButton ID="btnResetearBusqueda" CssClass="btn btn-warning" runat="server" OnClick="btnResetearBusqueda_Click1"><i class="fas fa-undo-alt"></i></asp:LinkButton>
                </div>
            </div>

            <br />

            <div class="row d-flex justify-content-center">
                <div class="col-md-8">
                    <div class="table-responsive">
                        <asp:Table ID="tblJugadores" CssClass="table table-hover" runat="server">
                            <asp:TableHeaderRow
                                runat="server">
                                <asp:TableHeaderCell>Nombre Jugador</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Posicion</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Dorsal</asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>

                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>
