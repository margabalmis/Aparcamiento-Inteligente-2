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
    class VehiculoUserControlMV : ObservableRecipient
    {

        //Servicios
        private readonly DBServicio baseDatos;
        private readonly DialogosNavegacion servicioDialogos;

        public RelayCommand DialogoEliminarVehiculo { get; }
        public RelayCommand DialogoEditarVehiculo { get; }



        public VehiculoUserControlMV() {

            //Servicios Navegación
            servicioDialogos = new DialogosNavegacion();
            baseDatos = new DBServicio();

            DialogoEliminarVehiculo = new RelayCommand(EliminarVehiculo);
            DialogoEditarVehiculo = new RelayCommand(EditarVehiculo);
            Vehiculos = baseDatos.VehiculosGetAll();
             
            
            

        }

        private void EditarVehiculo()
        {
            servicioDialogos.DialogoEditarVehiculo();
            WeakReferenceMessenger.Default.Send(new VehiculoSeleccionadoMessageDifuson(VehiculoSeleccionado));
        }

        private void EliminarVehiculo()
        {
            servicioDialogos.DialogoEliminarVehiculo();
            WeakReferenceMessenger.Default.Send(new VehiculoSeleccionadoMessageDifuson(VehiculoSeleccionado));
        }

        private ObservableCollection<Vehiculo> vehiculos;

        public ObservableCollection<Vehiculo> Vehiculos
        {
            get { return vehiculos; }
            set { SetProperty(ref vehiculos, value); }
        }
        private Vehiculo vehiculoSeleccionado;

        public Vehiculo VehiculoSeleccionado
        {
            get { return vehiculoSeleccionado; }
            set { SetProperty(ref vehiculoSeleccionado, value); }
        }
    }
}