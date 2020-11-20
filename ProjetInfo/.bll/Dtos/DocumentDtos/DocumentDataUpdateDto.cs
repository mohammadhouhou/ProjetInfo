using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.bll.Dtos.DocumentDtos
{
    public class DocumentDataUpdateDto
    {
        [Required]
        public Byte[] fileData { get; set; }
    }
}
