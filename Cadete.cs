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
        private List<Pedidos> ListadoPedidos;

        public Cadete()
        {
            // Constructor vacío
            ListadoPedidos = new List<Pedidos>(); // Inicializa la lista de pedidos
        }

        public Cadete(int id, string nombre, string direccion, string telefono)
        {
            Id1 = id;
            Nombre1 = nombre;
            Direccion1 = direccion;
            Telefono1 = telefono;
            ListadoPedidos1 = new List<Pedidos>(); // Agregacion
        }

        public int Id1 { get => Id; private set => Id = value; }
        public string Nombre1 { get => Nombre; private set => Nombre = value; }
        public string Direccion1 { get => Direccion; private set => Direccion = value; }
        public string Telefono1 { get => Telefono; private set => Telefono = value; }
        public List<Pedidos> ListadoPedidos1 { get => ListadoPedidos; private set => ListadoPedidos = value; }

        public double JornalACobrar(double montoPorPedido = 100)
        {
            if (ListadoPedidos == null || ListadoPedidos.Count == 0)
                return 0;

            // Contar solo los pedidos que están completados
            int pedidosCompletados = ListadoPedidos.Count(pedido => pedido.Estado == Estado.Completado);
            return pedidosCompletados * montoPorPedido;
        }

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
