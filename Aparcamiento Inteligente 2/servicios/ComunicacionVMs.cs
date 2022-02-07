using Aparcamiento_Inteligente_2.modelo;
using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aparcamiento_Inteligente_2.servicios
{
    class ClienteSeleccionadoMessage : RequestMessage<Cliente>
    {

    }
    class VehiculoSeleccionadoMessage : RequestMessage<Vehiculo>
    {
       
    }
    class VehiculoSeleccionadoMessageDifuson : ValueChangedMessage<Vehiculo>
    {
        public VehiculoSeleccionadoMessageDifuson(Vehiculo vehiculoSeleccionado) : base(vehiculoSeleccionado) { }
    }



}
