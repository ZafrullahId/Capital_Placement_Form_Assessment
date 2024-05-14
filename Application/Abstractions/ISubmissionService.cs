using Application.Model.Dtos.Request;
using Application.Wrapper;

namespace Application.Abstractions
{
    public interface ISubmissionService
    {
        Task<Result<bool>> CreateSubmissionAsync(CreateSubmissionRequest request, Guid formWindowId);
    }
}