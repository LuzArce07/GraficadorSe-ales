using System;
using System.Windows;

namespace GraficadorSeñales
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGraficar_Click(object sender, RoutedEventArgs e)
        {
            double amplitud = double.Parse(txtAmplitud.Text);
            double fase = double.Parse(txtFase.Text);
            double frecuencia = double.Parse(txtFrecuencia.Text);
            double tiempoInicial = double.Parse(txtTiempoInicial.Text);
            double tiempoFinal = double.Parse(txtTiempoFinal.Text);
            double frecuenciaMuestreo = double.Parse(txtFrecuenciaMuestreo.Text);
            
            SeñalSenoidal señal = new SeñalSenoidal(amplitud, fase, frecuencia); //constructor

            double periodoMuestreo = 1 / frecuenciaMuestreo;

            plnGrafica.Points.Clear();

            for(double i = tiempoInicial; i <= tiempoFinal; i += periodoMuestreo)
            {
                double valorMuestra = señal.evaluar(i);

                señal.Muestras.Add(new Muestra(i, valorMuestra));

                if (Math.Abs(valorMuestra) > señal.AmplitudMaxima)
                {
                    señal.AmplitudMaxima = Math.Abs(valorMuestra);

                }
                
            }
            //Recorre todos los elementos de una coleccion o arreglo
            foreach (Muestra muestra in señal.Muestras)
            {
                plnGrafica.Points.Add(new Point(muestra.X * scrContenedor.Width, (muestra.Y / señal.AmplitudMaxima * ((scrContenedor.Height / 2.0) - 30) * -1) + (scrContenedor.Height / 2)));

            }

            lblAmplitudMaximaY.Text = señal.AmplitudMaxima.ToString();
            lblAmplitudMaximaNegativaY.Text = "-" + señal.AmplitudMaxima.ToString();
            
        }

        private void btnGraficarRampa_Click(object sender, RoutedEventArgs e)
        {
            double tiempoInicial = double.Parse(txtTiempoInicial.Text);
            double tiempoFinal = double.Parse(txtTiempoFinal.Text);

            SeñalRampa rampa = new SeñalRampa(tiempoInicial, tiempoFinal);

            plnGrafica.Points.Clear();

            for (double i = tiempoInicial; i <= tiempoFinal; i++)
            {
                double valorMuestra = rampa.evaluar(i);
                rampa.Muestras.Add(new Muestra(i, valorMuestra));
                

            }

            foreach (Muestra muestra in rampa.Muestras)
            {
                plnGrafica.Points.Add(new Point(muestra.X * scrContenedor.Width, (muestra.Y * ((scrContenedor.Height / 2.0) - 30) * -1) + (scrContenedor.Height / 2)));

            }
           
        }
        
    }

}
