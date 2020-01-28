using AliExpress.Entidad;
using AliExpress.Entidad.Enum;
using AliExpress.Servicio.Interface;

namespace AliExpress.Servicio.Implementacion.InicializarPaqueterias
{
    public class PaqueteriaFedex : IInicializarPaqueterias
    {
        ITransportesPorPaqueteria ITransportesPorPaqueteria { get; set; }

        public PaqueteriaFedex(ITransportesPorPaqueteria _ITransportesPorPaqueteria)
        {
            ITransportesPorPaqueteria = _ITransportesPorPaqueteria;
        }

        public Paqueteria CrearPaqueteria()
        {
            Paqueteria entPaqueteria = new Paqueteria()
            {
                EEmpresa = EnumEmpresa.FEDEX,
                iMargenUtilidad = 50,
                lstETransporte = ITransportesPorPaqueteria.CrearListaTransportesPorPaquetria()
            };
            return entPaqueteria;
        }
    }
}
