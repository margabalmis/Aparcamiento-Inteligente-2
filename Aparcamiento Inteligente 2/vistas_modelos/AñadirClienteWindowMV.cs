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


        public AñadirClienteWindowMV()
        {
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Foto=openFileDialog.FileName;
            }
        }
        public void AñadirCliente()
        {
            string blobURL = Nube.SubirImagen(Foto);
            var ageGender = FaceAPI.GetAgeGender(blobURL);
            DBServicio db = new DBServicio();
            db.ClienteInsertOne(new Cliente(Nombre,Documento,blobURL,ageGender.age,ageGender.gender,Telefono));

        }





    }
}