using Domain.Common;


namespace Domain.Entities
{
    public class News : AuditableEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int AuthorId { get; set; }
    }
}
