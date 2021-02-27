using DPWA_Lab01_Periodo01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DPWA_Lab01_Periodo01
{
    public partial class Equipos : System.Web.UI.Page
    {
        private EquiposController controller;

        protected void Page_Load(object sender, EventArgs e)
        {
            VerificarSesiones();
            CargarEquipos();

            controller = new EquiposController(Session);

            validateReceivedPasrams();
        }

        private void validateReceivedPasrams()
        {
            if (Request.QueryString["deleteTeam"] != null)
            {
                Session["AlmacenDatos"] = controller.deleteTeam(Request.QueryString["teamId"].ToString());

                Response.Redirect("Equipos.aspx");
            }
        }

        private void VerificarSesiones()
        {
            if (Session["AlmacenDatos"] == null)
            {
                Session["AlmacenDatos"] = (AlmacenDatos)new AlmacenDatos(); 
            }
        }

        protected void btnAgregarEquipo_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            if (nombre != "" && imgView.ImageUrl != "")
            {
                AlmacenDatos almacen = (AlmacenDatos) Session["AlmacenDatos"];
                int respuesta = almacen.AgregarEquipo(new Equipo(imgView.ImageUrl, nombre));

                if (respuesta == 1)
                {
                    txtNombre.Text = "";
                    fileUpload.Dispose();
                    imgView.ImageUrl = "";
                }
                else
                {
                    //mensaje error
                }

                Session["AlmacenDatos"] = almacen;
                CargarEquipos();
            }
        }

        protected void btnSubirArchivo_Click(object sender, EventArgs e)
        {
            string nombreArchivo = string.Empty;
            string destino = @"~/imagenes/";
            if (fileUpload.HasFile)
            {
                //imagen
                string carpetaDestino = Server.MapPath(destino);
                nombreArchivo = System.IO.Path.GetFileName(fileUpload.PostedFile.FileName);
                string locacionServidor = carpetaDestino + nombreArchivo;
                fileUpload.PostedFile.SaveAs(locacionServidor);

                imgView.ImageUrl = destino + nombreArchivo;
            }
        }

        private void CargarEquipos()
        {
            AlmacenDatos almacen = (AlmacenDatos)Session["AlmacenDatos"];

            this.tblEquipos.Rows.Clear();

            TableHeaderRow header = new TableHeaderRow();
            TableHeaderCell headerNombre = new TableHeaderCell(), headerImagen = new TableHeaderCell(), headerEditar = new TableHeaderCell(), headerEliminar = new TableHeaderCell(), headerPlantel = new TableHeaderCell(), headerInfo = new TableHeaderCell();
            headerNombre.Text = "Nombre Equipo";
            headerImagen.Text = "";
            headerEditar.Text = "Editar";
            headerEliminar.Text = "Eliminar";
            headerPlantel.Text = "Plantel";
            headerInfo.Text = "Info";

            header.Cells.Add(headerImagen);
            header.Cells.Add(headerNombre);
            header.Cells.Add(headerEditar);
            header.Cells.Add(headerEliminar);
            header.Cells.Add(headerPlantel);
            header.Cells.Add(headerInfo);

            this.tblEquipos.Rows.Add(header);

            foreach (Equipo equipo in almacen.Equipos)
            {
                TableRow row = new TableRow();


                //celdas
                TableCell cellNombre = new TableCell(), cellImagen = new TableCell(), cellEditar = new TableCell(), cellEliminar = new TableCell(), cellPlantel = new TableCell(), cellInfo = new TableCell();
                cellNombre.Text = equipo.Nombre;
                cellImagen.Text = string.Format("<img width='50px' height='50px' src='{0}' />", equipo.DirFotografia.Substring(1));
                cellEditar.Text = "Pendiente";
                cellEliminar.Text = "<a class='btn btn-danger' href='Equipos.aspx?deleteTeam=true&teamId=" + equipo.Codigo + "'>Eliminar</a>";
                cellPlantel.Text = "<a class='btn btn-primary' href='Plantel.aspx?equipo="+equipo.Codigo+"'>Ver Jugadores</a>";
              
                string mensajeInfo = "";
                if (equipo.EquipoEstaCompleto())
                {
                    mensajeInfo = "Equipo completo";
                }else if (equipo.EquipoEstaIncompleto())
                {
                    mensajeInfo = "Equipo incompleto";
                }
                else
                {
                    mensajeInfo = "";
                }

                cellInfo.Text = mensajeInfo;

                row.Cells.Add(cellImagen);
                row.Cells.Add(cellNombre);
                row.Cells.Add(cellEditar);
                row.Cells.Add(cellEliminar);
                row.Cells.Add(cellPlantel);
                row.Cells.Add(cellInfo);

                this.tblEquipos.Rows.Add(row);
            }
        }

    }
}