using Application.Model.Dtos.Request;
using Application.Model.Dtos.Response;
using Application.Wrapper;

namespace Application.Abstractions
{
    public interface IQuestionService
    {
        Task<Result<bool>> UpdateQuestionAsync(UpdateQuestionRequest request, Guid questionId);
        Task<Result<List<QuestionResponse>>> GetQuestionsByFormWindowIdAsync(Guid formWindowId);
        Task<Result<bool>> CreateQuestionAsync(CreateQuestionRequest request, Guid formWindowId);
    }
}