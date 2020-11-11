using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.dal.entities
{
    public class Document
    {
        public Guid id { get; set; }
        public Guid universityId { get; set; }
        public Guid institutionId { get; set; }
        public string name  { get; set; }

        public string description { get; set; }

        public string ContentType { get; set; }
        public bool fileData { get; set; }
        public DateTime uploadedOn { get; set; }

        public string uploadedBy { get; set; }

        public bool isDeleted { get; set; }
    }
}
