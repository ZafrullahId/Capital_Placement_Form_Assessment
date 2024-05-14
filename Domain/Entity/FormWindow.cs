using Domain.Contracts;

namespace Domain.Entity
{
    public class FormWindow : AuditableEntity
    {
        public Guid ApplicationProgramId { get; set; }
        public ApplicationProgram? ApplicationProgram { get; set; }
    }
}
