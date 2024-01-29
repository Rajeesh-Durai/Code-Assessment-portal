namespace Judge0.Domain.DTO
{
    public class SubmissionDTO
    {
        public int language_id { get; set; }
        public string source_code { get; set; } = string.Empty;
        public string std_in { get; set; } = string.Empty;
        public string expected_output { get; set; } = string.Empty;
        public string token { get; set; } = string.Empty;
    }
}
