using System;

namespace EspacioCadeteria;

public abstract class AccesoADatos
{
    public abstract Cadeteria Cargar(string archivoCadeteria, string archivoCadete);
    //public abstract void Guardar(List<Pedidos> pedidos, string archivoPedidos);

}
