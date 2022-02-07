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
using System.Web.UI;
using System.Windows;

namespace Aparcamiento_Inteligente_2.vistas_modelos
{

    class ClienteUserControlMV : ObservableRecipient
    {

        //Servicios
        readonly DBServicio baseDatos;
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
            baseDatos = new DBServicio();
            Clientes = new ObservableCollection<Cliente>();
            Clientes = baseDatos.ClientesGetAll();

            //Cargar datos vehiculos
            VehiculosAsociadosCliente = new ObservableCollection<Vehiculo>();

            //Servicios Navegación
            servicioDialogos = new DialogosNavegacion();

            DialogoNuevoCliente = new RelayCommand(NuevoCliente);
            DialogoEditarCliente = new RelayCommand(EditarCliente);
            DialogoEliminarCliente = new RelayCommand(EliminarCliente);

            DialogoNuevoVehiculo = new RelayCommand(NuevoVehiculo);
            DialogoEditarVehiculo = new RelayCommand(EditarVehiculo);
            DialogoEliminarVehiculo = new RelayCommand(EliminarVehiculo);


            //Comunicación vistas modelo 
            WeakReferenceMessenger.Default.Register<ClienteUserControlMV, ClienteSeleccionadoMessage>
                (this, (r, m) =>
                {
                    m.Reply(r.ClienteSeleccionado);
                });

            VehiculoSeleccionado = null;
            

        }

        private ObservableCollection<Cliente> clientes;

        public ObservableCollection<Cliente> Clientes
        {
            get { return clientes; }
            set { SetProperty(ref clientes, value); }
        }
        private void EliminarVehiculo()
        {
            servicioDialogos.DialogoEliminarVehiculo();
        }

        private void EditarVehiculo()
        {
            servicioDialogos.DialogoEditarVehiculo();
        }

        private void NuevoVehiculo()
        {
            servicioDialogos.DialogoAñadirVehiculo();
        }

        private void EliminarCliente()
        {
            servicioDialogos.DialogoEliminarCliente();
        }

        private void EditarCliente()
        {
            servicioDialogos.DialogoEditarCliente();
        }

        private void NuevoCliente()
        {
            if (servicioDialogos.DialogoAñadirCliente() == true)
            {
                Clientes = baseDatos.ClientesGetAll();
            }
        }

        
        private Cliente clienteSeleccionado;

        public Cliente ClienteSeleccionado
        {
            get { return clienteSeleccionado; }
            set {
                _ = SetProperty(ref clienteSeleccionado, value);
                if (clienteSeleccionado != null)
                {
                    VehiculosAsociadosCliente = baseDatos.VehiculosFindByCliente(clienteSeleccionado);
                }
            }
        }
        private ObservableCollection<Vehiculo> vehiculosAsociadosCliente;

        public ObservableCollection<Vehiculo> VehiculosAsociadosCliente
        {
            
            get {   return vehiculosAsociadosCliente;}
            set { SetProperty(ref vehiculosAsociadosCliente, value); }
        }

        private Vehiculo vehiculoSeleccionado;

        public Vehiculo VehiculoSeleccionado
        {
            get 
            {
                return vehiculoSeleccionado;}
            set 
            {
                
                SetProperty(ref vehiculoSeleccionado, value);
                WeakReferenceMessenger.Default.Send(new VehiculoSeleccionadoMessage(vehiculoSeleccionado));
            }
        }
    }
}