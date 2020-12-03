using Microsoft.AspNetCore.Mvc;
using ProjetInfo.dal.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.bll.Services.ActivityCategoryServices
{
    public interface IActivityCategoryService
    {
        ActivityCategory GetActivityCategoryById(Guid id);
        IEnumerable<ActivityCategory> GetActivityCategories();
        void AddActivityCategory(ActivityCategory ActCat);
        bool UpdateActivityCategory(Guid id, ActivityCategory newActCat);
        bool DeleteActivityCategoryById(Guid id);
    }
}
