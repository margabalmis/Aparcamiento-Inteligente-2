using Newtonsoft.Json.Linq;
using RestSharp;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aparcamiento_Inteligente_2.servicios
{

    static class FaceAPI
    {
        const string ENDPOINT = "https://faceaparcamiento.cognitiveservices.azure.com/";

        /// <summary>
        /// Deduce la edad de la una foto retrato, mediante una llamada a una API de Azure. 
        /// </summary>
        /// <param name="url">Url en la que se encuentra la foto</param>
        /// <returns>Devuelve una tupla con la edad y el genero de la persona en la foto</returns>
        public static (int age, string gender) GetAgeGender(string url)
        {
            var cliente = new RestClient("https://faceaparcamiento.cognitiveservices.azure.com/face/v1.0");
            var request = new RestRequest("detect", Method.POST);

            request.AddHeader("Ocp-Apim-Subscription-Key", "fb99eeb905f441338b3ed4da2172a25f");
            request.AddHeader("Content-Type", "application/json");

            request.AddParameter("returnFaceAttributes", "age,gender", ParameterType.QueryString);

            request.AddJsonBody("{\u0022url\u0022:" + "\u0022" + url + "\u0022}");//Esto se ve feo pero lo que hace es un json



            var response = cliente.Execute(request);

            JToken jt = JToken.Parse(response.Content).First.Last.First;




            return (jt.Value<int>("age"), jt.Value<string>("gender"));

        }
    }
   
}