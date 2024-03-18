using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Repository.Entities.BaseEntity;

namespace WebApp.Repository.Entities
{
    public class OrchidImage : BaseEntityModel
    {
        public string? ImageUrl { get; set; }
        public string? ImageData { get; set; }
        public string OrchidId { get; set; }
        [ForeignKey(nameof(OrchidId))]
        public virtual Orchid Orchid { get; set; }
    }
}
