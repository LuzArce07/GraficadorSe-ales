using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficadorSeñales
{
    class SeñalRampa
    {
        public double TiempoInicial { get; set; }
        public double TiempoFinal { get; set; }

        public List<Muestra> Muestras { get; set; }

        public SeñalRampa()
        {
            TiempoInicial = 0.0;
            TiempoFinal = 1.0;
            Muestras = new List<Muestra>();
        }

        public SeñalRampa(double tiempoInicial, double tiempoFinal)
        {
            TiempoInicial = tiempoInicial;
            TiempoFinal = tiempoFinal;
            Muestras = new List<Muestra>();
        }

        public double evaluar(double tiempoInicial)
        {
            double resultado;
            if (tiempoInicial >= 0)
            {
                resultado = tiempoInicial;
            }
            else
            {
                resultado = 0;
            }

            return resultado;
        }
    }
}

