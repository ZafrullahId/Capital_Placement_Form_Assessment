using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.Dtos.Request
{
    public class CreateApplicationResponseRequest
    {
        public Guid QuestionId { get; set; }
        public string? Response { get; set; }
    }
}
