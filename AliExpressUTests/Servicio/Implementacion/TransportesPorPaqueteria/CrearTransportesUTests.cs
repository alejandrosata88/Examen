using Microsoft.VisualStudio.TestTools.UnitTesting;
using AliExpress.Servicio.Implementacion.TransportesPorPaqueteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AliExpress.Servicio.Interface;
using AliExpress.Entidad;
using AliExpress.Servicio.Implementacion.InicializarTransportes;

namespace AliExpress.Servicio.Implementacion.TransportesPorPaqueteria.Tests
{
    [TestClass()]
    public class CrearTransportesUTests
    {
        [TestMethod()]
        public void CrearListaTransportesPorPaquetria_EnviarListaTransportesVacia_CreaListaTransportesVacia()
        {
            List<Transporte> lstTransporte = new List<Transporte>();
            List<IInicializarTransportes> lstIInicializarTransportes = new List<IInicializarTransportes>();
            CrearTransportes CrearTransportes = new CrearTransportes(lstIInicializarTransportes);
            lstTransporte=CrearTransportes.CrearListaTransportesPorPaquetria();
            Assert.IsTrue(!lstTransporte.Any());
        }

        [TestMethod()]
        public void CrearListaTransportesPorPaquetria_EnviarListaTransportes_CreaListaTransportes()
        {
            List<Transporte> lstTransporte = new List<Transporte>();
            List<IInicializarTransportes> lstIInicializarTransportes = new List<IInicializarTransportes>();
            lstIInicializarTransportes.Add(new TransporteAvion());
            CrearTransportes CrearTransportes = new CrearTransportes(lstIInicializarTransportes);
            lstTransporte = CrearTransportes.CrearListaTransportesPorPaquetria();
            Assert.IsTrue(lstTransporte.Any());
        }
    }
}