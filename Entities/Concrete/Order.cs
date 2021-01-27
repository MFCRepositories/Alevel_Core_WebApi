using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Order
        :BaseCore, IEntity
    {
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
