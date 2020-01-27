using AliExpress.Entidad;
using AliExpress.Servicio.Implementacion.ObtenerMensaje;
using AliExpress.Servicio.Implementacion.ObtenerRangoTiempo;
using AliExpress.Servicio.Interface;
using System;
using System.Collections.Generic;

namespace AliExpress.Servicio.Implementacion.GenerarMensaje
{
    public class GenerarMensajePedido : IGenerarMensaje
    {
        ManejadorRangoTiempo ManejadorRangoTiempo { get; set; }
        IVerificarOpcionEconomica IVerificarOpcionEconomica { get; set; }

        public GenerarMensajePedido(ManejadorRangoTiempo _ManejadorRangoTiempo, IVerificarOpcionEconomica _IVerificarOpcionEconomica)
        {
            this.ManejadorRangoTiempo = _ManejadorRangoTiempo;
            this.IVerificarOpcionEconomica = _IVerificarOpcionEconomica;
        }

        public string CrearMensajeDePedido(Pedido _entPedido, DateTime _dtFechaHoy, string _cFormatoMesaje, List<Paqueteria> _lstPaqueteria,ref bool _lEntregado)
        {
            string cMensaje = string.Empty, cRangoTiempo = string.Empty, cMensajeOpcionEconomica = string.Empty; ;
            DateTime dtFechaEntrega = new DateTime();
            double dTiempoTraslado = 0;
            decimal dCostoEnvio = 0.0M;
            IObtenerMensaje IObtenerMensaje = null;
            TimeSpan tiempo = new TimeSpan();

            dTiempoTraslado = ObtenerTiempoTraslado(_entPedido.iDistancia, _entPedido.entTransporte.iVelodicad);
            dtFechaEntrega = ObtenerFechaEntrega(_entPedido.dtPedido, dTiempoTraslado);
            dCostoEnvio=ObtenerCostoEnvio(_entPedido);
 
            if (dtFechaEntrega < _dtFechaHoy)
            {
                tiempo = _dtFechaHoy.Subtract(dtFechaEntrega);
                IObtenerMensaje = new ObtenerMensajeEnvioEntregado();
                _lEntregado = true;
            }
            else
            {
                tiempo = dtFechaEntrega.Subtract(_dtFechaHoy);
                IObtenerMensaje = new ObtenerMensajeEnvioPendiente();
                _lEntregado = false;
            }
            cRangoTiempo=this.ManejadorRangoTiempo.ObtenerTextoRangoTiempo(tiempo);

            cMensaje=IObtenerMensaje.ObtenerMensaje(_cFormatoMesaje, _entPedido, cRangoTiempo, dCostoEnvio);
            cMensajeOpcionEconomica = IVerificarOpcionEconomica.ObtenerOpcioneEconomica(_entPedido, _lstPaqueteria, dCostoEnvio);
            if (!string.IsNullOrWhiteSpace(cMensajeOpcionEconomica))
                cMensaje += "\n"+cMensajeOpcionEconomica;
            return cMensaje;
        }

        public double ObtenerTiempoTraslado(int _iDistancia, int _iVelocidad)
        {
            double dTiempoTraslado = new double();
            dTiempoTraslado = _iDistancia / _iVelocidad;
            return dTiempoTraslado;
        }

        public DateTime ObtenerFechaEntrega(DateTime _dtFechaPedido, double _dTiempoTraslado)
        {
            DateTime dtFechaEntrega = new DateTime();
            dtFechaEntrega = _dtFechaPedido.AddHours(_dTiempoTraslado);
            return dtFechaEntrega;
        }

        public decimal ObtenerCostoEnvio(Pedido _Pedido)
        {
            decimal dCostoEnvio = 0.0M;
            dCostoEnvio = (_Pedido.entTransporte.iCostoKilometro * _Pedido.iDistancia) + (1 + ((decimal)_Pedido.entPaqueteria.iMargenUtilidad / 100));
            return dCostoEnvio;
        }
    }
}
