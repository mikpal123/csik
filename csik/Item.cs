using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace csik
{
    internal class Item
    {
        public string lowest_price { get; set; }
        public string itemName { get; set; }

        public void deleteZl()
        {
            lowest_price = lowest_price.Remove(lowest_price.Length-2);
        }


        public string makeRequest()
        {
            string strResponseValue = string.Empty;
            string finalWebAdress = "http://steamcommunity.com/market/listings/730/"+itemName+"/render?start=0&count=1&currency=1&format=json";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(finalWebAdress);

           

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
