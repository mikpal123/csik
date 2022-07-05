using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace csik
{
    public enum httpVerbs
    {
        GET,
        POST,
        PUT,
        DELETE,
    }

    class RestCient
    {
        public string webAdress { get; set; }
        public string endPoint { get; set; }
        public httpVerbs httpMethod { get; set; }

        public RestCient()
        {
            endPoint = String.Empty;
            webAdress = "https://steamcommunity.com/market/priceoverview/?currency=6&country=DE&appid=730&market_hash_name=";
            httpMethod = httpVerbs.GET;
        }

        public string makeRequest()
        {
            string strResponseValue = string.Empty;
            string finalWebAdress = webAdress + endPoint;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(finalWebAdress);

            request.Method = httpMethod.ToString();

            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)request.GetResponse();


                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strResponseValue = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";
            }
            finally
            {
                if (response != null)
                {
                    ((IDisposable)response).Dispose();
                }
            }

            return strResponseValue;
        }

    }
}
