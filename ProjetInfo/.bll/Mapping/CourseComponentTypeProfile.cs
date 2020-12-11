using AutoMapper;
using ProjetInfo.bll.Dtos.CourseComponentTypeDtos;
using ProjetInfo.dal.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.bll.Mapping
{
    public class CourseComponentTypeProfile : Profile
    {
        public CourseComponentTypeProfile()
        {
            CreateMap<CourseComponentType, CourseComponentTypeReadDto>();
            CreateMap<CourseComponentTypeReadDto, CourseComponentType>();
        }
    }
}