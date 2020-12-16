using ProjetInfo.dal.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo
{
    public class MockRepo
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

        public IEnumerable<Document> documentRepo = new List<Document>
        {
            new Document{id = new Guid("a3b32384-e6f9-4f9c-960a-9e758eb512b0"), universityId = new Guid("CB9CFBAF-E1EF-440B-0873-08D88262FA8D"), institutionId = null, name = "SQL.docx", 
                contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document", description = "description", uploadedOn = DateTime.Now, 
                uploadedBy = "Ray", isDeleted = false},

            new Document{id = new Guid("058cce6e-7685-4083-8f2a-6f9cbbc9c1d3"), universityId = new Guid("CB9CFBAF-E1EF-440B-0873-08D88262FA8D"), institutionId = null, name = "SQL_true.docx",
                contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document", description = "description", uploadedOn = DateTime.Now,
                uploadedBy = "Ray", isDeleted = true},

            new Document{id = new Guid("e7652f36-6160-4d9c-a495-565d9c50db38"), universityId = new Guid("CB9CFBAF-E1EF-440B-0873-08D88262FA8D"), institutionId = null, name = "SQL.docx",
                contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document", description = "description", uploadedOn = DateTime.Now,
                uploadedBy = "Ray", isDeleted = false},

            new Document{id = new Guid("a36202fe-0e69-4e16-b892-ec8b78a0439a"), universityId = new Guid("CB9CFBAF-E1EF-440B-0873-08D88262FA8D"), institutionId = null, name = "SQL.docx",
                contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document", description = "description", uploadedOn = DateTime.Now,
                uploadedBy = "Ray", isDeleted = false}
        };

    }
}
