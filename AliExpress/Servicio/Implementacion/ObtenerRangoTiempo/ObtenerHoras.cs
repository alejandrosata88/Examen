using System;

namespace AliExpress.Servicio.Implementacion.ObtenerRangoTiempo
{
    public class ObtenerHoras : ManejadorRangoTiempo
    {
        public override string ObtenerTextoRangoTiempo(TimeSpan _tiempo)
        {
            string cTextoRango = string.Empty;
            int iNumeroHoras = Convert.ToInt32(_tiempo.TotalHours);
            if (iNumeroHoras >= 1 && iNumeroHoras < 24)
                cTextoRango = string.Format("{0} Horas", iNumeroHoras);
            else
                cTextoRango = base.ObtenerTextoRangoTiempo(_tiempo);
            return cTextoRango;
        }
    }
}
