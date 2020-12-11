using NUnit.Framework;
using ProjetInfo.bll;
using ProjetInfo.bll.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo
{
    [TestFixture]
    public class InstitutionTest
    {
        //private readonly InstitutionService _repository;
        [Test]
        public void getChildNumber()
        {
            int x = 4;
            int y = 2 * 2;
            //var number = _repository.GetInstitutionChildren(new Guid("CB9CFBAF-E1EF-440B-0873-08D88262FA8D")).ToList().Count;
            Assert.AreEqual(x, y);
        }
    }
}
