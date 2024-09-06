/*
Cadeteria

Id
Nombre
Direccion
Telefono
ListadoPedidos

JornalACobrar()
*/
using System;

namespace EspacioCadeteria;

public class Cadete
{
    private int Id;
    private string Nombre;
    private string Direccion;
    private string Telefono;
    private List<Pedidos> ListadoPedidos;

    public Cadete(int id, string nombre, string direccion, string telefono, List<Pedidos> listadoPedidos)
    {
        Id1 = id;
        Nombre1 = nombre;
        Direccion1 = direccion;
        Telefono1 = telefono;
        ListadoPedidos1 = new List<Pedidos>(); //Agregacion 
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
    public void ListarPedidos(Pedidos pedidos)
    {
        Console.WriteLine("Pedidos:");
        foreach (var pedido in ListadoPedidos1)
        {
            Console.WriteLine($"Nro:{pedido.Nro1},Obs:{pedido.Obs1},Cliente:{pedido.Cliente},Estado:{pedido.Estado}");
        }
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