using InternshipWebAPI.Domain.DTOs;

namespace InternshipWebAPI.Utilities
{
    public class ResponseService : IResponseService
    {
        public APIResponse<T> SuccessResponse<T>(T data, string? message = null)
        {
            return new APIResponse<T>
            {
                Status = true,
                Data = data,
                Message = message ?? "Successful Operation"
            };
        }

        public APIResponse<T> ErrorResponse<T>(string? message = null)
        {
            return new APIResponse<T>
            {
                Status = false,
                Message = message ?? "Something went wrong"
            };
        }
    }

    public interface IResponseService
    {
        APIResponse<T> ErrorResponse<T>(string? message = null);
        APIResponse<T> SuccessResponse<T>(T data, string? message = null);
    }
}
