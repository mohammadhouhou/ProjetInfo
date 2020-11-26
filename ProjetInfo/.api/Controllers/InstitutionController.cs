using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetInfo.api.Controllers;
using ProjetInfo.bll;
using ProjetInfo.bll.Dtos;
using ProjetInfo.bll.Dtos.InstitutionDtos;
using ProjetInfo.bll.Services;
using ProjetInfo.dal;
using ProjetInfo.dal.entities;

namespace ProjetInfo.Controllers
{
    [Route("api/Institutions")]
    [ApiController]
    public class InstitutionController : ControllerBase
    {
        private readonly IInstitutionService _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<DocumentController> _logger;

        public InstitutionController(IInstitutionService repository, IMapper mapper, ILogger<DocumentController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        //GET api/institutions
        [HttpGet]
        public ActionResult<IEnumerable<InstitutionReadDto>> GetAllInstitutions()
        {
            _logger.LogInformation("{methodName} request for {message}", nameof(GetAllInstitutions), "LoggingGetAllInstitutions", DateTime.UtcNow.ToLongTimeString());
            var institutionItems = _repository.GetInstitutions();
            return Ok(_mapper.Map<IEnumerable<InstitutionReadDto>>(institutionItems));
        }

        //GET api/institutions/{id}
        [HttpGet("{id}",Name = "GetInstitutionById")]
        public ActionResult<IEnumerable<InstitutionReadDto>> GetInstitutionById(Guid id)
        {
            _logger.LogInformation("{methodName} request for {message}", nameof(GetInstitutionById), "LoggingGetInstitutionById", DateTime.UtcNow.ToLongTimeString());
            var insitutionItem = _repository.GetInstitutionById(id);
            if (insitutionItem != null)
                return Ok(_mapper.Map<InstitutionReadDto>(insitutionItem));
            return NotFound();
        }

        //GET api/institutions/{id}/children
        [HttpGet("children/{id}", Name = "GetInstitutionChildren")]
        public ActionResult<IEnumerable<InstitutionReadDto>> GetInstitutionChildren(Guid id)
        {
            _logger.LogInformation("{methodName} request for {message}", nameof(GetInstitutionChildren), "LoggingGetInstitutionChildren", DateTime.UtcNow.ToLongTimeString());
            var instiutionChildren = _repository.GetInstitutionChildren(id);
            if (instiutionChildren != null)
                return Ok(_mapper.Map<IEnumerable<InstitutionReadDto>>(instiutionChildren));
            return NotFound();
        }

        //POST api/institutions
        [HttpPost]
        public ActionResult<InstitutionReadDto> CreateInstitution(InstitutionReadDto insitutionReadDto)
        {
            _logger.LogInformation("{methodName} request for {message}", nameof(CreateInstitution), "LoggingCreateInstitution", DateTime.UtcNow.ToLongTimeString());
            var institutionModel = _mapper.Map<Institution>(insitutionReadDto);
            _repository.CreateInstitution(institutionModel);

            var institutionReadDto = _mapper.Map<InstitutionReadDto>(institutionModel);

            return CreatedAtRoute(nameof(GetInstitutionById), new { Id = institutionReadDto.id}, institutionReadDto);
        }

        //POST api/institutions/university
        [HttpPost("University")]
        public ActionResult<InstitutionReadDto> CreateUniversity(UniversityCreateDto UniversityCreateDto)
        {
            var universityModel = _mapper.Map<Institution>(UniversityCreateDto);
            _repository.CreateInstitution(universityModel);

            var universityReadDto = _mapper.Map<InstitutionReadDto>(universityModel);

            return CreatedAtRoute(nameof(GetInstitutionById), new { Id = universityReadDto.id }, universityReadDto);
        }

        //POST api/institution/{id}/institutions
        [HttpPost("{id}/institutions", Name = "AddChild")]
        public ActionResult<InstitutionReadChildDto> AddChild(Guid id, InstitutionReadChildDto insitutionReadChildDto)
        {
            _logger.LogInformation("{methodName} request for {message}", nameof(AddChild), "LoggingAddChild", DateTime.UtcNow.ToLongTimeString());
            var institutionModel = _mapper.Map<Institution>(insitutionReadChildDto);
            institutionModel.parentId = id;
            _repository.AddChild(institutionModel);

            var institutionReadChildDto = _mapper.Map<InstitutionReadChildDto>(institutionModel);
            return CreatedAtRoute(nameof(GetInstitutionById), new { Id = institutionModel.parentId }, institutionReadChildDto) ;
        }

        //PUT api/institution/{id}
        [HttpPut("{id}")]
        public ActionResult updateInstitution(Guid id, InstitutionUpdateDto institutionUpdateDto) {
            _logger.LogInformation("{methodName} request for {message}", nameof(updateInstitution), "LoggingupdateInstitution", DateTime.UtcNow.ToLongTimeString());
            var institutionModelFromRepo = _repository.GetInstitutionById(id);
            if(institutionModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(institutionUpdateDto, institutionModelFromRepo);

            _repository.UpdateInstitution(institutionModelFromRepo);

            return NoContent();
        }


    }
}