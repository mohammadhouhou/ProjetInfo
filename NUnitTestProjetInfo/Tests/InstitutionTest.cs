using NUnit.Framework;
using ProjetInfo;
using ProjetInfo.bll.Services.InstitutionServices;
using ProjetInfo.dal.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnitTestProjetInfo
{
    [TestFixture]
    class InstitutionTest
    {
        private MockRepo _repo = new MockRepo();

        [Test]
        public void get_All_Inst()
        {
            MockInstitutionService _service = new MockInstitutionService(_repo);
            var inst = _service.GetInstitutions().Count();
            Assert.AreEqual(7, inst);
        }
        [Test]
        public void get_Child_Inst()
        {
            MockInstitutionService _service = new MockInstitutionService(_repo);
            var child = _service.GetInstitutionChildren(new Guid("957C95EB-78DB-4826-C474-08D88263A8C6")).Count();
            Assert.AreEqual(2, child);
        }
    }
}
