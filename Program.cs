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

            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("Sistema de Gestión de Pedidos - Cadetería");
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Dar de alta un pedido");
                Console.WriteLine("2. Asignar pedido a un cadete");
                Console.WriteLine("3. Cambiar estado de un pedido");
                Console.WriteLine("4. Reasignar pedido a otro cadete");
                Console.WriteLine("5. Mostrar informe al finalizar la jornada");
                Console.WriteLine("6. Salir");

                Console.Write("Opción: ");
                int opcion;
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Por favor, ingrese una opción válida.");
                    Console.ReadLine();
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        DarDeAltaPedido(cadeteria);
                        break;

                    case 2:
                        AsignarPedidoACadete(cadeteria);
                        break;

                    case 3:
                        CambiarEstadoPedido(cadeteria);
                        break;

                    case 4:
                        ReasignarPedido(cadeteria);
                        break;

                    case 5:
                        MostrarInforme(cadeteria);
                        break;

                    case 6:
                        salir = true;
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Presione Enter para intentar nuevamente.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void DarDeAltaPedido(Cadeteria cadeteria)
        {
            Console.WriteLine("Dar de alta un pedido");

            Console.Write("Ingrese el número del pedido: ");
            int nroPedido;
            while (!int.TryParse(Console.ReadLine(), out nroPedido))
            {
                Console.WriteLine("Número de pedido inválido. Intente nuevamente.");
            }

            Console.Write("Ingrese las observaciones del pedido: ");
            string observaciones = Console.ReadLine();

            Console.Write("Ingrese el nombre del cliente: ");
            string nombreCliente = Console.ReadLine();

            Console.Write("Ingrese la dirección del cliente: ");
            string direccionCliente = Console.ReadLine();

            Console.Write("Ingrese el teléfono del cliente: ");
            string telefonoCliente = Console.ReadLine();

            Console.Write("Ingrese los datos de referencia de la dirección del cliente: ");
            string datosReferencia = Console.ReadLine();

            // Crear el pedido con los datos proporcionados
            cadeteria.agregarPedido(nroPedido, observaciones, nombreCliente, direccionCliente, telefonoCliente, datosReferencia);
            Console.WriteLine("Pedido creado exitosamente. Presione Enter para continuar.");
            Console.ReadLine();
        }

        static void AsignarPedidoACadete(Cadeteria cadeteria)
        {
            Console.Write("Ingrese el número del pedido para asignar: ");
            int nroPedido;
            while (!int.TryParse(Console.ReadLine(), out nroPedido))
            {
                Console.WriteLine("Número de pedido inválido. Intente nuevamente.");
            }

            Console.WriteLine("Seleccione un cadete para asignar el pedido:");
            for (int i = 0; i < cadeteria.ListadoCadetes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cadeteria.ListadoCadetes[i].Nombre1}");
            }

            int idCadete;
            while (!int.TryParse(Console.ReadLine(), out idCadete) || idCadete < 1 || idCadete > cadeteria.ListadoCadetes.Count)
            {
                Console.WriteLine("Selección inválida. Intente nuevamente.");
            }

            cadeteria.AsignarPedido(idCadete, nroPedido);
            Console.WriteLine("Pedido asignado exitosamente. Presione Enter para continuar.");
            Console.ReadLine();
        }

        static void CambiarEstadoPedido(Cadeteria cadeteria)
        {
            Console.Write("Ingrese el número del pedido para cambiar su estado: ");
            int nroPedido = int.Parse(Console.ReadLine());

            Console.WriteLine("Seleccione el nuevo estado del pedido:");
            Console.WriteLine("1. Pendiente");
            Console.WriteLine("2. En proceso");
            Console.WriteLine("3. Completado");
            Console.WriteLine("4. Cancelado");

            int estadoSeleccionado = int.Parse(Console.ReadLine());
            Estado nuevoEstado;

            switch (estadoSeleccionado)
            {
                case 1:
                    nuevoEstado = Estado.Pendiente;
                    break;
                case 2:
                    nuevoEstado = Estado.Proceso;
                    break;
                case 3:
                    nuevoEstado = Estado.Completado;
                    break;
                case 4:
                    nuevoEstado = Estado.Cancelado;
                    break;
                default:
                    Console.WriteLine("Estado no válido. Operación cancelada.");
                    return;
            }

            // Busca el pedido por su número en el listado de pedidos de la cadetería
            var pedido = cadeteria.ListadoPedidos.FirstOrDefault(p => p.Nro1 == nroPedido);
            if (pedido != null)
            {
                pedido.CambiarEstado(nuevoEstado); // Cambia el estado del pedido
                Console.WriteLine($"El estado del pedido {nroPedido} ha sido cambiado a {nuevoEstado}. Presione Enter para continuar.");
            }
            else
            {
                Console.WriteLine("Pedido no encontrado. Presione Enter para continuar.");
            }
            Console.ReadLine();
        }



        static void ReasignarPedido(Cadeteria cadeteria)
        {
            Console.Write("Ingrese el número del pedido para reasignar: ");
            int nroPedido;
            while (!int.TryParse(Console.ReadLine(), out nroPedido))
            {
                Console.WriteLine("Número de pedido inválido. Intente nuevamente.");
            }

            Console.WriteLine("Seleccione el cadete actual:");
            for (int i = 0; i < cadeteria.ListadoCadetes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cadeteria.ListadoCadetes[i].Nombre1}");
            }

            int idCadeteActual;
            while (!int.TryParse(Console.ReadLine(), out idCadeteActual) || idCadeteActual < 1 || idCadeteActual > cadeteria.ListadoCadetes.Count)
            {
                Console.WriteLine("Selección inválida. Intente nuevamente.");
            }

            Console.WriteLine("Seleccione el nuevo cadete:");
            for (int i = 0; i < cadeteria.ListadoCadetes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cadeteria.ListadoCadetes[i].Nombre1}");
            }

            int idNuevoCadete;
            while (!int.TryParse(Console.ReadLine(), out idNuevoCadete) || idNuevoCadete < 1 || idNuevoCadete > cadeteria.ListadoCadetes.Count)
            {
                Console.WriteLine("Selección inválida. Intente nuevamente.");
            }

            cadeteria.ReasignarPedido(idCadeteActual, idNuevoCadete, nroPedido);
            Console.WriteLine("Pedido reasignado exitosamente. Presione Enter para continuar.");
            Console.ReadLine();
        }

        static void MostrarInforme(Cadeteria cadeteria)
        {
            Console.WriteLine("Informe de Pedidos:");
            foreach (var cadete in cadeteria.ListadoCadetes)
            {
                Console.WriteLine($"Cadete: {cadete.Nombre1}");
                Console.WriteLine($"Jornal a cobrar: {cadeteria.JornalACobrar(cadete.Id1)}");
                Console.WriteLine("Pedidos asignados:");
                foreach (var pedido in cadete.ListadoPedidos1)
                {
                    Console.WriteLine($"- Pedido N° {pedido.Nro1}, Estado: {pedido.Estado}");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Presione Enter para continuar.");
            Console.ReadLine();
        }
    }
}
