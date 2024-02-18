using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Repository.Entities.BaseEntity
{
    public abstract class BaseEntityModel
    {
        protected BaseEntityModel()
        {
            Id = Guid.NewGuid().ToString("N");
            CreatedTime = LastUpdated = DateTimeOffset.Now;
        }
        [Key]
        public string Id { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
        public DateTimeOffset? DeleteTime { get; set; }
    }
}
