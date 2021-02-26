using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DPWA_Lab01_Periodo01.Models
{
    public class Jugador
    {
        private string dirFotografia;
        private string nombre;
        private string posicion;
        private int edad;
        private double estatura;
        private double peso;
        private Universidad u;

        public Jugador(string dirFotografia, string nombre, string posicion, int edad, double estatura, double peso, Universidad u)
        {
            DirFotografia = dirFotografia;
            Nombre = nombre;
            Posicion = posicion;
            Edad = edad;
            Estatura = estatura;
            Peso = peso;
            U = u;
        }

        public string DirFotografia { get => dirFotografia; set => dirFotografia = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Posicion { get => posicion; set => posicion = value; }
        public int Edad { get => edad; set => edad = value; }
        public double Estatura { get => estatura; set => estatura = value; }
        public double Peso { get => peso; set => peso = value; }
        public Universidad U { get => u; set => u = value; }
    }
}