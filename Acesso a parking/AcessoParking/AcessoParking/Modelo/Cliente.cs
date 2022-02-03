using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoParcking.modelo
{
    class Cliente : ObservableObject
    {

        public Cliente() { }

        public Cliente(int id_cliente, string nombre, string documento,
            string foto, int edad, string genero, string telefono)
        {
            Id_cliente = id_cliente;
            Nombre = nombre;
            Documento = documento;
            Foto = foto;
            Edad = edad;
            Genero = genero;
            Telefono = telefono;

        }

        //Constructor usado para insertar en la base de datos
        public Cliente(string nombre, string documento, string foto, int edad, string genero, string telefono)
        {
            Id_cliente = 0;
            Nombre = nombre;
            Documento = documento;
            Foto = foto;
            Edad = edad;
            Genero = genero;
            Telefono = telefono;
        }

        private int id_cliente;

        public int Id_cliente
        {
            get { return id_cliente; }
            set { SetProperty(ref id_cliente, value); }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { SetProperty(ref nombre, value); }
        }

        private string documento;

        public string Documento
        {
            get { return documento; }
            set { SetProperty(ref documento, value); }
        }
        private string foto;

        public string Foto
        {
            get { return foto; }
            set { SetProperty(ref foto, value); }
        }

        private int edad;

        public int Edad
        {
            get { return edad; }
            set { SetProperty(ref edad, value); }
        }
        private string genero;

        public string Genero
        {
            get { return genero; }
            set { SetProperty(ref genero, value); }
        }
        private string telefono;

        public string Telefono
        {
            get { return telefono; }
            set { SetProperty(ref telefono, value); }
        }



    }
}