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
    class EliminarVehiculoWindowMV : ObservableRecipient
    {
        //Servicios
        readonly DBServicio baseDatos;
        public EliminarVehiculoWindowMV()
        {

            //Cargar datos clientes
            baseDatos = new DBServicio();

            //Comunicacion
             VehiculoSeleccionado = WeakReferenceMessenger.Default.Send<VehiculoSeleccionadoMessage>();

            marca = baseDatos.MarcasFindMarca(VehiculoSeleccionado.Id_marca);

        }
        private Vehiculo vehiculoSeleccionado;

        public Vehiculo VehiculoSeleccionado
        {
            get { return vehiculoSeleccionado; }
            set { SetProperty(ref vehiculoSeleccionado, value); }
        }

        private string marca;

        public string Maraca
        {
            get { return marca; }
            set { SetProperty(ref marca, value); }
        }

    }
}
