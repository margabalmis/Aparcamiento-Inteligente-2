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
            this.path = "Data Source" + AbsolutePath(path);
        }

        public DBServicio()
        {
            this.path = string.Format("Data Source=" + AbsolutePath("parking.db"));
        }

        #region GetAll()
        public ObservableCollection<Cliente> ClientesGetAll()
        {
            ObservableCollection<Cliente> result = new ObservableCollection<Cliente>();
            SqliteConnection conexion = new SqliteConnection(path);
            conexion.Open();

            SqliteCommand comando = new SqliteCommand("SELECT * FROM clientes", conexion);
            SqliteDataReader lector = comando.ExecuteReader();

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    //public Cliente(int id_cliente, string nombre, string documento, string foto, int edad, string genero, string telefono)
                    result.Add(
                        new Cliente(
                            Convert.ToInt32(lector["id_cliente"]),
                            (string)lector["nombre"],
                            (string)lector["documento"],
                            (string)lector["foto"],
                            Convert.ToInt32(lector["edad"]),
                            (string)lector["genero"],
                            (string)lector["telefono"]
                    ));
                }
            }

            conexion.Close();
            return result;
        }


        public ObservableCollection<Vehiculo> VehiculosGetAll()
        {
            ObservableCollection<Vehiculo> result = new ObservableCollection<Vehiculo>();
            SqliteConnection conexion = new SqliteConnection(path);
            conexion.Open();

            SqliteCommand comando = new SqliteCommand("SELECT * FROM vehiculos", conexion);
            SqliteDataReader lector = comando.ExecuteReader();

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    //public Vehiculo(int id_vehiculo, int id_cliente, string matricula, int id_marcas, string modelo, string tipo)
                    result.Add(
                        new Vehiculo(
                            Convert.ToInt32(lector["id_vehiculo"]),
                            Convert.ToInt32(lector["id_cliente"]),
                            (string)lector["matricula"],
                            Convert.ToInt32(lector["id_marca"]),
                            (string)lector["modelo"],
                            (string)lector["tipo"]
                    ));
                }
            }

            conexion.Close();
            return result;
        }

        public ObservableCollection<Marcas> MarcasGetAll()
        {
            ObservableCollection<Marcas> result = new ObservableCollection<Marcas>();
            SqliteConnection conexion = new SqliteConnection(path);
            conexion.Open();

            SqliteCommand comando = new SqliteCommand("SELECT * FROM vehiculos", conexion);
            SqliteDataReader lector = comando.ExecuteReader();

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    //public Marcas(int id_marca, string marca)
                    result.Add(
                        new Marcas(
                            Convert.ToInt32(lector["id_marca"]),
                            (string)lector["marca"]
                    ));
                }
            }

            conexion.Close();
            return result;
        }

        public ObservableCollection<Estacionamiento> EstacionamientosGetAll()
        {
            ObservableCollection<Estacionamiento> result = new ObservableCollection<Estacionamiento>();
            SqliteConnection conexion = new SqliteConnection(path);
            conexion.Open();

            SqliteCommand comando = new SqliteCommand("SELECT * FROM vehiculos", conexion);
            SqliteDataReader lector = comando.ExecuteReader();

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    //public Estacionamiento(int id_estacionamiento, int id_vehiculo, string matricula, string entrada, string salida, float importe, string tipo)
                    result.Add(
                        new Estacionamiento(
                            Convert.ToInt32(lector["id_estacionamiento"]),
                            Convert.ToInt32(lector["id_vehiculo"]),
                            (string)lector["matricula"],
                            (string)lector["entrada"],
                            (string)lector["salida"],
                            (float)Convert.ToDouble(lector["importe"]),
                            (string)lector["tipo"]
                    ));
                }
            }

            conexion.Close();
            return result;
        }
        #endregion
        #region InsertOne()
        public bool ClienteInsertOne(Cliente cliente)
        {
            bool result = false;

            SqliteConnection conexion = new SqliteConnection(path);
            conexion.Open();

            SqliteCommand comando = new SqliteCommand("INSERT INTO clientes VALUES (@id_cliente, @nombre, @documento, @foto, @edad, @genero, @telefono) ", conexion);
            comando.Parameters.Add("@id_cliente", SqliteType.Integer);
            comando.Parameters.Add("@nombre", SqliteType.Text);
            comando.Parameters.Add("@documento", SqliteType.Text);
            comando.Parameters.Add("@foto", SqliteType.Text);
            comando.Parameters.Add("@edad", SqliteType.Integer);
            comando.Parameters.Add("@genero", SqliteType.Text);
            comando.Parameters.Add("@telefono", SqliteType.Text);

            comando.Parameters["@id_cliente"].Value = null;
            comando.Parameters["@nombre"].Value = cliente.Nombre;
            comando.Parameters["@documento"].Value = cliente.Documento;
            comando.Parameters["@foto"].Value = cliente.Foto;
            comando.Parameters["@edad"].Value = cliente.Edad;
            comando.Parameters["@genero"].Value = cliente.Genero;
            comando.Parameters["@telefono"].Value = cliente.Telefono;

            if (comando.ExecuteNonQuery() == 1)
            {
                result = true;
            }

            conexion.Close();

            return result;
        }

        public bool VehiculoInsertOne(Vehiculo vehiculo)
        {
            bool result = false;

            SqliteConnection conexion = new SqliteConnection(path);
            conexion.Open();

            SqliteCommand comando = new SqliteCommand("INSERT INTO vehiculos VALUES (@id_vehiculo, @id_cliente, @matricula, @id_marca, @modelo, @tipo) ", conexion);
            comando.Parameters.Add("@id_vehiculo", SqliteType.Integer);
            comando.Parameters.Add("@id_cliente", SqliteType.Integer);
            comando.Parameters.Add("@matricula", SqliteType.Text);
            comando.Parameters.Add("@id_marca", SqliteType.Integer);
            comando.Parameters.Add("@modelo", SqliteType.Text);
            comando.Parameters.Add("@tipo", SqliteType.Text);

            comando.Parameters["@id_vehiculo"].Value = null;
            comando.Parameters["@id_cliente"].Value = vehiculo.Id_cliente;
            comando.Parameters["@matricula"].Value = vehiculo.Matricula;
            comando.Parameters["@id_marca"].Value = vehiculo.Id_marca;
            comando.Parameters["@modelo"].Value = vehiculo.Modelo;
            comando.Parameters["@tipo"].Value = vehiculo.Tipo;

            if (comando.ExecuteNonQuery() == 1)
            {
                result = true;
            }

            conexion.Close();

            return result;
        }

        public bool MarcaInsertOne(Marcas marca)
        {
            bool result = false;

            SqliteConnection conexion = new SqliteConnection(path);
            conexion.Open();

            SqliteCommand comando = new SqliteCommand("INSERT INTO marcas VALUES (@id_marca, @marca)", conexion);
            comando.Parameters.Add("@id_marca", SqliteType.Integer);
            comando.Parameters.Add("@marca", SqliteType.Text);


            comando.Parameters["@id_marca"].Value = null;
            comando.Parameters["@marca"].Value = marca.Marca;

            if (comando.ExecuteNonQuery() == 1)
            {
                result = true;
            }

            conexion.Close();

            return result;
        }

        public bool EstacionamientoInsertOne(Estacionamiento estacionamiento)
        {
            bool result = false;

            SqliteConnection conexion = new SqliteConnection(path);
            conexion.Open();

            SqliteCommand comando = new SqliteCommand("INSERT INTO estacionamientos VALUES (@id_estacionamiento, @id_vehiculo, @matricula, @entrada, @salida, @importe, @tipo) ", conexion);
            comando.Parameters.Add("@id_estacionamiento", SqliteType.Integer);
            comando.Parameters.Add("@id_vehiculo", SqliteType.Integer);
            comando.Parameters.Add("@matricula", SqliteType.Text);
            comando.Parameters.Add("@entrada", SqliteType.Text);
            comando.Parameters.Add("@salida", SqliteType.Text);
            comando.Parameters.Add("@importe", SqliteType.Real);
            comando.Parameters.Add("@tipo", SqliteType.Text);

            comando.Parameters["@id_estacionamiento"].Value = null;
            comando.Parameters["@id_vehiculo"].Value = estacionamiento.Id_vehiculo;
            comando.Parameters["@matricula"].Value = estacionamiento.Matricula;
            comando.Parameters["@entrada"].Value = estacionamiento.Entrada;
            comando.Parameters["@salida"].Value = estacionamiento.Salida;
            comando.Parameters["@importe"].Value = estacionamiento.Importe;
            comando.Parameters["@tipo"].Value = estacionamiento.Tipo;

            if (comando.ExecuteNonQuery() == 1)
            {
                result = true;
            }

            conexion.Close();

            return result;
        }

        #endregion

        private string AbsolutePath(string path) => System.IO.Path.Combine(Environment.CurrentDirectory, path);

    }
}
