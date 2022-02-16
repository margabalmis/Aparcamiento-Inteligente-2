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
    /// <summary>
    /// Servicio de navegación
    /// </summary>
    class DialogosNavegacion
    {
        /// <summary>
        /// Instancia y lanza el dialogo para añadir cliente
        /// </summary>
        /// <returns>Devuelve el resultado del dialogo (bool)</returns>
        internal bool? DialogoAñadirCliente()
        {
            AñadirClienteWindow nuevaVentana = new AñadirClienteWindow();
            nuevaVentana.ShowDialog();
            return nuevaVentana.DialogResult;
        }
        /// <summary>
        /// Instancia y lanza el dialogo para editar un cliente
        /// </summary>
        /// <returns>Devuelve el resultado del dialogo (bool)</returns>
        internal bool? DialogoEditarCliente()
        {
            EditarClienteWindow nuevaVentana = new EditarClienteWindow();
            nuevaVentana.ShowDialog();
            return nuevaVentana.DialogResult;
        }
        /// <summary>
        /// Instancia y lanza el dialogo para eliminar un  cliente
        /// </summary>
        /// <returns>Devuelve el resultado del dialogo (bool)</returns>
        internal bool? DialogoEliminarCliente()
        {
            EliminarClienteWindow nuevaVentana = new EliminarClienteWindow();
            nuevaVentana.ShowDialog();
            return nuevaVentana.DialogResult;
        }

        /// <summary>
        /// Instancia y lanza el dialogo para añadir un nuevo Cliente
        /// </summary>
        /// <returns>Devuelve el resultado del dialogo (bool)</returns>
        internal bool? DialogoAñadirVehiculo()
        {
            AñadirVehiculoWindow nuevaVentana = new AñadirVehiculoWindow();
            nuevaVentana.ShowDialog();
            return nuevaVentana.DialogResult;
        }

        /// <summary>
        /// Instancia y lanza el dialogo para añadir una nueva Marca
        /// </summary>
        /// <returns>Devuelve el resultado del dialogo (bool)</returns>
        internal bool? DialogoAñadirMarca()
        {
            AñadirMarcaW nuevaVentana = new AñadirMarcaW();
            nuevaVentana.ShowDialog();
            return nuevaVentana.DialogResult;
        }

        /// <summary>
        /// Instancia y lanza el dialogo para editar un vehículo desde la pestaña de clientes
        /// </summary>
        /// <returns>Devuelve el resultado del dialogo (bool)</returns>
        internal bool? DialogoEditarVehiculoDesdeCliente()
        {
            string origen = "cliente";
            EditarVehiculoWindow nuevaVentana = new EditarVehiculoWindow(origen);
            nuevaVentana.ShowDialog();
            return nuevaVentana.DialogResult;
        }

        /// <summary>
        /// Instancia y lanza el dialogo para editar un vehículo desde la pestaña de vehículo
        /// </summary>
        /// <returns>Devuelve el resultado del dialogo (bool?)</returns>
        internal bool? DialogoEditarVehiculoDesdeVehiculo()
        {
            string origen = "vehiculo";
            EditarVehiculoWindow nuevaVentana = new EditarVehiculoWindow(origen);
            nuevaVentana.ShowDialog();
            return nuevaVentana.DialogResult;
        }

        /// <summary>
        /// Instancia y lanza el dialogo para eliminar un vehiculo desde la pestaña de cliente
        /// </summary>
        /// <returns>Devuelve el resultado del dialogo (bool?)</returns>
        internal bool? DialogoEliminarVehiculoDesdeCliente()
        {
            string origen = "cliente";
            EliminarVehiculoWindow nuevaVentana = new EliminarVehiculoWindow(origen);
            nuevaVentana.ShowDialog();
            return nuevaVentana.DialogResult;
        }

        /// <summary>
        /// Instancia y lanza el dialogo para  eliminar un vehiculo desde la pestaña de cliente
        /// </summary>
        /// <returns>Devuelve el resultado del dialogo (bool?)</returns>
        internal bool? DialogoEliminarVehiculoDesdeVehiculo()
        {
            string origen = "vehiculo";
            EliminarVehiculoWindow nuevaVentana = new EliminarVehiculoWindow(origen);
            nuevaVentana.ShowDialog();
            return nuevaVentana.DialogResult;
        }

        /// <summary>
        /// Instancia y lanza el dialogo para finalizar un estacionamiento
        /// </summary>
        /// <returns>Devuelve el resultado del dialogo (bool?)</returns>
        internal bool? MessageBoxFinalizarEstacionamiento()
        {
            return MessageBoxResult.Yes == MessageBox.Show("¿Quieres finalizar el estacionamiento?", 
                "Finalizar estacionamiento", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            return result;
        }
        /// <summary>
        /// Instancia y lanza el dialogo para abrir una imagen
        /// </summary>
        /// <returns>Devuelve la ruta de la imagen en string4</returns>
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

        /// <summary>
        /// Crea y muestra un MessageBox de Alerta con el mensaje que le pase al metodo
        /// </summary>
        /// <param name="mensaje">string mensaje a mostrar</param>
        public void Alert(string mensaje)
        {
            _ = MessageBox.Show(mensaje, "Alerta", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

    }
}


