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
        public documento()
        {
            InitializeComponent();
        }

        private void btnV_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

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
