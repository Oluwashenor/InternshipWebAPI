﻿using InternshipWebAPI.Domain.DTOs;
using InternshipWebAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternshipWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationTemplateController : ControllerBase
    {
        private readonly IApplicationTemplateService _applicationService;
        public ApplicationTemplateController(IApplicationTemplateService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet("{programId}")]
        public async Task<IActionResult> GetApplication(string programId)
        {
            var application = await _applicationService.GetApplication(programId);
            return Ok(application);
        }
        
        [HttpPut("{programId}")]
        public async Task<IActionResult> PutApplication(string programId, [FromBody] CreateApplicationTemplateDTO model)
        {
            var application = await _applicationService.UpdateApplicationTemplate(programId, model);
            return Ok(application);
        }

        //[HttpPost(Name = "Create Application")]
        //public async Task<IActionResult> CreateApplication([FromBody] CreateApplicationTemplateDTO model)
        //{
        //    var created = await _applicationService.CreateApplicationTemplate(model);
        //    return Ok(created);
        //}
    }
}
