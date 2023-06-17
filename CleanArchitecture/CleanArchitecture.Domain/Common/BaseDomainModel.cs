namespace CleanArchitecture.Domain.Common
{
    public abstract class BaseDomainModel
    {
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public String CreateBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public String LastModifiedBy { get; set; }

    }
}
