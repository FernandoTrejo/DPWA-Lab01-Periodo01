using DPWA_Lab01_Periodo01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DPWA_Lab01_Periodo01
{
    public partial class Universidades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerificarSesiones();
            VerificarExistenciaEditar();
            CargarUniversidades();
        }

        private void VerificarSesiones()
        {
            if (Session["AlmacenDatos"] == null)
            {
                Session["AlmacenDatos"] = (AlmacenDatos)new AlmacenDatos();
            }
        }

        private void VerificarExistenciaEditar()
        {
            if (Request.QueryString.Count > 0)
            {
                string codU = Convert.ToString(Request.QueryString["u"]);
                AlmacenDatos almacen = (AlmacenDatos)Session["AlmacenDatos"];
                Universidad u = almacen.BuscarUniversidad(Int16.Parse(codU));

                txtNombre.Text = u.Nombre;
                btnAgregarUniversidad.Text = "<i class='fas fa-edit'></i>&nbsp;&nbsp;Editar";
            }
        }

        private void CargarUniversidades()
        {
            AlmacenDatos almacen = (AlmacenDatos)Session["AlmacenDatos"];

            this.tblUniversidades.Rows.Clear();

            TableHeaderRow header = new TableHeaderRow();
            TableHeaderCell headerNombre = new TableHeaderCell(), headerEditar = new TableHeaderCell(), headerEliminar = new TableHeaderCell();
            headerNombre.Text = "Nombre Universidad";
            headerEditar.Text = "Editar";
            headerEliminar.Text = "Eliminar";

            header.Cells.Add(headerNombre);
            header.Cells.Add(headerEditar);
            header.Cells.Add(headerEliminar);

            this.tblUniversidades.Rows.Add(header);

            foreach (Universidad u in almacen.Universidades)
            {
                TableRow row = new TableRow();


                //celdas
                TableCell cellNombre = new TableCell(), cellEditar = new TableCell(), cellEliminar = new TableCell();
                cellNombre.Text = u.Nombre;
                cellEditar.Text = "<a class='btn btn-warning' href='Universidades.aspx?u=" + u.Codigo + "'><i class='fas fa-edit'></i></a>";
                cellEliminar.Text = "<a class='btn btn-primary' href='Operaciones/EliminarUniversidad.aspx?u=" + u.Codigo + "'><i class='fas fa-trash-alt'></i></a>";

                row.Cells.Add(cellNombre);
                row.Cells.Add(cellEditar);
                row.Cells.Add(cellEliminar);

                this.tblUniversidades.Rows.Add(row);
            }
        }

        protected void btnAgregarUniversidad_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            Response.Write("<script>alert('" + nombre + "');</script>");
            if (Request.QueryString.Count > 0)
            {
                //se esta editando un elemento
                if (nombre != "")
                {
                    string codU = Convert.ToString(Request.QueryString["u"]);
                    AlmacenDatos almacen = (AlmacenDatos)Session["AlmacenDatos"];
                    Universidad u = almacen.BuscarUniversidad(Int16.Parse(codU));

                    u.Nombre = nombre;
                    Response.Write("<script>alert('"+nombre+"');</script>");
                    Session["AlmacenDatos"] = almacen;
                }

            }
            else
            {
                //se agrega nuevo elemento
                if (nombre != "")
                {
                    AlmacenDatos almacen = (AlmacenDatos)Session["AlmacenDatos"];
                    int respuesta = almacen.AgregarUniversidad(new Universidad(nombre));
                    if (respuesta == 1)
                    {
                        //exito
                        txtNombre.Text = "";
                    }
                    else
                    {
                        //fallo
                    }

                    Session["AlmacenDatos"] = almacen;
                }
            }


            CargarUniversidades();
        }
    }
}