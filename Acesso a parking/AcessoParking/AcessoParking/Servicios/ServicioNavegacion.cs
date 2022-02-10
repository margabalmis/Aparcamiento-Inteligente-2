using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AcessoParking.Servicios
{
    class ServicioNavegacion
    {
        public string AbrirImagenDialog()
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "Image files (*.png;*.jpeg, *.jpg)|*.png;*.jpeg; *.jpg|All files (*.*)|*.*",
                FilterIndex = 0
            };
            string filename = "";

            if (dlg.ShowDialog() == true)
            {
                filename = dlg.FileName;
            }
            return filename;
        }

        public void Alert(string mensaje)
        {
            _ = MessageBox.Show(mensaje, "Alerta", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
    }
}
