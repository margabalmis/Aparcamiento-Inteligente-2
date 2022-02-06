using Aparcamiento_Inteligente_2.vistas;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Aparcamiento_Inteligente_2.servicios
{
    class DialogosNavegacion
    {
        internal bool? DialogoAñadirCliente()
        {
            AñadirClienteWindow nuevaVentana = new AñadirClienteWindow();
            nuevaVentana.ShowDialog();
            return nuevaVentana.DialogResult;
        }
        internal bool? DialogoEditarCliente()
        {
            EditarClienteWindow nuevaVentana = new EditarClienteWindow();
            nuevaVentana.ShowDialog();
            return nuevaVentana.DialogResult;
        }
        internal bool? DialogoEliminarCliente()
        {
            EliminarClienteWindow nuevaVentana = new EliminarClienteWindow();
            nuevaVentana.ShowDialog();
            return nuevaVentana.DialogResult;
        }
        internal bool? DialogoAñadirVehiculo()
        {
            AñadirVehiculoWindow nuevaVentana = new AñadirVehiculoWindow();
            nuevaVentana.ShowDialog();
            return nuevaVentana.DialogResult;
        }
        internal bool? DialogoAñadirMarca()
        {
            AñadirMarcaW nuevaVentana = new AñadirMarcaW();
            nuevaVentana.ShowDialog();
            return nuevaVentana.DialogResult;
        }
        internal bool? DialogoEditarVehiculo()
        {
            EditarVehiculoWindow nuevaVentana = new EditarVehiculoWindow();
            nuevaVentana.ShowDialog();
            return nuevaVentana.DialogResult;
        }
        internal bool? DialogoEliminarVehiculo()
        {
            EliminarVehiculoWindow nuevaVentana = new EliminarVehiculoWindow();
            nuevaVentana.ShowDialog();
            return nuevaVentana.DialogResult;
        }
        internal void MessageBoxFinalizarEstacionamiento()
        {
            MessageBox.Show("¿Quieres eliminar el estacionamiento?", 
                "Finalizar estacionamiento", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
        }
        internal string DialogoAbrirImagen()
        {
            string foto = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                foto = openFileDialog.FileName;
            }
            return foto;

        }

    }
}


