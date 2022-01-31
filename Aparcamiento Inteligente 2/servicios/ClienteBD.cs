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
    class ClienteBD : ObservableRecipient
    {

        
        public ObservableCollection<Cliente> ClientesBDSimulacion()
        {

            ObservableCollection<Cliente> clientesDB = new ObservableCollection<Cliente>();

            clientesDB.Add(new Cliente(1, "María", "58698771V", "foto", 33, "x", "654985522"));
            clientesDB.Add(new Cliente(2, "Julia", "11111171V", "fotos", 34, "x", "64524522"));
            clientesDB.Add(new Cliente(3, "Ana", "58622222V", "foto", 35, "x", "651454522"));
            clientesDB.Add(new Cliente(4, "Carmen", "58684671V", "foto", 31, "x", "6549254522"));
            clientesDB.Add(new Cliente(5, "Esperanza", "888898771V", "foto", 53, "x", "654985555"));
            clientesDB.Add(new Cliente(6, "Lucía", "58999991V", "foto", 43, "x", "6549835454"));

            return clientesDB;

        }

    }
}