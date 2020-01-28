using System.Collections.Generic;
using System.Linq;
using AliExpress.Entidad;
using AliExpress.Servicio.Interface;

namespace AliExpress.Servicio.Implementacion.Validacion
{
    public class Validaciones : IValidacion
    {
        public List<string> ValidarCampos(Pedido _entPedido, List<Paqueteria> _lstPaqueteria)
        {
            List<string> lstErrores = new List<string>();
            string cPaqueteria = !string.IsNullOrWhiteSpace(_entPedido.cPaqueteria) ? _entPedido.cPaqueteria.ToUpper() : "";
            if (!_lstPaqueteria.Where(w => w.EEmpresa.ToString() == cPaqueteria).Any())
                lstErrores.Add(string.Format("La Paquetería: {0} no se encuentra registrada en nuestra red de distribución.", cPaqueteria));
            else if (!_lstPaqueteria.Where(w => w.EEmpresa.ToString() == _entPedido.cPaqueteria.ToUpper()).SelectMany(s => s.lstETransporte).Where(w1 => w1.ETransporte.ToString() == _entPedido.cMedioTransporte.ToUpper()).Any())
                lstErrores.Add(string.Format("{0} no ofrece el servicio de transporte por {1}, te recomendamos cotizar en otra empresa.", _entPedido.cPaqueteria, _entPedido.cMedioTransporte));
            return lstErrores;
        }
    }
}
