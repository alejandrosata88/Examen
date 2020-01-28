using Microsoft.VisualStudio.TestTools.UnitTesting;
using AliExpress.Entidad;

namespace AliExpress.Servicio.Implementacion.InicializarTransportes.Tests
{
    [TestClass()]
    public class TransporteTrenUTests
    {
        [TestMethod()]
        public void CrearTransporte_llamarAMetodo_ObtieneTransporte()
        {
            Transporte entTransporte = new Transporte();
            TransporteTren TransporteTren = new TransporteTren();
            entTransporte = TransporteTren.CrearTransporte();
            Assert.IsTrue(entTransporte != null);
        }

        [TestMethod()]
        public void CrearTransporte_llamarAMetodo_ObtieneTransporteConNombreTransporte()
        {
            Transporte entTransporte = new Transporte();
            TransporteTren TransporteTren = new TransporteTren();
            entTransporte = TransporteTren.CrearTransporte();
            Assert.IsTrue(!string.IsNullOrWhiteSpace(entTransporte.ETransporte.ToString()));
        }

        [TestMethod()]
        public void CrearTransporte_llamarAMetodo_ObtieneTransporteConImporte()
        {
            Transporte entTransporte = new Transporte();
            TransporteTren TransporteTren = new TransporteTren();
            entTransporte = TransporteTren.CrearTransporte();
            Assert.IsTrue(entTransporte.iCostoKilometro != 0);
        }

        [TestMethod()]
        public void CrearTransporte_llamarAMetodo_ObtieneTransporteConVelocidad()
        {
            Transporte entTransporte = new Transporte();
            TransporteTren TransporteTren = new TransporteTren();
            entTransporte = TransporteTren.CrearTransporte();
            Assert.IsTrue(entTransporte.iVelodicad != 0);
        }
    }
}