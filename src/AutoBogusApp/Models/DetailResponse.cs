namespace AutoBogusApp.Models
{
    public record DetailResponse : ISourceResponse
    {
        public Object Response { get; init; } = new();
        public Dictionary<string, string> Metadata { get; init; } = [];
    }
}
