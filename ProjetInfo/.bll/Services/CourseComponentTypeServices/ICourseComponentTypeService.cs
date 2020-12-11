using ProjetInfo.dal.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.bll.Services.CourseComponentTypeServices
{
    public interface ICourseComponentTypeService
    {
        IEnumerable<CourseComponentType> GetAllCourseComponentType();
        CourseComponentType GetCourseComponentTypeById(Guid id);
        void CreateCourseComponentType(CourseComponentType courseComponentType);
        void UpdateCourseComponentType(Guid id, CourseComponentType OLDcourseComponentType);
        void DeleteCourseComponentType(CourseComponentType courseComponentType);
    }
}