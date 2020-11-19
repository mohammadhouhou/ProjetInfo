using Microsoft.AspNetCore.Http;
using ProjetInfo.dal;
using ProjetInfo.dal.entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace ProjetInfo.bll.Services.DocumentServices
{
    public class DocumentService : IDocumentService
    {
        private readonly DocumentContext _context;

        public DocumentService(DocumentContext context)
        {
            _context = context;
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
                uploadedBy = "Anonymous",
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

        public IEnumerable<IFormFile> GetDocuments()
        {
            throw new NotImplementedException();
        }

        public IFormFile GetDocumentById(Guid id)
        {
            Document Doc = _context.Documents.Find(id);

            var stream = new MemoryStream(Doc.fileData);
            IFormFile DocumentToReturn = new FormFile(stream, 0, Doc.fileData.Length, "DocumentToReturn", Doc.name);
            return DocumentToReturn;
        }

        public void UpdateDocument(IFormFile NEWfile)
        {
            throw new NotImplementedException();
        }
    }
}
