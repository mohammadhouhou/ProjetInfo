using Microsoft.AspNetCore.Http;
using ProjetInfo.dal;
using ProjetInfo.dal.entities;
using System;
using System.Collections.Generic;
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
        public void AddDocument(IFormFile fileForm)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Document> GetDocument()
        {
            throw new NotImplementedException();
        }

        public Document GetDocumentById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateDocument(Document NEWFile)
        {
            throw new NotImplementedException();
        }
    }
}
