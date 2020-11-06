using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProjetInfo.bll.Dtos;
using ProjetInfo.dal.entities;

namespace ProjetInfo.Mapping
{
    public class InstitutionProfile : Profile
    {
        public InstitutionProfile()
        {
            //Source -> Target
            CreateMap<Institution, InstitutionReadDto>();
            //Target -> Source
            CreateMap<InstitutionReadDto, Institution>();
            CreateMap<InstitutionUpdateDto, Institution>();
            CreateMap<Institution, InstitutionUpdateDto>();
        }
    }
}
