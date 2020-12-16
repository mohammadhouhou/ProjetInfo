using NUnit.Framework;
using ProjetInfo;
using ProjetInfo.bll.Services.DocumentServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnitTestProjetInfo
{
    [TestFixture]
    class DocumentTest
    {
        private MockRepo _repo = new MockRepo();
     
        [Test]
        public void isDeleted_true_return()
        {
            MockDocumentService _service = new MockDocumentService(_repo);
            var docNull = _service.GetDocumentById(new Guid("058cce6e-7685-4083-8f2a-6f9cbbc9c1d3"));
            var docNotNull = _service.GetDocumentById(new Guid("a3b32384-e6f9-4f9c-960a-9e758eb512b0"));
            Assert.IsNull(docNull);
            Assert.IsNotNull(docNotNull);
        }
    }
}
