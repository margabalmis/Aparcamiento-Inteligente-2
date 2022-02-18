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
using System.Windows;

namespace Aparcamiento_Inteligente_2.vistas_modelos
{
    class EstacionamientosMV : ObservableRecipient
    {
        //Servicios
        DBServicio baseDatos;
        readonly DialogosNavegacion servicioDialogos;

        public RelayCommand FinalizarEstacionamiento { get; }
        public EstacionamientosMV() 
        {
            //Cargar datos Estacionamientos
            baseDatos = new DBServicio(Properties.Settings.Default.Conexion);
            //Estacionamientos = new ObservableCollection<Estacionamiento>();
            Estacionamientos = baseDatos.EstacionamientosFindOngoing();

            //Servicios Navegación
            servicioDialogos = new DialogosNavegacion();
            FinalizarEstacionamiento = new RelayCommand(FinEstacionamiento);
        }
        private void FinEstacionamiento()
        {
            DateTime date = DateTime.Now;
            DateTime entrada = DateTime.Parse(EstacionamientoSeleccionado.Entrada);
            TimeSpan tiempo = date.Subtract(entrada);
            int minutos = (int)tiempo.TotalMinutes;
            double cantidadAbonar = EstacionamientoSeleccionado.Id_vehiculo != 0 ? minutos * 0.10 : minutos * 0.15;
            bool result = servicioDialogos.MessageBoxFinalizarEstacionamiento(cantidadAbonar);
            if (result)
            {
                EstacionamientoSeleccionado.Importe = (float)cantidadAbonar;
                EstacionamientoSeleccionado.Salida = date.ToString();
                baseDatos.EstacionamientoUpateOne(EstacionamientoSeleccionado);
            }
            Estacionamientos = baseDatos.EstacionamientosFindOngoing();
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
