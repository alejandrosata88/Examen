using Microsoft.VisualStudio.TestTools.UnitTesting;
using AliExpress.Servicio.Implementacion.LectorArchivo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AliExpress.Entidad;

namespace AliExpress.Servicio.Implementacion.LectorArchivo.Tests
{
    [TestClass()]
    public class LectorArchivoTextoUTests
    {
        [TestMethod()]
        public void ObtenerPedidos_LeerArchivo_ObtieneInformacion()
        {
            List<Pedido> lstPedidos = new List<Pedido>();
            LectorArchivoTexto LectorArchivoTexto = new LectorArchivoTexto();
            lstPedidos=LectorArchivoTexto.ObtenerPedidos();
            Assert.IsTrue(!lstPedidos.Any());
        }

        [TestMethod()]
        public void ObtenerEntidad_EnviarListaCamporVacia_NoGeneraPedido()
        {
            string[] lstCampos = null;
            Pedido entPedido = new Pedido();
            LectorArchivoTexto LectorArchivoTexto = new LectorArchivoTexto();
            entPedido=LectorArchivoTexto.ObtenerEntidad(lstCampos);
            Assert.IsTrue(entPedido==null);
        }

        [TestMethod()]
        public void ObtenerEntidad_EnviarListaCampos_GeneraPedido()
        {
            string[] lstCampos = new string[6];
            Pedido entPedido = new Pedido();
            LectorArchivoTexto LectorArchivoTexto = new LectorArchivoTexto();
            entPedido = LectorArchivoTexto.ObtenerEntidad(lstCampos);
            Assert.IsTrue(entPedido != null);
        }

        [TestMethod()]
        public void ObtenerEntidad_EnviarListaCampos_GeneraPedidoConOrigen()
        {
            string[] lstCampos = new string[6];
            lstCampos[0] = "Origen";
            Pedido entPedido = new Pedido();
            LectorArchivoTexto LectorArchivoTexto = new LectorArchivoTexto();
            entPedido = LectorArchivoTexto.ObtenerEntidad(lstCampos);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(entPedido.cOrigen));
        }

        [TestMethod()]
        public void ObtenerEntidad_EnviarListaCampos_GeneraPedidoConDestino()
        {
            string[] lstCampos = new string[6];
            lstCampos[1] = "Destino";
            Pedido entPedido = new Pedido();
            LectorArchivoTexto LectorArchivoTexto = new LectorArchivoTexto();
            entPedido = LectorArchivoTexto.ObtenerEntidad(lstCampos);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(entPedido.cDestino));
        }

        [TestMethod()]
        public void ObtenerEntidad_EnviarListaCampos_GeneraPedidoConDistancia()
        {
            string[] lstCampos = new string[6];
            lstCampos[2] = "100";
            Pedido entPedido = new Pedido();
            LectorArchivoTexto LectorArchivoTexto = new LectorArchivoTexto();
            entPedido = LectorArchivoTexto.ObtenerEntidad(lstCampos);
            Assert.IsTrue(entPedido.iDistancia > 0);
        }

        [TestMethod()]
        public void ObtenerEntidad_EnviarListaCampos_GeneraPedidoConPaqueteria()
        {
            string[] lstCampos = new string[6];
            lstCampos[3] = "Paqueteria";
            Pedido entPedido = new Pedido();
            LectorArchivoTexto LectorArchivoTexto = new LectorArchivoTexto();
            entPedido = LectorArchivoTexto.ObtenerEntidad(lstCampos);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(entPedido.cPaqueteria));
        }

        [TestMethod()]
        public void ObtenerEntidad_EnviarListaCampos_GeneraPedidoConMedioTransporte()
        {
            string[] lstCampos = new string[6];
            lstCampos[4] = "Paqueteria";
            Pedido entPedido = new Pedido();
            LectorArchivoTexto LectorArchivoTexto = new LectorArchivoTexto();
            entPedido = LectorArchivoTexto.ObtenerEntidad(lstCampos);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(entPedido.cMedioTransporte));
        }

        [TestMethod()]
        public void ObtenerEntidad_EnviarListaCampos_GeneraPedidoConFechaPedido()
        {
            string[] lstCampos = new string[6];
            lstCampos[5] = "29-01-2020 12:00:00";
            Pedido entPedido = new Pedido();
            LectorArchivoTexto LectorArchivoTexto = new LectorArchivoTexto();
            entPedido = LectorArchivoTexto.ObtenerEntidad(lstCampos);
            Assert.IsTrue(entPedido.dtPedido !=null);
        }
    }
}