using Aparcamiento_Inteligente_2.vistas_modelos;
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

namespace Aparcamiento_Inteligente_2.vistas
{
    /// <summary>
    /// Lógica de interacción para EliminarVehiculoWindow.xaml
    /// </summary>
    public partial class EliminarVehiculoWindow : Window
    {
        readonly EliminarVehiculoWindowMV vm;
        public EliminarVehiculoWindow(string origen)
        {
            InitializeComponent();
            vm = new EliminarVehiculoWindowMV(origen);
            DataContext = vm;
        }

        private void AceptarButton_Click(object sender, RoutedEventArgs e)
        {
            vm.EliminarVehiculo();
            DialogResult = true;
        }
    }
}