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
        readonly DBServicio baseDatos;
        readonly DialogosNavegacion navegacion;
        public EditarVehiculoMV(String origen)
        {
            // Cargar datos Marcas
            baseDatos = new DBServicio(Properties.Settings.Default.Conexion);
            Marcas = new ObservableCollection<Marcas>();
            Marcas = baseDatos.MarcasGetAll();

            //Añadir Marcas dialogo
            navegacion = new DialogosNavegacion();
            AñadirMarcaDialogo = new RelayCommand(DialogoAñadirMarca);

            //Comunicacion
            if (origen == "cliente")
            {
                VehiculoSeleccionado = WeakReferenceMessenger.Default.Send<VehiculoSeleccionadoMessageDesdeCliente>();
            }
            else
            {
                VehiculoSeleccionado = WeakReferenceMessenger.Default.Send<VehiculoSeleccionadoMessageDesdeVehiculo>();
            }


            //Seleccinar Tipo
            if (VehiculoSeleccionado != null)
            {
                if (VehiculoSeleccionado.Tipo.Equals("coche"))
                {
                    TipoCoche = true;
                    TipoMoto = false;
                }
                else if (VehiculoSeleccionado.Tipo.Equals("moto"))
                {
                    TipoCoche = false;
                    TipoMoto = true;
                }

                //Cliente Propietario
                if (VehiculoSeleccionado != null)
                {
                    Propietario = baseDatos.VehiculoFindCliente(VehiculoSeleccionado);
                }

            }
            
        }

        internal void EditarVehiculo()
        {

            _ = baseDatos.VehiculoUpateOne(VehiculoSeleccionado);
        }

        private void DialogoAñadirMarca()
        {
            navegacion.DialogoAñadirMarca();
        }

        public RelayCommand AñadirMarcaDialogo { get; }


        private Vehiculo vehiculoSeleccionado;

        public Vehiculo VehiculoSeleccionado
        {
            get { return vehiculoSeleccionado; }
            set { SetProperty(ref vehiculoSeleccionado, value); }
        }
        private bool tipoCoche;

        public bool TipoCoche
        {
            get { return tipoCoche; }
            set { SetProperty(ref tipoCoche, value); }
        }
        private bool tipoMoto;

        public bool TipoMoto
        {
            get { return tipoMoto; }
            set { SetProperty(ref tipoMoto, value); }
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