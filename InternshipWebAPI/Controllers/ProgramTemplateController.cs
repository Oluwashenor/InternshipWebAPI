using InternshipWebAPI.Domain.DTOs;
using InternshipWebAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternshipWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramTemplateController : ControllerBase
    {
        private readonly IProgramTemplateService _programService;

        public ProgramTemplateController(IProgramTemplateService programService)
        {
            _programService = programService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProgram(string id)
        {
            APIResponse<ProgramDTO> program = await _programService.GetProgramDetail(id);
            return Ok(program);
        }

        [HttpPost(Name = "Create Program")]
        public async Task<IActionResult> CreateProgram([FromBody] CreateProgramDTO model)
        {
            var created = await _programService.CreateProgram(model);
            return Ok(created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProgram(string id, [FromBody] CreateProgramDTO model)
        {
            var created = await _programService.PutProgram(id, model);
            return Ok(created);
        }
    }
}
