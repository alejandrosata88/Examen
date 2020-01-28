using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AliExpress.Entidad;

namespace AliExpress.Servicio.Implementacion.AsignarPaqueteria.Tests
{
    [TestClass()]
    public class AsignarEntidadesTests
    {
        [TestMethod()]
        public void AsignarEntidadPaqueteria_NoEnviarPedidoListaPaqueterias_NoAsignaPaqueteria()
        {
            Pedido entPedido = new Pedido();
            List<Paqueteria> lstPaqueteria = new List<Paqueteria>();
            AsignarEntidades AsignarEntidades = new AsignarEntidades();
            AsignarEntidades.AsignarEntidadPaqueteria(entPedido, lstPaqueteria);
            Assert.IsTrue(entPedido.entPaqueteria==null);
        }

        [TestMethod()]
        public void AsignarEntidadPaqueteria_NoEnviarPedidoListaPaqueterias_NoAsignaTransporte()
        {
            Pedido entPedido = new Pedido();
            List<Paqueteria> lstPaqueteria = new List<Paqueteria>();
            AsignarEntidades AsignarEntidades = new AsignarEntidades();
            AsignarEntidades.AsignarEntidadPaqueteria(entPedido, lstPaqueteria);
            Assert.IsTrue(entPedido.entTransporte == null);
        }

        [TestMethod()]
        public void AsignarEntidadPaqueteria_EnviarPedidoNoEnviarListaPaqueterias_NoAsignaPaqueteria()
        {
            Pedido entPedido = new Pedido()
            {
                cPaqueteria = "DHL"
            };
            List<Paqueteria> lstPaqueteria = new List<Paqueteria>();
            AsignarEntidades AsignarEntidades = new AsignarEntidades();
            AsignarEntidades.AsignarEntidadPaqueteria(entPedido, lstPaqueteria);
            Assert.IsTrue(entPedido.entPaqueteria == null);
        }

        [TestMethod()]
        public void AsignarEntidadPaqueteria_EnviarPedidoNoEnviarListaPaqueterias_NoAsignaTransporte()
        {
            Pedido entPedido = new Pedido()
            {
                cPaqueteria = "DHL",
                cMedioTransporte = "AVION"
            };
            List<Paqueteria> lstPaqueteria = new List<Paqueteria>();
            AsignarEntidades AsignarEntidades = new AsignarEntidades();
            AsignarEntidades.AsignarEntidadPaqueteria(entPedido, lstPaqueteria);
            Assert.IsTrue(entPedido.entTransporte == null);
        }

        [TestMethod()]
        public void AsignarEntidadPaqueteria_EnviarPaqueteriaListaPaqueterias_AsignaPaqueteria()
        {
            Pedido entPedido = new Pedido()
            {
                cPaqueteria = "DHL"
            };
            List<Paqueteria> lstPaqueteria = new List<Paqueteria>();
            lstPaqueteria.Add(new Paqueteria()
            {
                EEmpresa=Entidad.Enum.EnumEmpresa.DHL
            });
            AsignarEntidades AsignarEntidades = new AsignarEntidades();
            AsignarEntidades.AsignarEntidadPaqueteria(entPedido, lstPaqueteria);
            Assert.IsTrue(entPedido.entPaqueteria != null);
        }

        [TestMethod()]
        public void AsignarEntidadPaqueteria_EnviarPaqueteriaListaPaqueterias_AsignaTransporte()
        {
            Pedido entPedido = new Pedido()
            {
                cPaqueteria = "DHL",
                cMedioTransporte="AVION"
            };
            List<Paqueteria> lstPaqueteria = new List<Paqueteria>();
            lstPaqueteria.Add(new Paqueteria()
            {
                EEmpresa = Entidad.Enum.EnumEmpresa.DHL,
                lstETransporte=new List<Transporte>()
                {
                    new Transporte()
                    {
                        ETransporte=Entidad.Enum.EnumTransporte.AVION
                    }
                }
                
            });
            AsignarEntidades AsignarEntidades = new AsignarEntidades();
            AsignarEntidades.AsignarEntidadPaqueteria(entPedido, lstPaqueteria);
            Assert.IsTrue(entPedido.entTransporte != null);
        }
    }
}