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
        private readonly ILogger<DocumentController> _logger;


        public DocumentController(IDocumentService repository, IMapper mapper, ILogger<DocumentController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        //GET api/documents
        /*[HttpGet]
        public ActionResult<IEnumerable<Document>> GetAllDocuments()
        {
        _logger.LogInformation("{methodName} request for {message}", nameof(GetAllDocuments), "LoggingGetAllDocuments",DateTime.UtcNow.ToLongTimeString());
            *//*var documentItems = _repository.GetDocuments();
            return Ok(documentItems);*//*
        }*/

        //GET api/documents/{id}
        [HttpGet("{id}", Name = "GetDocumentById")]
        public ActionResult<IEnumerable<IFormFile>> GetDocumentById(Guid id)
        {
            _logger.LogInformation("{methodName} request for {message}", nameof(GetDocumentById), "LoggingGetInstitutionById", DateTime.UtcNow.ToLongTimeString());
            var documentItem = _repository.GetDocumentById(id);
            if (documentItem != null)
                return Ok(documentItem);
            return NotFound();
        }

        //POST api/documents
        [HttpPost]
        public IActionResult CreateDocument(IFormFile files)
        {
            _logger.LogInformation("{methodName} request for {message}", nameof(CreateDocument), "LoggingCreateDocument", DateTime.UtcNow.ToLongTimeString());
            if (files != null)
            {
                _repository.AddDocument(files);
                return Ok();
            }
            return NoContent();
        }

        //PUT api/documents/{id}
        /* [HttpPut("{id}")]
         public ActionResult updateDocument(Guid id, DocumentUpdateDto documentUpdateDto)
         {
        _logger.LogInformation("{methodName} request for {message}", nameof(updateDocument), "LoggingupdateDocument",DateTime.UtcNow.ToLongTimeString());
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
        _logger.LogInformation("{methodName} request for {message}", nameof(PartialDocumentUpdate), "LoggingPartialDocumentUpdate",DateTime.UtcNow.ToLongTimeString());
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
         }*/

    }
}