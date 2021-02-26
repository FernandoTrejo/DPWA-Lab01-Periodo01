using DPWA_Lab01_Periodo01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DPWA_Lab01_Periodo01.Operaciones
{
    public partial class EditarJugador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerificarSesiones();
            Response.Write("<script>alert(hola);</script>");
            string codE = Convert.ToString(Request.QueryString["equipo"]);
            string codJ = Convert.ToString(Request.QueryString["jugador"]);

            string nombre = Convert.ToString(Request.QueryString["nombre"]);
            string dirFoto = Convert.ToString(Request.QueryString["dirFoto"]);
            string pos = Convert.ToString(Request.QueryString["pos"]);
            string edad = Convert.ToString(Request.QueryString["edad"]);
            string estatura = Convert.ToString(Request.QueryString["estatura"]);
            string peso = Convert.ToString(Request.QueryString["peso"]);
            string codU = Convert.ToString(Request.QueryString["codU"]);
            string salario = Convert.ToString(Request.QueryString["salario"]);

            AlmacenDatos almacen = (AlmacenDatos)Session["AlmacenDatos"];
            Equipo equ = almacen.BuscarEquipo(Int16.Parse(codE));
            Jugador j = equ.BuscarJugador(Int16.Parse(codJ));

            j.DirFotografia = dirFoto;
            j.Nombre = nombre;
            j.Posicion = pos;

            j.Edad = Int16.Parse(edad);
            j.Estatura = Double.Parse(estatura);
            j.Peso = Double.Parse(peso);
            j.U = Int16.Parse(codU);
            j.Salario = Double.Parse(salario);

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