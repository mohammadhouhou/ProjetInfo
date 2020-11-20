﻿using AutoMapper;
using ProjetInfo.bll.Dtos.DocumentDtos;
using ProjetInfo.dal.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.bll.Mapping
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<Document, DocumentUpdateDto>();
            CreateMap<DocumentUpdateDto, Document>();
        }
    }
}
