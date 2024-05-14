using System.Net;

namespace Application.Exceptions
{
    public class ApplicationProgramWindowNotFoundException : BaseException
    {
        public ApplicationProgramWindowNotFoundException(Guid id) : base($"Application window with id {id} not found", HttpStatusCode.NotFound)
        {
            
        }
    }
}
