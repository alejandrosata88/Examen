using AliExpress.Entidad;
using AliExpress.Servicio.Interface;

namespace AliExpress.Servicio.Implementacion.ObtenerMensaje
{
    public class ObtenerMensajeEnvioEntregado: IObtenerMensaje
    {
        public string ObtenerMensaje(string _cTextoBase, Pedido _Pedido, string _cRangoTiempo, decimal _dCosto)
        {
            string cMensaje = string.Empty;
            cMensaje = string.Format(_cTextoBase, "salió", _Pedido.cOrigen, "llegó", _Pedido.cDestino, "hace", _cRangoTiempo, "tuvó", _dCosto, _Pedido.cPaqueteria);
            return cMensaje;
        }
    }
}
