using AliExpress.Entidad;
using System.Collections.Generic;

namespace AliExpress.Servicio.Interface
{
    public interface IAsignarPaqueteria
    {
        void AsignarEntidadPaqueteria(Pedido _Pedido, List<Paqueteria> _lstPaqueteria);
    }
}
