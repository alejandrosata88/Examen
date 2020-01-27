using System;
using AliExpress.Servicio.Interface;

namespace AliExpress.Servicio.Implementacion.ObtenerRangoTiempo
{
    public abstract class ManejadorRangoTiempo : IObtenerRangoTiempo
    {
        private IObtenerRangoTiempo SiguienteIObtenerRangoTiempo;

        public IObtenerRangoTiempo Siguiente(IObtenerRangoTiempo _IObtenerRangoTiempo)
        {
            this.SiguienteIObtenerRangoTiempo = _IObtenerRangoTiempo;
            return _IObtenerRangoTiempo;
        }

        public virtual string ObtenerTextoRangoTiempo(TimeSpan _tiempo)
        {
            string cMensaje = string.Empty;
            if (this.SiguienteIObtenerRangoTiempo != null)
                cMensaje = this.SiguienteIObtenerRangoTiempo.ObtenerTextoRangoTiempo(_tiempo);
            else
                cMensaje = string.Empty;
            return cMensaje;
        }
    }
}
