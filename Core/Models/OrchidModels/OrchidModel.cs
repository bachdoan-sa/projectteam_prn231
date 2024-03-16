using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Core.Models.OrchidModels
{
    public class OrchidModel
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string OrchidStatus { get; set; }

        public string? OrchidCategoryId { get; set; }
        public string? ProductOwnerId { get; set; }
        public string? MutationId { get; set; }
        public string Color { get; set; }
        public double Size { get; set; }
        public string Shape { get; set; }
        public DateTimeOffset? CreatedTime { get; set; }
        public DateTimeOffset? LastUpdated { get; set; }
        public DateTimeOffset? DeleteTime { get; set; }
    }
}
