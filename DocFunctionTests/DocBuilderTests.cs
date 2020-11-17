using Microsoft.VisualStudio.TestTools.UnitTesting;
using PdfBuilder;
using DemoObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfBuilder.Tests
{
    [TestClass()]
    public class DocBuilderTests
    {
        [TestMethod()]
        public void BuildTest()
        {
            DocBuilder docBuilder = new DocBuilder();
            List<int> row1 = new List<int>() { 1, 2, 3 };
            List<int> row2 = new List<int>() { 1, 2, 3 };
            List<List<int>> data = new List<List<int>>();
            data.Add(row1);
            data.Add(row2);
            PdfData pdfData = new PdfData()
            {
                Title = "Test title",
                Name = "Test",
                Paragraph = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Data = data
            };

            byte[] bits = docBuilder.Build(pdfData);
            File.WriteAllBytes("test.pdf", bits);
            Assert.IsTrue(bits.Length > 0);
        }
    }
}