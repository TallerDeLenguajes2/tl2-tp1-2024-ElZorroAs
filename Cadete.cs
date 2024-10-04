using System;
using System.Collections.Generic;
using System.Linq;

namespace EspacioCadeteria
{
    public class Cadete
    {
        private int Id;
        private string Nombre;
        private string Direccion;
        private string Telefono;
        

        public Cadete()
        {
            // Constructor vacío
            
        }

        public Cadete(int id, string nombre, string direccion, string telefono)
        {
            Id1 = id;
            Nombre1 = nombre;
            Direccion1 = direccion;
            Telefono1 = telefono;
            
        }

        public int Id1 { get => Id; private set => Id = value; }
        public string Nombre1 { get => Nombre; private set => Nombre = value; }
        public string Direccion1 { get => Direccion; private set => Direccion = value; }
        public string Telefono1 { get => Telefono; private set => Telefono = value; }
       
    }
}
