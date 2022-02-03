using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoParking.Servicios
{
    class ServicioNavegacion
    {
        public string AbrirImagenDialog()
        {
            string result = "";

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                result = openFileDialog.FileName;
            }

            return result;
        }
    }
}
