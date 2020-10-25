﻿using Share.entities;
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
        public FyH_selectViaje(ELinea _lineaSelected,EParada _paradaOSelected,EParada _paradaDSelected)
        {   

            InitializeComponent();
            lineaSelected = _lineaSelected;
            paradaOSelected = _paradaOSelected;
            paradaDSelected = _paradaDSelected;

            SalidaSelected = null;
            fechaSelected = null;

            cargarHorasSalidas(lineaSelected);
            
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
            new documento().ShowDialog();
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
            fechaSelected = (EViaje)lsFs.SelectedValue;
            cargarAsientos(fechaSelected);
        }

        private void cargarAsientos(EViaje fechaSelected)
        {

            if (fechaSelected != null)
            {
                Service1Client s = new Service1Client();
                lsA.ItemsSource = s.GetAsientos(fechaSelected.IdViaje);
            }
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
