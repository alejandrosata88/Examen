using System.Collections.Generic;
using AliExpress.Entidad;
using AliExpress.Servicio.Interface;

namespace AliExpress.Servicio.Implementacion.TransportesPorPaqueteria
{
    public class CrearTransportes : ITransportesPorPaqueteria
    {
        List<IInicializarTransportes> lstIInicializarTransportes { get; set; }

        public CrearTransportes(List<IInicializarTransportes> _lstIInicializarTransportes)
        {
            lstIInicializarTransportes = _lstIInicializarTransportes;
        }

        public List<Transporte> CrearListaTransportesPorPaquetria()
        {
            List<Transporte> lstTransporte = new List<Transporte>();
            foreach (IInicializarTransportes IInicializarTransportes in lstIInicializarTransportes)
            {
                lstTransporte.Add(IInicializarTransportes.CrearTransporte());
            }
            return lstTransporte;
        }
    }
}
