using System;

namespace AliExpress.Entidad
{
    public class Pedido
    {
        public string cOrigen { get; set; }
        public string cDestino {get; set;}
        public int iDistancia { get; set; }
        public string cPaqueteria { get; set; }
        public string cMedioTransporte { get; set; }
        public DateTime dtPedido { get; set; }
        public Paqueteria entPaqueteria { get; set; }
        public Transporte entTransporte { get; set; }
    }
}
