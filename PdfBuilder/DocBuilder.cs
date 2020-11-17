using System;
using System.IO;
using System.Collections.Generic;
using iText.License;
using iText.IO.Image;
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

using DemoObjects;

namespace PdfBuilder
{
    public class DocBuilder
    {
        //
        public DocBuilder()
        {
            LicenseKey.LoadLicenseFile("itextkey1605557042113_0.xml");
        }

        public byte[] Build(PdfData Data)
        {
            byte[] bits;

            using (ByteArrayOutputStream baos = new ByteArrayOutputStream())
            {
                using (FileStream colorProfileFile = new FileStream("sRGB_CS_profile.icm", FileMode.Open))
                {
                    PdfWriter writer = new PdfWriter(baos, new WriterProperties().AddUAXmpMetadata());
                    PdfOutputIntent outputIntent = new PdfOutputIntent("Custom", "", null, "sRGB IEC61966-2.1", colorProfileFile);
                    PdfADocument pdf = new PdfADocument(writer, PdfAConformanceLevel.PDF_A_3A, outputIntent);
                    Document document = new Document(pdf, PageSize.A4.Rotate());
                    document.SetMargins(20, 20, 20, 20);
                    pdf.SetTagged();
                    pdf.GetCatalog().SetLang(new PdfString("en-US"));
                    pdf.GetCatalog().SetViewerPreferences(new PdfViewerPreferences().SetDisplayDocTitle(true));
                    PdfDocumentInfo info = pdf.GetDocumentInfo();
                    info.SetTitle("iText7 PDF/A-3 example");
                    //Embed fonts
                    PdfFont font = PdfFontFactory.CreateFont("OpenSans-Regular.ttf", true);

                    Div divTop = new Div();
                    Paragraph title = new Paragraph(Data.Title).SetFont(font).SetFontSize(16).SetTextAlignment(TextAlignment.CENTER);
                    divTop.Add(title);
                    string intro = $"Hello { Data.Name }!";
                    Paragraph pintro = new Paragraph(intro).SetFont(font).SetFontSize(12);
                    divTop.Add(pintro);
                    Paragraph paragraph = new Paragraph(Data.Paragraph).SetFont(font).SetFontSize(10);
                    divTop.Add(paragraph);

                    document.Add(divTop);


                    //PDF/UA: Set alt text
                    // put the image in a paragraph. a paragraph is "block". not putting the 
                    //  image in a block, throws
                    //  "Possibly inappropriate use of a Figure structure element" warning
                    Image butterfly = new Image(ImageDataFactory.Create("butterfly.jpg"));
                    butterfly.GetAccessibilityProperties().SetAlternateDescription("Butterfly");
                    Div divImage = new Div();
                    Paragraph imageParagraph = new Paragraph();
                    imageParagraph.Add(butterfly);
                    divImage.Add(imageParagraph);

                    document.Add(divImage);

                    // table
                    Div divTable = new Div();
                    Table table = new Table(UnitValue.CreatePercentArray(3)).UseAllAvailableWidth();
                    foreach(List<int> row in Data.Data)
                    {
                        foreach(int val in row)
                        {
                            table.AddCell(new Cell().Add(new Paragraph(val.ToString()).SetFont(font).SetFontSize(10)));
                        }
                    }

                    divTable.Add(table);
                    document.Add(divTable);
                    //Close document
                    document.Close();
                    bits = baos.ToArray();
                }
            }

            return bits;
        }
    }
}


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
