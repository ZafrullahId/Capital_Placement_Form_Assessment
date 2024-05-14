using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.Dtos.Request
{
    public class CreateSubmissionRequest
    {
        public CreatePersonalInformationRequest PersonalInformation { get; set; }
        public List<CreateApplicationResponseRequest> ApplicationResponse { get; set; }
    }
}
