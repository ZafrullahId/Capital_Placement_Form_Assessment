using Application.Abstractions;
using Application.Model.Dtos.Request;
using Application.Model.Dtos.Response;
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
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IFormWindowRepository _formWindowRepository;
        private readonly IChoiceRepository _choiceRepository;
        public QuestionService(IQuestionRepository questionRepository, IFormWindowRepository formWindowRepository, IChoiceRepository choiceRepository)
        {
            _questionRepository = questionRepository;
            _formWindowRepository = formWindowRepository;
            _choiceRepository = choiceRepository;
        }
        public async Task<Result<bool>> CreateQuestionAsync(CreateQuestionRequest request, Guid formWindowId)
        {
            var formWindow = await _formWindowRepository.GetAsync(x => x.Id == formWindowId);
            if (formWindow is not null)
            {
                var newQuestion = request.Adapt<Question>();
                newQuestion.FormWindowId = formWindowId;
                await _questionRepository.CreateAsync(newQuestion);
                await _questionRepository.SaveChangesAsync();
                return await Result<bool>.SuccessAsync("Question Successfully Created");
            }
            return await Result<bool>.FailAsync("From Window not found");
        }
        public async Task<Result<bool>> UpdateQuestionAsync(UpdateQuestionRequest request, Guid questionId)
        {
            var question = await _questionRepository.GetAsync(x => x.Id == questionId);
            if (question is not null)
            {
                question.Text = request.Text ?? question.Text;
                await _questionRepository.UpdateAsync(question);
                return await Result<bool>.SuccessAsync("Question Successfully Updated");
            }
            return await Result<bool>.FailAsync();
        }
        public async Task<Result<List<QuestionResponse>>> GetQuestionsByFormWindowIdAsync(Guid formWindowId)
        {
            var formWindow = await _formWindowRepository.GetAsync(x => x.Id == formWindowId);
            if (formWindow is not null)
            {
                var questions = await _questionRepository.GetQuestionsAsync(formWindowId);
                var questionResponseDto = questions.Adapt<List<QuestionResponse>>();
                foreach (var questionResponse in questionResponseDto)
                {
                    var response = await _choiceRepository.GetAsync(x => x.Id == questionResponse.ChoiceId);
                    questionResponse.ChoiceResponse = response.Adapt<ChoiceResponse>();
                }
                questionResponseDto.Select(x => x.ChoiceResponse = _choiceRepository.GetAsync(y => y.Id == x.ChoiceId).GetAwaiter().Adapt<ChoiceResponse>());
                return await Result<List<QuestionResponse>>.SuccessAsync(questionResponseDto);
            }
            return await Result<List<QuestionResponse>>.FailAsync("Form Window not found");
        }

    }
}
