using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Business.HttpServices
{
    public class ClientServices
    {
        public async Task<HttpWebResponse> ExecuteAPIRequestByGet(string request, string Method, string ContentType)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest httpRequest = WebRequest.Create(request) as HttpWebRequest;
            httpRequest.Method = Method;
            httpRequest.ContentType = ContentType;
            HttpWebResponse httResponse = await httpRequest.GetResponseAsync() as HttpWebResponse;

            return httResponse;
        }
        public async Task<string> ExecuteRequestByGet(string request, string Method, string ContentType)
        {
            List<string> errors = new List<string>();

            try
            {
                HttpWebResponse response = await ExecuteAPIRequestByGet(request, Method, ContentType);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        JArray jsonArray = JArray.Parse(reader.ReadToEnd());

                        return (jsonArray.ToString());
                    }
                }
                else
                {
                    string errorMessage = "Error al conectarse al servicio api   - Response.StatusCode: " + response.StatusCode;
                    errors.Add("Error al conectarse al servicio api   - Response.StatusCode: " + response.StatusCode);
                    return errorMessage;
                }
            }
            catch (Exception)
            {
                string errorMessage = "Error al conectarse al servicio Api ";
                errors.Add("Error al conectarse al servicio Api ");
                return errorMessage;
            }
        }

    }
}
