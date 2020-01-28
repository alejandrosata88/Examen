using AliExpress.Entidad;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AliExpress.Servicio.Implementacion.VerificarOpcionEconomica.Tests
{
    [TestClass()]
    public class EvaluarOpcionEconomincaUTests
    {
        [TestMethod()]
        public void ObtenerCostoEnvioEconomico_EnviarPedidoVacioEnviarPaqueteriaVaciaEnviarTransporteVacio_ObtieneMontoEnvioUno()
        {
            Pedido Pedido = new Pedido();
            Paqueteria entPaqueteria = new Paqueteria();
            Transporte Transporte = new Transporte();
            decimal dMonto = 0.0M;
            EvaluarOpcionEconominca EvaluarOpcionEconominca = new EvaluarOpcionEconominca();
            dMonto=EvaluarOpcionEconominca.ObtenerCostoEnvioEconomico(Pedido, entPaqueteria, Transporte);
            Assert.IsTrue(dMonto==1);
        }

        [TestMethod()]
        public void ObtenerCostoEnvioEconomico_EnviarPedidoEnviarPaqueteriaVaciaEnviarTransporteVacio_NoObtieneMontoUno()
        {
            Pedido Pedido = new Pedido()
            {
                iDistancia=100
            };
            Paqueteria entPaqueteria = new Paqueteria();
            Transporte Transporte = new Transporte();
            decimal dMonto = 0.0M;
            EvaluarOpcionEconominca EvaluarOpcionEconominca = new EvaluarOpcionEconominca();
            dMonto = EvaluarOpcionEconominca.ObtenerCostoEnvioEconomico(Pedido, entPaqueteria, Transporte);
            Assert.IsTrue(dMonto == 1);
        }

        [TestMethod()]
        public void ObtenerCostoEnvioEconomico_EnviarPedidoEnviarPaqueteriaEnviarTransporteVacio_NoObtieneMontoMargen()
        {
            Pedido Pedido = new Pedido()
            {
                iDistancia = 100
            };
            Paqueteria entPaqueteria = new Paqueteria()
            {
                iMargenUtilidad = 40
            };
            Transporte Transporte = new Transporte();
            decimal dMonto = 0.0M;
            EvaluarOpcionEconominca EvaluarOpcionEconominca = new EvaluarOpcionEconominca();
            dMonto = EvaluarOpcionEconominca.ObtenerCostoEnvioEconomico(Pedido, entPaqueteria, Transporte);
            Assert.IsTrue(dMonto == (decimal)1.4);
        }

        [TestMethod()]
        public void ObtenerCostoEnvioEconomico_EnviarPedidoEnviarPaqueteriaEnviarTransporte_ObtieneMonto()
        {
            Pedido Pedido = new Pedido()
            {
                iDistancia = 100
            };
            Paqueteria entPaqueteria = new Paqueteria()
            {
                iMargenUtilidad = 40
            };
            Transporte Transporte = new Transporte()
            {
                iCostoKilometro=20
            };
            decimal dMonto = 0.0M;
            EvaluarOpcionEconominca EvaluarOpcionEconominca = new EvaluarOpcionEconominca();
            dMonto = EvaluarOpcionEconominca.ObtenerCostoEnvioEconomico(Pedido, entPaqueteria, Transporte);
            Assert.IsTrue(dMonto != 0);
        }
    }
}