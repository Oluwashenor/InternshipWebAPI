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
    public class ApplicationTemplateControllerTest
    {
        private readonly IApplicationTemplateService _appService;
        public ApplicationTemplateControllerTest()
        {
            _appService = A.Fake<IApplicationTemplateService>();
        }

        [Fact]
        public async Task App_GetApplication_ReturnOk()
        {
            var fAppService = A.Fake<IApplicationTemplateService>();
            var expectedData = A.Fake<ApplicationTemplateDTO>();
            var expectedAPIResult = new APIResponse<ApplicationTemplateDTO>()
            {
                Data = expectedData,
                Status = true,
                Message = "Successful Operation"
            };
            var programId = Guid.NewGuid().ToString();

            A.CallTo(()=> fAppService.GetApplication(programId)).Returns(Task.FromResult(expectedAPIResult));
            var controller = new ApplicationTemplateController(fAppService);

            var result = await controller.GetApplication(programId);
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            var resultObject = result as OkObjectResult;
            resultObject?.Value.Should().BeEquivalentTo(expectedAPIResult);
            resultObject?.StatusCode.Should().Be(200);

        }

        [Fact]
        public async Task App_UpdateApplication_ReturnOk()
        {
            var fAppService = A.Fake<IApplicationTemplateService>();
            var fCreateAppModel = A.Fake<CreateApplicationTemplateDTO>();
            var expectedAPIResult = new APIResponse<bool>()
            {
                Data = true,
                Status = true,
                Message = "Successful Operation"
            };
            var programId = Guid.NewGuid().ToString();

            A.CallTo(() => fAppService.UpdateApplicationTemplate(programId, fCreateAppModel)).Returns(Task.FromResult(expectedAPIResult));
            var controller = new ApplicationTemplateController(fAppService);

            var result = await controller.PutApplication(programId, fCreateAppModel);
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            var resultObject = result as OkObjectResult;
            resultObject?.Value.Should().BeEquivalentTo(expectedAPIResult);
            resultObject?.StatusCode.Should().Be(200);
        }
    }
}
