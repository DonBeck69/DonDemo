using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PdfBuilder;
using DemoObjects;

namespace DemoDocFunction
{
    public static class DocFunction
    {
        [FunctionName("DocFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            DocBuilder docBuilder = new DocBuilder();
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            PdfData pdfData = JsonConvert.DeserializeObject<PdfData>(requestBody);
            byte[] bits = await Task.Run(() => docBuilder.Build(pdfData));


            return new FileContentResult(bits, "application/pdf");
        }
    }
}
