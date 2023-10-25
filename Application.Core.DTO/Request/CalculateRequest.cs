namespace Application.Core.DTO.Request
{
    public sealed class CalculateRequest
    {
        public int FirstInput { get; }
        public int SecondInput { get; }
        public int SampleSize { get; }

        public CalculateRequest(int firstInput, int secondInput, int sampleSize)
        {
            FirstInput = firstInput;
            SecondInput = secondInput;
            SampleSize = sampleSize;
        }
    }
}
