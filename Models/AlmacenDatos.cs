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

        public AlmacenDatos(List<Universidad> universidades, List<Equipo> equipos)
        {
            Universidades = universidades;
            Equipos = equipos;
        }

        public List<Universidad> Universidades { get => universidades; set => universidades = value; }
        public List<Equipo> Equipos { get => equipos; set => equipos = value; }
    }
}