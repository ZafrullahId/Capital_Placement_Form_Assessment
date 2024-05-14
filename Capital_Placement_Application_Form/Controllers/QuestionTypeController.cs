using Application.Abstractions;
using Application.Model.Dtos.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionTypeController : ControllerBase
    {
        private readonly IQuestionTypeService _questionTypeService;
        public QuestionTypeController(IQuestionTypeService questionTypeService)
        {
            _questionTypeService = questionTypeService;
        }
        /// <summary>
        /// Creates Question Type e.g (Paragraph, YesNo, Dropdown, MultipleChoice, Date, Number)
        /// </summary>
        /// <param name="request"></param>
        /// <returns>This endpoint returns bool indicating success value accompanied with a message</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateQuestionTypeAsync(CreateQuestionTypeRequest request)
        {
            var response = await _questionTypeService.CreateQuestionTypeAsync(request);
            return Ok(response);
        }
    }
}
