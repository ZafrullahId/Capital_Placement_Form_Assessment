using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.Dtos.Response
{
    public class ChoiceResponse
    {
        public List<string> Options { get; set; } = [];
        public int MaxChoiceAllowed { get; set; }
    }
}
