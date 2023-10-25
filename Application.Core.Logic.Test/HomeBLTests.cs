using Application.Core.DTO.Request;
using Xunit;

namespace Application.Core.Logic.Test
{
    public class HomeBLTests
    {
        [Fact]
        public void Calculate_Should_Return_Valid_Response()
        {
            // Arrange
            var homeBL = new HomeBL();
            var request = new CalculateRequest(firstInput: 3, secondInput: 5, sampleSize: 15);

            // Act
            var response = homeBL.Calculate(request);

            // Assert
            Assert.NotNull(response);
            Assert.NotNull(response.Results);
            Assert.Equal(request.SampleSize + 1, response.Results.Count);
            // Add more specific assertions as needed based on your business logic
        }
    }
}
