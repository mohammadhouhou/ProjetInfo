using Microsoft.AspNetCore.Mvc;
using ProjetInfo.dal.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.bll
{
    interface IInstitutionService
    {
        IEnumerable<institution> GetInstitutionChildren(Guid Id);
        //IEnumerable<ActivityCategory> GetActivityCategories(Guid Id);
        IEnumerable<institution> GetInstitutions();
        institution GetInstitutionById(Guid id);
        string GetCode(Guid id);
        string GetName(Guid id);
        void AddChild(institutionType type, string NEWcode, string NEWname, Guid parentId);
        public void UpdateInstitution(institution OLDinst);
        void CreateInstitution(institution inst);

        //ActivityCategory CreateActivityCategory(string code, string name);
        //void Delete(ActivityCategory act_cat);

    }
}
