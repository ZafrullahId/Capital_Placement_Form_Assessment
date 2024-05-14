using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class ApplicationResponse
    {
        public Guid QuestionId { get; set; }
        public string Response {  get; set; }
    }
}
