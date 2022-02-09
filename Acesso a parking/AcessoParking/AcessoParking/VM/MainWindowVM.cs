using AcessoParcking.modelo;
using AcessoParcking.Servicios;
using AcessoParking.Servicios;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoParking.VM
{
    class MainWindowVM: ObservableObject
    {
        private readonly ServicioNavegacion navegacion;
        private readonly DBServicio baseDatos;

        public MainWindowVM()
        {
            AbrirFotoCommand = new RelayCommand(AbrirImagen);
            EntraParkingCommand = new RelayCommand(CrearEstacionamiento);

            navegacion = new ServicioNavegacion();
            baseDatos = new DBServicio(Properties.Settings.Default.Conexion);

            PathFoto = "";
        }

        private void AbrirImagen()
        {
           PathFoto = navegacion.AbrirImagenDialog();
        }

        public RelayCommand AbrirFotoCommand { get; }

        public RelayCommand EntraParkingCommand { get; }


        private string _pathFoto;

        public string PathFoto
        {
            get => _pathFoto;
            set { _ = SetProperty(ref _pathFoto, value); }
        }

        public void CrearEstacionamiento()
        {
            string imagen = Nube.SubirImagen(PathFoto);
            string tipo = VehiculoIdentificarAPI.Identificar(imagen);
            string matricula;

            if(tipo == "moto")
            {
                matricula = MatriculaAPI.GetMatriculaMoto(imagen);
            }
            else
            {
                matricula = MatriculaAPI.GetMatriculaCoche(imagen);
            }

            Vehiculo vehiculo = baseDatos.VehiculosFindByMatricula(matricula);

            if (baseDatos.VehiculoEstacionado(vehiculo))
            {
                navegacion.Alert("El vehículo ya esta dentro del parking, contacte con su supervisor");
            }
            else
            {
                DateTime fechaLocal = DateTime.Now;
                var culture = new CultureInfo("es-ES");
                string fechaEntrada = fechaLocal.ToString(culture);

                Estacionamiento nuevo = new Estacionamiento(vehiculo.Id_vehiculo, matricula, fechaEntrada, tipo);

                _ = baseDatos.EstacionamientoInsertOne(nuevo);
            }


           
            PathFoto = "";
        }
    }
}
