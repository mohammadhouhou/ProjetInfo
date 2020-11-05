using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.dal.entities
{
    public enum institutionType
    {
        amicale = 1,
        faculte = 2,
        institut = 3,
        ecole = 4,
        laboratoire = 5
    }
    public class institution
    {
        [Key]
        public Guid id { get; set; }
        [Required]
        [MaxLength(50)]
        public string code { get; set; }
        [Required]
        [MaxLength(250)]
        public string name { get; set; }
        public IEnumerable<ActivityCategory> activityCategories { get; set; }
        public IEnumerable<institution> children { get; set; }
        public Guid parentId { get; set; }
        [Required]
        public institutionType type { get; set; }

        /*public institution(string name, string code, Guid parentId, institutionType type)
        {
            this.code = code;
            this.name = name;
            this.parentId = parentId;
            this.type = type;
        }*/
    }
}
