using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aparcamiento_Inteligente_2.modelo
{
    class Marcas : ObservableObject
    {
        private int id_marcas;

        public int Id_marcas
        {
            get { return id_marcas; }
            set { SetProperty(ref id_marcas, value); }
        }

        private string marca;

        public string Marca
        {
            get { return marca; }
            set { SetProperty(ref marca, value); }
        }
    }

}