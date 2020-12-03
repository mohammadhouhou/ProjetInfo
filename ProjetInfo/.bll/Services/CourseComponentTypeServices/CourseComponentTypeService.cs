using ProjetInfo.dal;
using ProjetInfo.dal.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.bll.Services.CourseComponentTypeServices
{
    public class CourseComponentTypeService : ICourseComponentTypeService
    {
        private readonly CourseComponentTypeContext _context;
        public CourseComponentTypeService(CourseComponentTypeContext context)
        {
            _context = context;
        }
        public void CreateCourseComponentType(CourseComponentType courseComponentType)
        {
            _context.CourseComponentTypes.Add(courseComponentType);
            _context.SaveChangesAsync();
        }

        public void DeleteCourseComponentType(CourseComponentType courseComponentType)
        {
            if (courseComponentType == null)
            {
                throw new ArgumentNullException(nameof(courseComponentType));
            }
            _context.CourseComponentTypes.Remove(courseComponentType);
        }

        public IEnumerable<CourseComponentType> GetAllCourseComponentType()
        {
            return _context.CourseComponentTypes.ToList();
        }

        public CourseComponentType GetCourseComponentTypeById(Guid id)
        {
            return _context.CourseComponentTypes.Find(id);
        }

        public void UpdateCourseComponentType(CourseComponentType OLDcourseComponentType)
        {
            _context.SaveChanges();
        }
    }
}
