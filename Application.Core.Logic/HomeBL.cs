using Application.Core.DTO.Models;
using Application.Core.DTO.Request;
using Application.Core.DTO.Response;
using Application.Core.Interface;

namespace Application.Core.Logic
{
    public sealed class HomeBL : IHome
    {
        public CalculateResponse Calculate(CalculateRequest request)
        {
            CalculateResponse response = new();
            response.Results = new List<Result>();

            int totalItems = request.SampleSize + 1;

            for (int i = 0; i < totalItems; i++)
            {
                Result result = new();

                switch (i)
                {
                    case var _ when i % request.FirstInput == 0 && i % request.SecondInput == 0:
                        result.Value = i;
                        result.Message = "I don't know";
                        break;
                    case var _ when i % request.SecondInput == 0:
                        result.Value = i;
                        result.Message = "No";
                        break;
                    case var _ when i % request.FirstInput == 0:
                        result.Value = i;
                        result.Message = "Yes";
                        break;                    
                    default:
                        result.Value = i;
                        result.Message = "N/A";
                        break;
                }

                response.Results.Add(result);
            }

            response.TotalItems = totalItems;
            response.HasMoreItems = response.Page < response.TotalPages;

            return response;
        }
    }
}
