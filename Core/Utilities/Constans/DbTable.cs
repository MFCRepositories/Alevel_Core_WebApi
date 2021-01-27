using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Constans
{
    /// <summary>
    /// DAL Katmanında Entity framwork mapping işlemlerinde database tablolarının Name ve Schema yönetimi için...
    /// </summary>
    public class DbTable
    {
        public string Name { get; private set; }
        public string Schema { get; set; }
        public string NameWithSchema
        {
            get
            {
                return $"{Name}.{Schema}";
            }
        }
        public DbTable(string name, string schema)
        {
            Name = name;
            Schema = schema;
        }
    }
}
