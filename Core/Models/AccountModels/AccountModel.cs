using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models.RoleModels;

namespace WebApp.Core.Models.AccountModels
{
    public class AccountModel
    {
        public string? Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTimeOffset Birthdate { get; set; }
        public string RoleId { get; set; }
        public RoleModel? role { get; set; }
    }
}
