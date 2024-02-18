using Microsoft.EntityFrameworkCore;
using WebApp.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Repository.Infaustructure
{
    public sealed partial class AppDbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AuctionEvent> AuctionEvents { get; set; }
        public DbSet<AuctionState> AuctionStates { get; set; }
        public DbSet<DealHanger> DealHangers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Mutation> Mutations { get; set; }
        public DbSet<Orchid> Orchids { get; set; }
        public DbSet<OrchidCategory> OrchidsCategories { get; set;}
        public DbSet<OrchidMutation> OrchidsMutations { get; set;}
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

    }
}
