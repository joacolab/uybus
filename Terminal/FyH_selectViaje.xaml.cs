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
        private EViaje fechaSelected = null;
        private int AsientoSelected = -1;
        private int PrecioSelected = -1;
        public FyH_selectViaje(ELinea _lineaSelected,EParada _paradaOSelected,EParada _paradaDSelected)
        {   

            InitializeComponent();
            lineaSelected = _lineaSelected;
            paradaOSelected = _paradaOSelected;
            paradaDSelected = _paradaDSelected;
            cargarHorasSalidas(lineaSelected);
            btnSig.Visibility = System.Windows.Visibility.Hidden;
            lsA.Visibility = System.Windows.Visibility.Hidden;
            lbA.Visibility = System.Windows.Visibility.Hidden;

            // cargarFechasViaje(null);

            //cargarFechasDeViajes();

        }
        private void cargarHorasSalidas(ELinea lineaSelected)
        {
            Service1Client s = new Service1Client();
            lsHdSalida.ItemsSource = s.GetSalidas(lineaSelected.IdLinea);
        }
 
        private void btnSig_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window docu = new documento(lineaSelected, paradaOSelected, paradaDSelected, SalidaSelected, fechaSelected, AsientoSelected, PrecioSelected);
            docu.ShowDialog();
            this.Show();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
        private void cargarFechasDeViajes(ESalida salidaSelected)
        {

               if (salidaSelected != null)
               {
                  Service1Client s = new Service1Client();
                  lsFs.ItemsSource = s.GetFechasViajes(salidaSelected.IdSalida);
               }

        }
  
        private void lsHdSalida_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (lsHdSalida.SelectedIndex < 0)
            {
                cargarFechasDeViajes(null);
                return;
            }
            //lsD.Items.Clear();
            SalidaSelected = (ESalida)lsHdSalida.SelectedValue;
            cargarFechasDeViajes(SalidaSelected);
            
        }

        private void lsFs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lsFs.SelectedIndex < 0)
            {
                cargarAsientos(null);
                return;
            }


            Service1Client s = new Service1Client();
            PrecioSelected  = s.precioDelPasaje(lineaSelected.IdLinea, paradaOSelected.IdParada, paradaDSelected.IdParada);
            if (s.canSelectSeat(lineaSelected.IdLinea, paradaOSelected.IdParada, paradaDSelected.IdParada))
            {
                fechaSelected = (EViaje)lsFs.SelectedValue;
                cargarAsientos(fechaSelected);
                lsA.Visibility = System.Windows.Visibility.Visible;
                lbA.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                fechaSelected = (EViaje)lsFs.SelectedValue;
                btnSig.Visibility = System.Windows.Visibility.Visible;
            }
        }

        

        private void cargarAsientos(EViaje fechaSelected)
        {

            if (fechaSelected != null)
            {
                Service1Client s = new Service1Client();
                lsA.ItemsSource = s.GetAsientos(fechaSelected.IdViaje);
            }
        }

        private void lsA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AsientoSelected = (int)lsA.SelectedValue;
            btnSig.Visibility = System.Windows.Visibility.Visible;
        }




        /*
private void lsHdSalida_SelectionChanged(object sender, SelectionChangedEventArgs e)
{
   if (lsHdSalida.SelectedIndex < 0)
   {
       cargarFechasViaje(null);
       return;
   }
   //lsD.Items.Clear();
   ViajeSelected = (ESalida)lsHdSalida.SelectedValue;
   cargarFechasViaje(ViajeSelected);
}

private void cargarFechasViaje(ESalida salida)
{
   if (salida != null)
   {
       Service1Client s = new Service1Client();
       lsFs.ItemsSource = s.GetFechasViajes(salida.IdSalida);

   }
}
*/
    }
}
