using Aparcamiento_Inteligente_2.modelo;
using Aparcamiento_Inteligente_2.servicios;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
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
        private readonly DialogosNavegacion servicioDialogos;
        readonly DBServicio baseDatos;
        public EditarClienteWindowMV()
        {
            //Instancia Servicios
            baseDatos = new DBServicio();
            servicioDialogos = new DialogosNavegacion();
            //Comunicación
            ClienteSeleccionado = WeakReferenceMessenger.Default.Send<ClienteSeleccionadoMessage>();

            




            ImagenCommand = new RelayCommand(AbrirImagen);

        }
        public RelayCommand ImagenCommand { get; }

        private void AbrirImagen()
        {
            Foto = servicioDialogos.DialogoAbrirImagen();

        }
        private string foto;

        public string Foto
        {
            get { return foto; }
            set { SetProperty(ref foto, value); }
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