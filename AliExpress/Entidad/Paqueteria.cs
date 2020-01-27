using AliExpress.Entidad.Enum;
using System.Collections.Generic;

namespace AliExpress.Entidad
{
    public class Paqueteria
    {
        public EnumEmpresa EEmpresa { get; set; }
        public List<Transporte> lstETransporte { get; set; }
        public int iMargenUtilidad {get; set;}
    }
}
