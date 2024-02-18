using WebApp.Repository.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Repository.Entities
{
    public class Mutation : BaseEntityModel
    {
        public string MutationPosition { get; set; }
        public virtual ICollection<OrchidMutation>? OrchidMutations { get; set; }
    }
}
