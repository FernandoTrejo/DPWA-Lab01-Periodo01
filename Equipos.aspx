<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Equipos.aspx.cs" Inherits="DPWA_Lab01_Periodo01.Equipos" %>

<%@ Register Src="~/ControlesUsuario/Menu.ascx" TagPrefix="uc1" TagName="Menu" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Equipos</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.10.0/css/all.min.css" />

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:Menu runat="server" ID="Menu" />
        </div>
        <br />
        <div class="container">
            <div class="row d-flex justify-content-center">
                <div class="col-md-2">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre Equipo"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:FileUpload ID="fileUpload" CssClass="btn btn-info" runat="server" Width="263px" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnSubirArchivo" runat="server" CssClass="btn btn-primary" Text="Subir" OnClick="btnSubirArchivo_Click" />
                </div>
                <div class="col-md-2">
                    <asp:Image ID="imgView" runat="server" />
                </div>
            </div>

            <br />

            <div class="row d-flex justify-content-center">

                <div class="col-md-4">
                    <asp:LinkButton ID="btnAgregarEquipo" CssClass="btn btn-primary" runat="server" OnClick="btnAgregarEquipo_Click">Agregar</asp:LinkButton>
                </div>
            </div>

            <br />

            <div class="row d-flex justify-content-center">
                <div class="col-md-8">
                    <div class="table-responsive">
                        <asp:Table ID="tblEquipos" CssClass="table table-hover" runat="server">
                            <asp:TableHeaderRow
                                runat="server">
                                <asp:TableHeaderCell>Nombre Equipo</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Imagen</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Editar</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Eliminar</asp:TableHeaderCell>
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
