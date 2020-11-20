using Microsoft.AspNetCore.Http;
using ProjetInfo.dal.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.bll.Services.DocumentServices
{
    public interface IDocumentService
    {
        void AddDocument(IFormFile fileForm);
        IEnumerable<Document> GetDocument();
        Document GetDocumentById(Guid id);
        void UpdateDocument(Document NEWFile);
    }
}
