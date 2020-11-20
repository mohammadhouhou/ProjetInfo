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
        private readonly IDocumentService _documentRepository;
        private readonly IDocumentDataService _documentDataRepository;
        private readonly IMapper _mapper;

        public DocumentController(IDocumentService repository, IDocumentDataService datarepository, IMapper mapper)
        {
            _documentRepository = repository;
            _documentDataRepository = datarepository;
            _mapper = mapper;
        }

        //GET api/documents/{id}
        [HttpGet("{id}", Name = "GetDocumentById")]
        public ActionResult<IEnumerable<Document>> GetDocumentById(Guid id)
        {
            var documentItem = _documentRepository.GetDocumentById(id);
            if (documentItem != null)
            {
         //       return File(documentItem.fileData, documentItem.contentType, documentItem.name);
            }
            return NotFound();
        }

        //POST api/documents
        [HttpPost]
        public IActionResult CreateDocument(IFormFile files )
        {
            if (files != null)
            {
                _documentRepository.AddDocument(files);
                return Ok();
            }
            return NoContent();
        }

        //PUT api/documents/{id}
        [HttpPut("{id}")]
        public ActionResult updateDocument(Guid id, Document NEWDoc)
        {
            var documentModelFromRepo = _documentRepository.GetDocumentById(id);
            if (documentModelFromRepo == null)
            {
                return NotFound();
            }

            _documentRepository.UpdateDocument(NEWDoc);

            return NoContent();
        }

        //PATCH api/documents/{id}
       /* [HttpPatch("{id}")]
        public ActionResult PartialDocumentUpdate(int id, JsonPatchDocument<DocumentUpdateDto> patchDoc)
        {
            var documentModelFromRepo = _documentRepository.GetDocumentById(id);
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

            _documentRepository.UpdateCommand(documentModelFromRepo);
            _documentRepository.SaveChanges();

            return NoContent();
        }*/

    }
}