using System;

namespace AliExpress.Servicio.Implementacion.ObtenerRangoTiempo
{
    class ObtenerDias : ManejadorRangoTiempo
    {
        public override string ObtenerTextoRangoTiempo(TimeSpan _tiempo)
        {
            string cTextoRango = string.Empty;
            int iNumeroDias = Convert.ToInt32(_tiempo.TotalDays);
            if (iNumeroDias >= 1 && iNumeroDias < 30)
                cTextoRango = string.Format("{0} Días", iNumeroDias);
            else
                cTextoRango = base.ObtenerTextoRangoTiempo(_tiempo);
            return cTextoRango;
        }
    }
}
