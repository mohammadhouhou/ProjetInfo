using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.dal.entities
{
    public class ActivityCategory
    {
        [Key]
        public Guid id { get; set; }
        [Required]
        [MaxLength(6)]
        public string code { get; set; }
        [Required]
        [MaxLength(50)]
        public string name { get; set; }
        public bool exclusive { get; set; }
        public bool required { get; set; }
        [ForeignKey("institutionID")]
        public Guid? owner { get; set; }
    }
}