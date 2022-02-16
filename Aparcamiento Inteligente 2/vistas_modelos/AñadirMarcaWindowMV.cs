using Aparcamiento_Inteligente_2.modelo;
using Aparcamiento_Inteligente_2.servicios;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aparcamiento_Inteligente_2.vistas_modelos
{
    class AñadirMarcaWindowMV : ObservableObject
    {
        //Servicios
        DBServicio baseDatos;
 
        public AñadirMarcaWindowMV()
        {
            //Servicios
            baseDatos = new DBServicio(Properties.Settings.Default.Conexion);

        }
        private string nuevaMarca;

        public string NuevaMarca
        {
            get { return nuevaMarca; }
            set { SetProperty( ref nuevaMarca, value); }
        }

        internal void AñadirMarca()
        {
            baseDatos.MarcaInsertOne(string Marca);
        }
    }



}
