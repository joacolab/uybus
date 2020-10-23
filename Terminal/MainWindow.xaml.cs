using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Terminal.ServiceReference2;

namespace Terminal
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ELinea lineaSelected = null;
        private EParada paradaOSelected = null;
        private EParada paradaDSelected = null;
        public MainWindow()
        {
            InitializeComponent();
            cargarListaDeLineas();
            cargarListaDeParadasO(null);
            cargarListaDeParadasD(null, null);
            btnS.IsEnabled = false;
        }
        private void cargarListaDeLineas()
        {
            Service1Client s = new Service1Client();
            lsL.ItemsSource = s.GetLineas();
            /*
            ELinea e = new ELinea();
            e.IdLinea = 1;
            e.Nombre = "Montv a sanjose";

            List<ELinea> l = new List<ELinea>();
            l.Add(e);
            l.Add(e);
            l.Add(e);
            l.Add(e);*/
            //lsL.ItemsSource = l;
        }

        private void cargarListaDeParadasO(ELinea linea)
        {
            if (linea != null)
            {
                //Service1Client s = new Service1Client();
                //lsO.ItemsSource = s.GetData(linea);

                EParada p = new EParada();
                p.IdParada = 1;
                p.Nombre = "PuntaValdez";

                List<EParada> ps = new List<EParada>();
                ps.Add(p);
                ps.Add(p);
                ps.Add(p);
                ps.Add(p);
                lsO.ItemsSource = ps;
            }
        }

        private void cargarListaDeParadasD(ELinea linea, EParada parada)
        {
            if (linea != null)
            {
                //Service1Client s = new Service1Client();
                //lsO.ItemsSource = s.GetData(linea);

                EParada p = new EParada();
                p.IdParada = 1;
                p.Nombre = "PuntaValdez";

                List<EParada> ps = new List<EParada>();
               
                ps.Add(p);
                ps.Add(p);
                ps.Add(p);
                lsD.ItemsSource = ps;
            }
        }


        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnS_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new FyH_selectViaje().ShowDialog();
            this.Show();
        }

        private void lsL_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lsL.SelectedIndex < 0)
            {
                cargarListaDeParadasO(null);
                return;
            }
            lineaSelected = (ELinea)lsL.SelectedValue;
            cargarListaDeParadasO(lineaSelected);
        }

        private void lsO_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lsO.SelectedIndex < 0)
            {
                cargarListaDeParadasD(null, null);
                return;
            }
            paradaOSelected = (EParada)lsO.SelectedValue;
            cargarListaDeParadasD(lineaSelected, paradaOSelected);
        }

        private void lsD_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            paradaDSelected = (EParada)lsD.SelectedValue;
            btnS.IsEnabled = true;
        }


        /*
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                Service1Client s = new Service1Client();
                lb1.Content = s.GetData(Convert.ToInt32(tb1.Text));
            }
            catch (Exception)
            {
                lb1.Content = "Salto una excepción...";
            }
            
        }
        */
    }
}
