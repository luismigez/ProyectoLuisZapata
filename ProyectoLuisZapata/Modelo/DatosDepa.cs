using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace ProyectoLuisZapata.Modelo
{
    class DatosDepa
    {
        public int ID_TURN { get; set; }
        public int ID_TIPO_TURN { get; set; }
        public int ID_EMPL { get; set; }
        public string FECH { get; set; }
        public string HORA { get; set; }
    }
}
