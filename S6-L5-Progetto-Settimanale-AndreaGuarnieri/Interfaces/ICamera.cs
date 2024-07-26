﻿using S6_L5_Progetto_Settimanale_AndreaGuarnieri.Models;
using System.Collections.Generic;

namespace S6_L5_Progetto_Settimanale_AndreaGuarnieri.Models.Interfaces
{
    public interface ICamera
    {
        IEnumerable<Camera> GetCamereDisponibili();
        Camera GetCamera(int id);
        // Add other methods if needed...
    }
}
