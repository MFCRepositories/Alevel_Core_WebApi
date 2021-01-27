using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class MasterCategory
        :BaseCore, IEntity
    {
        public string Name { get; set; }

    }
}
