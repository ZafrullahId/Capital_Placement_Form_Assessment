using System.Net;

namespace Application.Exceptions
{
    public class FormWindowNotFoundException : BaseException
    {
        public FormWindowNotFoundException(Guid id) : base($"Application window with id {id} not found", HttpStatusCode.NotFound)
        {
            
        }
    }
}
