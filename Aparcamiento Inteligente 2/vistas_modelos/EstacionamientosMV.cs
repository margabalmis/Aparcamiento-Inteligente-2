using Aparcamiento_Inteligente_2.modelo;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aparcamiento_Inteligente_2.vistas_modelos
{
    class EstacionamientosMV : ObservableRecipient
    {


        public EstacionamientosMV() 
        {
        
        }

        private ObservableCollection<Estacionamiento> estacionamientos;

        public ObservableCollection<Estacionamiento> Estacionamientos
        {

            get
            { return estacionamientos; }
            set { SetProperty(ref estacionamientos, value); }
        }

    }
}
