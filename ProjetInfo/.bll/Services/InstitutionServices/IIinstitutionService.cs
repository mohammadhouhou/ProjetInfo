using Microsoft.AspNetCore.Mvc;
using ProjetInfo.dal.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.bll
{
    public interface IInstitutionService
    {
        IEnumerable<Institution> GetInstitutionChildren(Guid Id);
        IEnumerable<Institution> GetInstitutions();
        Institution GetInstitutionById(Guid id);
        void AddChild(Institution childInst);
        public void UpdateInstitution(Institution NEWinst);
        void CreateInstitution(Institution inst);
    }
}
