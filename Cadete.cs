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
       
        

        public void AgregarPedido(Pedidos pedido)
        {
            ListadoPedidos1.Add(pedido);
        }

        public void EliminarPedido(Pedidos pedido)
        {
            if (ListadoPedidos1.Contains(pedido))
            {
                ListadoPedidos1.Remove(pedido);
            }
        }

        public void CambiarEstadoPedido(int nroPedido, Estado nuevoEstado)
        {
            var pedido = ListadoPedidos1.FirstOrDefault(p => p.Nro1 == nroPedido);
            if (pedido != null)
            {
                pedido.CambiarEstado(nuevoEstado);
            }
        }
    }
}
