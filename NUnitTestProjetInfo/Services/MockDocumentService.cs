using Microsoft.AspNetCore.Http;
using ProjetInfo.bll.Dtos.DocumentDtos;
using ProjetInfo.dal.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.bll.Services.DocumentServices
{
    public class MockDocumentService : IDocumentService
    {
        private readonly MockRepo _repository;
        public MockDocumentService(MockRepo repo)
        {
            _repository = repo;
        }
        public string AddDocument(IFormFile form, Guid? institutionId, Guid universityId, string description)
        {
            throw new NotImplementedException();
        }

        public Document GetDocumentById(Guid id)
        {
            return _repository.documentRepo.ToList().Where(document => document.id.Equals(id)).Where(document => document.isDeleted == false).FirstOrDefault(); ;
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateDocument(Guid id, DocumentUpdateDto NEWDoc)
        {
            throw new NotImplementedException();
        }

        public void UpdateDocumentData(Guid id, string ContentType, string filename)
        {
            throw new NotImplementedException();
        }
    }
}
