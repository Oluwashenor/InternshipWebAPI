using InternshipWebAPI.Domain.DTOs;
using InternshipWebAPI.Domain.Models;
using static System.Net.Mime.MediaTypeNames;

namespace InternshipWebAPI.Utilities
{
    public static class SharedMapping
    {
        public static ProgramDTO ProgramMapToDTO(ProgramTemplate program)
        {
            return new ProgramDTO()
            {
                Id = program.Id,
                Created = program.Created,
                Title = program.Title,
                Description = program.Description,
            };
        }

        public static ProgramDTO MapToDTO(this ProgramTemplate program, Workflow workflow, ApplicationFormTemplate applicationForm)
        {
            return new ProgramDTO()
            {
                Id = program.Id,
                Created = program.Created,
                Title = program.Title,
                Description = program.Description,
                Workflow = workflow == null ? null : new WorkflowDTO()
                {
                    Id = workflow.Id,
                    ProgramTemplateId = workflow.ProgramTemplateId,
                    Workflows = workflow.Workflows,
                },
                ApplicationTemplate = applicationForm == null ? null : new ApplicationTemplateDTO()
                {
                    Id = applicationForm.Id,
                    ProgramTemplateId = applicationForm.ProgramTemplateId,
                    Education = applicationForm.Education,
                    Resume = applicationForm.Resume,
                    Experience = applicationForm.Experience,
                    Questions = applicationForm.PersonalInfoQuestions
                }
            };
        }

        public static ProgramTemplate MapToModel(this CreateProgramDTO model)
        {

            return new ProgramTemplate()
            {
                Title = model.Title,
                Skills = model.Skills,
                ProgramType = model.ProgramType,
                Description = model.Description,
                Benefit = model.Benefit,
                Criteria = model.Criteria,
                MaxApplicant = model.MaxApplicant,
                Location = model.Location,
                Remote = model.Remote,
                ApplicationTemplate = model?.ApplicationTemplate?.MapToModel(),
                Workflow = model?.Workflow?.MapToModel()
        };
        }

        public static Workflow MapToModel(this CreateWorkFlowDTO model)
        {
            if (model == null) return null;
            return new Workflow()
            {
                Workflows = model?.Workflows
            };
        }

        public static ApplicationFormTemplate MapToModel(this CreateApplicationTemplateDTO model)
        {
            if (model == null) return null;
            return new ApplicationFormTemplate()
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
                ProgramTemplateId = model.ProgramId,
            };
        }

        public static ApplicationTemplateDTO MapToDTO(this ApplicationFormTemplate model)
        {
            return new ApplicationTemplateDTO()
            {
                Id = model?.Id,
                Questions = model?.PersonalInfoQuestions,
                Education = model?.Education,
                Resume = model?.Resume,
                Experience = model?.Experience,
            };
        }

    }
}
