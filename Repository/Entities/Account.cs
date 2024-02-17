using Repository.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Account : BaseEntityModel 
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTimeOffset Birthdate { get; set; }     
        public string? Otp { get; set; } = null;
        public DateTime? OtpCreatedDate { get; set; } = null;
        public DateTime? OtpExpiredDate { get; set; } = null;
        
        public string RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; }

        public virtual ICollection<Wallet>? Wallets { get; set; }
        public virtual ICollection<AuctionEvent>? AuctionEvents { get; set; }
        public virtual ICollection<Orchid>? Orchids { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<DealHanger>? DealHangers { get; set; }
    }
}
