using AliExpress.Entidad;
using AliExpress.Servicio.Interface;

namespace AliExpress.Servicio.Implementacion.InicializarTransportes
{
    public class TransporteBarco : IInicializarTransportes
    {
        public Transporte CrearTransporte()
        {
            Transporte entTransporte = new Transporte()
            {
                ETransporte = Entidad.Enum.EnumTransporte.BARCO,
                iCostoKilometro = 1,
                iVelodicad = 46
            };
            return entTransporte;
        }
    }
}
