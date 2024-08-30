/*
Cliente

Nombre
Direcion
Telefono
DatosReferenciaDireccion
*/
using System;

namespace EspacioCadeteria;

public class Cliente
{
    private string Nombre;
    private string Direcion;
    private string Telefono;
    private string DatosReferenciaDireccion;

    public Cliente(string nombre, string direcion, string telefono, string datosReferenciaDireccion)
    {
        Nombre1 = nombre;
        Direcion1 = direcion;
        Telefono1 = telefono;
        DatosReferenciaDireccion1 = datosReferenciaDireccion;
    }

    public string Nombre1 { get => Nombre; set => Nombre = value; }
    public string Direcion1 { get => Direcion; set => Direcion = value; }
    public string Telefono1 { get => Telefono; set => Telefono = value; }
    public string DatosReferenciaDireccion1 { get => DatosReferenciaDireccion; set => DatosReferenciaDireccion = value; }
}