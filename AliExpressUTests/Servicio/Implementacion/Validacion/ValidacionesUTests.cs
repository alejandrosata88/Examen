using AliExpress.Entidad;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace AliExpress.Servicio.Implementacion.Validacion.Tests
{
    [TestClass()]
    public class ValidacionesUTests
    {
        [TestMethod()]
        public void ValidarCampos_EnviaPedidoVacioPaqueteriaVacia_ObtieneListaErrores()
        {
            Pedido entPedido = new Pedido();
            List<Paqueteria> lstPaqueteria = new List<Paqueteria>();
            List<string> lstcMensaje = new List<string>();
            Validaciones Validaciones = new Validaciones();
            lstcMensaje=Validaciones.ValidarCampos(entPedido, lstPaqueteria);
            Assert.IsTrue(lstcMensaje.Any());
        }

        [TestMethod()]
        public void ValidarCampos_EnviaPedidoPaqueteriaVacia_ObtieneListaErrores()
        {
            Pedido entPedido = new Pedido()
            {
                cPaqueteria="DHL"
            };
            List<Paqueteria> lstPaqueteria = new List<Paqueteria>();
            List<string> lstcMensaje = new List<string>();
            Validaciones Validaciones = new Validaciones();
            lstcMensaje = Validaciones.ValidarCampos(entPedido, lstPaqueteria);
            Assert.IsTrue(lstcMensaje.Any());
        }

        [TestMethod()]
        public void ValidarCampos_EnviaPedidoVacioPaqueteria_ObtieneListaErrores()
        {
            Pedido entPedido = new Pedido();
            List<Paqueteria> lstPaqueteria = new List<Paqueteria>();
            lstPaqueteria.Add(new Paqueteria()
            {
                EEmpresa=Entidad.Enum.EnumEmpresa.DHL,
                lstETransporte= new List<Transporte>()
                {
                    new Transporte()
                    {
                        ETransporte= Entidad.Enum.EnumTransporte.AVION
                    }
                }
            });
            List<string> lstcMensaje = new List<string>();
            Validaciones Validaciones = new Validaciones();
            lstcMensaje = Validaciones.ValidarCampos(entPedido, lstPaqueteria);
            Assert.IsTrue(lstcMensaje.Any());
        }


        [TestMethod()]
        public void ValidarCampos_EnviaPedidoPaqueteria_NoObtieneListaErrores()
        {
            Pedido entPedido = new Pedido()
            {
                cPaqueteria="dhl",
               cMedioTransporte="avion"
            };
            List<Paqueteria> lstPaqueteria = new List<Paqueteria>();
            lstPaqueteria.Add(new Paqueteria()
            {
                EEmpresa = Entidad.Enum.EnumEmpresa.DHL,
                lstETransporte = new List<Transporte>()
                {
                    new Transporte()
                    {
                        ETransporte= Entidad.Enum.EnumTransporte.AVION
                    }
                }
            });
            List<string> lstcMensaje = new List<string>();
            Validaciones Validaciones = new Validaciones();
            lstcMensaje = Validaciones.ValidarCampos(entPedido, lstPaqueteria);
            Assert.IsTrue(!lstcMensaje.Any());
        }

        [TestMethod()]
        public void ValidarCampos_EnviaPedidoPaqueteria_ObtieneListaErroresEmpresa()
        {
            Pedido entPedido = new Pedido()
            {
                cPaqueteria = "phl",
                cMedioTransporte = "avion"
            };
            List<Paqueteria> lstPaqueteria = new List<Paqueteria>();
            lstPaqueteria.Add(new Paqueteria()
            {
                EEmpresa = Entidad.Enum.EnumEmpresa.DHL,
                lstETransporte = new List<Transporte>()
                {
                    new Transporte()
                    {
                        ETransporte= Entidad.Enum.EnumTransporte.AVION
                    }
                }
            });
            List<string> lstcMensaje = new List<string>();
            Validaciones Validaciones = new Validaciones();
            lstcMensaje = Validaciones.ValidarCampos(entPedido, lstPaqueteria);
            Assert.IsTrue(lstcMensaje.Any());
        }


        [TestMethod()]
        public void ValidarCampos_EnviaPedidoPaqueteria_ObtieneListaErroresTransporte()
        {
            Pedido entPedido = new Pedido()
            {
                cPaqueteria = "dhl",
                cMedioTransporte = "Tren"
            };
            List<Paqueteria> lstPaqueteria = new List<Paqueteria>();
            lstPaqueteria.Add(new Paqueteria()
            {
                EEmpresa = Entidad.Enum.EnumEmpresa.DHL,
                lstETransporte = new List<Transporte>()
                {
                    new Transporte()
                    {
                        ETransporte= Entidad.Enum.EnumTransporte.AVION
                    }
                }
            });
            List<string> lstcMensaje = new List<string>();
            Validaciones Validaciones = new Validaciones();
            lstcMensaje = Validaciones.ValidarCampos(entPedido, lstPaqueteria);
            Assert.IsTrue(lstcMensaje.Any());
        }
    }
}