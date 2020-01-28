using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AliExpress.Servicio.Implementacion.ObtenerRangoTiempo.Tests
{
    [TestClass()]
    public class ObtenerDiasUTests
    {
        [TestMethod()]
        public void ObtenerTextoRangoTiempo_EnviaTiempoVacio_ObtieneMensajeVacio()
        {
            string cTextoRango = string.Empty;
            TimeSpan tiempo = new TimeSpan();
            ObtenerDias ObtenerDias = new ObtenerDias();
            cTextoRango=ObtenerDias.ObtenerTextoRangoTiempo(tiempo);
            Assert.IsTrue(string.IsNullOrWhiteSpace(cTextoRango));
        }

        [TestMethod()]
        public void ObtenerTextoRangoTiempo_EnviaTiempoVacio_ObtieneMensaje()
        {
            string cTextoRango = string.Empty;
            TimeSpan tiempo = new TimeSpan();
            tiempo = DateTime.Now.AddDays(10).Subtract(DateTime.Now);
            ObtenerDias ObtenerDias = new ObtenerDias();
            cTextoRango = ObtenerDias.ObtenerTextoRangoTiempo(tiempo);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(cTextoRango));
        }

        [TestMethod()]
        public void ObtenerTextoRangoTiempo_EnviaTiempoVacio_ObtieneMensajeSiguienteVacio()
        {
            string cTextoRango = string.Empty;
            TimeSpan tiempo = new TimeSpan();
            tiempo = DateTime.Now.AddDays(40).Subtract(DateTime.Now);
            ObtenerDias ObtenerDias = new ObtenerDias();
            cTextoRango = ObtenerDias.ObtenerTextoRangoTiempo(tiempo);
            Assert.IsTrue(string.IsNullOrWhiteSpace(cTextoRango));
        }
    }
}