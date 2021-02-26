<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Universidades.aspx.cs" Inherits="DPWA_Lab01_Periodo01.Universidades" %>

<%@ Register Src="~/ControlesUsuario/Menu.ascx" TagPrefix="uc1" TagName="Menu" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Universidades</title>
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
                <div class="col-md-4">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre Universidad"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:LinkButton ID="btnAgregarUniversidad" Height="100%" CssClass="btn btn-primary" runat="server" OnClick="btnAgregarUniversidad_Click"><i class="fas fa-plus"></i> &nbsp;&nbsp;Agregar</asp:LinkButton>
                </div>
                <div class="col-md-2">
                    <asp:LinkButton ID="btnEditarUniversidad" Enabled="false" Height="100%" OnClientClick="return false;" CssClass="btn btn-warning" runat="server" OnClick="btnEditarUniversidad_Click1"><i class="fas fa-edit"></i> &nbsp;&nbsp;Editar</asp:LinkButton>
                </div>
            </div>

            <br />
            <br />

            <div class="row d-flex justify-content-center">
                <div class="col-md-8">
                    <div class="table-responsive">
                        <asp:Table ID="tblUniversidades" CssClass="table table-hover" runat="server">
                        </asp:Table>

                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <script src="JS/Universidades.js"></script>
</body>
</html>
