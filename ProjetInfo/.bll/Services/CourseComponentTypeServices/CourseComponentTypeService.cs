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
            _context.SaveChanges();
        }

        public void DeleteCourseComponentType(CourseComponentType courseComponentType)
        {
            if (courseComponentType == null)
            {
                throw new ArgumentNullException(nameof(courseComponentType));
            }
            _context.CourseComponentTypes.Remove(courseComponentType);
            _context.SaveChanges();
        }

        public IEnumerable<CourseComponentType> GetAllCourseComponentType()
        {
            return _context.CourseComponentTypes.ToList();
        }

        public CourseComponentType GetCourseComponentTypeById(Guid id)
        {
            return _context.CourseComponentTypes.Find(id);
        }

        public void UpdateCourseComponentType(Guid id, CourseComponentType NewCourseComponentType)
        {
            CourseComponentType OldCCT = _context.CourseComponentTypes.Find(id);
            OldCCT.description = NewCourseComponentType.description;
            OldCCT.code = NewCourseComponentType.code;
            _context.SaveChanges();
        }
    }
}
