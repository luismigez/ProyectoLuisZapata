using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoLuisZapata.Modelo
{
    class DatosTurno
    {
        public int ID_TURN { get; set; }
        public int ID_TIPO_TURN { get; set; }
        public int ID_EMPL { get; set; }
        public string FECH { get; set; }
        public DateTime HORA { get; set; }
        public string TURN_ESTA { get; set; }
    }
}
