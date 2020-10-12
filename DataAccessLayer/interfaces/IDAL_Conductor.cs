﻿using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.interfaces
{
    public interface IDAL_Conductor
    {
        EConductor addConductor(int idPersona, DateTime FechaVenc);
        List<EConductor> getAllConductores();
        EConductor getConductor(int idConductor);

        void updateFechaVencLib(int idConductor, DateTime FechaVenc);

    }
}
