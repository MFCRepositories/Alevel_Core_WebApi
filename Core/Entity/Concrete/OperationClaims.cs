using System.Collections.Generic;

namespace Core.Entity.Concrete
{
    /// <summary>
    /// JWT altyapısı için Core katmanında Oluşturulan Roles Tablosu
    /// </summary>
    public class OperationClaims
    {
        //TODO : Genişetilecek
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserOperationClaims> UserOperationClaims { get; set; }
    }
}
