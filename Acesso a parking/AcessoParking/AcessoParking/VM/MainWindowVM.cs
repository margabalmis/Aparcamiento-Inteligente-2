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

        public MainWindowVM()
        {
            AbrirFotoCommand = new RelayCommand(AbrirImagen);
            EntraParkingCommand = new RelayCommand(CrearEstacionamiento);

            navegacion = new ServicioNavegacion();
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
            throw new NotSupportedException();
        }
    }
}
