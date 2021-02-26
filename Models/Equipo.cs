using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DPWA_Lab01_Periodo01.Models
{
    public class Equipo
    {
        private string dirFotografia;
        private string nombre;
        private List<Jugador> jugadores;
        private const int MAX_JUGADORES = 15;
        private const int MIN_JUGADORES = 15;

        public Equipo(string dirFotografia, string nombre)
        {
            DirFotografia = dirFotografia;
            Nombre = nombre;
            Jugadores = new List<Jugador>();
        }

        public void AgregarJugador(Jugador jugador)
        {
            Jugadores.Add(jugador);
        }

        public void EliminarJugador(Jugador jugador)
        {
            Jugadores.Remove(jugador);
        }

        public string DirFotografia { get => dirFotografia; set => dirFotografia = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public List<Jugador> Jugadores { get => jugadores; set => jugadores = value; }
    }
}