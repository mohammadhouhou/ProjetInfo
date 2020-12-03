using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetInfo.bll.Services.ActivityCategoryServices;
using ProjetInfo.dal.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.api.Controllers
{
    [Route("api/ActivityCategory")]
    [ApiController]
    public class ActivityCategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ActivityCategoryController> _logger;
        private readonly IActivityCategoryService _repository;
        public ActivityCategoryController(IMapper mapper, ILogger<ActivityCategoryController> logger, IActivityCategoryService repository)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
        }

        //=====================GET METHODS=====================
        [HttpGet("{id}")]
        public ActionResult<ActivityCategory> GetActivityCategoryById(Guid id)
        {
            ActivityCategory ActCatToReturn = _repository.GetActivityCategoryById(id);
            if (ActCatToReturn == null)
                return NotFound();
            return Ok(ActCatToReturn);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ActivityCategory>> GetActivityCategories()
        {
            IEnumerable<ActivityCategory> ActCatToReturn = _repository.GetActivityCategories();
            if (ActCatToReturn == null)
                return NotFound();
            return Ok(ActCatToReturn);
        }

        //=====================POST METHODS=====================
        [HttpPost]
        public IActionResult AddActivityCategory(ActivityCategory ActCat)
        {
            _repository.AddActivityCategory(ActCat);
            return Ok(ActCat);
        }

        //=====================UPDATE METHODS=====================
        [HttpPut("{id}")]
        public IActionResult UpdateActivityCategory(Guid id, ActivityCategory newActCat)
        {
            if (_repository.UpdateActivityCategory(id, newActCat) == false)
                return BadRequest();
            return Ok(newActCat);
        }

        //=====================DELETE METHODS=====================
        [HttpDelete("{id}")]
        public IActionResult DeleteActivityCategoryById(Guid id)
        {
            if (_repository.DeleteActivityCategoryById(id) == false)
                return BadRequest();
            return Ok("Deleted");
        }
    }
}
