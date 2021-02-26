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

        public void AgregarUniversidad(Universidad u)
        {
            Universidades.Add(u);
        }

        public void EliminarUniversidad(Universidad u)
        {
            Universidades.Remove(u);
        }

        public List<Universidad> Universidades { get => universidades; set => universidades = value; }
        public List<Equipo> Equipos { get => equipos; set => equipos = value; }
    }
}