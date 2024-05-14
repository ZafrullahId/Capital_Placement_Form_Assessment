using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.Dtos.Response
{
    public class QuestionResponse
    {
        public string Text { get; set; } = default!;
        public Guid QuestionTypeId { get; set; }
        public Guid? ChoiceId { get; set; }
        public ChoiceResponse? ChoiceResponse { get; set; }
    }
}
