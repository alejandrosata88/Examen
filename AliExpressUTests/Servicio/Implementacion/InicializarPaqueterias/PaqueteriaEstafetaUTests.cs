using Microsoft.VisualStudio.TestTools.UnitTesting;
using AliExpress.Servicio.Interface;
using AliExpress.Servicio.Implementacion.TransportesPorPaqueteria;
using AliExpress.Servicio.Implementacion.InicializarTransportes;
using AliExpress.Entidad;
using System.Collections.Generic;
using System.Linq;

namespace AliExpress.Servicio.Implementacion.InicializarPaqueterias.Tests
{
    [TestClass()]
    public class PaqueteriaEstafetaUTests
    {
        [TestMethod()]
        public void CrearPaqueteria_EnviarInterfaceTransporte_CreaPaqueteria()
        {
            Paqueteria Paqueteria = new Paqueteria();
            List<IInicializarTransportes> lstIInicializarTransportes = new List<IInicializarTransportes>();
            lstIInicializarTransportes.Add(new TransporteAvion());
            ITransportesPorPaqueteria ITransportesPorPaqueteria = new CrearTransportes(lstIInicializarTransportes);
            PaqueteriaEstafeta PaqueteriaEstafeta = new PaqueteriaEstafeta(ITransportesPorPaqueteria);
            Paqueteria = PaqueteriaEstafeta.CrearPaqueteria();
            Assert.IsTrue(Paqueteria != null);
        }

        [TestMethod()]
        public void CrearPaqueteria_EnviarInterfaceTransporte_CreaPaqueteriaConNombreEmpresa()
        {
            Paqueteria Paqueteria = new Paqueteria();
            List<IInicializarTransportes> lstIInicializarTransportes = new List<IInicializarTransportes>();
            lstIInicializarTransportes.Add(new TransporteAvion());
            ITransportesPorPaqueteria ITransportesPorPaqueteria = new CrearTransportes(lstIInicializarTransportes);
            PaqueteriaEstafeta PaqueteriaEstafeta = new PaqueteriaEstafeta(ITransportesPorPaqueteria);
            Paqueteria = PaqueteriaEstafeta.CrearPaqueteria();
            Assert.IsTrue(!string.IsNullOrEmpty(Paqueteria.EEmpresa.ToString()));
        }

        [TestMethod()]
        public void CrearPaqueteria_EnviarInterfaceTransporte_CreaPaqueteriaConMargerUtilidas()
        {
            Paqueteria Paqueteria = new Paqueteria();
            List<IInicializarTransportes> lstIInicializarTransportes = new List<IInicializarTransportes>();
            lstIInicializarTransportes.Add(new TransporteAvion());
            ITransportesPorPaqueteria ITransportesPorPaqueteria = new CrearTransportes(lstIInicializarTransportes);
            PaqueteriaEstafeta PaqueteriaEstafeta = new PaqueteriaEstafeta(ITransportesPorPaqueteria);
            Paqueteria = PaqueteriaEstafeta.CrearPaqueteria();
            Assert.IsTrue(Paqueteria.iMargenUtilidad != 0);
        }

        [TestMethod()]
        public void CrearPaqueteria_EnviarInterfaceTransporteVacia_CreaPaqueteriaSinListaTransporte()
        {
            Paqueteria Paqueteria = new Paqueteria();
            List<IInicializarTransportes> lstIInicializarTransportes = new List<IInicializarTransportes>();
            ITransportesPorPaqueteria ITransportesPorPaqueteria = new CrearTransportes(lstIInicializarTransportes);
            PaqueteriaEstafeta PaqueteriaEstafeta = new PaqueteriaEstafeta(ITransportesPorPaqueteria);
            Paqueteria = PaqueteriaEstafeta.CrearPaqueteria();
            Assert.IsTrue(!Paqueteria.lstETransporte.Any());
        }

        [TestMethod()]
        public void CrearPaqueteria_EnviarInterfaceTransporte_CreaPaqueteriaConListaTransporte()
        {
            Paqueteria Paqueteria = new Paqueteria();
            List<IInicializarTransportes> lstIInicializarTransportes = new List<IInicializarTransportes>();
            lstIInicializarTransportes.Add(new TransporteAvion());
            ITransportesPorPaqueteria ITransportesPorPaqueteria = new CrearTransportes(lstIInicializarTransportes);
            PaqueteriaEstafeta PaqueteriaEstafeta = new PaqueteriaEstafeta(ITransportesPorPaqueteria);
            Paqueteria = PaqueteriaEstafeta.CrearPaqueteria();
            Assert.IsTrue(Paqueteria.lstETransporte.Any());
        }
    }
}