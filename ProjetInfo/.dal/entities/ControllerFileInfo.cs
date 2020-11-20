using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.dal.entities
{
    public class ControllerFileInfo
    {
        public IFormFile files { get; set; }
        public Guid universityID { get; set; }
        public Guid institutionID { get; set; }
        public string description { get; set; }
    }
}
