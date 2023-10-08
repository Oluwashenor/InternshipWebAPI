using InternshipWebAPI.Data;
using InternshipWebAPI.Domain.DTOs;
using InternshipWebAPI.Domain.Models;
using InternshipWebAPI.Repository.Interfaces;
using InternshipWebAPI.Utilities;
using Microsoft.EntityFrameworkCore;

namespace InternshipWebAPI.Repository.Services
{
    public class ApplicationTemplateService : IApplicationTemplateService
    {
        private readonly AppDbContext _context;
        private readonly IResponseService _responseService;

        public ApplicationTemplateService(AppDbContext context, IResponseService responseService)
        {
            _context = context;
            _responseService = responseService;
        }

        public async Task<APIResponse<ApplicationTemplateDTO>> GetApplication(string programId)
        {
            var application = await _context.ApplicationFormTemplates.FirstOrDefaultAsync(x => x.ProgramTemplateId == programId);
            if (application == null)
                return _responseService.ErrorResponse<ApplicationTemplateDTO>("Application not found");
            var program = await _context.ProgramTemplates.FindAsync(application?.ProgramTemplateId);
            var response = new ApplicationTemplateDTO()
            {
                Id = application?.Id,
                ProgramTitle = program?.Title,
                ProgramTemplateId = program?.Id,
                Questions = application?.PersonalInfoQuestions,
                Education = application?.Education,
                Resume = application?.Resume,
                Experience = application?.Experience,
            };
            return _responseService.SuccessResponse(response);
        }

        public async Task<APIResponse<bool>> CreateApplicationTemplate(CreateApplicationTemplateDTO model)
        {
            var validateModel = ValidateModel(model);
            if (!validateModel.Status)
                return _responseService.ErrorResponse<bool>(validateModel.Message);
            var program = new ApplicationFormTemplate()
            {
                PersonalInfoQuestions = model?.Questions?.Select(x =>
                new QuestionBlock
                {
                    QuestionType = x.QuestionType,
                    IsRequired = x.IsRequired,
                    Question = x.Question,
                    AdditionalField = x.AdditionalField
                }).ToList(),
                Education = model?.Education,
                Experience = model?.Experience,
                Resume = model?.Resume,
                ProgramTemplateId = model.ProgramTemplateId,
            };
            await _context.AddAsync(program);
            await _context.SaveChangesAsync();
            return _responseService.SuccessResponse(true);
        }

        public async Task<APIResponse<bool>> UpdateApplicationTemplate(string programId, CreateApplicationTemplateDTO model)
        {
            var validateModel = ValidateModel(model);
            if (!validateModel.Status)
                return _responseService.ErrorResponse<bool>(validateModel.Message);
            ApplicationFormTemplate formTemplate = await _context.ApplicationFormTemplates.FirstOrDefaultAsync(x => x.ProgramTemplateId == programId);
            if (formTemplate == null)
                return _responseService.ErrorResponse<bool>("Application Form Not Found");
            var formTemplateNew = new ApplicationFormTemplate()
            {
                PersonalInfoQuestions = model?.Questions?.Select(x =>
                new QuestionBlock
                {
                    QuestionType = x.QuestionType,
                    IsRequired = x.IsRequired,
                    Question = x.Question,
                    AdditionalField = x.AdditionalField
                }).ToList(),
                Education = model?.Education,
                Experience = model?.Experience,
                Resume = model?.Resume,
                ProgramTemplateId = formTemplate.ProgramTemplateId,
            };
            _context.Remove(formTemplate);
            await _context.AddAsync(formTemplateNew);
            await _context.SaveChangesAsync();
            return _responseService.SuccessResponse(true);
        }

        private APIResponse<CreateApplicationTemplateDTO> ValidateModel(CreateApplicationTemplateDTO model)
        {
            if (model.ProgramTemplateId == default || model.ProgramTemplateId == "string")
            {
                return _responseService.ErrorResponse<CreateApplicationTemplateDTO>("Program Id is Required");
            }
            if (!model.Education.IsRequired)
            {
                model.Education.Questions = null;
            }
            else
            {
                if (model.Education.Questions == null || !model.Education.Questions.Any())
                {
                    return _responseService.ErrorResponse<CreateApplicationTemplateDTO>("Education Questions cannot be empty since Education is Required");
                }
            }
            if (!model.Experience.IsRequired)
            {
                model.Experience.Questions = null;
            }
            else
            {
                if (model.Experience.Questions == null || !model.Experience.Questions.Any())
                {
                    return _responseService.ErrorResponse<CreateApplicationTemplateDTO>("Experience Questions cannot be empty since Experience is Required");
                }
            }
            if (!model.Resume.IsRequired)
            {
                model.Resume.Questions = null;
            }
            else
            {
                if (model.Resume.Questions == null || !model.Resume.Questions.Any())
                {
                    return _responseService.ErrorResponse<CreateApplicationTemplateDTO>("Resume Questions cannot be empty since Resume is Required");
                }
            }
            return _responseService.SuccessResponse(model);
        }
    }

}
