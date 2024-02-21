using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Core.Models.AccountModels
{
    public class AccountRegisterModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTimeOffset Birthday { get; set; }
/*        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }*/
    }
}
