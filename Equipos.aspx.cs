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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregarEquipo_Click(object sender, EventArgs e)
        {
            string nombreArchivo = string.Empty;
            string destino = @"~/imagenes/";
            if (fileUpload.HasFile)
            {
                string carpetaDestino = Server.MapPath(destino);
                nombreArchivo = System.IO.Path.GetFileName(fileUpload.PostedFile.FileName);
                string locacionServidor = carpetaDestino + nombreArchivo;
                fileUpload.PostedFile.SaveAs(locacionServidor);
                imgView.ImageUrl = destino + nombreArchivo;
            }
        }
    }
}