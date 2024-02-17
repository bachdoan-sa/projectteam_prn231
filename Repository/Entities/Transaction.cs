using Repository.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Transaction : BaseEntityModel
    {
        public string PaymentMethod { get; set; }
        public double Amount { get; set; }
        public string? TransactionStatus { get; set; }
        public string? Message { get; set; }
        public long ReponseTime { get; set; }

        [Required]
        public string WalletId { get; set; }
        [ForeignKey(nameof(WalletId))]
        public virtual Wallet Wallet { get; set; }
    }
}
