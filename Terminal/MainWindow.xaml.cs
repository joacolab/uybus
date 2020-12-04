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
using Terminal.joaquin24;

namespace Terminal
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
//http://localhost:58746/Service1.svc?wsdl
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
            btnS.Visibility = System.Windows.Visibility.Hidden;
           
        }
        private void cargarListaDeLineas()
        {
            Service1Client s = new Service1Client();
            lsL.ItemsSource = s.GetLineas();
        }

        private void cargarListaDeParadasO(ELinea linea)
        {
            if (linea != null)
            {
                Service1Client s = new Service1Client();
                lsO.ItemsSource = s.GetParadas(linea.IdLinea);
            }
        }

        private void cargarListaDeParadasD(ELinea linea, EParada parada)
        {
            if (linea != null)
            {
                Service1Client s = new Service1Client();
                lsD.ItemsSource = s.GetParadasD(linea.IdLinea,parada.IdParada);

            }
        }


        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnS_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window FyH = new FyH_selectViaje(lineaSelected, paradaOSelected, paradaDSelected);
            FyH.ShowDialog();
            this.Show();
        }

        private void lsL_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (lsL.SelectedIndex < 0)
            {
                cargarListaDeParadasO(null);
                return;
            }
            //lsD.Items.Clear();
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
            btnS.Visibility = System.Windows.Visibility.Visible;
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
