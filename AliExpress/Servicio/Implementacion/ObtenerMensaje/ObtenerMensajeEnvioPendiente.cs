using AliExpress.Entidad;
using AliExpress.Servicio.Interface;

namespace AliExpress.Servicio.Implementacion.ObtenerMensaje
{
    public class ObtenerMensajeEnvioPendiente: IObtenerMensaje
    {
        public string ObtenerMensaje(string _cTextoBase, Pedido _Pedido, string _cRangoTiempo, decimal _dCosto)
        {
            string cMensaje = string.Empty;
            cMensaje = string.Format(_cTextoBase, "ha salió", _Pedido.cOrigen, "llegara", _Pedido.cDestino, "dentro de", _cRangoTiempo, "tendra", _dCosto, _Pedido.cPaqueteria);
            return cMensaje;
        }
    }
}
