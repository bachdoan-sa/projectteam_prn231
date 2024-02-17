using Repository.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class OrchidCategory : BaseEntityModel
    {
        public string CategoryName { get; set; }
        public virtual ICollection<Orchid>? Orchids { get; set; }
    }
}
