using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.dal.entities
{
    public class ActivityCategory
    {


        public Guid id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public bool exclusive { get; set; }

        public bool required { get; set; }
        public Guid owner { get; set; }
        public ActivityCategory(string name, string code, bool exclusive, bool required, Guid owner)
        {
            this.code = code;
            this.name = name;
            this.exclusive = exclusive;
            this.required = required;
            this.owner = owner;
        }
    }
}
