using Aparcamiento_Inteligente_2.modelo;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aparcamiento_Inteligente_2.servicios
{
    class VehiculosBD : ObservableRecipient
    {


        public ObservableCollection<Vehiculo> VehiculosBDSimulacion()
        {

            ObservableCollection<Vehiculo> veiculosDB = new ObservableCollection<Vehiculo>();

            veiculosDB.Add(new Vehiculo(1, 6 , "58698771V", 33, "x", "coche"));
            veiculosDB.Add(new Vehiculo(2, 2 , "11111171V",  34, "x", "moto"));
            veiculosDB.Add(new Vehiculo(3, 1, "58622222V",  35, "y", "coche"));
            veiculosDB.Add(new Vehiculo(4, 3, "58684671V",  31, "y", "coche"));
            veiculosDB.Add(new Vehiculo(5, 4, "888898771V", 53, "x", "moto"));
            veiculosDB.Add(new Vehiculo(6, 5, "58999991V", 43, "x", "moto"));

            return veiculosDB;

        }

    }
}