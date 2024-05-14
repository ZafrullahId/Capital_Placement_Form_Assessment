using System.Net;

namespace Application.Exceptions
{
    public class QuestionNotFoundException : BaseException
    {
        public QuestionNotFoundException(Guid id) : base($"Question with id {id} not found", HttpStatusCode.NotFound)
        {
            
        }
    }
}
