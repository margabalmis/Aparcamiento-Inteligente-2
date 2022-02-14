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
    /// Lógica de interacción para EditarVehiculoWindow.xaml
    /// </summary>
    public partial class EditarVehiculoWindow : Window
    {
        EditarVehiculoMV vm;
        public EditarVehiculoWindow(String origen)
        {
            InitializeComponent();
            vm = new EditarVehiculoMV(origen);
            this.DataContext = vm;
        }
        private void AceptarButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
