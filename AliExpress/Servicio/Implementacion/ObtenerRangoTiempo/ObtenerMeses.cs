using System;

namespace AliExpress.Servicio.Implementacion.ObtenerRangoTiempo
{
    class ObtenerMeses : ManejadorRangoTiempo
    {
        public override string ObtenerTextoRangoTiempo(TimeSpan _tiempo)
        {
            string cTextoRango = string.Empty;
            int iNumeroMeses= Convert.ToInt32(_tiempo.TotalDays)/30;
            if (iNumeroMeses >= 1)
                cTextoRango = string.Format("{0} Meses", iNumeroMeses);
            return cTextoRango;
        }
    }
}
