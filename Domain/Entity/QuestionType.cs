using Domain.Contracts;

namespace Domain.Entity
{
    public class QuestionType : AuditableEntity
    {
        public string TypeName { get; set; } = default!;
    }
}
