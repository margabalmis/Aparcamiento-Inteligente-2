using Aparcamiento_Inteligente_2.vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aparcamiento_Inteligente_2.servicios
{
    class DialogosNavegacion
    {
        internal void DialogoAñadirCliente()
        {
            AñadirClienteWindow nuevaVentana = new AñadirClienteWindow();
            nuevaVentana.Show();
        }
        internal void DialogoEditarCliente()
        {
            EditarClienteWindow nuevaVentana = new EditarClienteWindow();
            nuevaVentana.Show();
        }
        internal void DialogoEliminarCliente()
        {
            EliminarClienteWindow nuevaVentana = new EliminarClienteWindow();
            nuevaVentana.ShowDialog();
        }


    }
}


