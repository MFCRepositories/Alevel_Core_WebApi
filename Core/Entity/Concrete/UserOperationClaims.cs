namespace Core.Entity.Concrete
{
    /// <summary>
    /// JWT altyapısı için Core katmanında Oluşturulan Kullanıcı-Roles Many-To-Many ilişkisel Tablosu
    /// </summary>
    public class UserOperationClaims
    {
        //TODO : Genişetilecek
        public int UserId { get; set; }
        public User User { get; set; }
        public int OperationClaimId { get; set; }
        public  OperationClaims OperationClaims { get; set; }
    }
}
