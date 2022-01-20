using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Dtos
{
    public class CreateUrlModelRequest
    {
        [Required(ErrorMessage = "Long name is required")]
        [StringLength(200)]
        public string LongName { get; set; }

    }
}
