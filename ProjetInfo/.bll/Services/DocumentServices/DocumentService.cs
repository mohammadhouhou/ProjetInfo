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

        public void AddFile(IFormFile form)
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

        public IEnumerable<IFormFile> GetFile()
        {
            throw new NotImplementedException();
        }

        public IFormFile GetFileById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateDocument(IFormFile NEWfile)
        {
            throw new NotImplementedException();
        }
    }
}
