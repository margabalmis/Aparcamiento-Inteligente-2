using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoParking.Servicios
{
    static class Nube
    {

        public static string SubirImagen(string path)
        {
            //Cliente del contenedor
            BlobServiceClient clienteBlobService = new BlobServiceClient(Properties.Settings.Default.Conexion_Azure);
            BlobContainerClient clienteContenedor = clienteBlobService.GetBlobContainerClient(Properties.Settings.Default.Blob);

            //Leemos la imagen y la subimos al contenedor
            Stream streamImagen = File.OpenRead(path);
            string nombreImagen = Path.GetFileName(path);
            _ = clienteContenedor.DeleteBlobIfExists(nombreImagen);
            _ = clienteContenedor.UploadBlob(nombreImagen, streamImagen);

            //Una vez subida, obtenemos la URL para referenciarla
            BlobClient clienteBlobImagen = clienteContenedor.GetBlobClient(nombreImagen);

            return clienteBlobImagen.Uri.AbsoluteUri;
        }
    }
}