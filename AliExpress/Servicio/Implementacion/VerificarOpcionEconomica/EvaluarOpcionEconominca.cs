using System.Collections.Generic;
using System.Linq;
using AliExpress.Entidad;
using AliExpress.Servicio.Interface;

namespace AliExpress.Servicio.Implementacion.VerificarOpcionEconomica
{
    public class EvaluarOpcionEconominca : IVerificarOpcionEconomica
    {
        public string ObtenerOpcioneEconomica(Pedido _Pedido, List<Paqueteria> _lstPaqueteria, decimal _dCostoEnvio)
        {
            string cMensaje = string.Empty;
            Transporte entTransporte = new Transporte();
            List<Paqueteria> lstPaqueteriasOpcionales = new List<Paqueteria>();
            decimal dCostoMenor = 0.0M, dCostoNuevo=0.0M, dDiferencia=0.0M;
            dCostoMenor = _dCostoEnvio;
            lstPaqueteriasOpcionales = _lstPaqueteria.Where(w => w.EEmpresa != _Pedido.entPaqueteria.EEmpresa &&
                                                                 w.lstETransporte
                                                                  .Select(s => s.ETransporte)
                                                                  .Contains(_Pedido.entTransporte.ETransporte))
                                                     .Select(s1 => s1).ToList();
            if(lstPaqueteriasOpcionales.Any())
            {
                foreach(Paqueteria entPaqueteria in lstPaqueteriasOpcionales)
                {
                    entTransporte = entPaqueteria.lstETransporte
                                .Where(w=>w.ETransporte== _Pedido.entTransporte.ETransporte)
                                .Select(s=>s).FirstOrDefault();
                    dCostoNuevo = ObtenerCostoEnvioEconomico(_Pedido, entPaqueteria, entTransporte);
                    if (dCostoNuevo < dCostoMenor)
                    {
                        dCostoMenor = dCostoNuevo;
                        dDiferencia = _dCostoEnvio - dCostoMenor;
                        cMensaje =string.Format("Si hubieras pedido en {0} te hubiera costado {1} menos", entPaqueteria.EEmpresa.ToString(), dDiferencia.ToString());
                    }
                }
            }
            return cMensaje;
        }

        public decimal ObtenerCostoEnvioEconomico(Pedido _Pedido, Paqueteria _entPaqueteria, Transporte _Transporte)
        {
            decimal dCostoEnvio = 0.0M;
            dCostoEnvio = (_Transporte.iCostoKilometro * _Pedido.iDistancia) + (1 + ((decimal)_entPaqueteria.iMargenUtilidad / 100));
            return dCostoEnvio;
        }
    }
}
