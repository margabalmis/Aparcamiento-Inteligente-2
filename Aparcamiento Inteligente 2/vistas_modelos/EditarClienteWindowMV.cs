﻿using Aparcamiento_Inteligente_2.modelo;
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
    class EditarClienteWindowMV : ObservableRecipient
    {
        //Servicios
        readonly DBServicio baseDatos;
        public EditarClienteWindowMV()
        {
            baseDatos = new DBServicio();
            //Comunicación
            ClienteSeleccionado = WeakReferenceMessenger.Default.Send<ClienteSeleccionadoMessage>();
          
        }

        internal void EditarCliente()
        {
            baseDatos.ClienteUpateOne(ClienteSeleccionado);
        }

        private Cliente clienteSeleccionado;

        public Cliente ClienteSeleccionado
        {
            get { return clienteSeleccionado; }
            set { SetProperty(ref clienteSeleccionado, value); }
        }



    }
}