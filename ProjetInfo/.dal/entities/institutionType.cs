using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetInfo.dal.entities
{
    [NotMapped]
    public class institutionType
    {
        enum values
        {
            amicale = 1,
            faculte = 2,
            institut = 3,
            ecole = 4,
            laboratoire = 5
        }
    }

    
}
