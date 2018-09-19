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
           
            double tiempoInicial = double.Parse(txtTiempoInicial.Text);
            double tiempoFinal = double.Parse(txtTiempoFinal.Text);
            double frecuenciaMuestreo = double.Parse(txtFrecuenciaMuestreo.Text);

            Señal señal;
            switch (cbTipoSeñal.SelectedIndex)
            {
                //Señal Senoidal
                case 0:
                    /*double amplitud = double.Parse(txtAmplitud.Text);
                    double fase = double.Parse(txtFase.Text);
                    double frecuencia = double.Parse(txtFrecuencia.Text);*/

                    señal = new SeñalSenoidal(5, 0, 8); //constructor

                    break;

                //Rampa
                case 1: señal = new SeñalRampa();
                    break;
                default:
                    señal = null;
                    break;
            }

            señal.TiempoInicial = tiempoInicial;
            señal.TiempoFinal = tiempoFinal;
            señal.FrecuenciaMuestreo = frecuenciaMuestreo;
            
            señal.construirSeñalDigital();

            plnGrafica.Points.Clear();

            if(señal != null)
            {
                //Recorre todos los elementos de una coleccion o arreglo
                foreach (Muestra muestra in señal.Muestras)
                {
                    plnGrafica.Points.Add(new Point((muestra.X - tiempoInicial) * scrContenedor.Width, (muestra.Y /
                        señal.AmplitudMaxima * ((scrContenedor.Height / 2.0) - 30) * -1) + 
                        (scrContenedor.Height / 2)));

                }

                lblAmplitudMaximaY.Text = señal.AmplitudMaxima.ToString();
                lblAmplitudMaximaNegativaY.Text = "-" + señal.AmplitudMaxima.ToString();
            }
           
            plnEjeX.Points.Clear();
            //Punto del principio
            plnEjeX.Points.Add(new Point(0, (scrContenedor.Height / 2)));
            //Punto del final
            plnEjeX.Points.Add(new Point((tiempoFinal - tiempoInicial) * scrContenedor.Width, (scrContenedor.Height / 2)));

            plnEjeY.Points.Clear();
            //Punto del principio
            plnEjeY.Points.Add(new Point((0 - tiempoInicial) * scrContenedor.Width , (señal.AmplitudMaxima * 
                ((scrContenedor.Height / 2.0) - 30) * -1) + (scrContenedor.Height / 2)));
            //Punto del final
            plnEjeY.Points.Add(new Point((0 - tiempoInicial) * scrContenedor.Width, (-señal.AmplitudMaxima * 
                ((scrContenedor.Height / 2.0) - 30) * -1) + (scrContenedor.Height / 2)));
                        
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
                plnGrafica.Points.Add(new Point(muestra.X * scrContenedor.Width, (muestra.Y * 
                    ((scrContenedor.Height / 2.0) - 30) * -1) + (scrContenedor.Height / 2)));

            }
           
        }

        private void cbTipoSeñal_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (panelConfiguracion != null)
            {
                panelConfiguracion.Children.Clear();

                switch (cbTipoSeñal.SelectedIndex)
                {
                    case 0:  //Senoidal
                        panelConfiguracion.Children.Add(new ConfiguracionSeñalSenoidal());
                        break;

                    case 1:

                        break;
                    default:
                        break;
                }

            }
           
        }
    }

}
