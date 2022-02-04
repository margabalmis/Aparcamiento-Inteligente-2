﻿using Aparcamiento_Inteligente_2.modelo;
using Aparcamiento_Inteligente_2.servicios;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aparcamiento_Inteligente_2.vistas_modelos
{
    class AñadirVehiculoMV : ObservableRecipient
    {
        DBServicio baseDatos;
        public AñadirVehiculoMV()
        {
            VehiculoSeleccionado = WeakReferenceMessenger.Default.Send<VehiculoSeleccionadoMessage>();

            // Cargar datos Marcas
            baseDatos = new DBServicio();
            Marcas = new ObservableCollection<Marcas>();
            //Marcas = baseDatos.MarcasGetAll();
        }

        private Vehiculo vehiculoSeleccionado;

        public Vehiculo VehiculoSeleccionado
        {
            get { return vehiculoSeleccionado; }
            set { SetProperty(ref vehiculoSeleccionado, value); }
        }

        private Cliente propietario;

        public Cliente Propietario
        {
            get { return propietario; }
            set { SetProperty(ref propietario, value); }
        }


        private Marcas marcaSeleccionada;

        public Marcas MarcaSeleccionada
        {
            get { return marcaSeleccionada; }
            set { SetProperty(ref marcaSeleccionada, value); }
        }

        private ObservableCollection<Marcas> marcas;

        public ObservableCollection<Marcas> Marcas
        {
            get { return marcas; }
            set { SetProperty(ref marcas, value); }
        }



    }
}