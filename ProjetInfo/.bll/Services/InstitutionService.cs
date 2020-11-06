using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetInfo.dal;
using ProjetInfo.dal.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjetInfo.bll.Services
{

    public class InstitutionService : IInstitutionService
    {

        private readonly InstitutionContext _context;


        //********************* GET METHODS *********************

        public InstitutionService(InstitutionContext context)
        {
            _context = context;
        }
        public IEnumerable<Institution> GetInstitutions()
        {
            return _context.institutions.ToList();
        }

        public Institution GetInstitutionById(Guid id)
        {
            return _context.institutions.Find(id);
        }
        /*public IEnumerable<ActivityCategory> GetActivityCategories(Guid Id)
        {
            return _context.institutions.Find(Id).activityCategories; // .SelectMany(table => table.activityCategories);
        }*/

        public IEnumerable<Institution> GetInstitutionChildren(Guid Id)
        {
            return _context.institutions.ToList().Where(institutions => institutions.parentId.Equals(Id)); //.Select(table => table.children).SingleOrDefault();
        }

/*        public string GetCode(Guid Id)
        {
            return _context.institutions.Find(Id).code;

            //return _context.institutions.Select(table => table.code);
        }

        public string GetName(Guid Id)
        {
            return _context.institutions.Find(Id).name;   //.Select(table => table.name).SingleOrDefault();
        }*/


        //********************* POST METHODS *********************

        //must have an institution id to get it's children
        public void AddChild(Institution childInst)
        {
            Institution parentInst = _context.institutions.Find(childInst.parentId);
            if (parentInst == null)
                throw new ArgumentNullException(nameof(parentInst));
            _context.institutions.Add(childInst);
            _context.SaveChanges();
           
            /*var parent = _context.institutions.Find(parentId);
            parent.children.
            _context.institutions.Add(inst);*/
        }

        public void CreateInstitution(Institution inst)
        {
            _context.institutions.Add(inst);
            _context.SaveChangesAsync();
        }


        /*public ActivityCategory CreateActivityCategory(string NEWcode, string NEWname, Guid parentId)
        {
            institution tempinst = _context.institutions.Find(parentId);
            if(tempinst == null)
            {
                throw new ArgumentNullException(nameof(tempinst));
            }
            ActivityCategory NEWactivity = new ActivityCategory
            {
                code = NEWcode,
                name = NEWname,
                owner = parentId
            };
            tempinst.activityCategories.Append(NEWactivity);
            _context.SaveChanges();
            return NEWactivity;
        }
*/
        //********************* DELETE METHODS *********************

        //must have an institution id to know what categorie to delete
        /*public void Delete(ActivityCategory act_cat)
        {
            institution tempinst = _context.institutions.Find(act_cat);
            if (tempinst == null)
            {
                throw new ArgumentNullException(nameof(tempinst));
            }
            tempinst.activityCategories.Remove(act_cat);
            _context.SaveChanges();
            //_context.institutions.First(table => table.activityCategories).;
        }*/

        //********************* UPDATE METHODS *********************
        public void UpdateInstitution(Institution OLDinst)
        {
            _context.SaveChanges();
        }

        /*public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }*/
    }
}
