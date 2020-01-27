using AliExpress.Entidad;
using AliExpress.Entidad.Enum;
using AliExpress.Servicio.Interface;

namespace AliExpress.Servicio.Implementacion.InicializarPaqueterias
{
    class PaqueteriaEstafeta : IInicializarPaqueterias
    {
        ITransportesPorPaqueteria ITransportesPorPaqueteria { get; set; }

        public PaqueteriaEstafeta(ITransportesPorPaqueteria _ITransportesPorPaqueteria)
        {
            ITransportesPorPaqueteria = _ITransportesPorPaqueteria;
        }

        public Paqueteria CrearPaqueteria()
        {
            Paqueteria entPaqueteria = new Paqueteria()
            {
                EEmpresa = EnumEmpresa.ESTAFETA,
                iMargenUtilidad = 20,
                lstETransporte = ITransportesPorPaqueteria.CrearListaTransportesPorPaquetria()
            };
            return entPaqueteria;
        }
    }
}
