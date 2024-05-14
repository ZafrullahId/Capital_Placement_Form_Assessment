using Application.Model.Dtos.Request;
using Application.Wrapper;

namespace Application.Abstractions
{
    public interface IApplicationProgramService
    {
        Task<Result<bool>> CreateApplicationProgramWindowAsync(CreateApplicationProgramRequest request);
        Task<Result<bool>> UpdateApplicationProgramWindowAsync(UpdateApplicationProgramRequest request, Guid applicationProgramWindowId);
    }
}