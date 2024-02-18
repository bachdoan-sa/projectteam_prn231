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
    public class OrchidMutation : BaseEntityModel
    {
        public string Color { get; set; }
        public double Size { get; set; }
        public string Shape { get; set; }
        public string MutationId { get; set; }
        [ForeignKey(nameof(MutationId))]
        public virtual Mutation Mutation { get; set; }
        public string OrchidId { get; set; }
        [ForeignKey(nameof(OrchidId))]
        public virtual Orchid Orchid { get; set; }
        
    }
}
