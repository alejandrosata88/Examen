using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AliExpress.Servicio.Implementacion.ObtenerRangoTiempo.Tests
{
    [TestClass()]
    public class ObtenerHorasUTests
    {
        [TestMethod()]
        public void ObtenerTextoRangoTiempo_EnviaTiempoVacio_ObtieneMensajeVacio()
        {
            string cTextoRango = string.Empty;
            TimeSpan tiempo = new TimeSpan();
            ObtenerHoras ObtenerHoras = new ObtenerHoras();
            cTextoRango = ObtenerHoras.ObtenerTextoRangoTiempo(tiempo);
            Assert.IsTrue(string.IsNullOrWhiteSpace(cTextoRango));
        }

        [TestMethod()]
        public void ObtenerTextoRangoTiempo_EnviaTiempoVacio_ObtieneMensaje()
        {
            string cTextoRango = string.Empty;
            TimeSpan tiempo = new TimeSpan();
            tiempo = DateTime.Now.AddHours(10).Subtract(DateTime.Now);
            ObtenerHoras ObtenerHoras = new ObtenerHoras();
            cTextoRango = ObtenerHoras.ObtenerTextoRangoTiempo(tiempo);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(cTextoRango));
        }

        [TestMethod()]
        public void ObtenerTextoRangoTiempo_EnviaTiempoVacio_ObtieneMensajeSiguienteVacio()
        {
            string cTextoRango = string.Empty;
            TimeSpan tiempo = new TimeSpan();
            tiempo = DateTime.Now.AddHours(72).Subtract(DateTime.Now);
            ObtenerHoras ObtenerHoras = new ObtenerHoras();
            cTextoRango = ObtenerHoras.ObtenerTextoRangoTiempo(tiempo);
            Assert.IsTrue(string.IsNullOrWhiteSpace(cTextoRango));
        }
    }
}