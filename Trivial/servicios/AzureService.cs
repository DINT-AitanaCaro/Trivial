using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivial.servicios
{
    class AzureService
    {
        public static string SubirImagen(String url)
        {
            string cadenaConexion = "DefaultEndpointsProtocol=https;AccountName=trivialaitana;AccountKey=oYWKgFKSwIFfaDh08sn6xL0nla/Xc82w36TtRCTkeBgVZdrX7Qlnk9CDbdxzfI3LW4i4pis1IDB0+ASto5L3zA==;EndpointSuffix=core.windows.net"; //La obtenemos en el portal de Azure, asociada a la cuenta de almacenamiento
            string nombreContenedorBlobs = "trivial"; //El nombre que le hayamos dado a nuestro contenedor de blobs en el portal de Azure
            string rutaImagen = url;

            //Obtenemos el cliente del contenedor
            var clienteBlobService = new BlobServiceClient(cadenaConexion);
            var clienteContenedor = clienteBlobService.GetBlobContainerClient(nombreContenedorBlobs);

            //Leemos la imagen y la subimos al contenedor
            Stream streamImagen;
            try
            {
                streamImagen = File.OpenRead(rutaImagen);
            }
            catch (FileNotFoundException) { streamImagen = File.OpenRead("assets/image_not_found.png");  }
            string nombreImagen = Path.GetFileName(rutaImagen);
            try
            {
                clienteContenedor.UploadBlob(nombreImagen, streamImagen);
            }catch(Azure.RequestFailedException e)
            {

            }
            //Una vez subida, obtenemos la URL para referenciarla
            var clienteBlobImagen = clienteContenedor.GetBlobClient(nombreImagen);
            string urlImagen = clienteBlobImagen.Uri.AbsoluteUri;
            return urlImagen;
        }
    }
}
