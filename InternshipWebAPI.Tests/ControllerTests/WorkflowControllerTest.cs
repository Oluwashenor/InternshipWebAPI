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
    public class WorkflowControllerTest
    {
        private readonly IWorkflowService _workflowService;
        public WorkflowControllerTest()
        {
            _workflowService = A.Fake<IWorkflowService>();
        }

        [Fact]
        public async Task Workflow_GetWorkflow_ReturnOk()
        {
            var fWorkflowService = A.Fake<IWorkflowService>();
            var expectedData = A.Fake<WorkflowDTO>();
            var expectedAPIResult = new APIResponse<WorkflowDTO>()
            {
                Data = expectedData,
                Status = true,
                Message = "Successful Operation"
            };
            var programId = Guid.NewGuid().ToString();

            A.CallTo(()=> fWorkflowService.GetWorkflow(programId)).Returns(Task.FromResult(expectedAPIResult));
            var controller = new WorkflowController(fWorkflowService);

            var result = await controller.GetWorkflow(programId);
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            var resultObject = result as OkObjectResult;
            resultObject?.Value.Should().BeEquivalentTo(expectedAPIResult);
            resultObject?.StatusCode.Should().Be(200);

        }

        [Fact]
        public async Task Workflow_UpdateWorkflow_ReturnOk()
        {
            var fWorkflowService = A.Fake<IWorkflowService>();
            var fCreateAppModel = A.Fake<CreateWorkFlowDTO>();
            var expectedAPIResult = new APIResponse<bool>()
            {
                Data = true,
                Status = true,
                Message = "Successful Operation"
            };
            var programId = Guid.NewGuid().ToString();

            A.CallTo(() => fWorkflowService.UpdateWorkflow(programId, fCreateAppModel)).Returns(Task.FromResult(expectedAPIResult));
            var controller = new WorkflowController(fWorkflowService);

            var result = await controller.UpdateWorkFlow(programId, fCreateAppModel);
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            var resultObject = result as OkObjectResult;
            resultObject?.Value.Should().BeEquivalentTo(expectedAPIResult);
            resultObject?.StatusCode.Should().Be(200);
        }
    }
}
