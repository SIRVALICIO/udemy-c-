namespace CleanArchitecture.Domain.Common
{
    public abstract class BaseDomainModel
    {
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public String CreateBy { get; set; }
        public DateTime? LastModifiedDay { get; set; }
        public String LastModifiedBy { get; set; }

    }
}
