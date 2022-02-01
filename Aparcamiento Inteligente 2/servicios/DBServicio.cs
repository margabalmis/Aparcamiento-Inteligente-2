using Aparcamiento_Inteligente_2.modelo;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aparcamiento_Inteligente_2.servicios
{
    class DBServicio
    {
        public string path { get; private set; }

        public DBServicio(string path)
        {
            this.path = path;
        }

        public ObservableCollection<Cliente> ClientesGetAll()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Vehiculo> VehiculosGetAll()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Marcas> MarcasGetAll()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Estacionamiento> EstacionamientosGetAll()
        {
            throw new NotImplementedException();
        }

        private SqliteConnection conectar()
        {
            return new SqliteConnection("Data Source=" + path);
        }
    }
}
