using AliExpress.Entidad;
using AliExpress.Entidad.Enum;
using AliExpress.Servicio.Interface;

namespace AliExpress.Servicio.Implementacion.InicializarPaqueterias
{
    public class PaqueteriaDHL: IInicializarPaqueterias
    {
        ITransportesPorPaqueteria ITransportesPorPaqueteria { get; set; }

        public PaqueteriaDHL(ITransportesPorPaqueteria _ITransportesPorPaqueteria)
        {
            ITransportesPorPaqueteria = _ITransportesPorPaqueteria;
        }

        public Paqueteria CrearPaqueteria()
        {
            Paqueteria entPaqueteria = new Paqueteria()
            {
                EEmpresa = EnumEmpresa.DHL,
                iMargenUtilidad = 40,
                lstETransporte = ITransportesPorPaqueteria.CrearListaTransportesPorPaquetria()
            };
            return entPaqueteria;
        }
    }
}
