using Application.Abstractions;
using Application.Model.Dtos.Request;
using Application.Wrapper;
using Domain.Entity;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class QuestionTypeService : IQuestionTypeService
    {
        private readonly IQuestionTypeRepository _questionTypeRepository;
        public QuestionTypeService(IQuestionTypeRepository questionTypeRepository)
        {
            _questionTypeRepository = questionTypeRepository;
        }
        public async Task<Result<bool>> CreateQuestionTypeAsync(CreateQuestionTypeRequest request)
        {
            var optionType = request.Adapt<QuestionType>();
            await _questionTypeRepository.CreateAsync(optionType);
            await _questionTypeRepository.SaveChangesAsync();
            return await Result<bool>.SuccessAsync();
        }
    }
}
