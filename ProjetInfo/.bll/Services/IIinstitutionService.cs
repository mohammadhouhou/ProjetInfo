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
        //IEnumerable<ActivityCategory> GetActivityCategories(Guid Id);
        IEnumerable<Institution> GetInstitutions();
        Institution GetInstitutionById(Guid id);
/*        string GetCode(Guid id);
        string GetName(Guid id);*/
        void AddChild(Institution childInst);
        public void UpdateInstitution(Institution OLDinst);
        void CreateInstitution(Institution inst);

        //ActivityCategory CreateActivityCategory(string code, string name);
        //void Delete(ActivityCategory act_cat);
    }
}
