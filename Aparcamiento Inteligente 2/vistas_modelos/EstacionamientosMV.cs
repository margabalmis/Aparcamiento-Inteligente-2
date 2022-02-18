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
        readonly DBServicio baseDatos;
        readonly DialogosNavegacion servicioDialogos;

        public RelayCommand FinalizarEstacionamiento { get; }
        public RelayCommand ActualizarEstacionamiento { get; }
        public EstacionamientosMV() 
        {
            //Cargar datos Estacionamientos
            baseDatos = new DBServicio(Properties.Settings.Default.Conexion);
            Estacionamientos = baseDatos.EstacionamientosFindOngoing();

            //Servicios Navegación
            servicioDialogos = new DialogosNavegacion();
            FinalizarEstacionamiento = new RelayCommand(FinEstacionamiento);
            ActualizarEstacionamiento = new RelayCommand(ActualizarEstacionamientos);
            Precio = 0.0;

        }
        private void ActualizarEstacionamientos()
        {
            Estacionamientos = baseDatos.EstacionamientosFindOngoing();
        }
        private void FinEstacionamiento()
        {
            DateTime date = DateTime.Now;
            bool result = servicioDialogos.MessageBoxFinalizarEstacionamiento(Precio);
            if (result)
            {
                EstacionamientoSeleccionado.Importe = (float)Precio;
                EstacionamientoSeleccionado.Salida = date.ToString();
                baseDatos.EstacionamientoUpateOne(EstacionamientoSeleccionado);
            }
            Estacionamientos = baseDatos.EstacionamientosFindOngoing();
        }

        private double precio;

        public double Precio
        {
            get { return precio; }
            set { SetProperty(ref precio, value); }
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
            set { 
                SetProperty(ref estacionamientoSeleccionado, value);
                if(estacionamientoSeleccionado != null)
                {
                    DateTime date = DateTime.Now;
                    DateTime entrada = DateTime.Parse(EstacionamientoSeleccionado.Entrada);
                    TimeSpan tiempo = date.Subtract(entrada);
                    int minutos = (int)tiempo.TotalMinutes;
                    double cantidadAbonar = EstacionamientoSeleccionado.Id_vehiculo != 0 ? minutos * 0.10 : minutos * 0.15;
                    Precio = cantidadAbonar;
                }

            }
        }
    }
}
