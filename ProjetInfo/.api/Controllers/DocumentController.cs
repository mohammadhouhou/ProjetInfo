using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProjetInfo.bll.Services.DocumentServices;
using ProjetInfo.dal.entities;

namespace ProjetInfo.api.Controllers
{
    [Route("api/Documents")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _repository;
        private readonly IMapper _mapper;

        public DocumentController(IDocumentService repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

/*        //GET api/documents
        [HttpGet]
        public ActionResult<IEnumerable<DocumentReadDto>> GetAllDocuments()
        {
            var documentItems = _repository.GetDocuments();
            return Ok(_mapper.Map<IEnumerable<DocumentReadDto>>(documentItems));
        }

        //GET api/documents/{id}
        [HttpGet("{id}", Name = "GetDocumentById")]
        public ActionResult<IEnumerable<DocumentReadDto>> GetDocumentById(Guid id)
        {
            var documentItem = _repository.GetDocumentById(id);
            if (documentItem != null)
                return Ok(_mapper.Map<DocumentReadDto>(documentItem));
            return NotFound();
        }*/

        //POST api/documents
        [HttpPost]
        public IActionResult CreateDocument(IFormFile files)
        {

        }

        //PUT api/documents/{id}
        [HttpPut("{id}")]
        public ActionResult updateDocument(Guid id, DocumentUpdateDto documentUpdateDto)
        {
            var documentModelFromRepo = _repository.GetDocumentById(id);
            if (documentModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(DocumentUpdateDto, documentModelFromRepo);

            _repository.UpdateInstitution(documentModelFromRepo);

            return NoContent();
        }

        //PATCH api/documents/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialDocumentUpdate(int id, JsonPatchDocument<DocumentUpdateDto> patchDoc)
        {
            var documentModelFromRepo = _repository.GetDocumentById(id);
            if (documentModelFromRepo == null)
            {
                return NotFound();
            }

            var documentToPatch = _mapper.Map<DocumentUpdateDto>(documentModelFromRepo);
            patchDoc.ApplyTo(documentToPatch, ModelState);
            if (!TryValidateModel(documentToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(documentToPatch, documentModelFromRepo);

            _repository.UpdateCommand(documentModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}