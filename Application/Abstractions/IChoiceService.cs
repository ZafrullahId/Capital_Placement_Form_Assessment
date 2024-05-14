using Application.Model.Dtos.Request;
using Application.Wrapper;

namespace Application.Abstractions
{
    public interface IChoiceService
    {
        Task<Result<bool>> CreateMultipleChoiceOptions(CreateChoiceRequest request, Guid questionId);
    }
}