using DPWA_Lab01_Periodo01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DPWA_Lab01_Periodo01
{
    public partial class Plantel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerificarSesiones();
            CargarJugadores();
        }

        private void VerificarSesiones()
        {
            if (Session["AlmacenDatos"] == null)
            {
                Session["AlmacenDatos"] = (AlmacenDatos)new AlmacenDatos();
            }
        }

        private void CargarListaEquipos(Equipo equipoSeleccionado)
        {
            AlmacenDatos almacen = (AlmacenDatos)Session["AlmacenDatos"];

            foreach(Equipo equipo in almacen.Equipos)
            {
                ListItem li = new ListItem();
                li.Text = equipo.Nombre;
                li.Value = equipo.Codigo.ToString();

                if(equipo.Codigo == equipoSeleccionado.Codigo)
                {
                    li.Selected = true;
                }
                ddlistEquipo.Items.Add(li);
            }
        }

        private void CargarJugadores()
        {
            Equipo equipo = null;
            AlmacenDatos almacen = (AlmacenDatos)Session["AlmacenDatos"];
            if (Request.QueryString.Count > 0)
            {
                string cod = Convert.ToString(Request.QueryString["equipo"]);
                equipo = almacen.BuscarEquipo(Int16.Parse(cod));
                CargarListaEquipos(equipo);
            }


            this.tblPlantel.Rows.Clear();

            TableHeaderRow header = new TableHeaderRow();
            TableHeaderCell headerNombre = new TableHeaderCell(), 
                headerFoto = new TableHeaderCell(),
                headerPos = new TableHeaderCell(),
                headerEdad= new TableHeaderCell(),
                headerEst = new TableHeaderCell(),
                headerPeso = new TableHeaderCell(),
                headerU = new TableHeaderCell(),
                headerSalario = new TableHeaderCell(),
                headerEditar = new TableHeaderCell(), 
                headerEliminar = new TableHeaderCell();

            headerFoto.Text = "";
            headerNombre.Text = "Nombre";
            headerPos.Text = "Pos";
            headerEdad.Text = "Edad";
            headerEst.Text = "Est";
            headerPeso.Text = "Peso";
            headerU.Text = "Universidad";
            headerSalario.Text = "Salario";
            headerEditar.Text = "Editar";
            headerEliminar.Text = "Eliminar";

            header.Cells.Add(headerFoto);
            header.Cells.Add(headerNombre);
            header.Cells.Add(headerPos);
            header.Cells.Add(headerEdad);
            header.Cells.Add(headerEst);
            header.Cells.Add(headerPeso);
            header.Cells.Add(headerU);
            header.Cells.Add(headerSalario);
            header.Cells.Add(headerEditar);
            header.Cells.Add(headerEliminar);

            this.tblPlantel.Rows.Add(header);

            foreach (Jugador j in equipo.Jugadores)
            {
                TableRow row = new TableRow();

                //celdas
                TableCell cellNombre = new TableCell(),
                    cellFoto = new TableCell(),
                    cellPos = new TableCell(),
                    cellEdad = new TableCell(),
                    cellEst = new TableCell(),
                    cellPeso = new TableCell(),
                    cellU = new TableCell(),
                    cellSalario = new TableCell(),
                    cellEditar = new TableCell(), 
                    cellEliminar = new TableCell();

                cellFoto.Text = string.Format("<img width='50px' height='50px' src='{0}' />", j.DirFotografia);
                cellNombre.Text = j.Nombre;
                cellPos.Text = j.Posicion;
                cellEdad.Text = j.Edad.ToString();
                cellEst.Text = j.Estatura.ToString();
                cellPeso.Text = j.Peso.ToString();

                Universidad U = almacen.BuscarUniversidad(j.U);
                cellU.Text = U.Nombre;
                cellSalario.Text = "$"+j.Salario.ToString();
                cellEditar.Text = "<a class='btn btn-warning' href='Jugadores.aspx?codE="+equipo.Codigo+"&codJ=" + j.Codigo + "'><i class='fas fa-edit'></i></a>";
                cellEliminar.Text = "<a class='btn btn-primary' href='Operaciones/EliminarJugador.aspx?codE=" + equipo.Codigo + "&codJ=" + j.Codigo + "'><i class='fas fa-trash-alt'></i></a>";

                row.Cells.Add(cellFoto);
                row.Cells.Add(cellNombre);
                row.Cells.Add(cellPos);
                row.Cells.Add(cellEdad);
                row.Cells.Add(cellEst);
                row.Cells.Add(cellPeso);
                row.Cells.Add(cellU);
                row.Cells.Add(cellSalario);
                row.Cells.Add(cellEditar);
                row.Cells.Add(cellEliminar);

                this.tblPlantel.Rows.Add(row);
            }
        }

        protected void btnAgregarJugador_Click(object sender, EventArgs e)
        {
            if (Request.QueryString.Count > 0)
            {
                string cod = Convert.ToString(Request.QueryString["equipo"]);
                Response.Redirect("Jugadores.aspx?equipo="+cod);
            }
        }

        protected void ddlistEquipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cod = ddlistEquipo.SelectedValue.ToString();
            Response.Redirect("Plantel.aspx?equipo="+cod);
        }
    }
}