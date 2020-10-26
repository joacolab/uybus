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
    /// Lógica de interacción para documento.xaml
    /// </summary>
    public partial class documento : Window
    {
        private ELinea lineaSelected = null;
        private EParada paradaOSelected = null;
        private EParada paradaDSelected = null;
        private ESalida SalidaSelected = null;
        private EViaje fechaSelected = null;
        private int AsientoSelected = -1;
        private int PrecioSelected = -1;
        private string Documento = "";
        private int TipoDocumento = -1;

        public documento(ELinea _lineaSelected, EParada _paradaOSelected, EParada _paradaDSelected,ESalida _SalidaSelected,EViaje _fechaSelected, int _AsientoSelected, int _PrecioSelected)
        {
            InitializeComponent();
            lineaSelected = _lineaSelected;
            paradaOSelected = _paradaOSelected;
            paradaDSelected = _paradaDSelected;
            SalidaSelected = _SalidaSelected;
            fechaSelected = _fechaSelected;
            AsientoSelected = _AsientoSelected;
            PrecioSelected = _PrecioSelected;

            btnComprar.IsEnabled = false;
            tbDoc.IsEnabled = false;
            lbV.Content = "$ " + PrecioSelected.ToString();

            //btnSig.IsEnabled = false;
        }

        private void btnV_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       // private void recibirDocumento()


        private void btnComprar_Click(object sender, RoutedEventArgs e)
        {
            Service1Client s = new Service1Client();
            s.comprarPasaje(fechaSelected.IdViaje, -1, paradaOSelected.IdParada, paradaDSelected.IdParada, TipoDocumento, Documento, AsientoSelected);

            MessageBox.Show(
                    "Muchas gracias por usar nuestro sistema",
                    "Pasaje comprado",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );

            this.Hide();
            new MainWindow().ShowDialog();
            this.Show();
        }

        private void rbtnCI_Click(object sender, RoutedEventArgs e)
        {

            tbDoc.IsEnabled = true;
            if (rbtnCI.IsChecked == true)
            {
                TipoDocumento = 1;
            }
            else
            {
                TipoDocumento = 2;
            }
            
        }

        private void tbDoc_TextChanged(object sender, TextChangedEventArgs e)
        {
            Documento = tbDoc.Text;
            btnComprar.IsEnabled = true;
        }

        private void rbtnC_Click(object sender, RoutedEventArgs e)
        {
            

            tbDoc.IsEnabled = true;
            if (rbtnC.IsChecked == true)
            {
                TipoDocumento = 2;
            }
            else
            {
                TipoDocumento = 1;
            }
        }
    }
}
