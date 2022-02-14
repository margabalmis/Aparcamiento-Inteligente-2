using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aparcamiento_Inteligente_2.modelo
{
    class Estacionamiento : ObservableObject
    {

        public Estacionamiento(int id_estacionamiento, int id_vehiculo, string matricula, 
            string entrada, string salida, float importe, string tipo)
        {
            Id_estacionamiento = id_estacionamiento;
            Id_vehiculo = id_vehiculo;
            Matricula = matricula;
            Entrada = entrada;
            Salida = salida;
            Importe = importe;
            Tipo = tipo;
        }

        private int id_estacionamiento;

        public int Id_estacionamiento
        {
            get { return id_estacionamiento; }
            set { SetProperty(ref id_estacionamiento, value); }
        }

        private int id_vehiculo;

        public int Id_vehiculo
        {
            get { return id_vehiculo; }
            set { SetProperty(ref id_vehiculo, value); }
        }
        private string matricula;

        public string Matricula
        {
            get { return matricula; }
            set { SetProperty(ref matricula, value); }
        }
        private string entrada;

        public string Entrada
        {
            get { return entrada; }
            set { SetProperty(ref entrada, value); }
        }
        private string salida;

        public string Salida
        {
            get { return salida; }
            set { SetProperty(ref salida, value); }
        }
        private float importe;

        public float Importe
        {
            get { return importe; }
            set { SetProperty(ref importe, value); }
        }

        private string tipo;

        public string Tipo
        {
            get { return tipo; }
            set { SetProperty(ref tipo, value); }
        }


    }
}