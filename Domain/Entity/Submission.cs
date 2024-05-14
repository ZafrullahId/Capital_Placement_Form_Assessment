using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Submission : AuditableEntity
    {
        public Guid FormWindowId { get; set; }
        public PersonalInformation PersonalInformation { get; set; } = default!;
        public List<ApplicationResponse> ApplicationResponses { get; set; } = [];
    }
}
