using Application.Abstractions;
using Application.Model.Dtos.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionService _submissionService;
        public SubmissionController(ISubmissionService submissionService)
        {
            _submissionService = submissionService;
        }
        /// <summary>
        /// Creates Submission
        /// </summary>
        /// <param name="request"></param>
        /// <param name="formWindowId"></param>
        /// <returns></returns>
        [HttpPost("{formWindowId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSubmissionAsync(CreateSubmissionRequest request, [FromRoute] Guid formWindowId)
        {
            var response = await _submissionService.CreateSubmissionAsync(request, formWindowId);
            return Ok(response);
        }
    }
}
