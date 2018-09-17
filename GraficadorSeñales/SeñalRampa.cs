using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficadorSeñales
{
    class SeñalRampa : Señal
    {
        public double TiempoInicial { get; set; }
        public double TiempoFinal { get; set; }
        

        public SeñalRampa()
        {
            TiempoInicial = 0.0;
            TiempoFinal = 1.0;
            Muestras = new List<Muestra>();
            AmplitudMaxima = 0.0;
        }

        public SeñalRampa(double tiempoInicial, double tiempoFinal)
        {
            TiempoInicial = tiempoInicial;
            TiempoFinal = tiempoFinal;
            Muestras = new List<Muestra>();
            AmplitudMaxima = 0.0;
        }

        override public double evaluar(double tiempo)
        {
            double resultado;
            if (tiempo >= 0)
            {
                resultado = tiempo;
            }
            else
            {
                resultado = 0;
            }

            return resultado;
        }
    }
}

