using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.dal.entities
{
    public class CourseComponentType
    {
        [Key]
        public Guid id { get; set; }
        [Required]
        [MaxLength(50)]
        public string code { get; set; }
        [Required]
        [MaxLength(250)]
        public string description { get; set; }
        [ForeignKey("institutionID")]
        public Guid? owner { get; set; }

    }
}
