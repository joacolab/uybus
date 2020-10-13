﻿using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.interfaces
{
    public interface IDAL_Parada
    {
        EParada addParada(string nombre, double lat, double lon);
        List<EParada> getAllParadas();
        EParada getParada(int parada);
    }
}
