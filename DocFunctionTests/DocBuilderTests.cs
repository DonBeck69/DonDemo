using Microsoft.VisualStudio.TestTools.UnitTesting;
using PdfBuilder;
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
            byte[] bits = docBuilder.Build("Hello World!");
            File.WriteAllBytes("test.pdf", bits);
            Assert.IsTrue(bits.Length > 0);
        }
    }
}