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
            return _context.Institutions.ToList();
        }

        public Institution GetInstitutionById(Guid id)
        {
            return _context.Institutions.Find(id);
        }

        public IEnumerable<Institution> GetInstitutionChildren(Guid Id)
        {
            return _context.Institutions.ToList().Where(institutions => institutions.parentId.Equals(Id));
        }

        //********************* POST METHODS *********************

        public void AddChild(Institution childInst)
        {
            Institution parentInst = _context.Institutions.Find(childInst.parentId);
            if (parentInst == null)
                throw new ArgumentNullException(nameof(parentInst));
            _context.Institutions.Add(childInst);
            _context.SaveChanges();
        }

        public void CreateInstitution(Institution inst)
        {
            _context.Institutions.Add(inst);
            _context.SaveChangesAsync();
        }

        //********************* UPDATE METHODS *********************
        public void UpdateInstitution(Institution OLDinst)
        {
            _context.SaveChanges();
        }
    }
}
