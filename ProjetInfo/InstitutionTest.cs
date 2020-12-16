using NUnit.Framework;
using ProjetInfo.bll;
using ProjetInfo.bll.Services;
using ProjetInfo.bll.Services.InstitutionServices;
using ProjetInfo.dal;
using ProjetInfo.dal.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo
{
    [TestFixture]
    public class InstitutionTest
    {
        public IEnumerable<Institution> institutionRepo = new List<Institution>
       {
           new Institution{id = new Guid("CB9CFBAF-E1EF-440B-0873-08D88262FA8D"), code = "USJ", name = "Universite Saint Joseph",
               type = institutionType.universite, adressId= 0, contactInfoId= 0, parentId = null},

           new Institution{id = new Guid("60AE6A2D-72AD-46DD-C473-08D88263A8C6"), code = "CSM", name = "Campus des sciences medicales",
               type = institutionType.campus, adressId= 0, contactInfoId= 0, parentId = new Guid("CB9CFBAF-E1EF-440B-0873-08D88262FA8D")},

           new Institution{id = new Guid("957C95EB-78DB-4826-C474-08D88263A8C6"), code = "CST", name = "Campus de sciences et de technologie ",
               type = institutionType.campus, adressId= 0, contactInfoId= 0, parentId = new Guid("CB9CFBAF-E1EF-440B-0873-08D88262FA8D")},

           new Institution{id = new Guid("34DD5FDA-91F9-4127-7C66-08D884EFB42C"), code = "CSS", name = "Campus des sciences social",
               type = institutionType.campus, adressId= 0, contactInfoId= 0, parentId = new Guid("CB9CFBAF-E1EF-440B-0873-08D88262FA8D")},

           new Institution{id = new Guid("14C1460D-FD8D-43E0-469A-08D8865C5E13"), code = "CSH", name = "Campus des sciences humaine",
               type = institutionType.campus, adressId= 0, contactInfoId= 0, parentId = new Guid("CB9CFBAF-E1EF-440B-0873-08D88262FA8D")},

           new Institution{id = new Guid("2E5E1EDC-CE53-4BD8-2818-08D89DE0E0BB"), code = "INCI", name = "Institut National de communication et d'informatique",
               type = institutionType.faculte, adressId= 0, contactInfoId= 0, parentId = new Guid("957C95EB-78DB-4826-C474-08D88263A8C6")},

           new Institution{id = new Guid("af17afcf-8ef5-47cd-b6fa-0171100b624a"), code = "ESIB", name = "Ecole superieur d'ingenieurie de Beirut",
               type = institutionType.universite, adressId= 0, contactInfoId= 0, parentId = new Guid("957C95EB-78DB-4826-C474-08D88263A8C6")},
       };
        [TestCase]
        public void getChildNumber()
        {
/*            IEnumerable<Document> documents;
            IEnumerable<Institution> institutions;
            MockRepo _repo = new MockRepo(institutions, documents);
            MockInstitutionService _service = new MockInstitutionService(_repo);*/
            var number = institutionRepo.Count();
            Assert.AreEqual(7, number);
        }
    }
}
