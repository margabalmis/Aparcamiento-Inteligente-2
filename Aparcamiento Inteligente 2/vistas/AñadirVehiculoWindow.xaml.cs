using Aparcamiento_Inteligente_2.modelo;
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
    /// Lógica de interacción para AñadirVehiculoWindow.xaml
    /// </summary>
    public partial class AñadirVehiculoWindow : Window
    {
        AñadirVehiculoMV vm;

        public AñadirVehiculoWindow(Cliente prop)
        {
            InitializeComponent();
            vm = new AñadirVehiculoMV(prop);
            this.DataContext = vm;
        }
        private void AceptarButton_Click(object sender, RoutedEventArgs e)
        {
            vm.AñadirVehiculo();
            DialogResult = true;
        }
    }
}