using System;
using System.IO;
using iText.License;
using iText.IO.Source;
using iText.IO.Util;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Filespec;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Pdfa;

namespace PdfBuilder
{
    public class DocBuilder
    {
        //
        public DocBuilder()
        {
            LicenseKey.LoadLicenseFile("itextkey1605557042113_0.xml");
        }

        public byte[] Build(string someText)
        {
            byte[] bits;

            using (ByteArrayOutputStream baos = new ByteArrayOutputStream())
            {
                //using (MemoryStream stream = new MemoryStream())
                //{
                using (FileStream colorProfileFile = new FileStream("sRGB_CS_profile.icm", FileMode.Open))
                {
                    //PdfADocument pdf = new PdfADocument(new PdfWriter(stream), PdfAConformanceLevel.PDF_A_3A )

                    //PdfDictionary dictionary = new PdfDictionary();
                    //PdfWriter writer = new PdfWriter(baos);
                    PdfADocument pdf = new PdfADocument(new PdfWriter(baos), PdfAConformanceLevel.PDF_A_3A, new PdfOutputIntent(
                    "Custom", "", null, "sRGB IEC61966-2.1", colorProfileFile));

                    Document document = new Document(pdf, PageSize.A4.Rotate());
                    document.SetMargins(20, 20, 20, 20);
                    pdf.SetTagged();
                    pdf.GetCatalog().SetLang(new PdfString("en-US"));
                    pdf.GetCatalog().SetViewerPreferences(new PdfViewerPreferences().SetDisplayDocTitle(true));
                    PdfDocumentInfo info = pdf.GetDocumentInfo();
                    info.SetTitle("iText7 PDF/A-3 example");
                    //Add attachment
                    //PdfDictionary parameters = new PdfDictionary();
                    //parameters.Put(PdfName.ModDate, new PdfDate().GetPdfObject());
                    //PdfFileSpec fileSpec = PdfFileSpec.CreateEmbeddedFileSpec(pdf, File.ReadAllBytes(System.IO.Path.Combine(DATA
                    //    )), "united_states.csv", "united_states.csv", new PdfName("text/csv"), parameters, PdfName.Data);
                    //fileSpec.Put(new PdfName("AFRelationship"), new PdfName("Data"));
                    //pdf.AddFileAttachment("united_states.csv", fileSpec);
                    //PdfArray array = new PdfArray();
                    //array.Add(fileSpec.GetPdfObject().GetIndirectReference());
                    //pdf.GetCatalog().Put(new PdfName("AF"), array);
                    //Embed fonts
                    PdfFont font = PdfFontFactory.CreateFont("OpenSans-Regular.ttf", true);
                    //PdfFont bold = PdfFontFactory.CreateFont(BOLD_FONT, true);

                    // Create content
                    //Table table = new Table(UnitValue.CreatePercentArray(new float[] { 4, 1, 3, 4, 3, 3, 3, 3, 1 }))
                    //    .UseAllAvailableWidth();
                    //using (StreamReader sr = File.OpenText(DATA))
                    //{
                    //    String line = sr.ReadLine();
                    //    Process(table, line, bold, true);
                    //    while ((line = sr.ReadLine()) != null)
                    //    {
                    //        Process(table, line, font, false);
                    //    }
                    //}

                    //.Add(table);
                    //Close document

                    Paragraph p = new Paragraph(someText).SetFont(font).SetFontSize(10);
                    document.Add(p);
                    document.Close();
                    bits = baos.ToArray();
                }

                //}
            }

            return bits;
        }
    }
}
