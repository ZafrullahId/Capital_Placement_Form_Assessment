using Application.Model.Dtos.Request;
using Application.Wrapper;

namespace Application.Abstractions
{
    public interface IQuestionTypeService
    {
        Task<Result<bool>> CreateQuestionTypeAsync(CreateQuestionTypeRequest request);
    }
}