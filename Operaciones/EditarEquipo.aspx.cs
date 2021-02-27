using DPWA_Lab01_Periodo01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DPWA_Lab01_Periodo01.Operaciones
{
    public partial class EditarEquipo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerificarSesiones();

            string codE = Convert.ToString(Request.QueryString["equipo"]);
            string nombre = Convert.ToString(Request.QueryString["nombre"]);
            string dirFoto = Convert.ToString(Request.QueryString["dirFoto"]);

            AlmacenDatos almacen = (AlmacenDatos)Session["AlmacenDatos"];
            Equipo equ = almacen.BuscarEquipo(Int16.Parse(codE));
            
            equ.Nombre = nombre;
            equ.DirFotografia = dirFoto;

            Session["AlmacenDatos"] = almacen;
            Response.Redirect("../Equipos.aspx");
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