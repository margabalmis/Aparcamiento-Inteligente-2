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
            nuevaVentana.ShowDialog();
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
        internal void DialogoAñadirVehiculo()
        {
            AñadirVehiculoWindow nuevaVentana = new AñadirVehiculoWindow();
            nuevaVentana.ShowDialog();
        }
        internal void DialogoEditarVehiculo()
        {
            EditarVehiculoWindow nuevaVentana = new EditarVehiculoWindow();
            nuevaVentana.Show();
        }
        internal void DialogoEliminarVehiculo()
        {
            EliminarVehiculoWindow nuevaVentana = new EliminarVehiculoWindow();
            nuevaVentana.ShowDialog();
        }

    }
}


