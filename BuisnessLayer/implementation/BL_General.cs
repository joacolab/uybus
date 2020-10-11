using BuisnessLayer.interfaces;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.implementation
{
    public class BL_General : IBL_General
    {
        public void finalizarViaje(int idViaje)
        {
            throw new NotImplementedException();
        }

        public void notificacionProximidad()
        {
            throw new NotImplementedException();
        }

        public float reporteUtilidad(int idViaje, DateTime fechaDesde, DateTime fechaHasat, int linea, int salida)
        {
            throw new NotImplementedException();
        }

        public List<Pasaje> reposrtesPasajes(DateTime fechaDesde, DateTime fechaHasat, int linea, int horario)
        {
            throw new NotImplementedException();
        }
    }
}
