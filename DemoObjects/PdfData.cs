using System;
using System.Collections.Generic;

namespace DemoObjects
{
    public class PdfData
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Paragraph { get; set; }
        public List<List<int>> Data { get; set; }
    }
}
