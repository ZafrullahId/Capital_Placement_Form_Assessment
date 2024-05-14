using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.Dtos.Request
{
    public class CreateQuestionTypeRequest
    {
        [Required]
        public string TypeName { get; set; } = default!;
    }
}
