using Application.Core.DTO.Models;
using System.Text.Json.Serialization;

namespace Application.Core.DTO.Response
{
    public sealed class CalculateResponse
    {
        [JsonPropertyName("page")]
        public int? Page { get; set; } = null;

        [JsonPropertyName("totalItems")]
        public int TotalItems { get; set; }

        [JsonPropertyName("totalPages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("hasMoreItems")]
        public bool HasMoreItems { get; set; }

        [JsonPropertyName("results")]
        public List<Result> Results { get; set; } = null!;
    }
}
