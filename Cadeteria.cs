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
        /*
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Direcion1 { get => Direcion; set => Direcion = value; }
        public string Telefono1 { get => Telefono; set => Telefono = value; }
        public string DatosReferenciaDireccion1 { get => DatosReferenciaDireccion; set => DatosReferenciaDireccion = value; }
        */
        public void agregarPedido(int nroPedido, string observaciones, string nombreCliente, string direccionCliente, string telefonoCliente, string datosReferencia)
        {
            if (ListadoPedidos.Any(p => p.Nro1 == nroPedido))
            {
                throw new ArgumentException(); // Evita duplicados
            }

            Cliente cliente = new Cliente(nombreCliente, direccionCliente, telefonoCliente, datosReferencia);
            Pedidos nuevoPedido = new Pedidos(nroPedido, observaciones, cliente, Estado.Pendiente);
            ListadoPedidos.Add(nuevoPedido);
        }

        public void eliminarPedido(int nroPedido)
        {
            var pedido = listadoPedidos.FirstOrDefault(p => p.Nro1 == nroPedido);
            if (pedido != null)
            {
                listadoPedidos.Remove(pedido);
            }
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


        public void ReasignarPedido(Cadete anterior, Cadete nuevo, Pedidos pedido)
        {
            anterior.EliminarPedido(pedido);
            nuevo.AgregarPedido(pedido);
        }

        public void AgregarCadete(int idCadete, string nombre, string direccion, string telefono)
        {
            var nuevoCadete = new Cadete(idCadete, nombre,direccion, telefono);
            ListadoCadetes.Add(nuevoCadete);
        }

        public void EliminarCadete(int idCadete)
        {
            var cadete = ListadoCadetes.FirstOrDefault(c => c.Id1 == idCadete);
            if (cadete != null)
            {
                ListadoCadetes.Remove(cadete);
            }
        }
        
    }
}
