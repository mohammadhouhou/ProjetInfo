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
using Microsoft.Extensions.Logging;
using ProjetInfo.bll.Dtos.DocumentDtos;
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
        private readonly ILogger<DocumentController> _logger;

        public DocumentController(IDocumentService repository, IDocumentDataService datarepository, IMapper mapper, ILogger<DocumentController> logger)
        {
            _documentRepository = repository;
            _documentDataRepository = datarepository;
            _mapper = mapper;
            _logger = logger;
        }

        //GET api/documents/{id}
        [HttpGet("{id}", Name = "GetDocumentById")]
        public ActionResult<IEnumerable<Document>> GetDocumentById(Guid id)
        {
            _logger.LogInformation("{methodName} request for {message}", nameof(GetDocumentById), "LoggingGetInstitutionById", DateTime.UtcNow.ToLongTimeString());
            var documentItem = _documentRepository.GetDocumentById(id);
            var docData = _documentDataRepository.GetDataById(id);
            if (documentItem != null)
            {
                return File(docData.fileData, documentItem.contentType, documentItem.name);
            }
            return NotFound();
        }

        [HttpGet("{id}/details", Name = "GetDocumentDetailsById")]
        public ActionResult<IEnumerable<Document>> GetDocumentDetailsById(Guid id)
        {
            var documentItem = _documentRepository.GetDocumentById(id);
            if (documentItem != null)
            {
                return Ok(documentItem);
            }
            return NotFound();
        }

        //POST api/documents
        [HttpPost]
        public IActionResult CreateDocument(IFormFile files, [FromForm] Guid? institutionID, [FromForm] Guid universityID, [FromForm] string description)
        {
            _logger.LogInformation("{methodName} request for {message}", nameof(CreateDocument), "LoggingCreateDocument", DateTime.UtcNow.ToLongTimeString());
            if (files != null)
            {
                Guid DocRefID = new Guid(_documentRepository.AddDocument(files, institutionID, universityID, description));
                _documentDataRepository.AddDocumentData(files, DocRefID);
                return Ok();
            }
            return NoContent();
        }

        //PUT api/documents/{id}
        [HttpPut("{id}/details")]
        public ActionResult updateDocument(Guid id, DocumentUpdateDto NEWDoc)
        {
            _logger.LogInformation("{methodName} request for {message}", nameof(updateDocument), "LoggingupdateDocument", DateTime.UtcNow.ToLongTimeString());
            var documentModelFromRepo = _documentRepository.GetDocumentById(id);
            if (documentModelFromRepo == null)
            {
                return NotFound();
            }

            
            _documentRepository.UpdateDocument(id, NEWDoc);

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult updateDocumentData(Guid id, IFormFile Newfile)
        {
            var documentModelFromRepo = _documentDataRepository.GetDataById(id);
            if (documentModelFromRepo == null)
            {
                return NotFound();
            }
            DocumentDataUpdateDto NEWDocData = new DocumentDataUpdateDto();
            using (var target = new MemoryStream())
            {
                Newfile.CopyTo(target);
                NEWDocData.fileData = target.ToArray();
            }
            
            _mapper.Map(NEWDocData, documentModelFromRepo);
            _documentDataRepository.UpdateDocumentData();
            _documentRepository.UpdateDocumentData(id, Newfile.ContentType, Newfile.FileName);
            _documentRepository.SaveChanges();
            return NoContent();
        }

        //PATCH api/documents/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialDocumentUpdate(Guid id, JsonPatchDocument<DocumentUpdateDto> patchDoc)
        {
            _logger.LogInformation("{methodName} request for {message}", nameof(PartialDocumentUpdate), "LoggingPartialDocumentUpdate", DateTime.UtcNow.ToLongTimeString());
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

            _documentRepository.SaveChanges();

            return NoContent();
        }

    }
}