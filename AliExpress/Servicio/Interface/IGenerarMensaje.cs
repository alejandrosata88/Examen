using AliExpress.Entidad;
using System;
using System.Collections.Generic;

namespace AliExpress.Servicio.Interface
{
    public interface IGenerarMensaje
    {
        string CrearMensajeDePedido(Pedido _entPedido, DateTime _dtFechaHoy,string _cFormatoMesaje, List<Paqueteria> _lstPaqueteria,ref bool _lEntregado);
    }
}
