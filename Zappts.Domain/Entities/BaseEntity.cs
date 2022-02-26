using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zappts.Domain.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Id = new Guid();
        }
        
        public virtual Guid Id { get; set; }
        public string CriadoEm { get; set; }
    }
}
