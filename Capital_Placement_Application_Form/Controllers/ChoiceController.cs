using Application.Abstractions;
using Application.Model.Dtos.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoiceController : ControllerBase
    {
        private readonly IChoiceService _choiceService;
        public ChoiceController(IChoiceService choiceService)
        {
            _choiceService = choiceService;
        }
        /// <summary>
        /// Creates Multiple Choice Options for a question
        /// </summary>
        /// <param name="request"></param>
        /// <param name="questionId"></param>
        /// <returns>This endpoint returns bool indicating success value accompanied with a message</returns>
        [HttpPost("{questionId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateMultipleChoiceAsync(CreateChoiceRequest request, Guid questionId)
        {
            var response = await _choiceService.CreateMultipleChoiceOptions(request, questionId);
            return Ok(response);
        }
    }
}
