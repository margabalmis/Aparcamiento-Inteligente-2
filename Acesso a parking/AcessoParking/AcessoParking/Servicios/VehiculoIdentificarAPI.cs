﻿using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoParking.servicios
{
    class VehiculoIdentificarAPI
    {
        static string subscriptionKey = "9a74130c56a54c57ac22bef76c1a5241";
        public static string Identificar(string url)
        {
            var cliente = new RestClient("https://vehiculoidentificarapi-prediction.cognitiveservices.azure.com/customvision/v3.0/Prediction/ea3585fc-d360-4d77-b8dc-f89b6a4f1179/classify/iterations/Identificar/url");
            var request = new RestRequest(Method.POST);

            request.AddHeader("Prediction-Key", subscriptionKey);
            request.AddHeader("Content-Type", "application/json");

            request.AddJsonBody("{\u0022url\u0022:" + "\u0022" + url + "\u0022}");

            var response = cliente.Execute(request);
            return JToken.Parse(response.Content).SelectToken("predictions").First.SelectToken("tagName").ToString();

        }
    }
}
