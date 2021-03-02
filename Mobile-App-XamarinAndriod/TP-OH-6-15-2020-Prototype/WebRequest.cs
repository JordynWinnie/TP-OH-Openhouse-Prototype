using System.Net.Http;

namespace TP_OH_6_15_2020_Prototype
{
    public class WebRequest
    {
        public static readonly HttpClient HttpClient;

        static WebRequest()
        {
            HttpClient = new HttpClient();
        }
    }
}