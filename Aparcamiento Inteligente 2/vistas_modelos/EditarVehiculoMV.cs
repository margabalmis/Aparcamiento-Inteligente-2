using Aparcamiento_Inteligente_2.modelo;
using Aparcamiento_Inteligente_2.servicios;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aparcamiento_Inteligente_2.vistas_modelos
{
    class EditarVehiculoMV : ObservableRecipient
    {
        DBServicio baseDatos;
        DialogosNavegacion navegacion;
        public EditarVehiculoMV() 
        {
            // Cargar datos Marcas
            baseDatos = new DBServicio();
            Marcas = new ObservableCollection<Marcas>();
            Marcas = baseDatos.MarcasGetAll();

            navegacion = new DialogosNavegacion();

            AñadirMarcaDialogo = new RelayCommand(DialogoAñadirMarca);

            //Pasar al Combobox
            MarcasNombre = new ObservableCollection<string>();
            llenarListaNombreMarcas(Marcas);

            //Comunicacion
             VehiculoSeleccionado = WeakReferenceMessenger.Default.Send<VehiculoSeleccionadoMessage>();

            //Cliente Propietario
            if (VehiculoSeleccionado != null)
            {
                Propietario = baseDatos.VehiculoFindCliente(VehiculoSeleccionado);
            }
            WeakReferenceMessenger.Default.Register<VehiculoSeleccionadoMessageDifuson>
                (this, (r, m) => 
                {
                    VehiculoSeleccionado = m.Value;

                });

        }

        private void DialogoAñadirMarca()
        {
            navegacion.DialogoAñadirMarca();
        }

        public RelayCommand AñadirMarcaDialogo { get; }


        private void llenarListaNombreMarcas(ObservableCollection<Marcas> marcas)
        {
            foreach (Marcas m in Marcas) 
            {
                MarcasNombre.Add(m.Marca);
            }
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
        
        private ObservableCollection<string> marcasNombre;

        public ObservableCollection<string> MarcasNombre
        {
            get { return marcasNombre; }
            set { SetProperty(ref marcasNombre, value); }
        }

        

    }
}
