using AliExpress.Entidad;
using System.Collections.Generic;

namespace AliExpress.Servicio
{
    public interface ILectorArchivo
    {
        List<Pedido> ObtenerPedidos();
    }
}
