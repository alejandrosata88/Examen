using AliExpress.Entidad;
using System.Collections.Generic;

namespace AliExpress.Servicio.Interface
{
    public interface IValidacion
    {
        List<string> ValidarCampos(Pedido _entPedido, List<Paqueteria> _lstPaqueteria);
    }
}
