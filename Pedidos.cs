/*
Pedidos

Nro
Obs
Cliente
Estado
*/
using System;

namespace EspacioCadeteria;

public enum Estado{
    Proceso,Pendiente,Completado,Cancelado
}
public class Pedidos
{
    private int Nro;
    private string Obs;
    private Cliente cliente;
    private Estado estado;

    public Pedidos(int nro, string obs, Cliente cliente, Estado estado)
    {
        Nro1 = nro;
        Obs1 = obs;
        this.Cliente = cliente;
        this.Estado = estado;
    }

    public int Nro1 { get => Nro;private set => Nro = value; }
    public string Obs1 { get => Obs;private set => Obs = value; }
    public Cliente Cliente { get => cliente;private set => cliente = value; }
    public Estado Estado { get => estado;private set => estado = value; }

    public void VerDireccionCliente(Cliente cliente){
        Console.WriteLine($"Cliente direccion: {cliente.Direcion1}");
    }

    public void VerDatosCliente(Cliente cliente){
        Console.WriteLine($"Cliente nombre: {cliente.Nombre1}");
        Console.WriteLine($"Cliente telefono: {cliente.Telefono1}");
    }

    public void CambiarEstado(Estado nuevoEstado)
    {
        this.Estado = nuevoEstado;
    }
}