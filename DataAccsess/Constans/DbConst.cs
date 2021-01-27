using Core.Utilities.Constans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Constans
{
    /// <summary>
    /// Database tablo isimleri tutulacak
    /// </summary>
    public static class DbConst
    {
        public readonly static DbTable Product = new DbTable("Product", "Main");
    }
}
