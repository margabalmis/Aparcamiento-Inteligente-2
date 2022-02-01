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

            veiculosDB.Add(new Vehiculo(1, 6 ,"María", "58698771V", "foto", 33, "x", "654985522"));
            veiculosDB.Add(new Vehiculo(2, 2 ,"Julia", "11111171V", "fotos", 34, "x", "64524522"));
            veiculosDB.Add(new Vehiculo(3, 1,"Ana", "58622222V", "foto", 35, "x", "651454522"));
            veiculosDB.Add(new Vehiculo(4, 3,"Carmen", "58684671V", "foto", 31, "x", "6549254522"));
            veiculosDB.Add(new Vehiculo(5, 4,"Esperanza", "888898771V", "foto", 53, "x", "654985555"));
            veiculosDB.Add(new Vehiculo(6, 5,"Lucía", "58999991V", "foto", 43, "x", "6549835454"));

            return veiculosDB;

        }

    }
}