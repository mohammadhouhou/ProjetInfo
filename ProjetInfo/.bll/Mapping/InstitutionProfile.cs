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
            CreateMap<Institution, InstitutionReadDto>();
            CreateMap<InstitutionReadDto, Institution>();

            CreateMap<Institution, InstitutionReadChildDto>();
            CreateMap<InstitutionReadChildDto, Institution>();

            CreateMap<InstitutionUpdateDto, Institution>();

            CreateMap<Institution, InstitutionUpdateDto>();
        }
    }
}
