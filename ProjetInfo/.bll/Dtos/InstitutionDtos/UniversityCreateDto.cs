using ProjetInfo.dal.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.bll.Dtos.InstitutionDtos
{
    public class UniversityCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string code { get; set; }
        [Required]
        [MaxLength(250)]
        public string name { get; set; }

        public institutionType type = institutionType.universite;
        [Required]
        public int adressId { get; set; }
        [Required]

        public int contactInfoId { get; set; }
    }
}
