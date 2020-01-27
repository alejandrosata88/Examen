using AliExpress.Entidad;
using AliExpress.Servicio.Interface;
using System.Collections.Generic;
using System.Linq;

namespace AliExpress.Servicio.Implementacion.AsignarPaqueteria
{
    public class AsignarEntidades : IAsignarPaqueteria
    {
        public void AsignarEntidadPaqueteria(Pedido _Pedido, List<Paqueteria> _lstPaqueteria)
        {
            _Pedido.entPaqueteria = _lstPaqueteria.Where(w => w.EEmpresa.ToString() == _Pedido.cPaqueteria.ToUpper()).Select(s => s).FirstOrDefault();
            if (_Pedido.entPaqueteria!=null && _Pedido.cMedioTransporte!=null)
                _Pedido.entTransporte= _Pedido.entPaqueteria.lstETransporte.Where(w=>w.ETransporte.ToString()== _Pedido.cMedioTransporte.ToUpper()).Select(s=>s).FirstOrDefault();
        }
    }
}
