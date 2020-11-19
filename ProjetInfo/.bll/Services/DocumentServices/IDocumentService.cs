using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.bll.Services.DocumentServices
{
    public interface IDocumentService
    {
        void AddDocument(IFormFile form);
        IEnumerable<IFormFile> GetDocuments();
        IFormFile GetDocumentById(Guid id); //Ienum?
        void UpdateDocument(IFormFile NEWfile);
    }
}
