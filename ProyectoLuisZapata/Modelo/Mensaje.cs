using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoLuisZapata.Modelo
{
    public interface Mensaje
    {
        void LongAlert(string mensaje);
        void ShortAlert(string mensaje);
    }
}
