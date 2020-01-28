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
    public class ObtenerMesesUTests
    {
        [TestMethod()]
        public void ObtenerTextoRangoTiempo_EnviaTiempoVacio_ObtieneMensajeVacio()
        {
            string cTextoRango = string.Empty;
            TimeSpan tiempo = new TimeSpan();
            ObtenerMeses ObtenerMeses = new ObtenerMeses();
            cTextoRango = ObtenerMeses.ObtenerTextoRangoTiempo(tiempo);
            Assert.IsTrue(string.IsNullOrWhiteSpace(cTextoRango));
        }

        [TestMethod()]
        public void ObtenerTextoRangoTiempo_EnviaTiempoVacio_ObtieneMensaje()
        {
            string cTextoRango = string.Empty;
            TimeSpan tiempo = new TimeSpan();
            tiempo = DateTime.Now.AddDays(42).Subtract(DateTime.Now);
            ObtenerMeses ObtenerMeses = new ObtenerMeses();
            cTextoRango = ObtenerMeses.ObtenerTextoRangoTiempo(tiempo);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(cTextoRango));
        }
    }
}