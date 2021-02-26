using DPWA_Lab01_Periodo01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DPWA_Lab01_Periodo01.Operaciones
{
    public partial class EliminarJugador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerificarSesiones();

            string codE = Convert.ToString(Request.QueryString["codE"]);
            string codJ = Convert.ToString(Request.QueryString["codJ"]);

            AlmacenDatos almacen = (AlmacenDatos)Session["AlmacenDatos"];
            Equipo equ = almacen.BuscarEquipo(Int16.Parse(codE));
            Jugador j = equ.BuscarJugador(Int16.Parse(codJ));
            equ.EliminarJugador(j);

            Session["AlmacenDatos"] = almacen;
            Response.Redirect("../Plantel.aspx?equipo="+codE);
        }

        private void VerificarSesiones()
        {
            if (Session["AlmacenDatos"] == null)
            {
                Session["AlmacenDatos"] = (AlmacenDatos)new AlmacenDatos();
            }
        }
    }
}