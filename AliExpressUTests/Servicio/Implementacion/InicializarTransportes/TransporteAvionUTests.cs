using Microsoft.VisualStudio.TestTools.UnitTesting;
using AliExpress.Entidad;

namespace AliExpress.Servicio.Implementacion.InicializarTransportes.Tests
{
    [TestClass()]
    public class TransporteAvionUTests
    {
        [TestMethod()]
        public void CrearTransporte_llamarAMetodo_ObtieneTransporte()
        {
            Transporte entTransporte = new Transporte();
            TransporteAvion TransporteAvion = new TransporteAvion();
            entTransporte=TransporteAvion.CrearTransporte();
            Assert.IsTrue(entTransporte!=null);
        }

        [TestMethod()]
        public void CrearTransporte_llamarAMetodo_ObtieneTransporteConNombreTransporte()
        {
            Transporte entTransporte = new Transporte();
            TransporteAvion TransporteAvion = new TransporteAvion();
            entTransporte = TransporteAvion.CrearTransporte();
            Assert.IsTrue(!string.IsNullOrWhiteSpace(entTransporte.ETransporte.ToString()));
        }

        [TestMethod()]
        public void CrearTransporte_llamarAMetodo_ObtieneTransporteConImporte()
        {
            Transporte entTransporte = new Transporte();
            TransporteAvion TransporteAvion = new TransporteAvion();
            entTransporte = TransporteAvion.CrearTransporte();
            Assert.IsTrue(entTransporte.iCostoKilometro != 0);
        }

        [TestMethod()]
        public void CrearTransporte_llamarAMetodo_ObtieneTransporteConVelocidad()
        {
            Transporte entTransporte = new Transporte();
            TransporteAvion TransporteAvion = new TransporteAvion();
            entTransporte = TransporteAvion.CrearTransporte();
            Assert.IsTrue(entTransporte.iVelodicad != 0);
        }
    }
}