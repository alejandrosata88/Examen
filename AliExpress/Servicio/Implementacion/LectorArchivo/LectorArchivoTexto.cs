﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            Pedido entPedido = null;
            if (_lstCampos!=null && _lstCampos.Any())
            {
                entPedido = new Pedido()
                {
                    cOrigen = _lstCampos[0] != null ? _lstCampos[0] : null,
                    cDestino = _lstCampos[1] != null ? _lstCampos[1] : null,
                    iDistancia = _lstCampos[2] != null ? int.Parse(_lstCampos[2]) : 0,
                    cPaqueteria = _lstCampos[3] != null ? _lstCampos[3] : null,
                    cMedioTransporte = _lstCampos[4] != null ? _lstCampos[4] : null,
                    dtPedido = _lstCampos[5] != null ? DateTime.Parse(_lstCampos[5]) : new DateTime()
                };
            }
            return entPedido;
        }
    }
}
