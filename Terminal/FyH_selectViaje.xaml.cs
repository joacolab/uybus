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
    /// Lógica de interacción para FyH_selectViaje.xaml
    /// </summary>
    public partial class FyH_selectViaje : Window
    {
        public FyH_selectViaje()
        {
            InitializeComponent();
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
    }
}
