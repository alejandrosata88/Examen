using AliExpress.Entidad;
using System.Collections.Generic;

namespace AliExpress.Servicio.Interface
{
    public interface IVerificarOpcionEconomica
    {
        string ObtenerOpcioneEconomica(Pedido _Pedido, List<Paqueteria> _lstPaqueteria, decimal _dCostoEnvio);
    }
}
