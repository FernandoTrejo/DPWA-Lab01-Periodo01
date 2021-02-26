using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DPWA_Lab01_Periodo01.Models
{
    public class Equipo
    {
        private int codigo;
        private string dirFotografia;
        private string nombre;
        private List<Jugador> jugadores;
        private const int MAX_JUGADORES = 15;
        private const int MIN_JUGADORES = 5;

        public Equipo(string dirFotografia, string nombre)
        {
            DirFotografia = dirFotografia;
            Nombre = nombre;
            Jugadores = new List<Jugador>();
        }

        public int AgregarJugador(Jugador jugador)
        {
            if (EquipoEstaCompleto())
            {
                return 0;
            }

            jugador.Codigo = ObtenerNuevoCodigoJugador();
            Jugadores.Add(jugador);
            return 1;
        }

        public void EliminarJugador(Jugador jugador)
        {
            Jugadores.Remove(jugador);
        }

        public bool EquipoEstaCompleto()
        {
            return this.Jugadores.Count == MAX_JUGADORES;
        }

        public bool ExisteJugador(string nombre)
        {
            Jugador jugador = this.Jugadores.Find(x => x.Nombre.ToUpper() == nombre.ToUpper());
            return jugador != null;
        }

        public Jugador BuscarJugador(string nombre)
        {
            Jugador jugador = this.Jugadores.Find(x => x.Nombre.ToUpper() == nombre.ToUpper());
            return jugador;
        }

        public Jugador BuscarJugador(int cod)
        {
            Jugador jugador = this.Jugadores.Find(x => x.Codigo == cod);
            return jugador;
        }

        public int ObtenerNuevoCodigoJugador()
        {
            if (this.Jugadores.Count > 0)
            {
                Jugador jugador = this.Jugadores.Last();
                return jugador.Codigo + 1;
            }
            else
            {
                return 0;
            }

        }


        public bool EquipoEstaIncompleto()
        {
            return this.Jugadores.Count < MIN_JUGADORES;
        }

        public string DirFotografia { get => dirFotografia; set => dirFotografia = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public List<Jugador> Jugadores { get => jugadores; set => jugadores = value; }
        public int Codigo { get => codigo; set => codigo = value; }
    }
}