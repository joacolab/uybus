using BuisnessLayer.interfaces;
using DataAcessLayer;
using DataAcessLayer.implementation;
using DataAcessLayer.interfaces;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Share.DTOs;
using Share.entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.implementation
{
    public class BL_Usuario : IBL_Usuario
    {
        private IDAL_Persona iPersona;
        private IDAL_Usuario iUsuario;
        private IDAL_Linea iLinea;
        private IDAL_Salida iSalida;
        private IDAL_Tramo iTramo;
        private IDAL_Viaje iViaje;
        private IDAL_Pasaje iPasaje;
        private IDAL_Parametro iParametro;
        private IDAL_Parada iParada;
        private IDAL_Llegada iLlegada;
        private IDAL_Vehiculo iVehiculo;
        

        public BL_Usuario(IDAL_Persona _iPersona, IDAL_Usuario _iUsuario, IDAL_Linea _iLinea, IDAL_Salida _iSalida, IDAL_Tramo _iTramo, IDAL_Viaje _iViaje, IDAL_Pasaje _iPasaje, IDAL_Parametro _iParametro, IDAL_Parada _iParada, IDAL_Llegada _iLlegada, IDAL_Vehiculo _iVehiculo)
        {
            iPersona = _iPersona;
            iUsuario = _iUsuario;
            iLinea = _iLinea;
            iSalida = _iSalida;
            iTramo = _iTramo;
            iViaje = _iViaje;
            iPasaje = _iPasaje;
            iParametro = _iParametro;
            iParada = _iParada;
            iLlegada = _iLlegada;
            iVehiculo = _iVehiculo;
        }
        /// <summary>
        ///  
        /// </summary>
        /// <param name="idViaje"></param>
        /// <param name="idUsuario"> -1 si el usuario no esta logeado. </param>
        /// <param name="idParadaOrigen"></param>
        /// <param name="idParadaDestino"></param>
        /// <param name="tipoDoc"> "vacio" si el usaurio esta logeado.</param>
        /// <param name="documento"> "vacio" si el usaurio esta  logeado.</param>
        /// <param name="asiento"> Se gurdara -1 si, el costo de pasaje es inferior al parámetro.</param>
        /// <returns></returns>
        public EPasaje comprarPasaje(int idViaje, int idUsuario, int idParadaOrigen, int idParadaDestino, string tipoDoc, string documento, int asiento)
        {
            
            EViaje ev = iViaje.getViaje(idViaje);
            if (ev == null) return null; //Si no encuentra el viaje retorna null
            ESalida es = iSalida.getSalidas(ev.IdSalida);
            if (es == null) return null; //Si no encuentra una salida retorna null
            ELinea el = iLinea.getLinea(es.IdLinea);
            if (el == null) return null; //Si no encuentra una linea retorna null
            List<ETramo> tramos = el.Tramo.ToList<ETramo>();
            int posOrigen = -1;
            int posdestino = -1;
            foreach (var t in tramos)
            {
                if (t.IdLinea == el.IdLinea && t.IdParada == idParadaOrigen)
                {
                    posOrigen = tramos.IndexOf(t);
                }
                if (t.IdLinea == el.IdLinea && t.IdParada == idParadaDestino)
                {
                    posdestino = tramos.IndexOf(t);
                }
            }
            
            List<ETramo> subTramos = new List<ETramo>();
            
            for (int e = posOrigen; e <= posdestino; e++)
            {
                subTramos.Add(tramos.ElementAt(e));
            }
            
            int cosotP = 0;

            foreach (var s in subTramos)
            {
                cosotP = cosotP + iTramo.valorVigente(s.IdLinea, s.IdParada);
            }
            
            EParametro epara = iParametro.getAllParametros().Last();
            
            if (epara.Valor > cosotP) asiento = -1;
      
            EPasaje ep = new EPasaje();
            if (idUsuario == -1) //Usuario NOO logeado
            {
                ep = iPasaje.addPasaje(asiento, documento, tipoDoc, idViaje, idParadaDestino, idParadaOrigen, idUsuario);

                //esto no va, es una prueba, codigo pelotas
                //enviarCorreo("juan.alvarez@utec.edu.uy", ep.IdPasaje.ToString());//generar pdf con codigo QR y enviarlo 
                enviarCorreo("julio.arrieta@utec.edu.uy", ep.IdPasaje.ToString());//generar pdf con codigo QR y enviarlo
                //enviarCorreo("lucas.garrido@utec.edu.uy", "https://4.bp.blogspot.com/_xukD7iTXxKo/R6kUSmPim-I/AAAAAAAAAFg/JDYuhXlPdHA/s320/perros+culiando.jpg");//generar pdf con codigo QR y enviarlo
                //enviarCorreo("gustavo.cerdena@utec.edu.uy", ep.IdPasaje.ToString());//generar pdf con codigo QR y enviarlo
                enviarCorreo("karloxx09@gmail.com", "asfsfsf");//generar pdf con codigo QR y enviarlo
            }
            else //Usuario Logeado
            {
                EPersona epe = iPersona.getPersona(idUsuario);
                string strTipoDoc;
                if (epe.TipoDocumento == 1) strTipoDoc = "CI";
                else strTipoDoc = "Credencial";

                ep = iPasaje.addPasaje(asiento, epe.Documento, strTipoDoc, idViaje, idParadaDestino, idParadaOrigen, idUsuario);
                enviarCorreo(iPersona.getPersona(idUsuario).Correo, ep.IdPasaje.ToString());//generar pdf con codigo QR y enviarlo 
            }

            return ep;
           
        }
        private void getPdfconQR(string IDPasaje)
        {
            Document doc = new Document(PageSize.A4);
            //string path = Directory.GetCurrentDirectory();
            //PdfWriter.GetInstance(doc, new FileStream( path + @"pdf\pasaje.pdf", FileMode.Create));
            string outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), @"pdf", "pasaje.pdf");
            PdfWriter.GetInstance(doc, new FileStream(outputFile, FileMode.Create));
            doc.Open();
            BarcodeQRCode barcodeWrcode = new BarcodeQRCode(IDPasaje, 1000,1000,null);
            Image codeQRImga = barcodeWrcode.GetImage();
            codeQRImga.ScaleAbsolute(200,200);
            doc.Add(codeQRImga);
            doc.Close();
        }
        private void enviarCorreo(string correo, string IDPasaje)//generar pdf con codigo QR y enviarlo 
        {

            using (MailMessage emailMessage = new MailMessage())
            {
                emailMessage.From = new MailAddress("UruguayBus.2020@gmail.com", "UruguayBus");
                emailMessage.To.Add(new MailAddress(correo, "Pasajero")); //correo del pasajero
                emailMessage.Subject = "UruguayBus";
                emailMessage.Body = "";
                getPdfconQR(IDPasaje);
                string path = Directory.GetCurrentDirectory();
                emailMessage.Attachments.Add(new Attachment(path + @"\pdf\pasaje.pdf"));
                string outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), @"pdf", "pasaje.pdf");
                emailMessage.Attachments.Add(new Attachment(outputFile));
                emailMessage.Priority = MailPriority.Normal;
                using (SmtpClient MailClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    MailClient.EnableSsl = true;
                    MailClient.Credentials = new System.Net.NetworkCredential("UruguayBus.2020@gmail.com", "E4#r6%t,#.2E5g8");
                    MailClient.Send(emailMessage);
                }
            }
        }

        private int getOrd(List<ETramo> tramos, int ord)
        {
            foreach (var t in tramos)
            {
                if (t.Orden == ord) return t.IdParada;
            }
            return -1;
        }

        private EParada ultimaParada(int idViaje)
        {
            EViaje ev = iViaje.getViaje(idViaje);
            List<ELlegada> llegadas = ev.Llegada.ToList();

            llegadas.OrderBy(d => d.fecha);
            DateTime ultimaF = llegadas.Last().fecha;
            List<ELlegada> ultllegadasF = new List<ELlegada>();
            foreach (var item in llegadas)
            {
                if(item.fecha == ultimaF) ultllegadasF.Add(item);
            }
            ultllegadasF.OrderBy(d => d.hora);
            ELlegada ultimaLLeg = ultllegadasF.Last();
            return iParada.getParada(ultimaLLeg.idParada);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="idParada">Que no sea la terminal</param>
        /// <returns></returns>
        public List<DTOproxVehiculo> proximoVehiculo(int idUsuario, int idParada)
        {
            List<DTOproxVehiculo> proxVs = new List<DTOproxVehiculo>();
            
            EParada ep = iParada.getParada(idParada);

            List<ETramo> tramos = ep.Tramo.ToList(); // lista de tramos

            List<int> idLineas = new List<int>();
            foreach (var t in tramos)
            {
                idLineas.Add(t.IdLinea);
            }
            idLineas.Distinct(); // lista de lineas

            int ord = 0;
            int idpa = 0;
            List<EParada> paradasAnteriores = new List<EParada>();
            foreach (var idL in idLineas)
            {
                ord = iTramo.getTramos(idL, idParada).Orden -1;
                if (ord == 0) throw new Exception("La parada no puede ser la terminal");
                idpa = getOrd(iLinea.getLinea(idL).Tramo.ToList(), ord);
                paradasAnteriores.Add(iParada.getParada(idpa));
            }

            //lista de viajes de una parada hordendaos por hora
            List<EViaje> viajes = new List<EViaje>();
            foreach (var par in paradasAnteriores)
            {
                foreach (var ll in par.Llegada)
                {
                    if(ultimaParada(ll.idViaje) != iParada.getParada(idParada)) viajes.Add(iViaje.getViaje(ll.idViaje));
                }
            }

            List<EViaje> misViajs = new List<EViaje>();
            EUsuario usuario = iUsuario.getUsuario(idUsuario);
            if (usuario == null) return null;
            foreach (var pasaje in iUsuario.getUsuario(idUsuario).Pasaje.ToList())
            {
                misViajs.Add(iViaje.getViaje(pasaje.IdViaje));
            }

            foreach (var viaje in viajes)
            {
                foreach (var miV in misViajs)
                {
                    DTOproxVehiculo proxV = new DTOproxVehiculo();
                    proxV.linea = iLinea.getLinea(iSalida.getSalidas(miV.IdSalida).IdLinea).Nombre;
                    proxV.Vehiculo = iVehiculo.getVehiculos(iSalida.getSalidas(viaje.IdSalida).IdVehiculo);
                    if (viaje.IdViaje == miV.IdViaje) proxV.reservado = true;
                    else proxV.reservado = false;
                    proxVs.Add(proxV);
                }
            }
            
            List<DTOproxVehiculo> proximos = proxVs
                  .GroupBy(p => p.Vehiculo.Matricula)
                  .Select(g => g.First())
                  .ToList();

            return proximos;
            
        }

        public List<ELinea> listarLineas()
        {
            return iLinea.getAllLineas();
        }

        public List<ESalida> GetSalidas(int lineaSelected)
        {
            List<ESalida> salidas = new List<ESalida>();
            foreach (var salida in iLinea.getLinea(lineaSelected).Salida.ToList())
            {
                if (salida.Viaje.ToList().Count > 0) 
                {
                   salidas.Add(salida);
                }
            }
            return salidas;
        }



        public List<EViaje> GetFechasViajes(int IdSalida) 
        {
            return iSalida.getSalidas(IdSalida).Viaje.ToList();
        }

        private List<EParada> sinPuntas( ELinea linea)
        {
            List<EParada> lstParadas = new List<EParada>();

            List<ETramo> lstTramos = linea.Tramo.ToList();

            List<ETramo> SortedList = lstTramos.OrderBy(o => o.Orden).ToList();

            int ultimoTramo = SortedList.Count() - 1;

            SortedList.RemoveAt(ultimoTramo);
            SortedList.RemoveAt(0);

            foreach (var tramo in SortedList)
            {
                lstParadas.Add(iParada.getParada(tramo.IdParada));
            }
            return lstParadas;
        }

        public List<EParada> sinTerminales() //todas la paradas menos las terminales.
        {
            List<EParada> sinTerminales = new List<EParada>();
            foreach (var linea in iLinea.getAllLineas())
            {
                foreach (var parada in sinPuntas(linea))
                {
                    sinTerminales.Add(parada);
                }
            }
            List<EParada> sinTerNiRep = sinTerminales
                  .GroupBy(p => p.IdParada)
                  .Select(g => g.First())
                  .ToList();

            //List<EParada> sinTerNiRep = sinTerminales.Distinct().ToList();
            return sinTerNiRep;
        }

        public List<EParada> listarParadas(int IdLinea) //todas la paradas menos la terminal de salida
        {
            List<EParada> lstParadas = new List<EParada>();
            ELinea linea =  iLinea.getLinea(IdLinea);
            List<ETramo> lstTramos = linea.Tramo.ToList();

            List<ETramo> SortedList = lstTramos.OrderBy(o => o.Orden).ToList();

            int ultimoTramo = SortedList.Count() -1;

            SortedList.RemoveAt(ultimoTramo);

            foreach (var tramo in SortedList)
            {
                lstParadas.Add(iParada.getParada(tramo.IdParada));
            }
            return lstParadas;
        }

        public List<EParada> listarParadasD(int IdLinea, int IdParada)//todas la paradas menos la terminal de llegada
        {

            ETramo tramoOrigen = new ETramo();
            ELinea linea = iLinea.getLinea(IdLinea);

            List<EParada> lstParadas = new List<EParada>();
            List<ETramo> lstTramos = linea.Tramo.ToList();
            // int con el primero y pasarle un range (ese int, last tramo -1)

            List<ETramo> SortedList = lstTramos.OrderBy(o => o.Orden).ToList();
            foreach (var item in SortedList)
            {
                if (item.IdLinea == IdLinea && item.IdParada == IdParada)
                {
                    tramoOrigen = item;
                }
            }
            int indexOrigen = SortedList.IndexOf(tramoOrigen) + 1;

           
            int Largo = SortedList.Count();


            List<ETramo> tramosF = new List<ETramo>();
            for (int i = indexOrigen; i < Largo; i++)
            {
                tramosF.Add(SortedList.ElementAt(i));

            }

            foreach (var tramo in tramosF)
            {
                lstParadas.Add(iParada.getParada(tramo.IdParada));
            }
            return lstParadas;
        }
        /*
                public List<EViaje> GetViajes(int IdSalida)
                {
                    return iSalida.getSalidas(IdSalida).Viaje.ToList();
                }
        */
        public List<int> GetAsientos(int fechaSelected)
        {
            EViaje viaje = iViaje.getViaje(fechaSelected);
            ESalida salida = iSalida.getSalidas(viaje.IdSalida);
            EVehiculo vehiculo =  iVehiculo.getVehiculos(salida.IdVehiculo);
            int cantidadDeAsientos = vehiculo.CantAsientos;
            List<EPasaje> lstPasajes = viaje.Pasaje.ToList();

            List<int> lstPasajesOcupados = new List<int>();

            foreach (var pasaje in lstPasajes)
            {
                if (pasaje.Asientos != null)
                {
                   lstPasajesOcupados.Add((int)pasaje.Asientos);
                }
            }
            List<int> listaTotal = new List<int>();
            for (int i = 1; i <= cantidadDeAsientos; i++)
            {
                listaTotal.Add(i);
            }
            List<int> asientosLibres = listaTotal.Except(lstPasajesOcupados).ToList();
            return asientosLibres;
        }
        public bool canSelectSeat(int IdLinea, int idParadaOrigen, int idParadaDestino) 
        {
            int cosotP = precioDelPasaje(IdLinea, idParadaOrigen, idParadaDestino);
            EParametro epara = iParametro.getAllParametros().Last();
            if (epara.Valor > cosotP)
            {
                return false;
            }

            return true;
        }

        public int precioDelPasaje(int IdLinea, int idParadaOrigen, int idParadaDestino)
        {
            ELinea el = iLinea.getLinea(IdLinea);
            List<ETramo> tramos = el.Tramo.ToList<ETramo>();

            int posOrigen = -1;
            int posdestino = -1;
            foreach (var t in tramos)
            {
                if (t.IdLinea == el.IdLinea && t.IdParada == idParadaOrigen)
                {
                    posOrigen = tramos.IndexOf(t);
                }
                if (t.IdLinea == el.IdLinea && t.IdParada == idParadaDestino)
                {
                    posdestino = tramos.IndexOf(t);
                }
            }

            List<ETramo> subTramos = new List<ETramo>();

            for (int e = posOrigen; e <= posdestino; e++)
            {
                subTramos.Add(tramos.ElementAt(e));
            }

            int cosotP = 0;

            foreach (var s in subTramos)
            {
                cosotP = cosotP + iTramo.valorVigente(s.IdLinea, s.IdParada);
            }

            return cosotP;
        }
    }
}
