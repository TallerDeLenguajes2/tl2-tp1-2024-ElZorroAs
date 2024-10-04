using System;
using System.Linq;
using System.Collections.Generic;

namespace EspacioCadeteria
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cargar los datos de la cadetería y los cadetes
            CargarCadeteria cargador = new CargarCadeteria();
            Cadeteria cadeteria = cargador.Cargar("csv/cadeteria.csv", "csv/cadete.csv");

            
        }

        /*
         C) El sistema posee una interfaz de consola para gestión de pedidos para realizar las
        siguientes operaciones:
        
        b) asignarlos a cadetes
        c) cambiarlos de estado
        d) reasignar el pedido a otro cadete.
        */

        //a) dar de alta pedidos
        static void DarDeAltaPedido(Cadeteria cadeteria)
{
    Console.WriteLine("Dar de alta un pedido");

    Console.Write("Ingrese el número del pedido: ");
    int nro = int.Parse(Console.ReadLine());

    Console.Write("Ingrese las observaciones del pedido: ");
    string obs = Console.ReadLine();

    Console.Write("Ingrese el nombre del cliente: ");
    string nombreCliente = Console.ReadLine();

    Console.Write("Ingrese la dirección del cliente: ");
    string direccionCliente = Console.ReadLine();

    Console.Write("Ingrese el teléfono del cliente: ");
    string telefonoCliente = Console.ReadLine();

    Console.Write("Ingrese los datos de referencia de la dirección del cliente: ");
    string datosReferencia = Console.ReadLine();

    Cliente cliente = new Cliente(nombreCliente, direccionCliente, telefonoCliente, datosReferencia);
    Pedidos pedido = new Pedidos(nro, obs, cliente, Estado.Pendiente);

    // Mostrar los cadetes disponibles
    Console.WriteLine("Seleccione un cadete para asignarle el pedido:");
    for (int i = 0; i < cadeteria.Cadetes.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {cadeteria.Cadetes[i].Nombre} (ID: {cadeteria.Cadetes[i].Id})");
    }

    // Obtener la elección del usuario
    int seleccionCadete = int.Parse(Console.ReadLine()) - 1;

    if (seleccionCadete >= 0 && seleccionCadete < cadeteria.Cadetes.Count)
    {
        Cadete cadeteSeleccionado = cadeteria.Cadetes[seleccionCadete];
        cadeteSeleccionado.AsignarPedido(pedido);

        Console.WriteLine($"El pedido {nro} ha sido asignado a {cadeteSeleccionado.Nombre}.");
    }
    else
    {
        Console.WriteLine("Selección inválida. No se pudo asignar el pedido.");
    }

    Console.WriteLine("Pedido creado exitosamente. Presione Enter para continuar.");
    Console.ReadLine();
}

/*
 D) Mostrar un informe de pedidos al finalizar la jornada que incluya el monto ganado
 y la cantidad de envíos de cada cadete y el total. Muestre también la cantidad de
 envíos promedio por cadete.
*/
        static void MostrarInforme(Cadeteria cadeteria)
        {
            Console.WriteLine("Informe de pedidos al finalizar la jornada");

            var informeCadetes = cadeteria.ListadoCadetes.Select(c => new
            {
                Cadete = c,
                CantidadEnvios = c.ListaPedidos.Count,
                MontoGanado = c.JornalACobrar()
            }).ToList();

            foreach (var item in informeCadetes)
            {
                Console.WriteLine($"Cadete: {item.Cadete.Nombre}, Cantidad de envíos: {item.CantidadEnvios}, Monto ganado: {item.MontoGanado}");
            }

            var totalEnvios = informeCadetes.Sum(x => x.CantidadEnvios);
            var totalGanado = informeCadetes.Sum(x => x.MontoGanado);
            var promedioEnvios = totalEnvios / (double)informeCadetes.Count;

            Console.WriteLine($"Total de envíos: {totalEnvios}");
            Console.WriteLine($"Monto total ganado: {totalGanado}");
            Console.WriteLine($"Promedio de envíos por cadete: {promedioEnvios}");

            Console.WriteLine("Presione Enter para continuar.");
            Console.ReadLine();
        }
    }
}