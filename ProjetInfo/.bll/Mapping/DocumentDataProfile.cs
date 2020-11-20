using AutoMapper;
using ProjetInfo.bll.Dtos.DocumentDtos;
using ProjetInfo.dal.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.bll.Mapping
{
    public class DocumentDataProfile : Profile
    {
        public DocumentDataProfile()
        {
            CreateMap<DocumentData, DocumentDataUpdateDto>();
            CreateMap<DocumentDataUpdateDto, DocumentData>();
        }
    }
}
