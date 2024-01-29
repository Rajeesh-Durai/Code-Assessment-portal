namespace Judge0.Domain.Model
{
    public class SubmissionApiSettings
    {
        public string BaseUrl { get; set; } = string.Empty;
        public string SubmissionEndpoint { get; set; } = string.Empty;
        public string SubmissionStatusEndpoint { get; set; } = string.Empty;
    }
}
