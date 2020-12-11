using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.bll.Dtos.DocumentDtos
{
    public class DocumentUpdateDto
    {
        [Required]
        [ForeignKey("university")]
        public Guid universityId { get; set; }
        [ForeignKey("institution")]
        public Guid? institutionId { get; set; }
        [Required]
        [MaxLength(100)]
        public string name { get; set; }
        [Required]
        [MaxLength(100)]
        public string description { get; set; }
        [Required]
        public Boolean isDeleted { get; set; }
    }
}