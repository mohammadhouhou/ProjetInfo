using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjetInfo.Controllers
{
    [Route("api/Institutions")]
    [ApiController]
    public class InstitutionController : ControllerBase
    {
        private readonly IInstitutionService _repository;
        private readonly IMapper _mapper;

        public InstitutionController(IInstitutionService repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/institutions
        [HttpGet]
        public ActionResult<IEnumerable<InstitutionReadDto>> GetAllInstitutions()
        {
            var institutionItems = _repository.GetAllInstitutions();
            return Ok(_mapper.Map<IEnumerable<InstitutionReadDto>>(institutionItems));
        }

        //GET api/institutions/{id}
        public ActionResult<IEnumerable<InsitutionReadDto>> GetInstitutionById(int id)
        {
            var insitutionItem = _repository.GetInstitutionById(id);
            if (insitutionItem != null)
                return Ok(_mapper.Map<InsitutionReadDto>(insitutionItem));
            return NotFound();
        }

        //GET api/institutions/{id}/children
        public ActionResult<IEnumerable<InsitutionReadDto>> GetInstitutionChildren(int id)
        {
            var instiutionChildren = _repository.GetInstitutionChildren(id);
            if (instiutionChildren != null)
                return Ok(_mapper.Map<IEnumerable<InsitutionReadDto>>(instiutionChildren);
            return NotFound();
        }

        //POST api/institutions
        [HttpPost]
        public ActionResult<InsitutionReadDto> CreateInstitution(InsitutionReadDto insitutionReadDto)
        {
            var institutionModel = _mapper.Map<Insitution>(insitutionReadDto);
            _repository.CreateInstitution(institutionModel);
            _repository.SaveChanges();

            var institutionReadDto = _mapper.Map<InsitutionReadDto>(institutionModel);

            return CreatedAtRoute(nameof(GetInstitutionById), new { Id = institutionReadDto.Id}, institutionReadDto);
        }

        //POST api/institution/{id}/institutions
        [HttpPost]
        public ActionResult<InsitutionReadDto> CreateInstitutionAsChild(InsitutionReadDto insitutionReadDto, int parentId)
        {
            var institutionModel = _mapper.Map<Insitution>(insitutionReadDto);
            _repository.CreateInstitionAsChild(institutionModel, parentId);

            var institutionReadDto = _mapper.Map<InsitutionReadDto>(institutionModel);
            return CreatedAtRoute(nameof(GetInstitutionById), new { Id = institutionReadDto.parentId }, institutionReadDto);
        }

        //PUT api/institution/{id}
        public ActionResult updateInstitution(int id, InstitutionUpdateDto institutionUpdateDto) {
            var institutionModelFromRepo = _repository.GetInstitutionById(id);
            if(institutionModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(institutionUpdateDto, institutionModelFromRepo);

            _repository.UpdateInstitution(institutionModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}