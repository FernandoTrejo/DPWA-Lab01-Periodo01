using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DPWA_Lab01_Periodo01.Models
{
    public class AlmacenDatos
    {
        private List<Universidad> universidades;
        private List<Equipo> equipos;

        public AlmacenDatos()
        {
            Universidades = new List<Universidad>();
            Equipos = new List<Equipo>();
        }

        public void AgregarEquipo(Equipo equipo)
        {
            Equipos.Add(equipo);
        }

        public void EliminarEquipo(Equipo equipo)
        {
            Equipos.Remove(equipo);
        }

        public int AgregarUniversidad(Universidad u)
        {
            if (this.ExisteUniversidad(u.Nombre))
            {
                return 0;
            }

            u.Codigo = this.ObtenerNuevoCodigoU();
            Universidades.Add(u);
            return 1;
        }

        public int EliminarUniversidad(Universidad u)
        {
            if (this.ExisteUniversidad(u.Nombre))
            {
                Universidades.Remove(u);
                return 1;
            }

            return 0;
        }

        public bool ExisteUniversidad(string nombre)
        {
            Universidad u = this.Universidades.Find(x => x.Nombre.ToUpper() == nombre.ToUpper());
            return u != null;
        }

        public Universidad BuscarUniversidad(string nombre)
        {
            Universidad u = this.Universidades.Find(x => x.Nombre.ToUpper() == nombre.ToUpper());
            return u;
        }

        public Universidad BuscarUniversidad(int cod)
        {
            Universidad u = this.Universidades.Find(x => x.Codigo == cod);
            return u;
        }


        public int ObtenerNuevoCodigoU()
        {
            if(this.Universidades.Count > 0)
            {
                Universidad u = this.Universidades.Last();
                return u.Codigo + 1;
            }
            else
            {
                return 0;
            }
            
        }

        public List<Universidad> Universidades { get => universidades; set => universidades = value; }
        public List<Equipo> Equipos { get => equipos; set => equipos = value; }
    }
}