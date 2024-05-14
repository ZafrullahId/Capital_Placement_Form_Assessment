using Domain.Contracts;

namespace Domain.Entity
{
    public class Question : AuditableEntity
    {
        public string Text { get; set; } = default!;
        public Guid QuestionTypeId { get; set; }
        public Guid FormWindowId { get; set; }
        public Guid? ChoiceId { get; set; }
    }
}
