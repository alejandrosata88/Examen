using Microsoft.VisualStudio.TestTools.UnitTesting;
using AliExpress.Servicio.Implementacion.ObtenerRangoTiempo;
using AliExpress.Servicio.Interface;
using AliExpress.Servicio.Implementacion.VerificarOpcionEconomica;
using AliExpress.Entidad;
using System;

namespace AliExpress.Servicio.Implementacion.GenerarMensaje.Tests
{
    [TestClass()]
    public class GenerarMensajePedidoTests
    {
        [TestMethod()]
        public void ObtenerTiempoTraslado_EnviarDistanciaCeroVelocidadCero_ObtieneMontoCero()
        {
            double dTiempoTraslado = new double();
            ManejadorRangoTiempo ManejadorRangoTiempo = new ObtenerMinutos();
            IVerificarOpcionEconomica IVerificarOpcionEconomica = new EvaluarOpcionEconominca();
            GenerarMensajePedido GenerarMensajePedido = new GenerarMensajePedido(ManejadorRangoTiempo, IVerificarOpcionEconomica);
            dTiempoTraslado=GenerarMensajePedido.ObtenerTiempoTraslado(0,0);
            Assert.IsTrue(dTiempoTraslado==0);
        }

        [TestMethod()]
        public void ObtenerTiempoTraslado_EnviarDistanciaVelocidadCero_ObtieneMontoCero()
        {
            double dTiempoTraslado = new double();
            ManejadorRangoTiempo ManejadorRangoTiempo = new ObtenerMinutos();
            IVerificarOpcionEconomica IVerificarOpcionEconomica = new EvaluarOpcionEconominca();
            GenerarMensajePedido GenerarMensajePedido = new GenerarMensajePedido(ManejadorRangoTiempo, IVerificarOpcionEconomica);
            dTiempoTraslado = GenerarMensajePedido.ObtenerTiempoTraslado(10, 0);
            Assert.IsTrue(dTiempoTraslado == 0);
        }

        [TestMethod()]
        public void ObtenerTiempoTraslado_EnviarDistanciaCeroVelocidad_ObtieneMontoCero()
        {
            double dTiempoTraslado = new double();
            ManejadorRangoTiempo ManejadorRangoTiempo = new ObtenerMinutos();
            IVerificarOpcionEconomica IVerificarOpcionEconomica = new EvaluarOpcionEconominca();
            GenerarMensajePedido GenerarMensajePedido = new GenerarMensajePedido(ManejadorRangoTiempo, IVerificarOpcionEconomica);
            dTiempoTraslado = GenerarMensajePedido.ObtenerTiempoTraslado(0, 10);
            Assert.IsTrue(dTiempoTraslado == 0);
        }

        [TestMethod()]
        public void ObtenerTiempoTraslado_EnviarDistanciaVelocidad_ObtieneMontoCero()
        {
            double dTiempoTraslado = new double();
            ManejadorRangoTiempo ManejadorRangoTiempo = new ObtenerMinutos();
            IVerificarOpcionEconomica IVerificarOpcionEconomica = new EvaluarOpcionEconominca();
            GenerarMensajePedido GenerarMensajePedido = new GenerarMensajePedido(ManejadorRangoTiempo, IVerificarOpcionEconomica);
            dTiempoTraslado = GenerarMensajePedido.ObtenerTiempoTraslado(10, 10);
            Assert.IsTrue(dTiempoTraslado != 0);
        }

        [TestMethod()]
        public void ObtenerFechaEntrega_EnviarTiempoTrasladoTiempoTrasladoCero_ObtieneMismaFecha()
        {
            DateTime dtFechaEntrega = new DateTime(), dtFechaPedido = DateTime.Now;
            double dTiempoTraslado = 0;
            ManejadorRangoTiempo ManejadorRangoTiempo = new ObtenerMinutos();
            IVerificarOpcionEconomica IVerificarOpcionEconomica = new EvaluarOpcionEconominca();
            GenerarMensajePedido GenerarMensajePedido = new GenerarMensajePedido(ManejadorRangoTiempo, IVerificarOpcionEconomica);
            dtFechaEntrega = GenerarMensajePedido.ObtenerFechaEntrega(dtFechaPedido, dTiempoTraslado);
            Assert.IsTrue(dtFechaEntrega== dtFechaPedido);
        }

        [TestMethod()]
        public void ObtenerFechaEntrega_EnviarTiempoTrasladoTiempoTraslado_ObtieneFechaDiferente()
        {
            DateTime dtFechaEntrega = new DateTime(), dtFechaPedido = DateTime.Now;
            double dTiempoTraslado = 30000;
            ManejadorRangoTiempo ManejadorRangoTiempo = new ObtenerMinutos();
            IVerificarOpcionEconomica IVerificarOpcionEconomica = new EvaluarOpcionEconominca();
            GenerarMensajePedido GenerarMensajePedido = new GenerarMensajePedido(ManejadorRangoTiempo, IVerificarOpcionEconomica);
            dtFechaEntrega = GenerarMensajePedido.ObtenerFechaEntrega(dtFechaPedido, dTiempoTraslado);
            Assert.IsTrue(dtFechaEntrega != dtFechaPedido);
        }

        [TestMethod()]
        public void ObtenerCostoEnvio_EnviarPedidoVacio_ObtieneMontoCero()
        {
            decimal dMonto = 0.0M;
            ManejadorRangoTiempo ManejadorRangoTiempo = new ObtenerMinutos();
            IVerificarOpcionEconomica IVerificarOpcionEconomica = new EvaluarOpcionEconominca();
            GenerarMensajePedido GenerarMensajePedido = new GenerarMensajePedido(ManejadorRangoTiempo, IVerificarOpcionEconomica);
            Pedido Pedido = new Pedido();
            dMonto=GenerarMensajePedido.ObtenerCostoEnvio(Pedido);
            Assert.IsTrue(dMonto==0);
        }

        [TestMethod()]
        public void ObtenerCostoEnvio_EnviarPedido_ObtieneMontoDiferenteCero()
        {
            decimal dMonto = 0.0M;
            ManejadorRangoTiempo ManejadorRangoTiempo = new ObtenerMinutos();
            IVerificarOpcionEconomica IVerificarOpcionEconomica = new EvaluarOpcionEconominca();
            GenerarMensajePedido GenerarMensajePedido = new GenerarMensajePedido(ManejadorRangoTiempo, IVerificarOpcionEconomica);
            Pedido Pedido = new Pedido()
            {
                iDistancia=10,
                entPaqueteria= new Paqueteria()
                {
                    iMargenUtilidad=10
                },
                entTransporte=new Transporte()
                {
                    iCostoKilometro=10,
                }
            };
            dMonto = GenerarMensajePedido.ObtenerCostoEnvio(Pedido);
            Assert.IsTrue(dMonto != 0);
        }
    }
}