using DemoProject.Models;
using DemoProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidatesController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpPost("AddOrUpdateCandidate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddOrUpdateCandidate([FromBody] CandidatesRequest candidateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = await _candidateService.AddOrUpdateCandidateAsync(candidateDto);
            return data.IsSuccess ? Ok("Candidate information saved successfully.") : Problem(data.Errors[0].Message, statusCode: StatusCodes.Status422UnprocessableEntity);
        }
    }
}
