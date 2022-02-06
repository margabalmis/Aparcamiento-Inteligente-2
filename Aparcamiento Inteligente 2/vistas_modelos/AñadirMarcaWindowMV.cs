using Aparcamiento_Inteligente_2.modelo;
using Aparcamiento_Inteligente_2.servicios;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aparcamiento_Inteligente_2.vistas_modelos
{
    class AñadirMarcaWindowMV
    {
        //Servicios
        DBServicio baseDatos;
 
        public AñadirMarcaWindowMV()
        {
            //Servicios
            baseDatos = new DBServicio();


        }
        private Marcas nuevaMarca;

        public Marcas NuevaMarca
        {
            get { return nuevaMarca; }
            set { nuevaMarca = value; }
        }

        internal void AñadirMarca()
        {
            throw new NotImplementedException();
        }
    }



}
