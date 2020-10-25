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


            //btnSig.IsEnabled = false;
        }

        private void btnV_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       // private void recibirDocumento()


        private void btnComprar_Click(object sender, RoutedEventArgs e)
        {
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
    }
}
