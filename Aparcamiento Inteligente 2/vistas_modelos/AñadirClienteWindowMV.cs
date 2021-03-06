using Aparcamiento_Inteligente_2.modelo;
using Aparcamiento_Inteligente_2.servicios;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aparcamiento_Inteligente_2.vistas_modelos
{
    class AñadirClienteWindowMV : ObservableRecipient
    {
        //Servicios
        private readonly DialogosNavegacion servicioDialogos;

        public AñadirClienteWindowMV()
        {
            servicioDialogos = new DialogosNavegacion();
            ImagenCommand = new RelayCommand(AbrirImagen);
        }

        private Cliente nuevoCliente;

        public Cliente NuevoCliente
        {
            get { return nuevoCliente; }
            set { SetProperty(ref nuevoCliente, value); }
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


        private string telefono;

        public string Telefono
        {
            get { return telefono; }
            set { SetProperty(ref telefono, value); }
        }
        public RelayCommand ImagenCommand { get; }

        private void AbrirImagen()
        {
            Foto = servicioDialogos.DialogoAbrirImagen();

        }
        public void AñadirCliente()
        {
            if (Nombre != null && Documento != null && Foto != null && Telefono != null)
            {
                string blobURL = Nube.SubirImagen(Foto);
                var ageGender = FaceAPI.GetAgeGender(blobURL);
                DBServicio db = new DBServicio(Properties.Settings.Default.Conexion);
                db.ClienteInsertOne(new Cliente(Nombre, Documento, blobURL, ageGender.age, ageGender.gender, Telefono));
            }

        }





    }
}