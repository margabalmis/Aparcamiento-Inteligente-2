using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aparcamiento_Inteligente_2.servicios
{
    static class Nube
    {

        private static readonly string CADENA_CONEXION = "DefaultEndpointsProtocol=https;AccountName=storageaparcamiento;AccountKey=ubR0guLy+WGLMzsDrzAPlcSNcR51PLNEn/LUTQcCmKCf/aZ5JcgpsFVjSKc3+XVgCLT4pVtUHYk4073eF0scZg==;EndpointSuffix=core.windows.net"; //La obtenemos en el portal de Azure, asociada a la cuenta de almacenamiento
        private static readonly string NOMBRE_BLOB = "blobaparcamiento"; //El nombre que le hayamos dado a nuestro contenedor de blobs en el portal de Azure


        /// <summary>
        /// Sube la imagen proporcionada a un BlobStorage de Azure
        /// </summary>
        /// <param name="path">Ruta de la imagen a subir</param>
        /// <returns>Url de la imagen subida</returns>
        public static string SubirImagen(string path)
        {
            //Cliente del contenedor
            BlobServiceClient clienteBlobService = new BlobServiceClient(CADENA_CONEXION);
            BlobContainerClient clienteContenedor = clienteBlobService.GetBlobContainerClient(NOMBRE_BLOB);

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