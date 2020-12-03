using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetInfo.bll.Services.CourseComponentTypeServices;
using ProjetInfo.dal.entities;

namespace ProjetInfo.api.Controllers
{
    [Route("api/CourseComponentType")]
    [ApiController]
    public class CourseComponentTypeController : ControllerBase
    {
        private readonly ICourseComponentTypeService _repository;
        public CourseComponentTypeController(ICourseComponentTypeService repository)
        {
            _repository = repository;
        }

        //GET api/CourseComponentType
        [HttpGet]
        public ActionResult <IEnumerable<CourseComponentType>> GetAllCourseComponentTypes()
        {
            var courseComponentTypeItems = _repository.GetAllCourseComponentType();
            return Ok(courseComponentTypeItems);
        }

        //GET api/CourseComponentType/id
        [HttpGet("{id}")]
        public ActionResult<CourseComponentType> GetCourseComponentTypeById(Guid id)
        {
            var courseComponentTypeItem = _repository.GetCourseComponentTypeById(id);
            if (courseComponentTypeItem != null)
            {
                return Ok(courseComponentTypeItem);
            }
            return NotFound();
        }

        //POST api/CourseComponentType
        [HttpPost]
        public ActionResult CreateCourseComponentType(CourseComponentType courseComponentType)
        {
          _repository.CreateCourseComponentType(courseComponentType);
            return CreatedAtRoute(new { Id = courseComponentType.id }, courseComponentType );
        }

        //PUT api/CourseComponentType/id
        [HttpPut("{id}")]
        public ActionResult UpdateCourseComponentType(Guid id, CourseComponentType courseComponentType)
        {
            var courseComponentTypeModel = _repository.GetCourseComponentTypeById(id);
            if (courseComponentTypeModel == null)
                return NotFound();
            _repository.UpdateCourseComponentType(courseComponentType);
            return NoContent();
        }

        //DELETE api/CourseComponentType/id
        [HttpDelete("{id}")]
        public ActionResult DeleteCourseComponentType(Guid id)
        {
            var courseComponentTypeModel = _repository.GetCourseComponentTypeById(id);
            if (courseComponentTypeModel == null)
                return NotFound();
            _repository.DeleteCourseComponentType(courseComponentTypeModel);
            return NoContent();
        }
    }

}