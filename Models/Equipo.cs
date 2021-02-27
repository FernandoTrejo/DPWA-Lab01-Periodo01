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

        private const int MAX_BASE = 1;
        private const int MAX_ESCOLTA = 2;
        private const int MAX_ALERO = 3;
        private const int MAX_ALAPIVOT = 4;
        private const int MAX_PIVOT = 5;

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

            int apariciones = ObtenerCantidadPos(jugador.Posicion);
            if(!EsValidaPosicion(apariciones, jugador.Posicion))
            {
                return 2;
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

        public List<Jugador> BuscarJugadores(string pos)
        {
            List<Jugador> jugadores = this.Jugadores.FindAll(x => x.Posicion.ToUpper() == pos.ToUpper());
            return jugadores;
        }

        public Jugador BuscarJugador(int cod)
        {
            Jugador jugador = this.Jugadores.Find(x => x.Codigo == cod);
            return jugador;
        }

        public bool EsValidaPosicion(int cantidad, string pos)
        {
            switch (pos)
            {
                case "BA":
                    if(cantidad == MAX_BASE)
                    {
                        return false;
                    }
                    break;
                case "E":
                    if (cantidad == MAX_ESCOLTA)
                    {
                        return false;
                    }
                    break;
                case "SF":
                    if (cantidad == MAX_ALERO)
                    {
                        return false;
                    }
                    break;
                case "AP":
                    if (cantidad == MAX_ALAPIVOT)
                    {
                        return false;
                    }
                    break;
                case "C":
                    if (cantidad == MAX_PIVOT)
                    {
                        return false;
                    }
                    break;
            }

            return true;
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

        public int ObtenerCantidadPos(string pos)
        {
            List<Jugador> jugadores;
            switch (pos)
            {
                case "BA":
                    jugadores = this.BuscarJugadores("BA");
                    break;
                case "E":
                    jugadores = this.BuscarJugadores("E");
                    break;
                case "SF":
                    jugadores = this.BuscarJugadores("SF");
                    break;
                case "AP":
                    jugadores = this.BuscarJugadores("AP");
                    break;
                case "C":
                    jugadores = this.BuscarJugadores("C");
                    break;
                default:
                    jugadores = new List<Jugador>();
                    break;
            }

            return jugadores.Count;
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