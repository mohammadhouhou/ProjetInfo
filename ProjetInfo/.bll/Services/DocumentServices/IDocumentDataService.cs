using Microsoft.AspNetCore.Http;
using ProjetInfo.dal.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.bll.Services.DocumentServices
{
    public interface IDocumentDataService
    {
        void AddDocumentData(IFormFile file, Guid DocumentIDReference);
        DocumentData GetDataById(Guid id);
        void UpdateDocumentData();
    }
}
