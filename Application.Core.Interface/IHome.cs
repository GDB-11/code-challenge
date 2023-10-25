using Application.Core.DTO.Request;
using Application.Core.DTO.Response;

namespace Application.Core.Interface
{
    public interface IHome
    {
        CalculateResponse Calculate(CalculateRequest request);
    }
}
