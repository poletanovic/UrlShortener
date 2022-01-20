using Domain.Common;


namespace Domain.Entities
{
    public class UrlModel : AuditableEntity
    {
        public int Id { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public int AuthorId { get; set; }
    }
}
