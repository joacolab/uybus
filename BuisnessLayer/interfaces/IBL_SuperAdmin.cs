﻿using Share.entities;
using Share.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.interfaces
{
    public interface IBL_SuperAdmin
    {
        void ubicarVehiculo();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id del usuario</param>
        EPersona asignarRol(int id, Rol rol);
    }
}
