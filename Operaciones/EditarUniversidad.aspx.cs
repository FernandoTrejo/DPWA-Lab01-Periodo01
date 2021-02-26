using DPWA_Lab01_Periodo01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DPWA_Lab01_Periodo01.Operaciones
{
    public partial class EditarUniversidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerificarSesiones();

            string codU = Convert.ToString(Request.QueryString["u"]);
            string nombreNuevo = Convert.ToString(Request.QueryString["nombre"]);

            AlmacenDatos almacen = (AlmacenDatos)Session["AlmacenDatos"];
            Universidad u = almacen.BuscarUniversidad(Int16.Parse(codU));
            u.Nombre = nombreNuevo;

            Session["AlmacenDatos"] = almacen;
            Response.Redirect("../Universidades.aspx");
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