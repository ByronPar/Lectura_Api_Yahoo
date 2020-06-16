using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace CLIMA_PRACTICA.Models
{
    public class DataClima
    {
        private string cURL = "https://weather-ydn-yql.media.yahoo.com/forecastrss";
        private string cAppID = "MNpgYe4q";
        private string cConsumerKey = "dj0yJmk9WlZOUlh4Q3Q1NmhhJmQ9WVdrOVRVNXdaMWxsTkhFbWNHbzlNQS0tJnM9Y29uc3VtZXJzZWNyZXQmc3Y9MCZ4PTMy";
        private string cConsumerSecret = "fb8401f4bfc43dc78202ad8628e65e53668548ca";
        private string cOAuthVersion = "1.0";
        private string cOAuthSignMethod = "HMAC-SHA1";
        private string cWeatherID = "";
        private string cUnitID = "u=c";           // Metric units
        private string cFormat = "json";


        public DataClima(string woeid)
        {
            this.cWeatherID = "woeid=" + woeid;
        }

        static string _get_timestamp()
        {
            TimeSpan lTS = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64(lTS.TotalSeconds).ToString();
        }  // end _get_timestamp

        static string _get_nonce()
        {
            return Convert.ToBase64String(
             new ASCIIEncoding().GetBytes(
              DateTime.Now.Ticks.ToString()
             )
            );
        }

        string _get_auth()
        {
            string retVal;
            string lNonce = _get_nonce();
            string lTimes = _get_timestamp();
            string lCKey = string.Concat(cConsumerSecret, "&");
            string lSign = string.Format(  // note the sort order !!!
             "format={0}&" +
             "oauth_consumer_key={1}&" +
             "oauth_nonce={2}&" +
             "oauth_signature_method={3}&" +
             "oauth_timestamp={4}&" +
             "oauth_version={5}&" +
             "{6}&{7}",
             cFormat,
             cConsumerKey,
             lNonce,
             cOAuthSignMethod,
             lTimes,
             cOAuthVersion,
             cUnitID,
             cWeatherID
            );

            lSign = string.Concat(
             "GET&", Uri.EscapeDataString(cURL), "&", Uri.EscapeDataString(lSign)
            );

            using (var lHasher = new HMACSHA1(Encoding.ASCII.GetBytes(lCKey)))
            {
                lSign = Convert.ToBase64String(
                 lHasher.ComputeHash(Encoding.ASCII.GetBytes(lSign))
                );
            }  // end using

            return "OAuth " +
                   "oauth_consumer_key=\"" + cConsumerKey + "\", " +
                   "oauth_nonce=\"" + lNonce + "\", " +
                   "oauth_timestamp=\"" + lTimes + "\", " +
                   "oauth_signature_method=\"" + cOAuthSignMethod + "\", " +
                   "oauth_signature=\"" + lSign + "\", " +
                   "oauth_version=\"" + cOAuthVersion + "\"";

        }


        public String Datos()
        {

            string lURL = cURL + "?" + cWeatherID + "&" + cUnitID + "&format=" + cFormat;
            var lClt = new WebClient();
            lClt.Headers.Set("Content-Type", "application/" + cFormat);
            lClt.Headers.Add("X-Yahoo-App-Id", cAppID);
            lClt.Headers.Add("Authorization", _get_auth());
            Console.WriteLine("Downloading Yahoo weather report . . .");
            byte[] lDataBuffer = lClt.DownloadData(lURL);
            string lOut = Encoding.ASCII.GetString(lDataBuffer);
            return lOut;
        }

        public String Temperatura(string lOut) {
            dynamic data = JsonConvert.DeserializeObject(lOut);
            string temp = data.current_observation.condition.temperature;
            return temp;
        }

        public String Humedad(string lOut)
        {
            dynamic data = JsonConvert.DeserializeObject(lOut);
            string humedad = data.current_observation.atmosphere.humidity;
            return humedad;
        }

        public String Presion(string lOut)
        {
            dynamic data = JsonConvert.DeserializeObject(lOut);
            string presion= data.current_observation.atmosphere.pressure;
            return presion;
        }

        public String DireccionVi(string lOut)
        {
            dynamic data = JsonConvert.DeserializeObject(lOut);
            string direccion = data.current_observation.wind.direction;
            return direccion;
        }

        public String VelocidadVi(string lOut)
        {
            dynamic data = JsonConvert.DeserializeObject(lOut);
            string velocidad = data.current_observation.wind.speed;
            return velocidad;
        }

    }
        
    
}
