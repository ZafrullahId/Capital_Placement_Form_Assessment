using Domain.Contracts;

namespace Domain.Entity
{
    public class Choice : AuditableEntity
    {
        public Guid QuestionId { get; set; }
        public List<string> Options { get; set; } = [];
        public int MaxChoiceAllowed { get; set; }
    }
}
