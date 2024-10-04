using System;
using System.Collections.Generic;

namespace EspacioCadeteria
{
    public class Cadeteria
    {
        private string nombre;
        private string telefono;
        private List<Cadete> listadoCadetes;
        private List<Pedidos> listadoPedidos;


        public Cadeteria(string nombre, string telefono)
        {
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.ListadoCadetes = new List<Cadete>();
            this.ListadoPedidos = new List<Pedidos>();

        }

        public string Nombre { get => nombre; private set => nombre = value; }
        public string Telefono { get => telefono; private set => telefono = value; }
        public List<Cadete> ListadoCadetes { get => listadoCadetes; private set => listadoCadetes = value; }
        public List<Pedidos> ListadoPedidos
        {
            get => listadoPedidos;
            private set => listadoPedidos = value;
        }

        public void agregarPedido(Pedidos pedido)
        {
            ListadoPedidos.Add(pedido);
        }
        public void eliminarPedido(Pedidos pedido)
        {
            ListadoPedidos.Remove(pedido);
        }

        public void AsignarPedido(int idCadete, int nroPedido)
        {
            var cadete = ListadoCadetes.FirstOrDefault(c => c.Id1 == idCadete);
            var pedido = ListadoPedidos.FirstOrDefault(c => c.Nro1 == nroPedido);
            if (cadete != null && pedido != null)
            {
                pedido.asignarCadete(cadete);
            }
        }

        public double JornalACobrar(int idCadete)
        {
            var pedidosDelCadete = ListadoPedidos.Where(p =>
                p.Cadete != null && p.Cadete.Id1 == idCadete && p.Estado == Estado.Completado
            );
            return pedidosDelCadete.Count() * 500;
        }

/*
        public void ReasignarPedido(Cadete anterior, Cadete nuevo, Pedidos pedido)
        {
            anterior.EliminarPedido(pedido);
            nuevo.AgregarPedido(pedido);
        }
*/
        public void AgregarCadete(Cadete cadete)
        {
            ListadoCadetes.Add(cadete);
        }

        public void EliminarCadete(Cadete cadete)
        {
            ListadoCadetes.Remove(cadete);
        }
    }
}
