using System;
using System.Collections.Generic;

namespace EspacioCadeteria
{
    public class Cadeteria
    {
        private string nombre;
        private string telefono;
        private List<Cadete> listadoCadetes;

        public Cadeteria(string nombre, string telefono)
        {
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.ListadoCadetes = new List<Cadete>();
        }

        public string Nombre { get => nombre; private set => nombre = value; }
        public string Telefono { get => telefono; private set => telefono = value; }
        public List<Cadete> ListadoCadetes { get => listadoCadetes; private set => listadoCadetes = value; }

        public void AsignarPedido(Cadete cadete, Pedidos pedido)
        {
            cadete.AgregarPedido(pedido);
        }

        public void ReasignarPedido(Cadete anterior, Cadete nuevo, Pedidos pedido)
        {
            anterior.EliminarPedido(pedido);
            nuevo.AgregarPedido(pedido);
        }

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
