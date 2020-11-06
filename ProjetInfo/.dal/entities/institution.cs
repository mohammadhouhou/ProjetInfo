using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.dal.entities
{
    //Put in a sperate class
    public enum institutionType
    {
        amicale,
        faculte,
        institut,
        ecole,
        laboratoire,
        universite,
        campus
    }
    public class Institution
    {
        [Key]
        public Guid id { get; set; }
        [Required]
        [MaxLength(50)]
        public string code { get; set; }
        [Required]
        [MaxLength(250)]
        public string name { get; set; }
        [ForeignKey("parent")]
        public Guid? parentId { get; set; }
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
