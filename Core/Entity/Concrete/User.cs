using System.Collections.Generic;

namespace Core.Entity.Concrete
{
    /// <summary>
    /// JWT altyapısı için Core katmanında Oluşturulan Kullanıcı Tablosu
    /// </summary>
    public class User : IEntity
    {
        //TODO : Genişetilecek
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public virtual List<UserOperationClaims> UserOperationClaims { get; set; }
    }
}
