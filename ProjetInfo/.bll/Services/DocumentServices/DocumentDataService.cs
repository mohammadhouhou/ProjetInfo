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
    public class DocumentDataService : IDocumentDataService
    {
        private readonly DocumentDataContext _context;
        public DocumentDataService(DocumentDataContext context)
        {
            _context = context;
        }

        public void AddDocumentData(IFormFile file, Guid DocumentID)
        {

            DocumentData DocData = new DocumentData()
            {
                documentID = DocumentID
            };

            using (var target = new MemoryStream())
            {
                file.CopyTo(target);
                DocData.fileData = target.ToArray();
            }

            _context.DocumentDatas.Add(DocData);
            _context.SaveChanges();
        }

        public DocumentData GetDataById(Guid id)
        {
            return _context.DocumentDatas.Where(b => b.documentID == id).FirstOrDefault();
        }
        public void UpdateDocumentData()
        {
            _context.SaveChanges();
        }
    }
}
