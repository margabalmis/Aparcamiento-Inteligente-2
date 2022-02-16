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

        public string Path { get; private set; }

        /// <summary>
        /// Constructor del servicio
        /// </summary>
        /// <param name="path">Ruta en la que se encuentra la base de datos</param>
        public DBServicio(string path)
        {
            Path = "Data Source=" + path;
        }

        #region GetAll()
        /// <summary>
        /// Extrae todos los clientes de la base de datos
        /// </summary>
        /// <returns>Colección con los clientes de la base de datosCliente</returns>
        public ObservableCollection<Cliente> ClientesGetAll()
        {
            ObservableCollection<Cliente> result = new ObservableCollection<Cliente>();
            SqliteConnection conexion = new SqliteConnection(Path);
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

        /// <summary>
        /// Extrae todos los vehículos de la base de datos
        /// </summary>
        /// <returns>Colección con los vehiculos de la base de datos</returns>
        public ObservableCollection<Vehiculo> VehiculosGetAll()
        {
            ObservableCollection<Vehiculo> result = new ObservableCollection<Vehiculo>();
            SqliteConnection conexion = new SqliteConnection(Path);
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

        /// <summary>
        /// Extrae todos las marcas de la base de datos
        /// </summary>
        /// <returns>Colección con las marcas de la base de datos</returns>
        public ObservableCollection<Marcas> MarcasGetAll()
        {
            ObservableCollection<Marcas> result = new ObservableCollection<Marcas>();
            SqliteConnection conexion = new SqliteConnection(Path);
            conexion.Open();

            SqliteCommand comando = new SqliteCommand("SELECT * FROM marcas", conexion);
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

        #endregion
        #region InsertOne()
        /// <summary>
        /// Inserta un registro en la tabla clientes
        /// </summary>
        /// <param name="cliente">Cliente a insertar</param>
        /// <returns>devuelve true cuando la insercción es correcta</returns>
        public bool ClienteInsertOne(Cliente cliente)
        {
            bool result = false;

            SqliteConnection conexion = new SqliteConnection(Path);
            conexion.Open();

            SqliteCommand comando = new SqliteCommand("INSERT INTO clientes (nombre, documento, foto, edad, genero, telefono) " +
                "VALUES ( @nombre, @documento, @foto, @edad, @genero, @telefono);", conexion);
            _ = comando.Parameters.Add("@nombre", SqliteType.Text);
            _ = comando.Parameters.Add("@documento", SqliteType.Text);
            _ = comando.Parameters.Add("@foto", SqliteType.Text);
            _ = comando.Parameters.Add("@edad", SqliteType.Integer);
            _ = comando.Parameters.Add("@genero", SqliteType.Text);
            _ = comando.Parameters.Add("@telefono", SqliteType.Text);

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

        /// <summary>
        /// Inserta un registro en la tabla vehiculos
        /// </summary>
        /// <param name="vehiculo">Vehiculo a insertar</param>
        /// <returns>devuelve true cuando la insercción es correcta</returns>
        public bool VehiculoInsertOne(Vehiculo vehiculo)
        {
            bool result = false;

            SqliteConnection conexion = new SqliteConnection(Path);
            conexion.Open();

            SqliteCommand comando = new SqliteCommand("INSERT INTO vehiculos (id_cliente, matricula, id_marca, modelo, tipo) VALUES (@id_cliente, @matricula, @id_marca, @modelo, @tipo);", conexion);
            comando.Parameters.Add("@id_cliente", SqliteType.Integer);
            comando.Parameters.Add("@matricula", SqliteType.Text);
            comando.Parameters.Add("@id_marca", SqliteType.Integer);
            comando.Parameters.Add("@modelo", SqliteType.Text);
            comando.Parameters.Add("@tipo", SqliteType.Text);

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
        /// <summary>
        /// Inserta un registro en la tabla marcas
        /// </summary>
        /// <param name="marca">Marca a insertar</param>
        /// <returns>devuelve true cuando la insercción es correcta</returns>
        public bool MarcaInsertOne(Marcas marca)
        {
            bool result = false;

            SqliteConnection conexion = new SqliteConnection(Path);
            conexion.Open();

            SqliteCommand comando = new SqliteCommand("INSERT INTO marcas (marca) VALUES (@marca);", conexion);
            comando.Parameters.Add("@marca", SqliteType.Text);


            comando.Parameters["@marca"].Value = marca.Marca;

            if (comando.ExecuteNonQuery() == 1)
            {
                result = true;
            }

            conexion.Close();

            return result;
        }

        #endregion
        #region UpdateOne()
        public bool ClienteUpateOne(Cliente cliente)
        {
            bool result = false;

            SqliteConnection conexion = new SqliteConnection(Path);
            conexion.Open();

            SqliteCommand comando = new SqliteCommand("UPDATE clientes SET  " +
                    "nombre = @nombre," +
                    "documento = @documento," +
                    "foto = @foto," +
                    "edad = @edad," +
                    "genero = @genero," +
                    "telefono = @telefono " +
                    "WHERE id_cliente = @id_cliente;", conexion);

            _ = comando.Parameters.Add("@id_cliente", SqliteType.Integer);
            _ = comando.Parameters.Add("@nombre", SqliteType.Text);
            _ = comando.Parameters.Add("@documento", SqliteType.Text);
            _ = comando.Parameters.Add("@foto", SqliteType.Text);
            _ = comando.Parameters.Add("@edad", SqliteType.Integer);
            _ = comando.Parameters.Add("@genero", SqliteType.Text);
            _ = comando.Parameters.Add("@telefono", SqliteType.Text);

            comando.Parameters["@id_cliente"].Value = cliente.Id_cliente;
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

        public bool VehiculoUpateOne(Vehiculo vehiculo)
        {
            bool result = false;

            SqliteConnection conexion = new SqliteConnection(Path);
            conexion.Open();

            SqliteCommand comando = new SqliteCommand("UPDATE vehiculos SET  " +
                    "id_cliente = @id_cliente," +
                    "matricula = @matricula," +
                    "id_marca = @edid_marcaad," +
                    "modelo = @modelo," +
                    "tipo = @tipo " +
                    "WHERE id_vehiculo = @id_vehiculo;", conexion);

            _ = comando.Parameters.Add("@id_vehiculo", SqliteType.Integer);
            _ = comando.Parameters.Add("@id_cliente", SqliteType.Integer);
            _ = comando.Parameters.Add("@matricula", SqliteType.Text);
            _ = comando.Parameters.Add("@id_marca", SqliteType.Integer);
            _ = comando.Parameters.Add("@modelo", SqliteType.Text);
            _ = comando.Parameters.Add("@tipo", SqliteType.Text);

            comando.Parameters["@id_vehiculo"].Value = vehiculo.Id_vehiculo;
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

        public bool MarcaUpateOne(Marcas marca)
        {
            bool result = false;

            SqliteConnection conexion = new SqliteConnection(Path);
            conexion.Open();

            SqliteCommand comando = new SqliteCommand("UPDATE marcas SET  " +
                    "marca = @marca " +
                    "WHERE id_marca = @id_marca;", conexion);

            _ = comando.Parameters.Add("@id_marca", SqliteType.Integer);
            _ = comando.Parameters.Add("@marca", SqliteType.Text);


            comando.Parameters["@id_marca"].Value = marca.Id_marcas;
            comando.Parameters["@marca"].Value = marca.Marca;

            if (comando.ExecuteNonQuery() == 1)
            {
                result = true;
            }

            conexion.Close();

            return result;
        }

        public bool EstacionamientoUpateOne(Estacionamiento estacionamiento)
        {
            bool result = false;

            SqliteConnection conexion = new SqliteConnection(Path);
            conexion.Open();

            SqliteCommand comando = new SqliteCommand("UPDATE estacionamientos SET  " +
                    "id_vehiculo = @id_vehiculo," +
                    "matricula = @matricula," +
                    "entrada = @entrada," +
                    "salida = @salida," +
                    "importe = @importe, " +
                    "tipo = @tipo " +
                    "WHERE id_estacionamiento = @id_estacionamiento;", conexion);

            comando.Parameters.Add("@id_estacionamiento", SqliteType.Integer);
            comando.Parameters.Add("@id_vehiculo", SqliteType.Integer);
            comando.Parameters.Add("@matricula", SqliteType.Text);
            comando.Parameters.Add("@entrada", SqliteType.Text);
            comando.Parameters.Add("@salida", SqliteType.Text);
            comando.Parameters.Add("@importe", SqliteType.Real);
            comando.Parameters.Add("@tipo", SqliteType.Text);

            comando.Parameters["@id_estacionamiento"].Value = estacionamiento.Id_estacionamiento;
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
        #region DeleteOne()

        /// <summary>
        /// Elimina un registro de la tabla clientes
        /// </summary>
        /// <param name="cliente">Cliente a eliminar</param>
        /// <returns>Devuelve true cuando la eliminación es correcta</returns>
        public bool ClienteDeleteOne(Cliente cliente)
        {
            bool result = false;

            SqliteConnection conexion = new SqliteConnection(Path);
            conexion.Open();

            SqliteCommand comando = new SqliteCommand("DELETE FROM clientes WHERE id_cliente = @id_cliente;", conexion);

            _ = comando.Parameters.Add("@id_cliente", SqliteType.Integer);

            comando.Parameters["@id_cliente"].Value = cliente.Id_cliente;

            if (comando.ExecuteNonQuery() == 1)
            {
                result = true;
            }

            conexion.Close();

            return result;
        }

        /// <summary>
        /// Elimina un registro de la tabla vehiculo
        /// </summary>
        /// <param name="vehiculo">Vehiculo a eliminar</param>
        /// <returns>Devuelve true cuando la eliminación es correcta</returns>
        public bool VehiculoDeleteOne(Vehiculo vehiculo)
        {
            bool result = false;

            SqliteConnection conexion = new SqliteConnection(Path);
            conexion.Open();

            SqliteCommand comando = new SqliteCommand("DELETE FROM vehiculos WHERE id_vehiculo = @id_vehiculo;", conexion);

            _ = comando.Parameters.Add("@id_vehiculo", SqliteType.Integer);

            comando.Parameters["@id_vehiculo"].Value = vehiculo.Id_vehiculo;

            if (comando.ExecuteNonQuery() == 1)
            {
                result = true;
            }

            conexion.Close();

            return result;
        }

        #endregion
        #region Find()

        /// <summary>
        /// Busca y devuelve los vehículos asociados al cliente que le pases
        /// </summary>
        /// <param name="cliente">Cliente para buscar</param>
        /// <returns>Lista de Vehiculos</returns>
        public ObservableCollection<Vehiculo> VehiculosFindByCliente(Cliente cliente)
        {
            ObservableCollection<Vehiculo> result = new ObservableCollection<Vehiculo>();
            SqliteConnection conexion = new SqliteConnection(Path);
            conexion.Open();

            SqliteCommand comando = new SqliteCommand("SELECT * FROM vehiculos WHERE id_cliente = @id_cliente", conexion);

            _ = comando.Parameters.Add("@id_cliente", SqliteType.Integer);

            comando.Parameters["@id_cliente"].Value = cliente.Id_cliente;


            SqliteDataReader lector = comando.ExecuteReader();

            if (lector.HasRows)
            {
                while (lector.Read())
                {
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
        /// <summary>
        /// Busca y devuelve el vehículo por su matricula
        /// </summary>
        /// <param name="matricula">Matricula para buscar </param>
        /// <returns>Vehículo con la matricula pasada</returns>
        public Vehiculo VehiculosFindByMatricula(string matricula)
        {
            Vehiculo result = new Vehiculo();
            SqliteConnection conexion = new SqliteConnection(Path);
            conexion.Open();

            SqliteCommand comando = new SqliteCommand("SELECT * FROM vehiculos WHERE matricula = @matricula", conexion);

            _ = comando.Parameters.Add("@matricula", SqliteType.Text);

            comando.Parameters["@matricula"].Value = matricula;

            SqliteDataReader lector = comando.ExecuteReader();

            if (lector.HasRows)
            {
                lector.Read();
                result = new Vehiculo(
                        Convert.ToInt32(lector["id_vehiculo"]),
                        Convert.ToInt32(lector["id_cliente"]),
                        (string)lector["matricula"],
                        Convert.ToInt32(lector["id_marca"]),
                        (string)lector["modelo"],
                        (string)lector["tipo"]
                );

            }
            conexion.Close();
            return result;
        }
        
        /// <summary>
        /// Devuelve el Cliente de un vehículo
        /// </summary>
        /// <param name="vehiculo">Vehiculo para buscar</param>
        /// <returns>Cliente</returns>
        public Cliente VehiculoFindCliente(Vehiculo vehiculo)
        {
            Cliente result = null;
            SqliteConnection conexion = new SqliteConnection(Path);
            conexion.Open();

            SqliteCommand comando = new SqliteCommand("SELECT * FROM clientes WHERE id_cliente = @id_cliente", conexion);

            _ = comando.Parameters.Add("@id_cliente", SqliteType.Integer);

            comando.Parameters["@id_cliente"].Value = vehiculo.Id_cliente;


            SqliteDataReader lector = comando.ExecuteReader();

            if (lector.HasRows)
            {
                lector.Read();
                result =
                     new Cliente(
                        Convert.ToInt32(lector["id_cliente"]),
                        (string)lector["nombre"],
                        (string)lector["documento"],
                        (string)lector["foto"],
                        Convert.ToInt32(lector["edad"]),
                        (string)lector["genero"],
                        (string)lector["telefono"]
                );
            }

            conexion.Close();

            return result;
        }


        /// <summary>
        ///  Devuelve los estacionamientos en curso, aquellos cuya salida sea null
        /// </summary>
        /// <returns>Colección de Estacionamientos</returns>
        public ObservableCollection<Estacionamiento> EstacionamientosFindOngoing()
        {
            ObservableCollection<Estacionamiento> result = new ObservableCollection<Estacionamiento>();
            SqliteConnection conexion = new SqliteConnection(Path);
            conexion.Open();

            SqliteCommand comando = new SqliteCommand("SELECT * FROM estacionamientos WHERE salida IS NULL", conexion);
            SqliteDataReader lector = comando.ExecuteReader();

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    var id = lector["id_vehiculo"];
                    if (id is DBNull)
                    {
                        result.Add(new Estacionamiento(
                            Convert.ToInt32(lector["id_estacionamiento"]),
                            0,
                            (string)lector["matricula"],
                            (string)lector["entrada"],
                            "",
                            0,
                            (string)lector["tipo"]
                            ));
                    }
                    else
                    {
                        result.Add(
                            new Estacionamiento(
                                Convert.ToInt32(lector["id_estacionamiento"]),
                                Convert.ToInt32(id),
                                (string)lector["matricula"],
                                (string)lector["entrada"],
                                "",
                                0,
                                (string)lector["tipo"]
                        ));
                    }
                }
            }

            conexion.Close();
            return result;
        }

        /// <summary>
        /// Devuelve true si el vehículo que le pasa esta ya dentro del parking
        /// </summary>
        /// <param name="vehiculo">Vehiculo a comprobar</param>
        /// <returns>Si el vehiculo esta estacionado en bool</returns>
        public bool VehiculoIsEstacionado(Vehiculo vehiculo)
        {
            bool result = false;
            if (vehiculo.Id_vehiculo != 0)
            {
                ObservableCollection<Estacionamiento> cochesParking = EstacionamientosFindOngoing();

                foreach (Estacionamiento item in cochesParking)
                {
                    if (item.Id_vehiculo == vehiculo.Id_vehiculo)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Devuelve true si el cliente tiene vehiculos
        /// </summary>
        /// <param name="cliente">Cliente para buscar</param>
        /// <returns> Si el cliente tiene vehículos en bool</returns>
        public bool ClienteHasVehiculos(Cliente cliente)
        {
            bool result = false;
            if (VehiculosFindByCliente(cliente).Count != 0)
            {
                result = true;
            }

            return result;
        }
        
        /// <summary>
        /// Devuelve el nombre de la marca por su id 
        /// </summary>
        /// <param name="idMarca">Id de la marca en entero</param>
        /// <returns>string nombre de la marca</returns>
        public string MarcasFindMarca(int idMarca)
        {
            string result = "";
            SqliteConnection conexion = new SqliteConnection(Path);
            conexion.Open();

            SqliteCommand comando = new SqliteCommand("SELECT marca FROM marcas WHERE id_marca = @id_marca ", conexion);

            _ = comando.Parameters.Add("@id_marca", SqliteType.Integer);

            comando.Parameters["@id_marca"].Value = idMarca;

            SqliteDataReader lector = comando.ExecuteReader();

            if (lector.HasRows)
            {
                    result = (string)lector["marca"];
            }

            conexion.Close();
            return result;
        }
        #endregion
        #region New()

        /// <summary>
        /// Añade el estacionamiento a la base de datos para un estacionamiento con vehículo registrado
        /// </summary>
        /// <param name="estacionamiento">Estacionamiento a insertar</param>
        /// <returns>True si la insercción ha sido correcta</returns>
        public bool EstacionamientoNew(Estacionamiento estacionamiento)
        {
            bool result = false;

            SqliteConnection conexion = new SqliteConnection(Path);
            conexion.Open();

            SqliteCommand comando = new SqliteCommand("INSERT INTO estacionamientos (id_vehiculo, matricula, entrada, tipo) VALUES (@id_vehiculo, @matricula, @entrada, @tipo);", conexion);
            comando.Parameters.Add("@id_vehiculo", SqliteType.Integer);
            comando.Parameters.Add("@matricula", SqliteType.Text);
            comando.Parameters.Add("@entrada", SqliteType.Text);
            comando.Parameters.Add("@tipo", SqliteType.Text);

            comando.Parameters["@id_vehiculo"].Value = estacionamiento.Id_vehiculo;
            comando.Parameters["@matricula"].Value = estacionamiento.Matricula;
            comando.Parameters["@entrada"].Value = estacionamiento.Entrada;
            comando.Parameters["@tipo"].Value = estacionamiento.Tipo;

            if (comando.ExecuteNonQuery() == 1)
            {
                result = true;
            }

            conexion.Close();

            return result;
        }

        /// <summary>
        /// Añade el estacionamiento a la base de datos para un estacionamiento con vehículo registrado
        /// </summary>
        /// <param name="estacionamiento">Estacionamiento a insertar</param>
        /// <returns>True si la insercción ha sido correcta</returns>
        public bool EstacionamientoNewVehiculo(Estacionamiento estacionamiento)
        {
            bool result = false;

            SqliteConnection conexion = new SqliteConnection(Path);
            conexion.Open();

            SqliteCommand comando = new SqliteCommand("INSERT INTO estacionamientos (matricula, entrada, tipo) VALUES (@matricula, @entrada, @tipo);", conexion);
            comando.Parameters.Add("@matricula", SqliteType.Text);
            comando.Parameters.Add("@entrada", SqliteType.Text);
            comando.Parameters.Add("@tipo", SqliteType.Text);

            comando.Parameters["@matricula"].Value = estacionamiento.Matricula;
            comando.Parameters["@entrada"].Value = estacionamiento.Entrada;
            comando.Parameters["@tipo"].Value = estacionamiento.Tipo;

            if (comando.ExecuteNonQuery() == 1)
            {
                result = true;
            }

            conexion.Close();

            return result;
        }
        #endregion
    }
}
