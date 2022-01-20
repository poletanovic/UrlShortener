using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Dtos
{
    public class GetUrlModelResponse
    {
        public int Id { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public int AuthorId { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
    }
}
