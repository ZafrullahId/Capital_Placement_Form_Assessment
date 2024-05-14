using Application.Abstractions;
using Application.Model.Dtos.Request;
using Application.Model.Dtos.Response;
using Application.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        /// <summary>
        /// Creates additional application questions
        /// </summary>
        /// <param name="request"></param>
        /// <param name="formWindowId"></param>
        /// <returns>This endpoint returns bool indicating success value accompanied with a message </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateQuestionAsync(CreateQuestionRequest request, [FromRoute] Guid formWindowId)
        {
            var response = await _questionService.CreateQuestionAsync(request, formWindowId);
            return Ok(response);
        }
        /// <summary>
        /// Updates a question based on the questionId
        /// </summary>
        /// <param name="request"></param>
        /// <param name="questionId"></param>
        /// <returns>This endpoint returns bool indicating success value accompanied with a message</returns>
        /// [HttpGet("{formWindowId}")]
        [HttpPut("{questionId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateQuestionAsync(UpdateQuestionRequest request, [FromRoute] Guid questionId)
        {
            var response = await _questionService.UpdateQuestionAsync(request, questionId);
            return Ok(response);
        }
        /// <summary>
        /// Get all questions base on the formWindowId
        /// </summary>
        /// <param name="formWindowId"></param>
        /// <returns>This endpoint returns a list of Questions</returns>
        [HttpGet("{formWindowId}")]
        [ProducesResponseType(typeof(Result<List<QuestionResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<List<object>>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetQuestionsAsync(Guid formWindowId)
        {
            var response = await _questionService.GetQuestionsByFormWindowIdAsync(formWindowId);
            return Ok(response);
        }
    }
}
