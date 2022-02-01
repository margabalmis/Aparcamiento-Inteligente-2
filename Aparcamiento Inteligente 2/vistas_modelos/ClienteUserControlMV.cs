using Aparcamiento_Inteligente_2.modelo;
using Aparcamiento_Inteligente_2.servicios;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aparcamiento_Inteligente_2.vistas_modelos
{
    class ClienteUserControlMV : ObservableRecipient
    {

        ClienteBD clientesBD;
        VehiculosBD vehiculosBD;

        private readonly DialogosNavegacion servicioDialogos;
        public RelayCommand DialogoNuevoCliente { get; }
        public RelayCommand DialogoEditarCliente { get; }
        public RelayCommand DialogoEliminarCliente { get; }

        public RelayCommand DialogoNuevoVehiculo { get; }
        public RelayCommand DialogoEditarVehiculo { get; }
        public RelayCommand DialogoEliminarVehiculo { get; }

        public ClienteUserControlMV()
        {
            //Cargar datos clientes
            clientesBD = new ClienteBD();
            Clientes = new ObservableCollection<Cliente>();
            Clientes = new DBServicio().ClientesGetAll();
            //Cargar datos vehiculos
            vehiculosBD = new VehiculosBD();
            VehiculosAsociadosCliente = new ObservableCollection<Vehiculo>();
            VehiculosAsociadosCliente = vehiculosBD.VehiculosBDSimulacion();


            servicioDialogos = new DialogosNavegacion();

            DialogoNuevoCliente = new RelayCommand(NuevoCliente);
            DialogoEditarCliente = new RelayCommand(EditarCliente);
            DialogoEliminarCliente = new RelayCommand(EliminarCliente);

            DialogoNuevoVehiculo = new RelayCommand(NuevoVehiculo);
            DialogoEditarVehiculo = new RelayCommand(EditarVehiculo);
            DialogoEliminarVehiculo = new RelayCommand(EliminarVehiculo);

        }

        private ObservableCollection<Cliente> clientes;

        public ObservableCollection<Cliente> Clientes
        {
            get { return clientes; }
            set { SetProperty(ref clientes, value); }
        }
        private void EliminarVehiculo()
        {
            throw new NotImplementedException();
        }

        private void EditarVehiculo()
        {
            throw new NotImplementedException();
        }

        private void NuevoVehiculo()
        {
            throw new NotImplementedException();
        }

        private void EliminarCliente()
        {
            throw new NotImplementedException();
        }

        private void EditarCliente()
        {
            throw new NotImplementedException();
        }

        private void NuevoCliente()
        {

            //WeakReferenceMessenger.Default.Send(new NuevoClienteMesage(Nuev));
        }

        
        private Cliente clienteSeleccionado;

        public Cliente ClienteSeleccionado
        {
            get { return clienteSeleccionado; }
            set { SetProperty(ref clienteSeleccionado, value); }
        }
        private ObservableCollection<Vehiculo> vehiculosAsociadosCliente;

        public ObservableCollection<Vehiculo> VehiculosAsociadosCliente
        {
            
            get
            {   return vehiculosAsociadosCliente;}
            set { SetProperty(ref vehiculosAsociadosCliente, value); }
        }
        private Vehiculo vehiculoSeleccionado;

        public Vehiculo VehiculoSeleccionado
        {
            get { return vehiculoSeleccionado; }
            set { SetProperty(ref vehiculoSeleccionado, value); }
        }
    }
}