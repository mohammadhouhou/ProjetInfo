using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace ProjetInfo.Mapping
{
    public class InstitutionProfile : Profile
    {
        public InstitutionProfile()
        {
            //Source -> Target
            CreateMap<Insitution, InstitutionReadDto>();
            //Target -> Source
            CreateMap<InstitutionReadDto, Institution>();
            CreateMap<InstitutionUpdateDto, Institution>();
            CreateMap<Institution, InstitutionUpdateDto>();
        }
    }
}
