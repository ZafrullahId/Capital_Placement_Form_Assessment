using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class ApplicationProgram : AuditableEntity
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}
