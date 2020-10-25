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
using System.Windows.Shapes;
using Terminal.joaquin24;

namespace Terminal
{
    /// <summary>
    /// Lógica de interacción para FyH_selectViaje.xaml
    /// </summary>
    public partial class FyH_selectViaje : Window
    {
        private ELinea lineaSelected = null;
        private EParada paradaOSelected = null;
        private EParada paradaDSelected = null;
        private ESalida SalidaSelected = null;
        public FyH_selectViaje(ELinea _lineaSelected,EParada _paradaOSelected,EParada _paradaDSelected)
        {   

            InitializeComponent();
            lineaSelected = _lineaSelected;
            paradaOSelected = _paradaOSelected;
            paradaDSelected = _paradaDSelected;
            cargarHorasSalidas(null);
            cargarFechasDeViajes(null);

        }
        private void cargarHorasSalidas(ELinea lineaSelected)
        {
            Service1Client s = new Service1Client();
            lsHdSalida.ItemsSource = s.GetSalidas(lineaSelected.IdLinea);
     
        }
        




        private void btnSig_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new documento().ShowDialog();
            this.Show();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lsHdSalida_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
            if (lsHdSalida.SelectedIndex < 0)
            {
                cargarFechasDeViajes(null);
                return;
            }
            //lsD.Items.Clear();
            SalidaSelected = (ESalida)lsHdSalida.SelectedValue;
            cargarFechasDeViajes(SalidaSelected);
            */
        }

        private void cargarFechasDeViajes(ESalida salidaSelected)
        {
            /*
            if (salidaSelected != null)
            {
                Service1Client s = new Service1Client();
                lsFs.ItemsSource = s.GetViajes(salidaSelected.IdSalida);
            }
            */
        }

       
    }
}
