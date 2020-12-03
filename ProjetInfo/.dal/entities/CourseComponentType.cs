using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.dal.entities
{
    public class CourseComponentType
    {
        public Guid id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public Guid owner { get; set; }
    }
}
