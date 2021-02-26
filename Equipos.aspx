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
            <div class="row d-flex justify-content-end">
                <div class="col-md-2">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre Equipo"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <asp:FileUpload ID="fileUpload" CssClass="btn btn-info" runat="server" Width="403px" />
                    <asp:Button ID="btnSubirArchivo" runat="server" CssClass="btn btn-primary" Text="Subir" OnClick="btnSubirArchivo_Click" />
                </div>
                <div class="col-md-2">
                    <asp:Image ID="imgView" runat="server" Height="100px" Width="100px" />
                </div>
            </div>

            <br />

            <div class="row d-flex justify-content-center">
                
                <div class="col-md-2">
                    <asp:LinkButton ID="btnAgregarEquipo" Height="100%" CssClass="btn btn-primary" runat="server" OnClick="btnAgregarEquipo_Click"><i class="fas fa-plus"></i> &nbsp;&nbsp;Agregar</asp:LinkButton>
                </div>
            </div>
            <br />

            <div class="row d-flex justify-content-center">
                <div class="col-md-8">
                    <div class="table-responsive">
                        <asp:Table ID="tblEquipos" CssClass="table table-hover" runat="server">
                        </asp:Table>

                    </div>
                </div>
            </div>
        </div>

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    </form>

    </body>
</html>
