namespace AutoBogusApp.Models
{
    /// <summary>
    /// Represents a standardized error response format.
    /// </summary>
    public record ApiErrorResponse
    {
        /// <summary>
        /// An application-specific error code.
        /// </summary>
        public string Code { get; init; } = string.Empty;

        /// <summary>
        /// A human-readable explanation specific to this occurrence of the problem.
        /// </summary>
        public string Message { get; init; } = string.Empty;

        /// <summary>
        /// Detailed information about the error, potentially including multiple validation failures.
        /// </summary>
        public string Details { get; init; } = string.Empty;
    }
} 