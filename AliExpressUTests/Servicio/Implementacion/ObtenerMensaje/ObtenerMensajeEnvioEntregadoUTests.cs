﻿using AliExpress.Entidad;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AliExpress.Servicio.Implementacion.ObtenerMensaje.Tests
{
    [TestClass()]
    public class ObtenerMensajeEnvioEntregadoUTests
    {
        [TestMethod()]
        public void ObtenerMensaje_EnviarPedidoVacioRangoTiempoVacioCostoCero_ObtieneMensaje()
        {
            string cMensaje = string.Empty;
            string cFormatoMesaje = "Tu paquete {0} de {1} y {2} a {3} {4} {5} y {6} un costo de {7} (Cualquier reclamación con {8}).";
            Pedido entPedido = new Pedido();
            string cRangoTiempo = string.Empty;
            decimal dCosto = 0.0m;
            ObtenerMensajeEnvioEntregado ObtenerMensajeEnvioEntregado = new ObtenerMensajeEnvioEntregado();
            cMensaje = ObtenerMensajeEnvioEntregado.ObtenerMensaje(cFormatoMesaje, entPedido, cRangoTiempo, dCosto);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(cMensaje));
        }

        [TestMethod()]
        public void ObtenerMensaje_EnviarPedidoRangoTiempoCosto_ObtieneMensaje()
        {
            string cMensaje = string.Empty;
            string cFormatoMesaje = "Tu paquete {0} de {1} y {2} a {3} {4} {5} y {6} un costo de {7} (Cualquier reclamación con {8}).";
            Pedido entPedido = new Pedido()
            {
                cOrigen="Origen",
                cDestino="Destino",
                cPaqueteria="PAqueteria"
            };
            string cRangoTiempo = "Rango";
            decimal dCosto = 100.0m;
            ObtenerMensajeEnvioEntregado ObtenerMensajeEnvioEntregado = new ObtenerMensajeEnvioEntregado();
            cMensaje = ObtenerMensajeEnvioEntregado.ObtenerMensaje(cFormatoMesaje, entPedido, cRangoTiempo, dCosto);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(cMensaje));
        }
    }
}