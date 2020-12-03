using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using PdfBuilder;
using DemoObjects;

namespace DemoDocFunction
{
    public static class DocFunction
    {
        [FunctionName("DocFunction")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                //log.LogInformation("C# HTTP trigger function processed a request.");
                DocBuilder docBuilder = new DocBuilder();
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                PdfData pdfData = JsonConvert.DeserializeObject<PdfData>(requestBody);
                byte[] bits = await Task.Run(() => docBuilder.Build(pdfData));

                HttpResponseMessage httpResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(bits)
                };


                httpResponse.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");

                return httpResponse;
            }
            catch(Exception ex)
            {
                HttpResponseMessage resp = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "PDF Function Error"
                };
                throw new HttpResponseException(resp);
            }

        }
    }
}
