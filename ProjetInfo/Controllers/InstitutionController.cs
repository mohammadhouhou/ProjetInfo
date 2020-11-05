using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetInfo.bll;
using ProjetInfo.bll.Services;
using ProjetInfo.dal.entities;

namespace ProjetInfo.Controllers
{
    [Route("api/Institutions")]
    [ApiController]
    public class InstitutionController : ControllerBase
    {
        private readonly IInstitutionService _repository;
        private readonly IMapper _mapper;

        public InstitutionController(InstitutionContextService repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/institutions
        [HttpGet]
        public ActionResult<IEnumerable<InstitutionReadDto>> GetAllInstitutions()
        {
            var institutionItems = _repository.GetInstitutions();
            return Ok(_mapper.Map<IEnumerable<InstitutionReadDto>>(institutionItems));
        }

        //GET api/institutions/{id}
        public ActionResult<IEnumerable<InstitutionReadDto>> GetInstitutionById(Guid id)
        {
            var insitutionItem = _repository.GetInstitutionById(id);
            if (insitutionItem != null)
                return Ok(_mapper.Map<InstitutionReadDto>(insitutionItem));
            return NotFound();
        }

        //GET api/institutions/{id}/children
        public ActionResult<IEnumerable<InstitutionReadDto>> GetInstitutionChildren(Guid id)
        {
            var instiutionChildren = _repository.GetInstitutionChildren(id);
            if (instiutionChildren != null)
                return Ok(_mapper.Map<IEnumerable<InstitutionReadDto>>(instiutionChildren));
            return NotFound();
        }

        //POST api/institutions
        [HttpPost]
        public ActionResult<InstitutionReadDto> CreateInstitution(InstitutionReadDto insitutionReadDto)
        {
            var institutionModel = _mapper.Map<InstitutionContextService>(insitutionReadDto);
            _repository.CreateInstitution(institutionModel);

            var institutionReadDto = _mapper.Map<InstitutionReadDto>(institutionModel);

            return CreatedAtRoute(nameof(GetInstitutionById), new { Id = institutionReadDto.Id}, institutionReadDto);
        }

        //POST api/institution/{id}/institutions
        [HttpPost]
        public ActionResult<InstitutionReadDto> AddChild(InstitutionReadDto insitutionReadDto, Guid parentId)
        {
            var institutionModel = _mapper.Map<InstitutionContextService>(insitutionReadDto);
            _repository.(institutionModel, parentId);

            var institutionReadDto = _mapper.Map<InstitutionReadDto>(institutionModel);
            return CreatedAtRoute(nameof(GetInstitutionById), new { Id = institutionReadDto.parentId }, institutionReadDto);
        }

        //PUT api/institution/{id}
        public ActionResult updateInstitution(Guid id, InstitutionUpdateDto institutionUpdateDto) {
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