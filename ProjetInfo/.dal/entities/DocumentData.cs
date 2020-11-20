using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.dal.entities
{
    public class DocumentData
    {
        [Key]
        public Guid id { get; set; }
        [ForeignKey("Document")]
        public Guid documentID { get; set; }
        [Required]
        public Byte[] fileData { get; set; }
    }
}
