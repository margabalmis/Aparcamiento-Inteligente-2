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
        public AñadirVehiculoMV()
        {

            navegacion = new DialogosNavegacion();

            AñadirMarcaDialogo = new RelayCommand(DialogoAñadirMarca);
            // Cargar datos Marcas
            baseDatos = new DBServicio(Properties.Settings.Default.Conexion);
            Marcas = new ObservableCollection<Marcas>();
            Marcas = baseDatos.MarcasGetAll();

            //Seleccinar Tipo
            if (VehiculoNuevo != null)
            {
                if (VehiculoNuevo.Tipo.Equals("coche"))
                {
                    TipoCoche = true;
                    TipoMoto = false;
                }
                else if (VehiculoNuevo.Tipo.Equals("moto"))
                {
                    TipoCoche = false;
                    TipoMoto = true;
                }

                //Cliente Propietario
                if (VehiculoNuevo != null)
                {
                    Propietario = baseDatos.VehiculoFindCliente(VehiculoNuevo);
                }

            }

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

        private void DialogoAñadirMarca()
        {
            navegacion.DialogoAñadirMarca();
        }

        private Vehiculo vehiculoNuevo;

        public Vehiculo VehiculoNuevo
        {
            get { return vehiculoNuevo; }
            set { SetProperty(ref vehiculoNuevo, value); }
        }

        private Cliente propietario;

        internal void AñadirVehiculo()
        {
            throw new NotImplementedException();
        }

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