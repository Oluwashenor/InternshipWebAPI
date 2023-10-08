using FakeItEasy;
using FluentAssertions;
using InternshipWebAPI.Controllers;
using InternshipWebAPI.Domain.DTOs;
using InternshipWebAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InternshipWebAPI.Tests.ControllerTests
{
    public class ProgramPreviewControllerTest
    {
        private readonly IProgramTemplateService _programService;
        public ProgramPreviewControllerTest()
        {
            _programService = A.Fake<IProgramTemplateService>();
        }

        [Fact]
        public async Task ProgramPreview_GetProgram_ReturnOk()
        {
            var fWorkflowService = A.Fake<IProgramTemplateService>();
            var fProgramService = A.Fake<IProgramTemplateService>();
            var expectedData = A.Fake<ProgramDTO>();
            var expectedAPIResult = new APIResponse<ProgramDTO>()
            {
                Data = expectedData,
                Status = true,
                Message = "Successful Operation"
            };
            var programId = Guid.NewGuid().ToString();

            A.CallTo(() => fProgramService.GetProgramDetail(programId)).Returns(Task.FromResult(expectedAPIResult));
            var controller = new ProgramTemplateController(fProgramService);

            var result = await controller.GetProgram(programId);
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            var resultObject = result as OkObjectResult;
            resultObject?.Value.Should().BeEquivalentTo(expectedAPIResult);
            resultObject?.StatusCode.Should().Be(200);

        }
    }
}
