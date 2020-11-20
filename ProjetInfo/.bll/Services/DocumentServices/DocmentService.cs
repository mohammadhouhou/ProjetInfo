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
        public IEnumerable<Document> GetDocument()
        {
            return _context.Documents.ToList();
        }

        public Document GetDocumentById(Guid id)
        {
            return _context.Documents.Find(id);
        }
        public void AddDocument(IFormFile form)
        {
            Document Doc = new Document()
            {
                contentType = form.ContentType,
                description = "PlaceHolder",
                isDeleted = false,
                name = form.FileName,
                institutionId = null,
                universityId = Guid.NewGuid(),
                uploadedBy = Environment.UserName,
                uploadedOn = DateTime.Now
            };
            using (var target = new MemoryStream())
            {
                form.CopyTo(target);
                Doc.fileData = target.ToArray();
            }
            _context.Documents.Add(Doc);
            _context.SaveChanges();
        }
        public void UpdateDocument(Document NEWfile)
        {
            throw new NotImplementedException();
        }

    }
}