using Microsoft.AspNetCore.Http;
using ProjetInfo.dal;
using ProjetInfo.dal.entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.bll.Services.DocumentServices
{
    public class DocumentService : IDocumentService
    {
        private readonly DocumentContext _context;

        public DocumentService(DocumentContext context)
        {
            _context = context;
        }
        public Document GetDocumentById(Guid id)
        {
            return _context.Documents.Find(id);
        }
        public string AddDocument(IFormFile form, Guid? institutionId, Guid universityId, string description)
        {
            Document Doc = new Document()
            {
                contentType = form.ContentType,
                description = description,
                isDeleted = false,
                name = form.FileName,
                institutionId = institutionId,
                universityId = universityId,
                uploadedBy = Environment.UserName,
                uploadedOn = DateTime.Now
            };
            _context.Documents.Add(Doc);
            _context.SaveChanges();
           

            return Doc.id.ToString();
        }
        public void UpdateDocument()
        {
            _context.SaveChanges();
        }

    }
}