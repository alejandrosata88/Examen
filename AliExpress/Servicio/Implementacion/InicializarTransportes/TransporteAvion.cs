using AliExpress.Entidad;
using AliExpress.Servicio.Interface;

namespace AliExpress.Servicio.Implementacion.InicializarTransportes
{
    class TransporteAvion: IInicializarTransportes
    {
        public Transporte CrearTransporte()
        {
            Transporte entTransporte = new Transporte()
            {
                ETransporte = Entidad.Enum.EnumTransporte.AVION,
                iCostoKilometro = 10,
                iVelodicad = 600
            };
            return entTransporte;
        }   
    }
}
