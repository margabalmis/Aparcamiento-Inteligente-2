using Aparcamiento_Inteligente_2.modelo;
using Aparcamiento_Inteligente_2.servicios;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aparcamiento_Inteligente_2.vistas_modelos
{
    class EliminarClienteWindowMV : ObservableRecipient
    {

        public EliminarClienteWindowMV() 
        {

            ClienteSeleccionado = WeakReferenceMessenger.Default.Send<ClienteSeleccionadoMessage>();
            if (new DBServicio(Properties.Settings.Default.Conexion).ClienteHasVehiculos(ClienteSeleccionado))
            {
                new DialogosNavegacion().Alert("El cliente seleccionado tiene vehiculos asociados, si elimina el cliente se eliminaran los vehiculos asociados");
            }

        }

        private Cliente clienteSeleccionado;

        public Cliente ClienteSeleccionado
        {
            get { return clienteSeleccionado; }
            set { SetProperty(ref clienteSeleccionado, value); }
        }

        public void DeleteCliente()
        {
            DBServicio db = new DBServicio(Properties.Settings.Default.Conexion);

            if (db.ClienteHasVehiculos(ClienteSeleccionado))
            {
                foreach(Vehiculo item in db.VehiculosFindByCliente(clienteSeleccionado)){
                    db.VehiculoDeleteOne(item);
                }

                db.ClienteDeleteOne(clienteSeleccionado);
            }
            else
            {
                db.ClienteDeleteOne(ClienteSeleccionado);
            }
        }



    }


}
