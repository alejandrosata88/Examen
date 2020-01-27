using AliExpress.Entidad;

namespace AliExpress.Servicio.Interface
{
    public interface IObtenerMensaje
    {
        string ObtenerMensaje(string _cTextoBase, Pedido _Pedido, string _cRangoTiempo, decimal _dCosto);
    }
}
