using DPWA_Lab01_Periodo01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DPWA_Lab01_Periodo01
{
    public partial class Jugadores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerificarSesiones();
            VerificarExistenciaEditar();
            if (!this.IsPostBack)
            {
                CargarListaU();
            }
        }

        private void VerificarExistenciaEditar()
        {
            if (Request.QueryString.Count > 1)
            {
                string codE = Convert.ToString(Request.QueryString["codE"]);
                string codJ = Convert.ToString(Request.QueryString["codJ"]);

                AlmacenDatos almacen = (AlmacenDatos)Session["AlmacenDatos"];
                Equipo equ = almacen.BuscarEquipo(Int16.Parse(codE));
                Jugador j = equ.BuscarJugador(Int16.Parse(codJ));

                imgView.ImageUrl = j.DirFotografia;
                txtNombre.Text = j.Nombre;
                txtEdad.Text = j.Edad.ToString();
                txtEstatura.Text = j.Estatura.ToString();
                txtPeso.Text = j.Peso.ToString();
                txtSalario.Text = j.Salario.ToString();
                ddlisPos.SelectedValue = j.Posicion;
                ddlistU.SelectedValue = j.U.ToString();

                btnAgregarEquipo.Visible = false;
                btnEditarJugador.Visible = true;
            }
        }
        private void VerificarSesiones()
        {
            if (Session["AlmacenDatos"] == null)
            {
                Session["AlmacenDatos"] = (AlmacenDatos)new AlmacenDatos();
            }
        }

        private void CargarListaU()
        {
            ddlistU.Items.Clear();

            AlmacenDatos almacen = (AlmacenDatos)Session["AlmacenDatos"];
            //agregar primer elemento

            foreach (Universidad u in almacen.Universidades)
            {
                ListItem li = new ListItem();
                li.Text = u.Nombre;
                li.Value = u.Codigo.ToString();
                ddlistU.Items.Add(li);
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

        protected void btnAgregarEquipo_Click(object sender, EventArgs e)
        {
            string dirFoto = imgView.ImageUrl.Substring(1);
            string nombre = txtNombre.Text.Trim();
            string pos = ddlisPos.SelectedValue.ToString();

            int edad = Int16.Parse(txtEdad.Text.Trim());
            double estatura = Double.Parse(txtEstatura.Text.Trim());
            double peso = Double.Parse(txtPeso.Text.Trim());
            int codU = Int16.Parse(ddlistU.SelectedValue.ToString());
            double salario = Double.Parse(txtSalario.Text.Trim());

            Jugador jugador = new Jugador(dirFoto,nombre,pos,edad,estatura,peso,codU,salario);

            AlmacenDatos almacen = (AlmacenDatos)Session["AlmacenDatos"];
            Equipo equipo = null;
            if (Request.QueryString.Count > 0)
            {
                string codEquipo = Convert.ToString(Request.QueryString["equipo"]);
                equipo = almacen.BuscarEquipo(Int16.Parse(codEquipo));

                int respuesta = equipo.AgregarJugador(jugador);

                if(respuesta == 1)
                {
                    Session["AlmacenDatos"] = almacen;
                    Response.Redirect("Plantel.aspx?equipo=" + equipo.Codigo);
                }
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            
        }
    }
}