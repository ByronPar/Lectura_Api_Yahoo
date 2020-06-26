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
    public class LatitudLon
    {
        private string cURL = "https://weather-ydn-yql.media.yahoo.com/forecastrss";
        private string cAppID = "MNpgYe4q";
        private string cConsumerKey = "dj0yJmk9WlZOUlh4Q3Q1NmhhJmQ9WVdrOVRVNXdaMWxsTkhFbWNHbzlNQS0tJnM9Y29uc3VtZXJzZWNyZXQmc3Y9MCZ4PTMy";
        private string cConsumerSecret = "fb8401f4bfc43dc78202ad8628e65e53668548ca";
        private string cOAuthVersion = "1.0";
        private string cOAuthSignMethod = "HMAC-SHA1";
        private string cLatID = "";
        private string cLonID = "";
        private string cUnitID = "u=c";           // Metric units
        private string cFormat = "json";
        public string lat = "";
        public string lon = "";
        public string temperatura = "";
        public string humedad = "";
        public string presion = "";
        public string direccion = "";
        public string velocidad = "";
        public string ciudad = "";
        public string pais = "";


        public LatitudLon(string lat, string lon)
        {
            this.cLonID = "lon=" + lon;
            this.cLatID = "lat=" + lat;
            this.Datos();
        }

        public LatitudLon()
        {
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
             "{1}&" +
             "{2}&" +
             "oauth_consumer_key={3}&" +
             "oauth_nonce={4}&" +
             "oauth_signature_method={5}&" +
             "oauth_timestamp={6}&" +
             "oauth_version={7}&" +
             "{8}",
             cFormat,
             cLatID,
             cLonID,
             cConsumerKey,
             lNonce,
             cOAuthSignMethod,
             lTimes,
             cOAuthVersion,
             cUnitID
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


        public void Datos()
        {

            string lURL = cURL + "?" + cLatID + "&" + cLonID + "&" + cUnitID + "&format=" + cFormat;
            var lClt = new WebClient();
            lClt.Headers.Set("Content-Type", "application/" + cFormat);
            lClt.Headers.Add("X-Yahoo-App-Id", cAppID);
            lClt.Headers.Add("Authorization", _get_auth());
            Console.WriteLine("Downloading Yahoo weather report . . .");
            byte[] lDataBuffer = lClt.DownloadData(lURL);
            string lOut = Encoding.ASCII.GetString(lDataBuffer);
            dynamic data = JsonConvert.DeserializeObject(lOut);
            this.temperatura = data.current_observation.condition.temperature;
            this.humedad = data.current_observation.atmosphere.humidity;
            this.presion = data.current_observation.atmosphere.pressure;
            this.direccion = data.current_observation.wind.direction;
            this.velocidad = data.current_observation.wind.speed;
            this.ciudad = data.location.city;
            this.pais = data.location.country;
        }

    }
}
