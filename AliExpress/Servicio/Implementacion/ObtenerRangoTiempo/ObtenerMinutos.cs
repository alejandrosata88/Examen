using System;

namespace AliExpress.Servicio.Implementacion.ObtenerRangoTiempo
{
    public class ObtenerMinutos : ManejadorRangoTiempo
    {
        public override string ObtenerTextoRangoTiempo(TimeSpan _tiempo)
        {
            string cTextoRango = string.Empty;
            int iNumeroMinutos = Convert.ToInt32(_tiempo.TotalMinutes);
            if (iNumeroMinutos <= 59)
                cTextoRango = string.Format("{0} Minutos", iNumeroMinutos);
            else
                cTextoRango = base.ObtenerTextoRangoTiempo(_tiempo);
            return cTextoRango;
        }
    }
}
