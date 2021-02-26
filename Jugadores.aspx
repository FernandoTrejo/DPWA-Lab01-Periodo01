<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Jugadores.aspx.cs" Inherits="DPWA_Lab01_Periodo01.Jugadores" %>

<%@ Register Src="~/ControlesUsuario/Menu.ascx" TagPrefix="uc1" TagName="Menu" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Jugadores</title>
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

                <div class="col-md-8">
                    <form>
                        <div class="d-flex justify-content-between">
                            <div class="form-group">
                                <asp:FileUpload ID="fileUpload" CssClass="btn btn-info" runat="server" Width="403px" />
                                <asp:Button ID="btnSubirArchivo" runat="server" CssClass="btn btn-primary" Text="Subir" OnClick="btnSubirArchivo_Click" />
                            </div>
                            <div class="form-group">

                                <asp:Image ID="imgView" runat="server" Height="100px" Width="100px" />
                            </div>
                        </div>


                        <div class="d-flex justify-content-between">
                            <div class="form-group">
                                <label for="txtNombre" class="col-form-label">Nombre</label>
                                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" placeholder="Nombre Jugador"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="ddlisPos" class="col-form-label">Posicion</label>
                                <asp:DropDownList ID="ddlisPos" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="BA">Base</asp:ListItem>
                                    <asp:ListItem Value="E">Escolta</asp:ListItem>
                                    <asp:ListItem Value="SF">Alero</asp:ListItem>
                                    <asp:ListItem Value="AP">Ala-Pivot</asp:ListItem>
                                    <asp:ListItem Value="C">Pivot</asp:ListItem>
                                </asp:DropDownList>

                            </div>
                            <div class="form-group">
                                <label for="txtEdad" class="col-form-label">Edad</label>
                                <asp:TextBox ID="txtEdad" CssClass="form-control" runat="server" placeholder="Edad"></asp:TextBox>
                            </div>
                        </div>
                        <div class="d-flex justify-content-between">
                            <div class="form-group">
                                <label for="txtEstatura" class="col-form-label">Estatura (m)</label>
                                <asp:TextBox ID="txtEstatura" CssClass="form-control" runat="server" placeholder="Estatura en metros"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="txtPeso" class="col-form-label">Peso (kg)</label>
                                <asp:TextBox ID="txtPeso" CssClass="form-control" runat="server" placeholder="Peso en kilogramos"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="txtSalario" class="col-form-label">Salario ($)</label>
                                <asp:TextBox ID="txtSalario" CssClass="form-control" runat="server" placeholder="Salario"></asp:TextBox>
                            </div>

                        </div>
                        <div class="form-group">
                            <label for="ddlistU" class="col-form-label">Universidad</label>
                            <asp:DropDownList ID="ddlistU" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </form>
                </div>

            </div>

            <br />

            <div class="row d-flex justify-content-center">

                <div class="col-md-2">
                    <asp:LinkButton ID="btnAgregarEquipo" Height="100%" CssClass="btn btn-primary" runat="server" OnClick="btnAgregarEquipo_Click"><i class="fas fa-plus"></i> &nbsp;&nbsp;Agregar</asp:LinkButton>
                    <asp:LinkButton ID="btnEditarJugador" Height="100%" OnClientClick="return false;" CssClass="btn btn-warning" Visible="false" runat="server"><i class="fas fa-edit"></i> &nbsp;&nbsp;Editar</asp:LinkButton>
                </div>
            </div>
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <script src="JS/Jugadores.js"></script>
</body>
</html>
