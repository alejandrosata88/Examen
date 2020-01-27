using AliExpress.Entidad;
using AliExpress.Servicio;
using AliExpress.Servicio.Implementacion.InicializarPaqueterias;
using AliExpress.Servicio.Implementacion.InicializarTransportes;
using AliExpress.Servicio.Implementacion.LectorArchivo;
using AliExpress.Servicio.Implementacion.TransportesPorPaqueteria;
using AliExpress.Servicio.Implementacion.Validacion;
using AliExpress.Servicio.Implementacion.ObtenerRangoTiempo;
using AliExpress.Servicio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using AliExpress.Servicio.Implementacion.GenerarMensaje;
using AliExpress.Servicio.Implementacion.VerificarOpcionEconomica;
using AliExpress.Servicio.Implementacion.AsignarPaqueteria;

namespace AliExpress.Controller
{
    public class Cliente
    {
        public void Menu()
        {
            string cFormatoMesaje = string.Empty, cMensajePedido = string.Empty;
            bool lEntregado = false;
            DateTime dtFechaHoy = DateTime.Now;
            List<string> lstErrores = new List<string>(), lstMensajes = new List<string>();
            List<Pedido> lstPedido = new List<Pedido>();
            List<Paqueteria> lstPaqueteria = new List<Paqueteria>();
            ILectorArchivo IlectorArchivo = new LectorArchivoTexto();
            IValidacion IValidacion = new Validaciones();
            List<IInicializarTransportes> lstIInicializarTransportes = new List<IInicializarTransportes>();
            IVerificarOpcionEconomica IVerificarOpcionEconomica = new EvaluarOpcionEconominca();
            IAsignarPaqueteria IAsignarPaqueteria =new  AsignarEntidades();
            cFormatoMesaje = "Tu paquete {0} de {1} y {2} a {3} {4} {5} y {6} un costo de {7} (Cualquier reclamación con {8}).";

            ObtenerMinutos ObtenerMinutos = new ObtenerMinutos();
            ObtenerHoras ObtenerHoras = new ObtenerHoras();
            ObtenerDias ObtenerDias = new ObtenerDias();
            ObtenerMeses ObtenerMeses = new ObtenerMeses();

            ObtenerMinutos.Siguiente(ObtenerHoras);
            ObtenerHoras.Siguiente(ObtenerDias);
            ObtenerDias.Siguiente(ObtenerMeses);

            IGenerarMensaje IGenerarMensaje = new GenerarMensajePedido(ObtenerMinutos, IVerificarOpcionEconomica);

            lstIInicializarTransportes.Clear();
            lstIInicializarTransportes.Add(new TransporteBarco());
            ITransportesPorPaqueteria ITransportesPorPaqueteria = new CrearTransportes(lstIInicializarTransportes);
            IInicializarPaqueterias IInicializarPaqueterias = new PaqueteriaFedex(ITransportesPorPaqueteria);
            lstPaqueteria.Add(IInicializarPaqueterias.CrearPaqueteria());

            lstIInicializarTransportes.Clear();
            lstIInicializarTransportes.Add(new TransporteAvion());
            lstIInicializarTransportes.Add(new TransporteBarco());
            ITransportesPorPaqueteria = new CrearTransportes(lstIInicializarTransportes);
            IInicializarPaqueterias = new PaqueteriaDHL(ITransportesPorPaqueteria);
            lstPaqueteria.Add(IInicializarPaqueterias.CrearPaqueteria());

            lstIInicializarTransportes.Clear();
            lstIInicializarTransportes.Add(new TransporteTren());
            ITransportesPorPaqueteria = new CrearTransportes(lstIInicializarTransportes);
            IInicializarPaqueterias = new PaqueteriaEstafeta(ITransportesPorPaqueteria);
            lstPaqueteria.Add(IInicializarPaqueterias.CrearPaqueteria());


            lstPedido = IlectorArchivo.ObtenerPedidos();

            foreach (Pedido entPedido in lstPedido)
            {
                Console.ResetColor();
                lstErrores = new List<string>();
                lstErrores =IValidacion.ValidarCampos(entPedido, lstPaqueteria);
                if (!lstErrores.Any())
                {
                    IAsignarPaqueteria.AsignarEntidadPaqueteria(entPedido, lstPaqueteria);
                    cMensajePedido = IGenerarMensaje.CrearMensajeDePedido(entPedido, dtFechaHoy, cFormatoMesaje, lstPaqueteria,ref lEntregado);
                    if(lEntregado)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(cMensajePedido + "\n");
                }
                else
                {
                    foreach (string cError in lstErrores)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(cError + "\n");
                    }
                }
            }
            Console.ReadLine();

        }
    }
}
