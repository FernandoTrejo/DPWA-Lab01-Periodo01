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
            CargarUniversidades();
        }

        private void VerificarSesiones()
        {
            if (Session["AlmacenDatos"] == null)
            {
                Session["AlmacenDatos"] = (AlmacenDatos)new AlmacenDatos();
            }
        }

        private void CargarUniversidades()
        {
            Equipo equipo = null;
            AlmacenDatos almacen = (AlmacenDatos)Session["AlmacenDatos"];
            if (Request.QueryString.Count > 0)
            {
                string cod = Convert.ToString(Request.QueryString["equipo"]);
                equipo = almacen.BuscarEquipo(Int16.Parse(cod));

                equipo.AgregarJugador(new Jugador("fhefwehfeu", "Ronald", "DE", 14, 3.4,34.3,new Universidad("itca"),30202));
                equipo.AgregarJugador(new Jugador("jgjerie", "Fernando", "L", 15, 3.4,34.3,new Universidad("itca"),3477));
                equipo.AgregarJugador(new Jugador("ojojrg", "Gomez", "MA", 16, 3.4,34.3,new Universidad("iunicaes"),4000));
                equipo.AgregarJugador(new Jugador("jfijri", "Trejo", "LE", 17, 3.4,34.3,new Universidad("ues"),500));
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

                cellFoto.Text = string.Format("<img width='50px' height='50px' src='{0}' />", j.DirFotografia.Substring(1));
                cellNombre.Text = j.Nombre;
                cellPos.Text = j.Posicion;
                cellEdad.Text = j.Edad.ToString();
                cellEst.Text = j.Estatura.ToString();
                cellPeso.Text = j.Peso.ToString();
                cellU.Text = j.U.Nombre;
                cellSalario.Text = "$"+j.Salario.ToString();
                cellEditar.Text = "<a class='btn btn-warning' href='Jugadores.aspx?cod=" + j.Codigo + "'><i class='fas fa-edit'></i></a>";
                cellEliminar.Text = "<a class='btn btn-primary' href='Operaciones/EliminarJugador.aspx?u=" + j.Codigo + "'><i class='fas fa-trash-alt'></i></a>";

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
    }
}