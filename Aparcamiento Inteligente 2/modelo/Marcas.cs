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
        private int id_marca;

        public int Id_marcas
        {
            get { return id_marca; }
            set { SetProperty(ref id_marca, value); }
        }

        private string marca;

        public string Marca
        {
            get { return marca; }
            set { SetProperty(ref marca, value); }
        }

        public Marcas(int id_marcas, string marca)
        {
            Id_marcas = id_marcas;
            Marca = marca;
        }
    }

}