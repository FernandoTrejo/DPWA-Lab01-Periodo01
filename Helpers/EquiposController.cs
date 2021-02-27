using DPWA_Lab01_Periodo01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace DPWA_Lab01_Periodo01
{
    public class EquiposController
    {
        private HttpSessionState actualSession;

        public EquiposController(HttpSessionState actualSessionTemp)
        {
            actualSession = actualSessionTemp;
        }

        public AlmacenDatos deleteTeam(String teamId)
        {
            AlmacenDatos almacen = (AlmacenDatos)actualSession["AlmacenDatos"];

            Equipo objEquipo = almacen.BuscarEquipo(Int32.Parse(teamId));

            almacen.EliminarEquipo(objEquipo);

            return almacen;
        }
    }

    
}