using WebApp.Repository.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Repository.Entities
{
    public class Wallet : BaseEntityModel
    {
        public string WalletType { get; set; }
        public double Balance { get; set; }
        [Required]
        public string AccountId { get; set; }
        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }
        public virtual ICollection<Transaction>? Transactions { get; set; }  
    }
}
