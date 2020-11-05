using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using ProjetInfo.dal;
using ProjetInfo.dal.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.bll.Services
{

    public class InstitutionContextService : IInstitution
    {
        private readonly institutionContext _context;

        public InstitutionContextService(institutionContext context)
        {
            _context = context;
        }
        public IEnumerable<institution> GetInstitutions()
        {
            return _context.institutions.ToList();
        }

        public institution GetInstitutionById(Guid id)
        {
            return _context.institutions.Find(id);
        }
       /* public IEnumerable<ActivityCategory> ActivityCategories()
        {
            return _context.institutions.Select(table => table.activityCategories).SingleOrDefault();
        }*/

        //must have an institution id to get it's children
        public void AddChild(institution inst, string code, string name, institutionType type)
        {
            if (inst == null)
                throw new ArgumentNullException(nameof(inst));
            institution child = new institution(code, name, inst.id, type);
            _context.institutions.Find(inst.id).children.Append(child);
            _context.institutions.Add(child);
            /*var parent = _context.institutions.Find(parentId);
            parent.children.
            _context.institutions.Add(inst);*/
        }

        public IEnumerable<institution> AllChildren()
        {
            return _context.institutions.Select(table => table.children).SingleOrDefault();
        }

        public string Code()
        {
            return _context.institutions.Select(table => table.code).SingleOrDefault();
        }

        public ActivityCategory CreateActivityCategory(string code, string name, Guid parentId)
        {
            throw new NotImplementedException();
        }
        //must have an institution id to know what categorie to delete
        public void Delete(ActivityCategory act_cat)
        {
            //_context.institutions.First(table => table.activityCategories).;
        }

        public string Name()
        {
            return _context.institutions.Select(table => table.name).SingleOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
