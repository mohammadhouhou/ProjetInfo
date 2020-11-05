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
            CreateMap<institution, InstitutionReadDto>();
            //Target -> Source
            CreateMap<InstitutionReadDto, institution>();
            CreateMap<InstitutionUpdateDto, institution>();
            CreateMap<institution, InstitutionUpdateDto>();
        }
    }
}
