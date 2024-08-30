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
        ListadoPedidos1 =  new List<Pedidos>(); //Agregacion 
    }

    public int Id1 { get => Id;private set => Id = value; }
    public string Nombre1 { get => Nombre;private set => Nombre = value; }
    public string Direccion1 { get => Direccion;private set => Direccion = value; }
    public string Telefono1 { get => Telefono;private set => Telefono = value; }
    public List<Pedidos> ListadoPedidos1 { get => ListadoPedidos;private set => ListadoPedidos = value; }
}