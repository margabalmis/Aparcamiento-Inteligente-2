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
        internal bool? DialogoEditarVehiculoDesdeCliente()
        {
            string origen = "cliente";
            EditarVehiculoWindow nuevaVentana = new EditarVehiculoWindow(origen);
            nuevaVentana.ShowDialog();
            return nuevaVentana.DialogResult;
        }
        internal bool? DialogoEditarVehiculoDesdeVehiculo()
        {
            string origen = "vehiculo";
            EditarVehiculoWindow nuevaVentana = new EditarVehiculoWindow(origen);
            nuevaVentana.ShowDialog();
            return nuevaVentana.DialogResult;
        }
        internal bool? DialogoEliminarVehiculoDesdeCliente()
        {
            string origen = "cliente";
            EliminarVehiculoWindow nuevaVentana = new EliminarVehiculoWindow(origen);
            nuevaVentana.ShowDialog();
            return nuevaVentana.DialogResult;
        }
        internal bool? DialogoEliminarVehiculoDesdeVehiculo()
        {
            string origen = "vehiculo";
            EliminarVehiculoWindow nuevaVentana = new EliminarVehiculoWindow(origen);
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
        public void Alert(string mensaje)
        {
            _ = MessageBox.Show(mensaje, "Alerta", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

    }
}


