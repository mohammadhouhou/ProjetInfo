using ProjetInfo.dal.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.bll.Dtos
{
    public class InstitutionReadDto
    {
        [Key]
        public Guid id { get; set; }
        [Required]
        [MaxLength(50)]
        public string code { get; set; }
        [Required]
        [MaxLength(250)]
        public string name { get; set; }
        [Required]
        public institutionType type { get; set; }
        [Required]
        public int adressId { get; set; }
        [Required]
        public int contactInfoId { get; set; }
        public Guid? parentId { get; set; }

    }
}
