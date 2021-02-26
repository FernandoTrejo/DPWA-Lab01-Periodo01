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
        private string direccionArchivo;
        protected void Page_Load(object sender, EventArgs e)
        {
            VerificarSesiones();

            direccionArchivo = "";
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
            if (nombre != "" && direccionArchivo != "")
            {
                AlmacenDatos almacen = (AlmacenDatos) Session["AlmacenDatos"];
                almacen.AgregarEquipo(new Equipo(direccionArchivo, nombre));
                Session["AlmacenDatos"] = almacen;

                txtNombre.Text = "";
                fileUpload.Dispose();

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

                direccionArchivo = destino + nombreArchivo;
                imgView.ImageUrl = direccionArchivo;
            }
        }

        private void CargarEquipos()
        {
            AlmacenDatos almacen = (AlmacenDatos)Session["AlmacenDatos"];

            this.tblEquipos.Rows.Clear();

            TableHeaderRow header = new TableHeaderRow();
            TableHeaderCell headerNombre = new TableHeaderCell(), headerImagen = new TableHeaderCell(), headerEditar = new TableHeaderCell(), headerEliminar = new TableHeaderCell();
            headerNombre.Text = "Nombre Equipo";
            headerImagen.Text = "Imagen";
            headerEditar.Text = "Editar";
            headerEliminar.Text = "Eliminar";

            header.Cells.Add(headerNombre);
            header.Cells.Add(headerImagen);
            header.Cells.Add(headerEditar);
            header.Cells.Add(headerEliminar);

            this.tblEquipos.Rows.Add(header);

            foreach (Equipo equipo in almacen.Equipos)
            {
                TableRow row = new TableRow();


                //celdas
                TableCell cellNombre = new TableCell(), cellImagen = new TableCell(), cellEditar = new TableCell(), cellEliminar = new TableCell();
                cellNombre.Text = equipo.Nombre;
                cellImagen.Text = equipo.DirFotografia;
                cellEditar.Text = "Pendiente";
                cellEliminar.Text = "Pendiente";

                row.Cells.Add(cellNombre);
                row.Cells.Add(cellImagen);
                row.Cells.Add(cellEditar);
                row.Cells.Add(cellEliminar);

                this.tblEquipos.Rows.Add(row);
            }
        }

    }
}