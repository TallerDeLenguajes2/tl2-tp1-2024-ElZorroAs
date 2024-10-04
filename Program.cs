using System;
using System.Linq;
using System.Collections.Generic;

namespace EspacioCadeteria
{
    class Program
    {
        static void Main(string[] args)
        {
            AccesoADatos cargador = null;

            // Preguntar al usuario si desea usar CSV o JSON
            Console.WriteLine("Seleccione el formato de datos:");
            Console.WriteLine("1. CSV");
            Console.WriteLine("2. JSON");
            Console.Write("Opción: ");
            int opcion;
            while (!int.TryParse(Console.ReadLine(), out opcion) || (opcion < 1 || opcion > 2))
            {
                Console.WriteLine("Por favor, ingrese una opción válida (1 o 2).");
            }

            // Crear el cargador correspondiente
            if (opcion == 1)
            {
                cargador = new AccesoCSV();
            }
            else if (opcion == 2)
            {
                cargador = new AccesoJSON();
            }

            // Cargar los datos de la cadetería y los cadetes
            Cadeteria cadeteria = null;

            // Especificar las rutas de los archivos según el formato elegido
            string archivoCadeteria = opcion == 1 ? "csv/cadeteria.csv" : "json/cadeteria.json";
            string archivoCadete = opcion == 1 ? "csv/cadete.csv" : "json/cadete.json";

            // Cargar los datos
            cadeteria = cargador.Cargar(archivoCadeteria, archivoCadete);

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
                int Opcion;
                if (!int.TryParse(Console.ReadLine(), out Opcion))
                {
                    Console.WriteLine("Por favor, ingrese una opción válida.");
                    Console.ReadLine();
                    continue;
                }

                switch (Opcion)
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
            int nro;
            while (!int.TryParse(Console.ReadLine(), out nro))
            {
                Console.WriteLine("Número de pedido inválido. Intente nuevamente.");
            }

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

            // Crear cliente y pedido
            Cliente cliente = new Cliente(nombreCliente, direccionCliente, telefonoCliente, datosReferencia);
            Pedidos pedido = new Pedidos(nro, obs, cliente, Estado.Pendiente);

            // Añadir el pedido a la lista de pedidos de la cadetería
            cadeteria.agregarPedido(pedido);
            Console.WriteLine($"Pedido {nro} creado y agregado a la lista de pedidos.");
            Console.WriteLine("Presione Enter para continuar.");
            Console.ReadLine();
        }


        static void AsignarPedidoACadete(Cadeteria cadeteria)
        {
            Console.Write("Ingrese el número del pedido para asignar: ");
            int nroPedidoAsignar = int.Parse(Console.ReadLine());
            Pedidos pedidoParaAsignar = cadeteria.ListadoPedidos.FirstOrDefault(p => p.Nro1 == nroPedidoAsignar);

            if (pedidoParaAsignar == null)
            {
                Console.WriteLine("Pedido no encontrado. Presione Enter para continuar.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Seleccione un cadete para asignar el pedido:");
            for (int i = 0; i < cadeteria.ListadoCadetes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cadeteria.ListadoCadetes[i].Nombre1}");
            }

            int indiceCadeteAsignar = int.Parse(Console.ReadLine()) - 1;
            if (indiceCadeteAsignar >= 0 && indiceCadeteAsignar < cadeteria.ListadoCadetes.Count)
            {
                Cadete cadeteAsignado = cadeteria.ListadoCadetes[indiceCadeteAsignar];
                cadeteria.AsignarPedido(cadeteAsignado.Id1, pedidoParaAsignar.Nro1);
                Console.WriteLine("Pedido asignado exitosamente. Presione Enter para continuar.");
            }
            else
            {
                Console.WriteLine("Selección de cadete inválida. Presione Enter para continuar.");
            }
            Console.ReadLine();
        }

        static void CambiarEstadoPedido(Cadeteria cadeteria)
        {
            Console.Write("Ingrese el número del pedido para cambiar su estado: ");
            int nroPedido = int.Parse(Console.ReadLine());

            Console.WriteLine("Seleccione el nuevo estado del pedido:");
            Console.WriteLine("1. Pendiente");
            Console.WriteLine("2. En proceso");
            Console.WriteLine("3. Entregado");

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
                default:
                    Console.WriteLine("Estado no válido. Operación cancelada.");
                    return;
            }

            // Se debe buscar el pedido
            var pedido = cadeteria.ListadoPedidos.FirstOrDefault(p => p.Nro1 == nroPedido);
            if (pedido != null)
            {
                pedido.CambiarEstado(nuevoEstado);
                Console.WriteLine($"Estado del pedido {nroPedido} cambiado a {nuevoEstado}. Presione Enter para continuar.");
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
            int nroPedidoReasignar = int.Parse(Console.ReadLine());
            Pedidos pedidoParaReasignar = cadeteria.ListadoPedidos.FirstOrDefault(p => p.Nro1 == nroPedidoReasignar);

            if (pedidoParaReasignar == null)
            {
                Console.WriteLine("Pedido no encontrado. Presione Enter para continuar.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Seleccione el cadete actual:");
            for (int i = 0; i < cadeteria.ListadoCadetes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cadeteria.ListadoCadetes[i].Nombre1}");
            }

            int indiceCadeteActual = int.Parse(Console.ReadLine()) - 1;
            Cadete cadeteActual = cadeteria.ListadoCadetes[indiceCadeteActual];

            Console.WriteLine("Seleccione el nuevo cadete:");
            for (int i = 0; i < cadeteria.ListadoCadetes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cadeteria.ListadoCadetes[i].Nombre1}");
            }

            int indiceNuevoCadete = int.Parse(Console.ReadLine()) - 1;
            Cadete nuevoCadete = cadeteria.ListadoCadetes[indiceNuevoCadete];

            if (cadeteActual != null && nuevoCadete != null)
            {
                cadeteria.AsignarPedido(nuevoCadete.Id1, pedidoParaReasignar.Nro1);
                Console.WriteLine($"Pedido {nroPedidoReasignar} reasignado exitosamente de {cadeteActual.Nombre1} a {nuevoCadete.Nombre1}. Presione Enter para continuar.");
            }
            else
            {
                Console.WriteLine("Error al reasignar el pedido. Presione Enter para continuar.");
            }
            Console.ReadLine();
        }

        static void MostrarInforme(Cadeteria cadeteria)
        {
            Console.WriteLine("Informe de Pedidos:");

            // Iteramos sobre cada cadete en la cadeteria
            foreach (var cadete in cadeteria.ListadoCadetes)
            {
                Console.WriteLine($"Cadete: {cadete.Nombre1}");

                // Calculamos el jornal a cobrar para este cadete usando su ID
                Console.WriteLine($"Jornal a cobrar: {cadeteria.JornalACobrar(cadete.Id1)}");

                // Filtramos los pedidos asignados a este cadete en la lista de pedidos de la cadeteria
                var pedidosAsignados = cadeteria.ListadoPedidos.Where(p => p.Cadete != null && p.Cadete.Id1 == cadete.Id1).ToList();

                // Mostramos los pedidos asignados a este cadete
                if (pedidosAsignados.Any())
                {
                    Console.WriteLine("Pedidos asignados:");
                    foreach (var pedido in pedidosAsignados)
                    {
                        Console.WriteLine($"- Pedido N° {pedido.Nro1}, Estado: {pedido.Estado}");
                    }
                }
                else
                {
                    Console.WriteLine("No tiene pedidos asignados.");
                }

                Console.WriteLine(); // Salto de línea para separar informes de diferentes cadetes
            }

            Console.WriteLine("Presione Enter para continuar.");
            Console.ReadLine();
        }

    }
}
