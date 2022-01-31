using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aparcamiento_Inteligente_2.modelo
{
    class Vehiculo : ObservableObject
    {
        private int id_vehiculos;

        public int Id_vehiculo
        {
            get { return id_vehiculos; }
            set { SetProperty(ref id_vehiculos, value); }
        }

        private int id_cliente;

        public int Id_cliente
        {
            get { return id_cliente; }
            set { SetProperty(ref id_cliente, value); }
        }

        private string matricula;

        public string Matricula
        {
            get { return matricula; }
            set { SetProperty(ref matricula, value); }
        }
        private int id_marcas;

        public int Id_marcas
        {
            get { return id_marcas; }
            set { SetProperty(ref id_marcas, value); }
        }

        private string modelo;

        public string Modelo
        {
            get { return modelo; }
            set { SetProperty(ref modelo, value); }
        }

        private string tipo;

        public string Tipo
        {
            get { return tipo; }
            set { SetProperty(ref tipo, value); }
        }
    }
}