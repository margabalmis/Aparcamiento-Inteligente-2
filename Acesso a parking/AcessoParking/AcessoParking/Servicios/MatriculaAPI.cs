using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace AcessoParking.Servicios
{
    static public class MatriculaAPI
    {
        /// <summary>
        /// Extrae la matricula de una imagen que contiene un coche mediante con una IA alojada en Azure.
        /// Los datos se pasan mediante una API. 
        /// </summary>
        /// <param name="url">Url de la imagen a analizar</param>
        /// <returns>cadena con la matricula del véhículo</returns>
        public static string GetMatriculaCoche(string url)
        {
            var cliente = new RestClient("https://matriculaapi.cognitiveservices.azure.com/vision/v3.2/read");
            var request = new RestRequest("analyze", Method.POST);

            request.AddHeader("Ocp-Apim-Subscription-Key", Properties.Settings.Default.SubscriptionKeyMatricula);
            request.AddHeader("Content-Type", "application/json");

            request.AddJsonBody("{\u0022url\u0022:" + "\u0022" + url + "\u0022}");

            var response = cliente.Execute(request);

            string result = response.Headers[0].ToString().Split('=')[1];

            Thread.Sleep(2000);

            cliente = new RestClient(result);
            request = new RestRequest(Method.GET);
            request.AddHeader("Ocp-Apim-Subscription-Key", Properties.Settings.Default.SubscriptionKeyMatricula);

            response = cliente.Execute(request);

            JToken jt = JToken.Parse(response.Content).SelectToken("analyzeResult").SelectToken("readResults").First.SelectToken("lines").First.SelectToken("text");

            return jt.ToString();
        }

        /// <summary>
        /// Extrae la matricula de una imagen que contiene una moto mediante con una IA alojada en Azure.
        /// Los datos se pasan mediante una API. 
        /// </summary>
        /// <param name="url">Url de la imagen a analizar</param>
        /// <returns>cadena con la matricula del véhículo</returns>
        public static string GetMatriculaMoto(string url)
        {
            var cliente = new RestClient("https://matriculaapi.cognitiveservices.azure.com/vision/v3.2/read");
            var request = new RestRequest("analyze", Method.POST);

            request.AddHeader("Ocp-Apim-Subscription-Key", Properties.Settings.Default.SubscriptionKeyMatricula);
            request.AddHeader("Content-Type", "application/json");

            request.AddJsonBody("{\u0022url\u0022:" + "\u0022" + url + "\u0022}");

            var response = cliente.Execute(request);

            string result = response.Headers[0].ToString().Split('=')[1];

            Thread.Sleep(2500);

            cliente = new RestClient(result);
            request = new RestRequest(Method.GET);
            request.AddHeader("Ocp-Apim-Subscription-Key", Properties.Settings.Default.SubscriptionKeyMatricula);

            response = cliente.Execute(request);

            JToken jt = JToken.Parse(response.Content);
            string matricula = jt.SelectToken("analyzeResult").SelectToken("readResults").First.SelectToken("lines").First.SelectToken("text").ToString();
            matricula += jt.SelectToken("analyzeResult").SelectToken("readResults").First.SelectToken("lines").First.Next.SelectToken("text").ToString();

            return matricula;
        }
    }
}
