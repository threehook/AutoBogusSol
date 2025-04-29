using System.Text.Json.Serialization;

namespace AutoBogusApp.Models
{
    public record MatchResponse : ISourceResponse
    {
        public List<Object> Response { get; init; } = [];
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public bool More { get; set; } = false;
        public Dictionary<string, string> Metadata { get; init; } = [];
    }
}