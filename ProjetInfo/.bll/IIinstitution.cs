using ProjetInfo.dal.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.bll
{
    interface IInstitutionService
    {
        string Code();
        string Name();
        void AddChild(institution inst, Guid parentId);
        ActivityCategory CreateActivityCategory(string code, string name);
        void Delete(ActivityCategory act_cat);
        IInstitution[] AllChildren();
        ActivityCategory[] ActivityCategories();
        institution[] GetInstitutions();
    }
}
