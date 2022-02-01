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
            this.path = "Data Source={0}" + path;
        }

        public DBServicio()
        {
            this.path = string.Format("Data Source=db/parking.db");
        }

        public ObservableCollection<Cliente> ClientesGetAll()
        {
            ObservableCollection<Cliente> result = new ObservableCollection<Cliente>();
            using (SqliteConnection conexion = Conectar())
            {
                SqliteCommand comando = new SqliteCommand("SELECT * FROM clientes", conexion);
                SqliteDataReader lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    { 
                        //public Cliente(int id_cliente, string nombre, string documento, string foto, int edad, string genero, string telefono)
                        result.Add(new Cliente(
                            (int)lector["id_cliente"],
                            (string)lector["nombre"],
                            (string)lector["documento"],
                            (string)lector["foto"],
                            (int)lector["edad"],
                            (string)lector["genero"],
                            (string)lector["telefono"]
                        ));
                    }
                }
            }

            return result;
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

        private SqliteConnection Conectar() => new SqliteConnection(path);

    }
}
