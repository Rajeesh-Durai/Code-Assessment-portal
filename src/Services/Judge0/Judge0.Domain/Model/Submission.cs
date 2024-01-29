namespace Judge0.Domain.Model
{
    public class Submission
    {
        public int language_id { get; set; }
        public string source_code { get; set; } = string.Empty;
        public string stdin { get; set; } = string.Empty;
        public string expected_output { get; set; } = string.Empty;
    }
}
