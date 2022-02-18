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
    class AñadirVehiculoMV : ObservableRecipient
    {
        private readonly DBServicio baseDatos;
        readonly DialogosNavegacion navegacion;
        public RelayCommand AñadirMarcaDialogo { get; }
        public AñadirVehiculoMV(Cliente propietario)
        {

            navegacion = new DialogosNavegacion();
            AñadirMarcaDialogo = new RelayCommand(DialogoAñadirMarca);

            // Cargar datos Marcas
            baseDatos = new DBServicio(Properties.Settings.Default.Conexion);
            Marcas = new ObservableCollection<Marcas>();
            Marcas = baseDatos.MarcasGetAll();
            VehiculoNuevo = new Vehiculo();
            VehiculoNuevo.Id_cliente = propietario.Id_cliente;

        }

       

        private void DialogoAñadirMarca()
        {
            navegacion.DialogoAñadirMarca();
        }

        internal void AñadirVehiculo()
        {
            if (TipoCoche)
            {
                VehiculoNuevo.Tipo = "Coche";
            }
            else
            {
                VehiculoNuevo.Tipo = "Moto";
            }
            VehiculoNuevo.Id_marca = MarcaSeleccionada.Id_marcas;
            baseDatos.VehiculoInsertOne(VehiculoNuevo);
        }

        private Vehiculo vehiculoNuevo;

        public Vehiculo VehiculoNuevo
        {
            get { return vehiculoNuevo; }
            set { SetProperty(ref vehiculoNuevo, value); }
        }

        private Marcas marcaSeleccionada;

        public Marcas MarcaSeleccionada
        {
            get { return marcaSeleccionada; }
            set { 
                SetProperty(ref marcaSeleccionada, value);
            }
        }

        private ObservableCollection<Marcas> marcas;

        public ObservableCollection<Marcas> Marcas
        {
            get { return marcas; }
            set { SetProperty(ref marcas, value); }
        }

        private bool _tipoCoche;

        public bool TipoCoche
        {
            get { return _tipoCoche; }
            set { SetProperty(ref _tipoCoche, value); }
        }

    }
}