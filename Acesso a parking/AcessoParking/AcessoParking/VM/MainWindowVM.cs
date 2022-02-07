using AcessoParcking.modelo;
using AcessoParcking.servicios;
using AcessoParking.Servicios;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
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
            baseDatos = new DBServicio("C:\\parking");
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
           Estacionamiento test = new Estacionamiento(0, 21, "knowledge base", "07-02-2022-14:51", "07-02-2022-14:56", 3.20f, "coche");

            baseDatos.EstacionamientoInsertOne(test);
        }
    }
}
