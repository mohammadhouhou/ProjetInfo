using Microsoft.AspNetCore.Http;
using ProjetInfo.bll.Dtos.DocumentDtos;
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
            return _context.Documents.Where(document => document.id == id).Where(document => document.isDeleted == false).FirstOrDefault();
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
        public void UpdateDocument(Guid id, DocumentUpdateDto NEWDoc)
        {
            Document OLDDoc = _context.Documents.Find(id);
            OLDDoc.description = NEWDoc.description;
            OLDDoc.institutionId = NEWDoc.institutionId;
            OLDDoc.isDeleted = NEWDoc.isDeleted;
            OLDDoc.name = NEWDoc.name;
            OLDDoc.universityId = NEWDoc.universityId;
            OLDDoc.uploadedBy = System.Environment.UserName;
            _context.SaveChanges();
        }

        public void UpdateDocumentData(Guid id, string ContentType, string FileName)
        {
            Document toUpdate = _context.Documents.Find(id);
            toUpdate.contentType = ContentType;
            toUpdate.name = FileName + Path.GetExtension(toUpdate.name).ToString();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}