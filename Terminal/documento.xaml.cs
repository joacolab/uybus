using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            btnComprar.Visibility = System.Windows.Visibility.Hidden;
            tbDoc.Visibility = System.Windows.Visibility.Hidden;
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
            Documento = tbDoc.Text;
            if (TipoDocumento == 1)
            {
               
                if (validar(1))
                {

                    try
                    {
                    s.comprarPasaje(fechaSelected.IdViaje, -1, paradaOSelected.IdParada, paradaDSelected.IdParada, TipoDocumento, Documento, AsientoSelected);

                    }
                    catch (Exception ex)
                    {

                        throw;
                    }


                    MessageBox.Show(
                            "Muchas gracias por usar nuestro sistema",
                            "Pasaje comprado",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information
                        );
                    Environment.Exit(0);
                   // this.Hide();
                    //new MainWindow().ShowDialog();
                    //this.Show();
                }
                else
                {
                    MessageBox.Show(
                      "Ingrese Cédula correctamente \n Ejemplo: 12345678",
                      "Error",
                      MessageBoxButton.OK,
                      MessageBoxImage.Error
                  );
                }
            }
            else
            {
                if (validar(2))
                {

                    s.comprarPasaje(fechaSelected.IdViaje, -1, paradaOSelected.IdParada, paradaDSelected.IdParada, TipoDocumento, Documento, AsientoSelected);


                    MessageBox.Show(
                            "Muchas gracias por usar nuestro sistema",
                            "Pasaje comprado",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information
                        );
                    Environment.Exit(0);
                    //this.Hide();
                    //new MainWindow().ShowDialog();
                    //this.Show();
                }
                else
                {
                    MessageBox.Show(
                      "Ingrese Credencial correctamente \n Ejemplo: ABC1234",
                      "Error",
                      MessageBoxButton.OK,
                      MessageBoxImage.Error
                  );
                }
            }

        }

        private void rbtnCI_Click(object sender, RoutedEventArgs e)
        {

            tbDoc.Visibility = System.Windows.Visibility.Visible;
            if (rbtnCI.IsChecked == true)
            {
                TipoDocumento = 1;
            }
            else
            {
                TipoDocumento = 2;
            }
            
        }

        private bool validar(int TipoDoc)
        {

            if (TipoDoc == 1)
            {

                var regex = new Regex(@"^[0-9]{8}$");
                if (!regex.IsMatch(tbDoc.Text))
                {
                    return false;
                }
                return true;
            }
            else
            {
                var regex = new Regex(@"^[A-Z]{3}[0-9]{4}$");
                if (!regex.IsMatch(tbDoc.Text))
                {
                    return false;
                }
                return true;
            }

        }


        private void tbDoc_TextChanged(object sender, TextChangedEventArgs e)
        {
   
            btnComprar.Visibility = System.Windows.Visibility.Visible;
        }

        private void rbtnC_Click(object sender, RoutedEventArgs e)
        {
            

            tbDoc.Visibility = System.Windows.Visibility.Visible;
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
