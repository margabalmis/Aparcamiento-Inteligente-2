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
    class EstacionamientosMV : ObservableRecipient
    {
        //Servicios
        readonly DBServicio baseDatos;
        readonly DialogosNavegacion servicioDialogos;

        public RelayCommand FinalizarEstacionamiento { get; }
        public EstacionamientosMV() 
        {
            //Cargar datos Estacionamientos
            baseDatos = new DBServicio(Properties.Settings.Default.Conexion);
            Estacionamientos = baseDatos.EstacionamientosFindOngoing();

            //Servicios Navegación
            servicioDialogos = new DialogosNavegacion();
            FinalizarEstacionamiento = new RelayCommand(FinEstacionamiento);
        }
        private void FinEstacionamiento()
        {
           if (servicioDialogos.MessageBoxFinalizarEstacionamiento() == true)
            {
                Estacionamientos = baseDatos.EstacionamientosFindOngoing();
            }
        }

        private ObservableCollection<Estacionamiento> estacionamientos;

        public ObservableCollection<Estacionamiento> Estacionamientos
        {

            get { return estacionamientos; }
            set { SetProperty(ref estacionamientos, value); }
        }
        private Estacionamiento estacionamientoSeleccionado;

        public Estacionamiento EstacionamientoSeleccionado
        {
            get { return estacionamientoSeleccionado; }
            set { SetProperty(ref estacionamientoSeleccionado, value); }
        }
    }
}
