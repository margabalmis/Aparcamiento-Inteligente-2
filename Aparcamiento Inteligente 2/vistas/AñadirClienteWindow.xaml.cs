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
    /// Lógica de interacción para AñadirClienteWindow.xaml
    /// </summary>
    public partial class AñadirClienteWindow : Window
    {
        readonly AñadirClienteWindowMV vm;
        public AñadirClienteWindow()
        {
            InitializeComponent();
            vm = new AñadirClienteWindowMV();
            this.DataContext = vm;
        }
    }
}