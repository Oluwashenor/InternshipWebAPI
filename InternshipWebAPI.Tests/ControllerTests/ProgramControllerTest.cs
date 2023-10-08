using FakeItEasy;
using FluentAssertions;
using InternshipWebAPI.Controllers;
using InternshipWebAPI.Domain.DTOs;
using InternshipWebAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipWebAPI.Tests.ControllerTests
{
    public class ProgramControllerTest
    {
        private readonly IProgramTemplateService _programService;
        public ProgramControllerTest()
        {
            _programService = A.Fake<IProgramTemplateService>();
        }

        [Fact]
        public async Task Program_GetProgram_ReturnOk()
        {
            var fProgramService = A.Fake<IProgramTemplateService>();
            var expectedData = A.Fake<ProgramDTO>();
            var expectedAPIResult = new APIResponse<ProgramDTO>()
            {
                Data = expectedData,
                Status = true,
                Message = "Successful Operation"
            };
            var programId = Guid.NewGuid().ToString();

            A.CallTo(()=> fProgramService.GetProgramDetail(programId)).Returns(Task.FromResult(expectedAPIResult));
            var controller = new ProgramTemplateController(fProgramService);

            var result = await controller.GetProgram(programId);
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            var resultObject = result as OkObjectResult;
            resultObject?.Value.Should().BeEquivalentTo(expectedAPIResult);
            resultObject?.StatusCode.Should().Be(200);

        }

        [Fact]
        public async Task Program_UpdateProgram_ReturnOk()
        {
            var fProgramService = A.Fake<IProgramTemplateService>();
            var fCreateProgramModel = A.Fake<CreateProgramDTO>();
            var expectedData = A.Fake<ProgramDTO>();
            var expectedAPIResult = new APIResponse<ProgramDTO>()
            {
                Data = expectedData,
                Status = true,
                Message = "Successful Operation"
            };
            var programId = Guid.NewGuid().ToString();

            A.CallTo(() => fProgramService.PutProgram(programId, fCreateProgramModel)).Returns(Task.FromResult(expectedAPIResult));
            var controller = new ProgramTemplateController(fProgramService);

            var result = await controller.PutProgram(programId, fCreateProgramModel);
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            var resultObject = result as OkObjectResult;
            resultObject?.Value.Should().BeEquivalentTo(expectedAPIResult);
            resultObject?.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Program_CreateProgram_ReturnOk()
        {
            var fProgramService = A.Fake<IProgramTemplateService>();
            var fCreateProgramModel = A.Fake<CreateProgramDTO>();
            var expectedData = A.Fake<ProgramDTO>();
            var expectedAPIResult = new APIResponse<ProgramDTO>()
            {
                Data = expectedData,
                Status = true,
                Message = "Successful Operation"
            };
            var programId = Guid.NewGuid().ToString();

            A.CallTo(() => fProgramService.CreateProgram(fCreateProgramModel)).Returns(Task.FromResult(expectedAPIResult));
            var controller = new ProgramTemplateController(fProgramService);

            var result = await controller.CreateProgram(fCreateProgramModel);
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            var resultObject = result as OkObjectResult;
            resultObject?.Value.Should().BeEquivalentTo(expectedAPIResult);
            resultObject?.StatusCode.Should().Be(200);
        }
    }
}
