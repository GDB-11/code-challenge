using System.Text.Json.Serialization;

namespace Application.Core.DTO.Models
{
    public sealed class Result
    {
        [JsonPropertyName("value")]
        public int Value { get; set; }

        [JsonPropertyName("result")]
        public string Message { get; set; }

        [JsonPropertyName("pageNumber")]
        public string PageNumber { get; set; }

        [JsonPropertyName("pageSize")]
        public string pageSize { get; set; }
    }
}
