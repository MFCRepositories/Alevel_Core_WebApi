using Core.Entity;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Product
        : BaseCore, IEntity
    {
        public string Name { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public int Discount { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }


}
