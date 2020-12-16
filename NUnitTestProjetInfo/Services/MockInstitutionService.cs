using ProjetInfo.dal.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.bll.Services.InstitutionServices
{
    public class MockInstitutionService : IInstitutionService
    {
        private readonly MockRepo _repository;
        public MockInstitutionService(MockRepo repo)
        {
            _repository = repo;
        }
        public void AddChild(Institution childInst)
        {
            throw new NotImplementedException();
        }

        public void CreateInstitution(Institution inst)
        {
            throw new NotImplementedException();
        }

        public Institution GetInstitutionById(Guid id)
        {
            return _repository.institutionRepo.ToList().Where(institution => institution.id.Equals(id)).FirstOrDefault();
        }

        public IEnumerable<Institution> GetInstitutionChildren(Guid Id)
        {
            return _repository.institutionRepo.ToList().Where(institution => institution.parentId.Equals(Id));
        }

        public IEnumerable<Institution> GetInstitutions()
        {
            return _repository.institutionRepo.ToList();
        }

        public void UpdateInstitution(Institution OLDinst)
        {
            throw new NotImplementedException();
        }
    }
}
