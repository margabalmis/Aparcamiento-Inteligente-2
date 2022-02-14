using Aparcamiento_Inteligente_2.modelo;
using Aparcamiento_Inteligente_2.vistas_modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aparcamiento_Inteligente_2.vistas
{
    /// <summary>
    /// Lógica de interacción para VehiculoUserControl.xaml
    /// </summary>
    public partial class VehiculoUserControl : UserControl
    {
        private readonly VehiculoUserControlMV vm;

        public VehiculoUserControl()
        {
            InitializeComponent();
            vm = new VehiculoUserControlMV();
            this.DataContext = vm;
        }

       
    }

}
