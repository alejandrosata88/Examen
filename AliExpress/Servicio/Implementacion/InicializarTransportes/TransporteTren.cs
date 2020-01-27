using AliExpress.Entidad;
using AliExpress.Servicio.Interface;

namespace AliExpress.Servicio.Implementacion.InicializarTransportes
{
    class TransporteTren : IInicializarTransportes
    {
        public Transporte CrearTransporte()
        {
            Transporte entTransporte = new Transporte()
            {
                ETransporte= Entidad.Enum.EnumTransporte.TREN,
                iCostoKilometro=4,
                iVelodicad=80
            };
            return entTransporte;
        }
    }
}
