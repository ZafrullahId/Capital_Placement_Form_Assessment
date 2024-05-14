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
    public class ChoiceService : IChoiceService
    {
        private readonly IChoiceRepository _choiceRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IQuestionTypeRepository _questionTypeRepository;
        public ChoiceService(IChoiceRepository choiceRepository, IQuestionRepository questionRepository, IQuestionTypeRepository questionTypeRepository)
        {
            _choiceRepository = choiceRepository;
            _questionRepository = questionRepository;
            _questionTypeRepository = questionTypeRepository;
        }
        public async Task<Result<bool>> CreateMultipleChoiceOptions(CreateChoiceRequest request, Guid questionId)
        {
            var question = await _questionRepository.GetAsync(x => x.Id == questionId);
            if (question is not null)
            {
                var questionType = await _questionTypeRepository.GetAsync(x => x.Id == question.QuestionTypeId);
                if (questionType is not null && questionType.TypeName != "MultipleChoice")
                    return await Result<bool>.FailAsync("Question Answer Type must be MultipleChoice");
                var choice = request.Adapt<Choice>();
                choice.QuestionId = questionId;
                question.ChoiceId = choice.Id;
                await _choiceRepository.CreateAsync(choice);
                await _choiceRepository.SaveChangesAsync();
                return await Result<bool>.SuccessAsync("Choices Successfully Created");
            }
            return await Result<bool>.FailAsync("Choice Question not found");
        }

    }
}
