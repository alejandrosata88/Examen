using System;

namespace AliExpress.Servicio.Interface
{
    public interface IObtenerRangoTiempo
    {
        IObtenerRangoTiempo Siguiente(IObtenerRangoTiempo _IObtenerRangoTiempo);

        string ObtenerTextoRangoTiempo(TimeSpan _tiempo);
    }
}
