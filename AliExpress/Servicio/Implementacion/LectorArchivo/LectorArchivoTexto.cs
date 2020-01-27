using System;
using System.Collections.Generic;
using System.IO;
using AliExpress.Entidad;

namespace AliExpress.Servicio.Implementacion.LectorArchivo
{
    public class LectorArchivoTexto : ILectorArchivo
    {
        public List<Pedido> ObtenerPedidos()
        {
            List<Pedido> lstEntPedido = new List<Pedido>();
            string cUbicacion = Path.GetFullPath("pedido.txt");
            string[] lstLineas = null;
            string[] lstCampos = null;
            if(File.Exists(cUbicacion))
            {
                lstLineas=File.ReadAllLines(cUbicacion);
                foreach(string cLinea in lstLineas)
                {
                    lstCampos=cLinea.Split(',');
                    lstEntPedido.Add(ObtenerEntidad(lstCampos));
                }
            }
            return lstEntPedido;
        }

        public Pedido ObtenerEntidad(string[] _lstCampos)
        {
            Pedido entPedido = new Pedido()
            {
                cOrigen = _lstCampos[0],
                cDestino = _lstCampos[1],
                iDistancia = int.Parse(_lstCampos[2]),
                cPaqueteria = _lstCampos[3],
                cMedioTransporte = _lstCampos[4],
                dtPedido = DateTime.Parse(_lstCampos[5])
            };
            return entPedido;
        }
    }
}
