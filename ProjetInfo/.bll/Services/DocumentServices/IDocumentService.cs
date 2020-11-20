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
        string AddDocument(IFormFile form, Guid? institutionId, Guid universityId, string description);
        Document GetDocumentById(Guid id);
        void UpdateDocument();
    }
}
