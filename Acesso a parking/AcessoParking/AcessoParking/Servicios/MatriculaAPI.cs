using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace AcessoParking.servicios
{
    class MatriculaAPI
    {
        static string subscriptionKey = "a822ecfd08694897a7ba61a94af9fb0c";
        public static string GetMatriculaCoche(string url)
        {
            var cliente = new RestClient("https://matriculaapi.cognitiveservices.azure.com/vision/v3.2/read");
            var request = new RestRequest("analyze", Method.POST);

            request.AddHeader("Ocp-Apim-Subscription-Key", subscriptionKey);
            request.AddHeader("Content-Type", "application/json");

            request.AddJsonBody("{\u0022url\u0022:" + "\u0022" + url + "\u0022}");

            var response = cliente.Execute(request);

            string result = response.Headers[0].ToString().Split('=')[1];

            Thread.Sleep(2000);

            cliente = new RestClient(result);
            request = new RestRequest(Method.GET);
            request.AddHeader("Ocp-Apim-Subscription-Key", subscriptionKey);

            response = cliente.Execute(request);

            JToken jt = JToken.Parse(response.Content).SelectToken("analyzeResult").SelectToken("readResults").First.SelectToken("lines").First.SelectToken("text");

            return jt.ToString();
        }
        public static string GetMatriculaMoto(string url)
        {
            var cliente = new RestClient("https://matriculaapi.cognitiveservices.azure.com/vision/v3.2/read");
            var request = new RestRequest("analyze", Method.POST);

            request.AddHeader("Ocp-Apim-Subscription-Key", subscriptionKey);
            request.AddHeader("Content-Type", "application/json");

            request.AddJsonBody("{\u0022url\u0022:" + "\u0022" + url + "\u0022}");

            var response = cliente.Execute(request);

            string result = response.Headers[0].ToString().Split('=')[1];

            Thread.Sleep(2500);

            cliente = new RestClient(result);
            request = new RestRequest(Method.GET);
            request.AddHeader("Ocp-Apim-Subscription-Key", subscriptionKey);

            response = cliente.Execute(request);

            JToken jt = JToken.Parse(response.Content);
            string matricula = jt.SelectToken("analyzeResult").SelectToken("readResults").First.SelectToken("lines").First.SelectToken("text").ToString();
            matricula += jt.SelectToken("analyzeResult").SelectToken("readResults").First.SelectToken("lines").First.Next.SelectToken("text").ToString();

            return matricula;
        }
    }
}
