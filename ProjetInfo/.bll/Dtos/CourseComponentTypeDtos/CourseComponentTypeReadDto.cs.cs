using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.bll.Dtos.CourseComponentTypeDtos
{
    public class CourseComponentTypeReadDto
    {
        [Key]
        public Guid id { get; set; }
        [Required]
        [MaxLength(50)]
        public string code { get; set; }
        [Required]
        [MaxLength(250)]
        public string description { get; set; }
    }
}