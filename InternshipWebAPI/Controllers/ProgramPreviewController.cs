using InternshipWebAPI.Domain.DTOs;
using InternshipWebAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternshipWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgramPreviewController : ControllerBase
    {
        private readonly IProgramTemplateService _programService;
        public ProgramPreviewController(IProgramTemplateService programService)
        {
            _programService = programService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProgram(string id)
        {
            var program = await _programService.GetProgramDetail(id);
            return Ok(program);
        }
    }
}
