using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Author : AuditableEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public string UserId { get; set; }
        public IList<News> News { get; private set; } = new List<News>();
    }
}
