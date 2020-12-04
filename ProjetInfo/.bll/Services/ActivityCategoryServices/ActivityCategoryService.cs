using Microsoft.AspNetCore.Mvc;
using ProjetInfo.dal;
using ProjetInfo.dal.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.bll.Services.ActivityCategoryServices
{
    public class ActivityCategoryService : IActivityCategoryService
    {
        private readonly ActivityCategoryContext _context;

        public ActivityCategoryService(ActivityCategoryContext context)
        {
            _context = context;
        }
        public void AddActivityCategory(ActivityCategory ActCat)
        {
            _context.ActivityCategories.Add(ActCat);
            _context.SaveChanges();
        }

        public bool DeleteActivityCategoryById(Guid id)
        {
            ActivityCategory ActCatToDelete = _context.ActivityCategories.Find(id);
            if (ActCatToDelete == null)
                return false;
            _context.ActivityCategories.Remove(ActCatToDelete);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<ActivityCategory> GetActivityCategories()
        {
            return _context.ActivityCategories.ToList();
        }

        public ActivityCategory GetActivityCategoryById(Guid id)
        {
            return _context.ActivityCategories.Find(id);
        }

        public bool UpdateActivityCategory(Guid id, ActivityCategory newActCat)
        {
            ActivityCategory ActCatToUpdate = _context.ActivityCategories.Find(id);
            if (ActCatToUpdate == null)
                return false;
            ActCatToUpdate.name = newActCat.name;
            ActCatToUpdate.code = newActCat.code;
            ActCatToUpdate.exclusive = newActCat.exclusive;
            ActCatToUpdate.required = newActCat.required;
            ActCatToUpdate.owner = newActCat.owner;
            _context.SaveChanges();
            return true;
        }
    }
}
