using WebApp.Repository.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Repository.Entities
{
    public class Role : BaseEntityModel
    {
        public string RoleName { get; set; }
        public virtual ICollection<Account>? Accounts { get; set; }
    }
}
