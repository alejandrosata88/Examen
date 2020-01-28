using Microsoft.VisualStudio.TestTools.UnitTesting;
using AliExpress.Servicio.Implementacion.ObtenerRangoTiempo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliExpress.Servicio.Implementacion.ObtenerRangoTiempo.Tests
{
    [TestClass()]
    public class ObtenerMinutosUTests
    {
        [TestMethod()]
        public void ObtenerTextoRangoTiempo_EnviaTiempoVacio_ObtieneMensajeVacio()
        {
            string cTextoRango = string.Empty;
            TimeSpan tiempo = new TimeSpan();
            ObtenerMinutos ObtenerMinutos = new ObtenerMinutos();
            cTextoRango = ObtenerMinutos.ObtenerTextoRangoTiempo(tiempo);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(cTextoRango));
        }

        [TestMethod()]
        public void ObtenerTextoRangoTiempo_EnviaTiempoVacio_ObtieneMensaje()
        {
            string cTextoRango = string.Empty;
            TimeSpan tiempo = new TimeSpan();
            tiempo = DateTime.Now.AddMinutes(50).Subtract(DateTime.Now);
            ObtenerMinutos ObtenerMinutos = new ObtenerMinutos();
            cTextoRango = ObtenerMinutos.ObtenerTextoRangoTiempo(tiempo);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(cTextoRango));
        }

        [TestMethod()]
        public void ObtenerTextoRangoTiempo_EnviaTiempoVacio_ObtieneMensajeSiguienteVacio()
        {
            string cTextoRango = string.Empty;
            TimeSpan tiempo = new TimeSpan();
            tiempo = DateTime.Now.AddHours(120).Subtract(DateTime.Now);
            ObtenerMinutos ObtenerMinutos = new ObtenerMinutos();
            cTextoRango = ObtenerMinutos.ObtenerTextoRangoTiempo(tiempo);
            Assert.IsTrue(string.IsNullOrWhiteSpace(cTextoRango));
        }
    }
}