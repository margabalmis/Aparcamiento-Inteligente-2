using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aparcamiento_Inteligente_2.servicios
{
    class FaceAPI
    {
        const string SUBSCRIPTION_KEY = "fb99eeb905f441338b3ed4da2172a25f";
        const string ENDPOINT = "https://faceaparcamiento.cognitiveservices.azure.com/";
        const string URL = ENDPOINT + "face/v1.0/detect";
    }
}