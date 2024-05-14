using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.Dtos.Request
{
    public class CreateQuestionRequest
    {
        [Required]
        public string Text { get; set; } = default!;
        public Guid QuestionTypeId { get; set; }
    }
}
